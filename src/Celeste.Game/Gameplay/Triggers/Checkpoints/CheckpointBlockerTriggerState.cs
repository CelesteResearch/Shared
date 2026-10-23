using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Game.Gameplay.Triggers.Checkpoints
{
    public sealed class CheckpointBlockerTriggerState : SourceTriggerEntityState
    {
        public CheckpointBlockerTriggerState(EntityData data, Vector2 offset,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine)
            : base(
                ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height,
                ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
        }
    }
}
