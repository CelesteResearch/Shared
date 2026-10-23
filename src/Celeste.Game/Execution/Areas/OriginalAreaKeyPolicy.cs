using System;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Execution.Areas
{
    public sealed class OriginalAreaKeyPolicy : IOriginalAreaKeyPolicy
    {
        private readonly IOriginalAreaSourceTable areas;
        public OriginalAreaKey None { get; }
        public OriginalAreaKey Default { get; }

        public OriginalAreaKeyPolicy(IOriginalAreaSourceTable actualAreas)
        {
            areas = actualAreas;
            // Original AreaKey static fields are initialized in this order.
            None = Create(-1);
            Default = Create(0);
        }

        public OriginalAreaKey Create(int id, int mode = 0)
        {
            return new() { ID = id, Mode = mode };
        }

        public OriginalAreaKey ToKey(IOriginalAreaData actualArea, int mode = 0)
        {
            return Create(actualArea.ID, mode);
        }

        public OriginalAreaKey GetSessionArea(ChapterCompletionSession session)
        {
            return new() { ID = session.AreaID, Mode = session.Mode };
        }

        public string Format(OriginalAreaKey area)
        {
            return EvaluateOriginalFormat(area);
        }

        public static string EvaluateOriginalFormat(OriginalAreaKey area)
        {
            var text = area.ID.ToString();
            if (area.Mode == 1) text = string.Concat(text, "H");
            else if (area.Mode == 2) text = string.Concat(text, "HH");
            return text;
        }

        public IOriginalAreaData GetArea(OriginalAreaKey area)
        {
            return areas.Areas[area.ID];
        }

        public IOriginalAreaData GetAreaById(int id)
        {
            return areas.Areas[id];
        }

        // Original XML has no SID member. The format boundary ignores that installed extension.
        public OriginalAreaKey SetSID(OriginalAreaKey area, string sid)
        {
            return area;
        }

        public string GetSID(OriginalAreaKey area)
        {
            return null;
        }

        public string GetLevelSet(OriginalAreaKey area)
        {
            return "Celeste";
        }

        // There is no original AreaData.Get(string); installed-only source callers must use installed policy.
        public IOriginalAreaData GetAreaBySID(string sid)
        {
            throw new NotSupportedException("The original area lookup uses numeric IDs.");
        }

        public int GetChapterIndex(OriginalAreaKey area, ISourceEngineContext engine)
        {
            if (areas.Areas[area.ID].Interlude) return -1;
            var count = 0;
            for (var i = 0; i <= area.ID; i++)
                if (!areas.Areas[i].Interlude)
                    count++;
            return count;
        }

        public string GetCheckpointName(OriginalAreaKey area, string level,
            ISourceEngineContext engine)
        {
            return CleanOriginalCheckpointName(area, level, engine);
        }

        private string CleanOriginalCheckpointName(OriginalAreaKey area, string level,
            ISourceEngineContext engine)
        {
            if (string.IsNullOrEmpty(level)) return "START";
            var checkpoints = GetArea(area).Mode[area.Mode].Checkpoints;
            if (checkpoints != null)
                foreach (var checkpoint in checkpoints)
                    if (checkpoint.Level.Equals(level))
                        return ((IOriginalGameTextEnvironment)engine).Text
                            .CleanDialog(checkpoint.Name);
            return null;
        }
    }
}
