using Celeste.Core.Display;

namespace Celeste.Framework.Diagnostics.Commands
{
    public interface ISourceCommands
    {
        bool Open { get; }
        bool Enabled { get; }
        void Log(object value);
        void Log(object value, PackedColor color);
        void UpdateOpen();
        void UpdateClosed();
        void Render();
    }
}
