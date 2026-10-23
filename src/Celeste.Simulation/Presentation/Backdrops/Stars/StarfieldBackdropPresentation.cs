using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Simulation.Presentation.Backdrops.Stars
{
    public class StarfieldBackdropPresentation : BackdropPresentation
    {
        public struct Star
        {
            public AtlasEntry Texture;
            public Vector2 Position;
            public PackedColor Color;
            public int NodeIndex;
            public float NodePercent, Distance, Sine;
        }

        private readonly ISourceEngineContext engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;
        public float FlowSpeed;
        public List<float> YNodes = [];
        public Star[] Stars = new Star[128];

        public StarfieldBackdropPresentation(ISourceEngineContext engine, PackedColor color, float speed = 1f)
        {
            this.engine = engine;
            Color = color;
            FlowSpeed = speed;
            var node = SourceRandomMath.NextFloat(Random, 180f);
            var n = 0;
            while (n < 15)
            {
                YNodes.Add(node);
                n++;
                node += Random.Choose(-1, 1) * (16f + SourceRandomMath.NextFloat(Random, 24f));
            }

            for (var i = 0; i < 4; i++)
                YNodes[YNodes.Count - 1 - i] = ((ISourceScalarEnvironment)engine).ScalarArithmetic.Lerp(
                    YNodes[YNodes.Count - 1 - i], YNodes[0], ScalarMath.Clamp(1f - i / 4f, 0f, 1f));
            var textures =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.Frames("particles/starfield/");
            for (var i = 0; i < Stars.Length; i++)
            {
                var distance = SourceRandomMath.NextFloat(Random, 1f);
                Stars[i].NodeIndex = Random.Next(YNodes.Count - 1);
                Stars[i].NodePercent = SourceRandomMath.NextFloat(Random, 1f);
                Stars[i].Distance = 4f + distance * 20f;
                Stars[i].Sine = SourceRandomMath.NextFloat(Random, (float)Math.PI * 2f);
                Stars[i].Position = GetTargetOfStar(ref Stars[i]);
                Stars[i].Color = SourceColorInterpolation.Lerp(Color, PackedColor.Transparent, distance * .5f,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                var index = (int)ScalarMath.Clamp(
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(1f - distance)
                    * textures.Count, 0f, textures.Count - 1);
                Stars[i].Texture = textures[index];
            }
        }

        public override void Update(ISourceBackdropScene scene)
        {
            base.Update(scene);
            for (var i = 0; i < Stars.Length; i++) UpdateStar(ref Stars[i]);
        }

        protected void UpdateStar(ref Star star)
        {
            star.Sine += engine.Frame.DeltaTime * FlowSpeed;
            star.NodePercent += engine.Frame.DeltaTime * .25f * FlowSpeed;
            if (star.NodePercent >= 1f)
            {
                star.NodePercent -= 1f;
                star.NodeIndex++;
                if (star.NodeIndex >= YNodes.Count - 1)
                {
                    star.NodeIndex = 0;
                    star.Position.X -= 448f;
                }
            }

            star.Position += ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(
                GetTargetOfStar(ref star) - star.Position, 50f);
        }

        protected Vector2 GetTargetOfStar(ref Star star)
        {
            var first = new Vector2(star.NodeIndex * 32, YNodes[star.NodeIndex]);
            var second = new Vector2((star.NodeIndex + 1) * 32, YNodes[star.NodeIndex + 1]);
            var center = first + (second - first) * star.NodePercent;
            var direction = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(second - first);
            var perpendicular = new Vector2(-direction.Y, direction.X);
            return center + perpendicular * star.Distance * (float)Math.Sin(star.Sine);
        }

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            RenderStars(context, scene, ref Stars);
        }

        protected void RenderStars(ISourceRenderContext context, ISourceBackdropScene scene, ref Star[] stars)
        {
            var camera = scene.Camera.Position;
            for (var i = 0; i < stars.Length; i++)
            {
                var position = new Vector2(-64f + ScalarMath.Mod(stars[i].Position.X - camera.X * Scroll.X, 448f),
                    -16f + ScalarMath.Mod(stars[i].Position.Y - camera.Y * Scroll.Y, 212f));
                var texture = stars[i].Texture;
                var draw = new AtlasTextureDraw(texture, position, texture.Center,
                    stars[i].Color * FadeAlphaMultiplier, Vector2.One);
                ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in draw, null);
            }
        }
    }
}
