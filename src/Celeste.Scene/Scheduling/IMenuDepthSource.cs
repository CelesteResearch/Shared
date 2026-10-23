#nullable enable
using System;

namespace Celeste.Scene.Scheduling
{
    public interface IMenuDepthSource
    {
        int Depth { get; }
        event Action<int> DepthChanged;
    }
}
