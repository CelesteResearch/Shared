using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Effects.Mirrors;

namespace Celeste.Game.Gameplay.Environment.Mirrors
{
    public class OriginalTempleMirrorState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;

        private class Frame : SceneEntityState
        {
            private readonly OriginalTempleMirrorState mirror;

            public Frame(OriginalTempleMirrorState mirror)
                : base(((ISourceEntitySourceDataEnvironment)mirror.engine).EntitySourceDataRegistration)
            {
                this.mirror = mirror;
                Depth = 8995;
            }

            public override void Render(ISourceRenderContext context)
            {
                Position = mirror.Position;
                var frame = mirror.frame;
                var size = mirror.size;
                SourceAtlasDrawing.Draw(context, this, frame[0, 0], Position + new Vector2(0f, 0f), Vector2.Zero,
                    PackedColor.White);
                SourceAtlasDrawing.Draw(context, this, frame[2, 0], Position + new Vector2(size.X - 8f, 0f),
                    Vector2.Zero,
                    PackedColor.White);
                SourceAtlasDrawing.Draw(context, this, frame[0, 2], Position + new Vector2(0f, size.Y - 8f),
                    Vector2.Zero,
                    PackedColor.White);
                SourceAtlasDrawing.Draw(context, this, frame[2, 2], Position + new Vector2(size.X - 8f, size.Y - 8f),
                    Vector2.Zero, PackedColor.White);
                for (var i = 1; i < size.X / 8f - 1f; i++)
                {
                    SourceAtlasDrawing.Draw(context, this, frame[1, 0], Position + new Vector2(i * 8, 0f), Vector2.Zero,
                        PackedColor.White);
                    SourceAtlasDrawing.Draw(context, this, frame[1, 2], Position + new Vector2(i * 8, size.Y - 8f),
                        Vector2.Zero, PackedColor.White);
                }

                for (var j = 1; j < size.Y / 8f - 1f; j++)
                {
                    SourceAtlasDrawing.Draw(context, this, frame[0, 1], Position + new Vector2(0f, j * 8), Vector2.Zero,
                        PackedColor.White);
                    SourceAtlasDrawing.Draw(context, this, frame[2, 1], Position + new Vector2(size.X - 8f, j * 8),
                        Vector2.Zero, PackedColor.White);
                }
            }
        }

        private readonly PackedColor color = SourceHexColor.HexToColor("05070e");

        private readonly Vector2 size;

        private readonly AtlasEntry[,] frame = new AtlasEntry[3, 3];

        private readonly MirrorSurfaceState surface;

        public OriginalTempleMirrorState(EntityData e, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, e.Position + offset)
        {
            this.engine = engine;
            size = new(e.Width, e.Height);
            Depth = 9500;
            Collider = new HitboxColliderGeometry(e.Width, e.Height);
            Add(surface = new(((ISourceExtremaEnvironment)engine).ExtremaArithmetic));
            surface.ReflectionOffset = new(EntityAttributeReader.Float(e.Values, "reflectX"),
                EntityAttributeReader.Float(e.Values, "reflectY"));
            surface.OnRender = delegate
            {
                SourcePrimitiveDrawing.Rect(((OriginalLevelSceneRoot)Scene).SourceRenderContext, this, X + 2f, Y + 2f,
                    size.X - 4f, size.Y - 4f, surface.ReflectionColor);
            };
            var mTexture =
                ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).GameAtlas[
                    "scenery/templemirror"];
            for (var num = 0; num < mTexture.FrameWidth / 8; num++)
            for (var num2 = 0; num2 < mTexture.FrameHeight / 8; num2++)
                frame[num, num2] = mTexture.GetSubtexture(new(num * 8, num2 * 8, 8, 8));
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            ((ISourceScene)scene).SourceScene.QueueSourceEntity(new Frame(this));
        }

        public override void Render(ISourceRenderContext context)
        {
            SourcePrimitiveDrawing.Rect(context, this, X + 3f, Y + 3f, size.X - 6f, size.Y - 6f, color);
        }
    }
}
