using System.Numerics;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Player.Scene.Particles;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public int StartDash()
        {
            return Motor.Dash.Start();
        }

        public void CreateWallSlideParticles(int direction)
        {
            if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(.01f, EngineContext))
            {
                var index = -1;
                var platform = GetSourceJumpPlatformByPriority(Position + Vector2.UnitX * direction * 4f);
                if (platform.HasValue) index = platform.GetWallSoundIndex(this, direction);
                ((ISourcePlayerJumpScene)Level).BurstPlayerWallSlideDust(this, direction, index);
            }
        }
    }
}
