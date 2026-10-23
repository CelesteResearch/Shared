using System;
using Celeste.Graphics.Content;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Simulation.Gameplay.Player.Events;
using Celeste.Simulation.Rendering;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public bool DashAssistFreeze => EngineContext.Effects.DashAssistFreeze;
        public bool DashAssistFreezePress => EngineContext.Effects.DashAssistFreezePress;

        private void BindDashAssistEvents()
        {
            World.Emitted += value =>
            {
                if (value.Kind != RoomPlayerEventKind.Dash ||
                    value.Name != "AssistInit") return;
                EngineContext.Effects.DashAssistFreeze = true;
                EngineContext.Effects.DashAssistFreezePress = false;
                var scene = (IPlayerDashAssistScene)Scene;
                var entities = scene.Scheduler.Entities.GetTrackedEntities(typeof(PlayerDashAssistPresentation));
                var assist =
                    entities.Count == 0 ? null : (PlayerDashAssistPresentation)entities[0];
                if (assist == null)
                    scene.AddDashAssist(assist = new(EngineContext,
                        ((ISourceGlobalFrozenExecutionTagsEnvironment)
                            EngineContext).GlobalFrozenExecutionTags.Global.Value,
                        ((ISourceGameGraphicsEnvironment)EngineContext).GameGraphics
                        .GameAtlas));
                var aim = Input.GetAimVector(Data.Facing);
                assist.Initialize((float)Math.Atan2(aim.Y, aim.X), boostSequence.DashAssistOffset);
            };
        }
    }
}
