using System.Collections.Generic;
using System.Runtime.Serialization;
using Celeste.Core.Maps;

namespace Celeste.Simulation.Save.Progress
{
    // Save-codec contracts, rather than Unity-serialized scene fields.
    [DataContract]
    public sealed class ChapterModeProgress
    {
        [DataMember] public int TotalStrawberries, Deaths, BestDashes, BestDeaths;
        [DataMember] public bool Completed, SingleRunCompleted, FullClear, HeartGem;
        [DataMember] public long TimePlayed, BestTime, BestFullClearTime;

        [DataMember] public HashSet<MapEntityId> Strawberries = [];

        [DataMember] public HashSet<string> Checkpoints = [];

        public ChapterModeProgress Clone()
        {
            var result = (ChapterModeProgress)MemberwiseClone();
            result.Strawberries = /* ReSharper disable once UseCollectionExpression */ new(Strawberries);
            result.Checkpoints = /* ReSharper disable once UseCollectionExpression */ new(Checkpoints);
            return result;
        }
    }
}
