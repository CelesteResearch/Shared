using System;
using System.IO;
using System.Xml;
using Celeste.Core.IO.Content;
using Celeste.Core.Rendering;
using Celeste.Core.Serialization.Xml;
using Celeste.Core.Threading;
using Celeste.Everest;
using Celeste.Everest.Content.Atlases;
using Celeste.Everest.Content.Graphics;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Content.Sources;
using Celeste.Everest.Content.Textures;
using Celeste.Everest.Content.Types.Text;
using Celeste.Everest.Content.Xml;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Entities.IntroCar;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Runtime;
using Celeste.Everest.Runtime.Failures;
using Celeste.Everest.Runtime.Startup;
using Celeste.Everest.Runtime.Threading;
using Celeste.Everest.Tasks.Queuing;
using Celeste.Everest.Text.BitmapFonts;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Content.Fonts;
using Celeste.Game.Credits;
using Celeste.Game.Entities.IntroCar;
using Celeste.Game.Execution.Diagnostics;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Graphics.Drawing;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Profiles;
using Celeste.Game.Runtime.Rendering;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Compiled;
using Celeste.Graphics.Content.Gui;
using Celeste.Graphics.Content.Textures;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Text;
using Celeste.Graphics.Text.BitmapFonts;
using Celeste.Graphics.Text.Fonts;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication :
        ISourceOriginalContentXmlEnvironment, ISourceGameGraphicsEnvironment,
        ISourceDrawScope, ISourceRenderEnvironment,
        ISourceContentManagerEnvironment,
        ISourceXmlDocumentLoadingEnvironment,
        IOriginalDrawInitializationResources, IOriginalStartupSceneEnvironment, IOriginalMountainEnvironment,
        IOriginalLanguageTextureFactory, IEverestGameLoaderEventsEnvironment, IEverestLoaderProcessEnvironment,
        IEverestModUpdaterEnvironment, IEverestCompressedHttpEnvironment, IOriginalGameTextEnvironment,
        ISourceActiveFontScope, IOriginalFontRegistryProcess, IOriginalFontRegistryAugmentationEnvironment,
        IEverestEmojiProcess, IEverestPixelFontProcess, IEverestFontRegistryProcess, IEverestContentRegistryEnvironment,
        ISourceEverestFileProxyEnvironment, IEverestContentDiagnostics,
        IEverestYamlEnvironment, IEverestGamePathEnvironment, IEverestVersionStringEnvironment,
        ISourceEverestMainThreadEnvironment,
        IEverestHeadlessEnvironment,
        IEverestVirtualTextureDiagnostics,
        IEverestVirtualTextureEnvironment,
        ISourceAtlasLoaderEnvironment,
        IEverestErrorLogEnvironment,
        ISourceVirtualContentEnvironment, IEverestSplashEnvironment,
        IOriginalIntroCarEnvironment, IEverestStartupRuntimeEnvironment,
        IEverestCelesteVersionEnvironment, ISourceGuiAtlasResources,
        IEverestContentProcessingEnvironment, IEverestLoaderContentEnvironment,
        IEverestFlagsEnvironment,
        IEverestUpdaterPhysicalEnvironment,
        IOriginalCreditsGraphicsEnvironment
    {
        IContentSource
            ISourceAtlasLoaderEnvironment.ContentFiles =>
            PhysicalIO.ContentFiles;

        IContentSource
            ISourceVirtualTextureEnvironment.ContentFiles =>
            PhysicalIO.ContentFiles;

        private EverestSplashProcess sourceSplash;

        public EverestSplashProcess Splash => sourceSplash ??
                                              throw new InvalidOperationException(
                                                  "The installed splash process is not constructed.");

        public void ConstructSourceInstalledSplash()
        {
            if (sourceSplash != null)
                throw new InvalidOperationException("The installed splash process is already constructed.");
            sourceSplash = new(Logger,
                PhysicalIO.Splash ??
                throw new InvalidOperationException(
                    "The enabled Everest profile requires its splash transport."));
        }

        private IOriginalIntroCarFactory sourceIntroCars;

        public IOriginalIntroCarFactory IntroCars => sourceIntroCars ??
                                                     throw new InvalidOperationException(
                                                         "The source intro car factory is not selected.");

        public void ConstructSourceIntroCarFactory()
        {
            if (sourceIntroCars != null)
                throw new InvalidOperationException("The source intro car factory is already selected.");
            if (SourceProfile == GameProfile.InstalledEverest)
                sourceIntroCars = new EverestIntroCarFactory();
            else
                sourceIntroCars = new OriginalIntroCarFactory();
        }

        void IEverestVirtualTextureDiagnostics.InvalidPngMagic(ulong value,
            string path)
        {
            var message =
                ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("vtex", EverestLogLevel.Error);
            if (message.ShouldLog)
                message.Write("Failed preloading PNG: Expected magic to be 0x0A1A0A0D474E5089, got 0x" +
                              value.ToString("X16") + " - " + path);
        }

        void IEverestVirtualTextureDiagnostics.InvalidPngFirstChunkLength(
            uint value, string path)
        {
            var message =
                ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("vtex", EverestLogLevel.Error);
            if (message.ShouldLog)
                message.Write("Failed preloading PNG: Expected first chunk length to be 0x0D000000, got 0x" +
                              value.ToString("X8") + " - " + path);
        }

        void IEverestVirtualTextureDiagnostics.InvalidPngHeaderMarker(
            uint value,
            string path)
        {
            var message =
                ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("vtex", EverestLogLevel.Error);
            if (message.ShouldLog)
                message.Write("Failed preloading PNG: Expected IHDR marker 0x52444849, got 0x" + value.ToString("X8") +
                              " - " + path);
        }

        public void InitializeSourceBootDetourLog()
        {
            ModulesProcess
                .InitializeSourceBootDetourHooks();
        }

        private OriginalErrorLogProcess CreateSourceInstalledErrorLog()
        {
            return new EverestErrorLogProcess(
                PhysicalIO.ErrorLog, this, Logger,
                ModulesProcess);
        }

        public void ConstructSourceInstalledCriticalFailure()
        {
            if (sourceCriticalFailure != null)
                throw new InvalidOperationException("The installed critical failure process is already constructed.");
            sourceCriticalFailure = new(
                Logger,
                ModulesProcess,
                (EverestErrorLogProcess)ErrorLog, PhysicalIO.FatalExit);
        }

        string IEverestErrorLogEnvironment.Platform =>
            PhysicalIO.SDLRuntime.GetPlatform();

        string IEverestErrorLogEnvironment.BaseDirectory =>
            PhysicalIO.SavePaths.ApplicationBaseDirectory;

        string IEverestErrorLogEnvironment.VersionCelesteString =>
            EverestRuntime.VersionCelesteString;

        string IEverestErrorLogEnvironment.GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }

        string IEverestErrorLogEnvironment.GetPrefPath(string organization,
            string application)
        {
            return PhysicalIO.SDLRuntime.GetPrefPath(organization, application);
        }

        EverestCoreSettings IEverestErrorLogEnvironment
            .
            Settings =>
            CurrentCoreSettings;

        private VirtualContent sourceVirtualContent;

        public VirtualContent VirtualContent => sourceVirtualContent ??
                                                throw new InvalidOperationException(
                                                    "The shared virtual content process is not constructed.");

        private SourceTypeInitialization<
                EverestVirtualTextureTypeState>
            sourceVirtualTextureTypeInitialization;

        private EverestVirtualTextureTypeState VirtualTextureTypeState =>
            (sourceVirtualTextureTypeInitialization ??
             throw new InvalidOperationException(
                 "The installed VirtualTexture type initialization owner is not constructed.")).Value;

        public EverestTextureDataBuffers Buffers =>
            VirtualTextureTypeState.Buffers;

        public EverestFastTextureLoadingProcess FastLoading =>
            VirtualTextureTypeState.FastLoading;

        public void EnsureSourceVirtualTextureTypeInitialized()
        {
            _ = VirtualTextureTypeState;
        }

        public void ConstructSourceInstalledVirtualTextureTypeInitialization()
        {
            if (sourceVirtualTextureTypeInitialization != null)
                throw new InvalidOperationException(
                    "The installed VirtualTexture type initialization owner is already constructed.");
            sourceVirtualTextureTypeInitialization =
                new(
                    "Monocle.VirtualTexture",
                    new EverestVirtualTextureTypeState.Factory());
        }

        private EverestCriticalFailureProcess sourceCriticalFailure;

        public IEverestCriticalFailureProcess Failures =>
            sourceCriticalFailure ??
            throw new InvalidOperationException("The installed critical failure process is not constructed.");

        EverestContentRegistry
            IEverestVirtualTextureEnvironment.Content => SourceContentRegistry;

        EverestCoreSettings
            IEverestVirtualTextureEnvironment.Settings =>
            CurrentCoreSettings;

        IEverestVirtualTextureDiagnostics
            IEverestVirtualTextureEnvironment.Diagnostics => this;

        public XmlDocument LoadContentXml(string filename)
        {
            if (SourceProfile == GameProfile.InstalledEverest)
            {
                var virtualPath = filename.Substring(0, filename.Length - 4).Replace('\\', '/');
                if (virtualPath is "Graphics/Sprites" or "Graphics/SpritesGui" or "Graphics/Portraits")
                {
                    var reader = new EverestGraphicsXmlReader(
                        new FileEverestGraphicsContentIo(
                            SourceContentRegistry),
                        SourceContentRegistry, Logger);
                    return reader.LoadSpriteBank(filename);
                }

                if (SourceContentRegistry.TryGet<AssetTypeXml>(
                        filename.Substring(0, filename.Length - 4), out var metadata))
                {
                    var document = new XmlDocument();
                    using var stream = metadata.Stream;
                    document.Load(stream);
                    return document;
                }

                if (!File.Exists(Path.Combine(ContentDirectory, filename)))
                    return new();
            }

            return LoadOriginalContentXml(filename);
        }

        public XmlDocument LoadOriginalContentXml(string filename)
        {
            var originalDocument = new XmlDocument();
            using var originalStream = PhysicalIO.ContentFiles.OpenTitleStream(
                Path.Combine(ActualGame.Content.RootDirectory, filename));
            originalDocument.Load(originalStream);
            return originalDocument;
        }

        public void ConstructSourceVirtualContent()
        {
            if (sourceVirtualContent != null)
                throw new InvalidOperationException("The shared virtual content process is already constructed.");
            sourceVirtualContent = SourceProfile == GameProfile.InstalledEverest
                ? new EverestVirtualContent(this, RenderTargetFactory)
                : PhysicalIO.ContentFiles is ResidentContentSource resident
                    ? new ResidentVirtualContent(this,
                        RenderTargetFactory, resident)
                    : new VirtualContent(this, RenderTargetFactory);
        }

        private SourceApplicationRenderContext sourceRenderContext;

        public ISourceRenderContext CurrentContext => sourceRenderContext ??
                                                      throw new InvalidOperationException(
                                                          "The shared render context is not constructed.");

        public void ConstructSourceRenderContext()
        {
            if (sourceRenderContext != null)
                throw new InvalidOperationException("The shared render context is already constructed.");
            sourceRenderContext = new(this);
        }

        private EverestStartupRuntimeProcess sourceEverestRuntime;

        public EverestStartupRuntimeProcess EverestRuntime => sourceEverestRuntime ??
                                                              throw new InvalidOperationException(
                                                                  "The installed startup runtime is not constructed.");

        public string PathGame => EverestRuntime.PathGame;
        public string PathTmp => EverestRuntime.PathTmp;
        public string PathEverest => EverestRuntime.PathEverest;
        public string EverestVersionString => EverestRuntime.VersionString;
        Version IEverestCelesteVersionEnvironment.CelesteVersion => ActualGame.Version;

        public void ConstructSourceInstalledRuntime()
        {
            if (SourceProfile != GameProfile.InstalledEverest)
                throw new InvalidOperationException("The installed startup runtime requires the installed profile.");
            if (sourceEverestRuntime != null)
                throw new InvalidOperationException("The installed startup runtime is already constructed.");
            sourceEverestRuntime = new(this);
        }

        public void InitializeSourceInstalledGamePaths()
        {
            EverestRuntime.InitializeGamePathsFromDeploymentDirectory(SourceDeploymentGameDirectory,
                PhysicalIO.TemporaryDirectoryPath);
        }

        public void InitializeSourceInstalledStoragePaths()
        {
            EverestRuntime.InitializeStoragePaths(((IEverestLoggerProcessEnvironment)engine).Logger);
        }

        public void InitializeSourceInstalledFlags()
        {
            Flags.Initialize(EverestRuntime.PathGame);
        }

        public void ConstructSourceInstalledFileProxy()
        {
            if (sourceFileProxy != null)
                throw new InvalidOperationException("The installed file proxy is already constructed.");
            sourceFileProxy = new(SourceContentRegistry, EverestRuntime.PathTmp);
        }

        public ISourceRawImageCodec ImageCodec => ImageStreams;
        private SourceDataTextureFactory sourceTextureFactory;

        private SourceVirtualRenderTargetFactory
            sourceRenderTargetFactory;

        public ISourceDataTextureFactory TextureFactory =>
            sourceTextureFactory ??
            throw new InvalidOperationException("The source texture factory is not constructed.");

        public ISourceVirtualRenderTargetFactory RenderTargetFactory =>
            sourceRenderTargetFactory ??
            throw new InvalidOperationException("The source render target factory is not constructed.");

        public void ConstructSourceTextureFactories()
        {
            if (sourceTextureFactory != null || sourceRenderTargetFactory != null)
                throw new InvalidOperationException("The source texture factories are already constructed.");
            sourceTextureFactory = new(this, this);
            sourceRenderTargetFactory =
                new(this);
        }

        private EverestFlagsProcess sourceFlags;

        public EverestFlagsProcess Flags => sourceFlags ??
                                            throw new InvalidOperationException(
                                                "The installed flags process is not constructed.");

        public bool IsHeadless => Flags.IsHeadless;

        public void ConstructSourceInstalledFlags()
        {
            if (SourceProfile != GameProfile.InstalledEverest)
                throw new InvalidOperationException("The installed flags require the installed profile.");
            if (sourceFlags != null)
                throw new InvalidOperationException("The installed flags process is already constructed.");
            sourceFlags = new();
        }

        private EverestMainThreadProcess sourceMainThread;

        public EverestMainThreadProcess MainThread => sourceMainThread ??
                                                      throw new InvalidOperationException(
                                                          "The installed main thread process is not constructed.");

        public EverestMainThreadProcess MainThreadProcess => MainThread;

        public void ConstructSourceInstalledMainThread()
        {
            if (SourceProfile != GameProfile.InstalledEverest)
                throw new InvalidOperationException("The installed main thread requires the installed profile.");
            if (sourceMainThread != null)
                throw new InvalidOperationException("The installed main thread process is already constructed.");
            sourceMainThread =
                new(ActualGame.Framework);
        }

        public void AddSourceInstalledMainThreadComponent()
        {
            ActualGame.Components.Add(MainThread);
        }

        private EverestAtlasEvents sourceAtlasEvents;
        private ISourceAtlasConstruction sourceAtlasConstruction;

        public EverestAtlasEvents AtlasEvents => sourceAtlasEvents ??
                                                 throw new InvalidOperationException(
                                                     "The installed atlas events are not constructed.");

        public ISourceAtlasConstruction AtlasConstruction => sourceAtlasConstruction ??
                                                             throw new InvalidOperationException(
                                                                 "The source atlas construction is not constructed.");

        public void ConstructSourceAtlasConstruction()
        {
            if (sourceAtlasConstruction != null || sourceAtlasEvents != null)
                throw new InvalidOperationException("The source atlas construction is already constructed.");
            if (SourceProfile == GameProfile.InstalledEverest)
            {
                sourceAtlasEvents = new();
                sourceAtlasConstruction = new EverestAtlasConstruction(
                    SourceContentRegistry, sourceAtlasEvents, ((IEverestLoggerProcessEnvironment)engine).Logger);
            }
            else
            {
                sourceAtlasConstruction = new AtlasConstruction();
            }
        }

        private QueuedTaskScheduler sourceQueuedTasks;

        public QueuedTaskScheduler QueuedTasks => sourceQueuedTasks ??
                                                  throw new InvalidOperationException(
                                                      "The actual installed queued-task scheduler is not constructed.");

        EverestLoggerProcess IEverestContentProcessingEnvironment.Logger =>
            Logger;

        IEverestContentDiagnostics IEverestLoaderContentEnvironment.ContentDiagnostics => this;

        QueuedTaskScheduler IEverestLoaderContentEnvironment.QueuedTasks =>
            QueuedTasks;

        EverestVirtualContent IEverestContentProcessingEnvironment.
            VirtualContent =>
            (EverestVirtualContent)VirtualContent;

        IEverestAtlasIngestDiagnostics IEverestContentProcessingEnvironment.
            AtlasIngestDiagnostics =>
            Logger;

        bool IEverestContentProcessingEnvironment.ContentLoaded => EverestRuntime.IsContentLoaded;

        public SourceEverestEmojiState Emoji => sourceEmoji ??
                                                throw new InvalidOperationException(
                                                    "The actual installed emoji process is not constructed.");

        private EverestContentRegistry sourceContentRegistry;
        private EverestYamlProcess sourceYaml;
        private SourceEverestFileProxyProcess sourceFileProxy;
        private ISourceXmlDocumentLoadingPolicy sourceXmlDocumentLoading;

        public EverestContentRegistry SourceContentRegistry => sourceContentRegistry ??
                                                               throw new InvalidOperationException(
                                                                   "The installed content registry is not constructed.");

        public EverestYamlProcess Yaml => sourceYaml ??
                                          throw new InvalidOperationException(
                                              "The installed YAML process is not constructed.");

        public SourceEverestFileProxyProcess FileProxy => sourceFileProxy ??
                                                          throw new InvalidOperationException(
                                                              "The installed file proxy is not constructed.");

        public ISourceXmlDocumentLoadingPolicy XmlDocumentLoading => sourceXmlDocumentLoading ??
                                                                     throw new InvalidOperationException(
                                                                         "The source XML loading policy is not constructed.");

        public void InitializeSourceInstalledContent()
        {
            ActualGame.Content = SourceContentRegistry.CreateSourceContentManager(ActualGame.Content, Content);
            SourceContentRegistry.InitializeBuiltInSourcePaths(PathGame, ActualGame.Content.RootDirectory, PathEverest);
            SourceContentRegistry.Crawl(new AssemblyContentSource(
                SourceContentRegistry, typeof(EverestStartupRuntimeProcess).Assembly) { Name = "Everest" });
        }

        public void ConstructSourceInstalledContent()
        {
            if (SourceProfile != GameProfile.InstalledEverest)
                throw new InvalidOperationException("Installed content requires the installed profile.");
            if (sourceContentRegistry != null || sourceYaml != null)
                throw new InvalidOperationException("The installed content processes are already constructed.");
            sourceContentRegistry = new(this, this);
            sourceYaml = new();
            sourceQueuedTasks =
                new(
                    Logger);
        }

        public void ConstructSourceXmlDocumentLoading()
        {
            if (sourceXmlDocumentLoading != null)
                throw new InvalidOperationException("The source XML policy is already constructed.");
            if (SourceProfile == GameProfile.InstalledEverest)
                sourceXmlDocumentLoading = new EverestXmlDocumentLoadingPolicy(SourceContentRegistry);
            else
                sourceXmlDocumentLoading = new OriginalXmlDocumentLoadingPolicy(
                    PhysicalIO.ContentFiles is ResidentContentSource
                        ? PhysicalIO.ContentFiles
                        : null);
        }

        void IEverestContentDiagnostics.Warning(string category, string message)
        {
            ((IEverestLoggerProcessEnvironment)engine).Logger.Log(EverestLogLevel.Warn, category, message);
        }

        void IEverestContentDiagnostics.Verbose(string category, string message)
        {
            ((IEverestLoggerProcessEnvironment)engine).Logger.Log(EverestLogLevel.Verbose, category, message);
        }

        private OriginalGameTextProcess sourceText;
        private ISourcePixelFontFactory sourcePixelFontFactory;
        private IOriginalFontRegistryPolicy sourceFontRegistryPolicy;
        private IOriginalFontRegistryContentPolicy sourceFontRegistryContentPolicy;
        private SourceEverestEmojiState sourceEmoji;

        public OriginalGameTextProcess Text => sourceText ??
                                               throw new InvalidOperationException(
                                                   "The source text process is not constructed.");

        public ActiveBitmapFont ActiveFont => Text.ActiveFont;
        public AtlasData GuiAtlas => GraphicsResources.GuiAtlas;

        public ISourcePixelFontFactory PixelFontFactory => sourcePixelFontFactory ??
                                                           throw new InvalidOperationException(
                                                               "The source pixel font factory is not constructed.");

        public IOriginalFontRegistryPolicy FontRegistryPolicy => sourceFontRegistryPolicy ??
                                                                 throw new InvalidOperationException(
                                                                     "The source font lifecycle policy is not constructed.");

        public IOriginalFontRegistryContentPolicy FontRegistryContentPolicy => sourceFontRegistryContentPolicy ??
                                                                               throw new InvalidOperationException(
                                                                                   "The source font content policy is not constructed.");

        public IOriginalFontRegistryAugmentation FontAugmentation => sourceEmoji ??
                                                                     throw new InvalidOperationException(
                                                                         "The installed source emoji process is not constructed.");

        SourceCommands IOriginalFontRegistryProcess.Commands =>
            ((ISourceCommandsProcessEnvironment)engine).Commands;

        public void ConstructSourceTextProcess()
        {
            if (sourceText != null || sourcePixelFontFactory != null)
                throw new InvalidOperationException("The source text process is already constructed.");
            if (SourceProfile == GameProfile.InstalledEverest)
            {
                sourcePixelFontFactory = new SourceEverestPixelFontFactory();
                sourceFontRegistryPolicy = new ExtendedFontRegistryLifecyclePolicy();
                sourceFontRegistryContentPolicy = new EverestFontRegistryPolicy();
                sourceEmoji = new(this);
            }
            else
            {
                sourcePixelFontFactory = new SourcePixelFontFactory();
                var original = new OriginalFontRegistryPolicy(
                    PhysicalIO.ContentFiles is ResidentContentSource
                        ? PhysicalIO.ContentFiles
                        : null);
                sourceFontRegistryPolicy = original;
                sourceFontRegistryContentPolicy = original;
            }

            sourceText = new(this, OriginalDialogLookupPolicy.Shared, this);
        }

        private EverestLoaderProcess sourceLoader;

        public EverestLoaderProcess Loader => sourceLoader ??
                                              throw new InvalidOperationException(
                                                  "The installed loader process is not constructed.");

        public void ConstructSourceInstalledLoader()
        {
            if (sourceLoader != null)
                throw new InvalidOperationException("The installed loader process is already constructed.");
            sourceLoader = new(this);
        }

        private EverestGameLoaderEvents sourceGameLoaderEvents;
        private EverestModUpdaterProcess sourceModUpdater;
        private EverestCompressedHttpProcess sourceCompressedHttp;

        public EverestGameLoaderEvents GameLoaderEvents => sourceGameLoaderEvents ??
                                                           throw new InvalidOperationException(
                                                               "The installed GameLoader events are not constructed.");

        public EverestModUpdaterProcess ModUpdater => sourceModUpdater ??
                                                      throw new InvalidOperationException(
                                                          "The installed mod updater is not constructed.");

        public EverestCompressedHttpProcess CompressedHttp => sourceCompressedHttp ??
                                                              throw new InvalidOperationException(
                                                                  "The installed compressed HTTP process is not constructed.");

        public void ConstructSourceInstalledStartupProcesses()
        {
            if (SourceProfile != GameProfile.InstalledEverest)
                throw new InvalidOperationException("Installed startup processes require the installed profile.");
            if (sourceGameLoaderEvents != null || sourceModUpdater != null || sourceCompressedHttp != null)
                throw new InvalidOperationException("The installed startup processes are already constructed.");
            sourceGameLoaderEvents = new();
            sourceModUpdater = new(this);
            sourceCompressedHttp = new(this);
        }

        private OriginalGameGraphicsResources sourceGameGraphics;
        private OriginalMountainResources sourceMountainResources;
        private OriginalStartupResources sourceStartupResources;
        private OriginalStartupSceneFactory sourceStartupScenes;

        public OriginalGameGraphicsResources GraphicsResources => sourceGameGraphics ??
                                                                  throw new InvalidOperationException(
                                                                      "The source GFX resources are not constructed.");

        ISourceGameGraphicsResources ISourceGameGraphicsEnvironment.GameGraphics => GraphicsResources;

        public OriginalMountainResources MountainResources => sourceMountainResources ??
                                                              throw new InvalidOperationException(
                                                                  "The source mountain resources are not constructed.");

        public OriginalStartupResources StartupResources => sourceStartupResources ??
                                                            throw new InvalidOperationException(
                                                                "The source startup resources are not constructed.");

        public OriginalStartupSceneFactory StartupScenes => sourceStartupScenes ??
                                                            throw new InvalidOperationException(
                                                                "The source startup scene factory is not constructed.");

        public void ConstructSourceStartupGraphics()
        {
            if (sourceGameGraphics != null)
                throw new InvalidOperationException("The source GFX resources are already constructed.");
            sourceGameGraphics = new();
            sourceMountainResources = new();
            if (SourceProfile == GameProfile.InstalledEverest)
                sourceMountainExtension =
                    new(this);
        }

        public void InitializeSourceDrawing()
        {
            new OriginalMonocleDrawInitialization(Draw,
                VirtualContent,
                this).Initialize();
        }

        public SourceSpriteFont LoadDefaultSpriteFont(string assetName)
        {
            return ContentManager.Load<SourceSpriteFont>(assetName);
        }

        public void ConstructSourceStartupScenes()
        {
            if (sourceStartupScenes != null || sourceStartupResources != null)
                throw new InvalidOperationException("The source startup resources are already constructed.");
            sourceStartupResources = new(this);
            IOriginalGameLoaderConstruction construction;
            if (SourceProfile == GameProfile.InstalledEverest)
                construction = new EverestGameLoaderConstruction();
            else
                construction = new OriginalGameLoaderConstruction();
            sourceStartupScenes = new(this,
                sourceStartupResources, construction);
        }

        AtlasEntry IOriginalLanguageTextureFactory.CreateTexture(string contentRelativePath)
        {
            var atlasEnvironment = (ISourceAtlasLoaderEnvironment)this;
            var texture = atlasEnvironment.VirtualContent.CreateTexture(contentRelativePath);
            return atlasEnvironment.AtlasConstruction.CreateEntry(texture, null);
        }

        public void AssignSourceGameLoaderScene()
        {
            Frame.Scenes.NextScene = StartupScenes.CreateGameLoader();
        }
    }
}
