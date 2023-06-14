using System.ComponentModel.DataAnnotations;

namespace MovieCharacterAPI.Models
{
    public class Franchise
    {
        [Key]
        public int FranchiseId { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
