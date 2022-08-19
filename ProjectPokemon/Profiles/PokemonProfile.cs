using AutoMapper;
using PokeApiLibrary.Models;
using ProjectPokemon.Models;

namespace ProjectPokemon.Profiles;

public class PokemonProfile : Profile
{
    public PokemonProfile()
    {
        // source -> destination
        CreateMap<PokemonModel, PokemonDTO>()
            .ForMember(dest => dest.Img, opt => opt.MapFrom(src => src.Sprites.Other.OfficialArtwork.FrontDefault))
            .ForMember(dest => dest.Stats, opt => opt.MapFrom<StatsResolver>())
            .ForMember(dest => dest.Abilities, opt => opt.MapFrom<AbilitiesResolver>())
            .ForMember(dest => dest.Types, opt => opt.MapFrom<TypesResolver>());
    }
}
