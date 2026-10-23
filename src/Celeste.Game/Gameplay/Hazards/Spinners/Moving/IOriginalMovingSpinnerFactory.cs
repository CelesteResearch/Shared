using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Entities;

namespace Celeste.Game.Gameplay.Hazards.Spinners.Moving
{
    public interface IOriginalMovingSpinnerFactory
    {
        SceneEntityState Create(OriginalLevelSceneRoot level, EntityData data,
            Vector2 offset, bool rotating);
    }
}
