using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Celeste.Simulation;

namespace Celeste.Simulation.Save.Progress
{
    [DataContract]
    public class ChapterAreaProgress
    {
        [DataMember] public int ID;
        [DataMember] public string SID;
        [DataMember] public bool Cassette;
        [DataMember] public global::Celeste.Simulation.Save.Progress.ChapterModeProgress[] Modes;

        protected ChapterAreaProgress()
        {
        }

        public ChapterAreaProgress(int id)
        {
            ID = id;
            Modes = new[]
            {
                new global::Celeste.Simulation.Save.Progress.ChapterModeProgress(),
                new global::Celeste.Simulation.Save.Progress.ChapterModeProgress(),
                new global::Celeste.Simulation.Save.Progress.ChapterModeProgress()
            };
        }

        public int TotalStrawberries
        {
            get
            {
                int n = 0;
                foreach (var m in Modes) n += m.TotalStrawberries;
                return n;
            }
        }

        public int TotalDeaths
        {
            get
            {
                int n = 0;
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
                int n = 0;
                foreach (var m in Modes) n += m.BestDeaths;
                return n;
            }
        }

        public int BestTotalDashes
        {
            get
            {
                int n = 0;
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

        public global::Celeste.Simulation.Save.Progress.ChapterAreaProgress Clone()
        {
            var result = new global::Celeste.Simulation.Save.Progress.ChapterAreaProgress(ID)
                { Cassette = Cassette, SID = SID };
            for (int i = 0; i < Modes.Length; i++) result.Modes[i] = Modes[i].Clone();
            return result;
        }

        // Null represents an absent ModeProperties or Checkpoints array; an
        // omitted mode in the outer array is left untouched, as in AreaStats.
        public void CleanCheckpoints(IReadOnlyList<IReadOnlyList<string>> modes)
        {
            for (int mode = 0; mode < 3; mode++)
            {
                if (modes.Count <= mode) continue;
                var old = new HashSet<string>(Modes[mode].Checkpoints);
                Modes[mode].Checkpoints.Clear();
                if (modes[mode] == null) continue;
                foreach (string level in modes[mode])
                    if (old.Contains(level))
                        Modes[mode].Checkpoints.Add(level);
            }
        }
    }
}
