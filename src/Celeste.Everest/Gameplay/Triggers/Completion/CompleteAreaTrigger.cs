using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Entities.Metadata;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Everest.Gameplay.Triggers.Completion
{
    [CustomEntity("everest/completeAreaTrigger", "outback/completeareatrigger")]
    public class CompleteAreaTrigger : SourceTriggerEntityState
    {
        public CompleteAreaTrigger(ISourceEngineContext engine, OriginalLevelEntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            base.OnEnter(player);
            ((OriginalLevelSceneRoot)Scene).CompleteArea();
            player.Machine.State = 11;
            RemoveSelf();
        }
    }
}
