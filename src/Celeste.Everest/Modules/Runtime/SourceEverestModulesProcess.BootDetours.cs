using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Celeste.Everest.Reflection;

namespace Celeste.Everest.Modules.Runtime
{
    public sealed partial class SourceEverestModulesProcess
    {
        private readonly List<IDisposable> bootDetourSubscriptions = [];

        private readonly HashSet<MethodBase> inliningDisabledMethods = [];
        private ISourceBootDetourEnvironment BootDetourEnvironment => (ISourceBootDetourEnvironment)sourceEngine;

        public void InitializeSourceBootDetourHooks()
        {
            var firstSubscription = bootDetourSubscriptions.Count;
            if (bootDetourSubscriptions.Capacity < firstSubscription + 6)
                bootDetourSubscriptions.Capacity = firstSubscription + 6;
            try
            {
                var runtime = BootDetourEnvironment.BootDetourRuntime;
                bootDetourSubscriptions.Add(runtime.SubscribeDetourApplied(info =>
                {
                    EnsureLegalHook(info);
                    bool isMmhook;
                    var hookOwner = GetHookOwner(out isMmhook);
                    if (hookOwner != null)
                    {
                        if (!isMmhook)
                            detourLog.Add("new Detour by " + hookOwner.GetName().Name + ": " + info.MethodId);
                        else detourLog.Add("new On.+= by " + hookOwner.GetName().Name + ": " + info.MethodId);
                        RegisterModDetour(hookOwner, info.Identity, info.Undo);
                    }
                }));
                bootDetourSubscriptions.Add(runtime.SubscribeDetourUndone(UnregisterModDetour));
                bootDetourSubscriptions.Add(runtime.SubscribeILHookApplied(info =>
                {
                    EnsureLegalHook(info);
                    bool isMmhook;
                    var hookOwner = GetHookOwner(out isMmhook);
                    if (hookOwner != null)
                    {
                        if (!isMmhook)
                            detourLog.Add("new ILHook by " + hookOwner.GetName().Name + ": " + info.MethodId);
                        else detourLog.Add("new IL.+= by " + hookOwner.GetName().Name + ": " + info.MethodId);
                        RegisterModDetour(hookOwner, info.Identity, info.Undo);
                    }
                }));
                bootDetourSubscriptions.Add(runtime.SubscribeILHookUndone(UnregisterModDetour));
                bootDetourSubscriptions.Add(runtime.SubscribeNativeDetourApplied(info =>
                {
                    bool isMmhook;
                    var hookOwner = GetHookOwner(out isMmhook);
                    if (hookOwner != null)
                    {
                        detourLog.Add($"new NativeDetour by {hookOwner.GetName().Name}: {info.NativeFunction:X16}");
                        RegisterModDetour(hookOwner, info.Identity, info.Undo);
                    }
                }));
                bootDetourSubscriptions.Add(runtime.SubscribeNativeDetourUndone(UnregisterModDetour));
            }
            catch
            {
                DisposeSourceBootDetourHooks(firstSubscription);
                throw;
            }
        }

        private void DisposeSourceBootDetourHooks(int firstSubscription = 0)
        {
            for (var i = bootDetourSubscriptions.Count - 1; i >= firstSubscription; i--)
            {
                var subscription = bootDetourSubscriptions[i];
                bootDetourSubscriptions.RemoveAt(i);
                subscription.Dispose();
            }
        }

        public Assembly GetHookOwner(out bool isMMHOOK, StackTrace stack = null)
        {
            isMMHOOK = false;
            if (stack == null) stack = new();
            var frameCount = stack.FrameCount;
            for (var i = 0; i < frameCount; i++)
            {
                var method = stack.GetFrame(i).GetMethod();
                var assembly = method?.DeclaringType?.Assembly;
                if (assembly == null || assembly == BootDetourEnvironment.BootDetourRuntime.HookAssembly) continue;
                if (BootDetourEnvironment.BootDetourFrameIdentity is ISourceBootDetourSharedFrameIdentity shared &&
                    shared.TryValidateSharedHelperFrame(method, out var actualSharedIdentity))
                {
                    if (actualSharedIdentity != assembly.FullName)
                        throw new InvalidOperationException(
                            "The shared helper frame has a different actual assembly owner.");
                    continue;
                }

                var identity = BootDetourEnvironment.BootDetourFrameIdentity
                    .RequireFrameAssemblyIdentity(method, out var stopAtHostBoundary);
                if (stopAtHostBoundary) return null;
                if (identity == ((ISourceEverestReflectionAssemblyEnvironment)sourceEngine)
                    .OriginalGameAssemblyIdentity) continue;
                if (!assembly.GetName().Name.StartsWith("MMHOOK_")) return assembly;
                isMMHOOK = true;
            }

            return null;
        }

        public bool TryDisableInlining(MethodBase targetMethod)
        {
            if (inliningDisabledMethods.Contains(targetMethod)) return true;
            if (BootDetourEnvironment.BootDetourRuntime.TryDisableInlining(targetMethod))
            {
                inliningDisabledMethods.Add(targetMethod);
                return true;
            }

            return false;
        }

        public void EnsureLegalHook(ISourceBootDetourInfo info)
        {
            var method = info.Method;
            if (method.MethodImplementationFlags.HasFlag(MethodImplAttributes.NoInlining)) return;
            if (info.Kind != SourceBootDetourKind.Detour && info.Kind != SourceBootDetourKind.ILHook)
                throw new NotSupportedException();
            var entry = info.Entry;
            if (method.MethodImplementationFlags.HasFlag(MethodImplAttributes.AggressiveInlining))
                BootDetourEnvironment.MonoModPolice.ReportMonoModCrime(
                    GetFullMethodName(entry) + " is hooking method " + GetFullMethodName(method) +
                    " which has aggressive inlining enabled!", entry);
            if (!inliningDisabledMethods.Contains(method))
            {
                var level = Runtime.Initialized ? EverestLogLevel.Warn : EverestLogLevel.Verbose;
                var message = Logger.BeginEnabledMessage("Everest", level);
                if (message.ShouldLog)
                    message.Write(GetFullMethodName(entry) + " is hooking method " + GetFullMethodName(method) +
                                  " which does not have inlining disabled!");
            }
        }

        private static string GetFullMethodName(MethodBase method)
        {
            return (method.DeclaringType?.FullName ?? "(Unknown Declaring Type}") + "." + method.Name;
        }
    }
}
