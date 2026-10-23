using System;
using Celeste.Core.Randomness;

namespace Celeste.Game.Execution.Randomness
{
    public sealed class OriginalRandomArgumentPolicy : ISourceRandomArgumentPolicy
    {
        public ArgumentOutOfRangeException NegativeMaximum(int value)
        {
            return new("maxValue", "'maxValue' must be greater than zero.");
        }

        // Framework Random has no Int64 API; this extension retains its argument contract.
        public ArgumentOutOfRangeException NegativeMaximum(long value)
        {
            return new("maxValue", "'maxValue' must be greater than zero.");
        }

        public ArgumentOutOfRangeException SwappedRange()
        {
            return new("minValue", "'minValue' cannot be greater than maxValue.");
        }
    }
}
