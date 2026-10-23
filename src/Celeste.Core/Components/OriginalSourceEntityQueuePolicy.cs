namespace Celeste.Core.Components
{
    public sealed class OriginalSourceEntityQueuePolicy : ISourceEntityQueuePolicy
    {
        public bool RejectNullEntity => false;
    }
}
