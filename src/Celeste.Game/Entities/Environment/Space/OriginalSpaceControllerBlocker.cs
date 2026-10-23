using System.Linq;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities.Environment.Space
{
    public class OriginalSpaceControllerBlocker : SceneEntityState
    {
        public OriginalSpaceControllerBlocker(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            var sourceScene = (ISourceScene)scene;
            foreach (var controller in sourceScene.SourceScene.Entities.OfType<OriginalSpaceController>())
                sourceScene.RemoveEntity(controller);
        }
    }
}
