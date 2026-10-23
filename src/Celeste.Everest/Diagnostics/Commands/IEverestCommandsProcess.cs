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
    public interface IEverestCommandsProcess : ISourceCommandsProcess, ISourceVectorEnvironment,
        ISourceFnaInputEnvironment,
        IEverestLoggerProcessEnvironment
    {
        IEverestCommandsSettings Settings { get; }
        EverestTextInputProcess TextInput { get; }
        object Scene { get; }
        IOriginalAreaKeyPolicy AreaKeys { get; }
        IntRect Viewport { get; }
        int Width { get; }
        IEnumerable<IOriginalAreaData> Areas { get; }
        Lazy<bool> CelesteTASInstalled { get; }
    }
}
