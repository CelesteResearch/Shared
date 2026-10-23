using System.Collections.Generic;
using Celeste.Everest.Content.Extensions.Collectibles;
using Celeste.Everest.Runtime.Events;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Completion;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Collectibles.Strawberry;

namespace Celeste.Everest.Runtime.Levels.Completion
{
    public sealed class EverestLevelCompletionPolicy : IOriginalLevelCompletionPolicy
    {
        public void RegisterAreaComplete(OriginalLevelSceneRoot level)
        {
            if (level.Completed) return;
            var player =
                level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            if (player != null)
            {
                var strawberries = new List<ISourceStrawberryCollectible>();
                var berryTypes = ((ISourceInstalledStrawberryRegistryEnvironment)level.EngineContext).StrawberryRegistry
                    .GetBerryTypes();
                foreach (var follower in player.Leader.Followers)
                {
                    if (berryTypes.Contains(follower.Entity.GetType()) &&
                        follower.Entity is ISourceStrawberryCollectible)
                        strawberries.Add(follower.Entity as ISourceStrawberryCollectible);
                }

                foreach (var strawberry in strawberries)
                    strawberry.OnCollect();
            }

            level.Completed = true;
            ((IOriginalGameplayProcess)level.EngineContext).SaveContext.RegisterCompletion(level.Session);
            ((IEverestGameEventsEnvironment)level.EngineContext).GameEvents.Complete(level);
        }
    }
}
