namespace Celeste.Core.Scheduling
{
    public interface ISourceTimeRateModifier
    {
        bool Enabled { get; }
        float Multiplier { get; }
    }
}
