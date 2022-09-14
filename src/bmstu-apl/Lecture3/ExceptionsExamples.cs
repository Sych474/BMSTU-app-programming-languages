using System.Runtime.Serialization;

namespace Lecture3;

public class CustomException : Exception
{
    public CustomException() { }
    public CustomException(string? message) : base(message) { }
    public CustomException(string? message, Exception? innerException) : base(message, innerException) { }
}


    
public partial class CallExample
{
    private static void Foo() => throw new OutOfMemoryException("MyCustomMessage");
    private static void Bar() => throw new ArgumentException();
    
    public static void ExceptionsCatchExample()
    {
        try
        {
            Foo();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    public static void FullCatchBlockExample()
    {
        try
        {
            Foo();
            Console.WriteLine("No Errors in Foo");
        }
        catch (OutOfMemoryException e) when(e.Message.Contains("MyCustomMessage"))
        {
            Console.WriteLine("Filtered OutOfMemoryException was thrown");
        }
        catch (OutOfMemoryException e)
        {
            Console.WriteLine("Other OutOfMemoryException was thrown");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            Console.WriteLine("Finally be called anyway.");
        } 
    }
}