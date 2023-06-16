using System.ComponentModel.DataAnnotations;

namespace MovieCharacterAPI.DTO.CharacterDTO
{
    public class CharacterUpdateDTO
    {
        [Required]
        public int CharacterId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Gender { get; set; }
        public string? Alias { get; set; }
    }
}
