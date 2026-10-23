using System;

namespace Celeste.Everest.Runtime.Startup
{
    public sealed class EverestGameLoaderEvents
    {
        public event Action OnLoadThread;
        public void LoadThread() => OnLoadThread?.Invoke();
    }
}
