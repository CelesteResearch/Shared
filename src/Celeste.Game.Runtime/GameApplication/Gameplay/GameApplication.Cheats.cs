using Celeste.Game.Cheats;
using Celeste.Game.Profiles;
using Celeste.Game.Settings;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalUnlockEverythingProcess
    {
        private IOriginalUnlockEverythingPolicy sourceUnlockEverythingPolicy;

        IMenuSettingsFlags IOriginalUnlockEverythingProcess.MenuSettings => SettingsProcess.Instance;

        public IOriginalUnlockEverythingPolicy UnlockEverythingPolicy => sourceUnlockEverythingPolicy ??=
            SourceProfile == GameProfile.InstalledEverest
                ? new global::Celeste.Everest.Cheats.EverestUnlockEverythingPolicy()
                : new OriginalUnlockEverythingPolicy();
    }
}
