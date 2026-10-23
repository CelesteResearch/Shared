using Celeste.Input.Devices.Text;
using System;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private SourceFnaTextInputEvents sourceTextInput;

        public SourceFnaTextInputEvents TextInput => sourceTextInput ??
                                                     throw new InvalidOperationException(
                                                         "The actual text input events are not constructed.");

        public void ConstructSourceTextInputEvents()
        {
            if (sourceTextInput != null)
                throw new InvalidOperationException("The actual text input events are already constructed.");
            sourceTextInput = new SourceFnaTextInputEvents(PhysicalIO.TextInputPlatform);
        }
    }
}
