using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Celeste.Simulation.Save.Progress
{
    [DataContract]
    public class ChapterAreaProgress
    {
        [DataMember] public int ID;
        [DataMember] public string SID;
        [DataMember] public bool Cassette;
        [DataMember] public ChapterModeProgress[] Modes;

        protected ChapterAreaProgress()
        {
        }

        public ChapterAreaProgress(int id)
        {
            ID = id;
            Modes =
            [
                new(),
                new(),
                new(),
            ];
        }

        public int TotalStrawberries
        {
            get
            {
                var n = 0;
                foreach (var m in Modes) n += m.TotalStrawberries;
                return n;
            }
        }

        public int TotalDeaths
        {
            get
            {
                var n = 0;
                foreach (var m in Modes) n += m.Deaths;
                return n;
            }
        }

        public long TotalTimePlayed
        {
            get
            {
                long n = 0;
                foreach (var m in Modes) n += m.TimePlayed;
                return n;
            }
        }

        public int BestTotalDeaths
        {
            get
            {
                var n = 0;
                foreach (var m in Modes) n += m.BestDeaths;
                return n;
            }
        }

        public int BestTotalDashes
        {
            get
            {
                var n = 0;
                foreach (var m in Modes) n += m.BestDashes;
                return n;
            }
        }

        public long BestTotalTime
        {
            get
            {
                long n = 0;
                foreach (var m in Modes) n += m.BestTime;
                return n;
            }
        }

        public ChapterAreaProgress Clone()
        {
            var result = new ChapterAreaProgress(ID)
                { Cassette = Cassette, SID = SID };
            for (var i = 0; i < Modes.Length; i++) result.Modes[i] = Modes[i].Clone();
            return result;
        }

        // Null represents an absent ModeProperties or Checkpoints array; an
        // omitted mode in the outer array is left untouched, as in AreaStats.
        public void CleanCheckpoints(IReadOnlyList<IReadOnlyList<string>> modes)
        {
            for (var mode = 0; mode < 3; mode++)
            {
                if (modes.Count <= mode) continue;
                var old = new HashSet<string>(Modes[mode].Checkpoints);
                Modes[mode].Checkpoints.Clear();
                if (modes[mode] == null) continue;
                foreach (var level in modes[mode])
                    if (old.Contains(level))
                        Modes[mode].Checkpoints.Add(level);
            }
        }
    }
}
