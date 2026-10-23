using System.Collections.Generic;
using Celeste.Game.Execution.Startup;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public void UnloadLevel()
        {
            var entities = SourceScene.Entities.GetEntitiesExcludingTagMask(
                ((IOriginalGameTagsEnvironment)EngineContext).Tags.Global.Value);
            foreach (var entity in SourceScene.Entities.GetTrackedEntities("Celeste.Textbox"))
                entities.Add(entity);
            UnloadEntities(entities);
            SourceScene.CommitQueuedEntityLists();
        }

        public void UnloadEntities(List<object> entities)
        {
            foreach (var entity in entities)
                SourceScene.RemoveEntity(entity);
        }
    }
}
