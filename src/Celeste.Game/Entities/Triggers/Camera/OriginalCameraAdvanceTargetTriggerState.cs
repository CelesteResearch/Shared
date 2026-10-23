using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Framework;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Game.Entities.Triggers.Camera
{
    public class OriginalCameraAdvanceTargetTriggerState : SourceTriggerEntityState
    {
        public Vector2 Target;

        public Vector2 LerpStrength;

        public PositionModes PositionModeX;

        public PositionModes PositionModeY;

        public bool XOnly;

        public bool YOnly;

        public OriginalCameraAdvanceTargetTriggerState(ISourceEngineContext engine, EntityData data,
            Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                SourceVector2Math.Add(data.Position, offset), data.Width, data.Height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            Target = SourceVector2Math.Subtract(SourceVector2Math.Add(data.Nodes[0], offset),
                SourceVector2Math.Multiply(new(320f, 180f), 0.5f));
            LerpStrength.X = EntityAttributeReader.Float(data.Values, "lerpStrengthX");
            LerpStrength.Y = EntityAttributeReader.Float(data.Values, "lerpStrengthY");
            PositionModeX = EntityAttributeReader.Enum(data.Values, "positionModeX", PositionModes.NoEffect);
            PositionModeY = EntityAttributeReader.Enum(data.Values, "positionModeY", PositionModes.NoEffect);
            XOnly = EntityAttributeReader.Bool(data.Values, "xOnly");
            YOnly = EntityAttributeReader.Bool(data.Values, "yOnly");
        }

        public override void OnStay(RoomPlayerSession player)
        {
            player.CameraAnchor = Target;
            player.CameraAnchorLerp.X =
                SourceFrameworkMath.Clamp(LerpStrength.X * GetPositionLerp(player, PositionModeX), 0f, 1f);
            player.CameraAnchorLerp.Y =
                SourceFrameworkMath.Clamp(LerpStrength.Y * GetPositionLerp(player, PositionModeY), 0f, 1f);
            player.CameraAnchorIgnoreX = YOnly;
            player.CameraAnchorIgnoreY = XOnly;
        }

        public override void OnLeave(RoomPlayerSession player)
        {
            base.OnLeave(player);
            OriginalCameraTriggerQueries.ClearAnchorWhenOutside(Scene, player);
        }
    }
}
