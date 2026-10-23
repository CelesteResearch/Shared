using Celeste.Input.Devices.Touch;
using Celeste.Input.Devices.Mouse;
using System;
using Celeste.Core.Mathematics;

namespace Celeste.Input.Runtime
{
    public interface ISourceFnaInputEnvironment
    {
        SourceFnaInputProcess FnaInput { get; }
    }
}
