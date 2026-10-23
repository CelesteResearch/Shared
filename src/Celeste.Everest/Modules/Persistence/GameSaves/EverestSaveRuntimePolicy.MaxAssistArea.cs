using Celeste.Game.Save.Data;

namespace Celeste.Everest.Modules.Persistence.GameSaves
{
    public sealed partial class EverestSaveRuntimePolicy
    {
        public int GetMaxAssistArea(OriginalSaveDataState save)
        {
            OriginalLevelSetStats set = GetLevelSetStats(save);
            return unchecked(set.AreaOffset + set.MaxAssistArea);
        }
    }
}
