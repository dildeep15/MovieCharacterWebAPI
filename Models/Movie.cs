using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieCharacterAPI.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [MaxLength(255)]
        [Required]
        public string Title { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        public string? Genre { get; set; }
        public string? Director { get; set; }
        public string? PictureURL { get; set; }
        public string? TrailerURL { get; set; }
        public int? FranchiseId { get; set; }

        // Navigation property
        public Franchise? Franchise { get; set; }
        public ICollection<Character> Characters { get; set; }

    }
}
