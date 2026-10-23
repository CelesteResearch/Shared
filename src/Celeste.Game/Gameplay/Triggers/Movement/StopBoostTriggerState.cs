using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics.Extrema;
using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Game.Gameplay.Triggers.Movement
{
    public sealed class StopBoostTriggerState : SourceTriggerEntityState
    {
        public StopBoostTriggerState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset,
                data.Width, data.Height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            base.OnEnter(player);
            if (player.Machine.State == 10) player.StopSummitLaunch();
        }
    }
}
