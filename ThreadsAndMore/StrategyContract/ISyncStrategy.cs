namespace ThreadsAndMore.StrategyContract;

public interface ISyncStrategy
{
    public void Write(bool shouldLock);
    public void Read(bool shouldLock);
}