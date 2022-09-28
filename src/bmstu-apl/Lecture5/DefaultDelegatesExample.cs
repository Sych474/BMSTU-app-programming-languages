namespace Lecture5;

public class DefaultDelegatesExample
{
    private Action _simpleAction = () => Console.WriteLine("Fail");
    private Action<int> _simpleActionWithParameter = (param) => Console.WriteLine(param);
    
    public delegate void Action();
    public delegate void Action<in T>(T obj);
    public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);
    // ... 

    public Predicate<int> _predicate = (x) => x > 0;
    
    private Func<int> _func = () => 42;
    private Func<int, int, int> _funcWithParameters = (p1, p2) => p1 * p2;
    
    public delegate TResult Func<out TResult>();
    public delegate TResult Func<out TResult, in T>(T obj);
    public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
    // ... 
}