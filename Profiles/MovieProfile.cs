using AutoMapper;
using MovieCharacterAPI.DTO.CharacterDTO;
using MovieCharacterAPI.DTO.MovieDTO;
using MovieCharacterAPI.Models;

namespace MovieCharacterAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            // Mapping between Movie Model & Movie DTO
            CreateMap<Movie, MovieReadDTO>();
            CreateMap<MovieCreateDTO, Movie>();
            CreateMap<MovieUpdateDTO, Movie>();
        }
    }
}
