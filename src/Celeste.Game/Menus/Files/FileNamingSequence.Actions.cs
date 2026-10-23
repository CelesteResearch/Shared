using Celeste.Input.Devices.GamePads;
using System;
using System.Collections;
using System.Linq;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Timing;
using Celeste.Input.Gameplay;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Settings;
using Celeste.Scene.Components.Oscillation;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;

namespace Celeste.Game.Menus.Files
{
    public partial class FileNamingSequence
    {
        protected void ResetDefaultName()
        {
            if (StartingName == Settings.DefaultFileName ||
                StartingName == ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("FILE_DEFAULT"))
            {
                StartingName = Name;
            }

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
                {
                    ResetDefaultName();
                }

                Focused = false;
                base.Overworld.Goto<FileSelectSequence>();
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
            {
                ReloadLetters(((IOriginalGameTextEnvironment)engine).Text.CleanDialog("name_letters"));
            }
            else
            {
                ReloadLetters(((IOriginalGameTextEnvironment)engine).Text.CleanDialog("name_letters_katakana"));
            }
        }

        protected void Cancel()
        {
            FileSlot.Name = StartingName;
            Focused = false;
            base.Overworld.Goto<FileSelectSequence>();
            Process.AudioSession.Play("event:/ui/main/button_back");
        }
    }
}
