using System;
using Celeste.Core.Geometry;

namespace Celeste.Input.Devices.Text
{
    public sealed class SourceFnaTextInputEvents
    {
        private readonly ISourceTextInputPlatform platform;

        public SourceFnaTextInputEvents(ISourceTextInputPlatform platform)
        {
            this.platform = platform;
        }

        public bool IsTextInputActive()
        {
            return platform.IsTextInputActive();
        }

        public bool IsScreenKeyboardShown(IntPtr window)
        {
            return platform.IsScreenKeyboardShown(window);
        }

        public void StartTextInput()
        {
            platform.StartTextInput();
        }

        public void StopTextInput()
        {
            platform.StopTextInput();
        }

        public void SetInputRectangle(IntRect rectangle)
        {
            platform.SetTextInputRectangle(rectangle);
        }

        public event Action<char> TextInput;
        public event Action<string, int, int> TextEditing;

        public void OnTextInput(char c)
        {
            if (TextInput != null)
                TextInput(c);
        }

        public void OnTextEditing(string text, int start, int length)
        {
            if (TextEditing != null)
                TextEditing(text, start, length);
        }
    }
}
