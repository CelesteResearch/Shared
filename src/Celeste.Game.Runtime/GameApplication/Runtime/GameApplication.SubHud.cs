using System;
using Celeste.Everest.Presentation.Hud;
using Celeste.Game.Presentation.Hud;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication :
        IOriginalSubHudRendererEnvironment, IEverestSubHudRendererEnvironment
    {
        private SubHudRendererProcessState sourceSubHudRendererProcess;
        private IOriginalSubHudRendererFactory sourceSubHudRendererFactory;

        public SubHudRendererProcessState SubHudRendererProcess => sourceSubHudRendererProcess ??
                                                                   throw new InvalidOperationException(
                                                                       "The actual Installed SubHud process has not been constructed.");

        public IOriginalSubHudRendererFactory SubHudRenderers => sourceSubHudRendererFactory ??
                                                                 throw new InvalidOperationException(
                                                                     "The actual Installed SubHud factory has not been constructed.");

        internal void ConstructSourceInstalledSubHudProcess()
        {
            if (sourceSubHudRendererProcess != null)
                throw new InvalidOperationException("The actual Installed SubHud process is already constructed.");
            sourceSubHudRendererProcess = new();
            sourceSubHudRendererFactory = new EverestSubHudRendererFactory();
        }
    }
}
