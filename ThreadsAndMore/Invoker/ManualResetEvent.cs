using ThreadsAndMore.ConcreteStrategy;
using ThreadsAndMore.Processor;

namespace ThreadsAndMore.Invoker;

public class ManualResetEvent: Base
{
    public override void Invoke()
    {
        Console.WriteLine("------------------");
        Console.WriteLine("Without ManualResetEvent Strategy");
        Console.WriteLine("------------------");
        SyncProcessor syncProcessor = new SyncProcessor(new ManualResetEventStrategy());
        new Thread(() => syncProcessor.Write()).Start();
        for (int i = 0; i < 3; i++)
        {
            new Thread(() => syncProcessor.Read()).Start();
        }
        Thread.Sleep(2001);
        syncProcessor.SetStrategy(new ManualResetEventStrategy());
        Console.WriteLine("------------------");
        Console.WriteLine("With ManualResetEvent Strategy");
        Console.WriteLine("------------------");
        new Thread(() => syncProcessor.Write()).Start();
        for (int i = 0; i < 3; i++)
        {
            new Thread(() => syncProcessor.Read()).Start();
        }
    }
}