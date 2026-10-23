namespace Celeste.Everest.Modules.Updating
{
    public sealed partial class EverestLoaderProcess
    {
        public void StopWatching()
        {
            AutoLoadNewMods = false;
            var watcher = Watcher;
            Watcher = null;
            if (watcher == null) return;
            watcher.Created -= LoadAutoUpdated;
            watcher.Error -= WatcherError;
            try
            {
                watcher.EnableRaisingEvents = false;
            }
            finally
            {
                watcher.Dispose();
            }
        }
    }
}
