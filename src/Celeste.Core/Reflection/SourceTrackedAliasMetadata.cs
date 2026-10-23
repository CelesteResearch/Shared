namespace Celeste.Core.Reflection
{
    public readonly struct SourceTrackedAliasMetadata
    {
        public readonly string Identity;
        public readonly bool Inherited;

        // ReSharper disable once ConvertToPrimaryConstructor
        public SourceTrackedAliasMetadata(string identity, bool inherited)
        {
            Identity = identity;
            Inherited = inherited;
        }
    }
}
