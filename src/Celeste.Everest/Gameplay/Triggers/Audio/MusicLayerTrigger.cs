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
    public class MusicLayerTrigger : SourceTriggerEntityState
    {
        private readonly ISourceEngineContext engine;
        private int[] layers;
        private bool enable;

        public MusicLayerTrigger(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
            string[] array = EntityAttributeReader.Attr(data.Values, "layers").Split(',');
            layers = new int[array.Length];
            for (int i = 0; i < layers.Length; i++)
                layers[i] = int.Parse(array[i]);
            enable = EntityAttributeReader.Bool(data.Values, "enable");
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            var audio = ((OriginalLevelSceneRoot)Scene).Session.Audio;
            int[] array = layers;
            foreach (int index in array)
                audio.Music.Layer(index, enable);
            var process = (IOriginalGameplayProcess)engine;
            OriginalAudioSession.Apply(audio, process.AudioSession.ChannelOutput, process.AudioApplyPolicy, false);
        }
    }
}
