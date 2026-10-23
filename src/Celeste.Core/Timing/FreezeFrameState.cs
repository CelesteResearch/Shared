using System;

namespace Celeste.Core.Timing
{
    public sealed class FreezeFrameState
    {
        public float FreezeRemaining;

        // Set by the owning scene adapter only while its input session is active.
        public Action FreezeFrameUpdate;
        public Func<bool> SuppressFreezeFrame;
        public bool FrozenThisFrame { get; private set; }

        public void BeginFrame(float raw)
        {
            FrozenThisFrame = FreezeRemaining > 0 && !(SuppressFreezeFrame?.Invoke() ?? false);
            if (FrozenThisFrame)
            {
                FreezeFrameUpdate?.Invoke();
                FreezeRemaining = Math.Max(FreezeRemaining - raw, 0);
            }
        }
    }
}
