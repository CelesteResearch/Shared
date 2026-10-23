using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss.Construction
{
    public interface IOriginalFinalBossFactory
    {
        FinalBossState Create(EntityData data, Vector2 offset);
    }
}
