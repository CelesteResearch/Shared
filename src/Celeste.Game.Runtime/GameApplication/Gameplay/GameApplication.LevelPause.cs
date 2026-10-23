using Celeste.Game.Menus.Pause;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalLevelPauseEnvironment
    {
        private IOriginalLevelPausePolicy sourceLevelPause;

        public IOriginalLevelPausePolicy LevelPause => sourceLevelPause ??=
            SourceProfile == GameProfile.InstalledEverest
                ? new global::Celeste.Everest.Menus.Pause.EverestLevelPausePolicy()
                : new OriginalLevelPausePolicy();
    }
}
