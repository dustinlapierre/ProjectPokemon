using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeApiLibrary;

namespace ProjectPokemon.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var poke = PokeApi.GetPokemon("bruxish").Result;
            Console.WriteLine(poke.Name);
            Console.WriteLine(poke.Id);
            Console.WriteLine(poke.Sprites.Other.OfficialArtwork.FrontDefault);
            foreach (var a in poke.Abilities)
            {
                Console.WriteLine(a.Ability.Name);
            }
            foreach (var a in poke.Stats)
            {
                Console.WriteLine($"{a.Stat.Name}: {a.BaseStat}");
            }
            foreach (var a in poke.Types)
            {
                Console.WriteLine($"{a.Type.Name}");
            }
        }
    }
}