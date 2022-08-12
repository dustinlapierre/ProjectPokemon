namespace ProjectPokemon.Models;

//front facing model
public class PokemonDTO
{
    public string Name { get; set; }
    public int Id { get; set; }
    public List<Ability> Abilities { get; set; }
    public List<Type> Types { get; set; }
    public int BaseHP { get; set; }
    public int BaseAttack { get; set; }
    public int BaseDefense { get; set; }
    public int BaseSpAttack { get; set; }
    public int BaseSpDefense { get; set; }
    public int BaseSpeed { get; set; }
    public string Img { get; set; }
}

public class Ability
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Type
{
    public string Name { get; set; }
}