namespace ThreadsAndMore;

public class SyncProcessor(ISyncStrategy strategy)
{
    public void SetStrategy(ISyncStrategy syncStrategy)
    {
        strategy = syncStrategy;
    }
    public void Write()
    {
        strategy.Write();
    }
    public void Read()
    {
        strategy.Read();
    }
}