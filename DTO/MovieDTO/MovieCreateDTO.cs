using MovieCharacterAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieCharacterAPI.DTO.MovieDTO
{
    public class MovieCreateDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        public string? Genre { get; set; }
        public string? Director { get; set; }
        public string? PictureURL { get; set; }
        public string? TrailerURL { get; set; }
        public int? FranchiseId { get; set; }
    }
}
