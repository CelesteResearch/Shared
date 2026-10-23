using System.IO;

namespace Celeste.Hosting.Runtime.Content
{
    public sealed class GameContentPaths
    {
        public const string GameDirectoryName = "Celeste";
        public const string EverestDirectoryName = "Everest";
        public const string FrameworkTimeResourcesDirectoryName = "CelesteFrameworkTimeResources";

        public string ResourceDirectory { get; }
        public string Game { get; }
        public string Everest { get; }
        public string FrameworkTimeResources { get; }

        public GameContentPaths(string resourceDirectory)
        {
            ResourceDirectory = Path.GetFullPath(resourceDirectory);
            Game = Path.Combine(ResourceDirectory, GameDirectoryName);
            Everest = Path.Combine(ResourceDirectory, EverestDirectoryName);
            FrameworkTimeResources = Path.Combine(ResourceDirectory, FrameworkTimeResourcesDirectoryName);
        }
    }
}
