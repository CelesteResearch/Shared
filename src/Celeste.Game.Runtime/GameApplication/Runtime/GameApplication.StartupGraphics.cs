using Celeste.Everest;
using System;
using Celeste.Everest.Runtime.Startup;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Content.Xml;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Core.Serialization.Xml;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Content.Fonts;
using Celeste.Everest.Text.BitmapFonts;
using Celeste.Graphics.Text;
using Celeste.Graphics.Text.BitmapFonts;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Graphics.Content.Atlas;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Graphics.Drawing;
using Celeste.Game.Profiles;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Text.Fonts;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication :
        global::Celeste.Core.Serialization.Xml.ISourceOriginalContentXmlEnvironment, ISourceGameGraphicsEnvironment,
        ISourceDrawScope, global::Celeste.Core.Rendering.ISourceRenderEnvironment,
        global::Celeste.Graphics.Content.Compiled.ISourceContentManagerEnvironment,
        ISourceXmlDocumentLoadingEnvironment,
        IOriginalDrawInitializationResources, IOriginalStartupSceneEnvironment, IOriginalMountainEnvironment,
        IOriginalLanguageTextureFactory, IEverestGameLoaderEventsEnvironment, IEverestLoaderProcessEnvironment,
        IEverestModUpdaterEnvironment, IEverestCompressedHttpEnvironment, IOriginalGameTextEnvironment,
        ISourceActiveFontScope, IOriginalFontRegistryProcess, IOriginalFontRegistryAugmentationEnvironment,
        IEverestEmojiProcess, IEverestPixelFontProcess, IEverestFontRegistryProcess, IEverestContentRegistryEnvironment,
        global::Celeste.Everest.Content.Registry.ISourceEverestFileProxyEnvironment, IEverestContentDiagnostics,
        IEverestYamlEnvironment, IEverestGamePathEnvironment, IEverestVersionStringEnvironment,
        global::Celeste.Everest.Runtime.Threading.ISourceEverestMainThreadEnvironment,
        global::Celeste.Everest.Runtime.IEverestHeadlessEnvironment,
        global::Celeste.Everest.Content.Textures.IEverestVirtualTextureDiagnostics,
        global::Celeste.Everest.Content.Textures.IEverestVirtualTextureEnvironment,
        global::Celeste.Formats.Graphics.Atlas.ISourceAtlasLoaderEnvironment,
        global::Celeste.Everest.Runtime.Failures.IEverestErrorLogEnvironment,
        global::Celeste.Graphics.Content.VirtualAssets.ISourceVirtualContentEnvironment, IEverestSplashEnvironment,
        global::Celeste.Game.Entities.IntroCar.IOriginalIntroCarEnvironment, IEverestStartupRuntimeEnvironment,
        IEverestCelesteVersionEnvironment, global::Celeste.Graphics.Content.Gui.ISourceGuiAtlasResources,
        IEverestContentProcessingEnvironment, IEverestLoaderContentEnvironment,
        global::Celeste.Everest.Runtime.IEverestFlagsEnvironment,
        global::Celeste.Everest.Modules.Updating.IEverestUpdaterPhysicalEnvironment,
        global::Celeste.Game.Credits.IOriginalCreditsGraphicsEnvironment
    {
        global::Celeste.Core.IO.Content.IContentSource
            global::Celeste.Formats.Graphics.Atlas.ISourceAtlasLoaderEnvironment.ContentFiles =>
            PhysicalIO.ContentFiles;

        global::Celeste.Core.IO.Content.IContentSource
            global::Celeste.Graphics.Content.VirtualAssets.ISourceVirtualTextureEnvironment.ContentFiles =>
            PhysicalIO.ContentFiles;

        private EverestSplashProcess sourceSplash;

        public EverestSplashProcess Splash => sourceSplash ??
                                              throw new InvalidOperationException(
                                                  "The installed splash process is not constructed.");

        public void ConstructSourceInstalledSplash()
        {
            if (sourceSplash != null)
                throw new InvalidOperationException("The installed splash process is already constructed.");
            sourceSplash = new EverestSplashProcess(((IEverestLoggerProcessEnvironment)this).Logger,
                PhysicalIO.Splash ??
                throw new System.InvalidOperationException(
                    "The enabled Everest profile requires its splash transport."));
        }

        private global::Celeste.Game.Entities.IntroCar.IOriginalIntroCarFactory sourceIntroCars;

        public global::Celeste.Game.Entities.IntroCar.IOriginalIntroCarFactory IntroCars => sourceIntroCars ??
            throw new InvalidOperationException("The source intro car factory is not selected.");

        public void ConstructSourceIntroCarFactory()
        {
            if (sourceIntroCars != null)
                throw new InvalidOperationException("The source intro car factory is already selected.");
            if (SourceProfile == GameProfile.InstalledEverest)
                sourceIntroCars = new global::Celeste.Everest.Entities.IntroCar.EverestIntroCarFactory();
            else
                sourceIntroCars = new global::Celeste.Game.Entities.IntroCar.OriginalIntroCarFactory();
        }

        void global::Celeste.Everest.Content.Textures.IEverestVirtualTextureDiagnostics.InvalidPngMagic(ulong value,
            string path)
        {
            var message =
                ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("vtex", EverestLogLevel.Error);
            if (message.ShouldLog)
                message.Write("Failed preloading PNG: Expected magic to be 0x0A1A0A0D474E5089, got 0x" +
                              value.ToString("X16") + " - " + path);
        }

        void global::Celeste.Everest.Content.Textures.IEverestVirtualTextureDiagnostics.InvalidPngFirstChunkLength(
            uint value, string path)
        {
            var message =
                ((IEverestLoggerProcessEnvironment)engine).Logger.BeginEnabledMessage("vtex", EverestLogLevel.Error);
            if (message.ShouldLog)
                message.Write("Failed preloading PNG: Expected first chunk length to be 0x0D000000, got 0x" +
                              value.ToString("X8") + " - " + path);
        }

        void global::Celeste.Everest.Content.Textures.IEverestVirtualTextureDiagnostics.InvalidPngHeaderMarker(
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
            => ((global::Celeste.Everest.Modules.Runtime.ISourceEverestModulesProcessEnvironment)this).ModulesProcess
                .InitializeSourceBootDetourHooks();

        private global::Celeste.Game.Execution.Diagnostics.OriginalErrorLogProcess CreateSourceInstalledErrorLog()
            => new global::Celeste.Everest.Runtime.Failures.EverestErrorLogProcess(
                PhysicalIO.ErrorLog, this, ((IEverestLoggerProcessEnvironment)this).Logger,
                ((global::Celeste.Everest.Modules.Runtime.ISourceEverestModulesProcessEnvironment)this).ModulesProcess);

        public void ConstructSourceInstalledCriticalFailure()
        {
            if (sourceCriticalFailure != null)
                throw new InvalidOperationException("The installed critical failure process is already constructed.");
            sourceCriticalFailure = new global::Celeste.Everest.Runtime.Failures.EverestCriticalFailureProcess(
                ((IEverestLoggerProcessEnvironment)this).Logger,
                ((global::Celeste.Everest.Modules.Runtime.ISourceEverestModulesProcessEnvironment)this).ModulesProcess,
                (global::Celeste.Everest.Runtime.Failures.EverestErrorLogProcess)ErrorLog, PhysicalIO.FatalExit);
        }

        string global::Celeste.Everest.Runtime.Failures.IEverestErrorLogEnvironment.Platform =>
            PhysicalIO.SDLRuntime.GetPlatform();

        string global::Celeste.Everest.Runtime.Failures.IEverestErrorLogEnvironment.BaseDirectory =>
            PhysicalIO.SavePaths.ApplicationBaseDirectory;

        string global::Celeste.Everest.Runtime.Failures.IEverestErrorLogEnvironment.VersionCelesteString =>
            EverestRuntime.VersionCelesteString;

        string global::Celeste.Everest.Runtime.Failures.IEverestErrorLogEnvironment.GetEnvironmentVariable(string name)
            => Environment.GetEnvironmentVariable(name);

        string global::Celeste.Everest.Runtime.Failures.IEverestErrorLogEnvironment.GetPrefPath(string organization,
            string application)
            => PhysicalIO.SDLRuntime.GetPrefPath(organization, application);

        global::Celeste.Everest.EverestCoreSettings global::Celeste.Everest.Runtime.Failures.IEverestErrorLogEnvironment
            .
            Settings =>
            ((global::Celeste.Everest.Modules.Settings.IEverestCurrentCoreSettingsEnvironment)this).CurrentCoreSettings;

        private global::Celeste.Graphics.Content.VirtualAssets.VirtualContent sourceVirtualContent;

        public global::Celeste.Graphics.Content.VirtualAssets.VirtualContent VirtualContent => sourceVirtualContent ??
            throw new InvalidOperationException("The shared virtual content process is not constructed.");

        private global::Celeste.Core.Threading.SourceTypeInitialization<
                global::Celeste.Everest.Content.Textures.EverestVirtualTextureTypeState>
            sourceVirtualTextureTypeInitialization;

        private global::Celeste.Everest.Content.Textures.EverestVirtualTextureTypeState VirtualTextureTypeState =>
            (sourceVirtualTextureTypeInitialization ??
             throw new InvalidOperationException(
                 "The installed VirtualTexture type initialization owner is not constructed.")).Value;

        public global::Celeste.Everest.Content.Textures.EverestTextureDataBuffers Buffers =>
            VirtualTextureTypeState.Buffers;

        public global::Celeste.Everest.Content.Textures.EverestFastTextureLoadingProcess FastLoading =>
            VirtualTextureTypeState.FastLoading;

        public void EnsureSourceVirtualTextureTypeInitialized() => _ = VirtualTextureTypeState;

        public void ConstructSourceInstalledVirtualTextureTypeInitialization()
        {
            if (sourceVirtualTextureTypeInitialization != null)
                throw new InvalidOperationException(
                    "The installed VirtualTexture type initialization owner is already constructed.");
            sourceVirtualTextureTypeInitialization =
                new global::Celeste.Core.Threading.SourceTypeInitialization<
                    global::Celeste.Everest.Content.Textures.EverestVirtualTextureTypeState>(
                    "Monocle.VirtualTexture",
                    new global::Celeste.Everest.Content.Textures.EverestVirtualTextureTypeState.Factory());
        }

        private global::Celeste.Everest.Runtime.Failures.EverestCriticalFailureProcess sourceCriticalFailure;

        public global::Celeste.Everest.Runtime.Failures.IEverestCriticalFailureProcess Failures =>
            sourceCriticalFailure ??
            throw new InvalidOperationException("The installed critical failure process is not constructed.");

        global::Celeste.Everest.Content.Registry.EverestContentRegistry
            global::Celeste.Everest.Content.Textures.IEverestVirtualTextureEnvironment.Content => SourceContentRegistry;

        global::Celeste.Everest.EverestCoreSettings
            global::Celeste.Everest.Content.Textures.IEverestVirtualTextureEnvironment.Settings =>
            ((global::Celeste.Everest.Modules.Settings.IEverestCurrentCoreSettingsEnvironment)this).CurrentCoreSettings;

        global::Celeste.Everest.Content.Textures.IEverestVirtualTextureDiagnostics
            global::Celeste.Everest.Content.Textures.IEverestVirtualTextureEnvironment.Diagnostics => this;

        public System.Xml.XmlDocument LoadContentXml(string filename)
        {
            if (SourceProfile == GameProfile.InstalledEverest)
            {
                string virtualPath = filename.Substring(0, filename.Length - 4).Replace('\\', '/');
                if (virtualPath is "Graphics/Sprites" or "Graphics/SpritesGui" or "Graphics/Portraits")
                {
                    var reader = new global::Celeste.Everest.Content.Graphics.EverestGraphicsXmlReader(
                        new global::Celeste.Everest.Content.Graphics.FileEverestGraphicsContentIo(
                            SourceContentRegistry),
                        SourceContentRegistry, Logger);
                    return reader.LoadSpriteBank(filename);
                }

                if (SourceContentRegistry.TryGet<global::Celeste.Everest.Content.Types.Text.AssetTypeXml>(
                        filename.Substring(0, filename.Length - 4), out var metadata))
                {
                    var document = new System.Xml.XmlDocument();
                    using System.IO.Stream stream = metadata.Stream;
                    document.Load(stream);
                    return document;
                }

                if (!System.IO.File.Exists(System.IO.Path.Combine(ContentDirectory, filename)))
                    return new System.Xml.XmlDocument();
            }

            return LoadOriginalContentXml(filename);
        }

        public System.Xml.XmlDocument LoadOriginalContentXml(string filename)
        {
            var originalDocument = new System.Xml.XmlDocument();
            using System.IO.Stream originalStream = PhysicalIO.ContentFiles.OpenTitleStream(
                System.IO.Path.Combine(ActualGame.Content.RootDirectory, filename));
            originalDocument.Load(originalStream);
            return originalDocument;
        }

        public void ConstructSourceVirtualContent()
        {
            if (sourceVirtualContent != null)
                throw new InvalidOperationException("The shared virtual content process is already constructed.");
            sourceVirtualContent = SourceProfile == GameProfile.InstalledEverest
                ? new global::Celeste.Everest.Content.Textures.EverestVirtualContent(this, RenderTargetFactory)
                : PhysicalIO.ContentFiles is global::Celeste.Core.IO.Content.ResidentContentSource resident
                    ? new global::Celeste.Graphics.Content.VirtualAssets.ResidentVirtualContent(this,
                        RenderTargetFactory, resident)
                    : new global::Celeste.Graphics.Content.VirtualAssets.VirtualContent(this, RenderTargetFactory);
        }

        private global::Celeste.Game.Runtime.Rendering.SourceApplicationRenderContext sourceRenderContext;

        public global::Celeste.Core.Rendering.ISourceRenderContext CurrentContext => sourceRenderContext ??
            throw new InvalidOperationException("The shared render context is not constructed.");

        public void ConstructSourceRenderContext()
        {
            if (sourceRenderContext != null)
                throw new InvalidOperationException("The shared render context is already constructed.");
            sourceRenderContext = new global::Celeste.Game.Runtime.Rendering.SourceApplicationRenderContext(this);
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
            sourceEverestRuntime = new EverestStartupRuntimeProcess(this);
        }

        public void InitializeSourceInstalledGamePaths()
            => EverestRuntime.InitializeGamePathsFromDeploymentDirectory(SourceDeploymentGameDirectory,
                PhysicalIO.TemporaryDirectoryPath);

        public void InitializeSourceInstalledStoragePaths()
            => EverestRuntime.InitializeStoragePaths(((IEverestLoggerProcessEnvironment)engine).Logger);

        public void InitializeSourceInstalledFlags()
            => Flags.Initialize(EverestRuntime.PathGame);

        public void ConstructSourceInstalledFileProxy()
        {
            if (sourceFileProxy != null)
                throw new InvalidOperationException("The installed file proxy is already constructed.");
            sourceFileProxy = new SourceEverestFileProxyProcess(SourceContentRegistry, EverestRuntime.PathTmp);
        }

        public global::Celeste.Graphics.Content.Textures.ISourceRawImageCodec ImageCodec => ImageStreams;
        private global::Celeste.Graphics.Content.Textures.SourceDataTextureFactory sourceTextureFactory;

        private global::Celeste.Graphics.Content.VirtualAssets.SourceVirtualRenderTargetFactory
            sourceRenderTargetFactory;

        public global::Celeste.Graphics.Content.Textures.ISourceDataTextureFactory TextureFactory =>
            sourceTextureFactory ??
            throw new InvalidOperationException("The source texture factory is not constructed.");

        public global::Celeste.Graphics.Content.VirtualAssets.ISourceVirtualRenderTargetFactory RenderTargetFactory =>
            sourceRenderTargetFactory ??
            throw new InvalidOperationException("The source render target factory is not constructed.");

        public void ConstructSourceTextureFactories()
        {
            if (sourceTextureFactory != null || sourceRenderTargetFactory != null)
                throw new InvalidOperationException("The source texture factories are already constructed.");
            sourceTextureFactory = new global::Celeste.Graphics.Content.Textures.SourceDataTextureFactory(this, this);
            sourceRenderTargetFactory =
                new global::Celeste.Graphics.Content.VirtualAssets.SourceVirtualRenderTargetFactory(this);
        }

        private global::Celeste.Everest.Runtime.EverestFlagsProcess sourceFlags;

        public global::Celeste.Everest.Runtime.EverestFlagsProcess Flags => sourceFlags ??
                                                                            throw new InvalidOperationException(
                                                                                "The installed flags process is not constructed.");

        public bool IsHeadless => Flags.IsHeadless;

        public void ConstructSourceInstalledFlags()
        {
            if (SourceProfile != GameProfile.InstalledEverest)
                throw new InvalidOperationException("The installed flags require the installed profile.");
            if (sourceFlags != null)
                throw new InvalidOperationException("The installed flags process is already constructed.");
            sourceFlags = new global::Celeste.Everest.Runtime.EverestFlagsProcess();
        }

        private global::Celeste.Everest.Runtime.Threading.EverestMainThreadProcess sourceMainThread;

        public global::Celeste.Everest.Runtime.Threading.EverestMainThreadProcess MainThread => sourceMainThread ??
            throw new InvalidOperationException("The installed main thread process is not constructed.");

        public global::Celeste.Everest.Runtime.Threading.EverestMainThreadProcess MainThreadProcess => MainThread;

        public void ConstructSourceInstalledMainThread()
        {
            if (SourceProfile != GameProfile.InstalledEverest)
                throw new InvalidOperationException("The installed main thread requires the installed profile.");
            if (sourceMainThread != null)
                throw new InvalidOperationException("The installed main thread process is already constructed.");
            sourceMainThread =
                new global::Celeste.Everest.Runtime.Threading.EverestMainThreadProcess(ActualGame.Framework);
        }

        public void AddSourceInstalledMainThreadComponent()
            => ActualGame.Components.Add(MainThread);

        private global::Celeste.Everest.Content.Atlases.EverestAtlasEvents sourceAtlasEvents;
        private ISourceAtlasConstruction sourceAtlasConstruction;

        public global::Celeste.Everest.Content.Atlases.EverestAtlasEvents AtlasEvents => sourceAtlasEvents ??
            throw new InvalidOperationException("The installed atlas events are not constructed.");

        public ISourceAtlasConstruction AtlasConstruction => sourceAtlasConstruction ??
                                                             throw new InvalidOperationException(
                                                                 "The source atlas construction is not constructed.");

        public void ConstructSourceAtlasConstruction()
        {
            if (sourceAtlasConstruction != null || sourceAtlasEvents != null)
                throw new InvalidOperationException("The source atlas construction is already constructed.");
            if (SourceProfile == GameProfile.InstalledEverest)
            {
                sourceAtlasEvents = new global::Celeste.Everest.Content.Atlases.EverestAtlasEvents();
                sourceAtlasConstruction = new global::Celeste.Everest.Content.Atlases.EverestAtlasConstruction(
                    SourceContentRegistry, sourceAtlasEvents, ((IEverestLoggerProcessEnvironment)engine).Logger);
            }
            else
                sourceAtlasConstruction = new global::Celeste.Formats.Graphics.Atlas.AtlasConstruction();
        }

        private global::Celeste.Everest.Tasks.Queuing.QueuedTaskScheduler sourceQueuedTasks;

        public global::Celeste.Everest.Tasks.Queuing.QueuedTaskScheduler QueuedTasks => sourceQueuedTasks ??
            throw new InvalidOperationException("The actual installed queued-task scheduler is not constructed.");

        EverestLoggerProcess IEverestContentProcessingEnvironment.Logger =>
            ((IEverestLoggerProcessEnvironment)this).Logger;

        IEverestContentDiagnostics IEverestLoaderContentEnvironment.ContentDiagnostics => this;

        global::Celeste.Everest.Tasks.Queuing.QueuedTaskScheduler IEverestLoaderContentEnvironment.QueuedTasks =>
            QueuedTasks;

        global::Celeste.Everest.Content.Textures.EverestVirtualContent IEverestContentProcessingEnvironment.
            VirtualContent =>
            (global::Celeste.Everest.Content.Textures.EverestVirtualContent)VirtualContent;

        global::Celeste.Everest.Content.Atlases.IEverestAtlasIngestDiagnostics IEverestContentProcessingEnvironment.
            AtlasIngestDiagnostics =>
            ((IEverestLoggerProcessEnvironment)this).Logger;

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
            SourceContentRegistry.Crawl(new global::Celeste.Everest.Content.Sources.AssemblyContentSource(
                SourceContentRegistry, typeof(EverestStartupRuntimeProcess).Assembly) { Name = "Everest" });
        }

        public void ConstructSourceInstalledContent()
        {
            if (SourceProfile != GameProfile.InstalledEverest)
                throw new InvalidOperationException("Installed content requires the installed profile.");
            if (sourceContentRegistry != null || sourceYaml != null)
                throw new InvalidOperationException("The installed content processes are already constructed.");
            sourceContentRegistry = new EverestContentRegistry(this, this);
            sourceYaml = new EverestYamlProcess();
            sourceQueuedTasks =
                new global::Celeste.Everest.Tasks.Queuing.QueuedTaskScheduler(((IEverestLoggerProcessEnvironment)this)
                    .Logger);
        }

        public void ConstructSourceXmlDocumentLoading()
        {
            if (sourceXmlDocumentLoading != null)
                throw new InvalidOperationException("The source XML policy is already constructed.");
            if (SourceProfile == GameProfile.InstalledEverest)
                sourceXmlDocumentLoading = new EverestXmlDocumentLoadingPolicy(SourceContentRegistry);
            else
                sourceXmlDocumentLoading = new OriginalXmlDocumentLoadingPolicy(
                    PhysicalIO.ContentFiles is global::Celeste.Core.IO.Content.ResidentContentSource
                        ? PhysicalIO.ContentFiles
                        : null);
        }

        void IEverestContentDiagnostics.Warning(string category, string message)
            => ((IEverestLoggerProcessEnvironment)engine).Logger.Log(EverestLogLevel.Warn, category, message);

        void IEverestContentDiagnostics.Verbose(string category, string message)
            => ((IEverestLoggerProcessEnvironment)engine).Logger.Log(EverestLogLevel.Verbose, category, message);

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
                sourceEmoji = new SourceEverestEmojiState(this);
            }
            else
            {
                sourcePixelFontFactory = new SourcePixelFontFactory();
                var original = new OriginalFontRegistryPolicy(
                    PhysicalIO.ContentFiles is global::Celeste.Core.IO.Content.ResidentContentSource
                        ? PhysicalIO.ContentFiles
                        : null);
                sourceFontRegistryPolicy = original;
                sourceFontRegistryContentPolicy = original;
            }

            sourceText = new OriginalGameTextProcess(this, OriginalDialogLookupPolicy.Shared, this);
        }

        private EverestLoaderProcess sourceLoader;

        public EverestLoaderProcess Loader => sourceLoader ??
                                              throw new InvalidOperationException(
                                                  "The installed loader process is not constructed.");

        public void ConstructSourceInstalledLoader()
        {
            if (sourceLoader != null)
                throw new InvalidOperationException("The installed loader process is already constructed.");
            sourceLoader = new EverestLoaderProcess(this);
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
            sourceGameLoaderEvents = new EverestGameLoaderEvents();
            sourceModUpdater = new EverestModUpdaterProcess(this);
            sourceCompressedHttp = new EverestCompressedHttpProcess(this);
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
            sourceGameGraphics = new OriginalGameGraphicsResources();
            sourceMountainResources = new OriginalMountainResources();
            if (SourceProfile == GameProfile.InstalledEverest)
                sourceMountainExtension =
                    new global::Celeste.Everest.Presentation.Mountain.Model.EverestMountainExtensionProcess(this);
        }

        public void InitializeSourceDrawing()
        {
            new OriginalMonocleDrawInitialization(Draw,
                ((global::Celeste.Formats.Graphics.Atlas.ISourceAtlasLoaderEnvironment)this).VirtualContent,
                this).Initialize();
        }

        public SourceSpriteFont LoadDefaultSpriteFont(string assetName)
            => ContentManager.Load<SourceSpriteFont>(assetName);

        public void ConstructSourceStartupScenes()
        {
            if (sourceStartupScenes != null || sourceStartupResources != null)
                throw new InvalidOperationException("The source startup resources are already constructed.");
            sourceStartupResources = new OriginalStartupResources(this);
            IOriginalGameLoaderConstruction construction;
            if (SourceProfile == GameProfile.InstalledEverest)
                construction = new EverestGameLoaderConstruction();
            else
                construction = new OriginalGameLoaderConstruction();
            sourceStartupScenes = new OriginalStartupSceneFactory(this,
                sourceStartupResources, construction);
        }

        AtlasEntry IOriginalLanguageTextureFactory.CreateTexture(string contentRelativePath)
        {
            var atlasEnvironment = (global::Celeste.Formats.Graphics.Atlas.ISourceAtlasLoaderEnvironment)this;
            var texture = atlasEnvironment.VirtualContent.CreateTexture(contentRelativePath);
            return atlasEnvironment.AtlasConstruction.CreateEntry(texture, null);
        }

        public void AssignSourceGameLoaderScene()
            => Frame.Scenes.NextScene = StartupScenes.CreateGameLoader();
    }
}
