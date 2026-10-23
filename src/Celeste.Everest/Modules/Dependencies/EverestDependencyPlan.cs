using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Modules.Dependencies
{
    // OuiDependencyDownloader's planning rules. Downloading and scene navigation belong to hosts.
    public sealed class EverestDependencyPlan
    {
        public IReadOnlyList<EverestDependencyDecision> Decisions { get; private set; }

        public IReadOnlyCollection<string> ArchivesToUnblacklist { get; private set; }

        public bool RequiresManualIntervention => Decisions.Any(value =>
            value.Disposition == EverestDependencyDisposition
                .UpdateEverestManually ||
            value.Disposition == EverestDependencyDisposition.NotFound ||
            value.Disposition == EverestDependencyDisposition
                .MultipleDownloads ||
            value.Disposition == EverestDependencyDisposition
                .IncompatibleDatabaseVersion);

        // OuiDependencyDownloader's final UI precedence after attempted actions.
        // A database fetch failure must be represented by databaseAvailable=false.
        public static EverestDependencyCompletion Completion(
            bool databaseAvailable, bool actionFailed,
            bool anyArchiveInstalled, bool anyBlacklistAttempted, bool everestUpdateFound,
            bool unresolvedDependency)
        {
            var restart = anyArchiveInstalled || anyBlacklistAttempted;
            var autoExit = databaseAvailable && !actionFailed && !unresolvedDependency && !everestUpdateFound;
            if (autoExit)
                return restart
                    ? EverestDependencyCompletion.RestartAutomatically
                    : EverestDependencyCompletion.ExitToModOptions;
            if (everestUpdateFound)
                return EverestDependencyCompletion.ConfirmEverestUpdate;
            return restart
                ? EverestDependencyCompletion.BackRestarts
                : EverestDependencyCompletion.BackReturns;
        }

        public static EverestDependencyPlan Create(
            IEnumerable<EverestModuleMetadata> required,
            IReadOnlyDictionary<string, EverestModUpdateInfo> available,
            IEnumerable<EverestModuleMetadata> loaded,
            IReadOnlyDictionary<EverestModuleMetadata, string> installedFiles,
            ISet<string> blacklist,
            ISet<string> delayed,
            Func<EverestModuleMetadata, bool> dependencyLoaded,
            Func<int, bool> everestBuildAvailable,
            IReadOnlyDictionary<string, EverestModuleMetadata> graph = null,
            string netCoreMetaName = "EverestCore")
        {
            if (required == null || available == null || loaded == null || installedFiles == null ||
                blacklist == null || delayed == null || dependencyLoaded == null)
                throw new ArgumentNullException("Dependency planning requires the active module state and catalog");
            var missing = required.ToList();
            if (graph != null) ExpandTransitiveDependencies(missing, graph, dependencyLoaded);
            var loadedList = loaded.ToList();
            var decisions = new List<EverestDependencyDecision>();
            var unblacklist = new HashSet<string>(StringComparer.Ordinal);
            var manualEverest = false;
            foreach (var request in missing)
            {
                var decision = new EverestDependencyDecision
                    { Required = request };
                if (delayed.Contains(request.Name))
                {
                    decision.Disposition = EverestDependencyDisposition
                        .Delayed;
                }
                else if (request.Name == "Everest" || request.Name == netCoreMetaName)
                {
                    var version = request.Version;
                    if (version.Major != 1 || version.Build > 0 || version.Revision > 0 || manualEverest ||
                        everestBuildAvailable == null || !everestBuildAvailable(version.Minor))
                    {
                        manualEverest = true;
                        decision.Disposition = EverestDependencyDisposition
                            .UpdateEverestManually;
                    }
                    else
                    {
                        decision.Disposition = EverestDependencyDisposition
                            .UpdateEverest;
                    }
                }
                else if (TryUnblacklist(request, installedFiles, blacklist, unblacklist, dependencyLoaded))
                {
                    decision.Disposition = EverestDependencyDisposition
                        .Unblacklist;
                }
                else if (!available.TryGetValue(request.Name, out var download))
                {
                    decision.Disposition = EverestDependencyDisposition
                        .NotFound;
                }
                else if (download.xxHash.Count > 1)
                {
                    decision.Disposition = EverestDependencyDisposition
                        .MultipleDownloads;
                }
                else if (!Compatible(request.Version, download.Version))
                {
                    decision.Disposition = EverestDependencyDisposition
                        .IncompatibleDatabaseVersion;
                    decision.DatabaseVersion = download.Version;
                }
                else
                {
                    decision.Download = download;
                    decision.InstalledArchive =
                        loadedList.FirstOrDefault(value => value.Name == request.Name && value.PathArchive != null);
                    decision.Disposition = decision.InstalledArchive == null
                        ? EverestDependencyDisposition.Install
                        : EverestDependencyDisposition.Update;
                }

                decisions.Add(decision);
            }

            return new() { Decisions = decisions, ArchivesToUnblacklist = unblacklist };
        }

        private static bool Compatible(Version required, string databaseVersion)
        {
            try
            {
                return EverestDependencyVersion.Satisfies(required,
                    new(databaseVersion));
            }
            catch (Exception error) when (error is ArgumentException || error is FormatException ||
                                          error is OverflowException)
            {
                return false;
            }
        }

        private static bool TryUnblacklist(EverestModuleMetadata request,
            IReadOnlyDictionary<EverestModuleMetadata, string> installed,
            ISet<string> blacklist, ISet<string> result,
            Func<EverestModuleMetadata, bool> loaded)
        {
            EverestModuleMetadata newest = null;
            string filename = null;
            foreach (var candidate in installed)
                if (request.Name == candidate.Key.Name && (newest == null || newest.Version < candidate.Key.Version))
                {
                    newest = candidate.Key;
                    filename = candidate.Value;
                }

            if (newest == null || !blacklist.Contains(filename)) return false;
            if (!result.Add(filename)) return true;
            foreach (var dependency in newest.Dependencies)
                if (!loaded(dependency))
                    TryUnblacklist(dependency, installed, blacklist, result, loaded);
            return true;
        }

        // Same line-by-line blacklist.txt transformation as Everest. The caller writes
        // the result only after confirmation, with its own atomic-file policy.
        public static string UnblacklistText(string source, ISet<string> filenames,
            out IReadOnlyCollection<string> missing)
        {
            var left = new HashSet<string>(filenames, StringComparer.Ordinal);
            var lines = source.Split(["\r\n", "\n"], StringSplitOptions.None).ToList();
            if (lines.Count > 0 && lines[lines.Count - 1].Length == 0) lines.RemoveAt(lines.Count - 1);
            for (var i = 0; i < lines.Count; i++)
            {
                var trimmed = lines[i].Trim();
                if (filenames.Contains(trimmed))
                {
                    lines[i] = "# " + trimmed;
                    left.Remove(trimmed);
                }
                else
                {
                    lines[i] = trimmed;
                }
            }

            missing = left;
            return string.Join(Environment.NewLine, lines) + (lines.Count == 0 ? "" : Environment.NewLine);
        }

        private static void ExpandTransitiveDependencies(
            List<EverestModuleMetadata> missing,
            IReadOnlyDictionary<string, EverestModuleMetadata> graph,
            Func<EverestModuleMetadata, bool> loaded)
        {
            var additions = new List<EverestModuleMetadata>();
            do
            {
                additions.Clear();
                foreach (var request in missing)
                {
                    if (!graph.TryGetValue(request.Name, out var metadata)) continue;
                    foreach (var dependency in metadata.Dependencies)
                    {
                        if (loaded(dependency) || missing.Any(value => value.Name == dependency.Name) ||
                            additions.Any(value => value.Name == dependency.Name)) continue;
                        additions.Add(dependency);
                    }
                }

                missing.AddRange(additions);
            } while (additions.Count > 0);
        }
    }
}
