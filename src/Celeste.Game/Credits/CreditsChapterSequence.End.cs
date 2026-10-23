using Celeste.Input.Runtime;
using Celeste.Input.Gameplay;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsChapterSequence
    {
        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            Process.SaveContext.CurrentSave.Assists.DashAssist = wasDashAssistOn;
            Process.AudioSession.BusMuted("bus:/gameplay_sfx", false);
            CreditsProcess.Instance = null;
            ((global::Celeste.Input.Runtime.ISourceMInputEnvironment)engine).MInput.Disabled = false;
            if (!gotoEpilogue)
            {
                engine.Frame.Scenes.NextScene = ((IOriginalOverworldLoaderEnvironment)engine)
                    .OverworldLoaders.CreateOverworldLoader(OverworldStartMode.AreaComplete, snow);
            }
            else
            {
                OriginalLevelEntryRouting.Go(
                    ((IOriginalSessionEnvironment)engine).Sessions.CreateSession(
                        ((IOriginalAreaKeyEnvironment)engine).AreaKeys.Create(8)),
                    false, engine.Frame.Scenes,
                    ((IOriginalLevelEntryEnvironment)engine).LevelEntries);
            }
        }
    }
}
