using System;
using System.Threading.Tasks;

namespace Celeste.Hosting
{
    public interface IEmbeddedGameSession : IDisposable
    {
        bool IsLoading { get; }
        Exception? InitializationError { get; }
        Task DisposedCompletion { get; }
        bool IsRunning { get; }
        bool IsTextInputActive { get; }
        int Width { get; }
        int Height { get; }
        byte[] FrameRgba { get; }
        long FrameNumber { get; }
        void SetSuspended(bool suspended);
        void Advance(int[] pressedKeys, int mouseX, int mouseY, uint mouseButtons, int wheelDelta, bool focused);
        void PushTextInput(char character);
    }
}
