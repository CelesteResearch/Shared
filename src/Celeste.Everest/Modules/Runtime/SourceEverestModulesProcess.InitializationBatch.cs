using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Celeste.Everest.Modules.Runtime
{
    public sealed partial class SourceEverestModulesProcess
    {
        public sealed class SourceModInitializationBatch : IDisposable
        {
            private bool shouldReloadMaps;

            private readonly Queue<SourceEverestModule> lateModuleInitQueue = new();

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
                    throw new InvalidOperationException("Can't add tasks to an inactive mod initialization batch");

                shouldReloadMaps = true;
            }

            public void LateInitializeModule(SourceEverestModule module)
            {
                if (!IsActive)
                    throw new InvalidOperationException("Can't add tasks to an inactive mod initialization batch");

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
