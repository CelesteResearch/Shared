using Celeste.Scene.Tagging;

namespace Celeste.Scene.Scenes
{
    public partial class SourceSceneState
    {
        public virtual void FreezeFrameUpdate(SourceBitTag updateTag)
        {
            if (!Paused) SourceScene.UpdateTaggedEntities(updateTag);
        }
    }
}
