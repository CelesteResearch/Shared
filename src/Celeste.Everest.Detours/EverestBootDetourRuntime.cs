using System;
using System.Reflection;
using Celeste.Everest.Modules.Runtime;
using MonoMod.Core.Platforms;
using MonoMod.RuntimeDetour;
using MonoMod.Utils;

namespace Celeste.Everest.Detours
{
    public sealed class EverestBootDetourRuntime : ISourceBootDetourRuntime
    {
        public Assembly HookAssembly => typeof(Hook).Assembly;
        public bool TryDisableInlining(MethodBase method) => PlatformTriple.Current.TryDisableInlining(method);

        public IDisposable SubscribeDetourApplied(Action<ISourceBootDetourInfo> callback)
        {
            Action<DetourInfo> handler = info => callback(new ManagedInfo(info));
            return new Subscription(() => DetourManager.DetourApplied += handler,
                () => DetourManager.DetourApplied -= handler);
        }

        public IDisposable SubscribeDetourUndone(Action<object> callback)
        {
            Action<DetourInfo> handler = info => callback(info);
            return new Subscription(() => DetourManager.DetourUndone += handler,
                () => DetourManager.DetourUndone -= handler);
        }

        public IDisposable SubscribeILHookApplied(Action<ISourceBootDetourInfo> callback)
        {
            Action<ILHookInfo> handler = info => callback(new ManagedInfo(info));
            return new Subscription(() => DetourManager.ILHookApplied += handler,
                () => DetourManager.ILHookApplied -= handler);
        }

        public IDisposable SubscribeILHookUndone(Action<object> callback)
        {
            Action<ILHookInfo> handler = info => callback(info);
            return new Subscription(() => DetourManager.ILHookUndone += handler,
                () => DetourManager.ILHookUndone -= handler);
        }

        public IDisposable SubscribeNativeDetourApplied(Action<ISourceBootDetourInfo> callback)
        {
            Action<global::MonoMod.RuntimeDetour.NativeDetourInfo> handler = info => callback(new NativeInfo(info));
            return new Subscription(() => DetourManager.NativeDetourApplied += handler,
                () => DetourManager.NativeDetourApplied -= handler);
        }

        public IDisposable SubscribeNativeDetourUndone(Action<object> callback)
        {
            Action<global::MonoMod.RuntimeDetour.NativeDetourInfo> handler = info => callback(info);
            return new Subscription(() => DetourManager.NativeDetourUndone += handler,
                () => DetourManager.NativeDetourUndone -= handler);
        }

        private sealed class Subscription : IDisposable
        {
            private Action unsubscribe;

            public Subscription(Action subscribe, Action unsubscribe)
            {
                this.unsubscribe = unsubscribe;
                try
                {
                    subscribe();
                }
                catch
                {
                    Dispose();
                    throw;
                }
            }

            public void Dispose() => System.Threading.Interlocked.Exchange(ref unsubscribe, null)?.Invoke();
        }

        private sealed class ManagedInfo : ISourceBootDetourInfo
        {
            private readonly DetourBase info;
            public ManagedInfo(DetourBase info) => this.info = info;
            public object Identity => info;

            public SourceBootDetourKind Kind =>
                info is DetourInfo ? SourceBootDetourKind.Detour : SourceBootDetourKind.ILHook;

            public MethodBase Method => info.Method.Method;
            public MethodBase Entry => info is DetourInfo detour ? detour.Entry : ((ILHookInfo)info).ManipulatorMethod;
            public string MethodId => Method.GetID();
            public long NativeFunction => throw new NotSupportedException();
            public void Undo() => info.Undo();
        }

        private sealed class NativeInfo : ISourceBootDetourInfo
        {
            private readonly global::MonoMod.RuntimeDetour.NativeDetourInfo info;
            public NativeInfo(global::MonoMod.RuntimeDetour.NativeDetourInfo info) => this.info = info;
            public object Identity => info;
            public SourceBootDetourKind Kind => SourceBootDetourKind.NativeDetour;
            public MethodBase Method => throw new NotSupportedException();
            public MethodBase Entry => throw new NotSupportedException();
            public string MethodId => throw new NotSupportedException();
            public long NativeFunction => (long)info.Function.Function;
            public void Undo() => info.Undo();
        }
    }
}
