using Celeste.Game.Entities.Environment.Wind;
using Celeste.Simulation.Gameplay.Environment.Wind;
using Celeste.Simulation.Gameplay.Player.Intro;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private OriginalWindController windController;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public OriginalWindController WindController => windController;

        private void ReplaceSourceWindController(RoomWindPattern pattern, PlayerIntroType playerIntro)
        {
            Scheduler.Entities.FindFirst<OriginalWindController>()?.RemoveSelf();
            windController = new(pattern, EngineContext);
            Scheduler.QueueSourceEntity(WindController);
            if (playerIntro != PlayerIntroType.Transition) WindController.SetStartPattern();
        }
    }
}
