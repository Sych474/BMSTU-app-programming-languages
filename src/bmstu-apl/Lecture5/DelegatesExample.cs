namespace Lecture5;

public static class OtherClass
{
    public static void Hello() => Console.WriteLine("Hey bro!");
    public static double Sum(double f, double s) => f + s;
}

internal delegate void ActionDelegate();

internal delegate R BinaryOperation<T, R>(T first, T second);

public class DelegatesExample
{
    private static void WriteHelloWorld() => Console.WriteLine("Hello World");

    public static void SimpleDelegateExample()
    {
        ActionDelegate ad = WriteHelloWorld;
        ActionDelegate delegateFromOtherClass = OtherClass.Hello;
        BinaryOperation<double, double> binaryOperation = OtherClass.Sum;

        ad(); // Hello World
        delegateFromOtherClass(); // Hey bro!
        Console.WriteLine(binaryOperation(10, 20)); // 30
    }

    public static void SomeOtherExample()
    {
        ActionDelegate ad = WriteHelloWorld;
        ad(); 
        // Hello World

        ad += OtherClass.Hello;
        ad += OtherClass.Hello;
        ad();
        // Hello World 
        // Hey bro!
        // Hey bro!

        ad -= OtherClass.Hello;
        ad -= OtherClass.Hello;
        ad?.Invoke();
        // Hello World 

        ad -= WriteHelloWorld;
        ad?.Invoke();
        // No console
    }
}