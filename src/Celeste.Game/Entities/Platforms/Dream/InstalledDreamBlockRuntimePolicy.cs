using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Components.Animation;
using Celeste.Core.Display;
using Celeste.Core.Randomness;

namespace Celeste.Game.Entities.Platforms.Dream
{
    public sealed class InstalledDreamBlockRuntimePolicy : IOriginalDreamBlockRuntimePolicy
    {
        public int ChooseLayer(ISourceRandom random)
        {
            return random.Choose(0, 1, 1, 2, 2, 2);
        }

        public PackedColor ChooseColor(ISourceRandom random, PackedColor first, PackedColor second, PackedColor third)
        {
            return random.Choose(first, second, third);
        }

        public int GetParticleCount(OriginalDreamBlockState actual)
        {
            return unchecked((int)(actual.Width / 8.0 * (actual.Height / 8.0) * .7f));
        }

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
            var targetX = start.X + ((double)end.X - start.X) * tween.Eased;
            var targetY = start.Y + ((double)end.Y - start.Y) * tween.Eased;
            var moveX = (float)(targetX - actual.Position.X - actual.MovementCounter.X);
            var moveY = (float)((double)JITBarrier((float)targetY) - actual.Position.Y - actual.MovementCounter.Y);
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
        private static float JITBarrier(float value)
        {
            return value;
        }
    }
}
