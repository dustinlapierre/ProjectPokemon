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
        public Dictionary<string, string> TypeColors = new Dictionary<string, string>()
        {
            {"normal", "#A8A77A"},
            {"fire", "#EE8130" },
            {"water", "#6390F0" },
            {"electric", "#F7D02C" },
            {"grass", "#7AC74C" },
            {"ice", "#96D9D6" },
            {"fighting", "#C22E28" },
            {"poison", "#A33EA1" },
            {"ground", "#E2BF65" },
            {"flying", "#A98FF3" },
            {"psychic", "#F95587" },
            {"bug", "#A6B91A" },
            {"rock", "#B6A136" },
            {"ghost", "#735797" },
            {"dragon", "#6F35FC" },
            {"dark", "#705746" },
            {"steel", "#B7B7CE" },
            {"fairy", "#D685AD" }
        };


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
