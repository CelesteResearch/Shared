using System;
using Celeste.Core.Geometry;
using Celeste.Input.Devices.Mouse;
using Celeste.Input.Devices.Text;

namespace Celeste.Hosting.Runtime.Input
{
    public sealed class EmbeddedInputDevices : ISourceFnaInputClock, ISourceTextInputPlatform, ISourceClipboardIO,
        IDisposable
    {
        private readonly EmbeddedGameConfiguration configuration;
        private bool focused;
        private bool textActive;
        public EmbeddedKeyboardDevice Keyboard { get; }
        public EmbeddedMouseDevice Mouse { get; } = new();
        public DisconnectedGamePadDevice GamePads { get; } = new();
        public DateTime Now => DateTime.Now;
        public int TickCount => Environment.TickCount;
        public event Action<char>? TextInput;
        public event Action<IntRect>? TextInputRectangleChanged;

        public EmbeddedInputDevices(EmbeddedGameConfiguration configuration)
        {
            this.configuration = configuration;
            Keyboard = new EmbeddedKeyboardDevice(configuration.TranslateScancode);
        }

        public void Advance(int[] pressedKeys, int mouseX, int mouseY, uint mouseButtons, int wheelDelta, bool focused)
        {
            this.focused = focused;
            Keyboard.Advance(pressedKeys, focused);
            Mouse.Advance(mouseX, mouseY, mouseButtons, wheelDelta, focused);
        }

        public void PushTextInput(char character)
        {
            if (focused && textActive) TextInput?.Invoke(character);
        }

        public bool IsTextInputActive() => textActive;
        public bool IsScreenKeyboardShown(IntPtr window) => false;

        public void StartTextInput()
        {
            if (textActive) return;
            textActive = true;
            configuration.SetTextInputActive(true);
        }

        public void StopTextInput()
        {
            if (!textActive) return;
            textActive = false;
            configuration.SetTextInputActive(false);
        }

        public void SetTextInputRectangle(IntRect rectangle) => TextInputRectangleChanged?.Invoke(rectangle);
        public string GetClipboardText() => configuration.GetClipboardText();
        public void SetClipboardText(string value) => configuration.SetClipboardText(value);

        public void Dispose()
        {
            focused = false;
            Keyboard.Advance(Array.Empty<int>(), false);
            Mouse.Advance(0, 0, 0, 0, false);
            StopTextInput();
        }
    }
}
