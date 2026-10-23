using Celeste.Game.Entities.Mechanisms.RumbleWalls;
using Celeste.Everest.Entities.Mechanisms.RumbleWalls;
using Profile = Celeste.Game.Profiles.GameProfile;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalRumbleTriggerConstructionEnvironment
    {
        private IOriginalRumbleTriggerConstruction sourceRumbleTriggers;

        public IOriginalRumbleTriggerConstruction RumbleTriggers => sourceRumbleTriggers ??=
            SourceProfile == Profile.Original
                ? new OriginalRumbleTriggerConstruction()
                : new EverestRumbleTriggerConstruction();
    }
}
