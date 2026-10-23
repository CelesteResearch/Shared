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
                this.OnExit?.Invoke(obj: true);
                this.OnExit = null;
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
            this.OnExit?.Invoke(obj: false);
            this.OnExit = null;
            Process.AudioSession.Play("event:/ui/main/button_back");
        }
    }
}
