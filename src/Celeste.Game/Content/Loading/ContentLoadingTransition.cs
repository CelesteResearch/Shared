using System;
using System.Diagnostics;

namespace Celeste.Game.Content.Loading
{
    internal sealed class ContentLoadingTransition
    {
        private readonly Func<double> readSeconds;
        private double lastSeconds, animationStart, now;
        private float visibility;
        private bool wasWanted;

        public float Opacity => 1 - (1 - visibility) * (1 - visibility) * (1 - visibility);

        public ContentLoadingTransition(Func<double> readSeconds = null)
        {
            this.readSeconds = readSeconds ?? ReadPhysicalSeconds;
        }

        private static double ReadPhysicalSeconds() =>
            (double)Stopwatch.GetTimestamp() / Stopwatch.Frequency;

        public bool Prepare(bool wanted)
        {
            if (!wanted && visibility == 0)
            {
                wasWanted = false;
                return false;
            }

            now = readSeconds();
            if (wanted && !wasWanted && visibility == 0)
            {
                lastSeconds = now;
                animationStart = now;
            }

            double elapsed = Math.Max(0, now - lastSeconds);
            lastSeconds = now;
            wasWanted = wanted;
            visibility = Math.Clamp(visibility + (float)(wanted ? elapsed / .25 : -elapsed / .3), 0, 1);
            return visibility > 0;
        }

        public int FrameIndex(int count) => count <= 0 ? 0 : (int)(Math.Max(0, now - animationStart) * 10 % count);
    }
}
