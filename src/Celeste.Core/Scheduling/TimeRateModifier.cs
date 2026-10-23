using Celeste.Core.Components;

namespace Celeste.Core.Scheduling
{
    public class TimeRateModifier(float multiplier, bool enabled = true)
        : SourceComponentState(false, false), ISourceTimeRateModifier
    {
        public float Multiplier = multiplier;
        public bool Enabled = enabled;
        float ISourceTimeRateModifier.Multiplier => Multiplier;

        bool ISourceTimeRateModifier.Enabled => Enabled;
    }
}
