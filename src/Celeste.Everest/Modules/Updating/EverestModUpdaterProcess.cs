using System.Collections.Generic;
using System.Threading.Tasks;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Dependencies;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Modules.Updating
{
    public partial class EverestModUpdaterProcess
    {
        private readonly ISourceEngineContext engine;
        private Task updateCheckTask;
        private SortedDictionary<EverestModUpdateInfo, EverestModuleMetadata> availableUpdates;

        public EverestModUpdaterProcess(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        private sealed class MostRecentUpdatedFirst : IComparer<EverestModUpdateInfo>
        {
            public int Compare(EverestModUpdateInfo x, EverestModUpdateInfo y)
            {
                if (x.LastUpdate != y.LastUpdate) return y.LastUpdate - x.LastUpdate;
                return x.Name.CompareTo(y.Name);
            }
        }

        public void RunAsyncCheckForModUpdates(bool excludeBlacklist)
        {
            updateCheckTask = new(delegate
            {
                var updates = DownloadModUpdateList();
                if (updates != null)
                    availableUpdates = ListAvailableUpdates(updates, excludeBlacklist);
            });
            updateCheckTask.Start();
        }

        public bool IsAsyncUpdateCheckingDone()
        {
            if (updateCheckTask != null) return updateCheckTask.Status != TaskStatus.Running;
            return true;
        }

        public SortedDictionary<EverestModUpdateInfo, EverestModuleMetadata> GetAsyncLoadedModUpdates()
        {
            if (updateCheckTask != null) updateCheckTask.Wait();
            return availableUpdates;
        }
    }
}
