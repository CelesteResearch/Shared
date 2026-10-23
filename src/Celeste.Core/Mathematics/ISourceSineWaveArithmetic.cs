namespace Celeste.Core.Mathematics
{
    public interface ISourceSineWaveArithmetic
    {
        float WrapCounter(float value);
        float AdvanceCounter(float counter, float frequency, float rate, float delta);
        float RandomCounter(float nextFloat);
    }
}
