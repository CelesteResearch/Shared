using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Physics.Collision.Shapes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Game.Entities.PlaybackBillboard
{
    public class PlaybackBillboardState : SceneEntityState
    {
        private class FG : SceneEntityState
        {
            public PlaybackBillboardState Parent;

            public FG(PlaybackBillboardState parent) : base(((ISourceEntitySourceDataEnvironment)parent.engine)
                .EntitySourceDataRegistration)
            {
                Parent = parent;
                base.Depth = Parent.Depth - 5;
            }

            public override void Render(ISourceRenderContext context)
            {
                uint seed = Parent.Seed;
                DrawNoise(context, Parent.Collider.Bounds, ref seed, PackedColor.White * 0.1f,
                    ((ISourceExtremaEnvironment)Parent.engine).ExtremaArithmetic);
                for (int i = (int)Parent.Y; (float)i < Parent.Bottom; i += 2)
                {
                    float num = 0.05f +
                                (1f + (float)Math.Sin((float)i / 16f +
                                                      ((OriginalLevelSceneRoot)Scene).TimeActive * 2f)) /
                                2f * 0.2f;
                    SourcePrimitiveDrawing.Line(context, this, new Vector2(Parent.X, i),
                        new Vector2(Parent.X + Parent.Width, i), PackedColor.Teal * num,
                        ((ISourceVectorEnvironment)Parent.engine).VectorArithmetic);
                }
            }
        }

        internal static Type ForegroundEntityType => typeof(FG);

        public const int BGDepth = 9010;

        private readonly ISourceEngineContext engine;
        public const int BackgroundDepth = BGDepth;

        public uint Seed;

        private AtlasEntry[,] tiles;

        public PlaybackBillboardState(EntityData e, Vector2 offset, ISourceEngineContext engine)
            : this(engine, e.Position + offset, e.Width, e.Height)
        {
        }

        public PlaybackBillboardState(ISourceEngineContext engine, Vector2 position, int width, int height)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Position = position;
            base.Collider = new HitboxColliderGeometry(width, height);
            base.Depth = 9010;
            OwnedComponents.Add(new CustomBloomCallbackComponentState(RenderBloom));
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            ((ISourceScene)scene).SourceScene.QueueSourceEntity(new FG(this));
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            AtlasEntry mTexture = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["scenery/tvSlices"];
            tiles = new AtlasEntry[mTexture.FrameWidth / 8, mTexture.FrameHeight / 8];
            for (int i = 0; i < mTexture.FrameWidth / 8; i++)
            {
                for (int j = 0; j < mTexture.FrameHeight / 8; j++)
                {
                    tiles[i, j] = mTexture.GetSubtexture(new IntRect(i * 8, j * 8, 8, 8));
                }
            }

            int num = (int)(base.Width / 8f);
            int num2 = (int)(base.Height / 8f);
            for (int k = -1; k <= num; k++)
            {
                AutoTile(k, -1);
                AutoTile(k, num2);
            }

            for (int l = 0; l < num2; l++)
            {
                AutoTile(-1, l);
                AutoTile(num, l);
            }
        }

        private void AutoTile(int x, int y)
        {
            if (Empty(x, y))
            {
                bool flag = !Empty(x - 1, y);
                bool flag2 = !Empty(x + 1, y);
                bool flag3 = !Empty(x, y - 1);
                bool flag4 = !Empty(x, y + 1);
                bool flag5 = !Empty(x - 1, y - 1);
                bool flag6 = !Empty(x + 1, y - 1);
                bool flag7 = !Empty(x - 1, y + 1);
                bool flag8 = !Empty(x + 1, y + 1);
                if (!flag2 && !flag4 && flag8)
                {
                    Tile(x, y, tiles[0, 0]);
                }
                else if (!flag && !flag4 && flag7)
                {
                    Tile(x, y, tiles[2, 0]);
                }
                else if (!flag3 && !flag2 && flag6)
                {
                    Tile(x, y, tiles[0, 2]);
                }
                else if (!flag3 && !flag && flag5)
                {
                    Tile(x, y, tiles[2, 2]);
                }
                else if (flag2 && flag4)
                {
                    Tile(x, y, tiles[3, 0]);
                }
                else if (flag && flag4)
                {
                    Tile(x, y, tiles[4, 0]);
                }
                else if (flag2 && flag3)
                {
                    Tile(x, y, tiles[3, 2]);
                }
                else if (flag && flag3)
                {
                    Tile(x, y, tiles[4, 2]);
                }
                else if (flag4)
                {
                    Tile(x, y, tiles[1, 0]);
                }
                else if (flag2)
                {
                    Tile(x, y, tiles[0, 1]);
                }
                else if (flag)
                {
                    Tile(x, y, tiles[2, 1]);
                }
                else if (flag3)
                {
                    Tile(x, y, tiles[1, 2]);
                }
            }
        }

        private void Tile(int x, int y, AtlasEntry tile)
        {
            SpriteImage image = new SpriteImage(tile);
            image.Position = new Vector2(x, y) * 8f;
            OwnedComponents.Add(image);
        }

        private bool Empty(int x, int y)
        {
            return !SourceSceneCollision.CheckRect(((ISourceScene)Scene).SourceScene.Entities,
                "Celeste.PlaybackBillboard",
                new IntRect((int)base.X + x * 8, (int)base.Y + y * 8, 8, 8));
        }

        public override void Update()
        {
            base.Update();
            if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.1f, engine))
            {
                Seed++;
            }
        }

        private void RenderBloom()
        {
            var collider = Collider;
            SourcePrimitiveDrawing.Rect(((ISourceRenderEnvironment)engine).CurrentContext, this, collider.AbsoluteLeft,
                collider.AbsoluteTop, collider.Width, collider.Height, PackedColor.White * 0.4f);
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
            uint seed = Seed;
            var collider = Collider;
            SourcePrimitiveDrawing.Rect(context, this, collider.AbsoluteLeft, collider.AbsoluteTop, collider.Width,
                collider.Height, ((IPlaybackBillboardColorsEnvironment)engine).PlaybackBillboardColors.BackgroundColor);
            DrawNoise(context, base.Collider.Bounds, ref seed, PackedColor.White * 0.1f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
        }

        public static void DrawNoise(ISourceRenderContext context, IntRect bounds, ref uint seed, PackedColor color,
            ISourceExtremaArithmetic arithmetic)
        {
            AtlasEntry mTexture = ((ISourceGameAtlasRenderContext)context).GameAtlas["util/noise"];
            Vector2 vector = new Vector2(PseudoRandRange(ref seed, 0f, mTexture.FrameWidth / 2),
                PseudoRandRange(ref seed, 0f, mTexture.FrameHeight / 2));
            Vector2 vector2 = new Vector2(mTexture.FrameWidth, mTexture.FrameHeight) / 2f;
            for (float num = 0f; num < (float)bounds.Width; num += vector2.X)
            {
                float num2 = arithmetic.Min((float)bounds.Width - num, vector2.X);
                for (float num3 = 0f; num3 < (float)bounds.Height; num3 += vector2.Y)
                {
                    float num4 = arithmetic.Min((float)bounds.Height - num3, vector2.Y);
                    int x = (int)((float)mTexture.ClipRect.X + vector.X);
                    int y = (int)((float)mTexture.ClipRect.Y + vector.Y);
                    IntRect value = new IntRect(x, y, (int)num2, (int)num4);
                    ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(mTexture.ReadTextureForSpriteBatch(),
                        new Vector2((float)bounds.X + num, (float)bounds.Y + num3), value, color.PackedValue);
                }
            }
        }

        private static uint PseudoRand(ref uint seed)
        {
            seed ^= seed << 13;
            seed ^= seed >> 17;
            return seed;
        }

        private static float PseudoRandRange(ref uint seed, float min, float max)
        {
            return min + (float)(PseudoRand(ref seed) % 1000) / 1000f * (max - min);
        }
    }
}
