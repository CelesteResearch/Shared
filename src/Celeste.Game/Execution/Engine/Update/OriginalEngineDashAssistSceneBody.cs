using Celeste.Core.Scheduling;
using Celeste.Scene.Scheduling;
using Celeste.Simulation.Rendering;

namespace Celeste.Game.Execution.Engine.Update
{
    public static class OriginalEngineDashAssistSceneBody
    {
        public static void UpdateFirstTrackedDashAssist(SceneUpdateScheduler actualScene,
            ISourceEngineContext sameEngine)
        {
            var entities = actualScene.Entities.GetTrackedEntities(typeof(PlayerDashAssistPresentation));
            if (entities.Count > 0)
                ((PlayerDashAssistPresentation)entities[0]).Update();
        }

        public static void CommitEntityLists(SceneUpdateScheduler actualScene)
        {
            actualScene.CommitQueuedEntityLists();
        }
    }
}
