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
