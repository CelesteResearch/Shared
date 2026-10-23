using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveCollectibleTotalsPolicy
    {
        int GetTotalStrawberriesSafe(OriginalSaveDataState save);
        void SetTotalStrawberriesSafe(OriginalSaveDataState save, int value);
    }
}
