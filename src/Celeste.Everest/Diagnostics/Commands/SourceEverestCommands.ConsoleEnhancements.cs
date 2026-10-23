using System;
using System.Text;

namespace Celeste.Everest.Diagnostics.Commands
{
    public partial class SourceEverestCommands
    {
        public Func<string, object, object, string> SourceLevelCursorFormatter;

        public StringBuilder DebugRCLog
        {
            get => debugRClog;
            set => debugRClog = value;
        }

        public void OpenFromSourceTasHotkey()
        {
            Open = true;
            currentState = process.ReadKeyboardState();
            if (!installedListener)
            {
                installedListener = true;
                installed.TextInput.OnInput += HandleChar;
            }

            if (!!printedInfoMessage)
                return;
            Log(
                "Use the 'help' command for a list of debug commands. Press Esc or use the 'q' command to close the console.");
            printedInfoMessage = true;
        }

        private string FormatSourceLevelCursor(string format, object x, object y)
        {
            return SourceLevelCursorFormatter == null
                ? string.Format(format, x, y)
                : SourceLevelCursorFormatter(format, x, y);
        }
    }
}
