using System;

namespace Celeste.Everest.Runtime.Input
{
    public interface IEverestTextInputDevice
    {
        event Action<char> TextInput;
        bool IsTextInputActive();
        void StartTextInput();
        void StopTextInput();
        string GetClipboardText();
        void SetClipboardText(string value);
    }
}
