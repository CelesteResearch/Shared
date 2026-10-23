using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Reflection;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Input.Devices.Keyboard;

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
