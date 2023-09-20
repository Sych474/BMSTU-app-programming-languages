namespace Lecture10;

public static class TasksExamples
{
    public static void Run()
    {
        var task = new Task(() =>
        {
            Console.WriteLine($"PID: {Environment.CurrentManagedThreadId} START");
            Task.Delay(1000);
            Console.WriteLine($"PID: {Environment.CurrentManagedThreadId} END");
        });
        
        task.Start();
        task.Wait();
        Console.WriteLine($"PID: {Environment.CurrentManagedThreadId} Main thread");
    }
    
    public static void RunWithCancellationTokenSource()
    {
        var source = new CancellationTokenSource();
        Task.Run(() =>
        {
            Console.WriteLine($"PID: {Environment.CurrentManagedThreadId} START");
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine($"PID: {Environment.CurrentManagedThreadId} {i}");
                Thread.Sleep(100);
            }
            Console.WriteLine($"PID: {Environment.CurrentManagedThreadId} END");
        }, source.Token);

        Thread.Sleep(500);
        source.Cancel();
        Console.WriteLine($"PID: {Environment.CurrentManagedThreadId} Main thread");
    }
}