using Microsoft.EntityFrameworkCore;
using MovieCharacterAPI.Data;
using System.Diagnostics.CodeAnalysis;

namespace MovieCharacterAPI.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Franchise> Franchise { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding Character
            modelBuilder.Entity<Character>().HasData(DataSeedHelper.SeedCharacters());

            // Seeding Franchise
            modelBuilder.Entity<Franchise>().HasData(DataSeedHelper.SeedFranchises());

            // Seeding Movie
            modelBuilder.Entity<Movie>().HasData( DataSeedHelper.SeedMovies());
        }
    }
}
