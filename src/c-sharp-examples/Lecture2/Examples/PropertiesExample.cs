namespace Lecture2.Examples;

public class Person
{
    private int _name;
    public int NameProperty
    {
        get { return _name; }
        set { _name = value; }
    }

    public int NamePropertyV2
    {
        get => _name;
        set => _name = value;
    }
}

public static class PropertyCallExample
{
    static void Call()
    {
        var c = new Person();
        c.NameProperty = 8;
        Console.WriteLine(c.NamePropertyV2);
    }
}

public class ClassWithProperties
{
    public int Property { get; set; }

    public int PropertyWithPrivateSet { get; private set; }

    public int ImmutableProperty { get; }

    public int ComputedProperty => 42 + Property;
}