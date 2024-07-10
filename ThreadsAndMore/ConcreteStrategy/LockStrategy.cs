using ThreadsAndMore.StrategyContract;

namespace ThreadsAndMore.ConcreteStrategy;

public class LockStrategy : ISyncStrategy {
    private readonly object _lock = new object();
    public void Write(bool shouldLock)
    {
        if (!shouldLock)
        {
            // Write to console the current date time with milisecond precision
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
                lock (_lock)
                {
                    Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}  " +
                                      $"Thread {Thread.CurrentThread.ManagedThreadId} has started writing");
                    Thread.Sleep(2000);
                    Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}  " +
                                      $"Thread {Thread.CurrentThread.ManagedThreadId} has finished writing");
                }
        }
    }

    public void Read(bool shouldLock)
    {
        throw new NotImplementedException();
    }
}