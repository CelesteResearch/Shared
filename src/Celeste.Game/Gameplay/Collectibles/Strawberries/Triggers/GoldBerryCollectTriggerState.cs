using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Game.Gameplay.Collectibles.Strawberries.Triggers
{
    public sealed class GoldBerryCollectTriggerState : SourceTriggerEntityState
    {
        public GoldBerryCollectTriggerState(EntityData data, Vector2 offset,
            Celeste.Core.Scheduling.ISourceEngineContext engine)
            : base(((Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height,
                ((Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
        }
    }
}
