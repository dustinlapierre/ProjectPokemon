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
        public PokemonDTO? pokemon { get; set; }
        [BindProperty]
        public List<string>? pokemonNames { get; set; }


        public async Task OnGet(string search)
        {
            //get list of names, bound to the suggestions for the searchbox
            pokemonNames = await PokeApi.GetAllPokemonNames();

            //there is no query string, so no need to make the API call
            if (search == null)
                return;

            var pokemonModel = await PokeApi.GetPokemon(search);
            pokemon = new PokemonDTO();

            //manual model mapping, replace with automapper!
            pokemon.Name = pokemonModel.Name;
            pokemon.Id = pokemonModel.Id;
            pokemon.Img = pokemonModel.Sprites.Other.OfficialArtwork.FrontDefault;

            foreach (var stat in pokemonModel.Stats)
            {
                var mappedStat = new Stat()
                {
                    Name = stat.Stat.Name,
                    BaseStat = stat.BaseStat
                };
                pokemon.Stats.Add(mappedStat);
            }

            foreach (var ability in pokemonModel.Abilities)
            {
                var mappedAbility = new Ability()
                {
                    Name = ability.Ability.Name,
                    Url = ability.Ability.Url
                };
                pokemon.Abilities.Add(mappedAbility);
            }

            foreach (var type in pokemonModel.Types)
                pokemon.Types.Add(type.Type.Name);
        }
    }
}
