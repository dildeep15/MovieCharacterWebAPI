using MovieCharacterAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieCharacterAPI.DTO.CharacterDTO
{
    public class CharacterCreateDTO
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Gender { get; set; }
        public string? Alias { get; set; }
        public string? PictureURL { get; set; }
    }
}
