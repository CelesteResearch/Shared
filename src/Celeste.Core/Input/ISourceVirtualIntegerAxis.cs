using System.Numerics;

namespace Celeste.Core.Input
{
    public interface ISourceVirtualIntegerAxis
    {
        int Value { get; set; }
        int PreviousValue { get; }
        bool Inverted { get; set; }
    }
}
