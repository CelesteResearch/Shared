using System;
using Celeste.Game.Audio.Application;
using Celeste.Simulation.Audio;

namespace Celeste.Game.Audio
{
    public sealed class OriginalAudioSession : IRoomAudioSession
    {
        public RoomAudioState State { get; private set; }
        private Func<IRoomAudioOutput> readOutput;
        private readonly OriginalAudioStateApplyPolicy applyPolicy;

        public OriginalAudioSession(RoomAudioState state, Func<IRoomAudioOutput> readOutput,
            OriginalAudioStateApplyPolicy applyPolicy)
        {
            this.applyPolicy = applyPolicy;
            Rebind(state, readOutput);
        }

        public void Rebind(RoomAudioState state, Func<IRoomAudioOutput> output)
        {
            State = state ?? throw new ArgumentNullException(nameof(state));
            readOutput = output ?? throw new ArgumentNullException(nameof(output));
        }

        public int MusicProgress
        {
            get => State.Music.GetProgress();
            set => State.Music.SetProgress(value);
        }

        public string ResolveEvent(string handle)
        {
            return OriginalAudioHandles.EventnameByHandle(handle);
        }

        public string ResolveUnlockEvent(string style, string handle)
        {
            return string.IsNullOrWhiteSpace(handle)
                ? style == "temple_a" ? "event:/game/05_mirror_temple/key_unlock_light"
                : style == "temple_b" ? "event:/game/05_mirror_temple/key_unlock_dark"
                : "event:/game/03_resort/key_unlock"
                : ResolveEvent(handle);
        }

        public void EnterRoom(RoomAudioSettings room, bool isFromLoader = false)
        {
            State.CurrentRoom = room ?? throw new ArgumentNullException(nameof(room));
            var output = readOutput();
            if (!room.DelayAltMusic && output != null) output.SetAltMusic(ResolveEvent(room.AltMusic));
            if (room.Music.Length > 0) State.Music.Event = ResolveEvent(room.Music);
            if (!State.IgnoreLevelAudioLayerData)
                for (var i = 0; i < 4; i++)
                    State.Music.Layer(i + 1, room.MusicLayers[i]);
            if (room.MusicProgress >= 0) State.Music.SetProgress(room.MusicProgress);
            State.Music.Layer(6, room.MusicWhispers);
            if (room.Ambience.Length > 0) State.Ambience.Event = ResolveEvent(room.Ambience);
            if (room.AmbienceProgress >= 0) State.Ambience.SetProgress(room.AmbienceProgress);
            if (output != null) Apply(State, output, applyPolicy, isFromLoader);
        }

        public void CompleteTransition()
        {
            var output = readOutput();
            if (State.CurrentRoom != null && State.CurrentRoom.DelayAltMusic && output != null)
                output.SetAltMusic(ResolveEvent(State.CurrentRoom.AltMusic));
        }

        public void SetMusicHandle(string handle, int progress)
        {
            State.Music.Event = ResolveEvent(handle);
            if (progress != 0) State.Music.SetProgress(progress);
            Apply();
        }

        public void SetAltMusicHandle(string handle)
        {
            readOutput()?.SetAltMusic(handle == null ? null : ResolveEvent(handle));
        }

        public void SetMusicFade(string parameter, float value)
        {
            readOutput()?.SetMusicParam(string.IsNullOrEmpty(parameter) ? "fade" : parameter, value);
        }

        public void SetAmbienceParameter(string parameter, float value)
        {
            State.Ambience.Param(parameter, value);
            Apply();
        }

        // CS10_BadelineHelps.StartMusic: apply the live cassette phase, then keep
        // the session's later room-entry value at 7 without another audio apply.
        public void ApplyCassetteRoomsMusic(string eventName, int sixteenthNote)
        {
            State.Music.Event = eventName;
            State.Music.Param("sixteenth_note", sixteenthNote);
            Apply(true);
            State.Music.Param("sixteenth_note", 7f);
        }

        public void Apply(bool forceSixteenthNoteHack = false)
        {
            var output = readOutput();
            if (output != null) Apply(State, output, applyPolicy, forceSixteenthNoteHack);
        }

        public static void Apply(RoomAudioState state, IRoomAudioOutput output,
            OriginalAudioStateApplyPolicy applyPolicy, bool forceSixteenthNoteHack = false)
        {
            var changed = output.SetMusic(state.Music.Event, false);
            if (output.HasMusic)
            {
                foreach (var parameter in state.Music.Parameters)
                    if (parameter.Key != "sixteenth_note" || forceSixteenthNoteHack)
                        output.SetMusicParam(parameter.Key, parameter.Value);
                if (changed) output.StartMusic();
            }

            changed = output.SetAmbience(state.Ambience.Event, false);
            if (output.HasAmbience)
            {
                foreach (var parameter in state.Ambience.Parameters)
                    output.SetAmbienceParam(parameter.Key, parameter.Value);
                if (changed) output.StartAmbience();
            }

            if (applyPolicy == OriginalAudioStateApplyPolicy.Installed && state.AmbienceVolume.HasValue)
                output.SetAmbienceVolume(state.AmbienceVolume.Value);
        }

        public static void Stop(IRoomAudioOutput output, bool allowFadeOut = true)
        {
            if (output == null) throw new ArgumentNullException(nameof(output));
            output.SetMusic(null, false, allowFadeOut);
            output.SetAmbience(null);
        }
    }
}
