using Microsoft.EntityFrameworkCore;
using MovieCharacterAPI.Data;
using System.Diagnostics.CodeAnalysis;

namespace MovieCharacterAPI.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext([NotNullAttribute] DbContextOptions options) : base(options){ }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Franchise> Franchise { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding Character Data
            modelBuilder.Entity<Character>().HasData(DataSeedHelper.SeedCharacters());

            // Seeding Franchise Data
            modelBuilder.Entity<Franchise>().HasData(DataSeedHelper.SeedFranchises());

            // Seeding Movie Data
            modelBuilder.Entity<Movie>().HasData( DataSeedHelper.SeedMovies());

            modelBuilder.Entity<Character>()
                .HasMany(c => c.Movies)
                .WithMany(c => c.Characters)
                .UsingEntity(j => j.HasData(
                    new { MoviesMovieId = 1, CharactersCharacterId = 1 },
                    new { MoviesMovieId = 2, CharactersCharacterId = 2 },
                    new { MoviesMovieId = 3, CharactersCharacterId = 1 },
                    new { MoviesMovieId = 3, CharactersCharacterId = 2 },
                    new { MoviesMovieId = 3, CharactersCharacterId = 3 },
                    new { MoviesMovieId = 4, CharactersCharacterId = 1 },
                    new { MoviesMovieId = 4, CharactersCharacterId = 4 },
                    new { MoviesMovieId = 5, CharactersCharacterId = 1 },
                    new { MoviesMovieId = 5, CharactersCharacterId = 2 },
                    new { MoviesMovieId = 5, CharactersCharacterId = 3 },
                    new { MoviesMovieId = 5, CharactersCharacterId = 4 }
                    )); 
        }
    }
}
