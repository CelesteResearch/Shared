using Celeste.Game.Save.Data;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public int GetAreaStatsId(ChapterAreaProgress actualArea) => actualArea.ID;

        public ChapterAreaProgress CreateAreaStats(int id) => new OriginalAreaStats(id);

        public ChapterAreaProgress CloneAreaStats(ChapterAreaProgress actualArea)
        {
            var copy = new OriginalAreaStats { ID = actualArea.ID, Cassette = actualArea.Cassette };
            for (int i = 0; i < actualArea.Modes.Length; i++) copy.Modes[i] = actualArea.Modes[i].Clone();
            return copy;
        }
    }
}
