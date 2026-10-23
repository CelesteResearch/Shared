using Celeste.Game.Save.Data;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public ChapterAreaProgress CreateAreaStats(int id)
        {
            return new OriginalAreaStats(id, registry.Areas);
        }

        public ChapterAreaProgress CloneAreaStats(ChapterAreaProgress actualArea)
        {
            var copy = new OriginalAreaStats();
            // Installed Clone allocates the default modes before source ID_Safe getter/setter.
            copy.ID = GetAreaStatsId(actualArea);
            copy.SID = copy.ID == -1 ? null : registry.Areas[copy.ID].SID;
            copy.Cassette = actualArea.Cassette;
            for (var i = 0; i < actualArea.Modes.Length; i++) copy.Modes[i] = actualArea.Modes[i].Clone();
            return copy;
        }
    }
}
