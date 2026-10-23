using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public OriginalSaveDataState CreateSave()
        {
            var save = new OriginalSaveDataState(this);
            save.Name = "Madeline";
            save.Assists = FileAssists.Default;
            save.Flags = [];
            save.Poem = [];
            save.Areas = [];
            return save;
        }
    }
}
