using AutoMapper;
using MovieCharacterAPI.DTO.CharacterDTO;
using MovieCharacterAPI.Models;

namespace MovieCharacterAPI.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            // Mapping from Character Model to CharacterReadDTO
            CreateMap<Character, CharacterReadDTO>();
            CreateMap<CharacterCreateDTO, Character>();
            CreateMap<CharacterUpdateDTO, Character>();
        }
    }
}
