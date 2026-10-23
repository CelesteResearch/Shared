using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Physics.Collision;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Player.State;

namespace Celeste.Simulation.Gameplay.Player.Dummy
{
    public sealed class PlayerDummyController
    {
        public readonly RoomPlayerWorld World;

        public PlayerSprite Sprite =>
            World.SourcePlayer.Sprite;

        public PlayerState Data => World.Data;
        public SimulationStateMachine Machine => World.Machine;
        public PixelActor Body => World.Body;
        public bool Moving, Gravity = true, AutoAnimate = true, Maxspeed = true, Friction = true;
        public float DeltaTime => World.EngineContext.DeltaTime;

        public PlayerDummyController(RoomPlayerWorld world)
        {
            World = world;
            Machine.SetCallbacks(11, Update, begin: Begin);
            Machine.SetCallbacks(15, null, WakeUpCoroutine);
        }

        public void Begin()
        {
            Moving = false;
            Gravity = true;
            AutoAnimate = true;
        }

        public int Update()
        {
            if (World.CanUnDuck)
            {
                Data.Motion.Ducking = false;
                World.Contacts.SyncCollider();
            }

            ref var normal = ref Data.Motion.Normal;
            var jump = World.Input[GameAction.Jump].Check;
            if (!Data.OnGround && Gravity)
            {
                var multiplier = Math.Abs(normal.Speed.Y) < 40 && (jump || Data.Motion.AutoJump) ? .5f : 1;
                if (World.InSpace) multiplier *= .6f;
                normal.Speed.Y =
                    ScalarMath.Approach(normal.Speed.Y, 160,
                        900 * multiplier * DeltaTime);
            }

            if (normal.VariableJumpTimer > 0)
            {
                if (Data.Motion.AutoJump || jump) normal.Speed.Y = Math.Min(normal.Speed.Y, normal.VariableJumpSpeed);
                else normal.VariableJumpTimer = 0;
            }

            if (!Moving)
            {
                if (Math.Abs(normal.Speed.X) > 90 && Maxspeed)
                    normal.Speed.X =
                        ScalarMath.Approach(normal.Speed.X,
                            90 * Math.Sign(normal.Speed.X), 2500 * DeltaTime);
                if (Friction)
                    normal.Speed.X =
                        ScalarMath.Approach(normal.Speed.X, 0, 1000 * DeltaTime);
            }

            if (AutoAnimate)
                Sprite.Play(Data.OnGround ? normal.Speed.X == 0 ? "idle" : "walk" :
                    normal.Speed.Y < 0 ? "jumpSlow" : "fallSlow");
            return 11;
        }

        public IEnumerator WalkTo(float x, bool walkBackwards = false, float speedMultiplier = 1,
            bool keepWalkingIntoWalls = false)
        {
            Machine.State = 11;
            if (Math.Abs(Body.Position.X - x) > 4f && !World.SourcePlayer.Dead)
            {
                Moving = true;
                if (walkBackwards)
                {
                    Sprite.Rate = -1f;
                    Data.Facing = Math.Sign(Body.Position.X - x);
                }
                else
                {
                    Data.Facing = Math.Sign(x - Body.Position.X);
                }

                while (Math.Abs(x - Body.Position.X) > 4f && World.SourcePlayer.Scene != null &&
                       (keepWalkingIntoWalls || !World.SolidAt(Vector2.UnitX * Math.Sign(x - Body.Position.X))))
                {
                    Data.Motion.Normal.Speed.X = ScalarMath.Approach(
                        Data.Motion.Normal.Speed.X,
                        Math.Sign(x - Body.Position.X) * 64f * speedMultiplier, 1000f * DeltaTime);
                    yield return null;
                }

                Sprite.Rate = 1f;
                Sprite.Play("idle");
                Moving = false;
            }
        }

        public IEnumerator WalkToExact(int x, bool walkBackwards = false, float speedMultiplier = 1,
            bool cancelOnFall = false)
        {
            Machine.State = 11;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (Body.Position.X == x) yield break;
            Moving = true;
            if (walkBackwards)
            {
                Sprite.Rate = -1;
                Data.Facing = Math.Sign(Body.Position.X - x);
            }
            else
            {
                Data.Facing = Math.Sign(x - Body.Position.X);
            }

            var last = Math.Sign(Body.Position.X - x);
            // Native tests the facing-side wall even when walking backwards.
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            while (!World.SourcePlayer.Dead && Body.Position.X != x &&
                   !World.SolidAt(new(Data.Facing, 0)) &&
                   (!cancelOnFall || World.Contacts.GroundAt(Vector2.Zero)))
            {
                Data.Motion.Normal.Speed.X = ScalarMath.Approach(
                    Data.Motion.Normal.Speed.X,
                    Math.Sign(x - Body.Position.X) * 64f * speedMultiplier, 1000 * DeltaTime);
                var next = Math.Sign(Body.Position.X - x);
                if (next != last)
                {
                    Body.Position.X = x;
                    break;
                }

                last = next;
                yield return null;
            }

            Data.Motion.Normal.Speed.X = 0;
            Sprite.Rate = 1;
            Sprite.Play("idle");
            Moving = false;
        }

        public void StartTempleMirrorVoidSleep()
        {
            Sprite.Play("asleep");
            Data.Facing = 1;
            Machine.State = 11;
            Machine.Locked = true;
            AutoAnimate = false;
            Gravity = false;
        }

        public IEnumerator RunTo(float x, bool fastAnimation = false)
        {
            Machine.State = 11;
            if (Math.Abs(Body.Position.X - x) > 4f)
            {
                Moving = true;
                if (fastAnimation) Sprite.Play("runFast");
                else if (!Sprite.LastAnimationID.StartsWith("run")) Sprite.Play("runSlow");
                Data.Facing = Math.Sign(x - Body.Position.X);
                while (Math.Abs(Body.Position.X - x) > 4f)
                {
                    Data.Motion.Normal.Speed.X = ScalarMath.Approach(
                        Data.Motion.Normal.Speed.X,
                        Math.Sign(x - Body.Position.X) * 90f, 1000f * DeltaTime);
                    yield return null;
                }

                Sprite.Play("idle");
                Moving = false;
            }
        }

        public void StartWakeUp()
        {
            Sprite.Play("asleep");
            Data.Facing = 1;
            Machine.State = 15;
        }

        public IEnumerator WakeUpCoroutine()
        {
            Sprite.Play("asleep");
            yield return .5f;
            yield return Sprite.PlayRoutine("wakeUp");
            yield return .2f;
            Machine.State = 0;
        }
    }
}
