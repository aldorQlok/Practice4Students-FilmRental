using System.ComponentModel.DataAnnotations;

namespace FilmRental.Models.DTOs.User
{
    public class UserCreateDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
