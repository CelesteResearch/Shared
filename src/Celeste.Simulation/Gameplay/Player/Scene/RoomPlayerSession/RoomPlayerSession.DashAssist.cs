using System;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public bool DashAssistFreeze => engineContext.Effects.DashAssistFreeze;
        public bool DashAssistFreezePress => engineContext.Effects.DashAssistFreezePress;

        private void BindDashAssistEvents()
        {
            World.Emitted += value =>
            {
                if (value.Kind != global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Dash ||
                    value.Name != "AssistInit") return;
                engineContext.Effects.DashAssistFreeze = true;
                engineContext.Effects.DashAssistFreezePress = false;
                var scene = (IPlayerDashAssistScene)Scene;
                var entities = scene.Scheduler.Entities.GetTrackedEntities(typeof(PlayerDashAssistPresentation));
                PlayerDashAssistPresentation assist =
                    entities.Count == 0 ? null : (PlayerDashAssistPresentation)entities[0];
                if (assist == null)
                    scene.AddDashAssist(assist = new PlayerDashAssistPresentation(engineContext,
                        ((global::Celeste.Scene.Scheduling.ExecutionTags.ISourceGlobalFrozenExecutionTagsEnvironment)
                            engineContext).GlobalFrozenExecutionTags.Global.Value,
                        ((global::Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)engineContext).GameGraphics
                        .GameAtlas));
                var aim = Input.GetAimVector(Data.Facing);
                assist.Initialize((float)Math.Atan2(aim.Y, aim.X), boostSequence.DashAssistOffset);
            };
        }
    }
}
