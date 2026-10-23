using System;
using Celeste.Game.Execution.Levels;

namespace Celeste.Everest.Content.Reloading
{
    public sealed class EverestAssetReloadEvents
    {
        public delegate void ReloadHandler(bool silent);

        public delegate void ReloadLevelHandler(OriginalLevelSceneRoot level);

        public ReloadLevelHandler OnReloadLevel;
        public Action OnReloadAllMaps;
        public event ReloadHandler OnBeforeReload;
        public event ReloadHandler OnAfterReload;
        public event ReloadHandler OnBeforeNextReload;
        public event ReloadHandler OnAfterNextReload;

        internal void BeforeReload(bool silent)
        {
            OnBeforeReload?.Invoke(silent);
            var next = OnBeforeNextReload;
            OnBeforeNextReload = null;
            next?.Invoke(silent);
        }

        internal void AfterReload(bool silent)
        {
            OnAfterReload?.Invoke(silent);
            var next = OnAfterNextReload;
            OnAfterNextReload = null;
            next?.Invoke(silent);
        }

        internal void ReloadLevel(OriginalLevelSceneRoot level)
        {
            OnReloadLevel?.Invoke(level);
        }

        internal void ReloadAllMaps()
        {
            OnReloadAllMaps?.Invoke();
        }
    }
}
