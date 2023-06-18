using System.ComponentModel.DataAnnotations;

namespace MovieCharacterAPI.DTO.FranchiseDTO
{
    public class FranchiseCreateDTO
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
