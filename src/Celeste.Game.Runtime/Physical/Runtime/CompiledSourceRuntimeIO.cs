using System;
using System.Reflection;
using Celeste.Core.Framework.Startup;
using Celeste.Everest.Modules.Persistence.GameSaves;
using Celeste.Game.Runtime.Platform;

namespace Celeste.Game.Runtime.Physical.Runtime
{
    // The compiled host binds a real typed startup action, never a claimed PE path.
    // File, process, exit and error presentation remain separate physical endpoints.
    public sealed class CompiledSourceRuntimeIO : ISourceCommandLineDevice, ISourceExternalFrameAssemblyIdentity,
        IEverestUserIOPathDevice
    {
        private readonly string[] arguments;
        private readonly Action externalHostStartup;
        private readonly MethodInfo externalHostStartupFrame;
        private readonly string externalHostAssemblyIdentity;
        private readonly Func<string, string?> environmentVariables;

        public CompiledSourceRuntimeIO(CompiledSourceDeployment deployment, string[] arguments,
            Action externalHostStartup, Func<string, string?> environmentVariables,
            bool isLinux = false, bool isOSX = false)
        {
            if (deployment == null) throw new ArgumentNullException(nameof(deployment));
            if (externalHostStartup == null) throw new ArgumentNullException(nameof(externalHostStartup));
            var method = externalHostStartup.Method;
            if (externalHostStartup.GetInvocationList().Length != 1 || externalHostStartup.Target == null ||
                method.IsStatic || method.ContainsGenericParameters || method.ReturnType != typeof(void) ||
                method.GetParameters().Length != 0 || method.DeclaringType == null ||
                method.DeclaringType.Assembly.IsDynamic)
                throw new ArgumentException("One typed instance host startup action is required.",
                    nameof(externalHostStartup));
            ApplicationBaseDirectory = deployment.Directory;
            this.arguments = (string[])(arguments ?? throw new ArgumentNullException(nameof(arguments))).Clone();
            this.externalHostStartup = externalHostStartup;
            externalHostStartupFrame = method;
            externalHostAssemblyIdentity = method.DeclaringType.Assembly.FullName ??
                                           throw new InvalidOperationException(
                                               "The compiled host assembly has no identity.");
            this.environmentVariables = environmentVariables ??
                                        throw new ArgumentNullException(nameof(environmentVariables));
            IsLinux = isLinux;
            IsOSX = isOSX;
        }

        public string ApplicationBaseDirectory { get; }

        public string ExecutingAssemblyLocation => throw new PlatformNotSupportedException(
            "The compiled host has a deployment directory, not a physical owner DLL location.");

        public bool IsLinux { get; }
        public bool IsOSX { get; }

        public string[] GetCommandLineArgs() => (string[])arguments.Clone();
        public string GetEnvironmentVariable(string name) => environmentVariables(name)!;

        public bool TryGetExternalFrameAssemblyIdentity(MethodBase actualMethod,
            out string assemblyIdentity, out bool stopAtHostBoundary)
        {
            // The typed delegate retains the actual host owner and executable entry.
            // Frame ownership follows that loaded module; no source MethodDef is invented.
            if (actualMethod != null &&
                ReferenceEquals(actualMethod.Module, externalHostStartupFrame.Module) &&
                ReferenceEquals(actualMethod.DeclaringType?.Assembly,
                    externalHostStartupFrame.DeclaringType!.Assembly))
            {
                assemblyIdentity = externalHostAssemblyIdentity;
                stopAtHostBoundary = true;
                GC.KeepAlive(externalHostStartup);
                return true;
            }

            assemblyIdentity = null!;
            stopAtHostBoundary = false;
            return false;
        }
    }
}
