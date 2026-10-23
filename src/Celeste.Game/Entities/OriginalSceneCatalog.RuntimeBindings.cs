using Celeste.Scene.Tracking;
using Celeste.Game.Entities.StarJump.Cutscenes;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterActualRuntimeTypes(SceneEntityCatalog result)
        {
            // RegisterStoryScenesSceneAscendManager
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Npcs.Oshiro.OriginalResortRoofEndingState),
                "Celeste.ResortRoofEnding");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Npcs.Oshiro.OriginalDoorState),
                "Celeste.Door");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Birds.Fling.OriginalFlingBirdIntroState),
                "Celeste.FlingBirdIntro");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Birds.Fling.OriginalFlingBirdState),
                "Celeste.FlingBird");
            // RegisterVisualEffectsSceneBackgroundFadeIn
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.StarJump.OriginalBackgroundFadeInState),
                "Celeste.BackgroundFadeIn");
            // RegisterStoryScenesSceneBadelineAutoAnimator
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.BadelineDummy.BadelineAutoAnimatorPresentation),
                "Celeste.BadelineAutoAnimator");
            // RegisterStoryScenesSceneBadelineDummy
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.BadelineDummy.BadelineDummyPresentation),
                "Celeste.BadelineDummy");
            // RegisterDecorationSceneBigWaterfall
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Environment.Water.OriginalBigWaterfallState),
                "Celeste.BigWaterfall");
            // RegisterEnvironmentSceneBlackholeStrengthTrigger
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Triggers.Backdrops.OriginalBlackholeStrengthTriggerState),
                "Celeste.BlackholeStrengthTrigger");
            // RegisterLightingSceneBloomFadeTrigger
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Triggers.Rendering.OriginalBloomFadeTriggerState),
                "Celeste.BloomFadeTrigger");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Simulation.Presentation.PostProcessing.Bloom.BloomPointState),
                "Celeste.BloomPoint");
            // RegisterDecorationSceneBonfire
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.StarJump.OriginalBonfireState),
                "Celeste.Bonfire");
            // RegisterDecorationSceneCliffFlags
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Environment.Ridge.OriginalCliffsideWindFlagState),
                "Celeste.CliffsideWindFlag");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Environment.Ridge.OriginalCliffFlagsState),
                "Celeste.CliffFlags");
            // RegisterDecorationSceneClothesline
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Environment.Ridge.OriginalClotheslineState),
                "Celeste.Clothesline");
            // RegisterEarlyCutsceneTypes
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Stories.OldSite.Phone.CS02DreamingPhonecallState),
                "Celeste.CS02_DreamingPhonecall");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Stories.OldSite.Phone.CS02EndingState),
                "Celeste.CS02_Ending");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Stories.Temple.Cutscenes.CS05Reflection1State),
                "Celeste.CS05_Reflection1");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Stories.Interactions.CS03DiaryState),
                "Celeste.CS03_Diary");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Stories.Interactions.CS03GuestbookState),
                "Celeste.CS03_Guestbook");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Npcs.Gravestone.CS10GravestoneState),
                "Celeste.CS10_Gravestone");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Npcs.Theo.CS05TheoEntranceState),
                "Celeste.CS05_Entrance");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Npcs.Theo.CS05TheoMirrorState),
                "Celeste.CS05_TheoInMirror");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Npcs.Theo.CS05TheoPhoneState),
                "Celeste.CS05_TheoPhone");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Stories.Temple.Badeline.CS05BadelineState),
                "Celeste.CS05_Badeline");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.StarJump.Cutscenes.CS06EndingState),
                "Celeste.CS06_Ending");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.StarJump.Cutscenes.CS06CampfireState),
                "Celeste.CS06_Campfire");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Enemies.BadelineBoss.Cutscenes.CS06BossIntroState),
                "Celeste.CS06_BossIntro");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Enemies.BadelineBoss.Cutscenes.CS06BossMidState),
                "Celeste.CS06_BossMid");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Enemies.BadelineBoss.Cutscenes.CS06BossEndState),
                "Celeste.CS06_BossEnd");
            // RegisterFarewellCutsceneTypes
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Stories.Farewell.FreeBird.OriginalFreeBirdEndingCutscene),
                "Celeste.CS10_FreeBird");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Birds.Fling.CS10MissTheBirdState),
                "Celeste.CS10_MissTheBird");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Birds.Fling.CS10CatchTheBirdState),
                "Celeste.CS10_CatchTheBird");
            // RegisterVisualEffectsSceneCustomBloom
            result.RegisterRuntimeType(
                typeof(global::Celeste.Core.Components.Rendering.CustomBloomCallbackComponentState),
                "Celeste.CustomBloom");
            // RegisterStoryScenesSceneCutsceneNode
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Birds.Fling.OriginalCutsceneNodeState),
                "Celeste.CutsceneNode");
            // RegisterSceneComponentsSceneEffectCutout
            result.RegisterRuntimeType(typeof(global::Celeste.Simulation.Presentation.Lighting.EffectCutoutState),
                "Celeste.EffectCutout");
            // RegisterStoryScenesSceneEventTrigger
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Triggers.Events.OriginalEventTriggerState),
                "Celeste.EventTrigger");
            // RegisterVisualEffectsSceneFallEffects
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.StarJump.OriginalFallEffectsState),
                "Celeste.FallEffects");
            // RegisterDecorationSceneFlagline
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Environment.Ridge.OriginalFlaglineState), "Celeste.Flagline");
            // RegisterVisualEffectsSceneForegroundDebris
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Environment.Ridge.OriginalForegroundDebrisState),
                "Celeste.ForegroundDebris");
            // RegisterStoryScenesSceneHahaha
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Hahaha.OriginalHahahaState),
                "Celeste.Hahaha");
            // RegisterDecorationSceneHangingLamp
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Environment.Ridge.OriginalHangingLampState),
                "Celeste.HangingLamp");
            // RegisterDecorationSceneLamp
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Gameplay.Environment.Ridge.OriginalLampState),
                "Celeste.Lamp");
            // RegisterLightingSceneLightBeam
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Triggers.Rendering.OriginalLightFadeTriggerState),
                "Celeste.LightFadeTrigger");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Environment.Ridge.OriginalLightBeamState),
                "Celeste.LightBeam");
            // RegisterLightingSceneLightOcclude
            result.RegisterRuntimeType(typeof(global::Celeste.Simulation.Presentation.Lighting.LightOccludeState),
                "Celeste.LightOcclude");
            // RegisterEnvironmentSceneMoonCreature
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Birds.Fling.OriginalMoonGlitchBackgroundTriggerState),
                "Celeste.MoonGlitchBackgroundTrigger");
            // RegisterStoryNpcTypes
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Npcs.Gravestone.OriginalGravestoneState),
                "Celeste.NPC10_Gravestone");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Npcs.Theo.OriginalCityTheoState),
                "Celeste.NPC01_Theo");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Npcs.Theo.OriginalOldSiteTheoState),
                "Celeste.NPC02_Theo");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Npcs.Theo.OriginalTempleEntranceTheoState),
                "Celeste.NPC05_Theo_Entrance");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Npcs.Theo.OriginalTempleMirrorTheoState),
                "Celeste.NPC05_Theo_Mirror");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Stories.Temple.Badeline.OriginalTempleBadelineState),
                "Celeste.NPC05_Badeline");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.StarJump.OriginalReflectionEndingGrannyState),
                "Celeste.NPC06_Granny_Ending");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.StarJump.OriginalTheoPlateauState),
                "Celeste.NPC06_Theo_Plateau");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.StarJump.OriginalTheoEndingState),
                "Celeste.NPC06_Theo_Ending");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Enemies.BadelineBoss.OriginalBadelineCryingState),
                "Celeste.NPC06_Badeline_Crying");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Enemies.BadelineBoss.OriginalBadelineCryingOrbState),
                "Celeste.NPC06_Badeline_Crying.Orb");
            // RegisterMenusAndTextScenePrologueEndingText
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Stories.Prologue.Ending.PrologueEndingTextPresentation),
                "Celeste.PrologueEndingText");
            // RegisterLightingScenePropLight
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Lights.OriginalPropLightState),
                "Celeste.PropLight");
            // RegisterSceneComponentsSceneTileInterceptor
            result.RegisterRuntimeType(typeof(global::Celeste.Simulation.Gameplay.Tiles.TileInterceptorState),
                "Celeste.TileInterceptor");
            // RegisterVisualEffectsSceneTrailManager
            result.RegisterRuntimeType(
                typeof(global::Celeste.Simulation.Presentation.Effects.Trails.Lifecycle.TrailManagerState),
                "Celeste.TrailManager");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Simulation.Presentation.Effects.Trails.Lifecycle.TrailSnapshotState),
                "Celeste.TrailManager.Snapshot");
            // RegisterLightingSceneVertexLight
            result.RegisterRuntimeType(typeof(global::Celeste.Simulation.Presentation.Lighting.VertexLightState),
                "Celeste.VertexLight");
            // RegisterEnvironmentSceneWater
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Environment.Water.OriginalWaterFallState),
                "Celeste.WaterFall");
            // RegisterMonocleTypes
            result.RegisterRuntimeType(typeof(global::Celeste.Scene.Entities.SceneEntityState),
                typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName);
            result.RegisterRuntimeType(typeof(global::Celeste.Graphics.Animation.SpriteImage), "Monocle.Image");
            result.RegisterRuntimeType(typeof(global::Celeste.Graphics.Animation.Sprite), "Monocle.Sprite");
            result.RegisterRuntimeType(typeof(global::Celeste.Scene.Components.Oscillation.SineWaveState),
                "Monocle.SineWave");
            result.RegisterRuntimeType(typeof(global::Celeste.Core.Scheduling.SimulationStateMachine),
                "Monocle.StateMachine");
            result.RegisterRuntimeType(typeof(global::Celeste.Scene.Components.Oscillation.WigglerComponent),
                "Monocle.Wiggler");
            // RegisterVisualEffectsRuntimeAbsorbOrb
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Effects.AbsorbOrbs.OriginalAbsorbOrbState),
                "Celeste.AbsorbOrb");
            // RegisterEnemiesRuntimeAngryOshiro
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Enemies.AngryOshiro.OriginalAngryOshiroState),
                "Celeste.AngryOshiro");
            // RegisterStoryScenesRuntimeAscendManager
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Ascension.OriginalAscendManagerState),
                "Celeste.AscendManager");
            // RegisterInteractionRuntimeBadelineBoost
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.BadelineBoosts.BadelineBoostState),
                "Celeste.BadelineBoost");
            // RegisterVisualEffectsRuntimeLevelUpEffect
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Enemies.BadelineBoss.Effects.LevelUpEffectState),
                "Celeste.LevelUpEffect");
            // RegisterEnemiesRuntimeBadelineOldsite
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Enemies.Badeline.Chasers.BadelineOldsiteState),
                "Celeste.BadelineOldsite");
            // RegisterStoryScenesRuntimeBirdPath
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Birds.Paths.BirdPathState),
                "Celeste.BirdPath");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Birds.Paths.BirdPathTriggerState),
                "Celeste.BirdPathTrigger");
            // RegisterInteractionRuntimeBooster
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Interaction.Boosters.OriginalBoosterState), "Celeste.Booster");
            // RegisterPlatformsRuntimeBounceBlock
            result.RegisterRuntimeType(
                typeof(global::Celeste.Simulation.Gameplay.Platforms.BounceBlock.BounceBlockState),
                "Celeste.BounceBlock");
            // RegisterStoryScenesRuntimeBreathingMinigame
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.StarJump.OriginalBreathingMinigameState),
                "Celeste.BreathingMinigame");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.StarJump.OriginalBreathingRumblerState),
                "Celeste.BreathingRumbler");
            // RegisterPlatformsRuntimeBridgeFixed
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Bridges.OriginalBridgeFixedState),
                "Celeste.BridgeFixed");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Bridges.OriginalBridgeState),
                "Celeste.Bridge");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Bridges.OriginalBridgeTileState),
                "Celeste.BridgeTile");
            // RegisterInteractionRuntimeBumper
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Gameplay.Hazards.Bumpers.OriginalBumperState),
                "Celeste.Bumper");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Platforms.Cassette.OriginalCassetteBlockManagerState),
                "Celeste.CassetteBlockManager");
            // RegisterCassetteRhythmRuntimeCassetteBlock
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Gameplay.Platforms.Cassette.CassetteBlockState),
                "Celeste.CassetteBlock");
            // RegisterCollectiblesRuntimeCassette
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Collectibles.Cassettes.OriginalCassetteState),
                "Celeste.Cassette");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Collectibles.Cassettes.UnlockedBSideState),
                "Celeste.Cassette.UnlockedBSide");
            // RegisterPlatformsRuntimeCloud
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Gameplay.Platforms.Clouds.OriginalCloudState),
                "Celeste.Cloud");
            // RegisterClutterRuntimeClutterAbsorbEffect
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Clutter.Absorption.OriginalClutterAbsorbEffectState),
                "Celeste.ClutterAbsorbEffect");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Clutter.Blocks.OriginalClutterBlockBaseState),
                "Celeste.ClutterBlockBase");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Clutter.Blocks.OriginalClutterBlockState),
                "Celeste.ClutterBlock");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Clutter.Cabinets.OriginalClutterCabinetState),
                "Celeste.ClutterCabinet");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Gameplay.Clutter.Doors.ClutterDoorState),
                "Celeste.ClutterDoor");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Clutter.Switches.OriginalClutterSwitchState),
                "Celeste.ClutterSwitch");
            // RegisterCoreModeRuntimeCoreMessage
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Presentation.Hud.CoreMessages.CoreMessageState),
                "Celeste.CoreMessage");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Mechanisms.Core.OriginalCoreModeToggleState),
                "Celeste.CoreModeToggle");
            // RegisterWallsAndDoorsRuntimeCoverupWall
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Walls.Concealment.OriginalCoverupWallState),
                "Celeste.CoverupWall");
            // RegisterPlatformsRuntimeCrumblePlatform
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Platforms.Crumble.OriginalCrumblePlatformState),
                "Celeste.CrumblePlatform");
            // RegisterWallsAndDoorsRuntimeCrumbleWallOnRumble
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Mechanisms.RumbleWalls.OriginalCrumbleWallOnRumbleState),
                "Celeste.CrumbleWallOnRumble");
            // RegisterPlatformsRuntimeCrushBlock
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Platforms.CrushBlocks.OriginalCrushBlockState),
                "Celeste.CrushBlock");
            // RegisterVisualEffectsRuntimeCrystalDebris
            result.RegisterRuntimeType(typeof(global::Celeste.Simulation.Gameplay.Effects.Debris.CrystalDebrisState),
                "Celeste.CrystalDebris");
            // RegisterHazardsRuntimeCrystalStaticSpinner
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Hazards.Spinners.Crystal.OriginalCrystalStaticSpinner),
                "Celeste.CrystalStaticSpinner");
            // RegisterWallsAndDoorsRuntimeDashBlock
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Gameplay.Walls.Breakable.OriginalDashBlockState),
                "Celeste.DashBlock");
            // RegisterInteractionRuntimeDashSwitch
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Mechanisms.DashSwitches.OriginalDashSwitchState),
                "Celeste.DashSwitch");
            // RegisterCollectiblesRuntimeDetachStrawberryTrigger
            result.RegisterRuntimeType(
                typeof(
                    global::Celeste.Game.Gameplay.Collectibles.Strawberries.Triggers.DetachStrawberryTriggerState),
                "Celeste.DetachStrawberryTrigger");
            // RegisterPlatformsRuntimeDreamBlock
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Platforms.Dream.OriginalDreamBlockState),
                "Celeste.DreamBlock");
            // RegisterStoryScenesRuntimeDreamMirror
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Stories.OldSite.DreamMirror.DreamMirrorState),
                "Celeste.DreamMirror");
            // RegisterHazardsRuntimeDustRotateSpinner
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Hazards.Spinners.Dust.OriginalDustRotateSpinnerState),
                "Celeste.DustRotateSpinner");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Hazards.Spinners.Dust.OriginalDustTrackSpinnerState),
                "Celeste.DustTrackSpinner");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Hazards.Spinners.Dust.OriginalDustStaticSpinnerState),
                "Celeste.DustStaticSpinner");
            // RegisterPlatformsRuntimeFallingBlock
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Platforms.FallingBlocks.OriginalFallingBlockState),
                "Celeste.FallingBlock");
            // RegisterEnemiesRuntimeFinalBoss
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Gameplay.Enemies.BadelineBoss.FinalBossState),
                "Celeste.FinalBoss");
            // RegisterPlatformsRuntimeFinalBossMovingBlock
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Platforms.FinalBossMovingBlock.
                    OriginalFinalBossMovingBlockState), "Celeste.FinalBossMovingBlock");
            // RegisterHazardsRuntimeFireBall
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Hazards.FireBalls.OriginalFireBallState), "Celeste.FireBall");
            // RegisterStoryScenesRuntimeFlingBirdIntro
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Birds.Fling.OriginalFlingBirdIntroState),
                "Celeste.FlingBirdIntro");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Birds.Fling.OriginalFlingBirdState),
                "Celeste.FlingBird");
            // RegisterVisualEffectsRuntimeFloatingDebris
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Environment.Debris.OriginalFloatingDebrisState),
                "Celeste.FloatingDebris");
            // RegisterPlatformsRuntimeFloatySpaceBlock
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Platforms.FloatySpaceBlocks.FloatySpaceBlockState),
                "Celeste.FloatySpaceBlock");
            // RegisterCollectiblesRuntimeFlyFeather
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.StarJump.OriginalFlyFeatherState),
                "Celeste.FlyFeather");
            // RegisterStoryScenesRuntimeForsakenCitySatellite
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Puzzles.ForsakenSatellite.OriginalForsakenCitySatelliteState),
                "Celeste.ForsakenCitySatellite");
            // RegisterHudRuntimeGameplayStats
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Presentation.Hud.Statistics.GameplayStatsState),
                "Celeste.GameplayStats");
            // RegisterHoldablesRuntimeGlider
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Gameplay.Holdables.Gliders.OriginalGliderState),
                "Celeste.Glider");
            // RegisterPlayerPresentationRuntimeGrabbyIcon
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Presentation.Hud.GrabIndicators.OriginalGrabbyIconState),
                "Celeste.GrabbyIcon");
            // RegisterWallsAndDoorsRuntimeHeartGemDoor
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Doors.HeartGems.OriginalHeartGemDoorState),
                "Celeste.HeartGemDoor");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Doors.HeartGems.HeartGemDoorWhiteLineState),
                "Celeste.HeartGemDoor.WhiteLine");
            // RegisterCollectiblesRuntimeHeartGem
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Collectibles.Hearts.OriginalHeartGemState),
                "Celeste.HeartGem");
            // RegisterHudRuntimeHeightDisplay
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Presentation.Hud.Height.OriginalHeightDisplayState),
                "Celeste.HeightDisplay");
            // RegisterInteractionRuntimeInteractTrigger
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Stories.Interactions.OriginalInteractTriggerState),
                "Celeste.InteractTrigger");
            // RegisterPlatformsRuntimeIntroCrusher
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Platforms.IntroCrusher.OriginalIntroCrusherState),
                "Celeste.IntroCrusher");
            // RegisterCollectiblesRuntimeKey
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Gameplay.Collectibles.Keys.OriginalKeyState),
                "Celeste.Key");
            // RegisterHazardsRuntimeKillbox
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Hazards.Killboxes.OriginalKillboxEntity), "Celeste.Killbox");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Hazards.Lightning.LightningBreakerBoxState),
                "Celeste.LightningBreakerBox");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Simulation.Gameplay.Hazards.Lightning.LightningRendererState),
                "Celeste.LightningRenderer");
            result.RegisterRuntimeType(typeof(global::Celeste.Simulation.Gameplay.Hazards.Lightning.LightningState),
                "Celeste.Lightning");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Gameplay.Hazards.Lightning.LightningStrikeState),
                "Celeste.LightningStrike");
            // RegisterWallsAndDoorsRuntimeLockBlock
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Doors.LockBlocks.OriginalLockBlockState), "Celeste.LockBlock");
            // RegisterInteractionRuntimeLookoutBlocker
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Lookouts.OriginalLookoutBlockerState),
                "Celeste.LookoutBlocker");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Lookouts.OriginalLookoutState),
                "Celeste.Lookout");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Lookouts.OriginalLookoutHud),
                "Celeste.Lookout.Hud");
            // RegisterStoryScenesRuntimeMemorial
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Memorials.MemorialState),
                "Celeste.Memorial");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Memorials.MemorialTextState),
                "Celeste.MemorialText");
            // RegisterHudRuntimeMiniTextbox
            result.RegisterRuntimeType(typeof(global::Celeste.Game.UI.Dialogue.MiniTextboxes.MiniTextboxState),
                "Celeste.MiniTextbox");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Triggers.Dialogue.MiniTextboxTriggerState),
                "Celeste.MiniTextboxTrigger");
            // RegisterEnvironmentRuntimeMoonCreature
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Decoration.MoonCreatures.OriginalMoonCreature),
                "Celeste.MoonCreature");
            // RegisterPlatformsRuntimeMoveBlock
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Gameplay.Platforms.MoveBlocks.MoveBlockState),
                "Celeste.MoveBlock");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Platforms.Wood.OriginalMovingPlatformState),
                "Celeste.MovingPlatform");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Platforms.Wood.OriginalMovingPlatformLineState),
                "Celeste.MovingPlatformLine");
            // RegisterHazardsRuntimeTrackSpinner
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Hazards.Spinners.Moving.OriginalTrackSpinnerState),
                "Celeste.TrackSpinner");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Hazards.Spinners.Moving.OriginalRotateSpinnerState),
                "Celeste.RotateSpinner");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Hazards.Spinners.Moving.OriginalBladeRotateSpinnerState),
                "Celeste.BladeRotateSpinner");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Hazards.Spinners.Moving.OriginalBladeTrackSpinnerState),
                "Celeste.BladeTrackSpinner");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Hazards.Spinners.Moving.OriginalStarTrackSpinnerState),
                "Celeste.StarTrackSpinner");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Hazards.Spinners.Moving.OriginalStarRotateSpinnerState),
                "Celeste.StarRotateSpinner");
            // RegisterWallsAndDoorsRuntimeMrOshiroDoor
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Npcs.Oshiro.OriginalMrOshiroDoorState),
                "Celeste.MrOshiroDoor");
            // RegisterStoryScenesRuntimeOshiroLobbyBell
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Npcs.Oshiro.OriginalOshiroLobbyBellState),
                "Celeste.OshiroLobbyBell");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Enemies.AngryOshiro.OriginalOshiroTriggerState),
                "Celeste.OshiroTrigger");
            // RegisterPlatformsRuntimePlateau
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.StarJump.OriginalPlateauState),
                "Celeste.Plateau");
            // RegisterTutorialReplayRuntimePlaybackBillboard
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.PlaybackBillboard.PlaybackBillboardState),
                "Celeste.PlaybackBillboard");
            result.RegisterRuntimeType(
                global::Celeste.Game.Entities.PlaybackBillboard.PlaybackBillboardState.ForegroundEntityType,
                "Celeste.PlaybackBillboard.FG");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Platforms.SwapBlocks.OriginalSwapBlockState.PathRenderer),
                "Celeste.SwapBlock.PathRenderer");
            result.RegisterRuntimeType(typeof(global::Celeste.Simulation.Gameplay.Tutorial.Replay.PlayerPlaybackState),
                "Celeste.PlayerPlayback");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Playback.OriginalPlayerPlaybackState),
                "Celeste.PlayerPlayback");
            // RegisterEnemiesRuntimePlayerSeeker
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Player.Transformations.Seeker.OriginalPlayerSeekerState),
                "Celeste.PlayerSeeker");
            // RegisterStoryScenesRuntimePoem
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Presentation.Hud.Poems.PoemState),
                "Celeste.Poem");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Decoration.PowerSources.OriginalPowerSourceNumber),
                "Celeste.PowerSourceNumber");
            // RegisterHazardsRuntimePuffer
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Gameplay.Hazards.Puffer.OriginalPufferState),
                "Celeste.Puffer");
            // RegisterStoryScenesRuntimeReflectionHeartStatue
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Puzzles.ReflectionHeart.OriginalReflectionHeartStatueState),
                "Celeste.ReflectionHeartStatue");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Npcs.Oshiro.OriginalResortRoofEndingState),
                "Celeste.ResortRoofEnding");
            // RegisterWallsAndDoorsRuntimeRidgeGate
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Doors.Ridge.OriginalRidgeGateState),
                "Celeste.RidgeGate");
            // RegisterEnvironmentRuntimeRisingLava
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Environment.Lava.Rising.OriginalRisingLavaState),
                "Celeste.RisingLava");
            // RegisterPlatformsRuntimeRotatingPlatform
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Platforms.Rotating.OriginalRotatingPlatformState),
                "Celeste.RotatingPlatform");
            // RegisterWallsAndDoorsRuntimeRumbleTrigger
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Mechanisms.RumbleWalls.OriginalRumbleTriggerState),
                "Celeste.RumbleTrigger");
            // RegisterEnvironmentRuntimeSandwichLava
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Environment.Lava.Sandwich.OriginalSandwichLavaState),
                "Celeste.SandwichLava");
            // RegisterWallsAndDoorsRuntimeFakeWall
            result.RegisterRuntimeType(typeof(global::Celeste.Simulation.Gameplay.Walls.Concealment.FakeWallState),
                "Celeste.FakeWall");
            result.RegisterRuntimeType(typeof(global::Celeste.Simulation.Gameplay.Walls.Concealment.ExitBlockState),
                "Celeste.ExitBlock");
            // RegisterEnemiesRuntimeSeekerBarrier
            result.RegisterRuntimeType(typeof(global::Celeste.Simulation.Gameplay.Enemies.Seeker.SeekerBarrierState),
                "Celeste.SeekerBarrier");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Gameplay.Enemies.Seekers.OriginalSeekerState),
                "Celeste.Seeker");
            // RegisterPlatformsRuntimeSinkingPlatform
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Platforms.Wood.OriginalSinkingPlatformState),
                "Celeste.SinkingPlatform");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Platforms.Wood.OriginalSinkingPlatformLineState),
                "Celeste.SinkingPlatformLine");
            // RegisterHazardsRuntimeSnowball
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Hazards.Snowballs.OriginalSnowballState), "Celeste.Snowball");
            // RegisterAudioRuntimeSoundEmitter
            result.RegisterRuntimeType(typeof(global::Celeste.Simulation.Audio.Emitters.SoundEmitterState),
                "Celeste.SoundEmitter");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Audio.MapSoundSources.SoundSourceEntityState),
                "Celeste.SoundSourceEntity");
            // RegisterDecorationRuntimeFlutterBird
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Birds.FlutterBird.FlutterBirdState),
                "Celeste.FlutterBird");
            // RegisterVisualEffectsRuntimeSpeedRing
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Presentation.Effects.SpeedRings.OriginalSpeedRingState),
                "Celeste.SpeedRing");
            // RegisterPlatformsRuntimeStarJumpBlock
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.StarJump.OriginalStarJumpBlockState),
                "Celeste.StarJumpBlock");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.StarJump.OriginalStarJumpControllerState),
                "Celeste.StarJumpController");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.StarJump.OriginalStarClimbGraphicsControllerState),
                "Celeste.Mod.Entities.StarClimbGraphicsController");
            // RegisterCollectiblesRuntimeStrawberrySeed
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Collectibles.Strawberries.OriginalStrawberrySeedState),
                "Celeste.StrawberrySeed");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Collectibles.Strawberries.OriginalStrawberryState),
                "Celeste.Strawberry");
            // RegisterSummitRuntimeTypes
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Checkpoints.Summit.OriginalSummitCheckpointState),
                "Celeste.SummitCheckpoint");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Decoration.SummitClouds.OriginalSummitCloud),
                "Celeste.SummitCloud");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Collectibles.SummitGems.OriginalSummitGemManagerState),
                "Celeste.SummitGemManager");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Collectibles.SummitGems.OriginalSummitGemState),
                "Celeste.SummitGem");
            // RegisterPlatformsRuntimeSwapBlock
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Platforms.SwapBlocks.OriginalSwapBlockState),
                "Celeste.SwapBlock");
            // RegisterWallsAndDoorsRuntimeSwitchGate
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Mechanisms.SwitchGates.OriginalSwitchGateState),
                "Celeste.SwitchGate");
            // RegisterTempleRuntimeTypes
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Hazards.TempleEyes.OriginalTempleBigEyeballShockwaveState),
                "Celeste.TempleBigEyeballShockwave");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Walls.Breakable.OriginalTempleCrackedBlockState),
                "Celeste.TempleCrackedBlock");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Hazards.TempleEyes.OriginalTempleEyeState),
                "Celeste.TempleEye");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Doors.TempleGates.OriginalTempleGateState),
                "Celeste.TempleGate");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Stories.Temple.TempleMirrorPortalState),
                "Celeste.TempleMirrorPortal");
            // RegisterMenusAndTextRuntimeTextbox
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Stories.Interactions.CS02JournalState),
                "Celeste.CS02_Journal");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Stories.Interactions.CS03MemoState),
                "Celeste.CS03_Memo");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Stories.Interactions.CS02JournalState).GetNestedType("PoemPage",
                    global::System.Reflection.BindingFlags.NonPublic), "Celeste.CS02_Journal.PoemPage");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Stories.Interactions.CS03MemoState).GetNestedType("MemoPage",
                    global::System.Reflection.BindingFlags.NonPublic), "Celeste.CS03_Memo.MemoPage");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.UI.Dialogue.Textboxes.TextboxState),
                "Celeste.Textbox");
            // RegisterHoldablesRuntimeTheoCrystal
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Gameplay.Holdables.TheoCrystal.TheoCrystalState),
                "Celeste.TheoCrystal");
            // RegisterStoryScenesRuntimeTheoPhone
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Npcs.Theo.OriginalTheoPhoneState),
                "Celeste.TheoPhone");
            // RegisterHudRuntimeTotalStrawberriesDisplay
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Presentation.Hud.Strawberries.TotalStrawberriesDisplayState),
                "Celeste.TotalStrawberriesDisplay");
            // RegisterInteractionRuntimeTouchSwitch
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Mechanisms.Switches.OriginalTouchSwitchState),
                "Celeste.TouchSwitch");
            // RegisterWallsAndDoorsRuntimeTrapdoor
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Decoration.Resort.OriginalTrapdoorState), "Celeste.Trapdoor");
            // RegisterInteractionRuntimeWallBooster
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Platforms.WallBoosters.OriginalWallBoosterState),
                "Celeste.WallBooster");
            // RegisterEnvironmentRuntimeWater
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Gameplay.Environment.Water.OriginalWaterState),
                "Celeste.Water");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Simulation.Gameplay.Environment.Water.WaterInteractionState),
                "Celeste.WaterInteraction");
            // RegisterWallsAndDoorsRuntimeWhiteBlock
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Decoration.WhiteBlocks.OriginalWhiteBlock),
                "Celeste.WhiteBlock");
            // RegisterEnvironmentRuntimeWindAttackTrigger
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Hazards.Snowballs.OriginalWindAttackTriggerState),
                "Celeste.WindAttackTrigger");
            // RegisterPlatformsRuntimeZipMover
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Platforms.ZipMovers.OriginalZipMoverState),
                "Celeste.ZipMover");
            // RegisterRoomTriggersRuntimeCheckpoint
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Gameplay.Checkpoints.OriginalCheckpointState),
                "Celeste.Checkpoint");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Triggers.Inventory.NoRefillTriggerState),
                "Celeste.NoRefillTrigger");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Triggers.Movement.StopBoostTriggerState),
                "Celeste.StopBoostTrigger");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Triggers.Checkpoints.CheckpointBlockerTriggerState),
                "Celeste.CheckpointBlockerTrigger");
            // RegisterInteractionRuntimeSpring
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Interaction.Springs.OriginalSpringState), "Celeste.Spring");
            // RegisterCollectiblesRuntimeRefill
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Collectibles.Refills.OriginalRefillState), "Celeste.Refill");
            // RegisterEnemiesRuntimeFinalBossBeam
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles.FinalBossBeamState),
                "Celeste.FinalBossBeam");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles.FinalBossShotState),
                "Celeste.FinalBossShot");
            // RegisterStoryScenesRuntimeGondola
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Gondolas.OriginalGondolaState),
                "Celeste.Gondola");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.IntroCar.OriginalIntroCarState),
                "Celeste.IntroCar");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.IntroCar.OriginalIntroPavementState),
                "Celeste.IntroPavement");
            // RegisterWallsAndDoorsRuntimeIntroCarBarrier
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.IntroCar.OriginalIntroCarBarrierState),
                "Celeste.IntroCarBarrier");
            // RegisterStoryScenesRuntimeKevinsPC
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Decoration.Computers.OriginalKevinsPCState),
                "Celeste.KevinsPC");
            // RegisterMountainPresentationRuntimeMaddy3D
            result.RegisterRuntimeType(typeof(global::Celeste.Graphics.Geometry.ThreeD.Billboards.BillboardState),
                "Celeste.Billboard");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Presentation.Mountain.Particles.Snow3DState.Particle),
                "Celeste.Snow3D.Particle");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Presentation.Mountain.Particles.MoonParticle3DState.Particle),
                "Celeste.MoonParticle3D.Particle");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Presentation.Mountain.Characters.Maddy3DState),
                "Celeste.Maddy3D");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Presentation.Mountain.Particles.Snow3DState),
                "Celeste.Snow3D");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Presentation.Mountain.Particles.MoonParticle3DState),
                "Celeste.MoonParticle3D");
            // RegisterStoryScenesRuntimePayphone
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Payphones.OriginalPayphoneState),
                "Celeste.Payphone");
            // RegisterClassicMinigameRuntimePicoConsole
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Minigames.CelesteClassic.Interaction.PicoConsoleState),
                "Celeste.PicoConsole");
            // RegisterStoryScenesRuntimeReflectionTentacles
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.ReflectionTentacles.OriginalReflectionTentaclesState),
                "Celeste.ReflectionTentacles");
            // RegisterEnemiesRuntimeSeekerStatue
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Enemies.Seekers.OriginalSeekerStatueState),
                "Celeste.SeekerStatue");
            // RegisterTemplePresentationRuntimeTypes
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Hazards.TempleEyes.OriginalTempleBigEyeballState),
                "Celeste.TempleBigEyeball");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Environment.Mirrors.OriginalTempleMirrorState),
                "Celeste.TempleMirror");
            // RegisterHoldablesRuntimeTheoCrystalPedestal
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Gameplay.Holdables.TheoCrystal.TheoCrystalPedestalState),
                "Celeste.TheoCrystalPedestal");
            // RegisterHazardsRuntimeTriggerSpikes
            result.RegisterRuntimeType(
                typeof(global::Celeste.Simulation.Gameplay.Hazards.TriggerSpikes.TriggerSpikesState),
                "Celeste.TriggerSpikes");
            // RegisterClassicMinigameRuntimeUnlockedPico8Message
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Minigames.CelesteClassic.Unlock.UnlockedPico8MessageState),
                "Celeste.UnlockedPico8Message");
            // RegisterTutorialReplayRuntimeWaveDashTutorialMachine
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Entities.Machines.WaveDash.OriginalWaveDashTutorialMachineState),
                "Celeste.WaveDashTutorialMachine");
            // RegisterDecorationRuntimeWire
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Entities.Decoration.Wires.OriginalWireState),
                "Celeste.Wire");
            // RegisterTerrainAndTilesRuntimeIceTileOverlay
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Execution.LevelLoader.Terrain.OriginalIceTileOverlayState),
                "Celeste.IceTileOverlay");
            // RegisterFarewellCutsceneRuntimeTypes
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Stories.Farewell.Moon.MoonIntroSequence),
                "Celeste.CS10_MoonIntro");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Stories.Farewell.Ending.OriginalFarewellEndingCutscene),
                "Celeste.CS10_Ending");
            result.RegisterRuntimeType(typeof(global::Celeste.Game.Stories.Farewell.Hub.OriginalHubIntroCutscene),
                "Celeste.CS10_HubIntro");
            result.RegisterRuntimeType(
                global::Celeste.Game.Stories.Farewell.Hub.OriginalHubIntroCutscene.BirdRuntimeType,
                "Celeste.CS10_HubIntro.Bird");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Stories.Farewell.Help.OriginalBadelineHelpsCutscene),
                "Celeste.CS10_BadelineHelps");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Stories.Farewell.Farewell.OriginalFarewellCutscene),
                "Celeste.CS10_Farewell");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Stories.Farewell.FinalRoom.OriginalFinalRoomCutscene),
                "Celeste.CS10_FinalRoom");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Stories.Farewell.Effects.OriginalDisperseImageState),
                "Celeste.DisperseImage");
            result.RegisterRuntimeType(
                typeof(global::Celeste.Game.Stories.Farewell.Effects.OriginalGrannyLaughSfxState),
                "Celeste.GrannyLaughSfx");
            // RegisterPlayerPresentationRuntimePlayer2
            result.RegisterRuntimeType(typeof(global::Celeste.Simulation.RoomPlayerSession),
                typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            // RegisterHazardsRuntimeDustEdges
            result.RegisterRuntimeType(
                typeof(global::Celeste.Simulation.Gameplay.Hazards.Spinners.Dust.DustEdgesPresentation),
                "Celeste.DustEdges");
        }
    }
}
