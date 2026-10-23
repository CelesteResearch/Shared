using System.Numerics;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Gameplay.Player.Intro;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlayerIntroScene
    {
        float ISourcePlayerIntroScene.CameraX
        {
            get => Camera.X;
            set => Camera.X = value;
        }

        void ISourcePlayerIntroScene.EmitSummitLand(int type, bool background, int count,
            Vector2 position, Vector2 range, float? direction)
        {
            var definitions = ((IOriginalGameplayProcess)EngineContext).ParticleTypes.Player;
            var preset = type == 0 ? definitions.P_SummitLandA :
                type == 1 ? definitions.P_SummitLandB : definitions.P_SummitLandC;
            var system = background ? ParticlesBG : Particles;
            if (direction.HasValue) system.Emit(preset, count, position, range, direction.Value);
            else system.Emit(preset, count, position, range);
        }
    }
}
