using Celeste.Game.Entities.Environment.Wind;
using Celeste.Simulation.Gameplay.Environment.Wind;
using Celeste.Simulation.Gameplay.Player.Intro;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private OriginalWindController windController;
        public OriginalWindController WindController => windController;

        private void ReplaceSourceWindController(RoomWindPattern pattern, PlayerIntroType playerIntro)
        {
            Scheduler.Entities.FindFirst<OriginalWindController>()?.RemoveSelf();
            windController = new OriginalWindController(pattern, EngineContext);
            Scheduler.QueueSourceEntity(windController);
            if (playerIntro != PlayerIntroType.Transition) windController.SetStartPattern();
        }
    }
}
