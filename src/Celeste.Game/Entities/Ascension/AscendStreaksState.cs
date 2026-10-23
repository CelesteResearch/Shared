using Celeste.Core.Display;
using System;
using System.Numerics;
using System.Collections.Generic;
using Celeste.Core.Randomness;
using Celeste.Core.Components;
using Celeste.Graphics.Content;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Scene.Entities;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Entities.Ascension
{
    public class AscendStreaksState : SceneEntityState
    {
        private sealed class Particle
        {
            public Vector2 Position;
            public float Speed;
            public int Index;
            public int Color;
        }

        private readonly ISourceEngineContext engine;
        private OriginalAscendManagerState manager;
        private Particle[] particles = new Particle[80];
        private IReadOnlyList<AtlasEntry> textures;
        private PackedColor[] colors;
        private PackedColor[] alphaColors;
        public float Alpha = 1f;

        public AscendStreaksState(ISourceEngineContext engine, OriginalAscendManagerState manager = null)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            this.manager = manager;
            colors = manager == null || !manager.Dark
                ? new[] { PackedColor.White, SourceHexColor.HexToColor("e69ecb") }
                : new[] { SourceHexColor.HexToColor("041b44"), SourceHexColor.HexToColor("011230") };
            Depth = 20;
            textures = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.Frames("scenery/launch/slice");
            alphaColors = new PackedColor[colors.Length];
            for (int i = 0; i < particles.Length; i++)
            {
                float x = 160f + SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 24f, 144f) *
                    ((ISourceRandomEnvironment)engine).Random.Choose(-1, 1);
                float y = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 436f);
                float speed = ScalarMath.ClampedMap(Math.Abs(x - 160f), 0f, 160f, .25f)
                              * SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 600f, 2000f);
                particles[i] = new Particle
                {
                    Position = new Vector2(x, y),
                    Speed = speed,
                    Index = ((ISourceRandomEnvironment)engine).Random.Next(textures.Count),
                    Color = ((ISourceRandomEnvironment)engine).Random.Next(colors.Length)
                };
            }
        }

        public override void Update()
        {
            base.Update();
            for (int i = 0; i < particles.Length; i++)
                particles[i].Position.Y += particles[i].Speed * engine.DeltaTime;
        }

        public override void Render(ISourceRenderContext context)
        {
            float amount = ((ISourceEasingEnvironment)engine).EasingArithmetic.SineInOut(
                (manager != null ? manager.Fade : 1f) * Alpha);
            Vector2 camera = ((OriginalLevelSceneRoot)Scene).Camera.Position;
            for (int i = 0; i < colors.Length; i++)
                alphaColors[i] = colors[i] * amount;
            for (int i = 0; i < particles.Length; i++)
            {
                Vector2 position = particles[i].Position;
                position.X = ScalarMath.Mod(position.X, 320f);
                position.Y = -128f + ScalarMath.Mod(position.Y, 436f);
                position += camera;
                Vector2 scale = new Vector2(
                    ScalarMath.ClampedMap(particles[i].Speed, 600f, 2000f, 1f, .25f),
                    ScalarMath.ClampedMap(particles[i].Speed, 600f, 2000f, 1f, 2f));
                scale *= ScalarMath.ClampedMap(particles[i].Speed, 600f, 2000f, 1f, 4f);
                AtlasEntry texture = textures[particles[i].Index];
                var draw = new AtlasTextureDraw(texture, position,
                    new Vector2(texture.FrameWidth, texture.FrameHeight) * .5f,
                    alphaColors[particles[i].Color], scale);
                ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in draw, this);
            }

            SourcePrimitiveDrawing.Rect(context, this, camera.X - 10f, camera.Y - 10f, 26f, 200f, alphaColors[0]);
            SourcePrimitiveDrawing.Rect(context, this, camera.X + 320f - 16f, camera.Y - 10f, 26f, 200f,
                alphaColors[0]);
        }
    }
}
