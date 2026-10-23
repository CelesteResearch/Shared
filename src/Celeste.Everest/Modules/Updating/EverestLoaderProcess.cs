using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Modules.Updating
{
    public sealed partial class EverestLoaderProcess
    {
        internal HashSet<string> _Blacklist = [];
        internal HashSet<string> Favorites = [];
        internal string NameTemporaryBlacklist;
        internal List<string> _TemporaryBlacklist;
        internal string NameWhitelist;
        internal List<string> _Whitelist;

        internal List<Tuple<EverestModuleMetadata, Action>>
            Delayed =
                [];

        internal int DelayedLock;
        private bool enforceOptionalDependencies;
        internal HashSet<string> FilesWithMetadataLoadFailures = [];

        internal HashSet<EverestModuleMetadata>
            ModsWithAssemblyLoadFailures = [];

        internal readonly Version _VersionInvalid = new(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);

        internal readonly Version _VersionMax = new(int.MaxValue, int.MaxValue);
        internal List<string> _ModOptionsOrder = [];
        internal FileSystemWatcher Watcher;
        public string PathCache { get; internal set; }
        public string PathBlacklist { get; internal set; }
        public string PathFavorites { get; internal set; }
        public string PathTemporaryBlacklist { get; internal set; }
        public ReadOnlyCollection<string> TemporaryBlacklist => _TemporaryBlacklist?.AsReadOnly();
        public string PathWhitelist { get; internal set; }
        public ReadOnlyCollection<string> Whitelist => _Whitelist?.AsReadOnly();
        public string PathModOptionsOrder { get; internal set; }
        public ReadOnlyCollection<string> ModOptionsOrder => _ModOptionsOrder?.AsReadOnly();
        internal event Action<string, EverestModuleMetadata> OnCrawlMod;
        internal List<string> updaterBlacklist = [];
        public string PathMods { get; internal set; }
        public string PathUpdaterBlacklist { get; internal set; }
        public ReadOnlyCollection<string> UpdaterBlacklist => updaterBlacklist?.AsReadOnly();
        public bool AutoLoadNewMods { get; internal set; }
    }
}
