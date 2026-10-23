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
        public override void Update()
        {
            bool flag = Focused;
            Focused = flag && !UseKeyboardInput;
            base.Update();
            if (base.Selected && Focused)
            {
                if (Input.MenuRight.Pressed && (optionsIndex < 3 || !selectingOptions) &&
                    (Value.Length > 0 || !selectingOptions))
                {
                    if (selectingOptions)
                    {
                        optionsIndex = Math.Min(optionsIndex + 1, 3);
                    }
                    else
                    {
                        do
                        {
                            index = (index + 1) % letters[line].Length;
                        } while (letters[line][index] == ' ');
                    }

                    wiggler.Start();
                    Process.AudioSession.Play("event:/ui/main/rename_entry_rollover");
                }
                else if (Input.MenuLeft.Pressed && (optionsIndex > 0 || !selectingOptions))
                {
                    if (selectingOptions)
                    {
                        optionsIndex = Math.Max(optionsIndex - 1, 0);
                    }
                    else
                    {
                        do
                        {
                            index = (index + letters[line].Length - 1) % letters[line].Length;
                        } while (letters[line][index] == ' ');
                    }

                    wiggler.Start();
                    Process.AudioSession.Play("event:/ui/main/rename_entry_rollover");
                }
                else if (Input.MenuDown.Pressed && !selectingOptions)
                {
                    int i = line + 1;
                    bool flag2 = true;
                    for (; i < letters.Length; i++)
                    {
                        if (index < letters[i].Length && letters[i][index] != ' ')
                        {
                            flag2 = false;
                            break;
                        }
                    }

                    if (flag2)
                    {
                        selectingOptions = true;
                    }
                    else
                    {
                        line = i;
                    }

                    if (selectingOptions)
                    {
                        float num = (float)index * widestLetter;
                        float num2 = boxWidth - boxPadding * 2f;
                        if (Value.Length == 0 || num < cancelWidth +
                            (num2 - cancelWidth - beginWidth - backspaceWidth - spaceWidth - widestLetter * 3f) / 2f)
                        {
                            optionsIndex = 0;
                        }
                        else if (num < num2 - beginWidth - backspaceWidth - widestLetter * 2f)
                        {
                            optionsIndex = 1;
                        }
                        else if (num < num2 - beginWidth - widestLetter)
                        {
                            optionsIndex = 2;
                        }
                        else
                        {
                            optionsIndex = 3;
                        }
                    }

                    wiggler.Start();
                    Process.AudioSession.Play("event:/ui/main/rename_entry_rollover");
                }
                else if ((Input.MenuUp.Pressed || (selectingOptions && Value.Length <= 0 && optionsIndex > 0)) &&
                         (line > 0 || selectingOptions))
                {
                    if (selectingOptions)
                    {
                        line = letters.Length;
                        selectingOptions = false;
                        float num3 = boxWidth - boxPadding * 2f;
                        if (optionsIndex == 0)
                        {
                            index = (int)(cancelWidth / 2f / widestLetter);
                        }
                        else if (optionsIndex == 1)
                        {
                            index = (int)((num3 - beginWidth - backspaceWidth - spaceWidth / 2f - widestLetter * 2f) /
                                          widestLetter);
                        }
                        else if (optionsIndex == 2)
                        {
                            index = (int)((num3 - beginWidth - backspaceWidth / 2f - widestLetter) / widestLetter);
                        }
                        else if (optionsIndex == 3)
                        {
                            index = (int)((num3 - beginWidth / 2f) / widestLetter);
                        }
                    }

                    do
                    {
                        line--;
                    } while (line > 0 && (index >= letters[line].Length || letters[line][index] == ' '));

                    while (index >= letters[line].Length || letters[line][index] == ' ')
                    {
                        index--;
                    }

                    wiggler.Start();
                    Process.AudioSession.Play("event:/ui/main/rename_entry_rollover");
                }
                else if (Input.MenuConfirm.Pressed)
                {
                    if (selectingOptions)
                    {
                        if (optionsIndex == 0)
                        {
                            Cancel();
                        }
                        else if (optionsIndex == 1 && Value.Length > 0)
                        {
                            Space();
                        }
                        else if (optionsIndex == 2)
                        {
                            Backspace();
                        }
                        else if (optionsIndex == 3)
                        {
                            Finish();
                        }
                    }
                    else if (Value.Length < MaxValueLength)
                    {
                        Value += letters[line][index];
                        wiggler.Start();
                        Process.AudioSession.Play("event:/ui/main/rename_entry_char");
                    }
                    else
                    {
                        Process.AudioSession.Play("event:/ui/main/button_invalid");
                    }
                }
                else if (Input.MenuCancel.Pressed)
                {
                    if (Value.Length > 0)
                    {
                        Backspace();
                    }
                    else
                    {
                        Cancel();
                    }
                }
                else if (Input.Pause.Pressed)
                {
                    Finish();
                }
            }

            if (flag && !Focused && (bool)Input.ESC)
            {
                Cancel();
                flag = false;
            }

            Focused = flag;
            pressedTimer -= engine.Frame.DeltaTime;
            timer += engine.Frame.DeltaTime;
            wiggler.Update();
        }
    }
}
