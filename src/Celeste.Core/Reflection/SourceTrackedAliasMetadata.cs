namespace Celeste.Core.Reflection
{
    public readonly struct SourceTrackedAliasMetadata
    {
        public readonly string Identity;
        public readonly bool Inherited;

        public SourceTrackedAliasMetadata(string identity, bool inherited)
        {
            Identity = identity;
            Inherited = inherited;
        }
    }
}
