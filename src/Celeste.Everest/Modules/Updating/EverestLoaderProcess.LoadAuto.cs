using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Runtime.Startup;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Modules.Updating
{
    public sealed partial class EverestLoaderProcess
    {
        public void LoadAuto()
        {
            Directory.CreateDirectory(PathMods =
                Path.Combine(((IEverestStartupRuntimeEnvironment)sourceEngine).EverestRuntime.PathEverest, "Mods"));
            Directory.CreateDirectory(PathCache = Path.Combine(PathMods, "Cache"));
            PathBlacklist = Path.Combine(PathMods, "blacklist.txt");
            if (File.Exists(PathBlacklist))
                _Blacklist = File.ReadAllLines(PathBlacklist).Select(l => (l.StartsWith("#") ? "" : l).Trim())
                    .ToHashSet();
            else
            {
                using StreamWriter streamWriter = File.CreateText(PathBlacklist);
                streamWriter.WriteLine("# This is the blacklist. Lines starting with # are ignored.");
                streamWriter.WriteLine("# Mod folders and archives listed in this file will be disabled.");
                streamWriter.WriteLine("ExampleFolder");
                streamWriter.WriteLine("SomeMod.zip");
            }

            if (!string.IsNullOrEmpty(NameTemporaryBlacklist))
            {
                PathTemporaryBlacklist = Path.Combine(PathMods, NameTemporaryBlacklist);
                if (File.Exists(PathTemporaryBlacklist))
                    _TemporaryBlacklist = File.ReadAllLines(PathTemporaryBlacklist)
                        .Select(l => (l.StartsWith("#") ? "" : l).Trim()).ToList();
            }

            if (!string.IsNullOrEmpty(NameWhitelist))
            {
                PathWhitelist = Path.Combine(PathMods, NameWhitelist);
                if (File.Exists(PathWhitelist))
                    _Whitelist = File.ReadAllLines(PathWhitelist).Select(l => (l.StartsWith("#") ? "" : l).Trim())
                        .ToList();
            }

            PathModOptionsOrder = Path.Combine(PathMods, "modoptionsorder.txt");
            if (File.Exists(PathModOptionsOrder))
                _ModOptionsOrder = File.ReadAllLines(PathModOptionsOrder)
                    .Select(l => (l.StartsWith("#") ? "" : l).Trim())
                    .ToList();
            else
            {
                using StreamWriter streamWriter2 = File.CreateText(PathModOptionsOrder);
                streamWriter2.WriteLine("# This is the Mod Options order file. Lines starting with # are ignored.");
                streamWriter2.WriteLine(
                    "# Mod folders and archives in this file will be displayed in the same order in the Mod Options menu.");
                streamWriter2.WriteLine(
                    "# To define the position of the \"Everest Core\" options, put \"Everest\" on a line.");
                streamWriter2.WriteLine("ExampleFolder");
                streamWriter2.WriteLine("SomeMod.zip");
            }

            PathUpdaterBlacklist = Path.Combine(PathMods, "updaterblacklist.txt");
            if (File.Exists(PathUpdaterBlacklist))
                updaterBlacklist = File.ReadAllLines(PathUpdaterBlacklist)
                    .Select(l => (l.StartsWith("#") ? "" : l).Trim())
                    .ToList();
            else
            {
                using StreamWriter streamWriter3 = File.CreateText(PathUpdaterBlacklist);
                streamWriter3.WriteLine("# This is the Updater Blacklist. Lines starting with # are ignored.");
                streamWriter3.WriteLine(
                    "# If you put the name of a mod zip in this file, it won't be auto-updated and it won't show update notifications on the title screen.");
                streamWriter3.WriteLine("SomeMod.zip");
            }

            PathFavorites = Path.Combine(PathMods, "favorites.txt");
            if (File.Exists(PathFavorites))
                Favorites = new HashSet<string>(File.ReadAllLines(PathFavorites)
                    .Select(l => (l.StartsWith("#") ? "" : l).Trim()));
            else
            {
                using StreamWriter streamWriter4 = File.CreateText(PathFavorites);
                streamWriter4.WriteLine("# This is the favorites list. Lines starting with # are ignored.");
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            enforceOptionalDependencies = true;
            string[] array = Directory.GetFiles(PathMods).OrderBy(f => f).Select(Path.GetFileName)
                .Where(file => file.EndsWith(".zip") && ShouldLoadFile(file)).ToArray();
            string[] array2 = Directory.GetDirectories(PathMods).OrderBy(f => f).Select(Path.GetFileName)
                .Where(file => file != "Cache" && ShouldLoadFile(file)).ToArray();
            ((IEverestSplashEnvironment)sourceEngine).Splash.SetSplashLoadingModCount(array.Length + array2.Length);
            foreach (string path in array) LoadZip(Path.Combine(PathMods, path));
            foreach (string path2 in array2) LoadDir(Path.Combine(PathMods, path2));
            enforceOptionalDependencies = false;
            ((IEverestLoggerProcessEnvironment)sourceEngine).Logger.Log(EverestLogLevel.Info, "loader",
                "Loading mods with unsatisfied optional dependencies (if any)");
            CheckDependenciesOfDelayedMods();
            ((IEverestSplashEnvironment)sourceEngine).Splash.AllModsLoaded();
            stopwatch.Stop();
            var elapsedMessage =
                ((IEverestLoggerProcessEnvironment)sourceEngine).Logger.BeginEnabledMessage("loader",
                    EverestLogLevel.Verbose);
            if (elapsedMessage.ShouldLog)
                elapsedMessage.Write("ALL MODS LOADED IN " + stopwatch.ElapsedMilliseconds + "ms");
            var countMessage =
                ((IEverestLoggerProcessEnvironment)sourceEngine).Logger.BeginEnabledMessage("loader",
                    EverestLogLevel.Info);
            if (countMessage.ShouldLog)
                countMessage.Write("Loaded " +
                                   ((ISourceEverestModulesProcessEnvironment)sourceEngine).ModulesProcess.Modules
                                   .Count +
                                   " modules");
            try
            {
                Watcher = new FileSystemWatcher
                {
                    Path = PathMods,
                    NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite
                };
                Watcher.Created += LoadAutoUpdated;
                Watcher.Error += WatcherError;
                Watcher.EnableRaisingEvents = true;
                AutoLoadNewMods = true;
            }
            catch (Exception e)
            {
                var warning =
                    ((IEverestLoggerProcessEnvironment)sourceEngine).Logger.BeginEnabledMessage("loader",
                        EverestLogLevel.Warn);
                if (warning.ShouldLog) warning.Write("Failed watching folder: " + PathMods);
                ((IEverestLoggerProcessEnvironment)sourceEngine).Logger.LogDetailed(e);
                Watcher?.Dispose();
                Watcher = null;
            }
        }
    }
}
