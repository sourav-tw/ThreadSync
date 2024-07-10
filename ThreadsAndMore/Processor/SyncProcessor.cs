using ThreadsAndMore.StrategyContract;

namespace ThreadsAndMore.Processor;

public class SyncProcessor(ISyncStrategy strategy, bool shouldLock = false)
{
    public void SetStrategy(ISyncStrategy syncStrategy)
    {
        strategy = syncStrategy;
        shouldLock = true;
    }
    public void Write()
    {
        strategy.Write(shouldLock);
    }
    public void Read()
    {
        strategy.Read(shouldLock);
    }
}