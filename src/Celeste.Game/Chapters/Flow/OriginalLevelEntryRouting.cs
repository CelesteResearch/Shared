using Celeste.Core.Scheduling;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Presentation.Environment;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Chapters.Flow
{
    public static class OriginalLevelEntryRouting
    {
        public static void Go(ChapterCompletionSession session, bool fromSaveData,
            SourceEngineSceneState scenes, ILevelEntrySceneFactory sourceScenes)
        {
            if (sourceScenes is OriginalLevelEntrySceneFactory originalFactory)
                originalFactory.RequirePreparedEntry(session);
            HiresSnowState snow = null;
            if (scenes.CurrentScene is OverworldSequence overworld)
                snow = overworld.Snow;
            var start = !fromSaveData && session.StartedFromBeginning;
            if (start && session.AreaID == 0)
                scenes.NextScene = sourceScenes.CreateIntroVignette(session, snow);
            else if (start && session.AreaID == 7 && session.Mode == 0)
                scenes.NextScene = sourceScenes.CreateSummitVignette(session);
            else if (start && session.AreaID == 9 && session.Mode == 0)
                scenes.NextScene = sourceScenes.CreateCoreVignette(session, snow);
            else
                scenes.NextScene = sourceScenes.CreateLevelEnter(session, fromSaveData);
        }
    }
}
