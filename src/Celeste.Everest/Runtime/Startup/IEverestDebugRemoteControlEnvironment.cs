using System;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Everest.Runtime.Startup
{
    public interface IEverestDebugRemoteControlEnvironment
    {
        EverestDebugRemoteControlProcess DebugRC { get; }
    }
}
