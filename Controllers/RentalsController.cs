using FilmRental.Models.DTOs.Rental;
using FilmRental.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FilmRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRents()
        {
            var rentals = await _rentalService.GetAllRentsAsync();

            return Ok(rentals);
        }

        [HttpGet]
        [Route("rent/{rentId}")]
        public async Task<IActionResult> GetRentById(int rentId)
        {
            var rental = await _rentalService.GetRentByIdAsync(rentId);

            return Ok(rental);
        }


        // Implementera ett sätt att hämta alla filmer som lånades av en specifik användare.

        // Implementera ett sätt att hämta alla användare som lånade en specifik film.


        [HttpPost]
        [Route("createRent")]
        public async Task<IActionResult> CreateRent(RentalCreateDTO rentCreate)
        {
            await _rentalService.AddRentAsync(rentCreate);

            return Ok();
        }

        [HttpPut]
        [Route("updateRent/{rentId}")]
        public async Task<IActionResult> UpdateRetl(int rentId, RentalUpdateDTO rentUpdate)
        {
            await _rentalService.UpdateRentAsync(rentUpdate);

            return Ok();
        }

        [HttpDelete]
        [Route("deleteRent/{rentId}")]
        public async Task<IActionResult> DeleteRent(int rentId)
        {
            await _rentalService.DeleteRentAsync(rentId);

            return Ok();
        }
    }
}
