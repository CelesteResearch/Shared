using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Simulation.Presentation.Backdrops.Planets
{
    public sealed class PlanetsBackdropPresentation : BackdropPresentation
    {
        private struct Planet
        {
            public AtlasEntry Texture;
            public Vector2 Position;
        }

        private readonly Planet[] planets;
        public const int MapWidth = 640, MapHeight = 360;

        public PlanetsBackdropPresentation(ISourceEngineContext engine, int count, string size)
        {
            var frames = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.Frames("bgs/10/" + size);
            planets = new Planet[count];
            for (var i = 0; i < planets.Length; i++)
            {
                planets[i].Texture = ((ISourceRandomEnvironment)engine).Random.Choose(frames);
                planets[i].Position = new()
                {
                    X = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 640f),
                    Y = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 360f),
                };
            }
        }

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            var camera = scene.Camera.Position;
            var color = Color * FadeAlphaMultiplier;
            for (var i = 0; i < planets.Length; i++)
            {
                var position = new Vector2
                {
                    X = -32f + ScalarMath.Mod(planets[i].Position.X - camera.X * Scroll.X, 640f),
                    Y = -32f + ScalarMath.Mod(planets[i].Position.Y - camera.Y * Scroll.Y, 360f),
                };
                var texture = planets[i].Texture;
                var draw = new AtlasTextureDraw(texture, position, texture.Center, color, Vector2.One);
                ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in draw, null);
            }
        }
    }
}
