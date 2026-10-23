using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using Celeste.Core.Framework.Startup;
using Celeste.Core.IO.Platform.SDL;
using Celeste.Everest.Modules.Persistence.GameSaves;
using Celeste.Everest.Runtime.Failures;
using Celeste.Everest.Runtime.Processes;
using Celeste.Framework.Startup;
using Celeste.Game.Execution.Diagnostics;
using Celeste.Game.Runtime.Physical.Runtime;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Hosting.Runtime.Platform
{
    public sealed class RuntimeIO : ManagedSourceRuntimeIO, ISourceGameHostRuntimeIO,
        ISourceRuntimeErrorDevice, ISourceWindowFocusDevice, ISourceWindowFocusIO,
        ISourceSDLRuntimeDevice, ISourceSDLHintDevice, ISourceFatalExitIo, IEverestUserIOPathDevice,
        IOriginalErrorLogIo,
        IEverestProcessStartIo
    {
        private readonly Action<int> requestSessionExit;
        private readonly Action<string, string> reportError;

        public RuntimeIO(EmbeddedGameConfiguration configuration, string physicalOwnerAssemblyPath,
            MethodInfo actualStartupFrame, Action<int> requestSessionExit)
            : base(physicalOwnerAssemblyPath, GetDataRoot(configuration),
                new[] { physicalOwnerAssemblyPath }, actualStartupFrame)
        {
            this.requestSessionExit = requestSessionExit ?? throw new ArgumentNullException(nameof(requestSessionExit));
            reportError = configuration.ReportError ??
                          throw new ArgumentNullException(nameof(configuration.ReportError));
        }

        public Action<IntPtr> SdlRaiseWindow => null!;

        public bool GetTouchDeviceConnected()
        {
            return false;
        }

        public void SetMouseVisible(bool visible)
        {
            // The enclosing host owns its cursor and input capture.
        }

        public void ShowRuntimeError(string title, string message)
        {
            reportError(title, message);
        }

        public void SetHint(string name, string value)
        {
            // SDL belongs to the enclosing host; embedded hints must not alter it.
        }

        public bool GetHintBoolean(string name, bool defaultValue)
        {
            return defaultValue;
        }

        public void RaiseWindow(IntPtr window)
        {
            // An embedded render surface is not an independent OS window.
        }

        public bool SetForegroundWindow(IntPtr handle)
        {
            return false;
        }

        public string GetPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return "Windows";
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return "Mac OS X";
            }

            return "Linux";
        }

        public string GetPrefPath(string organization, string application)
        {
            return ApplicationBaseDirectory;
        }

        public new string GetEnvironmentVariable(string name)
        {
            // No parent process save-path or window hint can escape this host's DataRoot.
            return null!;
        }

        string IEverestUserIOPathDevice.GetEnvironmentVariable(string name)
        {
            return GetEnvironmentVariable(name);
        }

        string ISourceWindowFocusDevice.GetEnvironmentVariable(string name)
        {
            return GetEnvironmentVariable(name);
        }

        public new void Exit(int exitCode)
        {
            requestSessionExit(exitCode);
        }

        void ISourceFatalExitIo.Exit(int exitCode)
        {
            Exit(exitCode);
        }

        void IEverestProcessStartIo.Start(ProcessStartInfo startInfo)
        {
            reportError("Celeste process", "External process launch is unavailable in an embedded game session.");
        }

        public new bool FileExists(string path)
        {
            return File.Exists(ResolveDataPath(path));
        }

        public new bool DirectoryExists(string path)
        {
            return Directory.Exists(ResolveDataPath(path));
        }

        public new void CreateDirectory(string path)
        {
            Directory.CreateDirectory(ResolveDataPath(path));
        }

        public new TextReader OpenReader(string path)
        {
            return new StreamReader(ResolveDataPath(path));
        }

        public new TextWriter OpenWriter(string path, bool append)
        {
            string resolved = ResolveDataPath(path);
            Directory.CreateDirectory(Path.GetDirectoryName(resolved)!);
            return new StreamWriter(resolved, append);
        }

        public new void OpenDocument(string path)
        {
            reportError("Celeste error log", ResolveDataPath(path));
        }

        bool IOriginalErrorLogIo.FileExists(string path)
        {
            return FileExists(path);
        }

        bool IOriginalErrorLogIo.DirectoryExists(string path)
        {
            return DirectoryExists(path);
        }

        void IOriginalErrorLogIo.CreateDirectory(string path)
        {
            CreateDirectory(path);
        }

        TextReader IOriginalErrorLogIo.OpenReader(string path)
        {
            return OpenReader(path);
        }

        TextWriter IOriginalErrorLogIo.OpenWriter(string path, bool append)
        {
            return OpenWriter(path, append);
        }

        void IOriginalErrorLogIo.OpenDocument(string path)
        {
            OpenDocument(path);
        }

        private string ResolveDataPath(string path)
        {
            return Path.GetFullPath(Path.Combine(ApplicationBaseDirectory, path));
        }

        private static string GetDataRoot(EmbeddedGameConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (!Path.IsPathRooted(configuration.DataRoot))
            {
                throw new ArgumentException("An absolute embedded DataRoot is required.", nameof(configuration));
            }

            return Path.GetFullPath(configuration.DataRoot);
        }
    }
}
