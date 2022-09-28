namespace Lecture5;

public class LambdasExample
{
    private delegate int BinaryOperation(int first, int second);

    private static void CallDelegate(BinaryOperation op)
    {
        Console.WriteLine(op(5, 6));
    }
    
    public static void Exec()
    {
        BinaryOperation operation = (f, s) => f + s;
        CallDelegate((f, s) => f * s);
        
        var f = (int x) => x * x;
        Console.WriteLine(f(10));
    }

    private static double S(double radius) => Math.PI * 2 * radius;
}