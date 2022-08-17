using PokeApiLibrary;
using Xunit;

namespace PokeApiLibraryTests;

public class UnitTest1
{
    [Fact]
    public void PokeApiLibrary_GetByNameLowerCase_ReturnsSuccess()
    {
        var result = PokeApi.GetPokemon("charmander").Result;
        Assert.Equal(4, result.Id);
    }

    [Fact]
    public void PokeApiLibrary_GetByNameUpperCase_ReturnsSuccess()
    {
        var result = PokeApi.GetPokemon("Charmander").Result;
        Assert.Equal(4, result.Id);
    }

    [Fact]
    public void PokeApiLibrary_GetByNameAllCaps_ReturnsSuccess()
    {
        var result = PokeApi.GetPokemon("SQUIRTLE").Result;
        Assert.Equal(7, result.Id);
    }

    [Fact]
    public void PokeApiLibrary_GetAbilityDesc_ReturnsSuccess()
    {
        var result = PokeApi.GetAbilityDescription("battle-armor").Result;
        Assert.Equal("Moves cannot score critical hits against this Pokémon. This ability functions identically to shell armor.", result);
        result = PokeApi.GetAbilityDescription("own-tempo").Result;
        Assert.Equal("This Pokémon cannot be confused. If a Pokémon is confused and acquires this ability, its confusion will immediately be healed.", result);
    }

    [Fact]
    public void PokeApiLibrary_GetAllPokemonNames_ReturnsSuccess()
    {
        var result = PokeApi.GetAllPokemonNames().Result;
        //test that list is populated
        Assert.True(result.Count > 0);
        //test first
        Assert.Equal("bulbasaur", result[0]);
        //test last
        Assert.Equal("enamorus-therian", result[result.Count-1]);
        //test middle
        Assert.Equal("oshawott", result[500]);
    }
}
