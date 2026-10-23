using System;

namespace Celeste.Game.Gameplay.Enemies.AngryOshiro
{
    public interface IOriginalAngryOshiroStateEvents
    {
        event Action<OriginalAngryOshiroState> OnRegisterStates;
        void RegisterStates(OriginalAngryOshiroState actualActor);
    }
}
