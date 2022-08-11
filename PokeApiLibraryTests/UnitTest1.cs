using PokeApiLibrary;
using Xunit;

namespace PokeApiLibraryTests;

public class UnitTest1
{
    [Fact]
    public void PokeApiLibrary_GetById_ReturnsSuccess()
    {
        var result = PokeApi.GetPokemon(4).Result;
        Assert.Equal("charmander", result.Name);
    }

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
}
