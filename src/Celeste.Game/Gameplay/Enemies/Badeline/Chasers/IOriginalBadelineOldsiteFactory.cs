using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Gameplay.Enemies.Badeline.Chasers
{
    public interface IOriginalBadelineOldsiteFactory
    {
        BadelineOldsiteState Create(EntityData data, Vector2 offset, int index, ISourceEngineContext engine);
    }
}
