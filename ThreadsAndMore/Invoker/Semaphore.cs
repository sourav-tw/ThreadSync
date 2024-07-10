using ThreadsAndMore.ConcreteStrategy;
using ThreadsAndMore.Processor;

namespace ThreadsAndMore.Invoker;

public class Semaphore : Base
{
    public override void Invoke()
    { 
        Console.WriteLine("------------------");
        Console.WriteLine("Without Semaphore Strategy");
        Console.WriteLine("------------------");
        SyncProcessor syncProcessor = new SyncProcessor(new SemaphorStrategy());
        for (int i = 0; i < 3; i++)
        {
            new Thread(() => syncProcessor.Write()).Start();
        }
        Thread.Sleep(2001);
        syncProcessor.SetStrategy(new SemaphorStrategy());
        Console.WriteLine("------------------");
        Console.WriteLine("With Semaphore Strategy");
        Console.WriteLine("------------------");
        for (int i = 0; i < 5; i++)
        {
            new Thread(() => syncProcessor.Write()).Start();
        }
    }
}