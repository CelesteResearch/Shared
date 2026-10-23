namespace Celeste.Game.Execution.Levels.Debug
{
    public interface IOriginalLevelDebugAssetReloadProcess
    {
        void ReloadAssets(bool levels, bool graphics, bool hires, int areaID, int mode);
    }
}
