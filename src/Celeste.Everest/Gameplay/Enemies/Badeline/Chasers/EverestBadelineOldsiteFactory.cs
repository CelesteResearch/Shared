using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Gameplay.Enemies.Badeline.Chasers;

namespace Celeste.Everest.Gameplay.Enemies.Badeline.Chasers
{
    public sealed class EverestBadelineOldsiteFactory : IOriginalBadelineOldsiteFactory
    {
        public BadelineOldsiteState Create(EntityData data, Vector2 offset, int index,
            ISourceEngineContext engine)
        {
            return new EverestBadelineOldsiteState(data, offset, index, engine);
        }
    }
}
