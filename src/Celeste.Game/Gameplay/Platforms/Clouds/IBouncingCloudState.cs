using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Gameplay.Platforms.Clouds
{
    public interface IBouncingCloudState
    {
        ISourceEngineContext Engine { get; }
        SourceJumpThruEntityState Platform { get; }
        Sprite Sprite { get; }
        SoundSourceComponentState Sound { get; }
        ParticleTypePresentation ParticleType { get; }
        bool Fragile { get; }
        bool ShouldFade { get; }
        bool Pink { get; }
        bool SquashWhileRising { get; }
        ref Vector2 Scale { get; }
        ref float Timer { get; }
        ref float RespawnTimer { get; }
        ref float Speed { get; }
        ref float StartY { get; }
        ref bool Waiting { get; }
        ref bool Returning { get; }
        ref bool CanRumble { get; }
        void BeginFade(bool respawn);
    }
}
