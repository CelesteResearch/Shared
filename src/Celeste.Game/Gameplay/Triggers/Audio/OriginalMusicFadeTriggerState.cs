using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Game.Gameplay.Triggers.Audio
{
    public class OriginalMusicFadeTriggerState : SourceTriggerEntityState
    {
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        public bool LeftToRight;

        public float FadeA;

        public float FadeB;

        public string Parameter;

        public OriginalMusicFadeTriggerState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset,
                data.Width, data.Height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
            LeftToRight = EntityAttributeReader.Attr(data.Values, "direction", "leftToRight") == "leftToRight";
            FadeA = EntityAttributeReader.Float(data.Values, "fadeA");
            FadeB = EntityAttributeReader.Float(data.Values, "fadeB", 1f);
            Parameter = EntityAttributeReader.Attr(data.Values, "parameter");
        }

        public override void OnStay(RoomPlayerSession player)
        {
            var value = !LeftToRight
                ? ScalarMath.ClampedMap(player.Center.Y, Top, Bottom, FadeA, FadeB)
                : ScalarMath.ClampedMap(player.Center.X, Left, Right, FadeA, FadeB);
            if (string.IsNullOrEmpty(Parameter))
                Process.AudioSession.SetMusicParam("fade", value);
            else
                Process.AudioSession.SetMusicParam(Parameter, value);
        }
    }
}
