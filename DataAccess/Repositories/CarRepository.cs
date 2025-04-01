using Microsoft.EntityFrameworkCore;
using piyoz.uz.DataAccess.Entities;

namespace piyoz.uz.DataAccess.Repositories
{
    public interface ICarRepository
    {
        Task AddAsync(Car car);

        Task<Car> GetById(int id);

        Task<IList<Car>> GetAll();

        void Update(Car car);

        void Delete(Car car);

        void SaveChanges();

        Task SaveChangesAsync();
    }

    public class CarRepository(DataContext context) : ICarRepository
    {
        public async Task AddAsync(Car car)
        {
            await context.Cars.AddAsync(car);
        }

        public async Task<Car> GetById(int id)
        {
            return await context.Cars.FindAsync(id);
        }

        public async Task<IList<Car>> GetAll()
        {
            return await context.Cars.ToListAsync();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Update(Car car)
        {
            context.Update(car);
        }

        public void Delete(Car car)
        {
            context.Remove(car);
        }
    }
}
