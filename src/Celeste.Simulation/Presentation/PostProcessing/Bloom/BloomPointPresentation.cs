using System.Numerics;
using Celeste.Core.Components;

namespace Celeste.Simulation.Presentation.PostProcessing.Bloom
{
    public class BloomPointPresentation : SourceComponentState
    {
        public Vector2 Position, WorldPosition;
        public float Alpha = 1, Radius = 8;

        public BloomPointPresentation() : base(false, true)
        {
        }

        public bool EntityVisible = true;
    }
}
