using System.IO;

namespace Celeste.Everest.Content.Sources
{
    public interface ISourceAssemblyContentResources
    {
        string AssemblyName { get; }
        string[] GetManifestResourceNames();
        Stream GetManifestResourceStream(string resourceName);
    }
}
