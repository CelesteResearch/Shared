using System;

namespace Celeste.Everest.Runtime.Startup
{
    public interface IEverestCelesteVersionEnvironment
    {
        Version CelesteVersion { get; }
    }
}
