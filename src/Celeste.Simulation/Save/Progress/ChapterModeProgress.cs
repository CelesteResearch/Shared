using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Celeste.Simulation;

namespace Celeste.Simulation.Save.Progress
{
    // Save-codec contracts, rather than Unity-serialized scene fields.
    [DataContract]
    public sealed class ChapterModeProgress
    {
        [DataMember] public int TotalStrawberries, Deaths, BestDashes, BestDeaths;
        [DataMember] public bool Completed, SingleRunCompleted, FullClear, HeartGem;
        [DataMember] public long TimePlayed, BestTime, BestFullClearTime;

        [DataMember] public HashSet<global::Celeste.Core.Maps.MapEntityId> Strawberries =
            new HashSet<global::Celeste.Core.Maps.MapEntityId>();

        [DataMember] public HashSet<string> Checkpoints = new HashSet<string>();

        public global::Celeste.Simulation.Save.Progress.ChapterModeProgress Clone()
        {
            var result = (global::Celeste.Simulation.Save.Progress.ChapterModeProgress)MemberwiseClone();
            result.Strawberries = new HashSet<global::Celeste.Core.Maps.MapEntityId>(Strawberries);
            result.Checkpoints = new HashSet<string>(Checkpoints);
            return result;
        }
    }
}
