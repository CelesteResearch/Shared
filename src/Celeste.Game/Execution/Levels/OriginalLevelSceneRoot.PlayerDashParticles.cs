using System.Numerics;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Scene.Particles;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Execution.Levels
{
    public partial class OriginalLevelSceneRoot : ISourcePlayerDashParticleScene
    {
        void ISourcePlayerDashParticleScene.EmitPlayerDashParticle(ParticleTypePresentation type,
            RoomPlayerSession actualPlayer)
            => ParticlesFG.Emit(type, actualPlayer.Center + SourceRandomMath.Range(
                    ((ISourceRandomEnvironment)EngineContext).Random, Vector2.One * -2f, Vector2.One * 2f),
                Vector2Geometry.Angle(actualPlayer.Data.Direction));
    }
}
