using MovieCharacterAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieCharacterAPI.DTO.CharacterDTO
{
    public class CharacterReadDTO
    {
        public int CharacterId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string? Alias { get; set; }
        public string? PictureURL { get; set; }
    }
}
