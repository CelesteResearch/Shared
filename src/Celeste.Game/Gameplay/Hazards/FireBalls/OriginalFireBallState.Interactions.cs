using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Environment.Core;

namespace Celeste.Game.Gameplay.Hazards.FireBalls
{
    public partial class OriginalFireBallState
    {
        public override void Render(ISourceRenderContext context)
        {
            sprite.Position = hitDir * hitWiggler.Value * 8f;
            if (!broken) sprite.DrawOutline(context, PackedColor.Black);

            base.Render(context);
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (!iceMode && !broken)
                KillPlayer(player);
            else if (iceMode && !broken && player.Bottom > Y + 4f) KillPlayer(player);
        }

        private void KillPlayer(RoomPlayerSession player)
        {
            var direction = engine.VectorArithmetic.SafeNormalize(player.Center - Center);
            if (player.Die(direction) != null)
            {
                hitDir = direction;
                hitWiggler.Start();
            }
        }

        private void OnBounce(RoomPlayerSession player)
        {
            if (iceMode && !broken && player.Bottom <= Y + 4f && player.Data.Motion.Normal.Speed.Y >= 0f)
            {
                engine.SpatialAudio.Play("event:/game/09_core/iceball_break", Position);
                sprite.Play("shatter");
                broken = true;
                Collidable = false;
                player.Bounce((int)(Y - 2f));
                ((OriginalLevelSceneRoot)Scene).Particles.Emit(engine.ParticleTypes.FireBall.P_IceBreak, 18,
                    Center,
                    Vector2.One * 6f);
            }
        }

        private void OnChangeMode(RoomCoreMode mode)
        {
            iceMode = mode == RoomCoreMode.Cold;
            if (!broken) sprite.Play(iceMode ? "ice" : "hot", false, true);

            if (index == 0 && trackSfx != null)
            {
                if (iceMode)
                {
                    trackSfx.Stop();
                    return;
                }

                PositionTrackSfx();
                trackSfx.Play("event:/env/local/09_core/fireballs_idle");
            }
        }
    }
}
