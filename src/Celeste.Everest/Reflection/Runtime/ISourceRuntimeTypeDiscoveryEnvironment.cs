using System;
using System.Reflection;

namespace Celeste.Everest.Reflection.Runtime
{
    public interface ISourceRuntimeTypeDiscoveryEnvironment
    {
        SourceRuntimeTypeDiscovery RuntimeTypeDiscovery { get; }
        void RefreshRuntimeTypeConsumers();
        IDisposable RegisterRuntimeAssemblyTypes(Assembly assembly, Type[] types);
    }
}
