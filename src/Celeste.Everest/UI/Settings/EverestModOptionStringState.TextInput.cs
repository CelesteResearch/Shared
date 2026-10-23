namespace Celeste.Everest.UI.Settings
{
    public partial class EverestModOptionStringState
    {
        public void OnTextInput(char c)
        {
            switch (c)
            {
                case '\r':
                    Finish();
                    return;
                case '\b':
                    Backspace();
                    return;
                case '\u0016':
                {
                    var text = Value + TextInput.GetClipboardText();
                    if (text.Length > MaxValueLength) text = text.Substring(0, MaxValueLength);

                    Value = text;
                    return;
                }
                case ' ':
                    if (Value.Length < MaxValueLength)
                    {
                        Process.AudioSession.Play("event:/ui/main/rename_entry_space");
                        Value += c;
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
                if (Value.Length < MaxValueLength && ActiveFont.Font.Get(ActiveFont.BaseSize).Characters.ContainsKey(c))
                {
                    Process.AudioSession.Play("event:/ui/main/rename_entry_char");
                    Value += c;
                }
                else
                {
                    Process.AudioSession.Play("event:/ui/main/button_invalid");
                }
            }
        }
    }
}
