using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Gameplay.Enemies.BadelineBoss;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Construction;

namespace Celeste.Everest.Gameplay.Enemies.BadelineBoss
{
    public sealed class EverestFinalBossFactory : IOriginalFinalBossFactory
    {
        private readonly ISourceEngineContext engine;
        private readonly EverestFinalBossProgressionPolicy progression;

        public EverestFinalBossFactory(ISourceEngineContext engine)
        {
            this.engine = engine;
            progression = new EverestFinalBossProgressionPolicy(engine);
        }

        public FinalBossState Create(EntityData data, Vector2 offset) => new(data, offset, progression, engine);
    }
}
