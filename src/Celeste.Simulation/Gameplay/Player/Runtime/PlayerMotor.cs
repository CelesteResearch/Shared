using System;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Physics.Collision;
using Celeste.Simulation.Gameplay.Player.Collision.Responses;
using Celeste.Simulation.Gameplay.Player.Configuration;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Gameplay.Player.Movement;
using Celeste.Simulation.Gameplay.Player.State;

namespace Celeste.Simulation.Gameplay.Player.Runtime
{
    public sealed class PlayerMotor
    {
        public readonly PlayerState Data;
        public readonly IPlayerAssistSettings Settings;
        public readonly ISourceGameInput Input;
        public readonly PixelActor Body;
        public readonly SimulationStateMachine Machine;
        public readonly NormalSequence Normal;
        public readonly ClimbSequence Climb;
        public readonly DashSequence Dash;
        public readonly SwimSequence Swim;
        public readonly PlayerFrameMotion BeforeState;

        public readonly PlayerCollisionResponse
            Collisions;

        public readonly PlayerMovement Movement;

        // Native component order: Hair, Sprite and Sweat precede StateMachine;
        // Leader, light, water/wind interaction and sound sources follow it.
        public Action<float, float> UpdateOwnedComponents;

        public PlayerMotor(PlayerState data,
            IPlayerAssistSettings settings,
            ISourceGameInput input,
            PixelActor body, SimulationStateMachine machine,
            IPlayerMotorWorld world,
            ISourceEngineContext engine)
        {
            Data = data;
            Settings = settings;
            Input = input;
            Body = body;
            Machine = machine;
            Dash = new(data, settings, input, machine,
                world, engine);
            Normal = new(data, settings, input,
                machine, Dash, world, engine);
            Climb = new(data, input, machine, Dash,
                world, engine);
            Swim = new(data, settings, input, machine,
                Dash, world, engine);
            BeforeState =
                new(data, settings, input, machine,
                    world);
            Collisions =
                new(data,
                    machine, world, (RoomPlayerSession)body.SourceColliderOwner);
            Movement = new(data, machine, world,
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
