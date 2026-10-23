using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Audio;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Everest.Gameplay.Triggers.Audio
{
    public class AmbienceVolumeTrigger : SourceTriggerEntityState
    {
        private readonly ISourceEngineContext engine;
        private float from;
        private float to;
        private PositionModes positionMode;

        public AmbienceVolumeTrigger(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
            from = EntityAttributeReader.Float(data.Values, "from");
            to = EntityAttributeReader.Float(data.Values, "to");
            positionMode = EntityAttributeReader.Enum(data.Values, "direction", PositionModes.NoEffect);
        }

        public override void OnStay(RoomPlayerSession player)
        {
            float num = ScalarMath.ClampedMap(GetPositionLerp(player, positionMode), 0f, 1f, from, to);
            ((OriginalLevelSceneRoot)Scene).Session.Audio.AmbienceVolume = num;
            ((IOriginalGameplayProcess)engine).AudioSession.CurrentAmbienceEventInstance?.SetVolume(num);
        }
    }
}
