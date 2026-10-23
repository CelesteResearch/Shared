using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Celeste.Simulation;

namespace Celeste.Simulation.Save.Progress
{
    [DataContract]
    public class ChapterLevelSetStats
    {
        [DataMember] public string Name;
        [DataMember] public int UnlockedAreas;

        [DataMember] public List<global::Celeste.Simulation.Save.Progress.ChapterAreaProgress> Areas =
            new List<global::Celeste.Simulation.Save.Progress.ChapterAreaProgress>();

        [DataMember] public List<string> Poem = new List<string>();
        [DataMember] public int TotalStrawberries;
        [IgnoreDataMember] public int AreaOffset, AreaCount, PlayableCount;
    }
}
