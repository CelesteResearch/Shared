using Celeste.Game.Save.Data;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Save.Runtime
{
    public static class OriginalSaveCompletionSource
    {
        public static void RegisterCompletion(OriginalSaveDataState save, ChapterCompletionSession session,
            IOriginalSaveCounterQueries counters, IOriginalSaveProgressionPolicy progression)
        {
            var areaID = session.AreaID;
            int mode = session.Mode;
            var areaModeStats = counters.GetAreasSafe(save)[areaID].Modes[mode];
            if (session.GrabbedGolden)
            {
                areaModeStats.BestDeaths = 0;
            }

            if (session.StartedFromBeginning)
            {
                areaModeStats.SingleRunCompleted = true;
                if (areaModeStats.BestTime <= 0 || session.Deaths < areaModeStats.BestDeaths)
                {
                    areaModeStats.BestDeaths = session.Deaths;
                }

                if (areaModeStats.BestTime <= 0 || session.Dashes < areaModeStats.BestDashes)
                {
                    areaModeStats.BestDashes = session.Dashes;
                }

                if (areaModeStats.BestTime <= 0 || session.Time < areaModeStats.BestTime)
                {
                    if (areaModeStats.BestTime > 0)
                    {
                        session.BeatBestTime = true;
                    }

                    areaModeStats.BestTime = session.Time;
                }

                if (mode == 0 && session.FullClear)
                {
                    areaModeStats.FullClear = true;
                    if (session.StartedFromBeginning && (areaModeStats.BestFullClearTime <= 0 ||
                                                         session.Time < areaModeStats.BestFullClearTime))
                    {
                        areaModeStats.BestFullClearTime = session.Time;
                    }
                }
            }

            if (unchecked(areaID + 1) > progression.GetUnlockedAreasSafe(save) && areaID < progression.GetMaxArea(save))
            {
                progression.SetUnlockedAreasSafe(save, unchecked(areaID + 1));
            }

            areaModeStats.Completed = true;
            session.InArea = false;
        }
    }
}
