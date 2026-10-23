namespace Celeste.Game.Execution.Engine.Timing
{
    public readonly struct OriginalEngineTimeSample
    {
        public readonly float RawDeltaTime;
        public readonly float DeltaTime;
        public readonly float EffectiveTimeRate;

        public OriginalEngineTimeSample(float rawDeltaTime, float deltaTime, float effectiveTimeRate)
        {
            RawDeltaTime = rawDeltaTime;
            DeltaTime = deltaTime;
            EffectiveTimeRate = effectiveTimeRate;
        }
    }
}
