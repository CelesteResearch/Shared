using Celeste.Core.Display;
using Celeste.Core.Randomness;
using Celeste.Graphics.Display;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Entities.Platforms.Dream
{
    public sealed class OriginalDreamBlockRuntimePolicy : IOriginalDreamBlockRuntimePolicy
    {
        private readonly ISourceEngineContext engine;

        public OriginalDreamBlockRuntimePolicy(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public int ChooseLayer(ISourceRandom random) => random.Choose(new[] { 0, 1, 1, 2, 2, 2 });

        public PackedColor ChooseColor(ISourceRandom random, PackedColor first, PackedColor second, PackedColor third)
            => random.Choose(new[] { first, second, third });

        public int GetParticleCount(OriginalDreamBlockState actual)
            => unchecked((int)(actual.Width / 8f * (actual.Height / 8f) * .7f));

        public Vector2 PutInside(OriginalDreamBlockState actual, Vector2 position)
        {
            while (position.X < actual.X) position.X += actual.Width;
            while (position.X > actual.X + actual.Width) position.X -= actual.Width;
            while (position.Y < actual.Y) position.Y += actual.Height;
            while (position.Y > actual.Y + actual.Height) position.Y -= actual.Height;
            return position;
        }

        public void MoveNode(OriginalDreamBlockState actual, Vector2 start, Vector2 end, SourceTweenState tween)
        {
            if (actual.Collidable)
                actual.MoveTo(Vector2Math.Lerp(start, end, tween.Eased,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic));
            else
                actual.MoveToNaive(Vector2Math.Lerp(start, end, tween.Eased,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic));
        }
    }
}
