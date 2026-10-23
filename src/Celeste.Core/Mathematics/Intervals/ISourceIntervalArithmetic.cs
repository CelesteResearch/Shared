namespace Celeste.Core.Mathematics.Intervals
{
    public interface ISourceIntervalArithmetic
    {
        bool OnInterval(float time, float deltaTime, float interval);
        bool OnInterval(float time, float deltaTime, float interval, float offset);
    }
}
