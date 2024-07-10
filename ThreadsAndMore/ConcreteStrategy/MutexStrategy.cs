using ThreadsAndMore.StrategyContract;

namespace ThreadsAndMore.ConcreteStrategy;

public class MutexStrategy: ISyncStrategy
{
    private Mutex mx = new Mutex();
    public void Write(bool shouldLock)
    {
        if (!shouldLock)
        {
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}  " +
                              $"Thread {Thread.CurrentThread.ManagedThreadId} is writing");
            Thread.Sleep(2000);
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}  " +
                              $"Thread {Thread.CurrentThread.ManagedThreadId} has finished writing");
        }
        else
        {
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}  " +
                              $"Thread {Thread.CurrentThread.ManagedThreadId} is waiting");
            mx.WaitOne();
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}  " +
                              $"Thread {Thread.CurrentThread.ManagedThreadId} is writing");
            Thread.Sleep(2000);
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}  " +
                              $"Thread {Thread.CurrentThread.ManagedThreadId} has finished writing");
             mx.ReleaseMutex();
        }
    }

    public void Read(bool shouldLock)
    {
        if (shouldLock)
        {
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}  " +
                              $"Thread {Thread.CurrentThread.ManagedThreadId} has started reading");
            mx.ReleaseMutex();
        }
    }
}