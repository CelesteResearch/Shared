using System;
using Celeste.Core.Scheduling;
using System.IO;
using Celeste.Everest.Diagnostics.Logging;

namespace Celeste.Everest.Runtime.Startup
{
    public interface IEverestGamePathEnvironment
    {
        string PathGame { get; }
    }
}
