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
    public sealed partial class SourceEverestModulesProcess
    {
        public void InitializeModules()
        {
            foreach (SourceEverestModule module in Modules.ToArray())
                InitializeModule(module);
            Runtime.Initialized = true;
        }

        public void ParseArgs(IEnumerable<string> args)
        {
            Queue<string> queue = new(args);
            while (queue.Count > 0)
            {
                string arg = queue.Dequeue();
                using List<SourceEverestModule>.Enumerator enumerator = Modules.GetEnumerator();
                while (enumerator.MoveNext() && !enumerator.Current.ParseArg(arg, queue))
                {
                }
            }
        }
    }
}
