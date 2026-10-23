using System;
using Celeste.Game.Profiles;
using Celeste.Game.Runtime.Platform;

namespace Celeste.Game.Runtime
{
    public static class GameApplicationFactory
    {
        public static GameApplication Create(GameProfile profile,
            GamePlatformServices physicalIO)
        {
            if (physicalIO == null) throw new ArgumentNullException(nameof(physicalIO));
            if (physicalIO.CompiledSourceDeployment != null && profile != GameProfile.Original)
                throw new PlatformNotSupportedException(
                    "Compiled source startup currently requires the Original game profile.");
            var process = new GameApplication(profile, physicalIO.GarbageCollection);
            try
            {
                var constructed = Construct(process, profile, physicalIO);
                if (constructed == null) process.DisposeFailedConstruction(null);
                return constructed;
            }
            catch (Exception constructionFailure)
            {
                try
                {
                    process.WriteSourceExceptionToLog(constructionFailure);
                }
                catch (Exception logFailure)
                {
                    constructionFailure.Data["LogWriteFailure"] = logFailure;
                }

                process.DisposeFailedConstruction(constructionFailure);
                throw;
            }
        }

        private static GameApplication Construct(GameApplication process, GameProfile profile,
            GamePlatformServices physicalIO)
        {
            process.BindPhysicalIO(physicalIO);
            process.ConstructSourceSteamApplication();
            process.InitializeSourceRuntimePaths();
            process.ConstructSourceArithmetic();
            process.ConstructSourceSceneCatalog();
            process.ConstructSourceTrackerInitialization();
            process.ConstructSourceImageStreams(physicalIO.ImageCodec);
            process.ConstructSourceStockEffects();
            process.ConstructSourcePhysicalGraphicsIO();
            process.ConstructSourceFnaLogging();
            process.InitializeSourceFnaLogging();
            process.ConstructSourceFrameworkProcesses();
            process.ConstructSourceTextInputEvents();
            process.ConstructSourceKeyboardAndGamePads();
            process.ConstructSourceContent(physicalIO.ContentFiles, physicalIO.Displays);
            process.ConstructSourceProcessTiming();
            if (profile == GameProfile.InstalledEverest)
            {
                process.ConstructSourceInstalledLogger();
                process.ConstructSourceInstalledTextInput();
                process.ConstructSourceInstalledModuleRoster();
                process.ConstructSourceInstalledEntityLoadTypeOwner();
                process.ConstructSourceInstalledBackdropLoadTypeOwner();
                process.ConstructSourceInstalledAreaStaticTypeOwner();
                process.ConstructSourceInstalledRuntime();
                process.ConstructSourceInstalledBootProcess();
                process.ConstructSourceInstalledRestart();
                process.InitializeSourceInstalledGamePaths();
                process.ConstructSourceInstalledFlags();
                process.ConstructSourceInstalledGameEvents();
                process.ConstructSourceInstalledLevelUpdateEvents();
                process.ConstructSourceInstalledContent();
                process.ConstructSourceInstalledFileProxy();
                process.ConstructSourceInstalledVirtualTextureTypeInitialization();
                process.ConstructSourceInstalledSubHudProcess();
                process.ConstructSourceInstalledLoader();
                process.ConstructSourceDependencyDownloads();
                process.ConstructSourceInstalledModMetadata();
                process.ConstructSourceInstalledStartupProcesses();
                process.ApplySourceInstalledEarlyMainArguments();
            }

            process.ConstructSourceDrawState();
            process.ConstructSourceMembers();
            process.ConstructSourceExternalBaseClosureFacts();
            process.PublishSourceEntityActorPlayerBindings();
            if (profile == GameProfile.Original)
                process.ConstructSourceOriginalMethodMetadata();
            process.ConstructSourceRuntimeShapes();
            process.ConstructSourceAutotilerConstruction();
            process.ConstructSourceSaveSettingsUserIO();
            process.ConstructSourceErrorLog();
            if (profile == GameProfile.InstalledEverest)
                process.ConstructSourceInstalledCriticalFailure();
            if (physicalIO.SteamRuntime != null && !process.InitializeSourceSteamStartup()) return null;
            process.InitializeSourceGameInputProcess();
            process.ApplySourceMainStartupArguments();
            process.ConstructSourceGame();
            process.ActualGame.Disposed += (_, _) => physicalIO.DiscordSdk?.Instance?.Dispose();
            process.ConstructSourceMInputForActualGame();
            process.ConstructSourceRandomProcess();
            process.ConstructSourceTagProcess();
            process.ConstructSourceGameTagInitialization();
            process.ConstructSourceStateMachineFactory();
            process.ConstructSourceWigglerPool();
            process.ConstructSourceComponentPools();
            process.ConstructSourceVirtualInputConstruction();
            process.ConstructSourceInputLifecycle();
            process.ConstructSourceInputGuiPolicy();
            process.ConstructSourceTextMenuPolicy();
            process.ConstructSourceAudioStateGlobals();
            process.InitializeSourceStrawberriesCounterStatics();
            process.ConstructSourceGameplayProcesses();
            process.ConstructSourceGameplayActorServices();
            process.ConstructSourcePlayerRuntimePolicy();
            process.ConstructSourceGameplayRendererGlobals();
            process.ConstructSourceBloomBlendStateInitialization();
            process.ConstructSourceLightingRendererProcessInitialization();
            process.ConstructSourceBackdropAndTrailPresentationRoles();
            process.ConstructSourceTrailConstructionPolicy();
            process.ConstructSourceFileSlotFirstAreaPolicy();
            process.ConstructSourceHeartGemTypeInitialization();
            process.ConstructSourceTorchColorsTypeInitialization();
            process.ConstructSourceZipMoverColorsTypeInitialization();
            process.ConstructSourceSatelliteTypeInitialization();
            process.ConstructSourceStarJumpTypeInitialization();
            process.ConstructSourceGameplayBatchScope();
            process.ConstructSourceLightningFlashPolicy();
            process.ConstructSourceRidgeLookoutAndMirror();
            process.ConstructSourceSfxProcess();
            if (profile == GameProfile.InstalledEverest)
            {
                process.ConstructSourceInstalledReflection();
                process.ConstructSourceInstalledEntityRegistry();
                process.ConstructSourceInstalledAssemblyContexts();
            }

            process.ConstructSourceEntitySourceDataRegistration();
            process.ConstructSourceSceneEntityListRoles();
            process.PublishSourceCanonicalDrawRectangleBindings();
            process.ConstructSourceSoundSources();
            process.ConstructSourceStartupGraphics();
            process.ConstructSourceDustStyleTypeInitialization();
            process.ConstructSourceDustProcessTypeInitialization();
            process.ConstructSourceIntroCarFactory();
            process.ConstructSourceTextureFactories();
            process.ConstructSourceVirtualContent();
            process.ConstructSourceAtlasConstruction();
            process.ConstructSourceXmlDocumentLoading();
            process.ConstructSourceTextProcess();
            process.ConstructSourceAreaCompletionProcesses();
            process.ConstructSourceRenderContext();
            process.ConstructSourceGeneralThreads();
            if (profile == GameProfile.InstalledEverest)
            {
                process.ConstructSourceDebugRemoteControl();
                process.ConstructSourceInstalledStrawberryRegistry();
                process.PublishSourceInstalledBootCpuOwnerQualifications();
                process.CompleteSourceInstalledBoot();
            }

            process.ConstructSourceMountainViews();
            process.ConstructSourceAreaMapLoading();
            process.ConstructSourceLevelEntryScenes();
            process.ConstructSourceOverworldLoaders();
            process.ConstructSourceDecalFactory();
            if (profile == GameProfile.Original)
                process.ConstructSourceLevelLoaders();
            process.ConstructSourcePreviewRecordings();
            process.ConstructSourceStartupScenes();
            process.BindSourceGameContentLifecycle();
            process.BindSourceLogLifetime();
            return process;
        }
    }
}
