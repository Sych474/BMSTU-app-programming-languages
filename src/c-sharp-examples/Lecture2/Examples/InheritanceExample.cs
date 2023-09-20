namespace Lecture2.Examples;

public abstract class Unit
{
    public string Name { get; }
    public int Hp { get; protected set; }
    
    protected Unit(string name, int hp)
    {
        Name = name;
        Hp = hp;
    }

    public virtual void TakeDamage(int damage) => Hp -= damage;
    public abstract string GetPhrase();
}

public class Undead : Unit
{
    private const int DefaultHp = 100;
    
    public Undead() : base("Undead", DefaultHp) { }

    public override void TakeDamage(int damage) => Hp -= (int) Math.Round(damage / 2.0);

    public override string GetPhrase() => "...";
}

public class Worker : Unit
{
    private const int DefaultHp = 10;
    public int BuildPower { get; }
    
    public Worker(int buildPower) : base("Worker", DefaultHp)
    {
        BuildPower = buildPower;
    }
    
    public override string GetPhrase() => "Опять работа?!";
}