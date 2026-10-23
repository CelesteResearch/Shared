using Celeste.Physics.Collision;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Input.Gameplay;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Dash
{
    public sealed class PlayerBoostSequence
    {
        private readonly global::Celeste.Simulation.Gameplay.Player.State.PlayerState data;
        private readonly global::Celeste.Simulation.Gameplay.Player.Configuration.IPlayerAssistSettings settings;
        private readonly ISourceGameInput input;
        private readonly RoomPlayerSession player;
        private readonly PixelActor body;
        private readonly global::Celeste.Core.Scheduling.SimulationStateMachine machine;
        private readonly global::Celeste.Simulation.Gameplay.Player.Dash.DashSequence dash;
        private readonly global::Celeste.Simulation.Gameplay.Player.Dash.IPlayerBoostWorld world;
        private readonly Action correctRedDashJumpThrus;
        public RoomPlayerSession Player => player;
        public Vector2 BoostTarget { get; set; }
        public bool BoostRed { get; private set; }

        public bool Chapter9BoosterBusy =>
            player.LastBooster != null && player.LastBooster.Ch9HubTransition && player.LastBooster.BoostingPlayer;

        public Vector2 DashAssistOffset =>
            player.CurrentBooster == null && machine.PreviousState != 5 ? Vector2.Zero : new Vector2(0, -4);

        private Vector2 ColliderCenter => player.Collider.Center;

        public PlayerBoostSequence(RoomPlayerSession player,
            global::Celeste.Simulation.Gameplay.Player.State.PlayerState data,
            global::Celeste.Simulation.Gameplay.Player.Configuration.IPlayerAssistSettings settings,
            ISourceGameInput input, PixelActor body,
            global::Celeste.Core.Scheduling.SimulationStateMachine machine,
            global::Celeste.Simulation.Gameplay.Player.Dash.DashSequence dash,
            global::Celeste.Simulation.Gameplay.Player.Dash.IPlayerBoostWorld world)
        {
            this.player = player;
            this.data = data;
            this.settings = settings;
            this.input = input;
            this.body = body;
            this.machine = machine;
            this.dash = dash;
            this.world = world;
            correctRedDashJumpThrus = world.RedDashCorrectJumpThrus;
            machine.SetCallbacks(4, BoostUpdate, BoostCoroutine, BoostBegin, BoostEnd);
            machine.SetCallbacks(5, RedDashUpdate, RedDashCoroutine, RedDashBegin, RedDashEnd);
        }

        public void Boost(global::Celeste.Simulation.Gameplay.Interaction.Booster.ISourceBooster booster, bool red)
        {
            machine.State = 4;
            data.Motion.Normal.Speed = Vector2.Zero;
            BoostTarget = booster.Center;
            BoostRed = red;
            player.LastBooster = player.CurrentBooster = booster;
        }

        public void BoostBegin() =>
            ((global::Celeste.Simulation.Gameplay.Player.Runtime.ISourcePlayerRuntimeEnvironment)player.EngineContext)
            .PlayerRuntimePolicy.BoostBegin(player, BoostBeginSourceBody);

        private void BoostBeginSourceBody()
        {
            player.RefillDash();
            player.RefillStamina();
            if (player.Holding.Holding != null) player.Drop();
        }

        public void BoostEnd()
        {
            MoveTo(PlayerBoostMotion.ReleasePosition(BoostTarget, ColliderCenter));
        }

        private void MoveTo(Vector2 target)
        {
            // BoostUpdate/BoostEnd use Actor.MoveToX/Y. Preserve that method's
            // subpixel arithmetic instead of first rounding ExactPosition.
            player.MoveToX(target.X);
            player.MoveToY(target.Y);
        }

        public int BoostUpdate()
        {
            Vector2 aim = input.Aim.Value * 3f;
            Vector2 exactPosition = body.ExactPosition;
            Vector2 exact = PlayerBoostMotion.ApproachPosition(player.EngineContext, exactPosition,
                BoostTarget, ColliderCenter, aim);

            MoveTo(exact);
            if (input.DashPressed || input.CrouchDashPressed)
            {
                data.DemoDashed = input.CrouchDashPressed;
                input.Dash.ConsumePress();
                input.CrouchDash.ConsumeBuffer();
                return BoostRed ? 5 : 2;
            }

            return 4;
        }

        public IEnumerator BoostCoroutine()
        {
            yield return .25f;
            machine.State = BoostRed ? 5 : 2;
        }

        public void RedDashBegin()
        {
            data.CalledEvents = false;
            data.StartedOnGround = false;
            world.Freeze(.05f);
            Vector2 reversed = -data.Direction;
            world.RedDashDust((float)Math.Atan2(reversed.Y, reversed.X), 8);
            data.CooldownTimer = .2f;
            data.RefillCooldownTimer = .1f;
            data.StartedDashing = true;
            world.RedDashDisplacement();
            world.Emit(global::Celeste.Simulation.Gameplay.Player.Dash.DashEffect.Rumble);
            data.Motion.DashAttackTimer = .3f;
            data.Motion.GliderBoostTimer = .55f;
            data.Direction = data.Motion.Normal.Speed = Vector2.Zero;
            if (!data.OnGround && world.CanUnDuck) data.Motion.Ducking = false;
            if (settings.DashAssist && !data.DemoDashed)
            {
                input.LastAim = Vector2.UnitX * data.Facing;
                input.GetAimVector(data.Facing);
                world.Emit(global::Celeste.Simulation.Gameplay.Player.Dash.DashEffect.AssistInit);
            }
        }

        public void RedDashEnd() => dash.CallEvents();

        public int RedDashUpdate()
        {
            data.StartedDashing = false;
            bool hubTransition = player.LastBooster != null && player.LastBooster.Ch9HubTransition;
            data.Motion.GliderBoostTimer = .05f;
            if (dash.CanDash) return dash.Start();
            return PlayerRedBoostMotion.CheckJumpExit(data, input, world, hubTransition, 5, correctRedDashJumpThrus);
        }

        public IEnumerator RedDashCoroutine()
        {
            yield return null;
            data.Motion.Normal.Speed =
                global::Celeste.Simulation.Gameplay.Player.Dash.DashSequence.CorrectPrecision(data.LastAim) * 240f;
            data.Motion.GliderBoostDirection = data.Direction = data.LastAim;
            world.Emit(global::Celeste.Simulation.Gameplay.Player.Dash.DashEffect.DirectionalShake);
            if (data.Direction.X != 0f) data.Facing = Math.Sign(data.Direction.X);
            dash.CallEvents();
        }

        // Invoke inside the shared DashStarted endpoint, after calledDashEvents is set.
        public bool TryCallBoosterDashEvent()
        {
            if (player.CurrentBooster == null) return false;
            player.CurrentBooster.PlayerBoosted(player, data.Direction);
            player.CurrentBooster = null;
            return true;
        }

        // Bounce/SuperBounce clear the field; PointBounce intentionally retains it.
        public void ReleaseCurrentBooster(bool clear = true)
        {
            if (machine.State != 4 || player.CurrentBooster == null) return;
            player.CurrentBooster.PlayerReleased();
            if (clear) player.CurrentBooster = null;
        }

        public void PlayerDied() => player.LastBooster?.PlayerDied();
    }
}
