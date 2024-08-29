using FilmRental.Models.DTOs.Movie;
using FilmRental.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FilmRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieGetDTO>>> GetAllMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();

            return Ok(movies);
        }

        [HttpGet]
        [Route("movie/{id}")]
        public async Task<ActionResult<MovieGetDTO>> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost]
        [Route("addMovie")]
        public async Task<IActionResult> CreateMovie(MovieCreateDTO movieCreate)
        {
            if (!ModelState.IsValid)
            {
                // returnerar statuskod 400 Bad Request.
                return BadRequest();
            }

            await _movieService.AddMovieAsync(movieCreate);

            // returnerar statuskod 201 Created.
            return Created();
        }

        [HttpPut]
        [Route("updateMovie/{id}")]
        public async Task<IActionResult> UpdateMovie(int id, MovieUpdateDTO movieUpdate)
        {
            // vi kollar så att ID för datan som ska uppdateras matchar id i routen
            // för att säkerställa att inte fel data skrivs över.
            if (id != movieUpdate.Id)
            {
                return BadRequest();
            }

            var result = await _movieService.UpdateMovieAsync(movieUpdate);

            if (!result)
            {
                return NotFound();
            }

            // returnerar statuskod 204 No Content.
            // Det innebär att uppdateringen är lyckad men vi skickar inte tillbaka något.
            return NoContent();
        }

        [HttpDelete("deleteMovie/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var result = await _movieService.DeleteMovieAsync(id);

            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
