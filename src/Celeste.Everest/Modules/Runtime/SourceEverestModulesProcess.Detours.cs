using System;
using System.Reflection;
using System.Collections.Concurrent;

namespace Celeste.Everest.Modules.Runtime
{
    public sealed partial class SourceEverestModulesProcess
    {
        public void RegisterModDetour(Assembly owner, object detour, Action undo)
        {
            modDetours.GetOrAdd(owner, _ => new ConcurrentDictionary<object, Action>()).TryAdd(detour, undo);
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
                foreach (ConcurrentDictionary<object, Action> detours in modDetours.Values)
                {
                    foreach (Action undo in detours.Values)
                        undo();
                }

                modDetours.Clear();
            }
            finally
            {
                DisposeSourceBootDetourHooks();
            }
        }
    }
}
