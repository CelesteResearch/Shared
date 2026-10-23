using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Celeste.Core.Audio
{
    // AudioTrackState: event changes discard parameters; parameter edits preserve insertion order and spelling.
    [DataContract]
    public sealed class EventTrackState
    {
        [DataMember] private string ev;
        [DataMember] public readonly List<EventParameter> Parameters = new List<EventParameter>();

        public string Event
        {
            get => ev;
            set
            {
                if (ev != value)
                {
                    ev = value;
                    Parameters.Clear();
                }
            }
        }

        public EventTrackState(string ev = null)
        {
            Event = ev;
        }

        public int Progress
        {
            get => (int)GetParam("progress");
            set => Param("progress", value);
        }

        public EventTrackState SetProgress(int value)
        {
            Progress = value;
            return this;
        }

        public EventTrackState Layer(int index, bool value, string[] layerParameters)
            => Param(layerParameters[index], value);

        public EventTrackState Layer(int index, float value, string[] layerParameters)
            => Param(layerParameters[index], value);

        public EventTrackState Param(string key, bool value) => Param(key, value ? 1f : 0f);

        public EventTrackState Param(string key, float value)
        {
            foreach (var parameter in Parameters)
                if (parameter.Key != null && parameter.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase))
                {
                    parameter.Value = value;
                    return this;
                }

            Parameters.Add(new EventParameter(key, value));
            return this;
        }

        public float GetParam(string key)
        {
            foreach (var parameter in Parameters)
                if (parameter.Key != null && parameter.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase))
                    return parameter.Value;
            return 0f;
        }

        public EventTrackState Clone()
        {
            var result = new EventTrackState(Event);
            foreach (var parameter in Parameters)
                result.Parameters.Add(new EventParameter(parameter.Key, parameter.Value));
            return result;
        }
    }
}
