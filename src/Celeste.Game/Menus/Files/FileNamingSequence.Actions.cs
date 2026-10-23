using Celeste.Game.Content.Dialogs;
using Celeste.Input.Devices.GamePads;

namespace Celeste.Game.Menus.Files
{
    public partial class FileNamingSequence
    {
        protected void ResetDefaultName()
        {
            if (StartingName == Settings.DefaultFileName ||
                StartingName == ((IOriginalGameTextEnvironment)SourceEngine).Text.CleanDialog("FILE_DEFAULT"))
                StartingName = Name;

            Settings.DefaultFileName = Name;
            Process.AudioSession.Play("event:/new_content/ui/rename_entry_accept_locked");
        }

        private void Space()
        {
            if (Name.Length < MaxNameLength && Name.Length > 0)
            {
                Name += " ";
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
            if (Name.Length > 0)
            {
                Name = Name.Substring(0, Name.Length - 1);
                Process.AudioSession.Play("event:/ui/main/rename_entry_backspace");
            }
            else
            {
                Process.AudioSession.Play("event:/ui/main/button_invalid");
            }
        }

        protected void Finish()
        {
            if (Name.Length >= 1)
            {
                if (MInput.GamePads.Length != 0 && MInput.GamePads[0] != null &&
                    (MInput.GamePads[0].Check(SourceGamePadButtonFlags.LeftTrigger) ||
                     MInput.GamePads[0].Check(SourceGamePadButtonFlags.LeftShoulder)) &&
                    (MInput.GamePads[0].Check(SourceGamePadButtonFlags.RightTrigger) ||
                     MInput.GamePads[0].Check(SourceGamePadButtonFlags.RightShoulder)))
                    ResetDefaultName();

                Focused = false;
                Overworld.Goto<FileSelectSequence>();
                Process.AudioSession.Play("event:/ui/main/rename_entry_accept");
            }
            else
            {
                Process.AudioSession.Play("event:/ui/main/button_invalid");
            }
        }

        private void SwapType()
        {
            hiragana = !hiragana;
            if (hiragana)
                ReloadLetters(((IOriginalGameTextEnvironment)SourceEngine).Text.CleanDialog("name_letters"));
            else
                ReloadLetters(((IOriginalGameTextEnvironment)SourceEngine).Text.CleanDialog("name_letters_katakana"));
        }

        protected void Cancel()
        {
            FileSlot.Name = StartingName;
            Focused = false;
            Overworld.Goto<FileSelectSequence>();
            Process.AudioSession.Play("event:/ui/main/button_back");
        }
    }
}
