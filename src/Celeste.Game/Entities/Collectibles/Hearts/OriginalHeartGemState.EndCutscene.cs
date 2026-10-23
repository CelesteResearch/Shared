using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Entities.Collectibles.Hearts
{
    public partial class OriginalHeartGemState
    {
        private void EndCutscene()
        {
            var level = Scene as OriginalLevelSceneRoot;
            level.Frozen = false;
            level.CanRetry = true;
            level.FormationBackdrop.Display = false;
            engine.Effects.TimeRate = 1f;
            if (poem != null)
                poem.RemoveSelf();
            foreach (var wall in walls)
                wall.RemoveSelf();
            RemoveSelf();
        }
    }
}
