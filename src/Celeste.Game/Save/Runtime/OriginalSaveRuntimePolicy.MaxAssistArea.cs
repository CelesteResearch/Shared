using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public int GetMaxAssistArea(OriginalSaveDataState save)
        {
            return unchecked(areas.Areas.Count - 1);
        }
    }
}
