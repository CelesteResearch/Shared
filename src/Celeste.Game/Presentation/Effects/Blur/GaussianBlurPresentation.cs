using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Graphics.Effects.Blur;
using Celeste.Graphics.Effects.Sampling;

namespace Celeste.Game.Presentation.Effects.Blur
{
    public static class GaussianBlurPresentation
    {
        private static readonly string[] Techniques = ["GaussianBlur3", "GaussianBlur5", "GaussianBlur9"];

        public static object Blur(IGaussianBlurOutput output,
            object texture, RenderTargetReference temp,
            RenderTargetReference destination,
            float fade = 0, bool clear = true,
            GaussianBlurSamples samples =
                GaussianBlurSamples.Nine,
            float sampleScale = 1,
            GaussianBlurDirection direction =
                GaussianBlurDirection.Both, float alpha = 1)
        {
            // The original evaluates the technique array before the null-effect
            // check; its alpha argument is never read by either drawing pass.
            var technique = Techniques[(int)samples];
            if (!output.EffectAvailable) return texture;
            output.SetTechnique(technique);
            output.SetFade(fade);
            output.SetPixel(new Vector2(1f / temp.Width, 0) * sampleScale);
            output.SetTarget(temp.Handle);
            if (clear) output.ClearTransparent();
            output.DrawBlurPass(texture, new(0, 0, temp.Width, temp.Height),
                direction != GaussianBlurDirection.Vertical);
            output.SetPixel(new Vector2(0, 1f / destination.Height) * sampleScale);
            output.SetTarget(destination.Handle);
            if (clear) output.ClearTransparent();
            output.DrawBlurPass(temp.Handle,
                new(0, 0, destination.Width, destination.Height),
                direction != GaussianBlurDirection.Horizontal);
            return destination.Handle;
        }

        // These are the installed XNB's actual accumulation order and tap offsets,
        // FX preshader inputs and outputs have separate register files.
        public static IReadOnlyList<TextureKernelTap> Taps(
            GaussianBlurSamples samples, Vector2 pixel)
        {
            switch (samples)
            {
                case GaussianBlurSamples.Three:
                    var three = pixel * 3;
                    return (TextureKernelTap[])
                    [
                        new(Vector2.Zero, .5f),
                        new(-three, .25f),
                        new(three, .25f),
                    ];
                case GaussianBlurSamples.Five:
                    Vector2 four = pixel * 4, two = pixel + pixel;
                    return (TextureKernelTap[])
                    [
                        new(-two, .2f),
                        new(-four, .15f),
                        new(Vector2.Zero, .3f),
                        new(two, .2f),
                        new(four, .15f),
                    ];
                case GaussianBlurSamples.Nine:
                    Vector2 four9 = pixel * 4, three9 = pixel * 3, two9 = pixel + pixel;
                    return (TextureKernelTap[])
                    [
                        new(-three9, .09f),
                        new(-four9, .05f),
                        new(-two9, .12f),
                        new(-pixel, .15f),
                        new(Vector2.Zero, .18f),
                        new(pixel, .15f),
                        new(two9, .12f),
                        new(three9, .09f),
                        new(four9, .05f),
                    ];
                default: throw new IndexOutOfRangeException();
            }
        }

        public static Vector4 Evaluate(Vector2 uv, Vector2 pixel,
            GaussianBlurSamples samples, float fade,
            Func<Vector2, Vector4> sample)
        {
            var taps = Taps(samples, pixel);
            var color = sample(uv + taps[0].Offset) * taps[0].Weight;
            for (var i = 1; i < taps.Count; i++) color = sample(uv + taps[i].Offset) * taps[i].Weight + color;
            var center = uv - new Vector2(.5f);
            var distance = (float)Math.Sqrt(center.X * center.X + center.Y * center.Y);
            var amount = (1 - distance) * fade;
            return amount * -color + color;
        }
    }
}
