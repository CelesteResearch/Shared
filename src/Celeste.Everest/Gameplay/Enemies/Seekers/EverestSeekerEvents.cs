using System;

namespace Celeste.Everest.Gameplay.Enemies.Seekers
{
    public sealed class EverestSeekerEvents
    {
        public event Action<EverestSeekerState> OnRegisterStates;
        internal void RegisterStates(EverestSeekerState seeker) => OnRegisterStates?.Invoke(seeker);
    }
}
