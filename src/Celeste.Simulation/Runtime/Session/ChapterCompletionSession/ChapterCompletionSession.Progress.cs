using System.Collections.Generic;
using System.Runtime.Serialization;
using Celeste.Core.Maps;
using Celeste.Simulation.Save.Progress;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation.Runtime.Session
{
    // The same Session identity is used by menus, gameplay and save data.
    [DataContract]
    public sealed partial class ChapterCompletionSession
    {
        [DataMember] public int AreaID, Mode;
        [DataMember] public string AreaSID;
        [DataMember] public int AreaSIDID;
        [DataMember] public ChapterAreaProgress OldStats;
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

        [DataMember] public HashSet<MapEntityId> Strawberries = [];

        [DataMember] public bool[] SummitGems = new bool[6];

        public bool HasAllSummitGems
        {
            get
            {
                foreach (var gem in SummitGems)
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
