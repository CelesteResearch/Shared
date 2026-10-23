using System.Numerics;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Gameplay.Platforms.BounceBlock;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : IBounceBlockEffects
    {
        void IBounceBlockEffects.Rumble(bool medium) =>
            ((ISourceRumbleEnvironment)EngineContext).RumbleSession.Rumble(medium ? 1 : 0, 1);

        void IBounceBlockEffects.PlaySound(string path, Vector2 position)
        {
            var process = (IOriginalGameplayProcess)EngineContext;
            process.AudioSession.Play(path, position, process.SaveContext);
        }

        void IBounceBlockEffects.Emit(BounceBlockParticle kind, Vector2 position, float direction)
        {
            var types = ((IOriginalGameplayProcess)EngineContext).ParticleTypes.BounceBlock;
            var type = kind == BounceBlockParticle.Reform ? types.P_Reform :
                kind == BounceBlockParticle.FireBreak ? types.P_FireBreak : types.P_IceBreak;
            Particles.Emit(type, position, direction);
        }
    }
}
