using Celeste.Core.Scheduling;
using Celeste.Simulation;

namespace Celeste.Game.Stories.Farewell.Ending
{
    public sealed class OriginalFarewellEndingConstructionPolicy : IOriginalFarewellEndingConstructionPolicy
    {
        public static readonly OriginalFarewellEndingConstructionPolicy Instance = new();

        private OriginalFarewellEndingConstructionPolicy()
        {
        }

        public OriginalFarewellEndingCutscene Create(ISourceEngineContext engine, RoomPlayerSession player)
        {
            return new(engine, player);
        }
    }
}
