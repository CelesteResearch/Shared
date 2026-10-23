namespace Celeste.Audio.Fmod.Events
{
    public readonly struct FmodEventParameter
    {
        public readonly string Name;
        public readonly float Value;
        public readonly MissingParameterBehavior MissingBehavior;

        public FmodEventParameter(string name, float value,
            MissingParameterBehavior missingBehavior = MissingParameterBehavior.Report)
        {
            Name = name;
            Value = value;
            MissingBehavior = missingBehavior;
        }
    }
}
