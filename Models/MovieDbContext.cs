using Microsoft.EntityFrameworkCore;
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
