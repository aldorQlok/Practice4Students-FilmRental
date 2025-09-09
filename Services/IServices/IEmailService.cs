namespace FilmRental.Services.IServices
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string to, string subject, string htmlContent);
    }
}
