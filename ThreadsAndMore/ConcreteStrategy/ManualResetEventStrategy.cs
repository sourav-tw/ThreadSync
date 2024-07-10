using ThreadsAndMore.StrategyContract;

namespace ThreadsAndMore.ConcreteStrategy;

public class ManualResetEventStrategy : ISyncStrategy
{
    ManualResetEvent _manualResetEvent = new ManualResetEvent(false);
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
                              $"Thread {Thread.CurrentThread.ManagedThreadId} is writing");
                _manualResetEvent.Reset();
                Thread.Sleep(2000);
                Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}  " +
                                  $"Thread {Thread.CurrentThread.ManagedThreadId} has finished writing");
                _manualResetEvent.Set();
        }
    }

    public void Read(bool shouldLock)
    {
        if (!shouldLock)
        {
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}  " +
                              $"Thread {Thread.CurrentThread.ManagedThreadId} is waiting");
            Thread.Sleep(500);
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}  " +
                              $"Thread {Thread.CurrentThread.ManagedThreadId} has read the file");
        }
        else
        {
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}  " +
                              $"Thread {Thread.CurrentThread.ManagedThreadId} is waiting");
                _manualResetEvent.WaitOne();
                Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}  " +
                                  $"Thread {Thread.CurrentThread.ManagedThreadId} has read the file");
        }
    }
    }