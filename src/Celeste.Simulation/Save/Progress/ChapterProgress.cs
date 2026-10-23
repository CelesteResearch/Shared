using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Celeste.Core.Campaigns;
using Celeste.Simulation.Progression;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.Runtime.Session.Maps;

namespace Celeste.Simulation.Save.Progress
{
    [DataContract]
    public sealed class ChapterProgress : ChapterProgressData
    {
        [IgnoreDataMember] public IChapterSessionData SessionData;
        [DataMember] public int AreaCount, LastAreaID, LastAreaMode;
        [DataMember] public string LastAreaSID;
        [DataMember] public int LastAreaSIDID;
        [IgnoreDataMember] public bool LastAreaNeedsLegacyFallback;
        [IgnoreDataMember] public CampaignCatalogEntry[] LevelSetAreas;
        [DataMember] public bool EventMode;

        [IgnoreDataMember] private IChapterProgressionPolicy progressionPolicy;

        [IgnoreDataMember]
        public IChapterProgressionPolicy ProgressionPolicy
        {
            get => progressionPolicy ??
                   throw new InvalidOperationException("A progress graph requires its progression policy.");
            set => progressionPolicy = value ?? throw new ArgumentNullException(nameof(value));
        }

        public ChapterProgress(int areaCount,
            IChapterProgressionPolicy progressionPolicy)
        {
            Areas = [];
            LevelSets = [];
            LevelSetRecycleBin = [];
            ProgressionPolicy = progressionPolicy;
            AreaCount = areaCount;
            for (var i = 0; i < areaCount; i++)
                Areas.Add(new(i));
        }

        public ChapterLevelSetStats ActiveLevelSet
        {
            get
            {
                var name = LevelSetAreas != null && LastAreaID >= 0 && LastAreaID < LevelSetAreas.Length
                    ? LevelSetAreas[LastAreaID]?.CampaignId
                    : ProgressionPolicy.DefaultCampaignId;
                return LevelSets?.Find(set => set.Name == name);
            }
        }

        public int AreaOffset => ActiveLevelSet?.AreaOffset ?? 0;

        private int LevelSetMaxArea(ChapterLevelSetStats set)
        {
            return ProgressionPolicy.CampaignMaxArea(this, set);
        }

        public int MaxArea => AreaOffset + LevelSetMaxArea(ActiveLevelSet);
        public int MaxAssistArea => ProgressionPolicy.MaxAssistArea(this);

        public int MaxAreaFor(int areaID)
        {
            var set = LevelSetAreas != null && areaID >= 0 && areaID < LevelSetAreas.Length
                ? LevelSets?.Find(value => value.Name == LevelSetAreas[areaID]?.CampaignId)
                : null;
            return (set?.AreaOffset ?? 0) + LevelSetMaxArea(set);
        }

        public int UnlockedAreasSafe
        {
            get => ProgressionPolicy.GetUnlockedAreas(this, ActiveLevelSet);
            set => ProgressionPolicy.SetUnlockedAreas(this, ActiveLevelSet, value);
        }

