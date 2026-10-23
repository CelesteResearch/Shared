using Celeste.Core.Geometry;

namespace Celeste.Simulation.Presentation.PostProcessing.Bloom
{
    public sealed class BloomCutoutPresentation : IBloomCutout
    {
        public Bounds Bounds;
        public float Alpha = 1;
        public bool Visible = true, EntityVisible = true;
        bool IBloomCutout.Visible => Visible;
        float IBloomCutout.Alpha => Alpha;

        public IntRect DrawBounds => new(
            (int)Bounds.X, (int)Bounds.Y, (int)Bounds.Right - (int)Bounds.X,
            (int)Bounds.Bottom - (int)Bounds.Y);
    }
}
