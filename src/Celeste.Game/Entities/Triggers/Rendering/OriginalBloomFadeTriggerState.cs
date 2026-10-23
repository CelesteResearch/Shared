using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Game.Entities.Triggers.Rendering
{
    public class OriginalBloomFadeTriggerState : SourceTriggerEntityState
    {
        public float BloomAddFrom;

        public float BloomAddTo;

        public PositionModes PositionMode;

        private readonly ISourceEngineContext engine;

        public OriginalBloomFadeTriggerState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                SourceVector2Math.Add(data.Position, offset), data.Width, data.Height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
            BloomAddFrom = EntityAttributeReader.Float(data.Values, "bloomAddFrom");
            BloomAddTo = EntityAttributeReader.Float(data.Values, "bloomAddTo");
            PositionMode = EntityAttributeReader.Enum(data.Values, "positionMode", PositionModes.NoEffect);
        }

        public override void OnStay(RoomPlayerSession player)
        {
            OriginalLevelSceneRoot level = base.Scene as OriginalLevelSceneRoot;
            float num = (level.Session.BloomBaseAdd = ((ISourceScalarEnvironment)engine).ScalarArithmetic.AddProduct(
                BloomAddFrom, BloomAddTo - BloomAddFrom,
                ScalarMath.Clamp(GetPositionLerp(player, PositionMode), 0f, 1f)));
            level.Bloom.Base = level.AreaData.BloomBase + num;
        }
    }
}
