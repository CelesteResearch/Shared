using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Hooks;
using Celeste.Game.Profiles;
using Celeste.Simulation.Gameplay.Player.Intro;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalLevelLifecycleSourceHooksEnvironment,
        IOriginalLevelLoadSourceHooksEnvironment
    {
        public OriginalLevelLifecycleSourceHooks LevelSourceHooks { get; } = new();

        public void AfterSourceLevelLoad(OriginalLevelSceneRoot actualLevel, PlayerIntroType playerIntro,
            bool isFromLoader)
        {
            LevelSourceHooks.InvokeAfterLoadLevel(actualLevel);
            if (SourceProfile == GameProfile.InstalledEverest)
                GameEvents.LoadLevel(actualLevel, playerIntro, isFromLoader);
        }
    }
}
