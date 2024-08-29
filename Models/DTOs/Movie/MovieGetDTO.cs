using System.ComponentModel.DataAnnotations;

namespace FilmRental.Models.DTOs.Movie
{
    public class MovieGetDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ReleaseYear { get; set; }
    }
}
