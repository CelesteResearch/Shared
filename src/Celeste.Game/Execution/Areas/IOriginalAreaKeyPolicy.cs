using Celeste.Core.Scheduling;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Execution.Areas
{
    public interface IOriginalAreaKeyPolicy
    {
        OriginalAreaKey Default { get; }
        OriginalAreaKey Create(int id, int mode = 0);
        OriginalAreaKey ToKey(IOriginalAreaData actualArea, int mode = 0);
        OriginalAreaKey SetSID(OriginalAreaKey area, string sid);
        OriginalAreaKey GetSessionArea(ChapterCompletionSession session);
        string GetSID(OriginalAreaKey area);
        string Format(OriginalAreaKey area);
        int GetChapterIndex(OriginalAreaKey area, ISourceEngineContext engine);

        string GetCheckpointName(OriginalAreaKey area, string level,
            ISourceEngineContext engine);

        string GetLevelSet(OriginalAreaKey area);
        IOriginalAreaData GetArea(OriginalAreaKey area);
        IOriginalAreaData GetAreaById(int id);
        IOriginalAreaData GetAreaBySID(string sid);
    }
}
