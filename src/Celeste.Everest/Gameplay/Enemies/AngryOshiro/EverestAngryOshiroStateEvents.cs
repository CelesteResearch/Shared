using System;
using Celeste.Game.Gameplay.Enemies.AngryOshiro;

namespace Celeste.Everest.Gameplay.Enemies.AngryOshiro
{
    public sealed class EverestAngryOshiroStateEvents : IOriginalAngryOshiroStateEvents
    {
        public event Action<OriginalAngryOshiroState> OnRegisterStates;

        public void RegisterStates(OriginalAngryOshiroState actualActor)
        {
            OnRegisterStates?.Invoke(actualActor);
        }
    }
}
