namespace Lecture5;

public class AnonymousMethodsExamples
{
    private delegate int BinaryOperation(int first, int second);

    private static void CallDelegate(BinaryOperation op)
    {
        Console.WriteLine(op(5, 6));
    }
    
    public static void Exec()
    {
        BinaryOperation operation = delegate (int x, int y)
        {
            return x + y;
        };

        CallDelegate(delegate(int x, int y) 
        {
            return x * y;
        });
    }
}