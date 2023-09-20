namespace Lecture10;

public static class AsyncAwaitExample
{
    public static void Run()
    {
        Console.WriteLine($"PID: {Environment.CurrentManagedThreadId} Main START");
        DoWorkAsync().Wait();
        Console.WriteLine($"PID: {Environment.CurrentManagedThreadId} Main END");
    }

    private static async Task DoWorkAsync()
    {
        Console.WriteLine($"PID: {Environment.CurrentManagedThreadId} START");

        await Task.Delay(1000);
        // real work with awaiting
        Console.WriteLine($"PID: {Environment.CurrentManagedThreadId} END");
    }
}