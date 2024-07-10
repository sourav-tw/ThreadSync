namespace ThreadsAndMore.StrategyContract;

public interface ISyncStrategy
{
    public void Write(bool shouldLock, int threadNo=1);
    public void Read(bool shouldLock);
}