        public void ConfigureLevelSets(IReadOnlyList<CampaignCatalogEntry> areas)
        {
            if (areas == null) throw new ArgumentNullException(nameof(areas));
            var oldMetadata = LevelSetAreas;
            var lastSid = LastAreaID == LastAreaSIDID && !string.IsNullOrEmpty(LastAreaSID)
                ? LastAreaSID
                : oldMetadata != null && LastAreaID >= 0 && LastAreaID < oldMetadata.Length
                    ? oldMetadata[LastAreaID]?.SID
                    : LastAreaSID;
            var sessionSid = CurrentSession == null
                ? null
                : CurrentSession.AreaID == CurrentSession.AreaSIDID && !string.IsNullOrEmpty(CurrentSession.AreaSID)
                    ? CurrentSession.AreaSID
                    : oldMetadata != null && CurrentSession.AreaID >= 0 && CurrentSession.AreaID < oldMetadata.Length
                        ? oldMetadata[CurrentSession.AreaID]?.SID
                        : CurrentSession.AreaSID;
            var previousAreas = Areas.ToArray();
            LevelSetAreas = new CampaignCatalogEntry[areas.Count];
            var bySid =
                new Dictionary<string, CampaignCatalogEntry>(StringComparer.Ordinal);
            foreach (var area in areas)
            {
                if (area.ID >= 0 && area.ID < areas.Count) LevelSetAreas[area.ID] = area;
                if (!string.IsNullOrEmpty(area.SID)) bySid[area.SID] = area;
            }

            LevelSets ??= [];
            LevelSetRecycleBin ??= [];
            // Remove the runtime child aliases before rebuilding the metadata projection.
            // SaveData.BeforeSave does the same for its persisted root-only lists.
            if (oldMetadata != null)
                foreach (var set in LevelSets)
                    if (set.Areas != null && set.Areas.Count > set.PlayableCount)
                        set.Areas.RemoveRange(set.PlayableCount, set.Areas.Count - set.PlayableCount);
            foreach (var area in areas)
            {
                var name = area.CampaignId ?? ProgressionPolicy.DefaultCampaignId;
                if (LevelSets.Exists(set => set.Name == name)) continue;
                var restored = LevelSetRecycleBin.Find(set => set.Name == name);
                if (restored != null)
                {
                    LevelSetRecycleBin.Remove(restored);
                    LevelSets.Add(restored);
                }
                else
                {
                    LevelSets.Add(new()
                        { Name = name, UnlockedAreas = ProgressionPolicy.InitialUnlockedAreas(this, name) });
                }
            }

            for (var index = 0; index < LevelSets.Count; index++)
            {
                var set = LevelSets[index];
                var members = areas.Where(area => (area.CampaignId ?? ProgressionPolicy.DefaultCampaignId) == set.Name)
                    .ToArray();
                set.Areas ??= [];
                // On first binding the canonical vanilla list is the top-level Areas list.
                // New in-memory progress also starts with this flat list, before any set owns it.
                if (oldMetadata == null && set.Areas.Count == 0)
                    foreach (var stats in previousAreas)
                    {
                        CampaignCatalogEntry match = null;
                        if (!string.IsNullOrEmpty(stats.SID)) bySid.TryGetValue(stats.SID, out match);
                        else if (stats.ID >= 0 && stats.ID < LevelSetAreas.Length) match = LevelSetAreas[stats.ID];
                        if (match != null && (match.CampaignId ?? ProgressionPolicy.DefaultCampaignId) == set.Name)
                            set.Areas.Add(stats);
                    }

                if (members.Length == 0)
                {
                    set.AreaOffset = -1;
                    set.AreaCount = set.PlayableCount = 0;
                    var stale = LevelSetRecycleBin.Find(other => other.Name == set.Name);
                    if (stale != null) LevelSetRecycleBin.Remove(stale);
                    LevelSetRecycleBin.Add(set);
                    LevelSets.RemoveAt(index--);
                    continue;
                }

                set.AreaOffset = members.Min(area => area.ID);
                set.AreaCount = members.Length;
                set.PlayableCount = members.Count(area => string.IsNullOrEmpty(area.ParentSID));
                foreach (var stats in set.Areas)
                {
                    CampaignCatalogEntry match = null;
                    if (!string.IsNullOrEmpty(stats.SID)) bySid.TryGetValue(stats.SID, out match);
                    else if (stats.ID >= 0 && stats.ID < LevelSetAreas.Length) match = LevelSetAreas[stats.ID];
                    stats.ID = match != null && string.IsNullOrEmpty(match.ParentSID) ? match.ID : int.MaxValue;
                }

                set.Areas.Sort((left, right) => left.ID - right.ID);
                while (set.Areas.Count != 0 && set.Areas[set.Areas.Count - 1].ID == int.MaxValue)
                    set.Areas.RemoveAt(set.Areas.Count - 1);
                for (var local = 0; local < set.PlayableCount; local++)
                {
                    var id = set.AreaOffset + local;
                    if (local >= set.Areas.Count || set.Areas[local].ID != id)
                        set.Areas.Insert(local, new(id));
                }

                for (var local = set.PlayableCount; local < set.AreaCount; local++)
                    if (local >= set.Areas.Count)
                    {
                        var child = LevelSetAreas[set.AreaOffset + local];
                        var parent = bySid[child.ParentSID];
                        set.Areas.Insert(local, set.Areas[parent.ID - set.AreaOffset]);
                    }

                foreach (var stats in set.Areas) stats.SID = LevelSetAreas[stats.ID].SID;
            }

            LevelSets.Sort((left, right) => left.AreaOffset.CompareTo(right.AreaOffset));
            Areas.Clear();
            foreach (var set in LevelSets) Areas.AddRange(set.Areas);
            AreaCount = areas.Count;
            CampaignCatalogEntry last = null;
            if (!string.IsNullOrEmpty(lastSid)) bySid.TryGetValue(lastSid, out last);
            else if (LastAreaID >= 0 && LastAreaID < LevelSetAreas.Length) last = LevelSetAreas[LastAreaID];
            LastAreaNeedsLegacyFallback = (last?.ID ?? LastAreaID) == 0;
            if (last == null)
            {
                LastAreaID = 0;
                LastAreaMode = 0;
                LastAreaSID = LevelSetAreas.Length == 0 ? null : LevelSetAreas[0]?.SID;
            }
            else
            {
                LastAreaID = last.ID;
                LastAreaSID = last.SID;
            }

            LastAreaSIDID = LastAreaID;
            if (CurrentSession != null)
            {
                CampaignCatalogEntry current = null;
                if (!string.IsNullOrEmpty(sessionSid)) bySid.TryGetValue(sessionSid, out current);
                else if (CurrentSession.AreaID >= 0 && CurrentSession.AreaID < LevelSetAreas.Length)
                    current = LevelSetAreas[CurrentSession.AreaID];
                // AreaKey.SID retains its raw ID when the referenced map is absent.
                CurrentSession.AreaID = current?.ID ?? CurrentSession.AreaID;
                CurrentSession.AreaSID = current?.SID ?? sessionSid;
                CurrentSession.AreaSIDID = CurrentSession.AreaID;
                var oldStats = CurrentSession.OldStats;
                if (oldStats != null && !string.IsNullOrEmpty(oldStats.SID) &&
                    bySid.TryGetValue(oldStats.SID, out var oldArea))
                    oldStats.ID = oldArea.ID;
            }
        }

