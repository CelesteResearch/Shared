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
    public interface ISourceCommandsBuiltinProcess : ISourceCommandsProcess
    {
        SourceGraphicsDeviceManager Graphics { get; }
        ISourceSceneDiagnostics Scene { get; }
        SourceEntityPoolRegistry Pooler { get; }
        ISourceLogicalTypeNameMetadata SceneMetadata { get; }
        void Exit();
        void SetFullscreen();
        void SetWindowed(int width, int height);
    }
}
