using Celeste.Physics.Collision;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Intro
{
    // StateMachine coroutine components own the clock and yields. Motion remains
    // in PlayerMovement, after the state machine and the rest of the components.
    public sealed partial class PlayerIntroSequence
    {
        public readonly global::Celeste.Simulation.Gameplay.Player.State.PlayerState Data;
        public readonly global::Celeste.Core.Scheduling.SimulationStateMachine Machine;
        public global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSprite Sprite => World.Sprite;
        public readonly global::Celeste.Simulation.Gameplay.Player.Presentation.Hair.PlayerHair Hair;
        public readonly global::Celeste.Simulation.Gameplay.Player.Intro.IPlayerIntroWorld World;
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;
        public float DeltaTime => engine.DeltaTime;
        public int WalkDirection = 1;

        public PlayerIntroSequence(global::Celeste.Simulation.Gameplay.Player.State.PlayerState data,
            global::Celeste.Core.Scheduling.SimulationStateMachine machine,
            global::Celeste.Simulation.Gameplay.Player.Presentation.Hair.PlayerHair hair,
            global::Celeste.Simulation.Gameplay.Player.Intro.IPlayerIntroWorld world,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine)
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
            Vector2 start = World.Position;
            World.Position = new Vector2(
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
            float amount = (float)((double)DeltaTime * 800);
            Data.Motion.Normal.Speed.Y = (float)((double)Data.Motion.Normal.Speed.Y + amount);
        }

        public IEnumerator JumpCoroutine()
        {
            Vector2 start = World.Position;
            bool summit = Machine.PreviousState == 10;
            World.Depth = -1000000;
            Data.Facing = 1;
            if (!summit)
            {
                World.Position = new Vector2(World.Position.X, unchecked(World.RoomBounds.Bottom + 16));
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

            World.Position = new Vector2(World.Position.X, (float)Math.Round(World.Position.Y));
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
            else yield return .1f;

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
                for (int i = 0; i < Hair.Nodes.Count; i++) Hair.Nodes[i] = new Vector2(0, 2 + i);
            }

            Machine.State = 0;
        }

        public IEnumerator MoonJumpCoroutine()
        {
            Vector2 start = World.Position;
            Data.Facing = 1;
            Data.Motion.Normal.Speed = Vector2.Zero;
            World.Visible = false;
            World.Position = new Vector2(World.Position.X, unchecked(World.RoomBounds.Bottom + 16));
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
                speed = global::Celeste.Core.Mathematics.ScalarMath.Approach(speed, 2, DeltaTime * 50,
                    ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }

            World.Depth = 0;
        }

        public IEnumerator ThinkForABitCoroutine()
        {
            World.CameraX += 8;
            yield return .1f;
            Sprite.Play("walk");
            float target = World.Position.X + 8;
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
