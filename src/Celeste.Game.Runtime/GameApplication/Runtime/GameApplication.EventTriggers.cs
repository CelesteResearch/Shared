using Celeste.Everest.Entities.Triggers.Events;
using Celeste.Game.Entities.Triggers.Events;
using Profile = Celeste.Game.Profiles.GameProfile;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalEventTriggerEnvironment
    {
        private IOriginalEventTriggerRuntimePolicy sourceEventTriggers;

        public IOriginalEventTriggerRuntimePolicy EventTriggers => sourceEventTriggers ??=
            SourceProfile == Profile.Original
                ? new OriginalEventTriggerRuntimePolicy()
                : new EverestEventTriggerRuntimePolicy(engine);
    }
}
