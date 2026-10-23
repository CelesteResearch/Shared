using System;
using System.Numerics;

namespace Celeste.Simulation.Gameplay.Platforms.StaticMovers
{
    public sealed class PlatformStaticAttachment
    {
        public Action<Vector2> Move, Shake;
        public Action Enable, Disable, Destroy;
    }
}
