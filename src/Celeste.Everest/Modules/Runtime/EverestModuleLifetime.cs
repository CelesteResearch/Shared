using System;
using System.Collections.Generic;

namespace Celeste.Everest.Modules.Runtime
{
    // A cold-start code module normally lives until process exit. An engine host
    // that re-enters in one managed domain can retire only the registrations made
    // while that module's lifecycle methods run, without clearing other owners.
    public static class EverestModuleLifetime
    {
        [ThreadStatic] private static EverestModuleMetadata current;

        private static readonly Dictionary<EverestModuleMetadata, List<Action>>
            cleanup = new();

        public static IDisposable Begin(EverestModuleMetadata owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            var previous = current;
            current = owner;
            return new Scope(() => current = previous);
        }

        public static void Track(Action unregister)
        {
            if (unregister == null) throw new ArgumentNullException(nameof(unregister));
            var owner = current;
            if (owner == null) return;
            lock (cleanup)
            {
                if (!cleanup.TryGetValue(owner, out var actions)) cleanup.Add(owner, actions = []);
                actions.Add(unregister);
            }
        }

        public static void Retire(EverestModuleMetadata owner)
        {
            if (owner == null) return;
            List<Action> actions;
            lock (cleanup)
            {
                if (!cleanup.TryGetValue(owner, out actions)) return;
                cleanup.Remove(owner);
            }

            for (var i = actions.Count - 1; i >= 0; i--) actions[i]();
        }

        private sealed class Scope : IDisposable
        {
            private Action exit;

            public Scope(Action exit)
            {
                this.exit = exit;
            }

            public void Dispose()
            {
                var action = exit;
                exit = null;
                action?.Invoke();
            }
        }
    }
}
