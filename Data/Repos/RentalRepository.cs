using FilmRental.Data.Repos.IRepos;
using FilmRental.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmRental.Data.Repos
{
    public class RentalRepository : IRentalRepository
    {
        private readonly FilmRentalContext _context;

        public RentalRepository(FilmRentalContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
        {
            // Vi använder "Include" för att förhindra lazy-loading
            return await _context.Rentals
                .Include(r => r.Movie)
                .Include(r => r.User)
                .ToListAsync();
        }

        public async Task<Rental> GetRentalByIdAsync(int rentalId)
        {
            // Resultatet blir null om inget hittas
            var rental = await _context.Rentals
                .Include(r => r.Movie)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Id == rentalId);

            return rental;
        }

        public async Task AddRentalAsync(Rental rental)
        {
            await _context.Rentals.AddAsync(rental);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteRentalAsync(Rental rental)
        {
            _context.Rentals.Remove(rental);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateRentalAsync(Rental rental)
        {
            _context.Rentals.Update(rental);

            await _context.SaveChangesAsync();
        }
    }
}
