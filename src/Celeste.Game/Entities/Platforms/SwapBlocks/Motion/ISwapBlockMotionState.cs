using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;

namespace Celeste.Game.Entities.Platforms.SwapBlocks.Motion
{
    public interface ISwapBlockMotionState : ISwapBlockProgressState
    {
        new ISourceEngineContext Engine { get; }
        SourceSolidEntityState Solid { get; }
        Vector2 Start { get; }
        Vector2 End { get; }
        new float MaxForwardSpeed { get; }
        new float MaxBackwardSpeed { get; }
        Sprite MiddleRed { get; }
        Sprite MiddleGreen { get; }
        ref bool Swapping { get; }
        new ref int Target { get; }
        ref float ReturnTimer { get; }
        new ref float Lerp { get; }
        new ref float Speed { get; }
        ref float RedAlpha { get; }
        ref DisplacementBurst Burst { get; }
        ref ISourceAudioEventReference MoveSound { get; }
        ref ISourceAudioEventReference ReturnSound { get; }
        void EmitMovementParticles(Vector2 normal);
    }
}
