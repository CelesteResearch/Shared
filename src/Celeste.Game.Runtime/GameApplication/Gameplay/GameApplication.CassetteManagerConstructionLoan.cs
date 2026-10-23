using Celeste.Everest.Gameplay.Platforms.Cassette;
using Celeste.Game.Gameplay.Platforms.Cassette;
using Profile = Celeste.Game.Profiles.GameProfile;

namespace Celeste.Game.Runtime
{
    public sealed partial class
        GameApplication : IOriginalCassetteManagerEnvironment
    {
        private IOriginalCassetteManagerFactory
            sourceCassetteManagers;

        public IOriginalCassetteManagerFactory CassetteManagers =>
            sourceCassetteManagers ??=
                SourceProfile == Profile.Original
                    ? new OriginalCassetteManagerFactory(this,
                        RumbleSession)
                    : new InstalledCassetteManagerFactory(this,
                        RumbleSession);
    }
}
