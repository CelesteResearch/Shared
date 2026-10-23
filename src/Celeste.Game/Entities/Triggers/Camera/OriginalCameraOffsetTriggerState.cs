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
    public class OriginalCameraOffsetTriggerState : SourceTriggerEntityState
    {
        public Vector2 CameraOffset;

        public OriginalCameraOffsetTriggerState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                SourceVector2Math.Add(data.Position, offset), data.Width, data.Height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            CameraOffset = new Vector2(EntityAttributeReader.Float(data.Values, "cameraX"),
                EntityAttributeReader.Float(data.Values, "cameraY"));
            CameraOffset.X *= 48f;
            CameraOffset.Y *= 32f;
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            ((OriginalLevelSceneRoot)Scene).CameraOffset = CameraOffset;
        }
    }
}
