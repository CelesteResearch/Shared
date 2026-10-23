using Celeste.Input.Bindings;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Devices.Text;

namespace Celeste.Framework.Startup
{
    public partial class SourceGameProcess
    {
        public void OnPhysicalKeyDown(SourceFnaKeyboardStateProcess keyboard,
            SourceFnaTextInputBindings bindings, SourceFnaTextInputEvents textInput,
            SourceKeys key, byte repeat)
        {
            SourceSDLKeyboardEvents.KeyDown(keyboard, bindings, textInput, key, repeat,
                textInputControlDown, ref textInputSuppress);
        }

        public void OnPhysicalKeyUp(SourceFnaKeyboardStateProcess keyboard,
            SourceFnaTextInputBindings bindings, SourceKeys key)
        {
            SourceSDLKeyboardEvents.KeyUp(keyboard, bindings, key,
                textInputControlDown, ref textInputSuppress);
        }

        public bool SuppressPhysicalTextInput => textInputSuppress;
    }
}
