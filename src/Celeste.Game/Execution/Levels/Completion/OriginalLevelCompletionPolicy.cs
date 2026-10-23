using System.Collections.Generic;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Game.Execution.Processes;
using Celeste.Scene.Following;
using Celeste.Simulation;

namespace Celeste.Game.Execution.Levels.Completion
{
    public sealed class OriginalLevelCompletionPolicy : IOriginalLevelCompletionPolicy
    {
        public void RegisterAreaComplete(OriginalLevelSceneRoot level)
        {
            if (level.Completed) return;
            var player =
                level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            if (player != null)
            {
                var strawberries = new List<OriginalStrawberryState>();
                foreach (FollowerState follower in player.Leader.Followers)
                {
                    if (follower.Entity is OriginalStrawberryState)
                        strawberries.Add(follower.Entity as OriginalStrawberryState);
                }

                foreach (OriginalStrawberryState strawberry in strawberries)
                    strawberry.OnCollect();
            }

            level.Completed = true;
            ((IOriginalGameplayProcess)level.EngineContext).SaveContext.RegisterCompletion(level.Session);
        }
    }
}
