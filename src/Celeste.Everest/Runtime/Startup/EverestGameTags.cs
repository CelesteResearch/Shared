using Celeste.Game.Execution.Startup;
using Celeste.Scene.Tagging;

namespace Celeste.Everest.Runtime.Startup
{
    public sealed class EverestGameTags
    {
        public SourceBitTag SubHUD;
        public SourceBitTag FreezeFrameUpdate;

        public void Initialize(OriginalGameTags originalTags, SourceBitTagProcessState sameProcess)
        {
            originalTags.Initialize(sameProcess);
            SubHUD = new("subHUD", sameProcess);
            FreezeFrameUpdate = new("freezeFrameUpdate", sameProcess);
        }
    }
}
