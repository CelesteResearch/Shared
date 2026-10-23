using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Timing;
using Celeste.Everest.Runtime.Input;
using Celeste.Input.Gameplay;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Processes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;

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
                    string text = Value + TextInput.GetClipboardText();
                    if (text.Length > MaxValueLength)
                    {
                        text = text.Substring(0, MaxValueLength);
                    }

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
