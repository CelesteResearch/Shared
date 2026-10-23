using System;
using Celeste.Audio.Framework;
using Celeste.Audio.IO;
using Celeste.Core.Diagnostics;
using Celeste.Core.IO.Content;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Framework.Startup;
using Celeste.Graphics.Content.Compiled;
using Celeste.Graphics.Content.Images;
using Celeste.Graphics.Rendering.Batches;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Input.Bindings;
using Celeste.Input.Runtime;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private SourceImageStreamProcess sourceImageStreams;
        private SourceStockEffectResources sourceStockEffects;
        private SourceSpriteBatchProcess sourceSpriteBatch;
        private SourceContentProcessState sourceContent;
        private SourceFnaTextInputBindings sourceTextBindings;
        private SourceFrameworkDispatcherProcess sourceDispatcher;
        private SourceGraphicsAdapterProcess sourceAdapters;

        public SourceImageStreamProcess ImageStreams => sourceImageStreams ??
                                                        throw new InvalidOperationException(
                                                            "The image stream process is not constructed.");

        public SourceStockEffectResources StockEffects => sourceStockEffects ??
                                                          throw new InvalidOperationException(
                                                              "The stock effect process is not constructed.");

        public SourceSpriteBatchProcess SpriteBatchProcess => sourceSpriteBatch ??
                                                              throw new InvalidOperationException(
                                                                  "The SpriteBatch process is not constructed.");

        public SourceContentProcessState Content =>
            sourceContent ?? throw new InvalidOperationException("The content process is not constructed.");

        public SourceFnaTextInputBindings TextBindings => sourceTextBindings ??
                                                          throw new InvalidOperationException(
                                                              "The source text bindings are not constructed.");

        public SourceFrameworkDispatcherProcess FrameworkDispatcher => sourceDispatcher ??
                                                                       throw new InvalidOperationException(
                                                                           "The framework dispatcher is not constructed.");

        public SourceGraphicsAdapterProcess GraphicsAdapters => sourceAdapters ??
                                                                throw new InvalidOperationException(
                                                                    "The graphics adapter process is not constructed.");

        public void ConstructSourceImageStreams(ISourceImageCodecDevice physicalCodec)
        {
            if (sourceImageStreams != null)
                throw new InvalidOperationException("The image stream process is already constructed.");
            sourceImageStreams =
                new(physicalCodec ?? throw new ArgumentNullException(nameof(physicalCodec)));
        }

        public void ConstructSourceStockEffects()
        {
            if (sourceStockEffects != null)
                throw new InvalidOperationException("The stock effect process is already constructed.");
            sourceStockEffects = new(new SourceStockEffectEmbeddedReader());
            sourceSpriteBatch = new(sourceStockEffects);
        }

        public void ConstructSourceContent(IContentSource physicalFiles,
            ISourceGraphicsAdapterDisplayIO physicalDisplays)
        {
            if (sourceContent != null)
                throw new InvalidOperationException("The source content process is already constructed.");
            var typeIdentity =
                new SourceCatalogContentTypeIdentity(((ISourceSceneCatalogEnvironment)engine).SceneCatalog);
            sourceContent = new(physicalFiles, typeIdentity,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic,
                ((ISourceVectorEnvironment)engine).VectorArithmetic,
                (ISourceAudioEnvironment)engine, (ISourceTheoraEnvironment)engine,
                (ISourceFnaLoggingEnvironment)engine, StockEffects);
            sourceTextBindings = new();
            sourceDispatcher = new(
                ((ISourceAudioEnvironment)engine).AudioMedia, ((ISourceFnaInputEnvironment)engine).FnaInput);
            sourceAdapters = new(physicalDisplays);
        }
    }
}
