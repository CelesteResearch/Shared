using Celeste.Game.Save.Data;

namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public void Start(OriginalSaveDataState data, int slot, IOriginalSaveInitializationServices services)
        {
            context.PublishCurrentSave(data);
            context.CurrentSave.FileSlot = slot;
            AfterInitialize(context.CurrentSave, services);
            ((IOriginalSaveStartSourceHooksEnvironment)engineIdentity.EngineIdentity.Process)
                .AfterSourceSaveStart(context.CurrentSave);
        }
    }
}
