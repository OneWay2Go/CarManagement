using piyoz.uz.DataAccess.Repositories;
using piyoz.uz.Dtos;
using piyoz.uz.Maps;

namespace piyoz.uz.Extension
{
    public static class CarEndpoints
    {
        public static IEndpointRouteBuilder MapCarEndpoints(this IEndpointRouteBuilder app)
        {
            // Car minimal api

            // get all
            app.MapGet("/cars", async (ICarRepository carRepository) =>
            {
                var cars = await carRepository.GetAll();

                var carMapper = new CarMapper();

                var carsDto = carMapper.CarListToCarDtoList(cars);

                return Results.Ok(carsDto);
            });

            // create a car
            app.MapPost("/cars/add", async (CreateCarDto dto, ICarRepository carRepository) =>
            {
                var carMapper = new CarMapper();

                var car = carMapper.CarDtoToCar(dto);

                await carRepository.AddAsync(car);
                await carRepository.SaveChangesAsync();
            });

            // get by id
            app.MapGet("/cars/{id}", async (int id, ICarRepository carRepository) =>
            {
                var car = await carRepository.GetById(id);

                if (car is null)
                {
                    return Results.NotFound();
                }

                var carMapper = new CarMapper();
                var carDto = carMapper.CarToCarDto(car);

                return Results.Ok(carDto);
            });

            // update a car
            app.MapPut("/cars/{id}", async (int id, CreateCarDto dto, ICarRepository carRepository) =>
            {
                var existingCar = await carRepository.GetById(id);

                if (existingCar is null)
                {
                    Results.NotFound();
                }

                var carMapper = new CarMapper();
                carMapper.UpdateCar(dto, existingCar);

                carRepository.Update(existingCar);
                await carRepository.SaveChangesAsync();

                return Results.Ok(carMapper.CarToCarDto(existingCar));
            });

            // delete a car
            app.MapDelete("/cars/{id}", async (int id, ICarRepository carRepository) =>
            {
                var existingCar = await carRepository.GetById(id);

                if (existingCar is null)
                {
                    Results.NotFound();
                }

                carRepository.Delete(existingCar);
                await carRepository.SaveChangesAsync();

                return Results.Ok("Deleted!");
            });

            return app;
        }
    }
}
