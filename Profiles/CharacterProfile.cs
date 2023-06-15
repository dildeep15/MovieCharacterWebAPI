using AutoMapper;
using MovieCharacterAPI.DTO.CharacterDTO;
using MovieCharacterAPI.Models;

namespace MovieCharacterAPI.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            // Mapping between character & Character DTO
            CreateMap<Character, CharacterReadDTO>();
            CreateMap<CharacterCreateDTO, Character>();
            CreateMap<CharacterUpdateDTO, Character>();
        }
    }
}
