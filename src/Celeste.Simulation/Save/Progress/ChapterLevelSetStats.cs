using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Celeste.Simulation.Save.Progress
{
    [DataContract]
    public class ChapterLevelSetStats
    {
        [DataMember] public string Name;
        [DataMember] public int UnlockedAreas;

        [DataMember] public List<ChapterAreaProgress> Areas = [];

        [DataMember] public List<string> Poem = [];
        [DataMember] public int TotalStrawberries;
        [IgnoreDataMember] public int AreaOffset, AreaCount, PlayableCount;
    }
}
