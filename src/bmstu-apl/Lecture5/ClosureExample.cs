namespace Lecture5;

public class ClosureExample
{
    public static void LambdaExample()
    {
        var outerFn = () =>
        {
            var x = 10;
            return () => Console.WriteLine(++x);
        };
 
        var fn = outerFn();
        
        fn();   // 11
        fn();   // 12
        fn();   // 13
    }
    
    delegate int Operation(int n);
    
    public static void InnerFunctionExample()
    {
        var fn = Multiply(5);  
 
        Console.WriteLine(fn(5));   // 25
        Console.WriteLine(fn(6));   // 30
        Console.WriteLine(fn(7));   // 35
 
        Operation Multiply(int n)
        {
            int Inner(int m)
            {
                return n * m;
            }
            return Inner;
        }
    }
}


