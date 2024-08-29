using FilmRental.Data.Repos.IRepos;
using FilmRental.Models;
using FilmRental.Models.DTOs.User;
using FilmRental.Services.IServices;

namespace FilmRental.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<IEnumerable<UserGetDTO>> GetAllUsersAsync()
        {
            var users = await _userRepo.GetAllUsersAsync();

            var userList = users.Select(u => new UserGetDTO
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            }).ToList();

            return userList;
        }

        public async Task<UserGetDTO> GetUserByIdAsync(int userId)
        {
            var userFound = await _userRepo.GetUserByIdAsync(userId);

            var user = new UserGetDTO
            {
                Id = userFound.Id,
                Name = userFound.Name,
                Email = userFound.Email
            };

            return user;
        }

        public async Task AddUserAsync(UserCreateDTO userCreate)
        {
            var newUser = new User
            {
                Email = userCreate.Email,
                Name = userCreate.Name
            };

            await _userRepo.AddUserAsync(newUser);
        }

        public async Task UpdateUserAsync(UserUpdateDTO userUpdate)
        {
            var user = await _userRepo.GetUserByIdAsync(userUpdate.Id);

            user.Name = userUpdate.Name;
            user.Email = userUpdate.Email;

            await _userRepo.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var userFound = await _userRepo.GetUserByIdAsync(userId);

            await _userRepo.DeleteUserAsync(userFound);
        }
    }
}
