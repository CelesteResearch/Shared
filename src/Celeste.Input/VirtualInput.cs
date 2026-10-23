using System;
using System.Numerics;

namespace Celeste.Input
{
    public abstract class VirtualInput
    {
        public enum OverlapBehaviors
        {
            CancelOut,
            TakeOlder,
            TakeNewer
        }

        public InputContext Context = new InputContext();
        public abstract void Update();
    }
}
