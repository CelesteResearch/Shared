using System.Collections.Generic;
using Celeste.Input.Devices.GamePads;

namespace Celeste.Input.Devices.Keyboard
{
    public class SourceFnaKeyboardStateProcess
    {
        protected readonly ISourceKeyboardDevice device;
        public List<SourceKeys> Keys;

        public SourceFnaKeyboardStateProcess(ISourceKeyboardDevice device) : this(device, true)
        {
        }

        protected SourceFnaKeyboardStateProcess(ISourceKeyboardDevice device, bool initializeKeys)
        {
            this.device = device;
            if (initializeKeys)
                Keys = [];
        }

        public virtual SourceKeyboardState GetState()
        {
            return new(Keys);
        }

        public virtual SourceKeyboardState GetState(SourcePlayerIndex playerIndex)
        {
            return new(Keys);
        }

        public SourceKeys GetKeyFromScancodeEXT(SourceKeys scancode)
        {
            return device.GetKeyFromScancode(scancode);
        }

        protected static void SetKey(ref SourceKeyboardState state, SourceKeys key)
        {
            state.SetKey(key);
        }
    }
}
