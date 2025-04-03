using Microsoft.EntityFrameworkCore;
using piyoz.uz.DataAccess.Entities;

namespace piyoz.uz.DataAccess
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Rental> Rentals { get; set; }
    }
}
