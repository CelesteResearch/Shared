using Profile = Celeste.Game.Profiles.GameProfile;

namespace Celeste.Game.Runtime
{
    public sealed partial class
        GameApplication : global::Celeste.Game.Gameplay.Platforms.Cassette.IOriginalCassetteManagerEnvironment
    {
        private global::Celeste.Game.Gameplay.Platforms.Cassette.IOriginalCassetteManagerFactory
            sourceCassetteManagers;

        public global::Celeste.Game.Gameplay.Platforms.Cassette.IOriginalCassetteManagerFactory CassetteManagers =>
            sourceCassetteManagers ??=
                SourceProfile == Profile.Original
                    ? new global::Celeste.Game.Gameplay.Platforms.Cassette.OriginalCassetteManagerFactory(this,
                        RumbleSession)
                    : new global::Celeste.Everest.Gameplay.Platforms.Cassette.InstalledCassetteManagerFactory(this,
                        RumbleSession);
    }
}
