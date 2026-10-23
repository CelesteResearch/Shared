using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Celeste.Everest.Modules.Runtime;
using Celeste.Simulation.Diagnostics.Console;

namespace Celeste.Everest
{
    public static class EverestConsoleRegistry
    {
        private sealed class Registration : IDisposable
        {
            public string Name, Help, Usage;
            public Action<DebugConsole, string[]> Execute;

            private readonly ConditionalWeakTable<
                DebugConsole, RestoreAction> restore = new();

            private sealed class RestoreAction
            {
                public Action Action;
            }

            public void Dispose()
            {
                foreach (var weak in consoles)
                    if (weak.TryGetTarget(out var console) && restore.TryGetValue(console, out var item))
                    {
                        item.Action();
                        restore.Remove(console);
                    }

                registrations.Remove(this);
            }

            public void Apply(DebugConsole console)
            {
                if (!restore.TryGetValue(console, out _))
                    restore.Add(console,
                        new() { Action = console.RegisterOverride(Name, Help, Usage, args => Execute(console, args)) });
            }
        }

        private static readonly List<Registration> registrations = [];

        private static readonly List<WeakReference<DebugConsole>>
            consoles = [];

        static EverestConsoleRegistry()
        {
            DebugConsole.Created += Created;
            if (DebugConsole.Console != null)
                Created(DebugConsole.Console);
        }

        private static void Created(DebugConsole console)
        {
            consoles.RemoveAll(w => !w.TryGetTarget(out _));
            consoles.Add(new(console));
            foreach (var registration in registrations) registration.Apply(console);
        }

        public static IDisposable Register(string name, string help, string usage,
            Action<DebugConsole, string[]> execute)
        {
            var registration = new Registration { Name = name, Help = help, Usage = usage, Execute = execute };
            registrations.Add(registration);
            EverestModuleLifetime.Track(registration.Dispose);
            foreach (var weak in consoles)
                if (weak.TryGetTarget(out var console))
                    registration.Apply(console);
            return registration;
        }
    }
}
