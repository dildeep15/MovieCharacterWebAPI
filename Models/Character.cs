using System.ComponentModel.DataAnnotations;

namespace MovieCharacterAPI.Models
{
    public class Character
    {
        [Key]
        public int CustomerId { get; set; }
        [MaxLength(150)]
        public string FullName { get; set; }
        [MaxLength(150)]
        public string? Alias { get; set; }
        [MaxLength(50)]
        public string Gender { get; set; }
        [MaxLength(255)]
        public string Picture { get; set; }
    }
}
