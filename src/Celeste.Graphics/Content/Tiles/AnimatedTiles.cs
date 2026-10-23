using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Collections;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Display;
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

        // ReSharper disable once ConvertToPrimaryConstructor
        public AnimatedTiles(int columns, int rows, AnimatedTileBank bank, ISourceEngineContext engine) : base(true,
            true)
        {
            Sprites = new(columns, rows);
            Bank = bank;
            this.engine = engine;
        }

        public void Set(int x, int y, string name, float scaleX = 1f, float scaleY = 1f)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var animation = Bank.AnimationsByName[name];
                var list = Sprites[x, y];
                if (list == null)
                {
                    var list2 = Sprites[x, y] = [];
                    list = list2;
                }

                list.Add(new()
                {
                    AnimationID = animation.ID,
                    Frame = ((ISourceRandomEnvironment)engine).Random.Next(animation.Frames.Length),
                    Scale = new(scaleX, scaleY),
                });
            }
        }

        public IntRect GetClippedRenderTiles(int extend)
        {
            var vector = ((ISourceEntityPosition)Entity).Position + Position;
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
                var clipCamera = ClipCamera;
                val = (int)Math.Max(0.0, Math.Floor((clipCamera.Left - vector.X) / 8f) - extend);
                val2 = (int)Math.Max(0.0, Math.Floor((clipCamera.Top - vector.Y) / 8f) - extend);
                val3 = (int)Math.Min(Sprites.Columns, Math.Ceiling((clipCamera.Right - vector.X) / 8f) + extend);
                val4 = (int)Math.Min(Sprites.Rows, Math.Ceiling((clipCamera.Bottom - vector.Y) / 8f) + extend);
            }

            val = Math.Max(val, 0);
            val2 = Math.Max(val2, 0);
            val3 = Math.Min(val3, Sprites.Columns);
            val4 = Math.Min(val4, Sprites.Rows);
            return new(val, val2, val3 - val, val4 - val2);
        }

        public override void Update()
        {
            var clippedRenderTiles = GetClippedRenderTiles(1);
            for (var i = clippedRenderTiles.Left; i < clippedRenderTiles.Right; i++)
            for (var j = clippedRenderTiles.Top; j < clippedRenderTiles.Bottom; j++)
            {
                var list = Sprites[i, j];
                if (list != null)
                    for (var k = 0; k < list.Count; k++)
                    {
                        var animation = Bank.Animations[list[k].AnimationID];
                        list[k].Frame += engine.DeltaTime / animation.Delay;
                    }
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            RenderAt(((ISourceEntityPosition)Entity).Position + Position, context);
        }

        public void RenderAt(Vector2 position, ISourceRenderContext context)
        {
            var clippedRenderTiles = GetClippedRenderTiles(1);
            var color = Color * Alpha;
            for (var i = clippedRenderTiles.Left; i < clippedRenderTiles.Right; i++)
            for (var j = clippedRenderTiles.Top; j < clippedRenderTiles.Bottom; j++)
            {
                var list = Sprites[i, j];
                if (list != null)
                    for (var k = 0; k < list.Count; k++)
                    {
                        var tile = list[k];
                        var animation = Bank.Animations[tile.AnimationID];
                        var region = animation.Frames[(int)tile.Frame % animation.Frames.Length];
                        var drawPosition = position + animation.Offset + new Vector2(i + 0.5f, j + 0.5f) * 8f;
                        var image = new AtlasTextureDraw(region, drawPosition, animation.Origin, color, tile.Scale);
                        ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in image, Entity);
                    }
            }
        }
    }
}
