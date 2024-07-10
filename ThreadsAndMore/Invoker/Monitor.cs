using ThreadsAndMore.ConcreteStrategy;
using ThreadsAndMore.Processor;

namespace ThreadsAndMore.Invoker;

public class Monitor: Base
{
    public override void Invoke()
    {
        Console.WriteLine("------------------");
        Console.WriteLine("Without Monitor Strategy");
        Console.WriteLine("------------------");
        SyncProcessor syncProcessor = new SyncProcessor(new MonitorStrategy());
        for (int i = 0; i < 3; i++)
        {
            new Thread(() => syncProcessor.Write()).Start();
        }
        Thread.Sleep(4001);
        syncProcessor.SetStrategy(new MonitorStrategy());
        Console.WriteLine("------------------");
        Console.WriteLine("With Monitor Strategy");
        Console.WriteLine("------------------");
        for (int i = 0; i < 3; i++)
        {
            new Thread(() => syncProcessor.Write()).Start();
        }
    }
}