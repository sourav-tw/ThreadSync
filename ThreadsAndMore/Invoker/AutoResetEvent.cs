using ThreadsAndMore.ConcreteStrategy;
using ThreadsAndMore.Processor;

namespace ThreadsAndMore.Invoker;

public class AutoResetEvent : Base
{
    public override void Invoke()
    {
        Console.WriteLine("------------------");
        Console.WriteLine("Without AutoResetEvent Strategy");
        Console.WriteLine("------------------");
        SyncProcessor syncProcessor = new SyncProcessor(new AutoResetEventStrategy());
        for (int i = 0; i < 3; i++)
        {
            new Thread(() => syncProcessor.Write()).Start();
        }
        Thread.Sleep(2001);
        syncProcessor.SetStrategy(new AutoResetEventStrategy());
        Console.WriteLine("------------------");
        Console.WriteLine("With AutoResetEvent Strategy");
        Console.WriteLine("------------------");
        for (int i = 0; i < 3; i++)
        {
            new Thread(() => syncProcessor.Write()).Start();
        }
        
        Thread.Sleep(7001);
        syncProcessor.SetStrategy(new AutoResetEventStrategy());
        Console.WriteLine("------------------");
        Console.WriteLine("With AutoResetEvent Signal sent from another thread");
        Console.WriteLine("------------------");
        for (int i = 0; i < 3; i++)
        {
            new Thread(() => syncProcessor.Write()).Start();
        }
        new Thread(() => syncProcessor.Read()).Start();
    }
    }
