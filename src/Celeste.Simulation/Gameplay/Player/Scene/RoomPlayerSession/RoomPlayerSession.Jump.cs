using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.Audio;
using Celeste.Simulation.Gameplay.Platforms.DreamBlock;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Movement;
using Celeste.Simulation.Gameplay.Player.Scene.Particles;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        private readonly List<object> sourceCollisionTemp = [];

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
            Data.Motion.Normal.Speed.X += 40f * Data.MoveX;
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

            Sprite.Scale = new(.6f, 1.4f);
            if (particles)
            {
                var surfaceIndex = -1;
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

            Data.Motion.Normal.Speed.X = 130f * direction;
            Data.Motion.Normal.Speed.Y = -105f;
            Data.Motion.Normal.Speed += JumpMotion.LiftBoost(LiftSpeed);
            Data.Motion.Normal.VariableJumpSpeed = Data.Motion.Normal.Speed.Y;
            LaunchedBoostCheck();
            var index = -1;
            var platform = GetSourceJumpPlatformByPriority(Position - Vector2.UnitX * direction * 4f);
            if (platform.HasValue)
            {
                index = platform.GetWallSoundIndex(this, -direction);
                Play("event:/char/madeline/landing", "surface_index", index);
                if (platform.Platform is
                    ISourceDreamBlockRipple ripple)
                    ripple.FootstepRipple(Position + new Vector2(direction * 3, -4f));
            }

            Play(direction < 0 ? "event:/char/madeline/jump_wall_right" : "event:/char/madeline/jump_wall_left");
            Sprite.Scale = new(.6f, 1.4f);
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
            if (((ISourceVectorEnvironment)EngineContext).VectorArithmetic.LengthSquared(
                    JumpMotion.LiftBoost(LiftSpeed)) >= 10000f
                && ((ISourceVectorEnvironment)EngineContext).VectorArithmetic.LengthSquared(Data.Motion.Normal.Speed) >=
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
            Data.Motion.Normal.Speed.X = 260f * Data.Facing;
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
            Sprite.Scale = new(.6f, 1.4f);
            var index = -1;
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
            Data.Motion.Normal.Speed.X = 170f * direction;
            Data.Motion.Normal.Speed.Y = -160f;
            Data.Motion.Normal.Speed += JumpMotion.LiftBoost(LiftSpeed);
            Data.Motion.Normal.VariableJumpSpeed = Data.Motion.Normal.Speed.Y;
            Data.Motion.Launched = true;
            Play(direction < 0 ? "event:/char/madeline/jump_wall_right" : "event:/char/madeline/jump_wall_left");
            Play("event:/char/madeline/jump_superwall");
            Sprite.Scale = new(.6f, 1.4f);
            var index = -1;
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

        private SourceSurfaceSoundSelection
            GetSourceJumpPlatformByPriority(Vector2 at, string sourceType = "Celeste.Platform")
        {
            return FrameCallbackPlatform(at, sourceType);
        }

        public void ClimbJump()
        {
            if (!Data.OnGround)
            {
                Data.Stamina -= 27.5f;
                Sweat.Play("jump", true);
                Rumble(0, 1);
            }

            Data.DreamJump = false;
            Jump(false, false);
            if (Data.MoveX == 0)
            {
                Data.WallBoostDirection = -Data.Facing;
                Data.Motion.WallBoostTimer = .2f;
            }

            var index = -1;
            var platform = GetSourceJumpPlatformByPriority(Position - Vector2.UnitX * Data.Facing * 4f);
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
