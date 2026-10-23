using Celeste.Everest.Diagnostics.Logging;
using System;
using System.Collections.Generic;
using Celeste.Game.Execution.Areas;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Content.Maps.Registry
{
    public sealed class EverestAreaKeyPolicy : IOriginalAreaKeyPolicy
    {
        private readonly IOriginalAreaSourceTable registry;
        private readonly ISourceAreaReloadLockEnvironment areaLocks;
        private readonly IEverestLoggerProcessEnvironment diagnostics;
        private readonly Dictionary<string, string> cachedSidsToLevelSets = new();
        public OriginalAreaKey None { get; }
        public OriginalAreaKey Default { get; }

        public EverestAreaKeyPolicy(IOriginalAreaSourceTable registry,
            ISourceAreaReloadLockEnvironment areaLocks, IEverestLoggerProcessEnvironment diagnostics)
        {
            this.registry = registry;
            this.areaLocks = areaLocks;
            this.diagnostics = diagnostics;
            // The source cctor creates the SID cache first, then None and Default via patched ctor.
            None = Create(-1);
            Default = Create(0);
        }

        public OriginalAreaKey ToKey(IOriginalAreaData actualArea, int mode = 0)
        {
            OriginalAreaKey key = Create(actualArea.ID, mode);
            return SetSID(key, actualArea.SID);
        }

        public OriginalAreaKey Create(int id, int mode = 0)
        {
            var result = new OriginalAreaKey { Mode = mode, ID = id, SIDID = id, SID = null };
            if (id != -1 && registry.Areas != null && registry.Areas.Count > 0)
            {
                string sid = registry.Areas[id].SID;
                if (sid != null) result = SetSID(result, sid);
            }

            return result;
        }

        public OriginalAreaKey SetSID(OriginalAreaKey area, string sid)
        {
            area.SID = sid;
            area.ID = GetAreaBySID(sid)?.ID ?? area.ID;
            area.SIDID = area.ID;
            return area;
        }

        public OriginalAreaKey GetSessionArea(ChapterCompletionSession session)
            => new OriginalAreaKey
            {
                ID = session.AreaID, Mode = session.Mode,
                SID = session.AreaSID, SIDID = session.AreaSIDID
            };

        public string Format(OriginalAreaKey area)
        {
            string text = OriginalAreaKeyPolicy.EvaluateOriginalFormat(area);
            if (area.ID < 11) return text;
            string sid = GetSID(area);
            if (sid != null) text = string.Concat(text, " (SID: ", sid, ")");
            return text;
        }

        public string GetSID(OriginalAreaKey area)
        {
            string sid = area.SID;
            if ((area.SIDID != area.ID || string.IsNullOrEmpty(sid))
                && 0 <= area.ID && area.ID < registry.Areas.Count)
                sid = registry.Areas[area.ID].SID;
            return sid;
        }

        public string GetLevelSet(OriginalAreaKey area)
        {
            string sid = GetSID(area);
            if (string.IsNullOrEmpty(sid)) return "Celeste";
            if (!cachedSidsToLevelSets.TryGetValue(sid, out string levelSet))
            {
                diagnostics.Logger.Log(EverestLogLevel.Verbose, "SaveData", "Recomputing AreaKey.LevelSet");
                // Source computeLevelSet performs a second get_SID at this point.
                string current = GetSID(area);
                int separator = current.LastIndexOf('/');
                levelSet = separator == -1 ? "" : current.Substring(0, separator);
                cachedSidsToLevelSets.Add(sid, levelSet);
            }

            return levelSet;
        }

        public IOriginalAreaData GetArea(OriginalAreaKey area)
            => GetSID(area) == null ? GetAreaById(area.ID) : GetAreaBySID(GetSID(area));

        public IOriginalAreaData GetAreaBySID(string sid)
        {
            lock (areaLocks.AreaReloadLock)
            {
                if (string.IsNullOrEmpty(sid)) return null;
                return ((List<OriginalAreaData>)registry.Areas).Find(area => ((IOriginalAreaData)area).SID == sid);
            }
        }

        public IOriginalAreaData GetAreaById(int id)
        {
            if (id < 0) return null;
            lock (areaLocks.AreaReloadLock) return registry.Areas[id];
        }

        public int GetChapterIndex(OriginalAreaKey area, global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            if (area.ID == -1 || EverestAreaSafeQueries.GetInterlude(engine, registry.Areas[area.ID])) return -1;
            string levelSet = GetLevelSet(area);
            int count = 0;
            for (int i = 0; i <= area.ID; i++)
                if (!(registry.Areas[i].LevelSet != levelSet) &&
                    !EverestAreaSafeQueries.GetInterlude(engine, registry.Areas[i]))
                    count++;
            return count;
        }

        public string GetCheckpointName(OriginalAreaKey area, string level,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine)
        {
            int separator = level?.IndexOf('|') ?? -1;
            if (separator >= 0)
            {
                var other = GetAreaBySID(level.Substring(0, separator));
                area = other != null ? ToKey(other, area.Mode) : area;
                level = level.Substring(separator + 1);
            }

            return CleanOriginalCheckpointName(area, level, engine);
        }

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
