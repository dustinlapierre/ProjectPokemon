using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokeApiLibrary.Models;

public class SpriteEntry
{
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("back_default")]
    public string BackDefault { get; set; }

    public SpriteOtherEntry Other { get; set; }
}

public class SpriteOtherEntry
{
    [JsonPropertyName("official-artwork")]
    public Sprite OfficialArtwork { get; set; }
}

public class Sprite
{
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }
}
