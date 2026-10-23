using System;
using Celeste.Core.Randomness;

namespace Celeste.Everest.Runtime.Randomness
{
    public sealed class InstalledRandomArgumentPolicy : ISourceRandomArgumentPolicy
    {
        public ArgumentOutOfRangeException NegativeMaximum(int value) =>
            new("maxValue", value, string.Format("maxValue ('{0}') must be a non-negative value.", value));

        public ArgumentOutOfRangeException NegativeMaximum(long value) =>
            new("maxValue", value, string.Format("maxValue ('{0}') must be a non-negative value.", value));

        public ArgumentOutOfRangeException SwappedRange() =>
            new("minValue", "'minValue' cannot be greater than maxValue.");
    }
}
