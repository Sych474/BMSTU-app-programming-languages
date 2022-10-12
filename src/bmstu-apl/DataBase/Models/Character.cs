namespace DataBase.Models;

public class Character
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public Race Race { get; set; }
    
    public int Hp { get; set; }
    
    public List<DuelResult>? ChallengedDuels { get; set; }
    
    public List<DuelResult>? ReceivedDuels { get; set; }

    public override string ToString() => $"[{Id}] {Name} - {Race} (hp: {Hp});";
}

public enum Race
{
    Human, 
    Ork,
    Elf, 
    Dwarf
}