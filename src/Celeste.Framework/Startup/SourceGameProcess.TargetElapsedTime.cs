using System;
using System.Runtime.CompilerServices;

namespace Celeste.Framework.Startup
{
    public partial class SourceGameProcess
    {
        public TimeSpan TargetElapsedTime
        {
            get => Timing.TargetElapsedTime;
            [MethodImpl(MethodImplOptions.NoInlining)]
            set => Timing.TargetElapsedTime = value;
        }
    }
}
