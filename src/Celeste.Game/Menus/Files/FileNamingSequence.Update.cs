using System;
using System.Linq;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Gameplay;

namespace Celeste.Game.Menus.Files
{
    public partial class FileNamingSequence
    {
        public override void Update()
        {
            base.Update();
            if (Selected && Focused)
            {
                if (!string.IsNullOrWhiteSpace(Name) && MInput.Keyboard.Check(SourceKeys.LeftControl) &&
                    MInput.Keyboard.Pressed(SourceKeys.S))
                    ResetDefaultName();

                if (Input[GameAction.MenuJournal].Pressed && Japanese) SwapType();

                if (Input[GameAction.MenuRight].Pressed && (optionsIndex < 3 || !selectingOptions) &&
                    (Name.Length > 0 || !selectingOptions))
                {
                    if (selectingOptions)
                        optionsIndex = Math.Min(optionsIndex + 1, 3);
                    else
                        do
                        {
                            index = (index + 1) % letters[line].Length;
                        } while (letters[line][index] == ' ');

                    wiggler.Start();
                    Process.AudioSession.Play("event:/ui/main/rename_entry_rollover");
                }
                else if (Input[GameAction.MenuLeft].Pressed && (optionsIndex > 0 || !selectingOptions))
                {
                    if (selectingOptions)
                        optionsIndex = Math.Max(optionsIndex - 1, 0);
                    else
                        do
                        {
                            index = (index + letters[line].Length - 1) % letters[line].Length;
                        } while (letters[line][index] == ' ');

                    wiggler.Start();
                    Process.AudioSession.Play("event:/ui/main/rename_entry_rollover");
                }
                else if (Input[GameAction.MenuDown].Pressed && !selectingOptions)
                {
                    var num = line + 1;
                    while (true)
                    {
                        if (num >= letters.Length)
                        {
                            selectingOptions = true;
                            break;
                        }

                        if (index < letters[num].Length && letters[num][index] != ' ')
                        {
                            line = num;
                            break;
                        }

                        num++;
                    }

                    if (selectingOptions)
                    {
                        var num2 = index * widestLetter;
                        var num3 = boxWidth - boxPadding * 2f;
                        if (Name.Length == 0 || num2 < cancelWidth +
                            (num3 - cancelWidth - beginWidth - backspaceWidth - spaceWidth - widestLetter * 3f) / 2f)
                            optionsIndex = 0;
                        else if (num2 < num3 - beginWidth - backspaceWidth - widestLetter * 2f)
                            optionsIndex = 1;
                        else if (num2 < num3 - beginWidth - widestLetter)
                            optionsIndex = 2;
                        else
                            optionsIndex = 3;
                    }

                    wiggler.Start();
                    Process.AudioSession.Play("event:/ui/main/rename_entry_rollover");
                }
                else if ((Input[GameAction.MenuUp].Pressed ||
                          (selectingOptions && Name.Length <= 0 && optionsIndex > 0)) &&
                         (line > 0 || selectingOptions))
                {
                    if (selectingOptions)
                    {
                        line = letters.Length;
                        selectingOptions = false;
                        var num4 = boxWidth - boxPadding * 2f;
                        if (optionsIndex == 0)
                            index = (int)(cancelWidth / 2f / widestLetter);
                        else if (optionsIndex == 1)
                            index = (int)((num4 - beginWidth - backspaceWidth - spaceWidth / 2f - widestLetter * 2f) /
                                          widestLetter);
                        else if (optionsIndex == 2)
                            index = (int)((num4 - beginWidth - backspaceWidth / 2f - widestLetter) / widestLetter);
                        else if (optionsIndex == 3) index = (int)((num4 - beginWidth / 2f) / widestLetter);
                    }

                    line--;
                    while (line > 0 && (index >= letters[line].Length || letters[line][index] == ' ')) line--;

                    while (index >= letters[line].Length || letters[line][index] == ' ') index--;

                    wiggler.Start();
                    Process.AudioSession.Play("event:/ui/main/rename_entry_rollover");
                }
                else if (Input[GameAction.MenuConfirm].Pressed)
                {
                    if (selectingOptions)
                    {
                        if (optionsIndex == 0)
                            Cancel();
                        else if (optionsIndex == 1 && Name.Length > 0)
                            Space();
                        else if (optionsIndex == 2)
                            Backspace();
                        else if (optionsIndex == 3) Finish();
                    }
                    else if (Japanese && letters[line][index] == '\u309b' && Name.Length > 0 &&
                             dakuten_able.Contains(Name.Last()))
                    {
                        int num5 = Name[Name.Length - 1];
                        num5++;
                        Name = Name.Substring(0, Name.Length - 1);
                        Name += (char)num5;
                        wiggler.Start();
                        Process.AudioSession.Play("event:/ui/main/rename_entry_char");
                    }
                    else if (Japanese && letters[line][index] == '\u309c' && Name.Length > 0 &&
                             (handakuten_able.Contains(Name.Last()) || handakuten_able.Contains(Name.Last() + 1)))
                    {
                        int num6 = Name[Name.Length - 1];
                        num6 = !handakuten_able.Contains(num6) ? num6 + 2 : num6 + 1;
                        Name = Name.Substring(0, Name.Length - 1);
                        Name += (char)num6;
                        wiggler.Start();
                        Process.AudioSession.Play("event:/ui/main/rename_entry_char");
                    }
                    else if (Name.Length < MaxNameLength)
                    {
                        Name += letters[line][index];
                        wiggler.Start();
                        Process.AudioSession.Play("event:/ui/main/rename_entry_char");
                    }
                    else
                    {
                        Process.AudioSession.Play("event:/ui/main/button_invalid");
                    }
                }
                else if (Input[GameAction.MenuCancel].Pressed)
                {
                    if (Name.Length > 0)
                        Backspace();
                    else
                        Cancel();
                }
                else if (Input[GameAction.Pause].Pressed)
                {
                    Finish();
                }
            }

            pressedTimer -= SourceEngine.Frame.DeltaTime;
            timer += SourceEngine.Frame.DeltaTime;
            wiggler.Update();
        }
    }
}
