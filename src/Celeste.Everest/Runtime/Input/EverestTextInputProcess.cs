using System;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Runtime.Input
{
    public sealed class EverestTextInputProcess
    {
        private readonly IEverestTextInputDevice device;
        private readonly EverestLoggerProcess logger;
        private event Action<char> onInput;
        public bool Initialized { get; private set; }

        public EverestTextInputProcess(IEverestTextInputDevice actualDevice, EverestLoggerProcess actualLogger)
        {
            device = actualDevice;
            logger = actualLogger;
        }

        public event Action<char> OnInput
        {
            add
            {
                onInput += value;
                CheckTextStatus();
            }
            remove
            {
                onInput -= value;
                CheckTextStatus();
            }
        }

        public void Initialize()
        {
            if (!Initialized)
            {
                Initialized = true;
                device.TextInput += ReceiveTextInput;
                CheckTextStatus();
            }
        }

        public void Shutdown()
        {
            if (Initialized)
            {
                if (device.IsTextInputActive()) device.StopTextInput();
                device.TextInput -= ReceiveTextInput;
            }
        }

        public void ReceiveTextInput(char value) => onInput?.Invoke(value);

        private void CheckTextStatus()
        {
            if (Initialized)
            {
                if (onInput != null && onInput.GetInvocationList().Length != 0 && !device.IsTextInputActive())
                    device.StartTextInput();
                else if ((onInput == null || onInput.GetInvocationList().Length == 0) && device.IsTextInputActive())
                    device.StopTextInput();
                var current = onInput;
                if (current != null && current.GetInvocationList().Length > 1)
                    logger.Log(EverestLogLevel.Warn, "TextInput",
                        "Simultaneous text input subscriptions detected, is this a bug? See TextInput.OnInput for proper usage");
            }
        }

        public string GetClipboardText() => device.GetClipboardText();
        public void SetClipboardText(string value) => device.SetClipboardText(value);
    }
}
