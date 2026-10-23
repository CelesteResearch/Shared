using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Maps.Processing;
using Celeste.Everest.Content.Reloading;
using Celeste.Everest.Content.Extensions.Entities.Registry;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Types.Maps;
using Celeste.Everest.Runtime.Startup;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Updating;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Processes;
using Celeste.Scene.Tracking.Initialization;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Modules.Runtime
{
    using System.IO;
    using System.Security.Cryptography;

    public sealed partial class SourceEverestModulesProcess
    {
        public byte[] InstallationHash
        {
            get
            {
                if (installationHash != null)
                {
                    return installationHash;
                }

                List<byte> data = new List<byte>(512);
                lock (Modules)
                {
                    foreach (SourceEverestModule module in Modules)
                    {
                        if (module?.Metadata != null)
                        {
                            data.AddRange(module.Metadata.Hash);
                        }
                    }
                }

                lock (((IEverestContentRegistryEnvironment)sourceEngine).SourceContentRegistry.Map)
                {
                    EverestContentAsset[] array = ((IEverestContentRegistryEnvironment)sourceEngine)
                        .SourceContentRegistry
                        .Map.Values.ToArray();
                    foreach (EverestContentAsset modAsset in array)
                    {
                        if (modAsset?.Type != typeof(AssetTypeMap))
                        {
                            continue;
                        }

                        using Stream stream = modAsset.Stream;
                        if (stream != null)
                        {
                            AddStream(stream);
                        }
                    }
                }

                return installationHash = EverestChecksums.ComputeHash(data.ToArray());

                void AddStream(Stream inputStream)
                {
                    data.AddRange(EverestChecksums.ComputeHash(inputStream));
                }
            }
        }

        public string InstallationHashShort
        {
            get
            {
                using HashAlgorithm hashAlgorithm = XXHash64.Create();
                return global::Celeste.Everest.Modules.Runtime.Assemblies.SourceAssemblyStorageExtensions
                    .ToHexadecimalString(hashAlgorithm.ComputeHash(InstallationHash));
            }
        }

        public void InvalidateInstallationHash() => installationHash = null;

        public void LogDetours(EverestLogLevel level = EverestLogLevel.Debug)
        {
            List<string> pendingLog = detourLog;
            if (pendingLog.Count == 0)
            {
                return;
            }

            detourLog = new List<string>();
            foreach (string item in pendingLog)
            {
                Logger.Log(level, "detours", item);
            }
        }
    }
}
