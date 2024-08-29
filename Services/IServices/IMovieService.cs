using FilmRental.Models;
using FilmRental.Models.DTOs.Movie;

namespace FilmRental.Services.IServices
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieGetDTO>> GetAllMoviesAsync();
        Task<MovieGetDTO> GetMovieByIdAsync(int movieId);
        Task AddMovieAsync(MovieCreateDTO movieCreate);
        Task<bool> UpdateMovieAsync(MovieUpdateDTO movieUpdate);
        Task<bool> DeleteMovieAsync(int movieId);
    }
}
