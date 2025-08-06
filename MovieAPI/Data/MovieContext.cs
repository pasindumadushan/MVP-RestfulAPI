using Microsoft.EntityFrameworkCore;
using MovieAPI.Entities;

namespace MovieAPI.Data
{
    public class MovieContext(DbContextOptions<MovieContext> options) : DbContext(options)
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        //Method to seed data into our database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Sci-fi" },
                new Genre { Id = 3, Name = "Fantasy" },
                new Genre { Id = 4, Name = "Horror" },
                new Genre { Id = 5, Name = "Romance" }
                );

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Name = "Shadow Realm", GenreId = 1, Price = 9.49M, ReleaseDate = new DateOnly(2021, 10, 15) },
                new Movie { Id = 2, Name = "Echoes of Tomorrow", GenreId = 2, Price = 7.99M, ReleaseDate = new DateOnly(2022, 5, 20) },
                new Movie { Id = 3, Name = "Digital Drift", GenreId = 3, Price = 11.50M, ReleaseDate = new DateOnly(2023, 3, 8) },
                new Movie { Id = 4, Name = "Crimson Sky", GenreId = 1, Price = 10.00M, ReleaseDate = new DateOnly(2020, 12, 25) },
                new Movie { Id = 5, Name = "Neon Mirage", GenreId = 4, Price = 8.75M, ReleaseDate = new DateOnly(2019, 8, 3) },
                new Movie { Id = 6, Name = "Steel Pulse", GenreId = 5, Price = 6.99M, ReleaseDate = new DateOnly(2021, 2, 14) },
                new Movie { Id = 7, Name = "Quantum Loop", GenreId = 2, Price = 12.00M, ReleaseDate = new DateOnly(2024, 6, 30) },
                new Movie { Id = 8, Name = "Frozen Code", GenreId = 3, Price = 9.99M, ReleaseDate = new DateOnly(2020, 11, 5) }
                );
        }
    }
}
