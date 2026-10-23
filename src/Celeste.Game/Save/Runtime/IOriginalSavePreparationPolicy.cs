using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSavePreparationPolicy
    {
        void BeforeSave(OriginalSaveDataState actualSave);
    }
}
