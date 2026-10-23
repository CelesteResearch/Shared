namespace Celeste.Everest.Reflection.Runtime
{
    public interface ISourceRuntimeTypeDiscoveryEnvironment
    {
        SourceRuntimeTypeDiscovery RuntimeTypeDiscovery { get; }
        void RefreshRuntimeTypeConsumers();
        System.IDisposable RegisterRuntimeAssemblyTypes(System.Reflection.Assembly assembly, System.Type[] types);
    }
}
