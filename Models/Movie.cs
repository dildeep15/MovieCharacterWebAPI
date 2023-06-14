using System.ComponentModel.DataAnnotations;

namespace MovieCharacterAPI.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [MaxLength(255)]
        public string Title { get; set; }
        public string? Genre { get; set; }
        public int ReleaseYear { get; set; }
        [MaxLength(255)]
        public string Director { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }
    }
}
