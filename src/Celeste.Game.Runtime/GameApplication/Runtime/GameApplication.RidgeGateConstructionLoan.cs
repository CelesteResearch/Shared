using Profile = Celeste.Game.Profiles.GameProfile;

namespace Celeste.Game.Runtime
{
    public sealed partial class
        GameApplication : global::Celeste.Game.Entities.Doors.Ridge.IOriginalRidgeGateConstructionEnvironment
    {
        public global::Celeste.Game.Entities.Doors.Ridge.IOriginalRidgeGateConstructionPolicy
            RidgeGateConstruction => SourceProfile == Profile.Original
            ? global::Celeste.Game.Entities.Doors.Ridge.OriginalRidgeGateConstructionPolicy.Instance
            : global::Celeste.Everest.Entities.Doors.Ridge.EverestRidgeGateConstructionPolicy.Instance;
    }
}
