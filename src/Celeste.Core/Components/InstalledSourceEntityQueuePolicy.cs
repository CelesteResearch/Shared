namespace Celeste.Core.Components
{
    public sealed class InstalledSourceEntityQueuePolicy : ISourceEntityQueuePolicy
    {
        public bool RejectNullEntity => true;
    }
}
