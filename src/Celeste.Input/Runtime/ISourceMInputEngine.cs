using System.Numerics;
using Celeste.Core.Mathematics;

namespace Celeste.Input.Runtime
{
    public interface ISourceMInputEngine
    {
        bool IsActive { get; }
        float DeltaTime { get; }
        ISourceVectorArithmetic VectorArithmetic { get; }
        Matrix4x4 ScreenMatrix { get; }
        bool IsCommandConsoleOpen { get; }
    }
}
