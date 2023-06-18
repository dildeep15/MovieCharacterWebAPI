using AutoMapper;
using MovieCharacterAPI.DTO.CharacterDTO;
using MovieCharacterAPI.DTO.FranchiseDTO;
using MovieCharacterAPI.Models;

namespace MovieCharacterAPI.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            // Mapping between Franchise Model & Franchise DTO
            CreateMap<Franchise, FranchiseReadDTO>();
            CreateMap<FranchiseCreateDTO, Franchise>();
            CreateMap<FranchiseUpdateDTO, Franchise>();
        }
    }
}
