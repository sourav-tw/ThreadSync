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
        for (var i = 0; i < 3; i++)
        {
            new Thread(() => syncProcessor.Write()).Start();
        }
        Thread.Sleep(4001);
        syncProcessor.SetStrategy(new LockStrategy());
        Console.WriteLine("------------------");
        Console.WriteLine("With Lock Strategy");
        Console.WriteLine("------------------");
        for (var i = 0; i < 3; i++)
        {
            new Thread(() => syncProcessor.Write()).Start();
        }
    }
}