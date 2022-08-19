using AutoMapper;
using PokeApiLibrary.Models;
using ProjectPokemon.Models;

namespace ProjectPokemon.Profiles;

public class AbilitiesResolver : IValueResolver<PokemonModel, PokemonDTO, List<Ability>>
{
    public List<Ability> Resolve(PokemonModel source, PokemonDTO destination, List<Ability> destMember, ResolutionContext context)
    {
        var abilities = new List<Ability>();
        foreach (var ability in source.Abilities)
        {
            var mappedAbility = new Ability()
            {
                Name = ability.Ability.Name,
                Url = ability.Ability.Url
            };
            abilities.Add(mappedAbility);
        }

        return abilities;
    }
}

