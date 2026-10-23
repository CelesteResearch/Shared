using Celeste.Core.Scheduling;
using Celeste.Simulation;
using Celeste.Game.Stories.Farewell.Ending;

namespace Celeste.Everest.Stories.Farewell.Ending
{
    public sealed class EverestFarewellEndingConstructionPolicy : IOriginalFarewellEndingConstructionPolicy
    {
        public static readonly EverestFarewellEndingConstructionPolicy Instance = new();

        private EverestFarewellEndingConstructionPolicy()
        {
        }

        public OriginalFarewellEndingCutscene Create(ISourceEngineContext engine, RoomPlayerSession player) =>
            new EverestFarewellEndingCutscene(engine, player);
    }
}
