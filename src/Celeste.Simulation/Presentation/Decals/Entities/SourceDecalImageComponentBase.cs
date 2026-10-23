using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Simulation.Presentation.Decals.Entities
{
    public abstract class SourceDecalImageComponentBase : SourceComponentState
    {
        protected SourceDecalEntityState Decal => (SourceDecalEntityState)Entity;

        protected SourceDecalImageComponentBase(bool active) : base(active, true)
        {
        }

        public abstract override void Render(ISourceRenderContext context);

        protected void Draw(ISourceRenderContext context, AtlasEntry texture, Vector2 position, Vector2 origin,
            float rotation = 0f)
            => Draw(context, texture, position, origin, Decal.Color, rotation);

        protected void Draw(ISourceRenderContext context, AtlasEntry texture, Vector2 position, Vector2 origin,
            PackedColor color, float rotation)
        {
            SourceAtlasDrawing.Draw(context, Entity, texture, position, origin, color, Decal.Scale, rotation);
        }
    }
}
