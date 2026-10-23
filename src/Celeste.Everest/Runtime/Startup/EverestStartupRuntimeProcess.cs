using System;
using Celeste.Core.Scheduling;
using System.IO;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Runtime.Startup
{
    public sealed partial class EverestStartupRuntimeProcess
    {
        private readonly ISourceEngineContext engine;
        public string PathLog { get; internal set; }
        public global::Celeste.Everest.EverestCompatMode CompatibilityMode { get; internal set; }
        public bool RestartVanilla;
        public bool ShareVanillaSaveFiles { get; internal set; }
        internal bool Initialized;
        public bool IsInitialized => Initialized;
#pragma warning disable CS0649
        internal bool ContentLoaded;
#pragma warning restore CS0649
        public string VersionCelesteString =>
            $"{((IEverestCelesteVersionEnvironment)engine).CelesteVersion}-fna [Everest: {BuildString}]";

        public readonly string VersionString;
        public readonly Version Version;
        public readonly int Build;
        public readonly string VersionSuffix, VersionTag, VersionCommit, BuildString;
        public readonly float SystemMemoryMB;
        public readonly Celeste.Core.Diagnostics.Runtime.SourceRuntimeMemoryAvailability MemoryDiagnosticsAvailability;
        public string PathGame { get; internal set; }
        public string PathTmp { get; internal set; }
        public string PathEverest { get; internal set; }
        public bool XDGPaths { get; internal set; }

        public EverestStartupRuntimeProcess(ISourceEngineContext engine)
        {
            this.engine = engine;
            VersionString = "1.6580.0-azure-082e2-stable";
            int index = VersionString.IndexOf('-');
            if (index == -1)
            {
                Version = new Version(VersionString);
                Build = Version.Minor;
                VersionSuffix = "";
                VersionTag = "";
                VersionCommit = "";
                BuildString = Build.ToString();
            }
            else
            {
                Version = new Version(VersionString.Substring(0, index));
                Build = Version.Minor;
                VersionSuffix = VersionString.Substring(index + 1);
                BuildString = Version.Minor + "-" + VersionSuffix;
                index = VersionSuffix.IndexOf('-');
                if (index == -1)
                {
                    VersionTag = VersionSuffix;
                    VersionCommit = "";
                }
                else
                {
                    VersionTag = VersionSuffix.Substring(0, index);
                    VersionCommit = VersionSuffix.Substring(index + 1);
                }
            }

            var diagnostics = ((Celeste.Core.Diagnostics.Runtime.ISourceRuntimeMemoryDiagnosticsEnvironment)engine)
                .RuntimeMemoryDiagnostics;
            MemoryDiagnosticsAvailability = diagnostics.Availability;
            var capacity = ((Celeste.Core.Diagnostics.Runtime.ISourceRuntimeMemoryCapacityEnvironment)engine)
                .RuntimeMemoryCapacity;
            SystemMemoryMB = (float)capacity.ReadTotalAvailableMemoryBytes() / 1024f / 1024f;
        }

        public void InitializeGamePaths(string actualGameAssemblyLocation)
        {
            InitializeGamePathsFromDeploymentDirectory(Path.GetDirectoryName(actualGameAssemblyLocation));
        }

        public void InitializeGamePathsFromDeploymentDirectory(string actualGameDirectory,
            string defaultTemporaryDirectory = null)
        {
            if (actualGameDirectory == null) throw new ArgumentNullException(nameof(actualGameDirectory));
            if (!Path.IsPathRooted(actualGameDirectory))
                throw new ArgumentException("The actual deployed game data directory must be absolute.",
                    nameof(actualGameDirectory));
            PathGame = actualGameDirectory;
            string temporaryDirectory = Environment.GetEnvironmentVariable("EVEREST_TMPDIR");
            PathTmp = temporaryDirectory ?? defaultTemporaryDirectory ?? PathGame;
            if (temporaryDirectory == null && defaultTemporaryDirectory != null)
                Directory.CreateDirectory(PathTmp);
        }

        public void InitializeStoragePaths(EverestLoggerProcess logger)
        {
            if (!File.Exists(Path.Combine(PathGame, "EverestXDGFlag")))
            {
                XDGPaths = false;
                PathEverest = PathGame;
            }
            else
            {
                XDGPaths = true;
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                Directory.CreateDirectory(PathEverest = Path.Combine(folderPath, "Everest"));
                Directory.CreateDirectory(Path.Combine(folderPath, "Everest", "Mods"));
            }

            string oldSettings = Path.Combine(PathEverest, "ModSettings");
            string obsoleteSettings = Path.Combine(PathEverest, "ModSettings-OBSOLETE");
            if (Directory.Exists(oldSettings) || Directory.Exists(obsoleteSettings))
            {
                logger.Log(EverestLogLevel.Warn, "core",
                    "THE ModSettings FOLDER IS OBSOLETE AND WILL NO LONGER BE USED!");
                if (Directory.Exists(oldSettings) && !Directory.Exists(obsoleteSettings))
                    Directory.Move(oldSettings, obsoleteSettings);
            }
        }
    }
}
