using System;
using System.Collections.Generic;
using Celeste.Core.Audio;
using Celeste.Game.Audio.State.Globals;

namespace Celeste.Game.Audio.Interop
{
    public sealed class OriginalAudioTrackView
    {
        public EventTrackState ActualState { get; }
        private readonly OriginalAudioStateGlobals globals;
        private readonly Func<EventTrackState, OriginalAudioTrackView> project;

        public OriginalAudioTrackView(EventTrackState actualState, OriginalAudioStateGlobals globals,
            Func<EventTrackState, OriginalAudioTrackView> project)
        {
            ActualState = actualState;
            this.globals = globals;
            this.project = project;
        }

        public string Event
        {
            get => ActualState.Event;
            set => ActualState.Event = value;
        }

        public List<EventParameter> Parameters => ActualState.Parameters;

        public int Progress
        {
            get => ActualState.Progress;
            set => ActualState.Progress = value;
        }

        public OriginalAudioTrackView Layer(int index, float value)
        {
            ActualState.Layer(index, value, globals.LayerParameters);
            return this;
        }

        public OriginalAudioTrackView Layer(int index, bool value)
        {
            ActualState.Layer(index, value, globals.LayerParameters);
            return this;
        }

        public OriginalAudioTrackView Param(string key, float value)
        {
            ActualState.Param(key, value);
            return this;
        }

        public OriginalAudioTrackView Param(string key, bool value)
        {
            ActualState.Param(key, value);
            return this;
        }

        public float GetParam(string key) => ActualState.GetParam(key);

        public OriginalAudioTrackView SetProgress(int value)
        {
            ActualState.SetProgress(value);
            return this;
        }

        public OriginalAudioTrackView Clone() => project(ActualState.Clone());
    }
}
