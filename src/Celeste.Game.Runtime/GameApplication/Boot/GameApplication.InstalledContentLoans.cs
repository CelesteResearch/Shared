using System;
using System.IO;
using Celeste.Everest;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Presentation.Mountain.Model;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Graphics.Content.Textures;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestContentDumpEnvironment,
        ISourceTexturePngWriter, IEverestMountainResourceEnvironment, IEverestMountainContentEnvironment
    {
        private EverestMountainExtensionProcess sourceMountainExtension;

        public EverestMountainExtensionProcess MountainExtension => sourceMountainExtension ??
                                                                    throw new InvalidOperationException(
                                                                        "The installed mountain extension is not constructed.");

        EverestContentRegistry IEverestMountainContentEnvironment.Content => SourceContentRegistry;

        ISourceAtlasLoaderEnvironment
            IEverestContentProcessingEnvironment.AtlasLoader => this;

        IEverestContentDumpEnvironment IEverestContentProcessingEnvironment.ContentDump => this;
        ISourceTexturePngWriter IEverestContentDumpEnvironment.PngWriter => this;

        IEverestContentDumpDiagnostics IEverestContentDumpEnvironment.Diagnostics =>
            Logger;

        void IEverestContentDiagnostics.Error(string category, string message)
        {
            Logger.Log(EverestLogLevel.Error, category, message);
        }

        void IEverestContentDiagnostics.Detailed(Exception exception)
        {
            Logger.LogDetailed(exception);
        }

        void ISourceTexturePngWriter.SaveAsPng(ISourceDataTextureResource texture,
            Stream stream, int width, int height)
        {
            ((SourceTexture2DResource)texture).SaveAsPng(stream, width, height);
        }
    }
}
