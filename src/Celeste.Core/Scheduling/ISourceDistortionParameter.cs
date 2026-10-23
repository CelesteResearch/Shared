using System.Numerics;

namespace Celeste.Core.Scheduling
{
    public interface ISourceDistortionParameter
    {
        void SetValue(float value);
        void SetValue(Vector2 value);
    }
}
