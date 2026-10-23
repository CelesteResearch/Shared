using System;

namespace Celeste.Core.Framework.Timing
{
    public class SourceGameRunLoop(
        SourceGameLoopState state,
        SourceGameTickKernel tick,
        ISourceGameLoopDevice device,
        object actualGame)
    {
        // ReSharper disable once ReplaceWithPrimaryConstructorParameter
        private readonly SourceGameLoopState _state = state;

        // ReSharper disable once ReplaceWithPrimaryConstructorParameter
        private readonly SourceGameTickKernel _tick = tick;

        // ReSharper disable once ReplaceWithPrimaryConstructorParameter
        private readonly ISourceGameLoopDevice _device = device;

        // ReSharper disable once ReplaceWithPrimaryConstructorParameter
        private readonly object _actualGame = actualGame;


        public void Tick()
        {
            _tick.Tick();
        }

        public void RunLoop()
        {
            if (_tick.UsesHostFrameScheduling)
                throw new InvalidOperationException("A host-scheduled game must tick from its host callbacks.");
            if (_device.NeedsPlatformMainLoop()) _device.RunPlatformMainLoop(this);
            while (_state.RunApplication) Tick();
            OnExiting(_actualGame, EventArgs.Empty);
        }

        protected virtual void OnExiting(object sender, EventArgs args)
        {
            // FNA sends the actual Game instance rather than forwarding sender.
            _state.OnExiting(_actualGame, args);
        }
    }
}
