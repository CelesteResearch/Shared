using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Celeste.Core.Framework.Startup;
using Celeste.Everest.Modules.Persistence.GameSaves;
using Celeste.Everest.Runtime.Failures;
using Celeste.Everest.Runtime.Processes;
using Celeste.Game.Execution.Diagnostics;
using Celeste.Game.Runtime.Physical.Networking;

namespace Celeste.Game.Runtime.Physical.Runtime
{
    public class ManagedSourceRuntimeIO : ISourceCommandLineDevice, ISourceExternalFrameAssemblyIdentity,
        IEverestUserIOPathDevice, IOriginalErrorLogIo, ISourceFatalExitIo, IEverestProcessStartIo
    {
        private readonly string[] arguments;
        private readonly MethodInfo externalHostStartupFrame;
        private readonly string externalHostAssemblyIdentity;
        private ConstructorInfo? compressedHttpCreationFrame;
        private string? compressedHttpAssemblyIdentity;

        public ManagedSourceRuntimeIO(string physicalOwnerAssemblyPath, string applicationBaseDirectory,
            string[] arguments, MethodInfo externalHostStartupFrame)
        {
            if (!Path.IsPathRooted(physicalOwnerAssemblyPath) || !File.Exists(physicalOwnerAssemblyPath))
                throw new FileNotFoundException("The deployed physical managed owner DLL is required.",
                    physicalOwnerAssemblyPath);

            if (!Path.IsPathRooted(applicationBaseDirectory))
                throw new ArgumentException("An absolute physical application base directory is required.",
                    nameof(applicationBaseDirectory));

            if (externalHostStartupFrame == null) throw new ArgumentNullException(nameof(externalHostStartupFrame));

            if (externalHostStartupFrame.IsStatic || externalHostStartupFrame.ContainsGenericParameters ||
                externalHostStartupFrame.ReturnType != typeof(void) ||
                externalHostStartupFrame.GetParameters().Length != 0 ||
                externalHostStartupFrame.GetMethodBody() == null ||
                externalHostStartupFrame.Module.ModuleVersionId == Guid.Empty ||
                (externalHostStartupFrame.MetadataToken & unchecked((int)0xff000000)) != 0x06000000)
                throw new ArgumentException("The actual external host startup MethodDef is required.",
                    nameof(externalHostStartupFrame));

            ExecutingAssemblyLocation = Path.GetFullPath(physicalOwnerAssemblyPath);
            ApplicationBaseDirectory = Path.GetFullPath(applicationBaseDirectory);
            this.arguments = (string[])(arguments ?? throw new ArgumentNullException(nameof(arguments))).Clone();
            this.externalHostStartupFrame = externalHostStartupFrame;
            externalHostAssemblyIdentity = externalHostStartupFrame.DeclaringType!.Assembly.FullName ??
                                           throw new InvalidOperationException(
                                               "The external host assembly has no identity.");
        }

        public string ApplicationBaseDirectory { get; }
        public string ExecutingAssemblyLocation { get; }
        public bool IsLinux => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        public bool IsOSX => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        public void BindCompressedHttpCreationFrame(ConstructorInfo actualFrame)
        {
            if (compressedHttpCreationFrame != null)
                throw new InvalidOperationException("The HTTP physical creator frame is already bound.");

            var expected = SourceMonoCompressedHttpTransport.HookCreationFrame;
            if (actualFrame == null || !actualFrame.Equals(expected) || actualFrame.Module != expected.Module ||
                actualFrame.MetadataToken != expected.MetadataToken ||
                actualFrame.Module.ModuleVersionId != expected.Module.ModuleVersionId)
                throw new ArgumentException("The exact physical HTTP creator constructor is required.",
                    nameof(actualFrame));

            compressedHttpCreationFrame = actualFrame;
            compressedHttpAssemblyIdentity = actualFrame.DeclaringType!.Assembly.FullName;
        }

        public bool TryGetExternalFrameAssemblyIdentity(MethodBase actualMethod,
            out string assemblyIdentity, out bool stopAtHostBoundary)
        {
            // The constructor binds one actual host MethodDef. All actual MethodDefs
            // in that same loaded manifest module are the physical host assembly,
            // including later startup helpers; no original MethodDef is invented.
            if (actualMethod != null &&
                ReferenceEquals(actualMethod.Module, externalHostStartupFrame.Module) &&
                ReferenceEquals(actualMethod.DeclaringType?.Assembly,
                    externalHostStartupFrame.DeclaringType?.Assembly) &&
                actualMethod.Module.ModuleVersionId == externalHostStartupFrame.Module.ModuleVersionId &&
                (actualMethod.MetadataToken & unchecked((int)0xff000000)) == 0x06000000)
            {
                assemblyIdentity = externalHostAssemblyIdentity;
                stopAtHostBoundary = true;
                return true;
            }

            // The HTTP creator remains an exact constructor, not a module grant.
            if (compressedHttpCreationFrame != null && compressedHttpCreationFrame.Equals(actualMethod))
            {
                assemblyIdentity = compressedHttpAssemblyIdentity!;
                stopAtHostBoundary = false;
                return true;
            }

            assemblyIdentity = null!;
            stopAtHostBoundary = false;
            return false;
        }

        public string[] GetCommandLineArgs()
        {
            return (string[])arguments.Clone();
        }

        public string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name)!;
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public TextReader OpenReader(string path)
        {
            return new StreamReader(path);
        }

        public TextWriter OpenWriter(string path, bool append)
        {
            return new StreamWriter(path, append);
        }

        public void OpenDocument(string path)
        {
            Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
        }

        public void Start(ProcessStartInfo startInfo)
        {
            Process.Start(startInfo);
        }

        public void Exit(int exitCode)
        {
            Environment.Exit(exitCode);
        }
    }
}
