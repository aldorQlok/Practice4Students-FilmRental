using FilmRental.Data.Repos.IRepos;
using FilmRental.Models;
using FilmRental.Models.DTOs.Movie;
using FilmRental.Services.IServices;

namespace FilmRental.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieGetDTO>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllMoviesAsync();

            var movieList = movies.Select(movie => new MovieGetDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear
            }).ToList();

            return movieList;
        }

        public async Task<MovieGetDTO> GetMovieByIdAsync(int movieId)
        {
            var movieFound = await _movieRepository.GetMovieByIdAsync(movieId);

            if (movieFound != null)
            {
                var movie = new MovieGetDTO
                {
                    Id = movieFound.Id,
                    Title = movieFound.Title,
                    ReleaseYear = movieFound.ReleaseYear
                };

                return movie;
            }

            return null;
        }

        public async Task AddMovieAsync(MovieCreateDTO movieCreate)
        {
            var movie = new Movie
            {
                Title = movieCreate.Title,
                ReleaseYear = movieCreate.ReleaseYear
            };

            await _movieRepository.AddMovieAsync(movie);
        }

        public async Task<bool> UpdateMovieAsync(MovieUpdateDTO movieUpdate)
        {
            if (string.IsNullOrEmpty(movieUpdate.Title))
            {
                return false;
            }

            var movieFound = await _movieRepository.GetMovieByIdAsync(movieUpdate.Id);

            if (movieFound != null)
            {
                movieFound.Title = movieUpdate.Title;
                movieFound.ReleaseYear = movieUpdate.ReleaseYear;

                await _movieRepository.UpdateMovieAsync(movieFound);

                return true;
            }

            return false;
            
        }

        public async Task<bool> DeleteMovieAsync(int movieId)
        {
            var movieFound = await _movieRepository.GetMovieByIdAsync(movieId);

            if (movieFound != null)
            {
                await _movieRepository.DeleteMovieAsync(movieFound);

                return true;
            }

            return false;
        }
    }
}
