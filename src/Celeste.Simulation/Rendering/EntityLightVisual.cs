using System.Numerics;

namespace Celeste.Simulation.Rendering
{
    public sealed class EntityLightVisual
    {
        public Vector2 Position;
        public Vector4 Color = Vector4.One;
        public float Alpha = 1, StartRadius, EndRadius;
        public bool Active = true, Visible = true;
    }
}
