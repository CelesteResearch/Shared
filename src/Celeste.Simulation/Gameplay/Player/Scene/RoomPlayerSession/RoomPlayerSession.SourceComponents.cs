using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Environment.Water;
using Celeste.Simulation.Gameplay.Environment.Wind;
using Celeste.Simulation.Gameplay.Player.Movement.Wind;
using Celeste.Simulation.Presentation.Lighting;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession : ISceneEntityDepth,
        ISourceOwnedComponentList, ISourceEntityPosition
    {
        public ISourceEngineContext EngineContext { get; }

        Vector2 ISourceEntityPosition.Position => Body.Position;
        public VertexLightState Light { get; private set; }

        public WaterInteractionState WaterInteraction { get; private set; }

        public WindMoverState WindMover { get; private set; }

        private void ConstructSourceComponents()
        {
            // One actual ComponentList from construction, independent of any scene index.
            Leader = new(EngineContext, new(0f, -8f));
            Components.Add(Leader);
            Data.LastAim = Vector2.UnitX;
            Data.Facing = 1;
            ChaserStates =
                [];
            Light = new(EngineContext,
                new(0, -8), PackedColor.White, 1, 32, 64);
            Components.Add(Light);
            WaterInteraction =
                ((IWaterInteractionConstructionEnvironment)
                    EngineContext).WaterInteractions.Create(() => Machine.State == 2 || Machine.State == 18);
            Components.Add(WaterInteraction);
            var movement =
                new PlayerWindMovement(World, Appearance,
                    () => JustRespawned);
            WindMover = new(movement.Move);
            Components.Add(WindMover);
            var sounds = ((ISourceSoundSourceEnvironment)EngineContext)
                .SoundSources;
            WallSlideSoundComponent = sounds.Create();
            Components.Add(WallSlideSoundComponent);
            SwimSurfaceSoundComponent = sounds.Create();
            Components.Add(SwimSurfaceSoundComponent);
        }
    }
}
