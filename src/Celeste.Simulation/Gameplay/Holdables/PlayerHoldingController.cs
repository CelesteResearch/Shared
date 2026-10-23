using System;
using System.Collections;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Physics.Collision;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Player.State;

namespace Celeste.Simulation.Gameplay.Holdables
{
    public sealed class PlayerHoldingController
    {
        public readonly PixelActor Body;
        public readonly PlayerState Data;
        public readonly ISourceGameInput Input;
        public readonly SimulationStateMachine Machine;
        public PlayerSprite Sprite => player.Sprite;
        public int Depth => player.Depth;
        public HoldableState Holding { get; private set; }
        public Vector2 CarryOffset { get; private set; }
        public static readonly Vector2 CarryOffsetTarget = new(0, -12);
        private readonly PlayerCarryTargetState carryTarget;

        public Vector2 CarryOffsetTargetValue
        {
            get => carryTarget.Value;
            set => carryTarget.Value = value;
        }

        private readonly RoomPlayerSession player;

        public PlayerHoldingController(PixelActor body,
            PlayerState data, ISourceGameInput input,
            SimulationStateMachine machine, RoomPlayerSession player)
        {
            this.player = player ?? throw new ArgumentNullException(nameof(player));
            carryTarget = PlayerCarryTargetState.For(player.EngineContext);
            Body = body;
            Data = data;
            Input = input;
            Machine = machine;
            machine.SetCallbacks(8, null, PickupCoroutine);
        }

        public PlayerHoldingController(RoomPlayerWorld world, RoomPlayerSession player)
            : this(world.Body, world.Data, world.Input, world.Machine, player)
        {
        }

        public void SetHolding(HoldableState value)
        {
            Holding = value;
        }

        public bool TryPickup()
        {
            foreach (var tracked in ((ISourceScene)player.Scene).SourceScene.Components
                     .GetTrackedComponents("Celeste.Holdable"))
            {
                var holdable = (HoldableState)tracked;
                if (holdable.Check(player) && Pickup(holdable)) return true;
            }

            return false;
        }

        [MethodImpl(MethodImplOptions
            .NoInlining)]
        public bool Pickup(HoldableState pickup)
        {
            if (!pickup.Pickup(player)) return false;
            Data.Motion.Ducking = false;
            SetHolding(pickup);
            Data.MinHoldTimer = .35f;
            return true;
        }

        public void UpdateCarry()
        {
            if (Holding == null) return;
            if (!Holding.ScenePresent) SetHolding(null);
            else Holding.Carry(Body.Position + CarryOffset + Vector2.UnitY * Sprite.CarryYOffset);
        }

        public void Swat(int direction)
        {
            if (Holding != null)
            {
                Holding.Release(new(.8f * direction, -.25f));
                SetHolding(null);
            }
        }

        public void Throw()
        {
            if (Holding == null) return;
            if (Input.MoveY.Value == 1)
            {
                Drop();
            }
            else
            {
                player.Rumble(2, 0);
                Holding.Release(Vector2.UnitX * Data.Facing);
                Data.Motion.Normal.Speed.X += 80f * -Data.Facing;
                player.Play("event:/char/madeline/crystaltheo_throw");
                player.Sprite.Play("throw");
            }

            SetHolding(null);
        }

        public void Drop()
        {
            if (Holding != null)
            {
                player.Rumble(0, 0);
                Holding.Release(Vector2.Zero);
                SetHolding(null);
            }
        }

        private IEnumerator PickupCoroutine()
        {
            player.Play("event:/char/madeline/crystaltheo_lift");
            player.Rumble(1, 0);
            if (Holding != null && Holding.SlowFall &&
                ((Data.Motion.GliderBoostTimer - .16f > 0 && Data.Motion.GliderBoostDirection.Y < 0)
                 || (((ISourceVectorEnvironment)player.EngineContext)
                     .VectorArithmetic
                     .Length(Data.Motion.Normal.Speed) > 180 && Data.Motion.Normal.Speed.Y <= 0)))
                ((ISourceSpatialAudioEnvironment)player.EngineContext).SpatialAudio.Play(
                    "event:/new_content/game/10_farewell/glider_platform_dissipate", Body.Position);
            var speed = Data.Motion.Normal.Speed;
            var varJump = Data.Motion.Normal.VariableJumpTimer;
            Data.Motion.Normal.Speed = Vector2.Zero;
            var begin = ((ISourceEntityPosition)Holding.Entity).Position -
                        Body.Position;
            var control = new Vector2(begin.X + Math.Sign(begin.X) * 2,
                CarryOffsetTargetValue.Y - 2);
            var curve = new SimpleCurve(begin,
                CarryOffsetTargetValue, control);
            CarryOffset = begin;
            var tween = SourceTweenState.Create(
                player.EngineContext.TweenPool,
                SourceTweenState.TweenMode.Oneshot,
                ((ISourceEasingEnvironment)player.EngineContext)
                .EasingArithmetic.CubeInOut, .16f, true);
            tween.OnUpdate = t => CarryOffset = curve.GetPoint(t.Eased,
                ((ISourceCurveEnvironment)player.EngineContext).CurveArithmetic);
            player.Components.Add(tween);
            yield return tween.Wait();
            Data.Motion.Normal.Speed = speed;
            Data.Motion.Normal.Speed.Y =
                ((ISourceExtremaEnvironment)player.EngineContext)
                .ExtremaArithmetic.Min(Data.Motion.Normal.Speed.Y, 0);

            Data.Motion.Normal.VariableJumpTimer = varJump;
            Machine.State = 0;
            if (Holding != null && Holding.SlowFall)
            {
                if (Data.Motion.GliderBoostTimer > 0 && Data.Motion.GliderBoostDirection.Y < 0)
                {
                    player.Rumble(1, 0);
                    Data.Motion.GliderBoostTimer = 0;
                    Data.Motion.Normal.Speed.Y =
                        ((ISourceExtremaEnvironment)player.EngineContext)
                        .ExtremaArithmetic.Min(Data.Motion.Normal.Speed.Y,
                            -240 * Math.Abs(Data.Motion.GliderBoostDirection.Y));
                }
                else if (Data.Motion.Normal.Speed.Y < 0)
                {
                    Data.Motion.Normal.Speed.Y =
                        ((ISourceExtremaEnvironment)player.EngineContext)
                        .ExtremaArithmetic.Min(Data.Motion.Normal.Speed.Y, -105);
                }

                if (Data.OnGround && Input.MoveY.Value == 1) Data.Motion.Normal.HoldCannotDuck = true;
            }
        }
    }
}
