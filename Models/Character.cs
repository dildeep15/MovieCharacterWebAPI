using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieCharacterAPI.Models
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        [MaxLength(150)]
        [Required]
        public string FullName { get; set; }
        [MaxLength(50)]
        [Required]
        public string Gender { get; set; }
        [MaxLength(150)]
        public string? Alias { get; set; }
        [MaxLength(255)]
        public string? PictureURL { get; set; }

        // Navigation property
        public ICollection<Movie> Movies { get; set; }
    }
}
