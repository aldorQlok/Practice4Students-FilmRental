using FilmRental.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmRental.Data
{
    public class FilmRentalContext : DbContext
    {
        public FilmRentalContext(DbContextOptions<FilmRentalContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData
                (
                    new User { Id=1, Email= "Tobias@gmail.com", Name = "Tobias"},
                    new User { Id= 2, Email= "Johan@gmail.com", Name = "Johan" }
                );

            modelBuilder.Entity<Movie>().HasData
                (
                    new Movie { Id = 1, Title = "The Conjuring", ReleaseYear = 2013 },
                    new Movie { Id = 2, Title = "The Others", ReleaseYear = 2001}
                );

            modelBuilder.Entity<Rental>().HasData
                (
                    new Rental { Id = 1, FK_UserId = 1, FK_MovieId = 1, LoanDate = new DateTime(2024, 8, 20), ReturnDate = new DateTime(2024, 8, 22) },
                    new Rental { Id = 2, FK_UserId = 2, FK_MovieId = 2, LoanDate = new DateTime(2024, 8, 22), ReturnDate = null },
                    new Rental { Id = 3, FK_UserId = 2, FK_MovieId = 1, LoanDate = new DateTime(2024, 8, 26), ReturnDate = new DateTime(2024, 9, 12) }
                );
        }
    }
}