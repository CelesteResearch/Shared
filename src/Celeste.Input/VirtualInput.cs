namespace Celeste.Input
{
    public abstract class VirtualInput
    {
        public enum OverlapBehaviors
        {
            CancelOut,
            TakeOlder,
            TakeNewer,
        }

        public InputContext Context = new();
        public abstract void Update();
    }
}
