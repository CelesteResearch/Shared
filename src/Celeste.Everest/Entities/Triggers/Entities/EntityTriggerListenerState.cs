using System;
using Celeste.Core.Components;

namespace Celeste.Everest.Entities.Triggers.Entities
{
    public class EntityTriggerListenerState : SourceComponentState
    {
        public Action OnTrigger;
        public Action OnStartTriggered;

        public EntityTriggerListenerState(Action onTrigger, Action onStartTriggered) : base(false, false)
        {
            OnTrigger = onTrigger;
            OnStartTriggered = onStartTriggered;
        }
    }
}
