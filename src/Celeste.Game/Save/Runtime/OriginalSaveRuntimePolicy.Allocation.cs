using System.Collections.Generic;
using Celeste.Game.Save.Data;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public OriginalSaveDataState CreateSave()
        {
            var save = new OriginalSaveDataState(this);
            save.Name = "Madeline";
            save.Assists = FileAssists.Default;
            save.Flags = new HashSet<string>();
            save.Poem = new List<string>();
            save.Areas = new List<ChapterAreaProgress>();
            return save;
        }
    }
}
