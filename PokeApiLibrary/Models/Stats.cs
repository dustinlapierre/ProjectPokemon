using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokeApiLibrary.Models;

public class StatEntry
{
    [JsonPropertyName("base_stat")]
    public int BaseStat { get; set; }
    
    public StatInfo Stat { get; set; }
}

public class StatInfo
{
    public string Name { get; set; }
}