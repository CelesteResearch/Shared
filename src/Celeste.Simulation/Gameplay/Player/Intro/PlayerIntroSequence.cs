using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Player.State;

namespace Celeste.Simulation.Gameplay.Player.Intro
{
    // StateMachine coroutine components own the clock and yields. Motion remains
    // in PlayerMovement, after the state machine and the rest of the components.
    public sealed class PlayerIntroSequence
    {
        public readonly PlayerState Data;
        public readonly SimulationStateMachine Machine;
        public PlayerSprite Sprite => World.Sprite;
        public readonly PlayerHair Hair;
        public readonly IPlayerIntroWorld World;
        private readonly ISourceEngineContext engine;
        public float DeltaTime => engine.DeltaTime;
        public int WalkDirection = 1;

        public PlayerIntroSequence(PlayerState data,
            SimulationStateMachine machine,
            PlayerHair hair,
            IPlayerIntroWorld world,
            ISourceEngineContext engine)
        {
            Data = data;
            Machine = machine;
            Hair = hair;
            World = world;
            this.engine = engine;
            machine.SetCallbacks(12, null, WalkCoroutine);
            machine.SetCallbacks(13, null, JumpCoroutine);
            machine.SetCallbacks(23, null, MoonJumpCoroutine);
            machine.SetCallbacks(25, null, ThinkForABitCoroutine);
        }

        public IEnumerator WalkCoroutine()
        {
            var start = World.Position;
            World.Position = new(
                WalkDirection == 1 ? unchecked(World.RoomBounds.X - 16) : unchecked(World.RoomBounds.Right + 16),
                World.Position.Y);
            Data.Facing = WalkDirection == 1 ? 1 : -1;
            yield return .3f;
            Sprite.Play("runSlow");
            while (Math.Abs(World.Position.X - start.X) > 2 &&
                   !World.SolidAt(World.Position + new Vector2(Data.Facing, 0)))
            {
                World.MoveTowardsX(start.X, 64 * DeltaTime);
                yield return null;
            }

            World.Position = start;
            Sprite.Play("idle");
            yield return .2f;
            Machine.State = 0;
        }

        private void ApplyJumpGravity()
        {
            // Player.IntroJumpCoroutine stores the Single gravity increment
            // before adding it to Speed.Y; Mono otherwise fuses this product.
            var amount = (float)((double)DeltaTime * 800);
            Data.Motion.Normal.Speed.Y = (float)((double)Data.Motion.Normal.Speed.Y + amount);
        }

        public IEnumerator JumpCoroutine()
        {
            var start = World.Position;
            var summit = Machine.PreviousState == 10;
            World.Depth = -1000000;
            Data.Facing = 1;
            if (!summit)
            {
                World.Position = new(World.Position.X, unchecked(World.RoomBounds.Bottom + 16));
                yield return .5f;
            }
            else
            {
                start.Y = unchecked(World.RoomBounds.Bottom - 24);
                World.MoveToX((int)Math.Round(World.Position.X / 8) * 8);
            }

            if (!summit) Sprite.Play("jumpSlow");
            while (World.Position.Y > start.Y - 8)
            {
                World.Position += new Vector2(0, -120 * DeltaTime);
                yield return null;
            }

            World.Position = new(World.Position.X, (float)Math.Round(World.Position.Y));
            Data.Motion.Normal.Speed.Y = -100;
            while (Data.Motion.Normal.Speed.Y < 0)
            {
                ApplyJumpGravity();
                yield return null;
            }

            Data.Motion.Normal.Speed.Y = 0;
            if (summit)
            {
                yield return .2f;
                World.PlaySound("event:/char/madeline/summit_areastart");
                Sprite.Play("launchRecover");
                yield return .1f;
            }
            else
            {
                yield return .1f;
            }

            if (!summit) Sprite.Play("fallSlow");
            while (!Data.OnGround)
            {
                ApplyJumpGravity();
                yield return null;
            }

            if (Machine.PreviousState != 10) World.Position = start;
            World.Depth = 0;
            World.DirectionalShake(Vector2.UnitY);
            World.RumbleStrongMedium();
            if (summit)
            {
                World.EmitSummitLand(0, false, 12, World.BottomCenter, Vector2.UnitX * 3, -(float)Math.PI / 2);
                World.EmitSummitLand(1, false, 8, World.BottomCenter - Vector2.UnitX * 2, Vector2.UnitX * 2, 3.403392f);
                World.EmitSummitLand(1, false, 8, World.BottomCenter + Vector2.UnitX * 2, Vector2.UnitX * 2,
                    -(float)Math.PI / 12);
                World.EmitSummitLand(2, true, 30, World.BottomCenter, Vector2.UnitX * 5, null);
                yield return .35f;
                for (var i = 0; i < Hair.Nodes.Count; i++) Hair.Nodes[i] = new(0, 2 + i);
            }

            Machine.State = 0;
        }

        public IEnumerator MoonJumpCoroutine()
        {
            var start = World.Position;
            Data.Facing = 1;
            Data.Motion.Normal.Speed = Vector2.Zero;
            World.Visible = false;
            World.Position = new(World.Position.X, unchecked(World.RoomBounds.Bottom + 16));
            yield return .5f;
            yield return MoonLanding(start);
            Machine.State = 0;
        }

        public IEnumerator MoonLanding(Vector2 groundPosition)
        {
            World.Depth = -1000000;
            Data.Motion.Normal.Speed = Vector2.Zero;
            World.Visible = true;
            Sprite.Play("jumpSlow");
            while (World.Position.Y > groundPosition.Y - 8)
            {
                World.MoveV(-200 * DeltaTime);
                yield return null;
            }

            Data.Motion.Normal.Speed.Y = -200;
            while (Data.Motion.Normal.Speed.Y < 0)
            {
                Data.Motion.Normal.Speed.Y += DeltaTime * 400;
                yield return null;
            }

            Data.Motion.Normal.Speed.Y = 0;
            yield return .2f;
            Sprite.Play("fallSlow");
            float speed = 100;
            while (!World.OnGround())
            {
                Data.Motion.Normal.Speed.Y += DeltaTime * speed;
                speed = ScalarMath.Approach(speed, 2, DeltaTime * 50,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }

            World.Depth = 0;
        }

        public IEnumerator ThinkForABitCoroutine()
        {
            World.CameraX += 8;
            yield return .1f;
            Sprite.Play("walk");
            var target = World.Position.X + 8;
            while (World.Position.X < target)
            {
                World.MoveH(32 * DeltaTime);
                yield return null;
            }

            Sprite.Play("idle");
            yield return .3f;
            Data.Facing = -1;
            yield return .8f;
            Data.Facing = 1;
            yield return .1f;
            Machine.State = 0;
        }
    }
}
