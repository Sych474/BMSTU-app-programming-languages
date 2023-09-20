namespace Lecture5;

public class RefInOutExamples
{
    public static void RefExample(ref int param)
    {
        param++; 
        Console.WriteLine(param);
    }

    public static void RefExampleCall()
    {
        int variable = 42;
        RefExample(ref variable);
        Console.WriteLine(variable);
        
        // Console: 
        // 43 
        // 43
    }

    
    public static void InExample(in int param)
    {
        // param - не может быть измененен
        
        Console.WriteLine(param);
    }

    public static void OutExample(out int param)
    {
        param = 42;
        Console.WriteLine(param);
    }
    
    public static void OutExampleCall()
    {
        OutExample(out var variable);
        Console.WriteLine(variable);

        int otherVariable;
        OutExample(out otherVariable);
    }
}