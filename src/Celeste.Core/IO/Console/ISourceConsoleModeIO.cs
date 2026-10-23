using System;

namespace Celeste.Core.IO.Console
{
    public interface ISourceConsoleModeIO
    {
        IntPtr GetStdHandle(int kind);
        bool GetConsoleMode(IntPtr handle, out uint mode);
        bool SetConsoleMode(IntPtr handle, uint mode);
    }
}
