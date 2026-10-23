using Celeste.Input.Devices.GamePads;
using System.Collections.Generic;

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
                Keys = new List<SourceKeys>();
        }

        public virtual SourceKeyboardState GetState() => new SourceKeyboardState(Keys);
        public virtual SourceKeyboardState GetState(SourcePlayerIndex playerIndex) => new SourceKeyboardState(Keys);
        public SourceKeys GetKeyFromScancodeEXT(SourceKeys scancode) => device.GetKeyFromScancode(scancode);
        protected static void SetKey(ref SourceKeyboardState state, SourceKeys key) => state.SetKey(key);
    }
}
