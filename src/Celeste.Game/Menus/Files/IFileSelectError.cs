using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Game.Menus.Files
{
    public interface IFileSelectError
    {
        bool Open { get; }
        bool Ignore { get; }
    }
}
