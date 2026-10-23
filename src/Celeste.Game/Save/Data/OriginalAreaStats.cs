using System.Collections.Generic;
using Celeste.Game.Execution.Areas;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Game.Save.Data
{
// The original data and runtime state are the same object; inherited fields are authoritative.
    public class OriginalAreaStats : ChapterAreaProgress
    {
        // Source XML allocation does not resolve an Area ID.
        public OriginalAreaStats() : base() => InitializeModes();

        // Original source AreaStats(int) assigns ID before allocating the mode array.
        public OriginalAreaStats(int id) : base()
        {
            ID = id;
            InitializeModes();
        }

        // Installed source AreaStats(int) uses ID_Safe before allocating the mode array.
        public OriginalAreaStats(int id, IReadOnlyList<IOriginalAreaData> actualAreas) : base()
        {
            ID = id;
            SID = ID == -1 ? null : actualAreas[ID].SID;
            InitializeModes();
        }

        private void InitializeModes()
        {
            int length = System.Enum.GetValues(typeof(global::Celeste.Formats.Save.Xml.AreaMode)).Length;
            Modes = new ChapterModeProgress[length];
            for (int i = 0; i < Modes.Length; i++) Modes[i] = new ChapterModeProgress();
        }
    }
}
