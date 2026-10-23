namespace Celeste.Everest.UI.Settings
{
    public partial class EverestModOptionStringState
    {
        private void Space()
        {
            if (Value.Length < MaxValueLength)
            {
                Value += " ";
                wiggler.Start();
                Process.AudioSession.Play("event:/ui/main/rename_entry_char");
            }
            else
            {
                Process.AudioSession.Play("event:/ui/main/button_invalid");
            }
        }

        private void Backspace()
        {
            if (Value.Length > 0)
            {
                Value = Value.Substring(0, Value.Length - 1);
                Process.AudioSession.Play("event:/ui/main/rename_entry_backspace");
            }
            else
            {
                Process.AudioSession.Play("event:/ui/main/button_invalid");
            }
        }

        private void Finish()
        {
            if (Value.Length >= MinValueLength)
            {
                Focused = false;
                OnExit?.Invoke(true);
                OnExit = null;
                Process.AudioSession.Play("event:/ui/main/rename_entry_accept");
            }
            else
            {
                Process.AudioSession.Play("event:/ui/main/button_invalid");
            }
        }

        private void Cancel()
        {
            Environment.ModOptionStringProcess.Cancelled = true;
            Value = StartingValue;
            Focused = false;
            OnExit?.Invoke(false);
            OnExit = null;
            Process.AudioSession.Play("event:/ui/main/button_back");
        }
    }
}
