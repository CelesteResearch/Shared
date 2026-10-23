using Celeste.Framework.Startup;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Everest.Framework.Startup
{
    public sealed class EverestSourceGameBeforeLoopPolicy : ISourceGameBeforeLoopPolicy
    {
        private readonly ISourceWindowFocusDevice device;
        public EverestSourceGameBeforeLoopPolicy(ISourceWindowFocusDevice device) => this.device = device;

        public void AfterOriginalBeforeLoop(SourceGameWindow window)
        {
            if (!(device.GetEnvironmentVariable("EVEREST_SKIP_REQUEST_FOCUS_AFTER_SPLASH") == "1"))
            {
                device.SetHint("SDL_HINT_FORCE_RAISEWINDOW", "true");
                device.RaiseWindow(window.Handle);
            }
        }
    }
}
