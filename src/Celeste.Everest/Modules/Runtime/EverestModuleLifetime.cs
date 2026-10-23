using System;
using System.Collections.Generic;
using Celeste.Everest;

namespace Celeste.Everest.Modules.Runtime
{
    // A cold-start code module normally lives until process exit. An engine host
    // that re-enters in one managed domain can retire only the registrations made
    // while that module's lifecycle methods run, without clearing other owners.
    public static class EverestModuleLifetime
    {
        [ThreadStatic] private static global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata current;

        private static readonly Dictionary<global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata, List<Action>>
            cleanup =
                new Dictionary<global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata, List<Action>>();

        public static IDisposable Begin(global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata owner)
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
                if (!cleanup.TryGetValue(owner, out var actions)) cleanup.Add(owner, actions = new List<Action>());
                actions.Add(unregister);
            }
        }

        public static void Retire(global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata owner)
        {
            if (owner == null) return;
            List<Action> actions;
            lock (cleanup)
            {
                if (!cleanup.TryGetValue(owner, out actions)) return;
                cleanup.Remove(owner);
            }

            for (int i = actions.Count - 1; i >= 0; i--) actions[i]();
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
