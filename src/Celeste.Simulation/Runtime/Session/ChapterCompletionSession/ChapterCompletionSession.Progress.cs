using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Celeste.Simulation;

namespace Celeste.Simulation.Runtime.Session
{
    // The same Session identity is used by menus, gameplay and save data.
    [DataContract]
    public sealed partial class ChapterCompletionSession
    {
        [DataMember] public int AreaID, Mode;
        [DataMember] public string AreaSID;
        [DataMember] public int AreaSIDID;
        [DataMember] public global::Celeste.Simulation.Save.Progress.ChapterAreaProgress OldStats;
        [DataMember] public long Time;
        [DataMember] public int Deaths, Dashes, DashesAtLevelStart;

        [DataMember] public bool StartedFromBeginning,
            RestartedFromGolden,
            Cassette,
            HeartGem,
            GrabbedGolden,
            BeatBestTime;

        [DataMember] public bool InArea = true, FirstLevel = true, UnlockedCSide, HitCheckpoint;
        [DataMember] public string StartCheckpoint;

        [DataMember] public HashSet<global::Celeste.Core.Maps.MapEntityId> Strawberries =
            new HashSet<global::Celeste.Core.Maps.MapEntityId>();

        [DataMember] public bool[] SummitGems = new bool[6];

        public bool HasAllSummitGems
        {
            get
            {
                foreach (bool gem in SummitGems)
                    if (!gem)
                        return false;
                return true;
            }
        }

        public bool FullClear => Mode == 0 && Cassette && HeartGem &&
                                 Strawberries.Count >= DetectedStrawberries && (AreaID != 7 || HasAllSummitGems);

        public bool ShouldAdvance =>
            Mode == 0 && !OldStats.Modes[0].Completed && AreaID < sourceSessionFactory.GetMaxArea();
    }
}
