using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieCharacterAPI.Models
{
    public class Franchise
    {
        [Key]
        public int FranchiseId { get; set; }
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

        // Navigation Property
        public ICollection<Movie> Movie { get; set; }
    }
}
