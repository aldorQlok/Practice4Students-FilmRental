using FilmRental.Data.Repos.IRepos;
using FilmRental.Models;
using FilmRental.Models.DTOs.Rental;
using FilmRental.Services.IServices;

namespace FilmRental.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _repository;

        public RentalService(IRentalRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RentalGetDTO>> GetAllRentsAsync()
        {
            var rentals = await _repository.GetAllRentalsAsync();

            var rentalList = rentals.Select(rent => new RentalGetDTO
            {
                RentalId = rent.Id,
                UserId = rent.User.Id,
                UserName = rent.User.Name,
                MovieId = rent.Movie.Id,
                MovieTitle = rent.Movie.Title,
                LoanDate = rent.LoanDate,
                ReturnDate = rent.ReturnDate

            }).ToList();

            return rentalList;
        }

        public async Task<RentalGetDTO> GetRentByIdAsync(int rentId)
        {
            var rental = await _repository.GetRentalByIdAsync(rentId);

            var rentDTO = new RentalGetDTO
            {
                RentalId = rental.Id,
                UserId = rental.User.Id,
                UserName = rental.User.Name,
                MovieId = rental.Movie.Id,
                MovieTitle = rental.Movie.Title,
                LoanDate = rental.LoanDate,
                ReturnDate = rental.ReturnDate
            };

            return rentDTO;
        }

        public async Task AddRentAsync(RentalCreateDTO rentCreate)
        {
            var newRent = new Rental
            {
                FK_UserId = rentCreate.UserId,
                FK_MovieId = rentCreate.MovieId,
                LoanDate = DateTime.Today
            };

            await _repository.AddRentalAsync(newRent);
        }

        // Här kan man välja istället att den sätter dagens datum som värde för "ReturnDate".
        // Isåfall behövs ingen annan data hämtas förutom rentalId för att hitta den.
        public async Task UpdateRentAsync(RentalUpdateDTO rentUpdate)
        {
            var rentalFound = await _repository.GetRentalByIdAsync(rentUpdate.RentalId);

            if (rentalFound != null)
            {
                rentalFound.ReturnDate = rentUpdate.ReturnDate;

                await _repository.UpdateRentalAsync(rentalFound);
            }
        }

        public async Task DeleteRentAsync(int rentId)
        {
            var rentalFound = await _repository.GetRentalByIdAsync(rentId);

            if (rentalFound != null)
            {
                await _repository.DeleteRentalAsync(rentalFound);
            }

        }
    }
}
