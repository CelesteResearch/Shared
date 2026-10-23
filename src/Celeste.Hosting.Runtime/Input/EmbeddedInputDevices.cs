using System;
using Celeste.Core.Geometry;
using Celeste.Input.Devices.Mouse;
using Celeste.Input.Devices.Text;

namespace Celeste.Hosting.Runtime.Input
{
    public sealed class EmbeddedInputDevices : ISourceFnaInputClock, ISourceTextInputPlatform, ISourceClipboardIO,
        IDisposable
    {
        private readonly EmbeddedGameConfiguration _configuration;
        private bool _focused;
        private bool _textActive;
        public EmbeddedKeyboardDevice Keyboard { get; }
        public EmbeddedMouseDevice Mouse { get; } = new();
        public DisconnectedGamePadDevice GamePads { get; } = new();
        public DateTime Now => DateTime.Now;
        public int TickCount => Environment.TickCount;
        public event Action<char>? TextInput;
        public event Action<IntRect>? TextInputRectangleChanged;

        public EmbeddedInputDevices(EmbeddedGameConfiguration configuration)
        {
            _configuration = configuration;
            Keyboard = new(configuration.TranslateScancode);
        }

        public void Advance(int[] pressedKeys, int mouseX, int mouseY, uint mouseButtons, int wheelDelta, bool focused)
        {
            _focused = focused;
            Keyboard.Advance(pressedKeys, focused);
            Mouse.Advance(mouseX, mouseY, mouseButtons, wheelDelta, focused);
        }

        public void PushTextInput(char character)
        {
            if (_focused && _textActive) TextInput?.Invoke(character);
        }

        public bool IsTextInputActive()
        {
            return _textActive;
        }

        public bool IsScreenKeyboardShown(IntPtr window)
        {
            return false;
        }

        public void StartTextInput()
        {
            if (_textActive) return;
            _textActive = true;
            _configuration.SetTextInputActive(true);
        }

        public void StopTextInput()
        {
            if (!_textActive) return;
            _textActive = false;
            _configuration.SetTextInputActive(false);
        }

        public void SetTextInputRectangle(IntRect rectangle)
        {
            TextInputRectangleChanged?.Invoke(rectangle);
        }

        public string GetClipboardText()
        {
            return _configuration.GetClipboardText();
        }

        public void SetClipboardText(string value)
        {
            _configuration.SetClipboardText(value);
        }

        public void Dispose()
        {
            _focused = false;
            Keyboard.Advance([], false);
            Mouse.Advance(0, 0, 0, 0, false);
            StopTextInput();
        }
    }
}
