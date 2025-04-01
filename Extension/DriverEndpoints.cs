using piyoz.uz.DataAccess.Repositories;
using piyoz.uz.Dtos;
using piyoz.uz.Maps;

namespace piyoz.uz.Extension
{
    public static class DriverEndpoints
    {
        public static IEndpointRouteBuilder MapDriverEndpoints(this IEndpointRouteBuilder app)
        {
            // Driver minimal api

            // get all
            app.MapGet("/drivers", async (IDriverRepository driverRepository) =>
            {
                var drivers = await driverRepository.GetAll();

                var driverMapper = new DriverMapper();

                var driversDto = driverMapper.DriverListToDriverDtoList(drivers);

                return Results.Ok(driversDto);
            });

            // get by id
            app.MapGet("/drivers/{id}", async (int id, IDriverRepository driverRepository) =>
            {
                var driver = await driverRepository.GetById(id);

                if (driver is null)
                {
                    Results.NotFound();
                }

                var driverMapper = new DriverMapper();

                var driverDto = driverMapper.DriverToDriverDto(driver);

                return Results.Ok(driverDto);
            });

            // create a driver
            app.MapPost("/drivers/add", async (DriverDto dto, IDriverRepository driverRepository) =>
            {
                var driverMapper = new DriverMapper();

                var driver = driverMapper.DriverDtoToDriver(dto);

                await driverRepository.AddAsync(driver);
                await driverRepository.SaveChangesAsync();

                return Results.Created();
            });

            // update a driver
            app.MapPut("/drivers/{id}", async (int id, DriverDto dto, IDriverRepository driverRepository) =>
            {
                var existingDriver = await driverRepository.GetById(id);

                if (existingDriver is null)
                {
                    Results.NotFound();
                }

                var driverMapper = new DriverMapper();
                driverMapper.UpdateDriver(dto, existingDriver);

                driverRepository.Update(existingDriver);
                await driverRepository.SaveChangesAsync();

                return Results.Ok(driverMapper.DriverToDriverDto(existingDriver));
            });

            // delete a driver
            app.MapDelete("/drivers/{id}", async (int id, IDriverRepository driverRepository) =>
            {
                var driver = await driverRepository.GetById(id);

                if (driver is null)
                {
                    Results.NotFound();
                }

                driverRepository.Delete(driver);
                await driverRepository.SaveChangesAsync();

                return Results.Ok("Deleted!");
            });

            return app;
        } 
    }
}
