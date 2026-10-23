using Celeste.Core.Scheduling;
using Celeste.Game.Stories.Farewell.Ending;
using Celeste.Simulation;

namespace Celeste.Everest.Stories.Farewell.Ending
{
    public sealed class EverestFarewellEndingConstructionPolicy : IOriginalFarewellEndingConstructionPolicy
    {
        public static readonly EverestFarewellEndingConstructionPolicy Instance = new();

        private EverestFarewellEndingConstructionPolicy()
        {
        }

        public OriginalFarewellEndingCutscene Create(ISourceEngineContext engine, RoomPlayerSession player)
        {
            return new EverestFarewellEndingCutscene(engine, player);
        }
    }
}
