using Celeste.Everest.Runtime.Compatibility;

namespace Celeste.Everest.Modules.Runtime
{
    public interface ISourceBootDetourEnvironment
    {
        ISourceBootDetourRuntime BootDetourRuntime { get; }
        ISourceBootDetourFrameIdentity BootDetourFrameIdentity { get; }
        EverestMonoModPoliceProcess MonoModPolice { get; }
    }
}
