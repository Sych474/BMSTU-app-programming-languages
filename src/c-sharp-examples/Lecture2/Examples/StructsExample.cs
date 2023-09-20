namespace Lecture2.Examples;

public struct Student
{
    public string Name;
    public int Age = 18;

    public override string ToString() => $"Name: {Name}  Age: {Age}";

    public Student(string name)
    {
        Name = name;
    }
    
    public Student(string name, int age) : this(name)
    {
        Age = age;
    }
}

public static class StructUseExample
{
    public static void CopyExample()
    {
        var anna = new Student("Anna", 19);
        var ivan = anna with { Name = "Ivan" };
    }
}