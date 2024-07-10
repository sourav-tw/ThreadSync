using ThreadsAndMore.StrategyContract;

namespace ThreadsAndMore.Processor;

public class SyncProcessor(ISyncStrategy strategy, bool shouldLock = false)
{
    public void SetStrategy(ISyncStrategy syncStrategy)
    {
        strategy = syncStrategy;
        shouldLock = true;
    }
    public void Write(int i = 1)
    {
        strategy.Write(shouldLock,i);
    }
    public void Read()
    {
        strategy.Read(shouldLock);
    }
}