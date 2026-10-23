using System.Runtime.Serialization;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Runtime;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Game.Save.Data
{
    [DataContract]
    public sealed partial class OriginalSaveDataState : ChapterProgressData
    {
        private readonly IOriginalSaveCounterQueries counterQueries;
        [DataMember] public string Name;
        [DataMember] public int TotalDeaths, TotalStrawberries, TotalGoldenStrawberries;
        [DataMember] public OriginalAreaKey LastArea;

        public OriginalSaveDataState(IOriginalSaveCounterQueries counterQueries)
        {
            this.counterQueries = counterQueries;
        }

        public int TotalHeartGems => counterQueries.TotalHeartGems(this);
    }
}
