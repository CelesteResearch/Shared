using System;

namespace Celeste.Everest.Modules.Dependencies
{
    // Source selection is explicit. The public Everest catalog lists original
    // binaries and is only suitable for opt-in compatibility tests in this port.
    public sealed class EverestDependencySource
    {
        public string UpdateListPointerUrl { get; }
        public string DependencyGraphPointerUrl { get; }
        public string MirrorUpdateListUrl { get; }
        public string MirrorDependencyGraphUrl { get; }

        public EverestDependencySource(string updateListPointerUrl, string dependencyGraphPointerUrl,
            string mirrorUpdateListUrl, string mirrorDependencyGraphUrl)
        {
            UpdateListPointerUrl =
                updateListPointerUrl ?? throw new ArgumentNullException(nameof(updateListPointerUrl));
            DependencyGraphPointerUrl = dependencyGraphPointerUrl ??
                                        throw new ArgumentNullException(nameof(dependencyGraphPointerUrl));
            MirrorUpdateListUrl = mirrorUpdateListUrl ?? throw new ArgumentNullException(nameof(mirrorUpdateListUrl));
            MirrorDependencyGraphUrl = mirrorDependencyGraphUrl ??
                                       throw new ArgumentNullException(nameof(mirrorDependencyGraphUrl));
        }

        public static EverestDependencySource OriginalEverestForTests()
        {
            return new(
                "https://everestapi.github.io/modupdater.txt", "https://everestapi.github.io/modgraph.txt",
                "https://everestapi.github.io/updatermirror/everest_update.yaml",
                "https://everestapi.github.io/updatermirror/mod_dependency_graph.yaml");
        }
    }
}
