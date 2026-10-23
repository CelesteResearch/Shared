using System;
using Celeste.Core.Randomness;

namespace Celeste.Everest.Runtime.Randomness
{
    public sealed class InstalledRandomArgumentPolicy : ISourceRandomArgumentPolicy
    {
        public ArgumentOutOfRangeException NegativeMaximum(int value)
        {
            return new("maxValue", value, string.Format("maxValue ('{0}') must be a non-negative value.", value));
        }

        public ArgumentOutOfRangeException NegativeMaximum(long value)
        {
            return new("maxValue", value, string.Format("maxValue ('{0}') must be a non-negative value.", value));
        }

        public ArgumentOutOfRangeException SwappedRange()
        {
            return new("minValue", "'minValue' cannot be greater than maxValue.");
        }
    }
}
