using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Simulation
{
    public interface IRoomStateTriggerWorld
    {
        bool NoRefills { get; set; }
        string CurrentMusic { get; }
        global::Celeste.Simulation.Audio.IRoomAudioSession AudioSession { get; }
        global::Celeste.Graphics.Environment.Lighting.IRoomLightingParameters Environment { get; }
    }
}
