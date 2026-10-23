namespace Celeste.Core.IO
{
    public interface ISourceGameRuntimePathsEnvironment
    {
        string GameAssemblyLocation { get; }
        string GameAssemblyDirectory { get; }
        string ContentRoot { get; }
    }
}
