using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Runtime.Assemblies;
using Celeste.Everest.Modules.Settings;

namespace Celeste.Everest.Modules.Updating
{
    public sealed partial class EverestLoaderProcess
    {
        private readonly ISourceEngineContext sourceEngine;

        private readonly EverestModAssemblyFrameOwnership
            modFrameOwnership;

        public EverestLoaderProcess(ISourceEngineContext engine)
        {
            sourceEngine = engine;
            modFrameOwnership =
                new(assembly =>
                    ((ISourceEverestAssemblyProcessEnvironment)
                        sourceEngine).AssemblyContexts.GetPhysicalAssemblyOwner(assembly));
        }

        public bool TryGetRegisteredModFrameAssemblyIdentity(Assembly assembly, out string identity)
        {
            return modFrameOwnership.TryGetAssemblyIdentity(assembly, out identity);
        }

        public IReadOnlyCollection<string> Blacklist => /* ReSharper disable once UseCollectionExpression */
            _Blacklist.ToImmutableHashSet();

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
