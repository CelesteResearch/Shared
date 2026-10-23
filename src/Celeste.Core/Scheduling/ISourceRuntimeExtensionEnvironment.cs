namespace Celeste.Core.Scheduling
{
    public interface ISourceRuntimeExtensionEnvironment
    {
        T GetRuntimeExtension<T>() where T : class;
    }
}
