using Celeste.Game.Settings;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Engine.Screen;
using Celeste.Game.Audio;
using Celeste.Game.Controls.Source;
using Celeste.Framework.Diagnostics.Commands;
using global::Celeste.Game.Execution.Startup;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Execution
{
    public partial class GameRuntime
    {
        protected override void Initialize()
        {
            base.Initialize();
            ((ISettingsContext)Process).Settings.AfterLoad((IOriginalSettingsAfterLoadEnvironment)Process);
            if (((ISettingsContext)Process).Settings.Fullscreen)
                ((IOriginalEngineGraphicsEnvironment)Process).EngineGraphics.ViewPadding =
                    ((ISettingsContext)Process).Settings.ViewportPadding;
            ((ISettingsContext)Process).Settings.ApplyScreen((IOriginalEngineGraphicsEnvironment)Process,
                (IOriginalEngineScreenEnvironment)Process);
            ((IOriginalSfxEnvironment)Process).Sfx.Initialize();
            ((IOriginalGameTagInitializationEnvironment)Process).GameTagInitialization.Initialize();
            ((IOriginalScenePolicyBirthEnvironment)Process).ConstructSourceScenePolicies();
            ((IOriginalGameInputProcessEnvironment)Process).InputSource.Initialize();
            ((ISourceCommandsProcessEnvironment)Process).Commands.Enabled = PlayMode == PlayModes.Debug;
            Process.Frame.Scenes.NextScene =
                ((IOriginalStartupSceneEnvironment)Process).StartupScenes.CreateGameLoader();
            ((IOriginalGameInitializationCompletionEnvironment)Process).CompleteSourceGameInitialization();
        }
    }
}
