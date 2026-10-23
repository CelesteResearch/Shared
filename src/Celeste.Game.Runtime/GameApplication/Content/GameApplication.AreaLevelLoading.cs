using System;
using System.Collections.Generic;
using Celeste.Core.IO.Content;
using Celeste.Everest.Content.Extensions.Decals;
using Celeste.Everest.Content.Graphics;
using Celeste.Everest.Content.Maps.Levels;
using Celeste.Everest.Content.Maps.Processing;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Content.Metadata;
using Celeste.Everest.Content.Textures;
using Celeste.Everest.Entities.Platforms.Wood;
using Celeste.Everest.Gameplay.Levels.Errors;
using Celeste.Everest.Gameplay.Levels.Spawning;
using Celeste.Everest.Gameplay.Platforms.Movement;
using Celeste.Everest.Runtime.Chapters.Flow;
using Celeste.Everest.Runtime.LevelLoading;
using Celeste.Everest.Runtime.Levels.Update;
using Celeste.Everest.Runtime.Loading;
using Celeste.Game.Audio.Surfaces;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Content.Maps;
using Celeste.Game.Entities.Decoration.Decals;
using Celeste.Game.Entities.Platforms.Wood;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Diagnostics;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Levels.Construction;
using Celeste.Game.Execution.Levels.Spawning;
using Celeste.Game.Execution.Levels.Update;
using Celeste.Game.Execution.Threading;
using Celeste.Game.Gameplay.Platforms.Movement;
using Celeste.Game.Profiles;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalAreaSourceTable,
        IOriginalAreaRegistryLoadEnvironment, IOriginalChapterMapStartEnvironment,
        IEverestAssetMetadataEnvironment,
        IOriginalChapterMapBoostMetadataEnvironment, ISourcePlatformTargetMotionEnvironment,
        IOriginalLevelEnterStaticEnvironment, IEverestLevelEntityLoadEnvironment,
        IOriginalErrorLogEnvironment, IOriginalThreadEnvironment, IOriginalTileSurfaceEnvironment,
        IOriginalAreaDataResolver,
        IOriginalLevelEnterProcess, IOriginalLevelEntryEnvironment, IOriginalChapterMapConstructionEnvironment,
        IOriginalLevelLoadOverrideEnvironment, IEverestChapterMapProcessingEnvironment
    {
        private IOriginalLevelLoadOverridePolicy sourceLevelLoadOverrides;

        public IOriginalLevelLoadOverridePolicy LevelLoadOverrides => sourceLevelLoadOverrides ??
                                                                      throw new InvalidOperationException(
                                                                          "The selected Level load override policy is not constructed.");

        private IOriginalLevelLoaderFactory sourceLevelLoaders;
        private OriginalDecalFactory sourceDecals;

        public IOriginalLevelLoaderFactory LevelLoaders => sourceLevelLoaders ??
                                                           throw new InvalidOperationException(
                                                               "The actual Level loader factory is not constructed.");

        public OriginalDecalFactory Decals => sourceDecals ??
                                              throw new InvalidOperationException(
                                                  "The actual Decal factory is not constructed.");

        public void ConstructSourceDecalFactory()
        {
            if (sourceDecals != null)
                throw new InvalidOperationException("The actual Decal factory is already constructed.");
            IOriginalDecalRegistrationPolicy registration =
                new OriginalDecalVanillaPolicy(this);
            if (SourceProfile == GameProfile.InstalledEverest)
            {
                _ = DecalRegistry;
                registration =
                    new EverestDecalRegistrationPolicy(registration,
                        this);
            }

            sourceDecals = new(
                this, registration, WigglerPool,
                RandomProxy, this);
        }

        public void ConstructSourceLevelLoaders()
        {
            if (sourceLevelLoaders != null)
                throw new InvalidOperationException("The actual Level loader factory is already constructed.");
            ConstructSourceMovingSpinners();
            ConstructSourceDecorations();
            ConstructSourceLevelMapLoading();
            ConstructSourceLevelCompletion();
            sourceLevelLoadOverrides = SourceProfile == GameProfile.InstalledEverest
                ? new EverestLevelLoadOverridePolicy()
                : new OriginalLevelLoadOverridePolicy();
            IInstalledLevelLoaderPolicy installed = null;
            IOriginalLevelErrorPolicy errors = null;
            if (SourceProfile == GameProfile.InstalledEverest)
            {
                var logger = Logger;
                var state = new OriginalLevelLoaderProcessState();
                var prefix = new EverestLevelLoaderConstructorPrefix(
                    state, AreaKeys, this, logger,
                    this,
                    MainThreadProcess,
                    (EverestVirtualContent)
                    VirtualContent,
                    LevelGraphics);
                var failures = new EverestLevelLoaderFailureHandler(
                    AreaKeys, GraphicsResources, LevelEnterStatics, this, logger);
                installed = new EverestLevelLoaderPolicy(
                    prefix, failures, state, EntityPools, LevelEnterStatics, AreaKeys,
                    this, logger, Frame.Scenes, LevelEntries);
                errors = new EverestLevelEntryPendingErrorPolicy(
                    LevelEnterStatics, Frame.Scenes, LevelEntries);
            }

            var construction = new OriginalLevelSceneConstruction(
                this, AudioSession, SaveContext, TargetMotionPolicy, RumbleSession,
                this, WoodPlatformAddedPolicy, LevelUpdatePolicy, errors, Decals,
                SourceProfile == GameProfile.InstalledEverest
                    ? new InstalledLevelSpawnPolicy()
                    : new OriginalLevelSpawnPolicy());
            sourceLevelLoaders = new OriginalLevelLoaderFactory(this, construction,
                LevelResources, this, Threads, installed);
            ConstructSourceLevelTransitionPolicy();
        }

        private ILevelEntrySceneFactory sourceLevelEntries;
        private IOriginalLevelEnterPolicy sourceLevelEnterPolicy;

        public ILevelEntrySceneFactory LevelEntries => sourceLevelEntries ??
                                                       throw new InvalidOperationException(
                                                           "The actual Level entry scene factory is not constructed.");

        public IOriginalLevelEnterPolicy LevelEnterPolicy => sourceLevelEnterPolicy ??
                                                             throw new InvalidOperationException(
                                                                 "The selected LevelEnter policy is not constructed.");

        IOriginalAreaData IOriginalAreaDataResolver.Get(int id)
        {
            return AreaKeys.GetAreaById(id);
        }


        public void ConstructSourceLevelEntryScenes()
        {
            if (sourceLevelEntries != null)
                throw new InvalidOperationException("The actual Level entry scene factory is already constructed.");
            sourceLevelEntries = new OriginalLevelEntrySceneFactory(this, GraphicsResources, this);
            sourceLevelEnterPolicy = SourceProfile == GameProfile.Original
                ? new OriginalLevelEnterPolicy()
                : new EverestLevelEnterPolicy(this);
        }

        private OriginalTileSurfaceIndices sourceSurfaceIndices;
        private EverestLevelLoaderGraphicsBoundary sourceLevelGraphics;
        private OriginalErrorLogProcess sourceErrorLog;
        private OriginalGameThreadSession sourceGeneralThreads;
        private LevelEnterStaticState sourceLevelEnterStatics;
        private EverestLevelUpdateEvents sourceLevelUpdateEvents;
        private IOriginalLevelUpdatePolicy sourceLevelUpdate;
        private IPlatformTargetMotionPolicy sourceTargetMotion;
        private IWoodPlatformAddedPolicy sourceWoodPlatformPolicy;
        private OriginalLevelLoadingResources sourceLevelResources;
        private OriginalAreaRegistryProcess sourceAreaRegistry;
        private InstalledAreaRegistryLoadSource sourceInstalledAreaLoad;
        private IOriginalAreaRegistryLoadPolicy sourceAreaRegistryLoad;
        private IOriginalChapterMapStartPolicy sourceMapStart;
        private IOriginalChapterMapLoadPolicy sourceMapLoad;

        public OriginalChapterMapData CreateMapData(OriginalAreaKey actualArea)
        {
            return new(actualArea, this, MapStartPolicy,
                sourceMapLoad ??
                throw new InvalidOperationException("The selected source map load policy is not constructed."));
        }

        private InstalledChapterMapProcessingSource sourceMapProcessing;
        private InstalledAssetMetadataSource sourceMapAssetMetadata;

        public OriginalTileSurfaceIndices SurfaceIndices => sourceSurfaceIndices ??
                                                            throw new InvalidOperationException(
                                                                "The actual tile surface source domain is not constructed.");

        public EverestLevelLoaderGraphicsBoundary LevelGraphics => sourceLevelGraphics ??
                                                                   throw new InvalidOperationException(
                                                                       "The installed Level graphics prefix is not constructed.");

        public void ConstructSourceInstalledLevelGraphics()
        {
            if (SourceProfile != GameProfile.InstalledEverest)
                throw new InvalidOperationException(
                    "Original source does not construct the installed graphics prefix.");
            if (sourceLevelGraphics != null)
                throw new InvalidOperationException("The installed Level graphics prefix is already constructed.");
            var logger = Logger;
            var xml = new EverestGraphicsXmlReader(new FileEverestGraphicsContentIo(SourceContentRegistry),
                SourceContentRegistry, logger);
            sourceLevelGraphics = new(this, GraphicsResources, this,
                xml, LevelEnterStatics, this, logger);
        }

        public OriginalErrorLogProcess ErrorLog => sourceErrorLog ??
                                                   throw new InvalidOperationException(
                                                       "The actual source error log is not constructed.");

        public OriginalGameThreadSession Threads => sourceGeneralThreads ??
                                                    throw new InvalidOperationException(
                                                        "The actual general source threads are not constructed.");

        public void ConstructSourceErrorLog()
        {
            if (sourceErrorLog != null)
                throw new InvalidOperationException("The actual source error log is already constructed.");
            if (SourceProfile == GameProfile.Original)
                sourceErrorLog = new(PhysicalIO.ErrorLog, this);
            else
                sourceErrorLog = CreateSourceInstalledErrorLog();
        }

        public void ConstructSourceGeneralThreads()
        {
            if (sourceGeneralThreads != null)
                throw new InvalidOperationException("The actual general source threads are already constructed.");
            var failureOutput = (IOriginalThreadFailureOutput)this;
            if (SourceProfile == GameProfile.Original)
                sourceGeneralThreads = new(failureOutput, PhysicalIO.LoadingWorkScheduler);
            else
                sourceGeneralThreads = new(failureOutput,
                    OriginalGameThreadProfile.Installed,
                    sourceThreadAbortDiagnostics =
                        new(Logger),
                    PhysicalIO.LoadingWorkScheduler);
        }

        public LevelEnterStaticState LevelEnterStatics => sourceLevelEnterStatics ??
                                                          throw new InvalidOperationException(
                                                              "The actual LevelEnter static domain is not constructed.");

        public EverestLevelUpdateEvents LevelUpdateEvents => sourceLevelUpdateEvents ??
                                                             throw new InvalidOperationException(
                                                                 "The installed source Level events are not constructed.");

        public IOriginalLevelUpdatePolicy LevelUpdatePolicy => sourceLevelUpdate ??
                                                               throw new InvalidOperationException(
                                                                   "The selected source Level update policy is not constructed.");

        public IPlatformTargetMotionPolicy TargetMotionPolicy => sourceTargetMotion ??
                                                                 throw new InvalidOperationException(
                                                                     "The selected source platform target motion is not constructed.");

        public IWoodPlatformAddedPolicy WoodPlatformAddedPolicy => sourceWoodPlatformPolicy ??
                                                                   throw new InvalidOperationException(
                                                                       "The selected source wood platform policy is not constructed.");

        public OriginalLevelLoadingResources LevelResources => sourceLevelResources ??
                                                               throw new InvalidOperationException(
                                                                   "The same engine level resources are not constructed.");

        public OriginalAreaRegistryProcess AreaRegistry => sourceAreaRegistry ??
                                                           throw new InvalidOperationException(
                                                               "The actual source area registry is not constructed.");

        IReadOnlyList<IOriginalAreaData> IOriginalAreaSourceTable.Areas => sourceAreaRegistry?.Areas;

        public IOriginalAreaRegistryLoadPolicy AreaRegistryLoad => sourceAreaRegistryLoad ??
                                                                   throw new InvalidOperationException(
                                                                       "The selected source area load policy is not constructed.");

        public IOriginalChapterMapStartPolicy MapStartPolicy => sourceMapStart ??
                                                                throw new InvalidOperationException(
                                                                    "The selected source map start policy is not constructed.");

        public InstalledChapterMapProcessingSource MapProcessing => sourceMapProcessing ??
                                                                    throw new InvalidOperationException(
                                                                        "The installed source map processing is not constructed.");

        public IOriginalChapterMapBoostMetadata ChapterMapBoostMetadata => MapProcessing;
        public InstalledAssetMetadataSource AssetMetadata => MapAssetMetadata;

        public InstalledAssetMetadataSource MapAssetMetadata => sourceMapAssetMetadata ??
                                                                throw new InvalidOperationException(
                                                                    "The installed source asset metadata is not constructed.");

        public InstalledAreaRegistryLoadSource InstalledAreaLoad => sourceInstalledAreaLoad ??
                                                                    throw new InvalidOperationException(
                                                                        "The installed source area load is not constructed.");

        public void ConstructSourceInstalledLevelUpdateEvents()
        {
            if (SourceProfile != GameProfile.InstalledEverest)
                throw new InvalidOperationException("The original profile has no installed Level events.");
            if (sourceLevelUpdateEvents != null)
                throw new InvalidOperationException("The installed Level events are already constructed.");
            sourceLevelUpdateEvents = new();
        }

        public void ConstructSourceAreaMapLoading()
        {
            if (sourceAreaRegistry != null)
                throw new InvalidOperationException("The actual source area registry is already constructed.");
            sourceSurfaceIndices = new(this);
            sourceLevelEnterStatics = new();
            sourceLevelResources = new(this);
            if (SourceProfile == GameProfile.Original)
            {
                sourceLevelUpdate = new OriginalLevelUpdatePolicy();
                sourceTargetMotion = new OriginalPlatformTargetMotionPolicy();
                sourceWoodPlatformPolicy = new OriginalWoodPlatformAddedPolicy();
            }
            else
            {
                sourceLevelUpdate = new EverestLevelUpdatePolicy(LevelUpdateEvents);
                sourceTargetMotion = new EverestPlatformTargetMotionPolicy();
                sourceWoodPlatformPolicy = new EverestWoodPlatformAddedPolicy();
            }

            var originalStart = new OriginalChapterMapStartPolicy();
            IOriginalAreaDataFactory areaFactory;
            IOriginalChapterMapLoadPolicy mapLoad;
            if (SourceProfile == GameProfile.Original)
            {
                areaFactory = new OriginalAreaDataFactory();
                sourceMapStart = originalStart;
                mapLoad = new OriginalChapterMapLoadPolicy(this,
                    null, new OriginalChapterMapHeaderPolicy(),
                    PhysicalIO.ContentFiles is ResidentContentSource
                        ? PhysicalIO.ContentFiles
                        : null);
            }
            else
            {
                areaFactory = new InstalledAreaDataFactory(InstalledAreaStaticsDescriptor);
                sourceMapStart = new EverestChapterMapStartPolicy(this,
                    this, originalStart);
                sourceMapAssetMetadata = new(SourceContentRegistry);
                sourceMapProcessing = new(this, AreaKeys,
                    areaFactory, this);
                mapLoad = new InstalledChapterMapLoadPolicy(this,
                    FileProxy, sourceMapProcessing, new EverestLevelRoomDataExtensions(this),
                    new InstalledChapterMapHeaderPolicy(this), AreaKeys,
                    Logger);
            }

            sourceMapLoad = mapLoad;
            sourceAreaRegistry = new(areaFactory, AreaKeys,
                sourceMapStart, mapLoad, (IOriginalAreaInterludePolicy)SaveCounters, this);
            if (SourceProfile == GameProfile.Original)
            {
                sourceAreaRegistryLoad = new OriginalAreaRegistryLoadPolicy(sourceAreaRegistry);
            }
            else
            {
                sourceInstalledAreaLoad = new(sourceAreaRegistry,
                    SourceContentRegistry, this, areaFactory, AreaKeys, sourceMapStart, mapLoad,
                    sourceMapAssetMetadata, sourceMapProcessing, this,
                    InstalledAreaStaticsDescriptor);
                sourceAreaRegistryLoad = new EverestAreaRegistryLoadPolicy(sourceInstalledAreaLoad);
            }
        }
    }
}
