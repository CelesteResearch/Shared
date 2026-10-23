using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public void BeforeSave(OriginalSaveDataState actualSave)
        {
            // Original receiver is SaveData.Instance, even if BeforeSave was called on another object.
            context.CurrentSave.Version = engineIdentity.EngineIdentity.Version.ToString();
        }
    }
}
