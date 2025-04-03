using Microsoft.EntityFrameworkCore;
using piyoz.uz.DataAccess.Entities;

namespace piyoz.uz.DataAccess.Repositories
{
    public interface IRentalRepository
    {
        Task AddAsync(Rental driver);

        Task<Rental> GetById(int id);

        Task<IList<Rental>> GetAll();

        void Update(Rental driver);

        void Delete(Rental driver);

        void SaveChanges();

        Task SaveChangesAsync();
    }
    public class RentalRepository(DataContext context) : IRentalRepository
    {
        public async Task AddAsync(Rental rental)
        {
            await context.Rentals.AddAsync(rental);
        }

        public void Delete(Rental rental)
        {
            context.Rentals.Remove(rental);
        }

        public async Task<IList<Rental>> GetAll()
        {
            return await context.Rentals.ToListAsync();
        }

        public async Task<Rental> GetById(int id)
        {
            return await context.Rentals.FirstOrDefaultAsync(d => d.Id == id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Update(Rental rental)
        {
            context.Update(rental);
        }
    }
}
