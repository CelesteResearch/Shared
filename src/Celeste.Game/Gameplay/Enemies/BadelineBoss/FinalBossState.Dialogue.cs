using Celeste.Game.UI.Dialogue.MiniTextboxes;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss
{
    public partial class FinalBossState
    {
        private void AddMiniTextbox(string dialogId)
        {
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(
                new MiniTextboxState(dialogId, EngineContext));
        }
    }
}
