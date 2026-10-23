using Celeste.Game.Entities.ReflectionTentacles;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss
{
    public partial class FinalBossState
    {
        private void RetreatTentacles()
        {
            foreach (OriginalReflectionTentaclesState tentacles in level.SourceScene.Entities.GetTrackedEntities(
                         "Celeste.ReflectionTentacles"))
                tentacles.Retreat();
        }
    }
}
