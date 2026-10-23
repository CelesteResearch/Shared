using Celeste.Input.Runtime;
using Celeste.Input.Bindings;

namespace Celeste.Everest.Input
{
    public sealed class InstalledSourceVirtualInputPolicy : ISourceVirtualInputPolicy
    {
        public void Register(SourceMInputProcess process, SourceVirtualInput input)
        {
            lock (process.GetVirtualInputsForSynchronization()) process.RegisterVirtualInputCore(input);
        }

        public void Deregister(SourceMInputProcess process, SourceVirtualInput input)
        {
            lock (process.GetVirtualInputsForSynchronization()) process.DeregisterVirtualInputCore(input);
        }

        public void Update(SourceMInputProcess process)
        {
            lock (process.GetVirtualInputsForSynchronization()) process.UpdateVirtualInputsCore();
        }
    }
}
