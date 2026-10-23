using System;
using Celeste.Game.Execution.Startup;
using Celeste.Everest.Runtime.Startup;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalGameTagInitializationEnvironment
    {
        private IOriginalGameTagInitialization sourceGameTagInitialization;

        public IOriginalGameTagInitialization GameTagInitialization => sourceGameTagInitialization ??
                                                                       throw new InvalidOperationException(
                                                                           "The source tag initialization has not been selected.");

        public void ConstructSourceGameTagInitialization()
        {
            if (sourceGameTagInitialization != null)
                throw new InvalidOperationException("The source tag initialization is already selected.");
            if (SourceProfile == GameProfile.Original)
                sourceGameTagInitialization = new OriginalGameTagInitialization(engine);
            else if (SourceProfile == GameProfile.InstalledEverest)
                sourceGameTagInitialization = new EverestGameTagInitialization(engine);
            else throw new InvalidOperationException("The source profile has not been selected.");
        }
    }
}
