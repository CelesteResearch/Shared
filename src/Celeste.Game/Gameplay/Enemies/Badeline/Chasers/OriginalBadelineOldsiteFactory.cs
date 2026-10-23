using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Graphics.Display;

namespace Celeste.Game.Gameplay.Enemies.Badeline.Chasers
{
    public sealed class OriginalBadelineOldsiteFactory : IOriginalBadelineOldsiteFactory
    {
        public BadelineOldsiteState Create(EntityData data, Vector2 offset, int index,
            ISourceEngineContext engine)
            => new BadelineOldsiteState(data, offset, index, engine);
    }
}
