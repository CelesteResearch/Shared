using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Platforms.Cassette.Components
{
    public sealed class CassetteStaticAttachment
    {
        public bool IsSpikes;
        public Action Enable, Disable;
        public Action<Vector2> Move, SetOrigin, SetScale;
        public Action<int> SetDepth;
        public Action<Vector4, Vector4> SetColors;
    }
}
