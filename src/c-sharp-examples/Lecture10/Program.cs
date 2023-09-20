namespace Lecture10;

public static class Program
{
    public static int Main()
    {
        //TasksExamples.Run();
        //TasksExamples.RunWithCancellationTokenSource();
        //ThreadsExample.Run();
        return 0;
    }
}

public static class ThreadsExample
{
    public static void Run()
    {
        RunThreadsForAction(ThreadAction);
        RunThreadsForAction(ThreadActionWithInterlocked);
        RunThreadsForAction(ThreadActionWithMonitor);
        //RunThreadsForAction(ThreadActionWithLock);
    }

    private static int _counter = 0;
    private const int IterationsCount = 100000;

    private static void RunThreadsForAction(ThreadStart start)
    {
        _counter = 0;
        var workerOne = new Thread(start);
        var workerTwo = new Thread(start);

        workerOne.Start();
        workerTwo.Start();

        Thread.Sleep(1000);
        Console.WriteLine($"[{Environment.CurrentManagedThreadId}] Counter at the end: {_counter}");
    }

    private static void ThreadAction()
    {
        Console.WriteLine($"[{Environment.CurrentManagedThreadId}] Started");
        for (var i = 0; i < IterationsCount; i++)
        {
            _counter++;
        }
        Console.WriteLine($"[{Environment.CurrentManagedThreadId}] Finished");
    }
    
    private static void ThreadActionWithInterlocked()
    {
        Console.WriteLine($"[{Environment.CurrentManagedThreadId}] Started");
        for (var i = 0; i < IterationsCount; i++)
        {
            Interlocked.Increment(ref _counter);
        }
        Console.WriteLine($"[{Environment.CurrentManagedThreadId}] Finished");
    }

    private static readonly object MonitorObj = new object();
    
    private static void ThreadActionWithMonitor()
    {
        Console.WriteLine($"[{Environment.CurrentManagedThreadId}] Started");
        for (var i = 0; i < IterationsCount; i++)
        {
            try
            {
                Monitor.Enter(MonitorObj);
                _counter++;
            }
            finally
            {
                Monitor.Exit(MonitorObj);
            }
        }
        Console.WriteLine($"[{Environment.CurrentManagedThreadId}] Finished");
    }

    private static readonly object LockObj = new object();
    
    private static void ThreadActionWithLock()
    {
        Console.WriteLine($"[{Environment.CurrentManagedThreadId}] Started");
        for (var i = 0; i < IterationsCount; i++)
        {
            lock (LockObj)
            {
                _counter++;
            }
        }
        Console.WriteLine($"[{Environment.CurrentManagedThreadId}] Finished");
    }
}