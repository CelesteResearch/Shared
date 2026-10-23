using Celeste.Core.Display;
using System;
using Celeste.Core.Geometry;
using Celeste.Core.Framework.Services;

namespace Celeste.Graphics.Rendering.Devices
{
    public interface ISourceGraphicsManagerGame
    {
        SourceGameServiceContainer Services { get; }
        ISourceGraphicsManagerWindow Window { get; }
    }
}
