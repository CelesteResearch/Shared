using System;
using System.Collections.Generic;

namespace Celeste.Simulation.Presentation.Effects.Mirrors
{
    // A real, distinct MirrorReflection component; renderer registration is
    // separate from entity construction and from its owner visibility.
    public sealed class MirrorItemReflection
    {
        public bool Active = false, Visible = true, IgnoreEntityVisible, IsRendering;

        public readonly global::Celeste.Simulation.Presentation.Effects.Mirrors.MirrorRenderCollection.Reflection
            Component;

        global::Celeste.Simulation.Presentation.Effects.Mirrors.MirrorRenderCollection collection;
        public bool AddedToScene { get; private set; }

        public MirrorItemReflection(Func<int> depth, Func<bool> ownerVisible,
            Func<IEnumerable<global::Celeste.Graphics.Display.ImagePlacement>> render)
        {
            Component = new global::Celeste.Simulation.Presentation.Effects.Mirrors.MirrorRenderCollection.Reflection
            {
                Depth = depth, OwnerVisible = ownerVisible, Visible = () => Visible,
                IgnoreEntityVisible = () => IgnoreEntityVisible, SetIsRendering = value => IsRendering = value,
                RenderImages = render
            };
        }

        internal void Added(global::Celeste.Simulation.Presentation.Effects.Mirrors.MirrorRenderCollection target)
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
