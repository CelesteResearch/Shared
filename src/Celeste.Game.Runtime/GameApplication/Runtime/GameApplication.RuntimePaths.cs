using System;
using System.IO;
using Celeste.Core.IO;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceGameRuntimePathsEnvironment, ISourceContentDirectoryEnvironment
    {
        private string sourceGameAssemblyDirectory;
        public string GameAssemblyLocation => PhysicalIO.PhysicalOwnerAssemblyPath;

        public string GameAssemblyDirectory => sourceGameAssemblyDirectory ??
                                               throw new InvalidOperationException(
                                                   "The physical managed owner directory is not initialized.");

        public string ContentRoot => PhysicalIO.ContentRoot;
        public string ContentDirectory => PhysicalIO.ContentRoot;
        public string SourceDeploymentGameDirectory => PhysicalIO.ContentRoot;

        public void InitializeSourceRuntimePaths()
        {
            if (sourceGameAssemblyDirectory != null)
                throw new InvalidOperationException("The Game runtime paths are already initialized.");
            sourceGameAssemblyDirectory = PhysicalIO.CompiledSourceDeployment?.Directory ??
                                          Path.GetDirectoryName(GameAssemblyLocation);
            if (sourceGameAssemblyDirectory == null)
                throw new InvalidOperationException("The physical managed owner DLL path has no directory.");
        }
    }
}
