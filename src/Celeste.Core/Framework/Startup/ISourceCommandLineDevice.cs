using System;
using System.Collections.Generic;

namespace Celeste.Core.Framework.Startup
{
    public interface ISourceCommandLineDevice
    {
        string[] GetCommandLineArgs();
    }
}
