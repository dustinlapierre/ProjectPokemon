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

    public static async Task<PokemonModel> GetPokemon(string name)
    {
        using (var client = new HttpClient())
        {
            var endpoint = new Uri($"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}");
            var result = await client.GetAsync(endpoint);

            var opt = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            var pokemonModel = JsonSerializer.Deserialize<PokemonModel>(await result.Content.ReadAsStringAsync(), opt);
            return pokemonModel;
        }
    }

    public static async Task<List<string>> GetAllPokemonNames()
    {
        using (var client = new HttpClient())
        {
            var endpoint = new Uri($"https://pokeapi.co/api/v2/pokemon?limit=9999");
            var result = await client.GetAsync(endpoint);

            using(JsonDocument jsonDocument = JsonDocument.Parse(await result.Content.ReadAsStringAsync()))
            {
                var pokemonNameList = new List<string>();
                foreach (var element in jsonDocument.RootElement.GetProperty("results").EnumerateArray())
                {
                    pokemonNameList.Add(element.GetProperty("name").ToString());
                }
                return pokemonNameList;
            }
        }
    }
}

