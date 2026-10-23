using System;
using Celeste.Core.Components;

namespace Celeste.Simulation
{
    public sealed class RoomTransitionListener : SourceComponentState
    {
        public Action OnInBegin;
        public Action OnInEnd;
        public Action<float> OnIn;
        public Action OnOutBegin;
        public Action<float> OnOut;

        public RoomTransitionListener() : base(false, false)
        {
        }

        public void AddTo(SourceOwnedComponentList components)
        {
            components.Add(this);
        }
    }
}
