using Celeste.Core.Display;
using Celeste.Core.Geometry;
using System;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Collections;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Geometry.TwoD.Camera;


namespace Celeste.Graphics.Content.Tiles
{
    public sealed class AnimatedTiles : SourceComponentState
    {
        private readonly ISourceEngineContext engine;

        public CameraState ClipCamera;

        public Vector2 Position;

        public PackedColor Color = PackedColor.White;

        public float Alpha = 1f;

        public AnimatedTileBank Bank;

        public VirtualMap<List<OverlayTile>> Sprites;

        public AnimatedTiles(int columns, int rows, AnimatedTileBank bank, ISourceEngineContext engine) : base(true,
            true)
        {
            Sprites = new VirtualMap<List<OverlayTile>>(columns, rows);
            Bank = bank;
            this.engine = engine;
        }

        public void Set(int x, int y, string name, float scaleX = 1f, float scaleY = 1f)
        {
            if (!string.IsNullOrEmpty(name))
            {
                AnimatedTileAnimation animation = Bank.AnimationsByName[name];
                List<OverlayTile> list = Sprites[x, y];
                if (list == null)
                {
                    List<OverlayTile> list2 = (Sprites[x, y] = new List<OverlayTile>());
                    list = list2;
                }

                list.Add(new OverlayTile
                {
                    AnimationID = animation.ID,
                    Frame = ((ISourceRandomEnvironment)engine).Random.Next(animation.Frames.Length),
                    Scale = new Vector2(scaleX, scaleY)
                });
            }
        }

        public IntRect GetClippedRenderTiles(int extend)
        {
            Vector2 vector = ((ISourceEntityPosition)Entity).Position + Position;
            int val;
            int val2;
            int val3;
            int val4;
            if (ClipCamera == null)
            {
                val = -extend;
                val2 = -extend;
                val3 = Sprites.Columns + extend;
                val4 = Sprites.Rows + extend;
            }
            else
            {
                CameraState clipCamera = ClipCamera;
                val = (int)Math.Max(0.0, Math.Floor((clipCamera.Left - vector.X) / 8f) - (double)extend);
                val2 = (int)Math.Max(0.0, Math.Floor((clipCamera.Top - vector.Y) / 8f) - (double)extend);
                val3 = (int)Math.Min(Sprites.Columns,
                    Math.Ceiling((clipCamera.Right - vector.X) / 8f) + (double)extend);
                val4 = (int)Math.Min(Sprites.Rows, Math.Ceiling((clipCamera.Bottom - vector.Y) / 8f) + (double)extend);
            }

            val = Math.Max(val, 0);
            val2 = Math.Max(val2, 0);
            val3 = Math.Min(val3, Sprites.Columns);
            val4 = Math.Min(val4, Sprites.Rows);
            return new IntRect(val, val2, val3 - val, val4 - val2);
        }

        public override void Update()
        {
            IntRect clippedRenderTiles = GetClippedRenderTiles(1);
            for (int i = clippedRenderTiles.Left; i < clippedRenderTiles.Right; i++)
            {
                for (int j = clippedRenderTiles.Top; j < clippedRenderTiles.Bottom; j++)
                {
                    List<OverlayTile> list = Sprites[i, j];
                    if (list != null)
                    {
                        for (int k = 0; k < list.Count; k++)
                        {
                            AnimatedTileAnimation animation = Bank.Animations[list[k].AnimationID];
                            list[k].Frame += engine.DeltaTime / animation.Delay;
                        }
                    }
                }
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            RenderAt(((ISourceEntityPosition)Entity).Position + Position, context);
        }

        public void RenderAt(Vector2 position, ISourceRenderContext context)
        {
            IntRect clippedRenderTiles = GetClippedRenderTiles(1);
            PackedColor color = Color * Alpha;
            for (int i = clippedRenderTiles.Left; i < clippedRenderTiles.Right; i++)
            {
                for (int j = clippedRenderTiles.Top; j < clippedRenderTiles.Bottom; j++)
                {
                    List<OverlayTile> list = Sprites[i, j];
                    if (list != null)
                    {
                        for (int k = 0; k < list.Count; k++)
                        {
                            OverlayTile tile = list[k];
                            AnimatedTileAnimation animation = Bank.Animations[tile.AnimationID];
                            var region = animation.Frames[(int)tile.Frame % animation.Frames.Length];
                            var drawPosition = position + animation.Offset +
                                               new Vector2((float)i + 0.5f, (float)j + 0.5f) * 8f;
                            var image = new AtlasTextureDraw(region, drawPosition, animation.Origin, color, tile.Scale);
                            ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in image, Entity);
                        }
                    }
                }
            }
        }
    }
}
