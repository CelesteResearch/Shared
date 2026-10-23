using System.IO;
using Celeste.Graphics.Content.Compiled;
using Celeste.Everest.Content.Compiled;

namespace Celeste.Everest.Content.Registry
{
    public sealed partial class EverestContentRegistry
    {
        public SourceContentManager CreateSourceContentManager(SourceContentManager inner,
            SourceContentProcessState contentProcess)
            => new SourceEverestContentManager(inner, contentProcess, this);

        public void InitializeBuiltInSourcePaths(string pathGame, string contentRoot, string pathEverest)
        {
            Directory.CreateDirectory(PathContentOrig = Path.Combine(pathGame, contentRoot));
            PathDUMP = Path.Combine(pathEverest, "ModDUMP");
        }
    }
}
