using FilmRental.Models.DTOs.User;

namespace FilmRental.Services.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserGetDTO>> GetAllUsersAsync();
        Task<UserGetDTO> GetUserByIdAsync(int userId);
        Task AddUserAsync(UserCreateDTO userCreate);
        Task UpdateUserAsync(UserUpdateDTO userUpdate);
        Task DeleteUserAsync(int userId);
    }
}
