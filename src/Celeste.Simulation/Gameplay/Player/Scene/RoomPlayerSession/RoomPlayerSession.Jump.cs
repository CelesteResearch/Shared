using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Scene.Tracking;
using Celeste.Scene.Entities;
using Celeste.Simulation.Gameplay.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Movement;
using Celeste.Simulation.Gameplay.Player.Scene.Particles;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        private readonly List<object> sourceCollisionTemp = new();

        public void Jump(bool particles = true, bool playSfx = true)
        {
            Input.Jump.ConsumeBuffer();
            Data.Motion.JumpGraceTimer = 0f;
            Data.Motion.Normal.VariableJumpTimer = .2f;
            Data.Motion.AutoJump = false;
            Data.Motion.DashAttackTimer = 0f;
            Data.Motion.GliderBoostTimer = 0f;
            Data.Motion.WallSlideTimer = 1.2f;
            Data.Motion.WallBoostTimer = 0f;
            Data.Motion.Normal.Speed.X += 40f * (float)Data.MoveX;
            Data.Motion.Normal.Speed.Y = -105f;
            Data.Motion.Normal.Speed += JumpMotion.LiftBoost(LiftSpeed);
            Data.Motion.Normal.VariableJumpSpeed = Data.Motion.Normal.Speed.Y;
            LaunchedBoostCheck();
            if (playSfx)
            {
                if (Data.Motion.Launched) Play("event:/char/madeline/jump_assisted");
                if (Data.DreamJump) Play("event:/char/madeline/jump_dreamblock");
                else Play("event:/char/madeline/jump");
            }

            Sprite.Scale = new Vector2(.6f, 1.4f);
            if (particles)
            {
                int surfaceIndex = -1;
                var platform = GetSourceJumpPlatformByPriority(Position + Vector2.UnitY);
                if (platform.HasValue) surfaceIndex = platform.GetLandSoundIndex(this);
                ((ISourcePlayerJumpScene)Level).BurstPlayerDust(BottomCenter, -(float)Math.PI / 2f, 4, surfaceIndex);
            }

            ((ISourcePlayerJumpScene)Level).RecordPlayerJump();
        }

        public void WallJump(int direction)
        {
            Data.Motion.Ducking = false;
            Input.Jump.ConsumeBuffer();
            Data.Motion.JumpGraceTimer = 0f;
            Data.Motion.Normal.VariableJumpTimer = .2f;
            Data.Motion.AutoJump = false;
            Data.Motion.DashAttackTimer = 0f;
            Data.Motion.GliderBoostTimer = 0f;
            Data.Motion.WallSlideTimer = 1.2f;
            Data.Motion.WallBoostTimer = 0f;
            Data.Motion.LowFrictionStopTimer = .15f;
            if (Holding.Holding != null && Holding.Holding.SlowFall)
            {
                Data.Motion.ForceMoveX = direction;
                Data.Motion.ForceMoveXTimer = .26f;
            }
            else if (Data.MoveX != 0)
            {
                Data.Motion.ForceMoveX = direction;
                Data.Motion.ForceMoveXTimer = .16f;
            }

            if (LiftSpeed == Vector2.Zero)
            {
                var solid = SourceTrackedEntityCollision.FirstAt<SourceSolidEntityState>(
                    ((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid", this,
                    Position + Vector2.UnitX * 3f * -direction);
                if (solid != null) LiftSpeed = solid.LiftSpeed;
            }

            Data.Motion.Normal.Speed.X = 130f * (float)direction;
            Data.Motion.Normal.Speed.Y = -105f;
            Data.Motion.Normal.Speed += JumpMotion.LiftBoost(LiftSpeed);
            Data.Motion.Normal.VariableJumpSpeed = Data.Motion.Normal.Speed.Y;
            LaunchedBoostCheck();
            int index = -1;
            var platform = GetSourceJumpPlatformByPriority(Position - Vector2.UnitX * direction * 4f);
            if (platform.HasValue)
            {
                index = platform.GetWallSoundIndex(this, -direction);
                Play("event:/char/madeline/landing", "surface_index", index);
                if (platform.Platform is
                    global::Celeste.Simulation.Gameplay.Platforms.DreamBlock.ISourceDreamBlockRipple ripple)
                    ripple.FootstepRipple(Position + new Vector2(direction * 3, -4f));
            }

            Play(direction < 0 ? "event:/char/madeline/jump_wall_right" : "event:/char/madeline/jump_wall_left");
            Sprite.Scale = new Vector2(.6f, 1.4f);
            if (direction == -1)
                ((ISourcePlayerJumpScene)Level).BurstPlayerDust(Center + Vector2.UnitX * 2f,
                    (float)Math.PI * -3f / 4f, 4, index);
            else
                ((ISourcePlayerJumpScene)Level).BurstPlayerDust(Center + Vector2.UnitX * -2f,
                    -(float)Math.PI / 4f, 4, index);
            ((ISourcePlayerJumpScene)Level).RecordPlayerWallJump();
        }

        private bool LaunchedBoostCheck()
        {
            if (((ISourceVectorEnvironment)engineContext).VectorArithmetic.LengthSquared(
                    JumpMotion.LiftBoost(LiftSpeed)) >= 10000f
                && ((ISourceVectorEnvironment)engineContext).VectorArithmetic.LengthSquared(Data.Motion.Normal.Speed) >=
                48400f)
            {
                Data.Motion.Launched = true;
                return true;
            }

            Data.Motion.Launched = false;
            return false;
        }

        public void SuperJump()
        {
            Input.Jump.ConsumeBuffer();
            Data.Motion.JumpGraceTimer = 0f;
            Data.Motion.Normal.VariableJumpTimer = .2f;
            Data.Motion.AutoJump = false;
            Data.Motion.DashAttackTimer = 0f;
            Data.Motion.GliderBoostTimer = 0f;
            Data.Motion.WallSlideTimer = 1.2f;
            Data.Motion.WallBoostTimer = 0f;
            Data.Motion.Normal.Speed.X = 260f * (float)Data.Facing;
            Data.Motion.Normal.Speed.Y = -105f;
            Data.Motion.Normal.Speed += JumpMotion.LiftBoost(LiftSpeed);
            Data.Motion.GliderBoostTimer = .55f;
            Play("event:/char/madeline/jump");
            if (Data.Motion.Ducking)
            {
                Data.Motion.Ducking = false;
                Data.Motion.Normal.Speed.X *= 1.25f;
                Data.Motion.Normal.Speed.Y *= .5f;
                Play("event:/char/madeline/jump_superslide");
                Data.Motion.GliderBoostDirection = Vector2Geometry.AngleToVector((float)Math.PI * -3f / 16f, 1f);
            }
            else
            {
                Data.Motion.GliderBoostDirection = Vector2Geometry.AngleToVector(-(float)Math.PI / 4f, 1f);
                Play("event:/char/madeline/jump_super");
            }

            Data.Motion.Normal.VariableJumpSpeed = Data.Motion.Normal.Speed.Y;
            Data.Motion.Launched = true;
            Sprite.Scale = new Vector2(.6f, 1.4f);
            int index = -1;
            var platform = GetSourceJumpPlatformByPriority(Position + Vector2.UnitY);
            if (platform.HasValue) index = platform.GetLandSoundIndex(this);
            ((ISourcePlayerJumpScene)Level).BurstPlayerDust(BottomCenter, -(float)Math.PI / 2f, 4, index);
            ((ISourcePlayerJumpScene)Level).RecordPlayerJump();
        }

        public void SuperWallJump(int direction)
        {
            Data.Motion.Ducking = false;
            Input.Jump.ConsumeBuffer();
            Data.Motion.JumpGraceTimer = 0f;
            Data.Motion.Normal.VariableJumpTimer = .25f;
            Data.Motion.AutoJump = false;
            Data.Motion.DashAttackTimer = 0f;
            Data.Motion.GliderBoostTimer = .55f;
            Data.Motion.GliderBoostDirection = -Vector2.UnitY;
            Data.Motion.WallSlideTimer = 1.2f;
            Data.Motion.WallBoostTimer = 0f;
            Data.Motion.Normal.Speed.X = 170f * (float)direction;
            Data.Motion.Normal.Speed.Y = -160f;
            Data.Motion.Normal.Speed += JumpMotion.LiftBoost(LiftSpeed);
            Data.Motion.Normal.VariableJumpSpeed = Data.Motion.Normal.Speed.Y;
            Data.Motion.Launched = true;
            Play(direction < 0 ? "event:/char/madeline/jump_wall_right" : "event:/char/madeline/jump_wall_left");
            Play("event:/char/madeline/jump_superwall");
            Sprite.Scale = new Vector2(.6f, 1.4f);
            int index = -1;
            var platform = GetSourceJumpPlatformByPriority(Position - Vector2.UnitX * direction * 4f);
            if (platform.HasValue) index = platform.GetWallSoundIndex(this, direction);
            if (direction == -1)
                ((ISourcePlayerJumpScene)Level).BurstPlayerDust(Center + Vector2.UnitX * 2f,
                    (float)Math.PI * -3f / 4f, 4, index);
            else
                ((ISourcePlayerJumpScene)Level).BurstPlayerDust(Center + Vector2.UnitX * -2f,
                    -(float)Math.PI / 4f, 4, index);
            ((ISourcePlayerJumpScene)Level).RecordPlayerWallJump();
        }

        private Celeste.Simulation.Gameplay.Platforms.Audio.SourceSurfaceSoundSelection
            GetSourceJumpPlatformByPriority(Vector2 at, string sourceType = "Celeste.Platform")
            => FrameCallbackPlatform(at, sourceType);

        public void ClimbJump()
        {
            if (!Data.OnGround)
            {
                Data.Stamina -= 27.5f;
                Sweat.Play("jump", restart: true);
                Rumble(0, 1);
            }

            Data.DreamJump = false;
            Jump(particles: false, playSfx: false);
            if (Data.MoveX == 0)
            {
                Data.WallBoostDirection = -Data.Facing;
                Data.Motion.WallBoostTimer = .2f;
            }

            int index = -1;
            var platform = GetSourceJumpPlatformByPriority(Position - Vector2.UnitX * (float)Data.Facing * 4f);
            if (platform.HasValue) index = platform.GetWallSoundIndex(this, Data.Facing);
            if (Data.Facing == 1)
            {
                Play("event:/char/madeline/jump_climb_right");
                ((ISourcePlayerJumpScene)Level).BurstPlayerDust(Center + Vector2.UnitX * 2f,
                    (float)Math.PI * -3f / 4f, 4, index);
            }
            else
            {
                Play("event:/char/madeline/jump_climb_left");
                ((ISourcePlayerJumpScene)Level).BurstPlayerDust(Center + Vector2.UnitX * -2f,
                    -(float)Math.PI / 4f, 4, index);
            }
        }
    }
}
