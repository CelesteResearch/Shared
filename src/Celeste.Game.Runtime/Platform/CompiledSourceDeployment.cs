using System;
using System.IO;

namespace Celeste.Game.Runtime.Platform
{
    // A compiled host has a deployment directory without a runtime owner PE file.
    // This describes paths; executable source bindings are established separately.
    public sealed class CompiledSourceDeployment
    {
        public string Directory { get; }

        public CompiledSourceDeployment(string directory)
        {
            if (!Path.IsPathRooted(directory))
                throw new ArgumentException("An absolute compiled source deployment directory is required.",
                    nameof(directory));
            Directory = Path.GetFullPath(directory);
        }
    }
}
