using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokeApiLibrary.Models;

//this is the data model, not the front facing model the users will see
public class PokemonModel
{
    public string Name { get; set; }
    public int Id { get; set; }
    public List<AbilityEntry> Abilities { get; set; }
    public List<StatEntry> Stats { get; set; }
    public List<TypeEntry> Types { get; set; }
    public SpriteEntry Sprites { get; set; }
}

