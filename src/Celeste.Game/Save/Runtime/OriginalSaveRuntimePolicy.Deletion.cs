namespace Celeste.Game.Save.Runtime
{
    public sealed partial class OriginalSaveRuntimePolicy
    {
        public bool TryDelete(int slot, IOriginalSaveDeletionServices services)
            => services.Delete(GetFilename(slot));
    }
}
