using System;
using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Birds.Paths;
using Celeste.Game.Execution.Levels;

namespace Celeste.Everest.Entities.Birds.Paths
{
    public class EverestBirdPathState : BirdPathState
    {
        private float oldAngle;
        private bool oldAngleInit;
        private readonly bool angleFix;
        private readonly float angleFixMaxRotation;
        private bool inVanilla;

        public EverestBirdPathState(MapEntityId id, EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(id, data, offset, engine)
        {
            angleFix = EntityAttributeReader.Bool(data.Values, "angleFix");
            angleFixMaxRotation = MathF.Abs(EntityAttributeReader.Float(data.Values, "angleFixMaxRotation") *
                                            ((float)Math.PI / 180f));
        }

        public override void Added(object scene)
        {
            inVanilla = ((OriginalLevelSceneRoot)scene).AreaData.LevelSet == "Celeste";
            base.Added(scene);
        }

        protected override float RoutineSpeedMultiplier => inVanilla ? SourceSpeedMultiplier : 1f;

        protected override float CalculateRotation()
        {
            return angleFix ? CalcAngle() : base.CalculateRotation();
        }

        public float CalcAngle()
        {
            if (!oldAngleInit)
            {
                oldAngleInit = true;
                oldAngle = (float)Math.Atan2(SourceSpeed.Y, SourceSpeed.X);
            }
            else
            {
                var maxMove = angleFixMaxRotation * engine.DeltaTime;
                var angle = ScalarMath.AngleLerp((float)Math.Atan2(SourceSpeed.Y, SourceSpeed.X), oldAngle, 0.5f);
                oldAngle = ScalarMath.AngleApproach(oldAngle, angle, maxMove);
            }

            return oldAngle + MathF.PI / 2f;
        }
    }
}
