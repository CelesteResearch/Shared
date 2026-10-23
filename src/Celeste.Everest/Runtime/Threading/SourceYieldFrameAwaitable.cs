using System;
using System.Runtime.CompilerServices;

namespace Celeste.Everest.Runtime.Threading
{
    public readonly struct SourceYieldFrameAwaitable
    {
        private readonly EverestMainThreadProcess process;

        internal SourceYieldFrameAwaitable(EverestMainThreadProcess process)
        {
            this.process = process;
        }

        public SourceYieldFrameAwaiter GetAwaiter()
        {
            return new(process);
        }

        public readonly struct SourceYieldFrameAwaiter : INotifyCompletion
        {
            private readonly EverestMainThreadProcess process;

            internal SourceYieldFrameAwaiter(EverestMainThreadProcess process)
            {
                this.process = process;
            }

            public bool IsCompleted => false;

            public void GetResult()
            {
            }

            public void OnCompleted(Action continuation)
            {
                process.Schedule(continuation, true);
            }
        }
    }
}
