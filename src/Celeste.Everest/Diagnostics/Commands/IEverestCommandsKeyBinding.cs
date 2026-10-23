using System.Collections.Generic;
using Celeste.Input.Devices.Keyboard;

namespace Celeste.Everest.Diagnostics.Commands
{
    public interface IEverestCommandsKeyBinding
    {
        bool Pressed { get; }
        List<SourceKeys> Keys { get; }
    }
}
