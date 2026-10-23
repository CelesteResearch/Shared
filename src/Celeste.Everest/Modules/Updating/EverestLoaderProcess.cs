using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Celeste.Everest.Modules.Updating
{
    public sealed partial class EverestLoaderProcess
    {
        internal HashSet<string> _Blacklist = new HashSet<string>();
        internal HashSet<string> Favorites = new HashSet<string>();
        internal string NameTemporaryBlacklist;
        internal List<string> _TemporaryBlacklist;
        internal string NameWhitelist;
        internal List<string> _Whitelist;

        internal List<System.Tuple<global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata, System.Action>>
            Delayed =
                new();

        internal int DelayedLock;
        private bool enforceOptionalDependencies;
        internal HashSet<string> FilesWithMetadataLoadFailures = new();

        internal HashSet<global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata>
            ModsWithAssemblyLoadFailures = new();

        internal readonly System.Version _VersionInvalid =
            new System.Version(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);

        internal readonly System.Version _VersionMax = new System.Version(int.MaxValue, int.MaxValue);
        internal List<string> _ModOptionsOrder = new();
        internal System.IO.FileSystemWatcher Watcher;
        public string PathCache { get; internal set; }
        public string PathBlacklist { get; internal set; }
        public string PathFavorites { get; internal set; }
        public string PathTemporaryBlacklist { get; internal set; }
        public ReadOnlyCollection<string> TemporaryBlacklist => _TemporaryBlacklist?.AsReadOnly();
        public string PathWhitelist { get; internal set; }
        public ReadOnlyCollection<string> Whitelist => _Whitelist?.AsReadOnly();
        public string PathModOptionsOrder { get; internal set; }
        public ReadOnlyCollection<string> ModOptionsOrder => _ModOptionsOrder?.AsReadOnly();
        internal event System.Action<string, global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata> OnCrawlMod;
        internal List<string> updaterBlacklist = new List<string>();
        public string PathMods { get; internal set; }
        public string PathUpdaterBlacklist { get; internal set; }
        public ReadOnlyCollection<string> UpdaterBlacklist => updaterBlacklist?.AsReadOnly();
        public bool AutoLoadNewMods { get; internal set; }
    }
}
