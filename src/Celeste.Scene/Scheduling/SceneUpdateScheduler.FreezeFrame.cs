using Celeste.Core.Components;
using Celeste.Scene.Tagging;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Scheduling
{
    public sealed partial class SceneUpdateScheduler
    {
        public void UpdateTaggedEntities(SourceBitTag tag, SourceBitTag requiredTag = null, bool checkActive = true)
        {
            foreach (var identity in tagLists[tag.ID])
            {
                var entity = (ISourceEntityUpdate)identity;
                if (checkActive && !entity.Active) continue;
                if (requiredTag != null && (((ISceneEntityTags)identity).Tags.Bits & requiredTag.Value) == 0) continue;
                entity.Update();
            }
        }
    }
}
