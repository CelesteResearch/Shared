using Celeste.Core.Randomness;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Game.Entities.StarJump
{
    public sealed class StarClimbGraphicsProcessState
    {
        public struct Ray
        {
            public float X;

            public float Y;

            public float Percent;

            public float Duration;

            public float Width;

            public float Length;

            public void Reset(ISourceRandom random)
            {
                Percent = 0f;
                X = SourceRandomMath.NextFloat(random, 480f);
                Y = SourceRandomMath.NextFloat(random, 580f);
                Duration = 4f + SourceRandomMath.NextFloat(random) * 8f;
                Width = random.Next(8, 80);
                Length = random.Next(20, 200);
            }
        }

        public VirtualRenderTarget BlockFill;
        public Ray[] rays = new Ray[100];
    }
}
