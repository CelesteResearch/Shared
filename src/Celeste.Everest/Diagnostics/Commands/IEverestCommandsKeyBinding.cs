using Celeste.Input.Runtime;
using Celeste.Input.Devices.Keyboard;
using System;
using System.Numerics;
using System.Collections.Generic;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Game.Execution.Areas;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Runtime.Input;

namespace Celeste.Everest.Diagnostics.Commands
{
    public interface IEverestCommandsKeyBinding
    {
        bool Pressed { get; }
        List<SourceKeys> Keys { get; }
    }
}
