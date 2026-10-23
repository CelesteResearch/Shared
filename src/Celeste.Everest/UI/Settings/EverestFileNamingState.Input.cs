using System.Runtime.CompilerServices;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Gameplay;

namespace Celeste.Everest.UI.Settings
{
    public partial class EverestFileNamingState
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void Update()
        {
            var focused = Focused;
            Focused = focused && !UseKeyboardInput;
            if (Selected && focused && !Focused && !string.IsNullOrWhiteSpace(Name) &&
                MInput.Keyboard.Check(SourceKeys.LeftControl) && MInput.Keyboard.Pressed(SourceKeys.S))
                ResetDefaultName();

            base.Update();
            if (focused && !Focused && Input[GameAction.Escape].Check) Cancel();

            Focused = focused;
        }

        public void OnTextInput(char c)
        {
            switch (c)
            {
                case '\r':
                    Finish();
                    return;
                case '\b':
                    if (Name.Length > 0)
                    {
                        Name = Name.Substring(0, Name.Length - 1);
                        Process.AudioSession.Play("event:/ui/main/rename_entry_backspace");
                    }
                    else
                    {
                        Process.AudioSession.Play("event:/ui/main/button_invalid");
                    }

                    return;
                case ' ':
                    if (Name.Length < 12 && Name.Length > 0)
                    {
                        Process.AudioSession.Play("event:/ui/main/rename_entry_space");
                        Name += c;
                    }
                    else
                    {
                        Process.AudioSession.Play("event:/ui/main/button_invalid");
                    }

                    return;
                case '\u007f':
                    return;
            }

            if (!char.IsControl(c))
            {
                if (Name.Length < 12 && ActiveFont.Font.Get(ActiveFont.BaseSize).Characters.ContainsKey(c))
                {
                    Process.AudioSession.Play("event:/ui/main/rename_entry_char");
                    Name += c;
                }
                else
                {
                    Process.AudioSession.Play("event:/ui/main/button_invalid");
                }
            }
        }
    }
}
