using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Input;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Runtime.FramePacing
{
    public enum RoomEngineFrameResult
    {
        None,
        SceneUpdated,
        EngineSuppressed,
        HostPaused
    }
}
