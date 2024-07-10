using ThreadsAndMore.ConcreteStrategy;
using ThreadsAndMore.Processor;

namespace ThreadsAndMore.Invoker;

public class Mutex: Base
{
    public override void Invoke()
    {
Console.WriteLine("------------------");
        Console.WriteLine("Without Mutex Strategy");
        Console.WriteLine("------------------");
        SyncProcessor syncProcessor = new SyncProcessor(new MutexStrategy());
        for (int i = 0; i < 3; i++)
        {
            new Thread(() => syncProcessor.Write()).Start();
        }
        Thread.Sleep(2001);
        syncProcessor.SetStrategy(new MutexStrategy());
        Console.WriteLine("------------------");
        Console.WriteLine("With Mutex Strategy");
        Console.WriteLine("------------------");
        for (int i = 0; i < 3; i++)
        {
            new Thread(() => syncProcessor.Write()).Start();
        }
        
        Thread.Sleep(7001);
        syncProcessor.SetStrategy(new MutexStrategy());
        Console.WriteLine("------------------");
        Console.WriteLine("With Mutex Signal sent from another thread");
        Console.WriteLine("------------------");
        for (int i = 0; i < 3; i++)
        {
            new Thread(() => syncProcessor.Write()).Start();
        }
        
        new Thread(() => syncProcessor.Read()).Start();
    }
}