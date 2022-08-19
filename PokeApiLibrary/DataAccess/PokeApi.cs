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
    public static async Task<PokemonModel> GetPokemon(string query)
    {
        try
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri($"https://pokeapi.co/api/v2/pokemon/{query.ToLower()}");
                var result = await client.GetAsync(endpoint);

                var opt = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };

                var pokemonModel = JsonSerializer.Deserialize<PokemonModel>(await result.Content.ReadAsStringAsync(), opt);
                return pokemonModel;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static async Task<List<string>> GetAllPokemonNames()
    {
        try
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
        catch(Exception ex)
        {
            return new List<string>();
        }
    }

    //pass in ability name as displayed in PokeApi (ex. serene-grace)
    public static async Task<string> GetAbilityDescription(string abilityName)
    {
        try
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri($"https://pokeapi.co/api/v2/ability/{abilityName}");
                var result = await client.GetAsync(endpoint);

                using (JsonDocument jsonDocument = JsonDocument.Parse(await result.Content.ReadAsStringAsync()))
                {
                    //check effect entries for english entry
                    foreach (var element in jsonDocument.RootElement.GetProperty("effect_entries").EnumerateArray())
                    {
                        if (element.GetProperty("language").GetProperty("name").ToString() == "en")
                        {
                            return element.GetProperty("effect").ToString().Replace("\n\n", " ");
                        }
                    }
                    //check flavor text for english entry (sometimes a move hasn't been given an effect desc in the API)
                    foreach (var element in jsonDocument.RootElement.GetProperty("flavor_text_entries").EnumerateArray())
                    {
                        if (element.GetProperty("language").GetProperty("name").ToString() == "en")
                        {
                            return element.GetProperty("flavor_text").ToString().Replace("\n\n", " ");
                        }
                    }
                }
            }
        }
        catch (Exception ex) { };

        return "Description not found!";
    }
}

