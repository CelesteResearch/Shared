using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Celeste.Core.Audio
{
    [DataContract]
    public sealed class EventParameter
    {
        [DataMember] public string Key;
        [DataMember] public float Value;

        public EventParameter(string key, float value)
        {
            Key = key;
            Value = value;
        }
    }
}
