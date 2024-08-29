namespace FilmRental.Models.DTOs.Rental
{
    public class RentalGetDTO
    {
        public int RentalId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
