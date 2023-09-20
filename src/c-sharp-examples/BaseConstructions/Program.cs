namespace BaseConstructions;

internal static class Program
{
    private static void Main(string[] args)
    {
        // Variables example.
        bool boolVar = true; 
        
        int intVar = 42; 
        double doubleVar = 42.0;
        
        int[] array = new[] {1, 2, 3, 4, 5 };
        
        string stringVar = "Good string"; 
        char charVal = stringVar[0];

        EnumExample enumVar = EnumExample.First;
        ClassExample classVariable = new ClassExample();

        var autoVariable = doubleVar - 10;
        
        // Conditions example.
        if (boolVar)
            Console.WriteLine(stringVar);
        else 
            Console.WriteLine(intVar);

        switch (enumVar)
        {
            case EnumExample.First:
                break;
            case EnumExample.Second:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        

        // Cycles example.
        for (int i = 0; i < array.Length; i++)
            Console.Write(array[i].ToString() + " "); 
        Console.WriteLine();

        var flag = true;
        var counter = 0;

        while (flag)
            flag = (++counter) == intVar;

        // or 
        do
        {
            flag = (++counter) == intVar;
        } while (flag);
    }
}
