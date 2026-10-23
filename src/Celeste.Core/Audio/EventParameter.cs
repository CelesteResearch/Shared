using System.Runtime.Serialization;

namespace Celeste.Core.Audio
{
    [DataContract]
    public sealed class EventParameter(string key, float value)
    {
        [DataMember] public string Key = key;

        [DataMember] public float Value = value;
    }
}
