using Celeste.Input.Runtime;

namespace Celeste.Input.Bindings
{
    public interface ISourceVirtualInputPolicy
    {
        void Register(SourceMInputProcess process, SourceVirtualInput input);
        void Deregister(SourceMInputProcess process, SourceVirtualInput input);
        void Update(SourceMInputProcess process);
    }
}
