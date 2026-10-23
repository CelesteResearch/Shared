using Celeste.Everest.Entities.Doors.Ridge;
using Celeste.Game.Entities.Doors.Ridge;
using Profile = Celeste.Game.Profiles.GameProfile;

namespace Celeste.Game.Runtime
{
    public sealed partial class
        GameApplication : IOriginalRidgeGateConstructionEnvironment
    {
        public IOriginalRidgeGateConstructionPolicy
            RidgeGateConstruction => SourceProfile == Profile.Original
            ? OriginalRidgeGateConstructionPolicy.Instance
            : EverestRidgeGateConstructionPolicy.Instance;
    }
}
