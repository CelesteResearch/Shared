using Celeste.Input.Devices.Text;
using System;

namespace Celeste.Everest.Runtime.Input
{
    public sealed class EverestSourceTextInputDevice : IEverestTextInputDevice
    {
        private readonly SourceFnaTextInputEvents events;
        private readonly ISourceClipboardIO clipboard;

        public EverestSourceTextInputDevice(SourceFnaTextInputEvents events, ISourceClipboardIO clipboard)
        {
            this.events = events ?? throw new ArgumentNullException(nameof(events));
            this.clipboard = clipboard ?? throw new ArgumentNullException(nameof(clipboard));
        }

        public event Action<char> TextInput
        {
            add => events.TextInput += value;
            remove => events.TextInput -= value;
        }

        public bool IsTextInputActive() => events.IsTextInputActive();
        public void StartTextInput() => events.StartTextInput();
        public void StopTextInput() => events.StopTextInput();
        public string GetClipboardText() => clipboard.GetClipboardText();
        public void SetClipboardText(string value) => clipboard.SetClipboardText(value);
    }
}
