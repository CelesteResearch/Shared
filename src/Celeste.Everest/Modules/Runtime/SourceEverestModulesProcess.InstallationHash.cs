using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Types.Maps;
using Celeste.Everest.Modules.Runtime.Assemblies;
using Celeste.Everest.Modules.Updating;

namespace Celeste.Everest.Modules.Runtime
{
    public sealed partial class SourceEverestModulesProcess
    {
        public byte[] InstallationHash
        {
            get
            {
                if (installationHash != null) return installationHash;

                var data = new List<byte>(512);
                lock (Modules)
                {
                    foreach (var module in Modules)
                        if (module?.Metadata != null)
                            data.AddRange(module.Metadata.Hash);
                }

                lock (((IEverestContentRegistryEnvironment)sourceEngine).SourceContentRegistry.Map)
                {
                    var array = ((IEverestContentRegistryEnvironment)sourceEngine)
                        .SourceContentRegistry
                        .Map.Values.ToArray();
                    foreach (var modAsset in array)
                    {
                        if (modAsset?.Type != typeof(AssetTypeMap)) continue;

                        using var stream = modAsset.Stream;
                        if (stream != null) AddStream(stream);
                    }
                }

                return installationHash = EverestChecksums.ComputeHash([.. data]);

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
                return hashAlgorithm.ComputeHash(InstallationHash)
                    .ToHexadecimalString();
            }
        }

        public void InvalidateInstallationHash()
        {
            installationHash = null;
        }

        public void LogDetours(EverestLogLevel level = EverestLogLevel.Debug)
        {
            var pendingLog = detourLog;
            if (pendingLog.Count == 0) return;

            detourLog = [];
            foreach (var item in pendingLog) Logger.Log(level, "detours", item);
        }
    }
}
