using Celeste.Game.Execution.Areas;

namespace Celeste.Everest.Content.Reloading
{
    public sealed class EverestAssetReloadSynchronization : ISourceAreaReloadLockEnvironment
    {
        public object AreaReloadLock = new object();

        object ISourceAreaReloadLockEnvironment.AreaReloadLock => AreaReloadLock;
    }
}
