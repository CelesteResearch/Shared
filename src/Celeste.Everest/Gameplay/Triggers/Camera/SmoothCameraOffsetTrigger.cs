using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Everest.Gameplay.Triggers.Camera
{
    public class SmoothCameraOffsetTrigger : SourceTriggerEntityState
    {
        private readonly ISourceEngineContext engine;
        private readonly Vector2 offsetFrom;
        private readonly Vector2 offsetTo;
        private readonly PositionModes positionMode;
        private readonly bool onlyOnce;
        private readonly bool xOnly;
        private readonly bool yOnly;

        public SmoothCameraOffsetTrigger(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
            offsetFrom = new(EntityAttributeReader.Float(data.Values, "offsetXFrom") * 48f,
                EntityAttributeReader.Float(data.Values, "offsetYFrom") * 32f);
            offsetTo = new(EntityAttributeReader.Float(data.Values, "offsetXTo") * 48f,
                EntityAttributeReader.Float(data.Values, "offsetYTo") * 32f);
            positionMode = EntityAttributeReader.Enum(data.Values, "positionMode", PositionModes.NoEffect);
            onlyOnce = EntityAttributeReader.Bool(data.Values, "onlyOnce");
            xOnly = EntityAttributeReader.Bool(data.Values, "xOnly");
            yOnly = EntityAttributeReader.Bool(data.Values, "yOnly");
        }

        public override void OnStay(RoomPlayerSession player)
        {
            base.OnStay(player);
            if (!yOnly)
                ((OriginalLevelSceneRoot)Scene).CameraOffset.X =
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic.Lerp(
                        offsetFrom.X, offsetTo.X, GetPositionLerp(player, positionMode));
            if (!xOnly)
                ((OriginalLevelSceneRoot)Scene).CameraOffset.Y =
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic.Lerp(
                        offsetFrom.Y, offsetTo.Y, GetPositionLerp(player, positionMode));
        }

        public override void OnLeave(RoomPlayerSession player)
        {
            base.OnLeave(player);
            if (onlyOnce)
                RemoveSelf();
        }
    }
}
