namespace Celeste.Core.Randomness
{
    public interface ISourceRandomProcessEnvironment : ISourceRandomEnvironment
    {
        SourceRandomProcessState RandomProcess { get; }
    }
}
