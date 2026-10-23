using Celeste.Core.Display;
using System.Numerics;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession : global::Celeste.Scene.Tracking.ISceneEntityDepth,
        global::Celeste.Core.Components.ISourceOwnedComponentList, global::Celeste.Core.Components.ISourceEntityPosition
    {
        public global::Celeste.Core.Scheduling.ISourceEngineContext EngineContext => engineContext;
        Vector2 global::Celeste.Core.Components.ISourceEntityPosition.Position => Body.Position;
        public global::Celeste.Simulation.Presentation.Lighting.VertexLightState Light { get; private set; }

        public global::Celeste.Simulation.Gameplay.Environment.Water.WaterInteractionState WaterInteraction
        {
            get;
            private set;
        }

        public global::Celeste.Simulation.Gameplay.Environment.Wind.WindMoverState WindMover { get; private set; }

        private void ConstructSourceComponents()
        {
            // One actual ComponentList from construction, independent of any scene index.
            Leader = new global::Celeste.Scene.Following.LeaderState(engineContext, new Vector2(0f, -8f));
            Components.Add(Leader);
            Data.LastAim = Vector2.UnitX;
            Data.Facing = 1;
            ChaserStates =
                new System.Collections.Generic.List<
                    global::Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers.ChaserState>();
            Light = new global::Celeste.Simulation.Presentation.Lighting.VertexLightState(engineContext,
                new Vector2(0, -8), global::Celeste.Core.Display.PackedColor.White, 1, 32, 64);
            Components.Add(Light);
            WaterInteraction =
                ((global::Celeste.Simulation.Gameplay.Environment.Water.IWaterInteractionConstructionEnvironment)
                    engineContext).WaterInteractions.Create(() => Machine.State == 2 || Machine.State == 18);
            Components.Add(WaterInteraction);
            var movement =
                new global::Celeste.Simulation.Gameplay.Player.Movement.Wind.PlayerWindMovement(World, Appearance,
                    () => JustRespawned);
            WindMover = new global::Celeste.Simulation.Gameplay.Environment.Wind.WindMoverState(movement.Move);
            Components.Add(WindMover);
            var sounds = ((global::Celeste.Simulation.Audio.Sources.ISourceSoundSourceEnvironment)engineContext)
                .SoundSources;
            WallSlideSoundComponent = sounds.Create();
            Components.Add(WallSlideSoundComponent);
            SwimSurfaceSoundComponent = sounds.Create();
            Components.Add(SwimSurfaceSoundComponent);
        }
    }
}
