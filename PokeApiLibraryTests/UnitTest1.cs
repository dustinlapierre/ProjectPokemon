using PokeApiLibrary;
using System;
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
}
