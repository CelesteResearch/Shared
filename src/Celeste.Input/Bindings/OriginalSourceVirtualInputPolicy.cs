using Celeste.Input.Runtime;

namespace Celeste.Input.Bindings
{
    public sealed class OriginalSourceVirtualInputPolicy : ISourceVirtualInputPolicy
    {
        public void Register(SourceMInputProcess process, SourceVirtualInput input) =>
            process.RegisterVirtualInputCore(input);

        public void Deregister(SourceMInputProcess process, SourceVirtualInput input) =>
            process.DeregisterVirtualInputCore(input);

        public void Update(SourceMInputProcess process) => process.UpdateVirtualInputsCore();
    }
}
