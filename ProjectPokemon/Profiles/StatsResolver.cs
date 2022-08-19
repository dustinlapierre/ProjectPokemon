using AutoMapper;
using PokeApiLibrary.Models;
using ProjectPokemon.Models;

namespace ProjectPokemon.Profiles;

public class StatsResolver : IValueResolver<PokemonModel, PokemonDTO, List<Stat>>
{
    public List<Stat> Resolve(PokemonModel source, PokemonDTO destination, List<Stat> destMember, ResolutionContext context)
    {
        var stats = new List<Stat>();
        foreach (var stat in source.Stats)
        {
            var mappedStat = new Stat()
            {
                Name = stat.Stat.Name,
                BaseStat = stat.BaseStat
            };
            stats.Add(mappedStat);
        }

        return stats;
    }
}

