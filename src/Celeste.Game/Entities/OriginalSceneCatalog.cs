using Celeste.Simulation.Gameplay.Lookout;
using Celeste.Simulation.Gameplay.Clutter;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        public static SceneUpdateScheduler CreateScheduler(SceneEntityCatalog actualCatalog,
            global::Celeste.Core.Scheduling.ISourceEngineContext engine)
            => new SceneUpdateScheduler(actualCatalog ?? throw new System.ArgumentNullException(nameof(actualCatalog)),
                ((ISourceSceneUpdatePolicyEnvironment)engine).LevelScenePolicy,
                ((global::Celeste.Core.Components.ISourceEntityQueueEnvironment)engine).EntityQueuePolicy,
                ((global::Celeste.Core.Components.ISourceEntityAddMetadataEnvironment)engine).EntityAddMetadata,
                ((global::Celeste.Scene.Scheduling.ISourceEntityListProcessEnvironment)engine).EntityListProcess);

        public static SceneEntityCatalog Create(ISourceSceneCatalogMetadata metadata)
        {
            if (metadata == null) throw new System.ArgumentNullException(nameof(metadata));
            var result = new SceneEntityCatalog(new Tracking.Metadata.OriginalSceneCollectionMetadata());
            RegisterAudioScene3dSoundTest(result);
            RegisterVisualEffectsSceneAbsorbOrb(result);
            result.Register(
                new SceneEntityType(
                    typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName,
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[]
                    {
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName
                    }), true);
            RegisterAudioSceneAltMusicTrigger(result);
            RegisterEnemiesSceneAngryOshiro(result);
            RegisterTerrainAndTilesSceneAnimatedTiles(result);
            RegisterHudSceneAreaCompleteTitle(result);
            RegisterStoryScenesSceneAscendManager(result);
            RegisterVisualEffectsSceneBackgroundFadeIn(result);
            RegisterTerrainAndTilesSceneBackgroundTiles(result);
            RegisterStoryScenesSceneBadelineAutoAnimator(result);
            RegisterInteractionSceneBadelineBoost(result);
            RegisterStoryScenesSceneBadelineDummy(result);
            RegisterEnemiesSceneBadelineOldsite(result);
            RegisterSceneComponentsSceneBeforeRenderHook(result);
            RegisterHudSceneBestTimeDisplay(result);
            RegisterDecorationSceneBigWaterfall(result);
            RegisterTutorialReplaySceneBillboard(result);
            RegisterStoryScenesSceneBirdNPC(result);
            RegisterTutorialReplaySceneBirdTutorialGui(result);
            RegisterEnvironmentSceneBlackholeStrengthTrigger(result);
            RegisterHazardsSceneBladeRotateSpinner(result);
            RegisterTerrainAndTilesSceneBlockField(result);
            RegisterLightingSceneBloomFadeTrigger(result);
            RegisterDecorationSceneBonfire(result);
            RegisterInteractionSceneBooster(result);
            RegisterPlatformsSceneBounceBlock(result);
            RegisterStoryScenesSceneBreathingMinigame(result);
            RegisterPlatformsSceneBridge(result);
            RegisterInteractionSceneBumper(result);
            RegisterMenusAndTextSceneButtonConfigUI(result);
            RegisterCameraControlSceneCameraAdvanceTargetTrigger(result);
            RegisterCollectiblesSceneCassette(result);
            RegisterCassetteRhythmSceneCassetteBlock(result);
            RegisterRoomTriggersSceneChangeRespawnTrigger(result);
            RegisterHazardsSceneChaserBarrier(result);
            RegisterRoomTriggersSceneCheckpoint(result);
            RegisterDecorationSceneCliffFlags(result);
            RegisterSceneComponentsSceneClimbBlocker(result);
            RegisterDecorationSceneClothesline(result);
            RegisterPlatformsSceneCloud(result);
            RegisterClutterSceneClutterAbsorbEffect(result);
            RegisterDecorationSceneCobweb(result);
            RegisterCoreModeSceneCoreMessage(result);
            RegisterWallsAndDoorsSceneCoverupWall(result);
            RegisterRoomTriggersSceneCreditsTrigger(result);
            RegisterPlatformsSceneCrumblePlatform(result);
            RegisterWallsAndDoorsSceneCrumbleWallOnRumble(result);
            RegisterPlatformsSceneCrushBlock(result);
            RegisterVisualEffectsSceneCrystalDebris(result);
            RegisterHazardsSceneCrystalStaticSpinner(result);
            RegisterEarlyCutsceneTypes(result);
            RegisterFarewellCutsceneTypes(result);
            RegisterVisualEffectsSceneCustomBloom(result);
            result.Register(
                new SceneEntityType("Celeste.CutsceneEntity",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            RegisterStoryScenesSceneCutsceneNode(result);
            RegisterWallsAndDoorsSceneDashBlock(result);
            RegisterSceneComponentsSceneDashListener(result);
            RegisterInteractionSceneDashSwitch(result);
            RegisterVisualEffectsSceneDeathEffect(result);
            RegisterHudSceneDeathsCounter(result);
            RegisterVisualEffectsSceneDebris(result);
            RegisterDecorationSceneDecal(result);
            RegisterCollectiblesSceneDetachStrawberryTrigger(result);
            RegisterVisualEffectsSceneDisperseImage(result);
            RegisterSceneComponentsSceneDisplacementRenderHook(result);
            RegisterWallsAndDoorsSceneDoor(result);
            RegisterPlatformsSceneDreamBlock(result);
            RegisterCollectiblesSceneDreamHeartGem(result);
            RegisterStoryScenesSceneDreamMirror(result);
            RegisterHazardsSceneDustEdge(result);
            RegisterSceneComponentsSceneEffectCutout(result);
            RegisterStoryScenesSceneEventTrigger(result);
            RegisterWallsAndDoorsSceneExitBlock(result);
            RegisterCollectiblesSceneFakeHeart(result);
            RegisterWallsAndDoorsSceneFakeWall(result);
            RegisterVisualEffectsSceneFallEffects(result);
            RegisterPlatformsSceneFallingBlock(result);
            RegisterMenusAndTextSceneFileErrorOverlay(result);
            RegisterEnemiesSceneFinalBoss(result);
            RegisterPlatformsSceneFinalBossMovingBlock(result);
            RegisterEnemiesSceneFinalBossShot(result);
            RegisterHazardsSceneFireBall(result);
            RegisterDecorationSceneFlagline(result);
            RegisterStoryScenesSceneFlingBird(result);
            RegisterVisualEffectsSceneFloatingDebris(result);
            RegisterPlatformsSceneFloatySpaceBlock(result);
            RegisterDecorationSceneFlutterBird(result);
            RegisterCollectiblesSceneFlyFeather(result);
            RegisterSceneComponentsSceneFollower(result);
            RegisterVisualEffectsSceneForegroundDebris(result);
            RegisterFormationPresentationSceneFormationBackdrop(result);
            RegisterStoryScenesSceneForsakenCitySatellite(result);
            RegisterHudSceneGameplayStats(result);
            RegisterPlatformsSceneGlassBlock(result);
            RegisterHoldablesSceneGlider(result);
            RegisterCollectiblesSceneGoldBerryCollectTrigger(result);
            RegisterPlatformsSceneGoldenBlock(result);
            RegisterStoryScenesSceneGondola(result);
            RegisterPlayerPresentationSceneGrabbyIcon(result);
            RegisterAudioSceneGrannyLaughSfx(result);
            RegisterStoryScenesSceneHahaha(result);
            RegisterDecorationSceneHangingLamp(result);
            RegisterCollectiblesSceneHeartGem(result);
            RegisterHudSceneHeartGemDisplay(result);
            RegisterWallsAndDoorsSceneHeartGemDoor(result);
            RegisterHudSceneHeightDisplay(result);
            RegisterSceneComponentsSceneHoldable(result);
            RegisterHazardsSceneIceBlock(result);
            RegisterTerrainAndTilesSceneIceTileOverlay(result);
            RegisterInteractionSceneInteractTrigger(result);
            RegisterStoryScenesSceneIntroCar(result);
            RegisterWallsAndDoorsSceneIntroCarBarrier(result);
            RegisterPlatformsSceneIntroCrusher(result);
            RegisterStoryScenesSceneIntroPavement(result);
            RegisterWallsAndDoorsSceneInvisibleBarrier(result);
            result.Register(
                new SceneEntityType("Celeste.JumpThru",
                    new string[]
                        { "Celeste.Platform", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.JumpThru", "Celeste.Platform" }), true);
            RegisterPlatformsSceneJumpthruPlatform(result);
            RegisterStoryScenesSceneKevinsPC(result);
            RegisterCollectiblesSceneKey(result);
            RegisterMenusAndTextSceneKeyboardConfigUI(result);
            RegisterHazardsSceneKillbox(result);
            RegisterDecorationSceneLamp(result);
            RegisterMenusAndTextSceneLanguageSelectUI(result);
            RegisterEnvironmentSceneLavaRect(result);
            RegisterSceneComponentsSceneLeader(result);
            RegisterMenusAndTextSceneLevelEnterBSideTitle(result);
            RegisterVisualEffectsSceneLevelUpEffect(result);
            RegisterLightingSceneLightBeam(result);
            RegisterHazardsSceneLightning(result);
            RegisterLightingSceneLightOcclude(result);
            RegisterWallsAndDoorsSceneLockBlock(result);
            RegisterInteractionSceneLookout(result);
            RegisterMountainPresentationSceneMaddy3D(result);
            RegisterMenusAndTextSceneMainMenuClimb(result);
            RegisterStoryScenesSceneMemorial(result);
            RegisterMenusAndTextSceneMenuButton(result);
            RegisterHudSceneMiniTextbox(result);
            RegisterStoryScenesSceneMirrorReflection(result);
            RegisterModGameplayTriggersSceneModEntitiesActivateDreamBlocksTrigger(result);
            RegisterModAudioCameraSceneModEntitiesAmbienceTrigger(result);
            RegisterModStoryPresentationSceneModEntitiesBadelineOldsiteEnd(result);
            RegisterModGameplayTriggersSceneModEntitiesCassetteListener(result);
            RegisterModStoryPresentationSceneModEntitiesCSGENGenericStrawberrySeeds(result);
            RegisterModEntityIntegrationSceneModEntitiesEntityColliderGeneric(result);
            RegisterModGameplayTriggersSceneModEntitiesFlagTrigger(result);
            RegisterModStoryPresentationSceneModEntitiesGenericStrawberrySeed(result);
            RegisterModGameplayTriggersSceneModEntitiesLavaBlockerTrigger(result);
            RegisterModAudioCameraSceneModEntitiesMusicLayerTrigger(result);
            RegisterModEntityIntegrationSceneModEntitiesSceneWrappingEntity(result);
            RegisterModAudioCameraSceneModEntitiesSmoothCameraOffsetTrigger(result);
            RegisterModGameplayTriggersSceneModEntitiesSpaceControllerBlocker(result);
            RegisterModEntityIntegrationSceneModEntitiesTimeRateModifier(result);
            RegisterModGameplayTriggersSceneModEntitiesTriggerSpikesOriginal(result);
            RegisterModUiTypes(result);
            RegisterEnvironmentSceneMoonCreature(result);
            RegisterMountainPresentationSceneMoonParticle3D(result);
            RegisterPlatformsSceneMoveBlock(result);
            RegisterWallsAndDoorsSceneMrOshiroDoor(result);
            RegisterAudioSceneMusicFadeTrigger(result);
            RegisterPlatformsSceneNegaBlock(result);
            RegisterRoomTriggersSceneNoRefillTrigger(result);
            RegisterStoryNpcTypes(result);
            RegisterAudioSceneOldSiteChaseMusicHandler(result);
            RegisterStoryScenesSceneOshiroLobbyBell(result);
            RegisterOverworldUiTypes(result);
            RegisterMenusAndTextSceneOverlay(result);
            RegisterStoryScenesScenePayphone(result);
            RegisterClassicMinigameScenePicoConsole(result);
            RegisterPlatformsScenePlateau(result);
            result.Register(
                new SceneEntityType("Celeste.Platform",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), true);
            RegisterTutorialReplayScenePlaybackBillboard(result);
            RegisterPlayerPresentationScenePlayer(result);
            RegisterSceneComponentsScenePlayerCollider(result);
            RegisterPlayerPresentationScenePlayerDashAssist(result);
            RegisterTutorialReplayScenePlayerPlayback(result);
            RegisterEnemiesScenePlayerSeeker(result);
            RegisterPlayerPresentationScenePlayerSprite(result);
            RegisterStoryScenesScenePoem(result);
            RegisterMenusAndTextScenePostcard(result);
            RegisterSceneComponentsScenePostUpdateHook(result);
            RegisterStoryScenesScenePowerSourceNumber(result);
            RegisterMenusAndTextScenePrologueEndingText(result);
            RegisterLightingScenePropLight(result);
            RegisterHazardsScenePuffer(result);
            RegisterHudSceneQuickResetHint(result);
            RegisterCollectiblesSceneRefill(result);
            RegisterStoryScenesSceneReflectionHeartStatue(result);
            RegisterDecorationSceneResortLantern(result);
            RegisterStoryScenesSceneResortMirror(result);
            RegisterRoomTriggersSceneRespawnTargetTrigger(result);
            RegisterHudSceneReturnMapHint(result);
            RegisterWallsAndDoorsSceneRidgeGate(result);
            RegisterEnvironmentSceneRisingLava(result);
            RegisterHazardsSceneRotateSpinner(result);
            RegisterPlatformsSceneRotatingPlatform(result);
            RegisterWallsAndDoorsSceneRumbleTrigger(result);
            RegisterSceneComponentsSceneSafeGroundBlocker(result);
            RegisterEnvironmentSceneSandwichLava(result);
            RegisterHudSceneSaveLoadIcon(result);
            RegisterEnemiesSceneSeeker(result);
            RegisterStoryScenesSceneSelfie(result);
            RegisterPlatformsSceneSinkingPlatform(result);
            RegisterVisualEffectsSceneSlashFx(result);
            RegisterMenusAndTextSceneSlider(result);
            RegisterMountainPresentationSceneSnow3D(result);
            RegisterHazardsSceneSnowball(result);
            result.Register(
                new SceneEntityType("Celeste.Solid",
                    new string[]
                        { "Celeste.Platform", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), true);
            RegisterPlatformsSceneSolidOnInvinciblePlayer(result);
            RegisterTerrainAndTilesSceneSolidTiles(result);
            RegisterAudioSceneSoundEmitter(result);
            RegisterEnvironmentSceneSpaceController(result);
            RegisterRoomTriggersSceneSpawnFacingTrigger(result);
            RegisterVisualEffectsSceneSpeedRing(result);
            RegisterHudSceneSpeedrunTimerDisplay(result);
            RegisterHazardsSceneSpikes(result);
            RegisterInteractionSceneSpring(result);
            RegisterPlayerPresentationSceneStaminaDisplay(result);
            RegisterPlatformsSceneStarJumpBlock(result);
            RegisterHazardsSceneStarRotateSpinner(result);
            RegisterSceneComponentsSceneStaticMover(result);
            RegisterRoomTriggersSceneStopBoostTrigger(result);
            RegisterHudSceneStrawberriesCounter(result);
            RegisterCollectiblesSceneStrawberry(result);
            RegisterSummitSceneTypes(result);
            RegisterPlatformsSceneSwapBlock(result);
            RegisterInteractionSceneSwitch(result);
            RegisterWallsAndDoorsSceneSwitchGate(result);
            RegisterInteractionSceneTalkComponent(result);
            RegisterTempleSceneTypes(result);
            RegisterMenusAndTextSceneTextbox(result);
            RegisterHoldablesSceneTheoCrystal(result);
            RegisterStoryScenesSceneTheoPhone(result);
            RegisterSceneComponentsSceneTileInterceptor(result);
            RegisterDecorationSceneTorch(result);
            RegisterHudSceneTotalStrawberriesDisplay(result);
            RegisterInteractionSceneTouchSwitch(result);
            RegisterHazardsSceneTrackSpinner(result);
            RegisterVisualEffectsSceneTrailManager(result);
            RegisterSceneComponentsSceneTransitionListener(result);
            RegisterWallsAndDoorsSceneTrapdoor(result);
            result.Register(
                new SceneEntityType("Celeste.Trigger",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                true);
            RegisterHazardsSceneTriggerSpikes(result);
            RegisterClassicMinigameSceneUnlockedPico8Message(result);
            RegisterHudSceneUnlockedRemixDisplay(result);
            RegisterMenusAndTextSceneUnlockEverythingThingy(result);
            RegisterLightingSceneVertexLight(result);
            RegisterMenusAndTextSceneViewportAdjustmentUI(result);
            RegisterInteractionSceneWallBooster(result);
            RegisterEnvironmentSceneWater(result);
            RegisterTutorialReplaySceneWaveDashPresentation(result);
            RegisterWallsAndDoorsSceneWhiteBlock(result);
            RegisterEnvironmentSceneWindAttackTrigger(result);
            RegisterDecorationSceneWire(result);
            RegisterPlatformsSceneZipMover(result);
            RegisterMonocleTypes(result);
            RegisterMenusAndTextRuntimeTextbox(result);
            RegisterActualRuntimeTypes(result);
            metadata.Configure(result);
            return result;
        }
    }
}
