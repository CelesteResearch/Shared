using System;
using Celeste.Everest.Runtime.Events;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestGameEventsEnvironment, IOriginalCelesteExitingEnvironment
    {
        private EverestGameEventsProcess sourceGameEvents;

        public EverestGameEventsProcess GameEvents => sourceGameEvents ??
                                                      throw new InvalidOperationException(
                                                          "The actual installed game events are not constructed.");

        public void ConstructSourceInstalledGameEvents()
        {
            if (SourceProfile != GameProfile.InstalledEverest)
                throw new InvalidOperationException("The original profile has no installed game events.");
            if (sourceGameEvents != null)
                throw new InvalidOperationException("The actual game events are already constructed.");
            sourceGameEvents = new(this);
        }

        void IOriginalCelesteExitingEnvironment.AfterSourceGameExiting()
        {
            if (SourceProfile == GameProfile.InstalledEverest) GameEvents.Exiting();
        }
    }
}
