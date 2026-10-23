using Celeste.Core.Components;

namespace Celeste.Core.Scheduling
{
    public class TimeRateModifier : SourceComponentState, ISourceTimeRateModifier
    {
        public float Multiplier;
        public bool Enabled;

        float ISourceTimeRateModifier.Multiplier => Multiplier;
        bool ISourceTimeRateModifier.Enabled => Enabled;

        public TimeRateModifier(float multiplier, bool enabled = true) : base(false, false)
        {
            Multiplier = multiplier;
            Enabled = enabled;
        }
    }
}
