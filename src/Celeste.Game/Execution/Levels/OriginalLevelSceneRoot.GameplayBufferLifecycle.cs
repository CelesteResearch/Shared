using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public void CreateSourceGameplayBuffers()
        {
            Buffers.Create(((ISourceVirtualContentEnvironment)EngineContext).VirtualContent);
        }

        public void UnloadSourceGameplayBuffers()
        {
            Buffers.Unload();
        }
    }
}
