using Microsoft.EntityFrameworkCore;
using Movies.Data.Entities;
using System;

namespace Movies.Data.Contexts
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }


        public MovieDbContext(DbContextOptions<MovieDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenre>().HasKey(mg => new { mg.GenreId, mg.MovieId });

            modelBuilder.Entity<MovieGenre>()
                .HasOne<Movie>(mg => mg.Movie)
                .WithMany(m => m.Genres)
                .HasForeignKey(mg => mg.MovieId);


            modelBuilder.Entity<MovieGenre>()
                .HasOne<Genre>(mg => mg.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(mg => mg.GenreId);

            modelBuilder.Entity<Rating>().HasKey(mg => new { mg.UserId, mg.MovieId });

            modelBuilder.Entity<Rating>()
                .HasOne<Movie>(r => r.Movie)
                .WithMany(m => m.Ratings)
                .HasForeignKey(r => r.MovieId);


            modelBuilder.Entity<Rating>()
                .HasOne<User>(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId);


            SeedData(modelBuilder);

        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Name = "Deadpool", ReleaseDate = new DateTime(2016,2,10) },
                new Movie { Id = 2, Name = "Freddy vs Jason", ReleaseDate = new DateTime(2003, 8, 15) },
                new Movie { Id = 3, Name = "The Crow", ReleaseDate = new DateTime(1994, 6, 10) },
                new Movie { Id = 4, Name = "Dogma", ReleaseDate = new DateTime(1999, 12, 26) },
                new Movie { Id = 5, Name = "The Hitchhiker's Guide to the Galaxy", ReleaseDate = new DateTime(2005, 4, 28) },
                new Movie { Id = 6, Name = "Seven Psychopaths", ReleaseDate = new DateTime(2012, 12, 5) },
                new Movie { Id = 7, Name = "Moon", ReleaseDate = new DateTime(2009, 7, 17) },
                new Movie { Id = 8, Name = "Equilibrium ", ReleaseDate = new DateTime(2002, 3, 14) }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirtName = "John", LastName = "Smith" },
                new User { Id = 2, FirtName = "Jane", LastName = "Doe" },
                new User { Id = 3, FirtName = "Tester", LastName = "McTesteson" }
                );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Horror" },
                new Genre { Id = 3, Name = "Comedy" },
                new Genre { Id = 4, Name = "Superhero" },
                new Genre { Id = 5, Name = "Thriller" },
                new Genre { Id = 6, Name = "Sci-fi" }
                );

            modelBuilder.Entity<MovieGenre>().HasData(
                new MovieGenre { MovieId = 1, GenreId = 1 },
                new MovieGenre { MovieId = 1, GenreId = 3 },
                new MovieGenre { MovieId = 1, GenreId = 4 },
                new MovieGenre { MovieId = 1, GenreId = 6 },

                new MovieGenre { MovieId = 2, GenreId = 2 },
                new MovieGenre { MovieId = 2, GenreId = 3 },

                new MovieGenre { MovieId = 3, GenreId = 1 },
                new MovieGenre { MovieId = 3, GenreId = 4 },
                new MovieGenre { MovieId = 3, GenreId = 5 },

                new MovieGenre { MovieId = 4, GenreId = 3 },

                new MovieGenre { MovieId = 5, GenreId = 3 },
                new MovieGenre { MovieId = 5, GenreId = 6 },

                new MovieGenre { MovieId = 6, GenreId = 3 },
                new MovieGenre { MovieId = 6, GenreId = 5 },

                new MovieGenre { MovieId = 7, GenreId = 6 },

                new MovieGenre { MovieId = 8, GenreId = 1 },
                new MovieGenre { MovieId = 8, GenreId = 5 },
                new MovieGenre { MovieId = 8, GenreId = 6 }
                );

            modelBuilder.Entity<Rating>().HasData(
                new Rating { MovieId = 1, UserId = 1, Stars = 5 },
                new Rating { MovieId = 2, UserId = 1, Stars = 3 },
                new Rating { MovieId = 3, UserId = 1, Stars = 4 },
                new Rating { MovieId = 4, UserId = 1, Stars = 2 },
                new Rating { MovieId = 5, UserId = 1, Stars = 1 },
                new Rating { MovieId = 6, UserId = 1, Stars = 3 },
                new Rating { MovieId = 7, UserId = 1, Stars = 5 },
                new Rating { MovieId = 8, UserId = 1, Stars = 4 },

                new Rating { MovieId = 1, UserId = 2, Stars = 4 },
                new Rating { MovieId = 2, UserId = 2, Stars = 5 },
                new Rating { MovieId = 3, UserId = 2, Stars = 4 },
                new Rating { MovieId = 4, UserId = 2, Stars = 5 },
                new Rating { MovieId = 5, UserId = 2, Stars = 4 },
                new Rating { MovieId = 6, UserId = 2, Stars = 2 },
                new Rating { MovieId = 7, UserId = 2, Stars = 3 },
                new Rating { MovieId = 8, UserId = 2, Stars = 1 },

                new Rating { MovieId = 1, UserId = 3, Stars = 5 },
                new Rating { MovieId = 2, UserId = 3, Stars = 4 },
                new Rating { MovieId = 3, UserId = 3, Stars = 5 },
                new Rating { MovieId = 4, UserId = 3, Stars = 3 },
                new Rating { MovieId = 5, UserId = 3, Stars = 3 },
                new Rating { MovieId = 6, UserId = 3, Stars = 2 },
                new Rating { MovieId = 7, UserId = 3, Stars = 1 },
                new Rating { MovieId = 8, UserId = 3, Stars = 4 }
                );
        }
    }
}
