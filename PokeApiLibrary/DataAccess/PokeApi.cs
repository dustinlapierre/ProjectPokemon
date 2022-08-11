using PokeApiLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokeApiLibrary;

public static class PokeApi
{
    public static async Task<PokemonModel> GetPokemon(int id)
    {
        using (var client = new HttpClient())
        {
            var endpoint = new Uri($"https://pokeapi.co/api/v2/pokemon/{id}");
            var result = await client.GetAsync(endpoint);

            var opt = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            var pokemonModel = JsonSerializer.Deserialize<PokemonModel>(await result.Content.ReadAsStringAsync(), opt);
            return pokemonModel;
        }
    }
}

