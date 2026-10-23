using System;

namespace Celeste.Core.Randomness
{
    public interface ISourceRandomArgumentPolicy
    {
        ArgumentOutOfRangeException NegativeMaximum(int value);
        ArgumentOutOfRangeException NegativeMaximum(long value);
        ArgumentOutOfRangeException SwappedRange();
    }
}
