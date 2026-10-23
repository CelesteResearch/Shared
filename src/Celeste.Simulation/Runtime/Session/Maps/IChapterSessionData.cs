using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;
using Celeste.Simulation;

namespace Celeste.Simulation.Runtime.Session.Maps
{
    // Runtime AreaData/ModeProperties/MapData lookup; it is rebound after loading a save.
    public interface IChapterSessionData
    {
        global::Celeste.Simulation.Runtime.Session.Maps.IChapterSessionMapData GetMap(int areaID, int mode);
        global::Celeste.Simulation.Audio.RoomAudioState GetAudioState(int areaID, int mode);
    }
}
