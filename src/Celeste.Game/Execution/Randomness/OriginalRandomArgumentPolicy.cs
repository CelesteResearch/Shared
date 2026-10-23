using System;
using Celeste.Core.Randomness;

namespace Celeste.Game.Execution.Randomness
{
    public sealed class OriginalRandomArgumentPolicy : ISourceRandomArgumentPolicy
    {
        public ArgumentOutOfRangeException NegativeMaximum(int value) =>
            new("maxValue", "'maxValue' must be greater than zero.");

        // Framework Random has no Int64 API; this extension retains its argument contract.
        public ArgumentOutOfRangeException NegativeMaximum(long value) =>
            new("maxValue", "'maxValue' must be greater than zero.");

        public ArgumentOutOfRangeException SwappedRange() =>
            new("minValue", "'minValue' cannot be greater than maxValue.");
    }
}
