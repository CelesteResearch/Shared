using System;
using System.Collections.Generic;
using Celeste.Graphics.Display;

namespace Celeste.Simulation.Presentation.Effects.Mirrors
{
    // A real, distinct MirrorReflection component; renderer registration is
    // separate from entity construction and from its owner visibility.
    public sealed class MirrorItemReflection
    {
        public bool Active = false, Visible = true, IgnoreEntityVisible, IsRendering;

        public readonly MirrorRenderCollection.Reflection
            Component;

        private MirrorRenderCollection collection;
        public bool AddedToScene { get; private set; }

        public MirrorItemReflection(Func<int> depth, Func<bool> ownerVisible,
            Func<IEnumerable<ImagePlacement>> render)
        {
            Component = new()
            {
                Depth = depth, OwnerVisible = ownerVisible, Visible = () => Visible,
                IgnoreEntityVisible = () => IgnoreEntityVisible, SetIsRendering = value => IsRendering = value,
                RenderImages = render,
            };
        }

        internal void Added(MirrorRenderCollection target)
        {
            if (AddedToScene)
                throw new InvalidOperationException("MirrorReflection was registered twice for the same Entity.Added.");
            AddedToScene = true;
            collection = target;
            collection?.Add(Component);
        }

        internal void Removed()
        {
            if (!AddedToScene) return;
            collection?.Remove(Component);
            collection = null;
            AddedToScene = false;
        }
    }
}
