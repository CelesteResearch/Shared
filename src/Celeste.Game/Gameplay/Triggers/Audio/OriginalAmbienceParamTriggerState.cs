using System;
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
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Game.Gameplay.Triggers.Audio
{
    public class OriginalAmbienceParamTriggerState : SourceTriggerEntityState
    {
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        public string Parameter;

        public float From;

        public float To;

        public PositionModes PositionMode;

        public OriginalAmbienceParamTriggerState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset,
                data.Width, data.Height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
            Parameter = EntityAttributeReader.Attr(data.Values, "parameter");
            From = EntityAttributeReader.Float(data.Values, "from");
            To = EntityAttributeReader.Float(data.Values, "to");
            PositionMode = EntityAttributeReader.Enum(data.Values, "direction", PositionModes.NoEffect);
        }

        public override void OnStay(RoomPlayerSession player)
        {
            float value = ScalarMath.ClampedMap(GetPositionLerp(player, PositionMode), 0f, 1f, From, To);
            OriginalLevelSceneRoot obj = base.Scene as OriginalLevelSceneRoot;
            obj.Session.Audio.Ambience.Param(Parameter, value);
            OriginalAudioSession.Apply(obj.Session.Audio, Process.AudioSession.ChannelOutput, Process.AudioApplyPolicy);
        }
    }
}
