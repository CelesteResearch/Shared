using System;
using System.Reflection;

namespace Celeste.Everest.Modules.Runtime
{
    public interface ISourceBootDetourRuntime
    {
        Assembly HookAssembly { get; }
        bool TryDisableInlining(MethodBase method);
        IDisposable SubscribeDetourApplied(Action<ISourceBootDetourInfo> callback);
        IDisposable SubscribeDetourUndone(Action<object> callback);
        IDisposable SubscribeILHookApplied(Action<ISourceBootDetourInfo> callback);
        IDisposable SubscribeILHookUndone(Action<object> callback);
        IDisposable SubscribeNativeDetourApplied(Action<ISourceBootDetourInfo> callback);
        IDisposable SubscribeNativeDetourUndone(Action<object> callback);
    }
}
