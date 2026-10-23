using Celeste.Input.Devices.Keyboard;

namespace Celeste.Framework.Diagnostics.Commands
{
    public partial class SourceCommands
    {
        public virtual void UpdateClosed()
        {
            if (!canOpen)
            {
                canOpen = true;
            }
            else if (process.Keyboard.Pressed(SourceKeys.OemTilde, SourceKeys.Oem8))
            {
                Open = true;
                currentState = process.ReadKeyboardState();
            }

            for (var i = 0; i < FunctionKeyActions.Length; i++)
                if (process.Keyboard.Pressed((SourceKeys)(112 + i)))
                    ExecuteFunctionKeyAction(i);
        }

        public virtual void UpdateOpen()
        {
            oldState = currentState;
            currentState = process.ReadKeyboardState();
            underscoreCounter += process.DeltaTime;
            while (underscoreCounter >= 0.5f)
            {
                underscoreCounter -= 0.5f;
                underscore = !underscore;
            }

            if (repeatKey.HasValue)
            {
                if (currentState[repeatKey.Value] == SourceKeyState.Down)
                {
                    repeatCounter += process.DeltaTime;
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

            var pressedKeys = currentState.GetPressedKeys();
            foreach (var key in pressedKeys)
                if (oldState[key] == SourceKeyState.Up)
                {
                    HandleKey(key);
                    break;
                }
        }

        protected virtual void HandleKey(SourceKeys key)
        {
            if (key != SourceKeys.Tab && key != SourceKeys.LeftShift && key != SourceKeys.RightShift &&
                key != SourceKeys.RightAlt && key != SourceKeys.LeftAlt && key != SourceKeys.RightControl &&
                key != SourceKeys.LeftControl)
                tabIndex = -1;

            if (key != SourceKeys.OemTilde && key != SourceKeys.Oem8 && key != SourceKeys.Enter && repeatKey != key)
            {
                repeatKey = key;
                repeatCounter = 0f;
            }

            switch (key)
            {
                case SourceKeys.D1:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += "!";
                    else
                        currentText += "1";

                    return;
                case SourceKeys.D2:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += "@";
                    else
                        currentText += "2";

                    return;
                case SourceKeys.D3:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += "#";
                    else
                        currentText += "3";

                    return;
                case SourceKeys.D4:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += "$";
                    else
                        currentText += "4";

                    return;
                case SourceKeys.D5:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += "%";
                    else
                        currentText += "5";

                    return;
                case SourceKeys.D6:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += "^";
                    else
                        currentText += "6";

                    return;
                case SourceKeys.D7:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += "&";
                    else
                        currentText += "7";

                    return;
                case SourceKeys.D8:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += "*";
                    else
                        currentText += "8";

                    return;
                case SourceKeys.D9:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += "(";
                    else
                        currentText += "9";

                    return;
                case SourceKeys.D0:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += ")";
                    else
                        currentText += "0";

                    return;
                case SourceKeys.OemComma:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += "<";
                    else
                        currentText += ",";

                    return;
                case SourceKeys.OemPeriod:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += ">";
                    else
                        currentText += ".";

                    return;
                case SourceKeys.OemQuestion:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += "?";
                    else
                        currentText += "/";

                    return;
                case SourceKeys.OemSemicolon:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += ":";
                    else
                        currentText += ";";

                    return;
                case SourceKeys.OemQuotes:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += "\"";
                    else
                        currentText += "'";

                    return;
                case SourceKeys.OemBackslash:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += "|";
                    else
                        currentText += "\\";

                    return;
                case SourceKeys.OemOpenBrackets:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += "{";
                    else
                        currentText += "[";

                    return;
                case SourceKeys.OemCloseBrackets:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += "}";
                    else
                        currentText += "]";

                    return;
                case SourceKeys.OemMinus:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += "_";
                    else
                        currentText += "-";

                    return;
                case SourceKeys.OemPlus:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                        currentText += "+";
                    else
                        currentText += "=";

                    return;
                case SourceKeys.Space:
                    currentText += " ";
                    return;
                case SourceKeys.Back:
                    if (currentText.Length > 0) currentText = currentText.Substring(0, currentText.Length - 1);

                    return;
                case SourceKeys.Delete:
                    currentText = "";
                    return;
                case SourceKeys.Up:
                    if (seekIndex < commandHistory.Count - 1)
                    {
                        seekIndex++;
                        currentText = string.Join(" ", commandHistory[seekIndex]);
                    }

                    return;
                case SourceKeys.Down:
                    if (seekIndex > -1)
                    {
                        seekIndex--;
                        if (seekIndex == -1)
                        {
                            currentText = "";
                            return;
                        }

                        currentText = string.Join(" ", commandHistory[seekIndex]);
                    }

                    return;
                case SourceKeys.Tab:
                    if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                        currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                    {
                        if (tabIndex == -1)
                        {
                            tabSearch = currentText;
                            FindLastTab();
                        }
                        else
                        {
                            tabIndex--;
                            if (tabIndex < 0 || (tabSearch != "" && sorted[tabIndex].IndexOf(tabSearch) != 0))
                                FindLastTab();
                        }
                    }
                    else if (tabIndex == -1)
                    {
                        tabSearch = currentText;
                        FindFirstTab();
                    }
                    else
                    {
                        tabIndex++;
                        if (tabIndex >= sorted.Count || (tabSearch != "" && sorted[tabIndex].IndexOf(tabSearch) != 0))
                            FindFirstTab();
                    }

                    if (tabIndex != -1) currentText = sorted[tabIndex];

                    return;
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
                    ExecuteFunctionKeyAction((int)(key - 112));
                    return;
                case SourceKeys.Enter:
                    if (currentText.Length > 0) EnterCommand();

                    return;
                case SourceKeys.OemTilde:
                case SourceKeys.Oem8:
                    Open = canOpen = false;
                    return;
            }

            if (key.ToString().Length == 1)
            {
                if (currentState[SourceKeys.LeftShift] == SourceKeyState.Down ||
                    currentState[SourceKeys.RightShift] == SourceKeyState.Down)
                    currentText += key;
                else
                    currentText += key.ToString().ToLower();
            }
        }
    }
}
