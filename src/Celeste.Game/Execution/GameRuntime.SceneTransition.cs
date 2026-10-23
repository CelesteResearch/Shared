using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Overworld;
using global::Celeste.Game.Execution.Startup;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Execution
{
    public partial class GameRuntime
    {
        protected override void OnSceneTransition(ISourceSceneExecution previous, ISourceSceneExecution next)
        {
            if (!(previous is OverworldLoaderSequence) || !(next is OverworldSequence))
                base.OnSceneTransition(previous, next);
            Process.Effects.TimeRate = 1f;
            ((IOriginalGameplayProcess)Process).AudioSession.PauseGameplaySfx = false;
            ((IOriginalGameplayProcess)Process).AudioSession.SetMusicParam("fade", 1f);
            Process.Effects.Anxiety = 0f;
            Process.Effects.GameRate = 1f;
            Process.Effects.Glitch = 0f;
            ((IOriginalEngineSceneTransitionEnvironment)Process).AfterSourceSceneTransition(previous, next);
        }
    }
}
