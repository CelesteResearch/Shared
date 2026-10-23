using Celeste.Input.Devices.Keyboard;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Celeste.Core.Mathematics;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Graphics.Display;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Diagnostics.Commands
{
    public partial class SourceEverestCommands
    {
        public override void UpdateClosed()
        {
            if (installedListener)
            {
                installedListener = false;
                installed.TextInput.OnInput -= HandleChar;
            }

            if (!canOpen)
            {
                canOpen = true;
            }
            else if (installed.Settings.DebugConsole.Pressed || installed.Settings.ToggleDebugConsole.Pressed)
            {
                Open = true;
                currentState = process.ReadKeyboardState();
                if (!installedListener)
                {
                    installedListener = true;
                    installed.TextInput.OnInput += HandleChar;
                }

                if (!printedInfoMessage)
                {
                    Log(
                        "Use the 'help' command for a list of debug commands. Press Esc or use the 'q' command to close the console.");
                    printedInfoMessage = true;
                }
            }

            for (int i = 0; i < FunctionKeyActions.Length; i++)
            {
                if (process.Keyboard.Pressed((SourceKeys)(112 + i)))
                {
                    ExecuteFunctionKeyAction(i);
                }
            }
        }

        public override void UpdateOpen()
        {
            oldState = currentState;
            currentState = process.ReadKeyboardState();
            underscoreCounter += process.RawDeltaTime;
            while (underscoreCounter >= 0.5f)
            {
                underscoreCounter -= 0.5f;
                underscore = !underscore;
            }

            if (repeatKey.HasValue)
            {
                if (currentState[repeatKey.Value] == SourceKeyState.Down)
                {
                    repeatCounter += process.RawDeltaTime;
                    while (repeatCounter >= 0.5f)
                    {
                        HandleKey(repeatKey.Value);
                        repeatCounter -= 1f / 30f;
                    }
                }
                else
                {
                    repeatKey = null;
                }
            }

            SourceKeys[] pressedKeys = currentState.GetPressedKeys();
            foreach (SourceKeys key in pressedKeys)
            {
                if (oldState[key] == SourceKeyState.Up)
                {
                    HandleKey(key);
                    break;
                }
            }
        }

        protected override void HandleKey(SourceKeys key)
        {
            if (key == SourceKeys.Escape || installed.Settings.ToggleDebugConsole.Keys.Contains(key))
            {
                process.Keyboard.CurrentState = currentState;
                Open = (canOpen = false);
                return;
            }

            underscore = true;
            underscoreCounter = 0f;
            bool flag = currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down;
            bool flag2 = currentState[SourceKeys.LeftControl] == SourceKeyState.Down ||
                         currentState[SourceKeys.RightControl] == SourceKeyState.Down;
            if (key != SourceKeys.Tab && (uint)(key - 160) > 5u)
            {
                tabIndex = -1;
            }

            if (key != SourceKeys.Enter && (!repeatKey.HasValue || repeatKey != key))
            {
                repeatKey = key;
                repeatCounter = 0f;
            }

            int num;
            int num3;
            int num2;
            int num4;
            switch (key)
            {
                case SourceKeys.Enter:
                    if (currentText.Length > 0)
                    {
                        EnterCommand();
                    }

                    charIndex = currentText.Length;
                    seekIndex = -1;
                    break;
                case SourceKeys.Tab:
                    if (tabIndex == -1)
                    {
                        if (currentText.StartsWith("load ") || currentText.StartsWith("hard ") ||
                            currentText.StartsWith("rmx2 "))
                        {
                            tabPrefix = currentText.Substring(0, 5);
                            string startOfSid = currentText.Substring(5);
                            tabResults = (from area in installed.Areas
                                select area.SID
                                into sid
                                where sid.StartsWith(startOfSid, StringComparison.InvariantCultureIgnoreCase)
                                select sid).ToArray();
                        }
                        else
                        {
                            tabPrefix = "";
                            tabResults = sorted.Where((string cmd) =>
                                cmd.StartsWith(currentText, StringComparison.InvariantCultureIgnoreCase)).ToArray();
                        }

                        if (tabResults.Length == 0)
                        {
                            break;
                        }

                        tabIndex = (flag ? (tabResults.Length - 1) : 0);
                    }
                    else
                    {
                        int num5 = ((!flag) ? 1 : (-1));
                        tabIndex += num5;
                        if (tabIndex < 0)
                        {
                            tabIndex += tabResults.Length;
                        }

                        tabIndex %= tabResults.Length;
                    }

                    currentText = tabPrefix + tabResults[tabIndex];
                    charIndex = currentText.Length;
                    break;
                case SourceKeys.Right:
                    num = 1;
                    goto IL_0330;
                case SourceKeys.Left:
                    num = -1;
                    goto IL_0330;
                case SourceKeys.Back:
                    while (charIndex != 0)
                    {
                        bool flag3 = IsWordBoundary(charIndex - 1, forward: false);
                        currentText = currentText.Substring(0, Math.Max(charIndex - 1, 0)) +
                                      currentText.Substring(charIndex);
                        charIndex--;
                        if (!flag2 || flag3)
                        {
                            break;
                        }
                    }

                    break;
                case SourceKeys.Delete:
                    while (charIndex != currentText.Length)
                    {
                        bool flag3 = IsWordBoundary(charIndex + 1, forward: true);
                        currentText = currentText.Substring(0, charIndex) + currentText.Substring(charIndex + 1);
                        if (!flag2 || flag3)
                        {
                            break;
                        }
                    }

                    break;
                case SourceKeys.Home:
                    if (flag2)
                    {
                        firstLineIndexToDraw = Math.Max(drawCommands.Count - 1, 0);
                    }
                    else
                    {
                        charIndex = 0;
                    }

                    break;
                case SourceKeys.End:
                    if (flag2)
                    {
                        firstLineIndexToDraw = 0;
                    }
                    else
                    {
                        charIndex = currentText.Length;
                    }

                    break;
                case SourceKeys.Down:
                    num3 = -1;
                    goto IL_0491;
                case SourceKeys.Up:
                    num3 = 1;
                    goto IL_0491;
                case SourceKeys.C:
                    if (flag2 && currentText.Length > 0)
                    {
                        installed.TextInput.SetClipboardText(currentText);
                    }

                    break;
                case SourceKeys.V:
                    if (flag2)
                    {
                        string clipboardText = installed.TextInput.GetClipboardText();
                        if (clipboardText != null && clipboardText.Length > 0)
                        {
                            clipboardText = clipboardText.Replace("\n", " ");
                            currentText = currentText.Substring(0, charIndex) + clipboardText +
                                          currentText.Substring(charIndex);
                            charIndex = Math.Min(charIndex + clipboardText.Length, currentText.Length);
                        }
                    }

                    break;
                case SourceKeys.F1:
                case SourceKeys.F2:
                case SourceKeys.F3:
                case SourceKeys.F4:
                case SourceKeys.F5:
                case SourceKeys.F6:
                case SourceKeys.F7:
                case SourceKeys.F8:
                case SourceKeys.F9:
                case SourceKeys.F10:
                case SourceKeys.F11:
                case SourceKeys.F12:
                {
                    ExecuteFunctionKeyAction((int)(key - 112));
                    break;
                }
                    IL_0330:
                    num2 = num;
                    charIndex = ScalarMath.Clamp(charIndex + num2, 0, currentText.Length);
                    while (flag2 && !IsWordBoundary(charIndex, num2 == 1))
                    {
                        charIndex += num2;
                    }

                    break;
                    IL_0491:
                    num4 = num3;
                    if (flag2)
                    {
                        firstLineIndexToDraw = ScalarMath.Clamp(firstLineIndexToDraw + num4, 0,
                            Math.Max(drawCommands.Count - 1, 0));
                        break;
                    }

                    seekIndex = ScalarMath.Clamp(seekIndex + num4, -1, commandHistory.Count - 1);
                    currentText = ((seekIndex == -1) ? "" : commandHistory[seekIndex]);
                    charIndex = currentText.Length;
                    break;
            }
        }

        private void HandleChar(char key)
        {
            if (Open && !char.IsControl(key))
            {
                SourceKeyboardState keyboardState = process.ReadKeyboardState();
                if (!installed.Settings.ToggleDebugConsole.Keys.Any((SourceKeys k) => keyboardState.IsKeyDown(k)))
                {
                    currentText = currentText.Substring(0, charIndex) + key + currentText.Substring(charIndex);
                    charIndex++;
                }
            }
        }

        private bool IsWord(char ch)
        {
            if (!char.IsLetterOrDigit(ch) && ch != '_')
            {
                return ch == '-';
            }

            return true;
        }

        private bool IsWordBoundary(int idx, bool forward)
        {
            if (idx <= 0 || idx >= currentText.Length)
            {
                return true;
            }

            char ch = currentText[idx - 1];
            char ch2 = currentText[idx];
            bool flag = IsWord(ch);
            bool flag2 = IsWord(ch2);
            if (!(forward && flag) || flag2)
            {
                return !forward && !flag && flag2;
            }

            return true;
        }
    }
}
