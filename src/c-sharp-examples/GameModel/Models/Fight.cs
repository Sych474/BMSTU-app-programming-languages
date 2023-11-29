namespace GameModel.Models;

public class Fight
{
    public Fight(int id, Character attacker, Character defender, FightResult result, DateTime time)
    {
        Id = id;
        Attacker = attacker;
        Defender = defender;
        Result = result;
        Time = time;
    }
    
    public Fight(Character attacker, Character defender, FightResult result, DateTime time)
    {
        Attacker = attacker;
        Defender = defender;
        Result = result;
        Time = time;
    }

    public int Id { get; }
    public Character Attacker { get; }
    public Character Defender { get; }
    public FightResult Result { get; }
    public DateTime Time { get; }
}

public enum FightResult
{
    FirstDead,
    SecondDead,
    Draw
}