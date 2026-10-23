using Celeste.Input.Runtime;
using JetBrains.Annotations;

namespace Celeste.Input.Bindings
{
    public abstract class SourceVirtualInput
    {
        public enum OverlapBehaviors
        {
            CancelOut,
            TakeOlder,
            TakeNewer,
        }

        public enum ThresholdModes
        {
            LargerThan,
            LessThan,
            EqualTo,
        }

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly SourceMInputProcess process;

        protected SourceMInputProcess Process => process;

        protected SourceVirtualInput(SourceMInputProcess process)
        {
            this.process = process;
            process.VirtualInputPolicy.Register(process, this);
        }

        public void Deregister()
        {
            process.VirtualInputPolicy.Deregister(process, this);
        }

        public abstract void Update();
    }
}
