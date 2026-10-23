using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Settings;

namespace Celeste.Everest.Modules.Updating
{
    public sealed partial class EverestLoaderProcess
    {
        private readonly ISourceEngineContext sourceEngine;

        private readonly global::Celeste.Everest.Modules.Runtime.Assemblies.EverestModAssemblyFrameOwnership
            modFrameOwnership;

        public EverestLoaderProcess(ISourceEngineContext engine)
        {
            sourceEngine = engine;
            modFrameOwnership =
                new global::Celeste.Everest.Modules.Runtime.Assemblies.EverestModAssemblyFrameOwnership(assembly =>
                    ((global::Celeste.Everest.Modules.Runtime.Assemblies.ISourceEverestAssemblyProcessEnvironment)
                        sourceEngine).AssemblyContexts.GetPhysicalAssemblyOwner(assembly));
        }

        public bool TryGetRegisteredModFrameAssemblyIdentity(System.Reflection.Assembly assembly, out string identity)
            => modFrameOwnership.TryGetAssemblyIdentity(assembly, out identity);

        public IReadOnlyCollection<string> Blacklist => _Blacklist.ToImmutableHashSet();

        public bool ShouldLoadFile(string file)
        {
            if (((IEverestCurrentCoreSettingsEnvironment)sourceEngine).CurrentCoreSettings.WhitelistFullOverride ==
                true)
            {
                if (Whitelist == null)
                {
                    if (!Blacklist.Contains(file))
                    {
                        if (TemporaryBlacklist != null)
                            return !TemporaryBlacklist.Contains(file);
                        return true;
                    }

                    return false;
                }

                return Whitelist.Contains(file);
            }

            if (Whitelist == null || !Whitelist.Contains(file))
            {
                if (!Blacklist.Contains(file))
                {
                    if (TemporaryBlacklist != null)
                        return !TemporaryBlacklist.Contains(file);
                    return true;
                }

                return false;
            }

            return true;
        }
    }
}
