using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Simulation.Presentation.Backdrops.Stars
{
    public sealed class StarsBackdropPresentation : BackdropPresentation
    {
        private struct Star
        {
            public Vector2 Position;
            public int TextureSet;
            public float Timer, Rate;
        }

        private readonly ISourceEngineContext engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;
        private Star[] stars;
        private PackedColor[] colors;
        private List<List<AtlasEntry>> textures;
        private float falling;
        private Vector2 center;

        public StarsBackdropPresentation(ISourceEngineContext engine)
        {
            this.engine = engine;
            textures = new List<List<AtlasEntry>>();
            textures.Add(((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.Frames("bgs/02/stars/a"));
            textures.Add(((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.Frames("bgs/02/stars/b"));
            textures.Add(((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.Frames("bgs/02/stars/c"));
            center = new Vector2(textures[0][0].FrameWidth, textures[0][0].FrameHeight) / 2f;
            stars = new Star[100];
            for (int i = 0; i < stars.Length; i++)
                stars[i] = new Star
                {
                    Position = new Vector2(SourceRandomMath.NextFloat(Random, 320f),
                        SourceRandomMath.NextFloat(Random, 180f)),
                    Timer = SourceRandomMath.NextFloat(Random, (float)Math.PI * 2f),
                    Rate = 2f + SourceRandomMath.NextFloat(Random, 2f),
                    TextureSet = Random.Next(textures.Count)
                };
            colors = new PackedColor[8];
            for (int i = 0; i < colors.Length; i++)
                colors[i] = PackedColor.Teal * .7f * (1f - (float)i / colors.Length);
        }

        public override void Update(ISourceBackdropScene scene)
        {
            base.Update(scene);
            if (Visible)
            {
                for (int i = 0; i < stars.Length; i++) stars[i].Timer += engine.Frame.DeltaTime * stars[i].Rate;
                if (scene.Dreaming) falling += engine.Frame.DeltaTime * 12f;
            }
        }

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            SourcePrimitiveDrawing.Rect(context, null, 0, 0, 320, 180, PackedColor.Black);
            PackedColor color = PackedColor.White;
            int count = 100;
            if (scene.Dreaming) color = PackedColor.Teal * .7f;
            else count /= 2;
            for (int i = 0; i < count; i++)
            {
                var frames = textures[stars[i].TextureSet];
                int frame = (int)((Math.Sin(stars[i].Timer) + 1.0) / 2.0 * (double)frames.Count);
                frame %= frames.Count;
                Vector2 position = stars[i].Position;
                var texture = frames[frame];
                if (scene.Dreaming)
                {
                    position.Y -= scene.Camera.Y;
                    position.Y += falling * stars[i].Rate;
                    position.Y %= 180f;
                    if (position.Y < 0f) position.Y += 180f;
                    for (int j = 0; j < colors.Length; j++)
                    {
                        var trail = new AtlasTextureDraw(texture, position - Vector2.UnitY * j, center,
                            colors[j], Vector2.One);
                        ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in trail, null);
                    }
                }

                var draw = new AtlasTextureDraw(texture, position, center, color, Vector2.One);
                ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in draw, null);
            }
        }
    }
}
