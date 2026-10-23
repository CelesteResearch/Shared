using System;
using Celeste.Game.Chapters.Flow;
using Celeste.Simulation.Gameplay.Collectibles.Strawberry;
using Celeste.Simulation.Gameplay.Player.Death;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourceGoldenBerryRestartScene
    {
        ChapterCompletionSession ISourceGoldenBerryRestartScene.GoldenRestartSession => Session;

        public Action CreateGoldenRestartAction(ChapterCompletionSession actualCapturedSession,
            ISourceStrawberryFollower actualGoldenBerry)
            => () =>
            {
                var exit = ((IOriginalLevelExitEnvironment)EngineContext).LevelExits.CreateLevelExit(
                    LevelExitMode.GoldenBerryRestart, actualCapturedSession);
                exit.GoldenStrawberryEntryLevel = actualGoldenBerry.ID.Level;
                EngineContext.Frame.Scenes.NextScene = exit;
            };
    }
}
