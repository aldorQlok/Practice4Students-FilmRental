using FilmRental.Data.Repos.IRepos;
using FilmRental.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmRental.Data.Repos
{
    public class MovieRepository : IMovieRepository
    {
        private readonly FilmRentalContext _context;

        public MovieRepository(FilmRentalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int movieId)
        {
            // returnerar null om inget hittas.
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

            return movie;
        }

        public async Task AddMovieAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(Movie movie)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}
