using FilmRental.Models.DTOs.Rental;

namespace FilmRental.Services.IServices
{
    public interface IRentalService
    {
        Task<IEnumerable<RentalGetDTO>> GetAllRentsAsync();
        Task<RentalGetDTO> GetRentByIdAsync(int rentId);
        Task AddRentAsync(RentalCreateDTO rentCreate);
        Task UpdateRentAsync(RentalUpdateDTO rentUpdate);
        Task DeleteRentAsync(int rentId);
    }
}
