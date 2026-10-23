using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Processes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Simulation;

namespace Celeste.Game.Gameplay.Triggers.Audio
{
    public class InstalledMusicFadeTriggerState : OriginalMusicFadeTriggerState
    {
        private readonly ISourceEngineContext engine;
        private PositionModes? positionMode;

        public InstalledMusicFadeTriggerState(EntityData data, Vector2 offset, ISourceEngineContext engine) :
            base(data, offset, engine)
        {
            this.engine = engine;
            string text = EntityAttributeReader.Attr(data.Values, "positionMode");
            if (!string.IsNullOrEmpty(text) && Enum.TryParse<PositionModes>(text.ToString(), true, out var result))
                positionMode = result;
        }

        public override void OnStay(RoomPlayerSession player)
        {
            float value = !positionMode.HasValue
                ? (!LeftToRight
                    ? ScalarMath.ClampedMap(player.Center.Y, Top, Bottom, FadeA, FadeB)
                    : ScalarMath.ClampedMap(player.Center.X, Left, Right, FadeA, FadeB))
                : ScalarMath.ClampedMap(GetPositionLerp(player, positionMode.Value), 0f, 1f, FadeA, FadeB);
            if (string.IsNullOrEmpty(Parameter))
                ((IOriginalGameplayProcess)engine).AudioSession.SetMusicParam("fade", value);
            else
                ((IOriginalGameplayProcess)engine).AudioSession.SetMusicParam(Parameter, value);
        }
    }
}
