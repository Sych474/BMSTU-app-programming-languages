namespace GameModel.Models;

public class Character
{
    public Character(int id, string name, uint hp, uint armour, uint damage)
    {
        Id = id;
        Name = name;
        Hp = hp;
        Armour = armour;
        Damage = damage;
    }

    public int Id { get; }

    public string Name { get; }
    
    public uint Hp { get; }
    
    public uint Armour { get; }

    public uint Damage { get; }

}