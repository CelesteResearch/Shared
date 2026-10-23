using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Scene.Entities;

namespace Celeste.Game.Presentation.Platforms.Wood
{
    public static class WoodPlatformDrawing
    {
        public static void Render(ISourceRenderContext context, SceneEntityState entity, AtlasEntry[] textures)
        {
            Draw(context, entity, textures[0], entity.Position);
            for (int i = 8; i < entity.Width - 8f; i += 8)
                Draw(context, entity, textures[1], entity.Position + new Vector2(i, 0));
            Draw(context, entity, textures[3], entity.Position + new Vector2(entity.Width - 8f, 0));
            Draw(context, entity, textures[2], entity.Position + new Vector2(entity.Width / 2f - 4f, 0));
        }

        private static void Draw(ISourceRenderContext context, SceneEntityState entity, AtlasEntry texture, Vector2 at)
        {
            var draw = new AtlasTextureDraw(texture, at, Vector2.Zero, PackedColor.White, Vector2.One);
            ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in draw, entity);
        }
    }
}
