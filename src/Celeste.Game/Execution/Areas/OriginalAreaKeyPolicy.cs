using System;
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
            => new OriginalAreaKey { ID = id, Mode = mode };

        public OriginalAreaKey ToKey(IOriginalAreaData actualArea, int mode = 0)
            => Create(actualArea.ID, mode);

        public OriginalAreaKey GetSessionArea(ChapterCompletionSession session)
            => new OriginalAreaKey { ID = session.AreaID, Mode = session.Mode };

        public string Format(OriginalAreaKey area) => EvaluateOriginalFormat(area);

        public static string EvaluateOriginalFormat(OriginalAreaKey area)
        {
            string text = area.ID.ToString();
            if (area.Mode == 1) text = string.Concat(text, "H");
            else if (area.Mode == 2) text = string.Concat(text, "HH");
            return text;
        }

        public IOriginalAreaData GetArea(OriginalAreaKey area) => areas.Areas[area.ID];
        public IOriginalAreaData GetAreaById(int id) => areas.Areas[id];

        // Original XML has no SID member. The format boundary ignores that installed extension.
        public OriginalAreaKey SetSID(OriginalAreaKey area, string sid) => area;
        public string GetSID(OriginalAreaKey area) => null;
        public string GetLevelSet(OriginalAreaKey area) => "Celeste";

        // There is no original AreaData.Get(string); installed-only source callers must use installed policy.
        public IOriginalAreaData GetAreaBySID(string sid)
            => throw new NotSupportedException("The original area lookup uses numeric IDs.");

        public int GetChapterIndex(OriginalAreaKey area, global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            if (areas.Areas[area.ID].Interlude) return -1;
            int count = 0;
            for (int i = 0; i <= area.ID; i++)
                if (!areas.Areas[i].Interlude)
                    count++;
            return count;
        }

        public string GetCheckpointName(OriginalAreaKey area, string level,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine)
            => CleanOriginalCheckpointName(area, level, engine);

        private string CleanOriginalCheckpointName(OriginalAreaKey area, string level,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            if (string.IsNullOrEmpty(level)) return "START";
            var checkpoints = GetArea(area).Mode[area.Mode].Checkpoints;
            if (checkpoints != null)
                foreach (var checkpoint in checkpoints)
                    if (checkpoint.Level.Equals(level))
                        return ((global::Celeste.Game.Content.Dialogs.IOriginalGameTextEnvironment)engine).Text
                            .CleanDialog(checkpoint.Name);
            return null;
        }
    }
}
