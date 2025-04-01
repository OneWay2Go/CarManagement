using Microsoft.EntityFrameworkCore;
using piyoz.uz.DataAccess.Entities;

namespace piyoz.uz.DataAccess.Repositories
{
    public interface IDriverRepository
    {
        Task AddAsync(Driver driver);

        Task<Driver> GetById(int id);

        Task<IList<Driver>> GetAll();

        void Update(Driver driver);

        void Delete(Driver driver);

        void SaveChanges();

        Task SaveChangesAsync();
    }

    public class DriverRepository(DataContext context) : IDriverRepository
    {
        public async Task AddAsync(Driver driver)
        {
            await context.Drivers.AddAsync(driver);
        }

        public void Delete(Driver driver)
        {
            context.Drivers.Remove(driver);
        }

        public async Task<IList<Driver>> GetAll()
        {
            return await context.Drivers.ToListAsync();
        }

        public async Task<Driver> GetById(int id)
        {
            return await context.Drivers.FirstOrDefaultAsync(d => d.Id == id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Update(Driver driver)
        {
            context.Update(driver);
        }
    }
}
