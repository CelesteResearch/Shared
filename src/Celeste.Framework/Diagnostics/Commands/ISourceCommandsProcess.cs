using Celeste.Input.Devices.Keyboard;
using Celeste.Core.Reflection;
using Celeste.Core.Diagnostics;
using Celeste.Core.Pooling;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Framework.Diagnostics.Commands
{
    public interface ISourceCommandsProcess : ISourceDrawScope, ISourceVectorEnvironment
    {
        SourceCommands Commands { get; }
        ISourceCommandsKeyboard Keyboard { get; }
        SourceKeyboardState ReadKeyboardState();
        float DeltaTime { get; }
        float RawDeltaTime { get; }
        IntRect WindowClientBounds { get; }
        int ViewWidth { get; }
        int ViewHeight { get; }
        ISourceAssemblyMetadata CommandsCallingAssembly { get; }
        ISourceAssemblyMetadata CommandsEntryAssembly { get; }
    }
}
