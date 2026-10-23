using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Input;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Scene
{
    // Entity systems attach their actual behavior here as they are implemented. A missing
    // callback means no such interaction is registered; MissingEntityTypes exposes map gaps.
    public sealed class RoomPlayerInteractions
    {
        public Action<float> FreezeRequested;
        public Func<RoomPlayerWorld, bool> PlayerOverTalk, Chapter9BoosterBusy;
        public Action<RoomPlayerWorld, Vector2> DashStarted, BoosterBoosted;
        public Func<RoomPlayerWorld, Vector2, bool> TryBoosterBoosted;
    }
}
