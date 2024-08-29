using FilmRental.Models.DTOs.User;
using FilmRental.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FilmRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<ActionResult<UserGetDTO>> GetUserById(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);

            return Ok(user);
        }

        [HttpPost]
        [Route("createUser")]
        public async Task<ActionResult> CreateUser(UserCreateDTO userCreate)
        {
            await _userService.AddUserAsync(userCreate);

            return Ok();
        }

        [HttpPut]
        [Route("updateUser/{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, UserUpdateDTO updatedUser)
        {
            await _userService.UpdateUserAsync(updatedUser);

            return Ok();
        }

        [HttpDelete]
        [Route("deleteUser/{userId}")]
        public async Task<IActionResult> DeleteUserById(int userId)
        {
            await _userService.DeleteUserAsync(userId);

            return Ok();
        }
    }
}
