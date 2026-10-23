namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public bool TryDelete(int slot, IOriginalSaveDeletionServices services)
        {
            return services.Delete(GetFilename(slot));
        }
    }
}
