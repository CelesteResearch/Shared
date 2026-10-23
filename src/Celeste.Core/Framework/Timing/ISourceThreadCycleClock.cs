namespace Celeste.Core.Framework.Timing
{
    public interface ISourceThreadCycleClock
    {
        bool TryRead(out ulong cycles);
    }
}
