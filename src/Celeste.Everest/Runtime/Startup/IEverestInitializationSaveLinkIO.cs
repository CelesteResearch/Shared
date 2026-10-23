#nullable enable annotations
using System.IO;

namespace Celeste.Everest.Runtime.Startup
{
    public interface IEverestInitializationSaveLinkIO
    {
        string GetDirectoryLinkTarget(DirectoryInfo directory);
    }
}
