using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Game.Gameplay.Triggers.Inventory
{
    public sealed class NoRefillTriggerState : SourceTriggerEntityState
    {
        public bool State;

        public NoRefillTriggerState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset,
                data.Width, data.Height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            State = EntityAttributeReader.Bool(data.Values, "state");
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            base.OnEnter(player);
            ((OriginalLevelSceneRoot)Scene).Session.Inventory.NoRefills = State;
        }
    }
}
