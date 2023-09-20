namespace Lecture2.Examples;

public class Character
{
    public string Name { get; init; }
    public int Age { get; init; }

    public override string ToString() => $"{Name}, {Age}";
}

public class InitExample
{
    public static void InitCallExample()
    {
        var character = new Character()
        {
            Name = "Aragorn",
            Age = 87
        };
        Console.WriteLine($"{character}");
    }
}
