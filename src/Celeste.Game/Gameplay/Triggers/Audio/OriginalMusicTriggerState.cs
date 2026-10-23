using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Audio;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Game.Gameplay.Triggers.Audio
{
    public class OriginalMusicTriggerState : SourceTriggerEntityState
    {
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        public string Track;

        public bool SetInSession;

        public bool ResetOnLeave;

        public int Progress;

        private string oldTrack;

        public OriginalMusicTriggerState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset,
                data.Width, data.Height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
            Track = EntityAttributeReader.Attr(data.Values, "track");
            ResetOnLeave = EntityAttributeReader.Bool(data.Values, "resetOnLeave", true);
            Progress = EntityAttributeReader.Int(data.Values, "progress");
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            if (ResetOnLeave) oldTrack = Process.AudioSession.CurrentMusic;

            var session = (Scene as OriginalLevelSceneRoot).Session;
            session.Audio.Music.Event = ((IOriginalSfxEnvironment)engine).Sfx.EventnameByHandle(Track);
            if (Progress != 0) session.Audio.Music.SetProgress(Progress);

            OriginalAudioSession.Apply(session.Audio, Process.AudioSession.ChannelOutput, Process.AudioApplyPolicy);
        }

        public override void OnLeave(RoomPlayerSession player)
        {
            if (ResetOnLeave)
            {
                var session = (Scene as OriginalLevelSceneRoot).Session;
                session.Audio.Music.Event = oldTrack;
                OriginalAudioSession.Apply(session.Audio, Process.AudioSession.ChannelOutput, Process.AudioApplyPolicy);
            }
        }
    }
}
