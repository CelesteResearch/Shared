using Celeste.Core.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Execution.Engine.Actions
{
    public static class OriginalCelesteFreeze
    {
        public static void Freeze(ISourceEngineContext engine, float time)
        {
            if (!(engine.Effects.FreezeTimer < time))
                return;
            engine.Effects.FreezeTimer = time;
            var scene = engine.Frame.Scenes.CurrentScene;
            if (scene != null)
            {
                var managers = ((ISourceScene)scene).SourceScene.Entities
                    .GetTrackedEntities("Celeste.CassetteBlockManager");
                if (managers.Count > 0)
                    ((IOriginalCassetteMusicAdvance)managers[0]).AdvanceMusic(time);
            }
        }
    }
}
