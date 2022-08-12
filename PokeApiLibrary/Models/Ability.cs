using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokeApiLibrary.Models;

public class AbilityEntry
{
    public AbilityInfo Ability { get; set; }

    [JsonPropertyName("is_hidden")]
    public bool IsHidden { get; set; }
}

public class AbilityInfo
{
    public string Name { get; set; }
    public string Url { get; set; }
}