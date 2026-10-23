using Celeste.Core.Display;
using Celeste.Core.Randomness;
using Celeste.Graphics.Display;
using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Components.Animation;

namespace Celeste.Game.Entities.Platforms.Dream
{
    public sealed class InstalledDreamBlockRuntimePolicy : IOriginalDreamBlockRuntimePolicy
    {
        public int ChooseLayer(ISourceRandom random) => random.Choose(0, 1, 1, 2, 2, 2);

        public PackedColor ChooseColor(ISourceRandom random, PackedColor first, PackedColor second, PackedColor third)
            => random.Choose(first, second, third);

        public int GetParticleCount(OriginalDreamBlockState actual)
            => unchecked((int)((double)actual.Width / 8.0 * ((double)actual.Height / 8.0) * (double).7f));

        public Vector2 PutInside(OriginalDreamBlockState actual, Vector2 position)
        {
            if (position.X > actual.Right)
                position.X -= (float)Math.Ceiling((position.X - actual.Right) / actual.Width) * actual.Width;
            else if (position.X < actual.Left)
                position.X += (float)Math.Ceiling((actual.Left - position.X) / actual.Width) * actual.Width;
            if (position.Y > actual.Bottom)
                position.Y -= (float)Math.Ceiling((position.Y - actual.Bottom) / actual.Height) * actual.Height;
            else if (position.Y < actual.Top)
                position.Y += (float)Math.Ceiling((actual.Top - position.Y) / actual.Height) * actual.Height;
            return position;
        }

        public void MoveNode(OriginalDreamBlockState actual, Vector2 start, Vector2 end, SourceTweenState tween)
        {
            double targetX = (double)start.X + ((double)end.X - start.X) * tween.Eased;
            double targetY = (double)start.Y + ((double)end.Y - start.Y) * tween.Eased;
            float moveX = (float)(targetX - actual.Position.X - actual.MovementCounter.X);
            float moveY = (float)((double)JITBarrier((float)targetY) - actual.Position.Y - actual.MovementCounter.Y);
            if (actual.Collidable)
            {
                actual.MoveH(moveX);
                actual.MoveV(moveY);
            }
            else
            {
                actual.MoveHNaive(moveX);
                actual.MoveVNaive(moveY);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static float JITBarrier(float value) => value;
    }
}
