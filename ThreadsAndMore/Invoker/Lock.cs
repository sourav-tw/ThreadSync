using ThreadsAndMore.ConcreteStrategy;
using ThreadsAndMore.Processor;

namespace ThreadsAndMore.Invoker;

public class Lock : Base
{
    public override void Invoke()
    {
        Console.WriteLine("------------------");
        Console.WriteLine("Without Lock Strategy");
        Console.WriteLine("------------------");
        SyncProcessor syncProcessor = new SyncProcessor(new LockStrategy());
        for (int i = 0; i < 3; i++)
        {
            new Thread(() => syncProcessor.Write(i)).Start();
        }
        Thread.Sleep(2001);
        syncProcessor.SetStrategy(new LockStrategy());
        Console.WriteLine("------------------");
        Console.WriteLine("With Lock Strategy");
        Console.WriteLine("------------------");
        for (int i = 0; i < 3; i++)
        {
            new Thread(() => syncProcessor.Write(i)).Start();
        }
        Thread.Sleep(6001);
        Console.WriteLine("------------------");
        Console.WriteLine("With Exception Cases");
        Console.WriteLine("------------------");
        for (int i = 0; i < 5; i++)
        {
            new Thread(() => syncProcessor.Write(i)).Start();
        }
    }
}