using System.Runtime.CompilerServices;
using Celeste.Core.Display;

namespace Celeste.Simulation.Gameplay.Hazards.Lightning
{
    public sealed partial class LightningRendererState
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public new void Reset() => base.Reset();

        protected override PackedColor BufferClearColor
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get => base.BufferClearColor;
        }
    }
}
