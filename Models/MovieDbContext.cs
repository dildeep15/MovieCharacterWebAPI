using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MovieCharacterAPI.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
    }
}
