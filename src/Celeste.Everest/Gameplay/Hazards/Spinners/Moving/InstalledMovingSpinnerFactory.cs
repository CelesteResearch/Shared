using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Gameplay.Hazards.Spinners.Moving;

namespace Celeste.Everest.Gameplay.Hazards.Spinners.Moving
{
    public sealed class InstalledMovingSpinnerFactory : OriginalMovingSpinnerFactory
    {
        protected override bool ShouldUseStar(OriginalLevelSceneRoot level, EntityData data)
        {
            return level.Session.AreaID == 10 || EntityAttributeReader.Bool(data.Values, "star");
        }

        protected override bool ShouldUseDust(OriginalLevelSceneRoot level, EntityData data)
        {
            return level.Session.AreaID == 3
                   || (level.Session.AreaID == 7 && level.Session.Level.StartsWith("d-"))
                   || EntityAttributeReader.Bool(data.Values, "dust");
        }
    }
}
