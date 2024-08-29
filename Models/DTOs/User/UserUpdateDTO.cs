using System.ComponentModel.DataAnnotations;

namespace FilmRental.Models.DTOs.User
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
