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
    public class OriginalAltMusicTriggerState : SourceTriggerEntityState
    {
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        public string Track;

        public bool ResetOnLeave;

        public OriginalAltMusicTriggerState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset,
                data.Width, data.Height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
            Track = EntityAttributeReader.Attr(data.Values, "track");
            ResetOnLeave = EntityAttributeReader.Bool(data.Values, "resetOnLeave", true);
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            Process.AudioSession.SetAltMusic(((IOriginalSfxEnvironment)engine).Sfx.EventnameByHandle(Track));
        }

        public override void OnLeave(RoomPlayerSession player)
        {
            if (ResetOnLeave)
            {
                Process.AudioSession.SetAltMusic(null);
            }
        }
    }
}
