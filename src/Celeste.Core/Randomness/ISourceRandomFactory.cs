namespace Celeste.Core.Randomness
{
    public interface ISourceRandomFactory
    {
        ISourceRandom CreateUnseeded();
        ISourceRandom CreateSeeded(int seed);
    }
}
