using System;

namespace Celeste.Core.Mathematics
{
    public sealed class OriginalSineWaveArithmetic : ISourceSineWaveArithmetic
    {
        public float WrapCounter(float value) => (value + (float)Math.PI * 8f) % ((float)Math.PI * 8f);

        public float AdvanceCounter(float counter, float frequency, float rate, float delta) =>
            counter + (float)Math.PI * 2f * frequency * rate * delta;

        public float RandomCounter(float nextFloat) => nextFloat * ((float)Math.PI * 2f) * 2f;
    }
}
