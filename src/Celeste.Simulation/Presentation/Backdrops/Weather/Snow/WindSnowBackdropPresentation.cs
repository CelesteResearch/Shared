using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Simulation.Presentation.Backdrops.Weather.Snow
{
    public sealed class WindSnowBackdropPresentation : BackdropPresentation
    {
        public Vector2 CameraOffset;
        public float Alpha = 1f;
        private readonly ISourceEngineContext engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private readonly Vector2[] positions;
        private readonly SineWaveState[] sines;
        private Vector2 scale = Vector2.One;
        private float rotation;
        private readonly float loopWidth = 640f;
        private readonly float loopHeight = 360f;
        private float visibleFade = 1f;

        public WindSnowBackdropPresentation(ISourceEngineContext engine)
        {
            this.engine = engine;
            Color = PackedColor.White;
            positions = new Vector2[240];
            for (var i = 0; i < positions.Length; i++)
                positions[i] = SourceRandomMath.Range(Random, Vector2.Zero, new(loopWidth, loopHeight));
            sines = new SineWaveState[16];
            for (var i = 0; i < sines.Length; i++)
            {
                sines[i] = new(engine,
                    SourceRandomMath.Range(Random, .8f, 1.2f));
                sines[i].Randomize();
            }
        }

        public override void Update(ISourceBackdropScene scene)
        {
            base.Update(scene);
            visibleFade = ScalarMath.Approach(visibleFade, IsVisible(scene) ? 1 : 0,
                engine.Frame.DeltaTime * 2f, Extrema);
            var array = sines;
            for (var i = 0; i < array.Length; i++) array[i].Update();
            var horizontal = scene.Wind.Y == 0f;
            if (horizontal)
            {
                scale.X = Extrema.Max(1f, Math.Abs(scene.Wind.X) / 100f);
                rotation = ScalarMath.Approach(rotation, 0f, engine.Frame.DeltaTime * 8f, Extrema);
            }
            else
            {
                scale.X = Extrema.Max(1f, Math.Abs(scene.Wind.Y) / 40f);
                rotation = ScalarMath.Approach(rotation, -(float)Math.PI / 2f, engine.Frame.DeltaTime * 8f, Extrema);
            }

            scale.Y = 1f / Extrema.Max(1f, scale.X * .25f);
            for (var i = 0; i < positions.Length; i++)
            {
                var value = sines[i % sines.Length].Value;
                var velocity = Vector2.Zero;
                velocity = !horizontal
                    ? new(0f, scene.Wind.Y * 3f + value * 10f)
                    : new Vector2(scene.Wind.X + value * 10f, 20f);
                positions[i] += velocity * engine.Frame.DeltaTime;
            }
        }

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            if (Alpha <= 0f) return;
            var color = Color * visibleFade * Alpha;
            var count = (int)(scene.Wind.Y == 0f ? (float)positions.Length : positions.Length * .6f);
            var drawn = 0;
            var array = positions;
            for (var i = 0; i < array.Length; i++)
            {
                var position = array[i];
                position.Y -= scene.Camera.Y + CameraOffset.Y;
                position.Y %= loopHeight;
                if (position.Y < 0f) position.Y += loopHeight;
                position.X -= scene.Camera.X + CameraOffset.X;
                position.X %= loopWidth;
                if (position.X < 0f) position.X += loopWidth;
                if (drawn < count)
                {
                    var texture = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["particles/snow"];
                    var draw = new AtlasTextureDraw(texture, position, texture.Center, color, scale, rotation);
                    ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in draw, null);
                }

                drawn++;
            }
        }
    }
}
