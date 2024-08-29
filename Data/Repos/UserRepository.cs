using FilmRental.Data.Repos.IRepos;
using FilmRental.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmRental.Data.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly FilmRentalContext _context;

        public UserRepository(FilmRentalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var usersList = await _context.Users.ToListAsync();

            return usersList;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            // Resultatet blir null om inget hittas
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            return user;
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}
