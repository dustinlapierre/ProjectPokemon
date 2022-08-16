using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeApiLibrary;
using ProjectPokemon.Models;

namespace ProjectPokemon.Pages
{
    [ValidateAntiForgeryToken]
    public class PokedexModel : PageModel
    {
        [BindProperty]
        public PokemonDTO? Pokemon { get; set; }
        [BindProperty]
        public List<string>? PokemonNames { get; set; }


        public async Task OnGet(string search)
        {
            //get list of names, bound to the suggestions for the searchbox
            PokemonNames = await PokeApi.GetAllPokemonNames();

            //there is no query string, so no need to make the API call
            if (search == null)
                return;

            var pokemonModel = await PokeApi.GetPokemon(search);
            Pokemon = new PokemonDTO();

            //manual model mapping, replace with automapper!
            Pokemon.Name = pokemonModel.Name;
            Pokemon.Id = pokemonModel.Id;
            Pokemon.Img = pokemonModel.Sprites.Other.OfficialArtwork.FrontDefault;

            foreach (var stat in pokemonModel.Stats)
            {
                var mappedStat = new Stat()
                {
                    Name = stat.Stat.Name,
                    BaseStat = stat.BaseStat
                };
                Pokemon.Stats.Add(mappedStat);
            }

            foreach (var ability in pokemonModel.Abilities)
            {
                var mappedAbility = new Ability()
                {
                    Name = ability.Ability.Name,
                    Url = ability.Ability.Url
                };
                Pokemon.Abilities.Add(mappedAbility);
            }

            foreach (var type in pokemonModel.Types)
                Pokemon.Types.Add(type.Type.Name);
        }
    }
}
