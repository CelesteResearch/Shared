using System;
using System.Reflection;

namespace Celeste.Everest.Modules.Runtime
{
    public interface ISourceBootDetourEnvironment
    {
        ISourceBootDetourRuntime BootDetourRuntime { get; }
        ISourceBootDetourFrameIdentity BootDetourFrameIdentity { get; }
        global::Celeste.Everest.Runtime.Compatibility.EverestMonoModPoliceProcess MonoModPolice { get; }
    }
}
