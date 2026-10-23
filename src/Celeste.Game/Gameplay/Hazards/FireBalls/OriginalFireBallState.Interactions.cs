using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Scene.Components.Oscillation;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Audio.Sources;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Display;

namespace Celeste.Game.Gameplay.Hazards.FireBalls
{
    public partial class OriginalFireBallState
    {
        public override void Render(ISourceRenderContext context)
        {
            sprite.Position = hitDir * hitWiggler.Value * 8f;
            if (!broken)
            {
                sprite.DrawOutline(context, PackedColor.Black);
            }

            base.Render(context);
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (!iceMode && !broken)
            {
                KillPlayer(player);
            }
            else if (iceMode && !broken && player.Bottom > base.Y + 4f)
            {
                KillPlayer(player);
            }
        }

        private void KillPlayer(RoomPlayerSession player)
        {
            Vector2 direction = engine.VectorArithmetic.SafeNormalize(player.Center - base.Center);
            if (player.Die(direction) != null)
            {
                hitDir = direction;
                hitWiggler.Start();
            }
        }

        private void OnBounce(RoomPlayerSession player)
        {
            if (iceMode && !broken && player.Bottom <= base.Y + 4f && player.Data.Motion.Normal.Speed.Y >= 0f)
            {
                engine.SpatialAudio.Play("event:/game/09_core/iceball_break", Position);
                sprite.Play("shatter");
                broken = true;
                Collidable = false;
                player.Bounce((int)(base.Y - 2f));
                ((OriginalLevelSceneRoot)Scene).Particles.Emit(engine.ParticleTypes.FireBall.P_IceBreak, 18,
                    base.Center,
                    Vector2.One * 6f);
            }
        }

        private void OnChangeMode(RoomCoreMode mode)
        {
            iceMode = mode == RoomCoreMode.Cold;
            if (!broken)
            {
                sprite.Play(iceMode ? "ice" : "hot", restart: false, randomizeFrame: true);
            }

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
