using System;
using System.Collections.Generic;
using Celeste.Simulation;

namespace Celeste.Everest
{
    public static class EverestConsoleRegistry
    {
        private sealed class Registration : IDisposable
        {
            public string Name, Help, Usage;
            public Action<global::Celeste.Simulation.Diagnostics.Console.DebugConsole, string[]> Execute;

            private readonly System.Runtime.CompilerServices.ConditionalWeakTable<
                global::Celeste.Simulation.Diagnostics.Console.DebugConsole, RestoreAction> restore =
                new System.Runtime.CompilerServices.ConditionalWeakTable<
                    global::Celeste.Simulation.Diagnostics.Console.DebugConsole, RestoreAction>();

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

            public void Apply(global::Celeste.Simulation.Diagnostics.Console.DebugConsole console)
            {
                if (!restore.TryGetValue(console, out _))
                    restore.Add(console,
                        new RestoreAction
                            { Action = console.RegisterOverride(Name, Help, Usage, args => Execute(console, args)) });
            }
        }

        private static readonly List<Registration> registrations = new List<Registration>();

        private static readonly List<WeakReference<global::Celeste.Simulation.Diagnostics.Console.DebugConsole>>
            consoles = new List<WeakReference<global::Celeste.Simulation.Diagnostics.Console.DebugConsole>>();

        static EverestConsoleRegistry()
        {
            global::Celeste.Simulation.Diagnostics.Console.DebugConsole.Created += Created;
            if (global::Celeste.Simulation.Diagnostics.Console.DebugConsole.Console != null)
                Created(global::Celeste.Simulation.Diagnostics.Console.DebugConsole.Console);
        }

        private static void Created(global::Celeste.Simulation.Diagnostics.Console.DebugConsole console)
        {
            consoles.RemoveAll(w => !w.TryGetTarget(out _));
            consoles.Add(new WeakReference<global::Celeste.Simulation.Diagnostics.Console.DebugConsole>(console));
            foreach (var registration in registrations) registration.Apply(console);
        }

        public static IDisposable Register(string name, string help, string usage,
            Action<global::Celeste.Simulation.Diagnostics.Console.DebugConsole, string[]> execute)
        {
            var registration = new Registration { Name = name, Help = help, Usage = usage, Execute = execute };
            registrations.Add(registration);
            global::Celeste.Everest.Modules.Runtime.EverestModuleLifetime.Track(registration.Dispose);
            foreach (var weak in consoles)
                if (weak.TryGetTarget(out var console))
                    registration.Apply(console);
            return registration;
        }
    }
}
