using Celeste.Input.Runtime;

namespace Celeste.Everest.Input
{
    public abstract class SourceVirtualInputNode
    {
        protected readonly SourceMInputProcess Process;

        protected SourceVirtualInputNode(SourceMInputProcess process)
        {
            Process = process;
        }

        public virtual void Update()
        {
        }
    }
}
