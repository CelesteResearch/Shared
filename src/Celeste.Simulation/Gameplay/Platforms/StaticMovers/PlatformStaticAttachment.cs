using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Platforms.StaticMovers
{
    public sealed class PlatformStaticAttachment
    {
        public Action<Vector2> Move, Shake;
        public Action Enable, Disable, Destroy;
    }
}
