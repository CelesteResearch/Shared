using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveProgressionPolicy
    {
        int GetUnlockedModes(OriginalSaveDataState save);
        int GetMaxArea(OriginalSaveDataState save);
        int GetMaxAssistArea(OriginalSaveDataState save);
        int GetUnlockedAreasSafe(OriginalSaveDataState save);
        void SetUnlockedAreasSafe(OriginalSaveDataState save, int value);
    }
}
