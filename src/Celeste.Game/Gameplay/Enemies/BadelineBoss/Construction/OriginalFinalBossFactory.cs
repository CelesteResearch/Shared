using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Progression;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss.Construction
{
    public sealed class OriginalFinalBossFactory : IOriginalFinalBossFactory
    {
        private readonly ISourceEngineContext engine;
        private readonly OriginalFinalBossProgressionPolicy progression = new();

        public OriginalFinalBossFactory(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public FinalBossState Create(EntityData data, Vector2 offset)
        {
            return new(data, offset, progression, engine);
        }
    }
}
