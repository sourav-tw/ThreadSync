namespace ThreadsAndMore;

public interface ISyncStrategy
{
    public void Write();
    public void Read();
}