using System;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Textures;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Settings;
using Celeste.Game.Execution.Startup;

namespace Celeste.Everest.Runtime.Startup
{
    public sealed class EverestCelesteContentLifecycle : IOriginalCelesteContentLifecycle
    {
        private readonly OriginalCelesteLoadContent original;
        private readonly ISourceEngineContext engine;
        private readonly EverestStartupRuntimeProcess runtime;

        public EverestCelesteContentLifecycle(OriginalCelesteLoadContent original,
            ISourceEngineContext engine, EverestStartupRuntimeProcess runtime)
        {
            this.original = original;
            this.engine = engine;
            this.runtime = runtime;
        }

        public void UnloadContent()
        {
            original.UnloadContent();
        }

        public void LoadContent()
        {
            var firstLoad = original.FirstLoad;
            var fast = ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings.FastTextureLoading;
            bool start;
            if (!fast.HasValue)
            {
                if (Environment.ProcessorCount < 4)
                    start = false;
                else
                    start = !((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings.ThreadedGL ?? true;
            }
            else
            {
                start = fast == true;
            }

            if (start)
            {
                var limit =
                    (long)(((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings
                           .FastTextureLoadingMaxMB *
                           1024f * 1024f);
                if (limit <= 0)
                {
                    limit = (long)(runtime.SystemMemoryMB * 0.2f * 1024f * 1024f);
                    if (limit <= 536870912)
                        limit = 536870912L;
                }

                if (limit <= 134217728)
                    limit = 134217728L;
                ((IEverestFastTextureLoadingEnvironment)engine).FastLoading.Start(limit);
            }

            try
            {
                original.LoadContent();
                var modules = ((ISourceEverestModulesProcessEnvironment)engine).ModulesProcess;
                foreach (var module in modules.Modules.ToArray())
                    modules.LoadModuleContent(module, firstLoad);
            }
            finally
            {
                ((IEverestFastTextureLoadingEnvironment)engine).FastLoading.Stop();
            }

            runtime.MarkSourceContentLoaded();
        }
    }
}
