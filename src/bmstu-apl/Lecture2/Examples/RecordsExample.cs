namespace Lecture2.Examples;

public record Record
{
    public string Name { get; init; }
    public int Age { get; init; }

    public Record(string name, int age)
    {
        Name = name; 
        Age = age;
    }
}

public record ShortRecord(string Name, int Age);