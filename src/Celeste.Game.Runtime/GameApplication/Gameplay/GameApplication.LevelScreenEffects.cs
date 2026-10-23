using Celeste.Game.Execution.Levels;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalLevelScreenEffectsProcess
    {
        LevelScreenEffectsBehavior IOriginalLevelScreenEffectsProcess.LevelScreenEffectsBehavior =>
            SourceProfile == GameProfile.Original
                ? LevelScreenEffectsBehavior.Original
                : LevelScreenEffectsBehavior.Everest;

        bool IOriginalLevelScreenEffectsProcess.AllowGlitch =>
            SourceProfile == GameProfile.Original
                ? !Settings.DisableFlashes
                : CurrentCoreSettings.AllowGlitch;

        bool IOriginalLevelScreenEffectsProcess.AllowScreenFlash =>
            SourceProfile == GameProfile.Original
                ? !Settings.DisableFlashes
                : CurrentCoreSettings.AllowScreenFlash;
    }
}
