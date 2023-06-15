namespace MovieCharacterAPI.DTO.CharacterDTO
{
    public class CharacterUpdateDTO
    {
        public int CharacterId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string? Alias { get; set; }
    }
}
