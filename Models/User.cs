using System.ComponentModel.DataAnnotations;

namespace FilmRental.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } 

        [Required]
        public string Email { get; set; }

        public ICollection<Rental> Rentals { get; set; }
    }
}
