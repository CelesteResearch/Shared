namespace Celeste.Game.Gameplay.Enemies.BadelineBoss
{
    public partial class FinalBossState
    {
        private void AddMiniTextbox(string dialogId)
        {
            ((Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.QueueSourceEntity(
                new Celeste.Game.UI.Dialogue.MiniTextboxes.MiniTextboxState(dialogId, engine));
        }
    }
}
