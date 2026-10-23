using System;
using System.Reflection;

namespace Celeste.Everest.Modules.Runtime
{
    public sealed partial class SourceEverestModulesProcess
    {
        public void RegisterModDetour(Assembly owner, object detour, Action undo)
        {
            modDetours.GetOrAdd(owner, _ => new()).TryAdd(detour, undo);
            detourOwners.TryAdd(detour, owner);
        }

        public void UnregisterModDetour(object detour)
        {
            if (detourOwners.TryRemove(detour, out var owner) && modDetours.TryGetValue(owner, out var detours))
                detours.TryRemove(detour, out _);
        }

        public void DisposeSourceModDetours()
        {
            try
            {
                foreach (var detours in modDetours.Values)
                foreach (var undo in detours.Values)
                    undo();

                modDetours.Clear();
            }
            finally
            {
                DisposeSourceBootDetourHooks();
            }
        }
    }
}
