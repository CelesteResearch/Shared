using System;
using Celeste.Everest.Input;
using Celeste.Game.Controls.Source;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalInputLifecycleEnvironment, IEverestInputEventsEnvironment
    {
        private IOriginalInputLifecyclePolicy sourceInputLifecycle;
        private EverestInputEvents sourceInputEvents;

        public IOriginalInputLifecyclePolicy InputLifecycle => sourceInputLifecycle ??
                                                               throw new InvalidOperationException(
                                                                   "The actual Input lifecycle is not selected.");

        public EverestInputEvents InputEvents => sourceInputEvents ??
                                                 throw new InvalidOperationException(
                                                     "The actual installed Input events are not constructed.");

        public void ConstructSourceInputLifecycle()
        {
            if (sourceInputLifecycle != null)
                throw new InvalidOperationException("The actual Input lifecycle is already selected.");
            if (SourceProfile == GameProfile.Original)
            {
                sourceInputLifecycle = new OriginalInputLifecyclePolicy();
            }
            else if (SourceProfile == GameProfile.InstalledEverest)
            {
                sourceInputEvents = new();
                sourceInputLifecycle = new InstalledInputLifecyclePolicy(engine);
            }
            else
            {
                throw new InvalidOperationException("A supported source profile is required.");
            }
        }
    }
}
