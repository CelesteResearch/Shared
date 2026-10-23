using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Mathematics.Framework;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Game.Entities.Triggers.Camera
{
    public class OriginalCameraTargetTriggerState : SourceTriggerEntityState
    {
        public Vector2 Target;

        public float LerpStrength;

        public PositionModes PositionMode;

        public bool XOnly;

        public bool YOnly;

        public string DeleteFlag;

        public OriginalCameraTargetTriggerState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                SourceVector2Math.Add(data.Position, offset), data.Width, data.Height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            Target = SourceVector2Math.Subtract(SourceVector2Math.Add(data.Nodes[0], offset),
                SourceVector2Math.Multiply(new Vector2(320f, 180f), 0.5f));
            LerpStrength = EntityAttributeReader.Float(data.Values, "lerpStrength");
            PositionMode = EntityAttributeReader.Enum(data.Values, "positionMode", PositionModes.NoEffect);
            XOnly = EntityAttributeReader.Bool(data.Values, "xOnly");
            YOnly = EntityAttributeReader.Bool(data.Values, "yOnly");
            DeleteFlag = EntityAttributeReader.Attr(data.Values, "deleteFlag");
        }

        public override void OnStay(RoomPlayerSession player)
        {
            if (string.IsNullOrEmpty(DeleteFlag) || !((OriginalLevelSceneRoot)Scene).Session.GetFlag(DeleteFlag))
            {
                player.CameraAnchor = Target;
                player.CameraAnchorLerp = SourceVector2Math.Multiply(Vector2.One,
                    SourceFrameworkMath.Clamp(LerpStrength * GetPositionLerp(player, PositionMode), 0f, 1f));
                player.CameraAnchorIgnoreX = YOnly;
                player.CameraAnchorIgnoreY = XOnly;
            }
        }

        public override void OnLeave(RoomPlayerSession player)
        {
            base.OnLeave(player);
            OriginalCameraTriggerQueries.ClearAnchorWhenOutside(Scene, player);
        }
    }
}
