using Celeste.Core.Mathematics;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Profiles;
using Celeste.Game.Save.Runtime;
using Celeste.Simulation.Runtime.Session.Maps;

namespace Celeste.Game.Execution.Session
{
    public interface IOriginalSessionConstructionProcess : IOriginalGameplayProcess,
        IOriginalAreaKeyEnvironment, IOriginalSaveCounterEnvironment, IGameProfileEnvironment,
        IOriginalAreaStatsEnvironment, ISourceVectorEnvironment
    {
        IOriginalAreaSourceTable AreaTable { get; }
        IChapterSessionData SessionMaps { get; }
    }
}
