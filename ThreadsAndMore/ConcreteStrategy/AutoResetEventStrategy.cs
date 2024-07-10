using ThreadsAndMore.StrategyContract;

namespace ThreadsAndMore.ConcreteStrategy;

public class AutoResetEventStrategy: ISyncStrategy
{
    AutoResetEvent _autoResetEvent = new AutoResetEvent(true);
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
            _autoResetEvent.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is writing");
            Thread.Sleep(2000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has finished writing");
            _autoResetEvent.Set();
        }
    }

    public void Read(bool shouldLock)
    {
        if (shouldLock)
        {
            Thread.Sleep(2500);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has started reading");
            _autoResetEvent.Set();
        }
    }
}