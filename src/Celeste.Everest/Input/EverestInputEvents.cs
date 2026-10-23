using System;

namespace Celeste.Everest.Input
{
    public sealed class EverestInputEvents
    {
        public event Action OnInitialize;
        public event Action OnDeregister;
        public void Initialize() => OnInitialize?.Invoke();
        public void Deregister() => OnDeregister?.Invoke();
    }
}
