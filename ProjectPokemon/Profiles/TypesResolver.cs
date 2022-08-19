using AutoMapper;
using PokeApiLibrary.Models;
using ProjectPokemon.Models;

namespace ProjectPokemon.Profiles;

public class TypesResolver : IValueResolver<PokemonModel, PokemonDTO, List<string>>
{
    public List<string> Resolve(PokemonModel source, PokemonDTO destination, List<string> destMember, ResolutionContext context)
    {
        var result = new List<string>();
        foreach (var type in source.Types)
            result.Add(type.Type.Name);

        return result;
    }
}

