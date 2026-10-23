using Celeste.Core.Geometry;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Content.VirtualAssets
{
    public class VirtualRenderTarget : VirtualAsset
    {
        public SourceRenderTarget2DResource Target;
        private readonly VirtualContent Owner;

        public int MultiSampleCount;

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public bool Depth { get; private set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public bool Preserve { get; private set; }

        public bool IsDisposed
        {
            get
            {
                if (Target != null && !Target.IsDisposed) return Target.GraphicsDevice.IsDisposed;

                return true;
            }
        }

        public IntRect Bounds => Target.Bounds;

        internal VirtualRenderTarget(VirtualContent owner, string name, int width, int height, int multiSampleCount,
            bool depth, bool preserve)
        {
            Owner = owner;
            Name = name;
            Width = width;
            Height = height;
            MultiSampleCount = multiSampleCount;
            Depth = depth;
            Preserve = preserve;
            Reload();
        }

        public override void Unload()
        {
            if (Target != null && !Target.IsDisposed) Target.Dispose();
        }

        public override void Reload()
        {
            Unload();
            Target = Owner.RenderTargets.CreateRenderTarget(Name, Width, Height, MultiSampleCount, Depth, Preserve);
        }

        public override void Dispose()
        {
            Unload();
            Target = null;
            Owner.Remove(this);
        }
    }
}
