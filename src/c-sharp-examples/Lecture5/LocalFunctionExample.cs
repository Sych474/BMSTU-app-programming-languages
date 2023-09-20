namespace Lecture5;

public class LocalFunctionExample
{
    public void Method(int x)
    {
        int temp = 42;

        Console.WriteLine(InnerMethod());
        Console.WriteLine(InnerMethod());
        Console.WriteLine(InnerMethod());
        
        int InnerMethod()
        {
            temp += x;
            return temp;
        }
    }
}