namespace FilmRental.Models.DTOs.Rental
{
    public class RentalCreateDTO
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
