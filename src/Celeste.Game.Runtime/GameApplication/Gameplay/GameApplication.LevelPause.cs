using Celeste.Everest.Menus.Pause;
using Celeste.Game.Menus.Pause;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalLevelPauseEnvironment
    {
        private IOriginalLevelPausePolicy sourceLevelPause;

        public IOriginalLevelPausePolicy LevelPause => sourceLevelPause ??=
            SourceProfile == GameProfile.InstalledEverest
                ? new EverestLevelPausePolicy()
                : new OriginalLevelPausePolicy();
    }
}
