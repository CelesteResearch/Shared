using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Game.Presentation.Effects.Blur
{
    public static class GaussianBlurPresentation
    {
        private static readonly string[] Techniques = { "GaussianBlur3", "GaussianBlur5", "GaussianBlur9" };

        public static object Blur(global::Celeste.Game.Presentation.Effects.Blur.IGaussianBlurOutput output,
            object texture, global::Celeste.Graphics.Effects.Sampling.RenderTargetReference temp,
            global::Celeste.Graphics.Effects.Sampling.RenderTargetReference destination,
            float fade = 0, bool clear = true,
            global::Celeste.Graphics.Effects.Blur.GaussianBlurSamples samples =
                global::Celeste.Graphics.Effects.Blur.GaussianBlurSamples.Nine,
            float sampleScale = 1,
            global::Celeste.Graphics.Effects.Blur.GaussianBlurDirection direction =
                global::Celeste.Graphics.Effects.Blur.GaussianBlurDirection.Both, float alpha = 1)
        {
            // The original evaluates the technique array before the null-effect
            // check; its alpha argument is never read by either drawing pass.
            string technique = Techniques[(int)samples];
            if (!output.EffectAvailable) return texture;
            output.SetTechnique(technique);
            output.SetFade(fade);
            output.SetPixel(new Vector2(1f / temp.Width, 0) * sampleScale);
            output.SetTarget(temp.Handle);
            if (clear) output.ClearTransparent();
            output.DrawBlurPass(texture, new global::Celeste.Core.Geometry.IntRect(0, 0, temp.Width, temp.Height),
                direction != global::Celeste.Graphics.Effects.Blur.GaussianBlurDirection.Vertical);
            output.SetPixel(new Vector2(0, 1f / destination.Height) * sampleScale);
            output.SetTarget(destination.Handle);
            if (clear) output.ClearTransparent();
            output.DrawBlurPass(temp.Handle,
                new global::Celeste.Core.Geometry.IntRect(0, 0, destination.Width, destination.Height),
                direction != global::Celeste.Graphics.Effects.Blur.GaussianBlurDirection.Horizontal);
            return destination.Handle;
        }

        // These are the installed XNB's actual accumulation order and tap offsets,
        // FX preshader inputs and outputs have separate register files.
        public static IReadOnlyList<global::Celeste.Graphics.Effects.Sampling.TextureKernelTap> Taps(
            global::Celeste.Graphics.Effects.Blur.GaussianBlurSamples samples, Vector2 pixel)
        {
            switch (samples)
            {
                case global::Celeste.Graphics.Effects.Blur.GaussianBlurSamples.Three:
                    Vector2 three = pixel * 3;
                    return new[]
                    {
                        new global::Celeste.Graphics.Effects.Sampling.TextureKernelTap(Vector2.Zero, .5f),
                        new global::Celeste.Graphics.Effects.Sampling.TextureKernelTap(-three, .25f),
                        new global::Celeste.Graphics.Effects.Sampling.TextureKernelTap(three, .25f)
                    };
                case global::Celeste.Graphics.Effects.Blur.GaussianBlurSamples.Five:
                    Vector2 four = pixel * 4, two = pixel + pixel;
                    return new[]
                    {
                        new global::Celeste.Graphics.Effects.Sampling.TextureKernelTap(-two, .2f),
                        new global::Celeste.Graphics.Effects.Sampling.TextureKernelTap(-four, .15f),
                        new global::Celeste.Graphics.Effects.Sampling.TextureKernelTap(Vector2.Zero, .3f),
                        new global::Celeste.Graphics.Effects.Sampling.TextureKernelTap(two, .2f),
                        new global::Celeste.Graphics.Effects.Sampling.TextureKernelTap(four, .15f)
                    };
                case global::Celeste.Graphics.Effects.Blur.GaussianBlurSamples.Nine:
                    Vector2 four9 = pixel * 4, three9 = pixel * 3, two9 = pixel + pixel;
                    return new[]
                    {
                        new global::Celeste.Graphics.Effects.Sampling.TextureKernelTap(-three9, .09f),
                        new global::Celeste.Graphics.Effects.Sampling.TextureKernelTap(-four9, .05f),
                        new global::Celeste.Graphics.Effects.Sampling.TextureKernelTap(-two9, .12f),
                        new global::Celeste.Graphics.Effects.Sampling.TextureKernelTap(-pixel, .15f),
                        new global::Celeste.Graphics.Effects.Sampling.TextureKernelTap(Vector2.Zero, .18f),
                        new global::Celeste.Graphics.Effects.Sampling.TextureKernelTap(pixel, .15f),
                        new global::Celeste.Graphics.Effects.Sampling.TextureKernelTap(two9, .12f),
                        new global::Celeste.Graphics.Effects.Sampling.TextureKernelTap(three9, .09f),
                        new global::Celeste.Graphics.Effects.Sampling.TextureKernelTap(four9, .05f)
                    };
                default: throw new IndexOutOfRangeException();
            }
        }

        public static Vector4 Evaluate(Vector2 uv, Vector2 pixel,
            global::Celeste.Graphics.Effects.Blur.GaussianBlurSamples samples, float fade,
            Func<Vector2, Vector4> sample)
        {
            var taps = Taps(samples, pixel);
            Vector4 color = sample(uv + taps[0].Offset) * taps[0].Weight;
            for (int i = 1; i < taps.Count; i++) color = sample(uv + taps[i].Offset) * taps[i].Weight + color;
            Vector2 center = uv - new Vector2(.5f);
            float distance = (float)Math.Sqrt(center.X * center.X + center.Y * center.Y);
            float amount = (1 - distance) * fade;
            return amount * -color + color;
        }
    }
}
