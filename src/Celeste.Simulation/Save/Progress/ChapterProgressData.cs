using System.Collections.Generic;
using System.Runtime.Serialization;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Simulation.Save.Progress
{
    [DataContract]
    public abstract class ChapterProgressData
    {
        [DataMember] public List<ChapterAreaProgress> Areas;
        [DataMember] public int UnlockedAreas;
        [DataMember] public List<ChapterLevelSetStats> LevelSets;
        [DataMember] public List<ChapterLevelSetStats> LevelSetRecycleBin;
        [DataMember] public long Time;
        [DataMember] public bool DebugMode, CheatMode, AssistMode, VariantMode;
        [DataMember] public bool RevealedChapter9;
        [DataMember] public ChapterCompletionSession CurrentSession;
    }
}
