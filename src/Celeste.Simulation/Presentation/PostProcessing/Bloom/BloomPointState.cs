using System.Numerics;
using Celeste.Core.Components;
using Celeste.Scene.Components;

namespace Celeste.Simulation.Presentation.PostProcessing.Bloom
{
    // Actual BloomPoint and the renderer's point are the same object.
    public sealed class BloomPointState : BloomPointPresentation
    {
        public float X
        {
            get => Position.X;
            set => Position.X = value;
        }

        public float Y
        {
            get => Position.Y;
            set => Position.Y = value;
        }

        public BloomPointState()
        {
        }

        public BloomPointState(float alpha, float radius)
        {
            Alpha = alpha;
            Radius = radius;
        }

        public BloomPointState(Vector2 position, float alpha, float radius)
        {
            Position = position;
            Alpha = alpha;
            Radius = radius;
        }
    }
}
