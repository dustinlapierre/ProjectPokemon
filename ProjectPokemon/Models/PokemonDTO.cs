namespace ProjectPokemon.Models;

//front facing model
public class PokemonDTO
{
    public string Name { get; set; }
    public int Id { get; set; }
    public List<Ability> Abilities { get; set; } = new List<Ability>();
    public List<string> Types { get; set; } = new List<string>();
    public List<Stat> Stats { get; set; } = new List<Stat>();
    public string Img { get; set; }
}

public class Ability
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Stat
{
    public string Name { get; set; }
    public int BaseStat { get; set; }
}