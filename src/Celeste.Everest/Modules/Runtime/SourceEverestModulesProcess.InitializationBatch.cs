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
    using System.Diagnostics;

    public sealed partial class SourceEverestModulesProcess
    {
        public sealed class SourceModInitializationBatch : IDisposable
        {
            private bool shouldReloadMaps;

            private Queue<SourceEverestModule> lateModuleInitQueue = new Queue<SourceEverestModule>();

            public bool IsActive { get; private set; }

            private readonly SourceEverestModulesProcess owner;

            internal SourceModInitializationBatch(SourceEverestModulesProcess owner)
            {
                this.owner = owner;
                if (owner.modInitBatch == null)
                {
                    IsActive = true;
                    owner.modInitBatch = this;
                }
            }

            public void Dispose()
            {
                if (IsActive)
                {
                    Trace.Assert(owner.modInitBatch == this);
                    try
                    {
                        Flush();
                    }
                    finally
                    {
                        owner.modInitBatch = null;
                        IsActive = false;
                    }
                }
            }

            public void ReloadMaps()
            {
                if (!IsActive)
                {
                    throw new InvalidOperationException("Can't add tasks to an inactive mod initialization batch");
                }

                shouldReloadMaps = true;
            }

            public void LateInitializeModule(SourceEverestModule module)
            {
                if (!IsActive)
                {
                    throw new InvalidOperationException("Can't add tasks to an inactive mod initialization batch");
                }

                lateModuleInitQueue.Enqueue(module);
            }

            public void Flush()
            {
                if (IsActive)
                {
                    if (lateModuleInitQueue.Count > 0)
                    {
                        var pending = lateModuleInitQueue.ToArray();
                        lateModuleInitQueue.Clear();
                        try
                        {
                            owner.LateInitializeModules(pending);
                        }
                        catch (Exception failure)
                        {
                            foreach (var module in pending)
                                owner.RollbackModule(module, failure);
                            throw;
                        }
                    }

                    if (shouldReloadMaps)
                    {
                        owner.AssetReload.ReloadAllMaps();
                        shouldReloadMaps = false;
                    }
                }
            }
        }
    }
}
