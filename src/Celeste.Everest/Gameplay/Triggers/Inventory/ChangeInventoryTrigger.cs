using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Entities.Metadata;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Inventory;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Everest.Gameplay.Triggers.Inventory
{
    [CustomEntity("everest/changeInventoryTrigger")]
    public class ChangeInventoryTrigger : SourceTriggerEntityState
    {
        private readonly RoomPlayerInventory inventory;

        public ChangeInventoryTrigger(ISourceEngineContext engine, OriginalLevelEntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            inventory = (RoomPlayerInventory)typeof(RoomPlayerInventory)
                .GetField(EntityAttributeReader.Attr(data.Values, "inventory", "Default")).GetValue(null);
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            ((OriginalLevelSceneRoot)Scene).Session.Inventory = inventory;
        }
    }
}
