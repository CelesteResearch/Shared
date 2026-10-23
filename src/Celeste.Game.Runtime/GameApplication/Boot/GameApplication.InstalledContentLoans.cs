using Celeste.Everest;
using System;
using System.IO;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Presentation.Mountain.Model;
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

        global::Celeste.Formats.Graphics.Atlas.ISourceAtlasLoaderEnvironment
            IEverestContentProcessingEnvironment.AtlasLoader => this;

        IEverestContentDumpEnvironment IEverestContentProcessingEnvironment.ContentDump => this;
        ISourceTexturePngWriter IEverestContentDumpEnvironment.PngWriter => this;

        IEverestContentDumpDiagnostics IEverestContentDumpEnvironment.Diagnostics =>
            ((IEverestLoggerProcessEnvironment)this).Logger;

        void IEverestContentDiagnostics.Error(string category, string message) =>
            ((IEverestLoggerProcessEnvironment)this).Logger.Log(EverestLogLevel.Error, category, message);

        void IEverestContentDiagnostics.Detailed(Exception exception) =>
            ((IEverestLoggerProcessEnvironment)this).Logger.LogDetailed(exception);

        void ISourceTexturePngWriter.SaveAsPng(ISourceDataTextureResource texture,
            Stream stream, int width, int height) =>
            ((SourceTexture2DResource)texture).SaveAsPng(stream, width, height);
    }
}
