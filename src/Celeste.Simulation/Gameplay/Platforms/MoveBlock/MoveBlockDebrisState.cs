using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content.Atlas;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation.Gameplay.Platforms.MoveBlock
{
    public sealed class MoveBlockDebrisState(
        AtlasData atlas,
        ISourceEngineContext engine,
        IPlatformTargetMotionPolicy targetMotionPolicy) : MovingBlockDebrisState(atlas, engine, targetMotionPolicy)
    {
        // Original TAS hooks qualify this concrete Init signature and must not target the common helper method.
        public new MoveBlockDebrisState Init(Vector2 position, Vector2 center, Vector2 returnTo)
        {
            base.Init(position, center, returnTo);
            return this;
        }
    }
}
