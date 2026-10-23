using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Gameplay.Hazards.Spinners.Dust;
using Celeste.Scene.Entities;

namespace Celeste.Game.Gameplay.Hazards.Spinners.Moving
{
    public class OriginalMovingSpinnerFactory : IOriginalMovingSpinnerFactory
    {
        public SceneEntityState Create(OriginalLevelSceneRoot level, EntityData data,
            Vector2 offset, bool rotating)
        {
            if (ShouldUseStar(level, data))
                return rotating
                    ? new OriginalStarRotateSpinnerState(data, offset, level.EngineContext)
                    : new OriginalStarTrackSpinnerState(data, offset, level.EngineContext);
            if (ShouldUseDust(level, data))
                return rotating
                    ? new OriginalDustRotateSpinnerState(data, offset, level.EngineContext)
                    : new OriginalDustTrackSpinnerState(data, offset, level.EngineContext);
            return rotating
                ? new OriginalBladeRotateSpinnerState(data, offset, level.EngineContext)
                : new OriginalBladeTrackSpinnerState(data, offset, level.EngineContext);
        }

        protected virtual bool ShouldUseStar(OriginalLevelSceneRoot level, EntityData data)
        {
            return level.Session.AreaID == 10;
        }

        protected virtual bool ShouldUseDust(OriginalLevelSceneRoot level, EntityData data)
        {
            return level.Session.AreaID == 3
                   || (level.Session.AreaID == 7 && level.Session.Level.StartsWith("d-"));
        }
    }
}
