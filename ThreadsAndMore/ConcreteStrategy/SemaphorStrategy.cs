using ThreadsAndMore.StrategyContract;

namespace ThreadsAndMore.ConcreteStrategy;

public class SemaphorStrategy: ISyncStrategy
{
    Semaphore semaphore = new Semaphore(2, 2);
    public void Write(bool shouldLock, int threadNo = 1)
    {
        if (!shouldLock)
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is writing");
            Thread.Sleep(2000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has finished writing");
        }
        else
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is waiting");
            semaphore.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is writing");
            Thread.Sleep(2000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has finished writing");
            semaphore.Release();
        }
    }

    public void Read(bool shouldLock)
    {
        throw new NotImplementedException();
    }
}