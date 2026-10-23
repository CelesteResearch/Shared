namespace Celeste.Audio.Fmod.Parameters
{
    public sealed class FmodParameterInfo
    {
        public string Name { get; internal set; }
        public int Index { get; internal set; }
        public float Minimum { get; internal set; }
        public float Maximum { get; internal set; }
        public float DefaultValue { get; internal set; }
        public int Type { get; internal set; }
    }
}