        public int TotalHeartGems
        {
            get
            {
                var n = 0;
                // Everest sums the active runtime list, including parent aliases.
                // Do not deduplicate: child references are observable in its result.
                foreach (var area in ActiveLevelSet?.Areas ?? Areas)
                foreach (var mode in area.Modes)
                    if (mode != null && mode.HeartGem)
                        n++;
                return n;
            }
        }

        public int UnlockedModes => ProgressionPolicy.UnlockedModes(this);

        public int GetUnlockedModesFor(ChapterLevelSetStats set)
        {
            return ProgressionPolicy.UnlockedModesFor(this, set);
        }

        public bool SetCheckpoint(int areaID, int mode, string level)
        {
            return Areas[areaID].Modes[mode].Checkpoints.Add(level);
        }

        public bool HasCheckpoint(int areaID, int mode, string level)
        {
            return Areas[areaID].Modes[mode].Checkpoints.Contains(level);
        }

        public void AddTime(int areaID, int mode, long time)
        {
            Time += time;
            Areas[areaID].Modes[mode].TimePlayed += time;
        }

        public void RegisterCompletion(ChapterCompletionSession session)
        {
            var stats = Areas[session.AreaID].Modes[session.Mode];
            if (session.GrabbedGolden) stats.BestDeaths = 0;
            if (session.StartedFromBeginning)
            {
                stats.SingleRunCompleted = true;
                if (stats.BestTime <= 0 || session.Deaths < stats.BestDeaths) stats.BestDeaths = session.Deaths;
                if (stats.BestTime <= 0 || session.Dashes < stats.BestDashes) stats.BestDashes = session.Dashes;
                if (stats.BestTime <= 0 || session.Time < stats.BestTime)
                {
                    if (stats.BestTime > 0) session.BeatBestTime = true;
                    stats.BestTime = session.Time;
                }

                if (session.Mode == 0 && session.FullClear)
                {
                    stats.FullClear = true;
                    if (session.StartedFromBeginning &&
                        (stats.BestFullClearTime <= 0 || session.Time < stats.BestFullClearTime))
                        stats.BestFullClearTime = session.Time;
                }
            }

            ProgressionPolicy.RegisterCompletionUnlock(this, session);

            stats.Completed = true;
            session.InArea = false;
        }
    }
}
