namespace BaseConstructions;

internal class ClassExample
{
    private int _privateField;

    private const int ConstExample = 42;

    public int PublicMethod(int argument)
    {
        _privateField = ConstExample + argument;
        PrivateLogExample();
        return _privateField;
    }

    private void PrivateLogExample()
    {
        Console.WriteLine("Log action");
    }

    public int PublicProperty { get; set; }
}