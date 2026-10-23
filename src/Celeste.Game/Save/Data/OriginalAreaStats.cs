using System;
using System.Collections.Generic;
using Celeste.Formats.Save.Xml;
using Celeste.Game.Execution.Areas;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Game.Save.Data
{
// The original data and runtime state are the same object; inherited fields are authoritative.
    public class OriginalAreaStats : ChapterAreaProgress
    {
        // Source XML allocation does not resolve an Area ID.
        public OriginalAreaStats()
        {
            InitializeModes();
        }

        // Original source AreaStats(int) assigns ID before allocating the mode array.
        public OriginalAreaStats(int id)
        {
            ID = id;
            InitializeModes();
        }

        // Installed source AreaStats(int) uses ID_Safe before allocating the mode array.
        public OriginalAreaStats(int id, IReadOnlyList<IOriginalAreaData> actualAreas)
        {
            ID = id;
            SID = ID == -1 ? null : actualAreas[ID].SID;
            InitializeModes();
        }

        private void InitializeModes()
        {
            var length = Enum.GetValues(typeof(AreaMode)).Length;
            Modes = new ChapterModeProgress[length];
            for (var i = 0; i < Modes.Length; i++) Modes[i] = new();
        }
    }
}
