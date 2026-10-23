using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Environment.Space
{
    public sealed class OriginalSpaceController : SceneEntityState
    {
        private OriginalLevelSceneRoot level;

        public OriginalSpaceController(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
        }

        public override void Added(object actualScene)
        {
            base.Added(actualScene);
            level = (OriginalLevelSceneRoot)actualScene;
        }

        public override void Update()
        {
            base.Update();
            var player =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (!(player != null))
                return;
            var top = player.Collider != null
                ? player.Body.Position.Y + player.Collider.Top
                : player.Body.Position.Y;
            if (top > level.Camera.Bottom + 12f)
            {
                var bottom = level.Camera.Top - 4f;
                var position = player.Body.Position;
                position.Y = player.Collider != null ? bottom - player.Collider.Bottom : bottom;
                player.Body.Position = position;
            }
            else
            {
                var bottom = player.Collider != null
                    ? player.Body.Position.Y + player.Collider.Bottom
                    : player.Body.Position.Y;
                if (bottom < level.Camera.Top - 4f)
                {
                    top = level.Camera.Bottom + 12f;
                    var position = player.Body.Position;
                    position.Y = player.Collider != null ? top - player.Collider.Top : top;
                    player.Body.Position = position;
                }
            }
        }
    }
}
