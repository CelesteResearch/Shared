using System;

namespace Celeste.Core.Framework.Timing
{
    public class SourceGameRunLoop
    {
        private readonly SourceGameLoopState state;
        private readonly SourceGameTickKernel tick;
        private readonly ISourceGameLoopDevice device;
        private readonly object actualGame;

        public SourceGameRunLoop(SourceGameLoopState state, SourceGameTickKernel tick,
            ISourceGameLoopDevice device, object actualGame)
        {
            this.state = state;
            this.tick = tick;
            this.device = device;
            this.actualGame = actualGame;
        }

        public void Tick() => tick.Tick();

        public void RunLoop()
        {
            if (tick.UsesHostFrameScheduling)
                throw new InvalidOperationException("A host-scheduled game must tick from its host callbacks.");
            if (device.NeedsPlatformMainLoop()) device.RunPlatformMainLoop(this);
            while (state.RunApplication) Tick();
            OnExiting(actualGame, EventArgs.Empty);
        }

        protected virtual void OnExiting(object sender, EventArgs args)
        {
            // FNA sends the actual Game instance rather than forwarding sender.
            state.OnExiting(actualGame, args);
        }
    }
}
