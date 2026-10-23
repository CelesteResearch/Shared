using System;
using System.Reflection;

namespace Celeste.Everest.Runtime.Compatibility
{
// Physical MonoMod cache type and method replacement; CPU setter policy stays in the shared process.
    public interface IEverestLegacyDynamicDataRuntime
    {
        Type DynamicDataCacheType { get; }

        IDisposable InstallCacheConstructorHook(ConstructorInfo constructor,
            Action<Action<object, Type>, object, Type> replacement);
    }
}
