using System;

namespace Celeste.Core.Mathematics
{
    public sealed class InstalledSineWaveArithmetic : ISourceSineWaveArithmetic
    {
        public float WrapCounter(float value) => (float)(((double)value + (float)Math.PI * 8f) % ((float)Math.PI * 8f));

        public float AdvanceCounter(float counter, float frequency, float rate, float delta)
        {
            float step = (float)((double)((float)Math.PI * 2f) * frequency * rate * delta);
            return counter + step;
        }

        public float RandomCounter(float nextFloat) => (float)((double)nextFloat * ((float)Math.PI * 2f) * 2d);
    }
}
