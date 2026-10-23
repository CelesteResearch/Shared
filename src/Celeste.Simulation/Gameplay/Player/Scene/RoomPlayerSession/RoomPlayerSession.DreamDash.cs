using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Platforms.DreamBlock;
using Celeste.Simulation.Gameplay.Player.Dash;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        private SoundSourceComponentState dreamSfxLoop;
        private float dreamDashCanEndTimer;
        private ISourceDreamBlock dreamBlock;

        private void DreamDashBegin()
        {
            if (dreamSfxLoop == null)
                Components.Add(dreamSfxLoop = ((ISourceSoundSourceEnvironment)engineContext).SoundSources.Create());
            Data.Motion.Normal.Speed = Data.Direction * 240f;
            TreatNaive = true;
            Depth = -12000;
            dreamDashCanEndTimer = .1f;
            Data.Stamina = 110f;
            Data.DreamJump = false;
            Play("event:/char/madeline/dreamblock_enter");
            Loop(dreamSfxLoop, "event:/char/madeline/dreamblock_travel");
        }

        private void DreamDashEnd()
        {
            Depth = 0;
            if (!Data.DreamJump)
            {
                Data.Motion.AutoJump = true;
                Data.AutoJumpTimer = 0f;
            }

            if (!Inventory.NoRefills) World.RefillDash();
            RefillStamina();
            TreatNaive = false;
            if (dreamBlock != null)
            {
                if (Data.Direction.X != 0f)
                {
                    Data.Motion.JumpGraceTimer = .1f;
                    Data.DreamJump = true;
                }
                else Data.Motion.JumpGraceTimer = 0f;

                dreamBlock.OnPlayerExit(this);
                dreamBlock = null;
            }

            Stop(dreamSfxLoop);
            Play("event:/char/madeline/dreamblock_exit");
            ((ISourceRumbleEnvironment)engineContext).RumbleSession.Rumble(1, 0);
        }

        private int DreamDashUpdate()
        {
            ((ISourceRumbleEnvironment)engineContext).RumbleSession.Rumble(0, 1);
            Vector2 position = Position;
            NaiveMove(Data.Motion.Normal.Speed * engineContext.DeltaTime);
            if (dreamDashCanEndTimer > 0f) dreamDashCanEndTimer -= engineContext.DeltaTime;
            var block = SourceTrackedEntityCollision.First<ISourceDreamBlock>(
                ((ISourceScene)Scene).SourceScene.Entities, "Celeste.DreamBlock", this);
            if (block == null)
            {
                if (DreamDashedIntoSolid())
                {
                    if (Settings.Invincible)
                    {
                        Position = position;
                        Data.Motion.Normal.Speed *= -1f;
                        Play("event:/game/general/assist_dreamblockbounce");
                    }
                    else Die(Vector2.Zero);
                }
                else if (dreamDashCanEndTimer <= 0f)
                {
                    Freeze(.05f);
                    if (Input.Jump.Pressed && Data.Direction.X != 0f)
                    {
                        Data.DreamJump = true;
                        Jump();
                    }
                    else if (Data.Direction.Y >= 0f || Data.Direction.X != 0f)
                    {
                        if (Data.Direction.X > 0f && DreamSolidAt(Position - Vector2.UnitX * 5f)) MoveHExact(-5);
                        else if (Data.Direction.X < 0f && DreamSolidAt(Position + Vector2.UnitX * 5f)) MoveHExact(5);
                        bool left = World.ClimbCheck(-1);
                        bool right = World.ClimbCheck(1);
                        if (Input.GrabCheck && ((Data.MoveX == 1 && right) || (Data.MoveX == -1 && left)))
                        {
                            Data.Facing = Data.MoveX;
                            if (!Settings.NoGrabbing) return 1;
                            ClimbTrigger(Data.MoveX);
                            Data.Motion.Normal.Speed.X = 0f;
                        }
                    }

                    return 0;
                }
            }
            else
            {
                dreamBlock = block;
                if (((global::Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Clock.OnInterval(.1f,
                        engineContext))
                    CreateTrail();
                if (((global::Celeste.Scene.Tracking.ISourceScene)Level).SourceScene.Clock.OnInterval(.04f,
                        engineContext))
                {
                    var burst = ((ISourcePlayerDreamDashScene)Level).AddDreamDashBurst(Center);
                    burst.WorldClipCollider = dreamBlock.Collider;
                    burst.WorldClipPadding = 2;
                }
            }

            return 9;
        }

        private bool DreamSolidAt(Vector2 at) => SourceTrackedEntityCollision.CheckAt(
            ((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid", this, at);

        private bool DreamDashedIntoSolid()
        {
            if (SourceTrackedEntityCollision.Check(((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid", this))
            {
                for (int x = 1; x <= 5; x++)
                for (int sx = -1; sx <= 1; sx += 2)
                for (int y = 1; y <= 5; y++)
                for (int sy = -1; sy <= 1; sy += 2)
                {
                    Vector2 offset = new(x * sx, y * sy);
                    if (!DreamSolidAt(Position + offset))
                    {
                        Position += offset;
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        internal void PlayClimbGrabSurface()
        {
            var platform =
                GetSourceJumpPlatformByPriority(Position + Vector2.UnitX * (float)Data.Facing, "Celeste.Solid");
            if (platform.HasValue)
            {
                Play("event:/char/madeline/grab", "surface_index", platform.GetWallSoundIndex(this, Data.Facing));
                if (platform.Platform is ISourceDreamBlock dream)
                    dream.FootstepRipple(Position + new Vector2(Data.Facing * 3, -4f));
            }
        }

        public void ClimbTrigger(int direction) => Data.ClimbTriggerDirection = direction;
    }
}
