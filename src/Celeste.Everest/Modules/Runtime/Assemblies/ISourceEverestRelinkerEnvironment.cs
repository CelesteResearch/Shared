namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    public interface ISourceEverestRelinkerEnvironment
    {
        string PathGame { get; }
        string PathCache { get; }
        string OriginalGameAssemblyPath { get; }
        ISourceRelinkPatcherRuntime PatcherRuntime { get; }
    }
}
