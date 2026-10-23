using Celeste.Physics.Collision;
using Celeste.Input.Gameplay;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Runtime
{
    public sealed class PlayerMotor
    {
        public readonly global::Celeste.Simulation.Gameplay.Player.State.PlayerState Data;
        public readonly global::Celeste.Simulation.Gameplay.Player.Configuration.IPlayerAssistSettings Settings;
        public readonly global::Celeste.Input.Gameplay.ISourceGameInput Input;
        public readonly PixelActor Body;
        public readonly global::Celeste.Core.Scheduling.SimulationStateMachine Machine;
        public readonly global::Celeste.Simulation.Gameplay.Player.Movement.NormalSequence Normal;
        public readonly global::Celeste.Simulation.Gameplay.Player.Movement.ClimbSequence Climb;
        public readonly global::Celeste.Simulation.Gameplay.Player.Dash.DashSequence Dash;
        public readonly global::Celeste.Simulation.Gameplay.Player.Movement.SwimSequence Swim;
        public readonly global::Celeste.Simulation.Gameplay.Player.Runtime.PlayerFrameMotion BeforeState;

        public readonly global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionResponse
            Collisions;

        public readonly global::Celeste.Simulation.Gameplay.Player.Movement.PlayerMovement Movement;

        // Native component order: Hair, Sprite and Sweat precede StateMachine;
        // Leader, light, water/wind interaction and sound sources follow it.
        public System.Action<float, float> UpdateOwnedComponents;

        public PlayerMotor(global::Celeste.Simulation.Gameplay.Player.State.PlayerState data,
            global::Celeste.Simulation.Gameplay.Player.Configuration.IPlayerAssistSettings settings,
            global::Celeste.Input.Gameplay.ISourceGameInput input,
            PixelActor body, global::Celeste.Core.Scheduling.SimulationStateMachine machine,
            global::Celeste.Simulation.Gameplay.Player.Runtime.IPlayerMotorWorld world,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            Data = data;
            Settings = settings;
            Input = input;
            Body = body;
            Machine = machine;
            Dash = new global::Celeste.Simulation.Gameplay.Player.Dash.DashSequence(data, settings, input, machine,
                world, engine);
            Normal = new global::Celeste.Simulation.Gameplay.Player.Movement.NormalSequence(data, settings, input,
                machine, Dash, world, engine);
            Climb = new global::Celeste.Simulation.Gameplay.Player.Movement.ClimbSequence(data, input, machine, Dash,
                world, engine);
            Swim = new global::Celeste.Simulation.Gameplay.Player.Movement.SwimSequence(data, settings, input, machine,
                Dash, world, engine);
            BeforeState =
                new global::Celeste.Simulation.Gameplay.Player.Runtime.PlayerFrameMotion(data, settings, input, machine,
                    world);
            Collisions =
                new global::Celeste.Simulation.Gameplay.Player.Collision.Responses.PlayerCollisionResponse(data,
                    machine, world, (RoomPlayerSession)body.SourceColliderOwner);
            Movement = new global::Celeste.Simulation.Gameplay.Player.Movement.PlayerMovement(data, machine, world,
                Collisions);
        }

        // Scene input/variant hooks run first. Freeze and pause belong to the scene
        // clock and skip this entire method; entering a dash does not abort its frame.
        public void UpdateMotion(float deltaTime, float rawDeltaTime)
        {
            BeforeState.Update(deltaTime);
            UpdateOwnedComponents(deltaTime, rawDeltaTime);
            Movement.Update(deltaTime);
        }

        // Run after animation, carry, triggers, hazards and camera. The original early
        // return on a lethal player collision skips these assignments.
        public void FinishFrame()
        {
            Data.WasOnGround = Data.OnGround;
            Data.WindMovedUp = false;
        }
    }
}
