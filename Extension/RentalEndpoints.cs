using Microsoft.AspNetCore.Mvc;
using piyoz.uz.DataAccess.Entities;
using piyoz.uz.DataAccess.Repositories;
using piyoz.uz.Dtos;
using piyoz.uz.Maps;
using System.Reflection;

namespace piyoz.uz.Extension
{
    public static class RentalEndpoints
    {
        public static IEndpointRouteBuilder MapRentalEndpoints(this IEndpointRouteBuilder app)
        {
            // Rental minimal api
            // get all (pagination)
            app.MapGet("/rentals", async (int pageSize, int pageNumber, IRentalRepository rentalRepository) =>
            {
                var rentals = await rentalRepository.GetAll();

                var paginatedRentals = rentals
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var rentalMapper = new RentalMapper();
                var rentalsDto = rentalMapper.RentalListToRentalDtoList(paginatedRentals);

                var paginatedDate = new PaginatedData<RentalDto>
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = rentals.Count,
                    Data = rentalsDto
                };

                return Results.Ok(paginatedDate);
            });

            // get all (filtering)
            app.MapGet("/rentals/search", async (string? searchBy, string? searchKey, IRentalRepository rentalRepository) =>
            {
                var rentals = await rentalRepository.GetAll();

                if (string.IsNullOrEmpty(searchBy) && string.IsNullOrEmpty(searchKey))
                {
                    var mapper = new RentalMapper();
                    var dtos = mapper.RentalListToRentalDtoList(rentals);

                    return Results.Ok(dtos);
                }

                var filteredRentals = rentals
                    .Where(r => r.GetType().GetProperty(searchBy).GetValue(r).ToString().Contains(searchKey)).ToList();

                var rentalMapper = new RentalMapper();
                var rentalsDto = rentalMapper.RentalListToRentalDtoList(filteredRentals);

                return Results.Ok(rentalsDto);
            });

            // get by id
            app.MapGet("/rentals/{id}", async (int id, IRentalRepository rentalRepository) =>
            {
                var rental = await rentalRepository.GetById(id);

                if (rental is null)
                {
                    return Results.NotFound();
                }

                var rentalMapper = new RentalMapper();
                var rentalDto = rentalMapper.RentalToRentalDto(rental);

                return Results.Ok(rentalDto);
            });

            // create a rental
            app.MapPost("/rentals/add", async (CreateRentalDto dto, IRentalRepository rentalRepository, ICarRepository carRepository) =>
            {
                var rentalMapper = new RentalMapper();
                var rental = rentalMapper.RentalDtoToRental(dto);

                // check if car exists 
                var car = await carRepository.GetById(dto.CarId);

                if (car is null)
                {
                    return Results.NotFound("This car does not exists!");
                }
                else if (!car.IsAvailable)
                {
                    return Results.BadRequest("This car is not available!");
                }

                // calculate total price
                rental.TotalPrice = (decimal)(rental.EndDate - rental.StartDate).TotalDays * car.DailyRate;

                // set car availability
                car.IsAvailable = false;

                // update car availability
                carRepository.Update(car);

                await rentalRepository.AddAsync(rental);
                await rentalRepository.SaveChangesAsync();
                await carRepository.SaveChangesAsync();

                return Results.Ok(rentalMapper.RentalToRentalDto(rental));
            });

            // update a rental
            app.MapPut("/rentals/{id}", async (int id, CreateRentalDto dto, IRentalRepository rentalRepository) =>
            {
                var existingRental = await rentalRepository.GetById(id);
                if (existingRental is null)
                {
                    return Results.NotFound();
                }
                var rentalMapper = new RentalMapper();
                rentalMapper.UpdateRental(dto, existingRental);
                await rentalRepository.SaveChangesAsync();
                return Results.NoContent();
            });

            return app;
        }
    }
}
