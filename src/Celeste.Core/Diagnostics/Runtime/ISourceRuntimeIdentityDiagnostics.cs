namespace Celeste.Core.Diagnostics.Runtime
{
    public interface ISourceRuntimeIdentityDiagnostics
    {
        SourceRuntimeIdentifierAvailability RuntimeIdentifierAvailability { get; }
        string RuntimeIdentifier { get; }
    }
}
