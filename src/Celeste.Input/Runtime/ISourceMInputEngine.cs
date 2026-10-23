using Celeste.Input.Devices.Keyboard;

namespace Celeste.Input.Runtime
{
    public interface ISourceMInputEngine
    {
        bool IsActive { get; }
        float DeltaTime { get; }
        Celeste.Core.Mathematics.ISourceVectorArithmetic VectorArithmetic { get; }
        System.Numerics.Matrix4x4 ScreenMatrix { get; }
        bool IsCommandConsoleOpen { get; }
    }
}
