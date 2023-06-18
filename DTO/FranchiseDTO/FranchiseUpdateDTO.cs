using System.ComponentModel.DataAnnotations;

namespace MovieCharacterAPI.DTO.FranchiseDTO
{
    public class FranchiseUpdateDTO
    {
        public int FranchiseId { get; set; }
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
