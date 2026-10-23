using Celeste.Input.Devices.Keyboard;
using System;
using System.Collections;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Timing;
using Celeste.Everest.Runtime.Input;
using Celeste.Input.Gameplay;
using Celeste.Game.Menus.Files;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Startup;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Graphics.Display;

namespace Celeste.Everest.UI.Settings
{
    public partial class EverestFileNamingState
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void Update()
        {
            bool focused = Focused;
            Focused = focused && !UseKeyboardInput;
            if (base.Selected && focused && !Focused && !string.IsNullOrWhiteSpace(Name) &&
                MInput.Keyboard.Check(SourceKeys.LeftControl) && MInput.Keyboard.Pressed(SourceKeys.S))
            {
                ResetDefaultName();
            }

            base.Update();
            if (focused && !Focused && Input[GameAction.Escape].Check)
            {
                Cancel();
            }

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
