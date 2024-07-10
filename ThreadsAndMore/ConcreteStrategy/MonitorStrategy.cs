using ThreadsAndMore.StrategyContract;

namespace ThreadsAndMore.ConcreteStrategy;

public class MonitorStrategy: ISyncStrategy
{
    private readonly object _lock = new object();
    public void Write(bool shouldLock, int threadNo)
    {
        if (!shouldLock)
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is writing");
            Thread.Sleep(2000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has finished writing");
        }
        else
        {
            try
            {
                Monitor.Enter(_lock);
                if (threadNo == 5)
                    throw new ApplicationException("No exception handling");
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is writing");
                Thread.Sleep(2000);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has finished writing");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Monitor.Exit(_lock);   
            }
        }
    }

    public void Read(bool shouldLock)
    {
        throw new NotImplementedException();
    }
}