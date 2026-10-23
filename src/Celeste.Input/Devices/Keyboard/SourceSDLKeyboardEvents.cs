using Celeste.Input.Bindings;
using Celeste.Input.Devices.Text;

namespace Celeste.Input.Devices.Keyboard
{
    public static class SourceSDLKeyboardEvents
    {
        public static void KeyDown(SourceFnaKeyboardStateProcess keyboard,
            SourceFnaTextInputBindings bindings, SourceFnaTextInputEvents textInput,
            SourceKeys key, byte repeat, bool[] textInputControlDown, ref bool textInputSuppress)
        {
            if (!keyboard.Keys.Contains(key))
            {
                keyboard.Keys.Add(key);
                if (bindings.TextInputBindings.TryGetValue(key, out var value))
                {
                    textInputControlDown[value] = true;
                    textInput.OnTextInput(bindings.TextInputCharacters[value]);
                }
                else if ((keyboard.Keys.Contains(SourceKeys.LeftControl) ||
                          keyboard.Keys.Contains(SourceKeys.RightControl)) && key == SourceKeys.V)
                {
                    textInputControlDown[6] = true;
                    textInput.OnTextInput(bindings.TextInputCharacters[6]);
                    textInputSuppress = true;
                }
            }
            else if (repeat > 0)
            {
                if (bindings.TextInputBindings.TryGetValue(key, out var value))
                    textInput.OnTextInput(bindings.TextInputCharacters[value]);
                else if ((keyboard.Keys.Contains(SourceKeys.LeftControl) ||
                          keyboard.Keys.Contains(SourceKeys.RightControl)) && key == SourceKeys.V)
                    textInput.OnTextInput(bindings.TextInputCharacters[6]);
            }
        }

        public static void KeyUp(SourceFnaKeyboardStateProcess keyboard,
            SourceFnaTextInputBindings bindings, SourceKeys key,
            bool[] textInputControlDown, ref bool textInputSuppress)
        {
            if (keyboard.Keys.Remove(key))
            {
                if (bindings.TextInputBindings.TryGetValue(key, out var value))
                {
                    textInputControlDown[value] = false;
                }
                else if ((!keyboard.Keys.Contains(SourceKeys.LeftControl) &&
                          !keyboard.Keys.Contains(SourceKeys.RightControl) && textInputControlDown[6]) ||
                         key == SourceKeys.V)
                {
                    textInputControlDown[6] = false;
                    textInputSuppress = false;
                }
            }
        }
    }
}
