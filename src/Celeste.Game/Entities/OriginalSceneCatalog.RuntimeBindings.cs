using System.Reflection;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.Ascension;
using Celeste.Game.Entities.Audio.MapSoundSources;
using Celeste.Game.Entities.BadelineBoosts;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Entities.Birds.Fling;
using Celeste.Game.Entities.Birds.FlutterBird;
using Celeste.Game.Entities.Birds.Paths;
using Celeste.Game.Entities.Bridges;
using Celeste.Game.Entities.Collectibles.Hearts;
using Celeste.Game.Entities.Collectibles.SummitGems;
using Celeste.Game.Entities.Decoration.Computers;
using Celeste.Game.Entities.Decoration.Resort;
using Celeste.Game.Entities.Decoration.Wires;
using Celeste.Game.Entities.Doors.LockBlocks;
using Celeste.Game.Entities.Doors.Ridge;
using Celeste.Game.Entities.Effects.AbsorbOrbs;
using Celeste.Game.Entities.Gondolas;
using Celeste.Game.Entities.Hahaha;
using Celeste.Game.Entities.Hazards.Killboxes;
using Celeste.Game.Entities.Hazards.Snowballs;
using Celeste.Game.Entities.Hazards.Spinners.Crystal;
using Celeste.Game.Entities.Interaction.Boosters;
using Celeste.Game.Entities.IntroCar;
using Celeste.Game.Entities.Lights;
using Celeste.Game.Entities.Lookouts;
using Celeste.Game.Entities.Machines.WaveDash;
using Celeste.Game.Entities.Mechanisms.RumbleWalls;
using Celeste.Game.Entities.Memorials;
using Celeste.Game.Entities.Npcs.Gravestone;
using Celeste.Game.Entities.Npcs.Oshiro;
using Celeste.Game.Entities.Npcs.Theo;
using Celeste.Game.Entities.Payphones;
using Celeste.Game.Entities.Platforms.Dream;
using Celeste.Game.Entities.Platforms.SwapBlocks;
using Celeste.Game.Entities.Platforms.WallBoosters;
using Celeste.Game.Entities.Platforms.Wood;
using Celeste.Game.Entities.Platforms.ZipMovers;
using Celeste.Game.Entities.Playback;
using Celeste.Game.Entities.PlaybackBillboard;
using Celeste.Game.Entities.Puzzles.ForsakenSatellite;
using Celeste.Game.Entities.Puzzles.ReflectionHeart;
using Celeste.Game.Entities.ReflectionTentacles;
using Celeste.Game.Entities.StarJump;
using Celeste.Game.Entities.StarJump.Cutscenes;
using Celeste.Game.Entities.Triggers.Events;
using Celeste.Game.Entities.Triggers.Rendering;
using Celeste.Game.Entities.Walls.Concealment;
using Celeste.Game.Execution.LevelLoader.Terrain;
using Celeste.Game.Gameplay.Checkpoints;
using Celeste.Game.Gameplay.Checkpoints.Summit;
using Celeste.Game.Gameplay.Clutter.Absorption;
using Celeste.Game.Gameplay.Clutter.Blocks;
using Celeste.Game.Gameplay.Clutter.Cabinets;
using Celeste.Game.Gameplay.Clutter.Doors;
using Celeste.Game.Gameplay.Clutter.Switches;
using Celeste.Game.Gameplay.Collectibles.Cassettes;
using Celeste.Game.Gameplay.Collectibles.Keys;
using Celeste.Game.Gameplay.Collectibles.Refills;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Game.Gameplay.Collectibles.Strawberries.Triggers;
using Celeste.Game.Gameplay.Decoration.MoonCreatures;
using Celeste.Game.Gameplay.Decoration.PowerSources;
using Celeste.Game.Gameplay.Decoration.SummitClouds;
using Celeste.Game.Gameplay.Decoration.WhiteBlocks;
using Celeste.Game.Gameplay.Doors.HeartGems;
using Celeste.Game.Gameplay.Doors.TempleGates;
using Celeste.Game.Gameplay.Enemies.AngryOshiro;
using Celeste.Game.Gameplay.Enemies.Badeline.Chasers;
using Celeste.Game.Gameplay.Enemies.BadelineBoss;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Cutscenes;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Effects;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles;
using Celeste.Game.Gameplay.Enemies.Seekers;
using Celeste.Game.Gameplay.Environment.Debris;
using Celeste.Game.Gameplay.Environment.Lava.Rising;
using Celeste.Game.Gameplay.Environment.Lava.Sandwich;
using Celeste.Game.Gameplay.Environment.Mirrors;
using Celeste.Game.Gameplay.Environment.Ridge;
using Celeste.Game.Gameplay.Environment.Water;
using Celeste.Game.Gameplay.Hazards.Bumpers;
using Celeste.Game.Gameplay.Hazards.FireBalls;
using Celeste.Game.Gameplay.Hazards.Lightning;
using Celeste.Game.Gameplay.Hazards.Puffer;
using Celeste.Game.Gameplay.Hazards.Spinners.Dust;
using Celeste.Game.Gameplay.Hazards.Spinners.Moving;
using Celeste.Game.Gameplay.Hazards.TempleEyes;
using Celeste.Game.Gameplay.Holdables.Gliders;
using Celeste.Game.Gameplay.Holdables.TheoCrystal;
using Celeste.Game.Gameplay.Interaction.Springs;
using Celeste.Game.Gameplay.Mechanisms.Core;
using Celeste.Game.Gameplay.Mechanisms.DashSwitches;
using Celeste.Game.Gameplay.Mechanisms.Switches;
using Celeste.Game.Gameplay.Mechanisms.SwitchGates;
using Celeste.Game.Gameplay.Platforms.Cassette;
using Celeste.Game.Gameplay.Platforms.Clouds;
using Celeste.Game.Gameplay.Platforms.Crumble;
using Celeste.Game.Gameplay.Platforms.CrushBlocks;
using Celeste.Game.Gameplay.Platforms.FallingBlocks;
using Celeste.Game.Gameplay.Platforms.FinalBossMovingBlock;
using Celeste.Game.Gameplay.Platforms.FloatySpaceBlocks;
using Celeste.Game.Gameplay.Platforms.IntroCrusher;
using Celeste.Game.Gameplay.Platforms.MoveBlocks;
using Celeste.Game.Gameplay.Platforms.Rotating;
using Celeste.Game.Gameplay.Player.Transformations.Seeker;
using Celeste.Game.Gameplay.Triggers.Backdrops;
using Celeste.Game.Gameplay.Triggers.Checkpoints;
using Celeste.Game.Gameplay.Triggers.Dialogue;
using Celeste.Game.Gameplay.Triggers.Inventory;
using Celeste.Game.Gameplay.Triggers.Movement;
using Celeste.Game.Gameplay.Walls.Breakable;
using Celeste.Game.Minigames.CelesteClassic.Interaction;
using Celeste.Game.Minigames.CelesteClassic.Unlock;
using Celeste.Game.Presentation.Effects.SpeedRings;
using Celeste.Game.Presentation.Hud.CoreMessages;
using Celeste.Game.Presentation.Hud.GrabIndicators;
using Celeste.Game.Presentation.Hud.Height;
using Celeste.Game.Presentation.Hud.Poems;
using Celeste.Game.Presentation.Hud.Statistics;
using Celeste.Game.Presentation.Hud.Strawberries;
using Celeste.Game.Presentation.Mountain.Characters;
using Celeste.Game.Presentation.Mountain.Particles;
using Celeste.Game.Stories.Farewell.Effects;
using Celeste.Game.Stories.Farewell.Ending;
using Celeste.Game.Stories.Farewell.Farewell;
using Celeste.Game.Stories.Farewell.FinalRoom;
using Celeste.Game.Stories.Farewell.FreeBird;
using Celeste.Game.Stories.Farewell.Help;
using Celeste.Game.Stories.Farewell.Hub;
using Celeste.Game.Stories.Farewell.Moon;
using Celeste.Game.Stories.Interactions;
using Celeste.Game.Stories.OldSite.DreamMirror;
using Celeste.Game.Stories.OldSite.Phone;
using Celeste.Game.Stories.Prologue.Ending;
using Celeste.Game.Stories.Temple;
using Celeste.Game.Stories.Temple.Badeline;
using Celeste.Game.Stories.Temple.Cutscenes;
using Celeste.Game.UI.Dialogue.MiniTextboxes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Geometry.ThreeD.Billboards;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Emitters;
using Celeste.Simulation.Gameplay.Effects.Debris;
using Celeste.Simulation.Gameplay.Enemies.Seeker;
using Celeste.Simulation.Gameplay.Environment.Water;
using Celeste.Simulation.Gameplay.Hazards.Lightning;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;
using Celeste.Simulation.Gameplay.Hazards.TriggerSpikes;
using Celeste.Simulation.Gameplay.Platforms.BounceBlock;
using Celeste.Simulation.Gameplay.Tiles;
using Celeste.Simulation.Gameplay.Tutorial.Replay;
using Celeste.Simulation.Gameplay.Walls.Concealment;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterActualRuntimeTypes(SceneEntityCatalog result)
        {
            // RegisterStoryScenesSceneAscendManager
            result.RegisterRuntimeType(
                typeof(OriginalResortRoofEndingState),
                "Celeste.ResortRoofEnding");
            result.RegisterRuntimeType(typeof(OriginalDoorState),
                "Celeste.Door");
            result.RegisterRuntimeType(
                typeof(OriginalFlingBirdIntroState),
                "Celeste.FlingBirdIntro");
            result.RegisterRuntimeType(typeof(OriginalFlingBirdState),
                "Celeste.FlingBird");
            // RegisterVisualEffectsSceneBackgroundFadeIn
            result.RegisterRuntimeType(typeof(OriginalBackgroundFadeInState),
                "Celeste.BackgroundFadeIn");
            // RegisterStoryScenesSceneBadelineAutoAnimator
            result.RegisterRuntimeType(
                typeof(BadelineAutoAnimatorPresentation),
                "Celeste.BadelineAutoAnimator");
            // RegisterStoryScenesSceneBadelineDummy
            result.RegisterRuntimeType(
                typeof(BadelineDummyPresentation),
                "Celeste.BadelineDummy");
            // RegisterDecorationSceneBigWaterfall
            result.RegisterRuntimeType(
                typeof(OriginalBigWaterfallState),
                "Celeste.BigWaterfall");
            // RegisterEnvironmentSceneBlackholeStrengthTrigger
            result.RegisterRuntimeType(
                typeof(OriginalBlackholeStrengthTriggerState),
                "Celeste.BlackholeStrengthTrigger");
            // RegisterLightingSceneBloomFadeTrigger
            result.RegisterRuntimeType(
                typeof(OriginalBloomFadeTriggerState),
                "Celeste.BloomFadeTrigger");
            result.RegisterRuntimeType(
                typeof(BloomPointState),
                "Celeste.BloomPoint");
            // RegisterDecorationSceneBonfire
            result.RegisterRuntimeType(typeof(OriginalBonfireState),
                "Celeste.Bonfire");
            // RegisterDecorationSceneCliffFlags
            result.RegisterRuntimeType(
                typeof(OriginalCliffsideWindFlagState),
                "Celeste.CliffsideWindFlag");
            result.RegisterRuntimeType(
                typeof(OriginalCliffFlagsState),
                "Celeste.CliffFlags");
            // RegisterDecorationSceneClothesline
            result.RegisterRuntimeType(
                typeof(OriginalClotheslineState),
                "Celeste.Clothesline");
            // RegisterEarlyCutsceneTypes
            result.RegisterRuntimeType(
                typeof(CS02DreamingPhonecallState),
                "Celeste.CS02_DreamingPhonecall");
            result.RegisterRuntimeType(typeof(CS02EndingState),
                "Celeste.CS02_Ending");
            result.RegisterRuntimeType(typeof(CS05Reflection1State),
                "Celeste.CS05_Reflection1");
            result.RegisterRuntimeType(typeof(CS03DiaryState),
                "Celeste.CS03_Diary");
            result.RegisterRuntimeType(typeof(CS03GuestbookState),
                "Celeste.CS03_Guestbook");
            result.RegisterRuntimeType(typeof(CS10GravestoneState),
                "Celeste.CS10_Gravestone");
            result.RegisterRuntimeType(typeof(CS05TheoEntranceState),
                "Celeste.CS05_Entrance");
            result.RegisterRuntimeType(typeof(CS05TheoMirrorState),
                "Celeste.CS05_TheoInMirror");
            result.RegisterRuntimeType(typeof(CS05TheoPhoneState),
                "Celeste.CS05_TheoPhone");
            result.RegisterRuntimeType(typeof(CS05BadelineState),
                "Celeste.CS05_Badeline");
            result.RegisterRuntimeType(typeof(CS06EndingState),
                "Celeste.CS06_Ending");
            result.RegisterRuntimeType(typeof(CS06CampfireState),
                "Celeste.CS06_Campfire");
            result.RegisterRuntimeType(
                typeof(CS06BossIntroState),
                "Celeste.CS06_BossIntro");
            result.RegisterRuntimeType(
                typeof(CS06BossMidState),
                "Celeste.CS06_BossMid");
            result.RegisterRuntimeType(
                typeof(CS06BossEndState),
                "Celeste.CS06_BossEnd");
            // RegisterFarewellCutsceneTypes
            result.RegisterRuntimeType(
                typeof(OriginalFreeBirdEndingCutscene),
                "Celeste.CS10_FreeBird");
            result.RegisterRuntimeType(typeof(CS10MissTheBirdState),
                "Celeste.CS10_MissTheBird");
            result.RegisterRuntimeType(typeof(CS10CatchTheBirdState),
                "Celeste.CS10_CatchTheBird");
            // RegisterVisualEffectsSceneCustomBloom
            result.RegisterRuntimeType(
                typeof(CustomBloomCallbackComponentState),
                "Celeste.CustomBloom");
            // RegisterStoryScenesSceneCutsceneNode
            result.RegisterRuntimeType(typeof(OriginalCutsceneNodeState),
                "Celeste.CutsceneNode");
            // RegisterSceneComponentsSceneEffectCutout
            result.RegisterRuntimeType(typeof(EffectCutoutState),
                "Celeste.EffectCutout");
            // RegisterStoryScenesSceneEventTrigger
            result.RegisterRuntimeType(
                typeof(OriginalEventTriggerState),
                "Celeste.EventTrigger");
            // RegisterVisualEffectsSceneFallEffects
            result.RegisterRuntimeType(typeof(OriginalFallEffectsState),
                "Celeste.FallEffects");
            // RegisterDecorationSceneFlagline
            result.RegisterRuntimeType(
                typeof(OriginalFlaglineState), "Celeste.Flagline");
            // RegisterVisualEffectsSceneForegroundDebris
            result.RegisterRuntimeType(
                typeof(OriginalForegroundDebrisState),
                "Celeste.ForegroundDebris");
            // RegisterStoryScenesSceneHahaha
            result.RegisterRuntimeType(typeof(OriginalHahahaState),
                "Celeste.Hahaha");
            // RegisterDecorationSceneHangingLamp
            result.RegisterRuntimeType(
                typeof(OriginalHangingLampState),
                "Celeste.HangingLamp");
            // RegisterDecorationSceneLamp
            result.RegisterRuntimeType(typeof(OriginalLampState),
                "Celeste.Lamp");
            // RegisterLightingSceneLightBeam
            result.RegisterRuntimeType(
                typeof(OriginalLightFadeTriggerState),
                "Celeste.LightFadeTrigger");
            result.RegisterRuntimeType(
                typeof(OriginalLightBeamState),
                "Celeste.LightBeam");
            // RegisterLightingSceneLightOcclude
            result.RegisterRuntimeType(typeof(LightOccludeState),
                "Celeste.LightOcclude");
            // RegisterEnvironmentSceneMoonCreature
            result.RegisterRuntimeType(
                typeof(OriginalMoonGlitchBackgroundTriggerState),
                "Celeste.MoonGlitchBackgroundTrigger");
            // RegisterStoryNpcTypes
            result.RegisterRuntimeType(
                typeof(OriginalGravestoneState),
                "Celeste.NPC10_Gravestone");
            result.RegisterRuntimeType(typeof(OriginalCityTheoState),
                "Celeste.NPC01_Theo");
            result.RegisterRuntimeType(typeof(OriginalOldSiteTheoState),
                "Celeste.NPC02_Theo");
            result.RegisterRuntimeType(
                typeof(OriginalTempleEntranceTheoState),
                "Celeste.NPC05_Theo_Entrance");
            result.RegisterRuntimeType(
                typeof(OriginalTempleMirrorTheoState),
                "Celeste.NPC05_Theo_Mirror");
            result.RegisterRuntimeType(
                typeof(OriginalTempleBadelineState),
                "Celeste.NPC05_Badeline");
            result.RegisterRuntimeType(
                typeof(OriginalReflectionEndingGrannyState),
                "Celeste.NPC06_Granny_Ending");
            result.RegisterRuntimeType(typeof(OriginalTheoPlateauState),
                "Celeste.NPC06_Theo_Plateau");
            result.RegisterRuntimeType(typeof(OriginalTheoEndingState),
                "Celeste.NPC06_Theo_Ending");
            result.RegisterRuntimeType(
                typeof(OriginalBadelineCryingState),
                "Celeste.NPC06_Badeline_Crying");
            result.RegisterRuntimeType(
                typeof(OriginalBadelineCryingOrbState),
                "Celeste.NPC06_Badeline_Crying.Orb");
            // RegisterMenusAndTextScenePrologueEndingText
            result.RegisterRuntimeType(
                typeof(PrologueEndingTextPresentation),
                "Celeste.PrologueEndingText");
            // RegisterLightingScenePropLight
            result.RegisterRuntimeType(typeof(OriginalPropLightState),
                "Celeste.PropLight");
            // RegisterSceneComponentsSceneTileInterceptor
            result.RegisterRuntimeType(typeof(TileInterceptorState),
                "Celeste.TileInterceptor");
            // RegisterVisualEffectsSceneTrailManager
            result.RegisterRuntimeType(
                typeof(TrailManagerState),
                "Celeste.TrailManager");
            result.RegisterRuntimeType(
                typeof(TrailSnapshotState),
                "Celeste.TrailManager.Snapshot");
            // RegisterLightingSceneVertexLight
            result.RegisterRuntimeType(typeof(VertexLightState),
                "Celeste.VertexLight");
            // RegisterEnvironmentSceneWater
            result.RegisterRuntimeType(
                typeof(OriginalWaterFallState),
                "Celeste.WaterFall");
            // RegisterMonocleTypes
            result.RegisterRuntimeType(typeof(SceneEntityState),
                typeof(SceneEntityState).FullName);
            result.RegisterRuntimeType(typeof(SpriteImage), "Monocle.Image");
            result.RegisterRuntimeType(typeof(Sprite), "Monocle.Sprite");
            result.RegisterRuntimeType(typeof(SineWaveState),
                "Monocle.SineWave");
            result.RegisterRuntimeType(typeof(SimulationStateMachine),
                "Monocle.StateMachine");
            result.RegisterRuntimeType(typeof(WigglerComponent),
                "Monocle.Wiggler");
            // RegisterVisualEffectsRuntimeAbsorbOrb
            result.RegisterRuntimeType(
                typeof(OriginalAbsorbOrbState),
                "Celeste.AbsorbOrb");
            // RegisterEnemiesRuntimeAngryOshiro
            result.RegisterRuntimeType(
                typeof(OriginalAngryOshiroState),
                "Celeste.AngryOshiro");
            // RegisterStoryScenesRuntimeAscendManager
            result.RegisterRuntimeType(typeof(OriginalAscendManagerState),
                "Celeste.AscendManager");
            // RegisterInteractionRuntimeBadelineBoost
            result.RegisterRuntimeType(typeof(BadelineBoostState),
                "Celeste.BadelineBoost");
            // RegisterVisualEffectsRuntimeLevelUpEffect
            result.RegisterRuntimeType(
                typeof(LevelUpEffectState),
                "Celeste.LevelUpEffect");
            // RegisterEnemiesRuntimeBadelineOldsite
            result.RegisterRuntimeType(
                typeof(BadelineOldsiteState),
                "Celeste.BadelineOldsite");
            // RegisterStoryScenesRuntimeBirdPath
            result.RegisterRuntimeType(typeof(BirdPathState),
                "Celeste.BirdPath");
            result.RegisterRuntimeType(typeof(BirdPathTriggerState),
                "Celeste.BirdPathTrigger");
            // RegisterInteractionRuntimeBooster
            result.RegisterRuntimeType(
                typeof(OriginalBoosterState), "Celeste.Booster");
            // RegisterPlatformsRuntimeBounceBlock
            result.RegisterRuntimeType(
                typeof(BounceBlockState),
                "Celeste.BounceBlock");
            // RegisterStoryScenesRuntimeBreathingMinigame
            result.RegisterRuntimeType(
                typeof(OriginalBreathingMinigameState),
                "Celeste.BreathingMinigame");
            result.RegisterRuntimeType(typeof(OriginalBreathingRumblerState),
                "Celeste.BreathingRumbler");
            // RegisterPlatformsRuntimeBridgeFixed
            result.RegisterRuntimeType(typeof(OriginalBridgeFixedState),
                "Celeste.BridgeFixed");
            result.RegisterRuntimeType(typeof(OriginalBridgeState),
                "Celeste.Bridge");
            result.RegisterRuntimeType(typeof(OriginalBridgeTileState),
                "Celeste.BridgeTile");
            // RegisterInteractionRuntimeBumper
            result.RegisterRuntimeType(typeof(OriginalBumperState),
                "Celeste.Bumper");
            result.RegisterRuntimeType(
                typeof(OriginalCassetteBlockManagerState),
                "Celeste.CassetteBlockManager");
            // RegisterCassetteRhythmRuntimeCassetteBlock
            result.RegisterRuntimeType(typeof(CassetteBlockState),
                "Celeste.CassetteBlock");
            // RegisterCollectiblesRuntimeCassette
            result.RegisterRuntimeType(
                typeof(OriginalCassetteState),
                "Celeste.Cassette");
            result.RegisterRuntimeType(
                typeof(UnlockedBSideState),
                "Celeste.Cassette.UnlockedBSide");
            // RegisterPlatformsRuntimeCloud
            result.RegisterRuntimeType(typeof(OriginalCloudState),
                "Celeste.Cloud");
            // RegisterClutterRuntimeClutterAbsorbEffect
            result.RegisterRuntimeType(
                typeof(OriginalClutterAbsorbEffectState),
                "Celeste.ClutterAbsorbEffect");
            result.RegisterRuntimeType(
                typeof(OriginalClutterBlockBaseState),
                "Celeste.ClutterBlockBase");
            result.RegisterRuntimeType(
                typeof(OriginalClutterBlockState),
                "Celeste.ClutterBlock");
            result.RegisterRuntimeType(
                typeof(OriginalClutterCabinetState),
                "Celeste.ClutterCabinet");
            result.RegisterRuntimeType(typeof(ClutterDoorState),
                "Celeste.ClutterDoor");
            result.RegisterRuntimeType(
                typeof(OriginalClutterSwitchState),
                "Celeste.ClutterSwitch");
            // RegisterCoreModeRuntimeCoreMessage
            result.RegisterRuntimeType(typeof(CoreMessageState),
                "Celeste.CoreMessage");
            result.RegisterRuntimeType(
                typeof(OriginalCoreModeToggleState),
                "Celeste.CoreModeToggle");
            // RegisterWallsAndDoorsRuntimeCoverupWall
            result.RegisterRuntimeType(
                typeof(OriginalCoverupWallState),
                "Celeste.CoverupWall");
            // RegisterPlatformsRuntimeCrumblePlatform
            result.RegisterRuntimeType(
                typeof(OriginalCrumblePlatformState),
                "Celeste.CrumblePlatform");
            // RegisterWallsAndDoorsRuntimeCrumbleWallOnRumble
            result.RegisterRuntimeType(
                typeof(OriginalCrumbleWallOnRumbleState),
                "Celeste.CrumbleWallOnRumble");
            // RegisterPlatformsRuntimeCrushBlock
            result.RegisterRuntimeType(
                typeof(OriginalCrushBlockState),
                "Celeste.CrushBlock");
            // RegisterVisualEffectsRuntimeCrystalDebris
            result.RegisterRuntimeType(typeof(CrystalDebrisState),
                "Celeste.CrystalDebris");
            // RegisterHazardsRuntimeCrystalStaticSpinner
            result.RegisterRuntimeType(
                typeof(OriginalCrystalStaticSpinner),
                "Celeste.CrystalStaticSpinner");
            // RegisterWallsAndDoorsRuntimeDashBlock
            result.RegisterRuntimeType(typeof(OriginalDashBlockState),
                "Celeste.DashBlock");
            // RegisterInteractionRuntimeDashSwitch
            result.RegisterRuntimeType(
                typeof(OriginalDashSwitchState),
                "Celeste.DashSwitch");
            // RegisterCollectiblesRuntimeDetachStrawberryTrigger
            result.RegisterRuntimeType(
                typeof(
                    DetachStrawberryTriggerState),
                "Celeste.DetachStrawberryTrigger");
            // RegisterPlatformsRuntimeDreamBlock
            result.RegisterRuntimeType(
                typeof(OriginalDreamBlockState),
                "Celeste.DreamBlock");
            // RegisterStoryScenesRuntimeDreamMirror
            result.RegisterRuntimeType(typeof(DreamMirrorState),
                "Celeste.DreamMirror");
            // RegisterHazardsRuntimeDustRotateSpinner
            result.RegisterRuntimeType(
                typeof(OriginalDustRotateSpinnerState),
                "Celeste.DustRotateSpinner");
            result.RegisterRuntimeType(
                typeof(OriginalDustTrackSpinnerState),
                "Celeste.DustTrackSpinner");
            result.RegisterRuntimeType(
                typeof(OriginalDustStaticSpinnerState),
                "Celeste.DustStaticSpinner");
            // RegisterPlatformsRuntimeFallingBlock
            result.RegisterRuntimeType(
                typeof(OriginalFallingBlockState),
                "Celeste.FallingBlock");
            // RegisterEnemiesRuntimeFinalBoss
            result.RegisterRuntimeType(typeof(FinalBossState),
                "Celeste.FinalBoss");
            // RegisterPlatformsRuntimeFinalBossMovingBlock
            result.RegisterRuntimeType(
                typeof(OriginalFinalBossMovingBlockState), "Celeste.FinalBossMovingBlock");
            // RegisterHazardsRuntimeFireBall
            result.RegisterRuntimeType(
                typeof(OriginalFireBallState), "Celeste.FireBall");
            // RegisterStoryScenesRuntimeFlingBirdIntro
            result.RegisterRuntimeType(
                typeof(OriginalFlingBirdIntroState),
                "Celeste.FlingBirdIntro");
            result.RegisterRuntimeType(typeof(OriginalFlingBirdState),
                "Celeste.FlingBird");
            // RegisterVisualEffectsRuntimeFloatingDebris
            result.RegisterRuntimeType(
                typeof(OriginalFloatingDebrisState),
                "Celeste.FloatingDebris");
            // RegisterPlatformsRuntimeFloatySpaceBlock
            result.RegisterRuntimeType(
                typeof(FloatySpaceBlockState),
                "Celeste.FloatySpaceBlock");
            // RegisterCollectiblesRuntimeFlyFeather
            result.RegisterRuntimeType(typeof(OriginalFlyFeatherState),
                "Celeste.FlyFeather");
            // RegisterStoryScenesRuntimeForsakenCitySatellite
            result.RegisterRuntimeType(
                typeof(OriginalForsakenCitySatelliteState),
                "Celeste.ForsakenCitySatellite");
            // RegisterHudRuntimeGameplayStats
            result.RegisterRuntimeType(typeof(GameplayStatsState),
                "Celeste.GameplayStats");
            // RegisterHoldablesRuntimeGlider
            result.RegisterRuntimeType(typeof(OriginalGliderState),
                "Celeste.Glider");
            // RegisterPlayerPresentationRuntimeGrabbyIcon
            result.RegisterRuntimeType(
                typeof(OriginalGrabbyIconState),
                "Celeste.GrabbyIcon");
            // RegisterWallsAndDoorsRuntimeHeartGemDoor
            result.RegisterRuntimeType(
                typeof(OriginalHeartGemDoorState),
                "Celeste.HeartGemDoor");
            result.RegisterRuntimeType(
                typeof(HeartGemDoorWhiteLineState),
                "Celeste.HeartGemDoor.WhiteLine");
            // RegisterCollectiblesRuntimeHeartGem
            result.RegisterRuntimeType(
                typeof(OriginalHeartGemState),
                "Celeste.HeartGem");
            // RegisterHudRuntimeHeightDisplay
            result.RegisterRuntimeType(
                typeof(OriginalHeightDisplayState),
                "Celeste.HeightDisplay");
            // RegisterInteractionRuntimeInteractTrigger
            result.RegisterRuntimeType(
                typeof(OriginalInteractTriggerState),
                "Celeste.InteractTrigger");
            // RegisterPlatformsRuntimeIntroCrusher
            result.RegisterRuntimeType(
                typeof(OriginalIntroCrusherState),
                "Celeste.IntroCrusher");
            // RegisterCollectiblesRuntimeKey
            result.RegisterRuntimeType(typeof(OriginalKeyState),
                "Celeste.Key");
            // RegisterHazardsRuntimeKillbox
            result.RegisterRuntimeType(
                typeof(OriginalKillboxEntity), "Celeste.Killbox");
            result.RegisterRuntimeType(
                typeof(LightningBreakerBoxState),
                "Celeste.LightningBreakerBox");
            result.RegisterRuntimeType(
                typeof(LightningRendererState),
                "Celeste.LightningRenderer");
            result.RegisterRuntimeType(typeof(LightningState),
                "Celeste.Lightning");
            result.RegisterRuntimeType(typeof(LightningStrikeState),
                "Celeste.LightningStrike");
            // RegisterWallsAndDoorsRuntimeLockBlock
            result.RegisterRuntimeType(
                typeof(OriginalLockBlockState), "Celeste.LockBlock");
            // RegisterInteractionRuntimeLookoutBlocker
            result.RegisterRuntimeType(typeof(OriginalLookoutBlockerState),
                "Celeste.LookoutBlocker");
            result.RegisterRuntimeType(typeof(OriginalLookoutState),
                "Celeste.Lookout");
            result.RegisterRuntimeType(typeof(OriginalLookoutHud),
                "Celeste.Lookout.Hud");
            // RegisterStoryScenesRuntimeMemorial
            result.RegisterRuntimeType(typeof(MemorialState),
                "Celeste.Memorial");
            result.RegisterRuntimeType(typeof(MemorialTextState),
                "Celeste.MemorialText");
            // RegisterHudRuntimeMiniTextbox
            result.RegisterRuntimeType(typeof(MiniTextboxState),
                "Celeste.MiniTextbox");
            result.RegisterRuntimeType(
                typeof(MiniTextboxTriggerState),
                "Celeste.MiniTextboxTrigger");
            // RegisterEnvironmentRuntimeMoonCreature
            result.RegisterRuntimeType(
                typeof(OriginalMoonCreature),
                "Celeste.MoonCreature");
            // RegisterPlatformsRuntimeMoveBlock
            result.RegisterRuntimeType(typeof(MoveBlockState),
                "Celeste.MoveBlock");
            result.RegisterRuntimeType(
                typeof(OriginalMovingPlatformState),
                "Celeste.MovingPlatform");
            result.RegisterRuntimeType(
                typeof(OriginalMovingPlatformLineState),
                "Celeste.MovingPlatformLine");
            // RegisterHazardsRuntimeTrackSpinner
            result.RegisterRuntimeType(
                typeof(OriginalTrackSpinnerState),
                "Celeste.TrackSpinner");
            result.RegisterRuntimeType(
                typeof(OriginalRotateSpinnerState),
                "Celeste.RotateSpinner");
            result.RegisterRuntimeType(
                typeof(OriginalBladeRotateSpinnerState),
                "Celeste.BladeRotateSpinner");
            result.RegisterRuntimeType(
                typeof(OriginalBladeTrackSpinnerState),
                "Celeste.BladeTrackSpinner");
            result.RegisterRuntimeType(
                typeof(OriginalStarTrackSpinnerState),
                "Celeste.StarTrackSpinner");
            result.RegisterRuntimeType(
                typeof(OriginalStarRotateSpinnerState),
                "Celeste.StarRotateSpinner");
            // RegisterWallsAndDoorsRuntimeMrOshiroDoor
            result.RegisterRuntimeType(typeof(OriginalMrOshiroDoorState),
                "Celeste.MrOshiroDoor");
            // RegisterStoryScenesRuntimeOshiroLobbyBell
            result.RegisterRuntimeType(
                typeof(OriginalOshiroLobbyBellState),
                "Celeste.OshiroLobbyBell");
            result.RegisterRuntimeType(
                typeof(OriginalOshiroTriggerState),
                "Celeste.OshiroTrigger");
            // RegisterPlatformsRuntimePlateau
            result.RegisterRuntimeType(typeof(OriginalPlateauState),
                "Celeste.Plateau");
            // RegisterTutorialReplayRuntimePlaybackBillboard
            result.RegisterRuntimeType(
                typeof(PlaybackBillboardState),
                "Celeste.PlaybackBillboard");
            result.RegisterRuntimeType(
                PlaybackBillboardState.ForegroundEntityType,
                "Celeste.PlaybackBillboard.FG");
            result.RegisterRuntimeType(
                typeof(OriginalSwapBlockState.PathRenderer),
                "Celeste.SwapBlock.PathRenderer");
            result.RegisterRuntimeType(typeof(PlayerPlaybackState),
                "Celeste.PlayerPlayback");
            result.RegisterRuntimeType(typeof(OriginalPlayerPlaybackState),
                "Celeste.PlayerPlayback");
            // RegisterEnemiesRuntimePlayerSeeker
            result.RegisterRuntimeType(
                typeof(OriginalPlayerSeekerState),
                "Celeste.PlayerSeeker");
            // RegisterStoryScenesRuntimePoem
            result.RegisterRuntimeType(typeof(PoemState),
                "Celeste.Poem");
            result.RegisterRuntimeType(
                typeof(OriginalPowerSourceNumber),
                "Celeste.PowerSourceNumber");
            // RegisterHazardsRuntimePuffer
            result.RegisterRuntimeType(typeof(OriginalPufferState),
                "Celeste.Puffer");
            // RegisterStoryScenesRuntimeReflectionHeartStatue
            result.RegisterRuntimeType(
                typeof(OriginalReflectionHeartStatueState),
                "Celeste.ReflectionHeartStatue");
            result.RegisterRuntimeType(
                typeof(OriginalResortRoofEndingState),
                "Celeste.ResortRoofEnding");
            // RegisterWallsAndDoorsRuntimeRidgeGate
            result.RegisterRuntimeType(typeof(OriginalRidgeGateState),
                "Celeste.RidgeGate");
            // RegisterEnvironmentRuntimeRisingLava
            result.RegisterRuntimeType(
                typeof(OriginalRisingLavaState),
                "Celeste.RisingLava");
            // RegisterPlatformsRuntimeRotatingPlatform
            result.RegisterRuntimeType(
                typeof(OriginalRotatingPlatformState),
                "Celeste.RotatingPlatform");
            // RegisterWallsAndDoorsRuntimeRumbleTrigger
            result.RegisterRuntimeType(
                typeof(OriginalRumbleTriggerState),
                "Celeste.RumbleTrigger");
            // RegisterEnvironmentRuntimeSandwichLava
            result.RegisterRuntimeType(
                typeof(OriginalSandwichLavaState),
                "Celeste.SandwichLava");
            // RegisterWallsAndDoorsRuntimeFakeWall
            result.RegisterRuntimeType(typeof(FakeWallState),
                "Celeste.FakeWall");
            result.RegisterRuntimeType(typeof(ExitBlockState),
                "Celeste.ExitBlock");
            // RegisterEnemiesRuntimeSeekerBarrier
            result.RegisterRuntimeType(typeof(SeekerBarrierState),
                "Celeste.SeekerBarrier");
            result.RegisterRuntimeType(typeof(OriginalSeekerState),
                "Celeste.Seeker");
            // RegisterPlatformsRuntimeSinkingPlatform
            result.RegisterRuntimeType(
                typeof(OriginalSinkingPlatformState),
                "Celeste.SinkingPlatform");
            result.RegisterRuntimeType(
                typeof(OriginalSinkingPlatformLineState),
                "Celeste.SinkingPlatformLine");
            // RegisterHazardsRuntimeSnowball
            result.RegisterRuntimeType(
                typeof(OriginalSnowballState), "Celeste.Snowball");
            // RegisterAudioRuntimeSoundEmitter
            result.RegisterRuntimeType(typeof(SoundEmitterState),
                "Celeste.SoundEmitter");
            result.RegisterRuntimeType(
                typeof(SoundSourceEntityState),
                "Celeste.SoundSourceEntity");
            // RegisterDecorationRuntimeFlutterBird
            result.RegisterRuntimeType(typeof(FlutterBirdState),
                "Celeste.FlutterBird");
            // RegisterVisualEffectsRuntimeSpeedRing
            result.RegisterRuntimeType(
                typeof(OriginalSpeedRingState),
                "Celeste.SpeedRing");
            // RegisterPlatformsRuntimeStarJumpBlock
            result.RegisterRuntimeType(typeof(OriginalStarJumpBlockState),
                "Celeste.StarJumpBlock");
            result.RegisterRuntimeType(
                typeof(OriginalStarJumpControllerState),
                "Celeste.StarJumpController");
            result.RegisterRuntimeType(
                typeof(OriginalStarClimbGraphicsControllerState),
                "Celeste.Mod.Entities.StarClimbGraphicsController");
            // RegisterCollectiblesRuntimeStrawberrySeed
            result.RegisterRuntimeType(
                typeof(OriginalStrawberrySeedState),
                "Celeste.StrawberrySeed");
            result.RegisterRuntimeType(
                typeof(OriginalStrawberryState),
                "Celeste.Strawberry");
            // RegisterSummitRuntimeTypes
            result.RegisterRuntimeType(
                typeof(OriginalSummitCheckpointState),
                "Celeste.SummitCheckpoint");
            result.RegisterRuntimeType(
                typeof(OriginalSummitCloud),
                "Celeste.SummitCloud");
            result.RegisterRuntimeType(
                typeof(OriginalSummitGemManagerState),
                "Celeste.SummitGemManager");
            result.RegisterRuntimeType(
                typeof(OriginalSummitGemState),
                "Celeste.SummitGem");
            // RegisterPlatformsRuntimeSwapBlock
            result.RegisterRuntimeType(
                typeof(OriginalSwapBlockState),
                "Celeste.SwapBlock");
            // RegisterWallsAndDoorsRuntimeSwitchGate
            result.RegisterRuntimeType(
                typeof(OriginalSwitchGateState),
                "Celeste.SwitchGate");
            // RegisterTempleRuntimeTypes
            result.RegisterRuntimeType(
                typeof(OriginalTempleBigEyeballShockwaveState),
                "Celeste.TempleBigEyeballShockwave");
            result.RegisterRuntimeType(
                typeof(OriginalTempleCrackedBlockState),
                "Celeste.TempleCrackedBlock");
            result.RegisterRuntimeType(
                typeof(OriginalTempleEyeState),
                "Celeste.TempleEye");
            result.RegisterRuntimeType(
                typeof(OriginalTempleGateState),
                "Celeste.TempleGate");
            result.RegisterRuntimeType(typeof(TempleMirrorPortalState),
                "Celeste.TempleMirrorPortal");
            // RegisterMenusAndTextRuntimeTextbox
            result.RegisterRuntimeType(typeof(CS02JournalState),
                "Celeste.CS02_Journal");
            result.RegisterRuntimeType(typeof(CS03MemoState),
                "Celeste.CS03_Memo");
            result.RegisterRuntimeType(
                typeof(CS02JournalState).GetNestedType("PoemPage",
                    BindingFlags.NonPublic), "Celeste.CS02_Journal.PoemPage");
            result.RegisterRuntimeType(
                typeof(CS03MemoState).GetNestedType("MemoPage",
                    BindingFlags.NonPublic), "Celeste.CS03_Memo.MemoPage");
            result.RegisterRuntimeType(typeof(TextboxState),
                "Celeste.Textbox");
            // RegisterHoldablesRuntimeTheoCrystal
            result.RegisterRuntimeType(typeof(TheoCrystalState),
                "Celeste.TheoCrystal");
            // RegisterStoryScenesRuntimeTheoPhone
            result.RegisterRuntimeType(typeof(OriginalTheoPhoneState),
                "Celeste.TheoPhone");
            // RegisterHudRuntimeTotalStrawberriesDisplay
            result.RegisterRuntimeType(
                typeof(TotalStrawberriesDisplayState),
                "Celeste.TotalStrawberriesDisplay");
            // RegisterInteractionRuntimeTouchSwitch
            result.RegisterRuntimeType(
                typeof(OriginalTouchSwitchState),
                "Celeste.TouchSwitch");
            // RegisterWallsAndDoorsRuntimeTrapdoor
            result.RegisterRuntimeType(
                typeof(OriginalTrapdoorState), "Celeste.Trapdoor");
            // RegisterInteractionRuntimeWallBooster
            result.RegisterRuntimeType(
                typeof(OriginalWallBoosterState),
                "Celeste.WallBooster");
            // RegisterEnvironmentRuntimeWater
            result.RegisterRuntimeType(typeof(OriginalWaterState),
                "Celeste.Water");
            result.RegisterRuntimeType(
                typeof(WaterInteractionState),
                "Celeste.WaterInteraction");
            // RegisterWallsAndDoorsRuntimeWhiteBlock
            result.RegisterRuntimeType(
                typeof(OriginalWhiteBlock),
                "Celeste.WhiteBlock");
            // RegisterEnvironmentRuntimeWindAttackTrigger
            result.RegisterRuntimeType(
                typeof(OriginalWindAttackTriggerState),
                "Celeste.WindAttackTrigger");
            // RegisterPlatformsRuntimeZipMover
            result.RegisterRuntimeType(
                typeof(OriginalZipMoverState),
                "Celeste.ZipMover");
            // RegisterRoomTriggersRuntimeCheckpoint
            result.RegisterRuntimeType(typeof(OriginalCheckpointState),
                "Celeste.Checkpoint");
            result.RegisterRuntimeType(
                typeof(NoRefillTriggerState),
                "Celeste.NoRefillTrigger");
            result.RegisterRuntimeType(
                typeof(StopBoostTriggerState),
                "Celeste.StopBoostTrigger");
            result.RegisterRuntimeType(
                typeof(CheckpointBlockerTriggerState),
                "Celeste.CheckpointBlockerTrigger");
            // RegisterInteractionRuntimeSpring
            result.RegisterRuntimeType(
                typeof(OriginalSpringState), "Celeste.Spring");
            // RegisterCollectiblesRuntimeRefill
            result.RegisterRuntimeType(
                typeof(OriginalRefillState), "Celeste.Refill");
            // RegisterEnemiesRuntimeFinalBossBeam
            result.RegisterRuntimeType(
                typeof(FinalBossBeamState),
                "Celeste.FinalBossBeam");
            result.RegisterRuntimeType(
                typeof(FinalBossShotState),
                "Celeste.FinalBossShot");
            // RegisterStoryScenesRuntimeGondola
            result.RegisterRuntimeType(typeof(OriginalGondolaState),
                "Celeste.Gondola");
            result.RegisterRuntimeType(typeof(OriginalIntroCarState),
                "Celeste.IntroCar");
            result.RegisterRuntimeType(typeof(OriginalIntroPavementState),
                "Celeste.IntroPavement");
            // RegisterWallsAndDoorsRuntimeIntroCarBarrier
            result.RegisterRuntimeType(typeof(OriginalIntroCarBarrierState),
                "Celeste.IntroCarBarrier");
            // RegisterStoryScenesRuntimeKevinsPC
            result.RegisterRuntimeType(
                typeof(OriginalKevinsPCState),
                "Celeste.KevinsPC");
            // RegisterMountainPresentationRuntimeMaddy3D
            result.RegisterRuntimeType(typeof(BillboardState),
                "Celeste.Billboard");
            result.RegisterRuntimeType(
                typeof(Snow3DState.Particle),
                "Celeste.Snow3D.Particle");
            result.RegisterRuntimeType(
                typeof(MoonParticle3DState.Particle),
                "Celeste.MoonParticle3D.Particle");
            result.RegisterRuntimeType(typeof(Maddy3DState),
                "Celeste.Maddy3D");
            result.RegisterRuntimeType(typeof(Snow3DState),
                "Celeste.Snow3D");
            result.RegisterRuntimeType(
                typeof(MoonParticle3DState),
                "Celeste.MoonParticle3D");
            // RegisterStoryScenesRuntimePayphone
            result.RegisterRuntimeType(typeof(OriginalPayphoneState),
                "Celeste.Payphone");
            // RegisterClassicMinigameRuntimePicoConsole
            result.RegisterRuntimeType(
                typeof(PicoConsoleState),
                "Celeste.PicoConsole");
            // RegisterStoryScenesRuntimeReflectionTentacles
            result.RegisterRuntimeType(
                typeof(OriginalReflectionTentaclesState),
                "Celeste.ReflectionTentacles");
            // RegisterEnemiesRuntimeSeekerStatue
            result.RegisterRuntimeType(
                typeof(OriginalSeekerStatueState),
                "Celeste.SeekerStatue");
            // RegisterTemplePresentationRuntimeTypes
            result.RegisterRuntimeType(
                typeof(OriginalTempleBigEyeballState),
                "Celeste.TempleBigEyeball");
            result.RegisterRuntimeType(
                typeof(OriginalTempleMirrorState),
                "Celeste.TempleMirror");
            // RegisterHoldablesRuntimeTheoCrystalPedestal
            result.RegisterRuntimeType(
                typeof(TheoCrystalPedestalState),
                "Celeste.TheoCrystalPedestal");
            // RegisterHazardsRuntimeTriggerSpikes
            result.RegisterRuntimeType(
                typeof(TriggerSpikesState),
                "Celeste.TriggerSpikes");
            // RegisterClassicMinigameRuntimeUnlockedPico8Message
            result.RegisterRuntimeType(
                typeof(UnlockedPico8MessageState),
                "Celeste.UnlockedPico8Message");
            // RegisterTutorialReplayRuntimeWaveDashTutorialMachine
            result.RegisterRuntimeType(
                typeof(OriginalWaveDashTutorialMachineState),
                "Celeste.WaveDashTutorialMachine");
            // RegisterDecorationRuntimeWire
            result.RegisterRuntimeType(typeof(OriginalWireState),
                "Celeste.Wire");
            // RegisterTerrainAndTilesRuntimeIceTileOverlay
            result.RegisterRuntimeType(
                typeof(OriginalIceTileOverlayState),
                "Celeste.IceTileOverlay");
            // RegisterFarewellCutsceneRuntimeTypes
            result.RegisterRuntimeType(typeof(MoonIntroSequence),
                "Celeste.CS10_MoonIntro");
            result.RegisterRuntimeType(
                typeof(OriginalFarewellEndingCutscene),
                "Celeste.CS10_Ending");
            result.RegisterRuntimeType(typeof(OriginalHubIntroCutscene),
                "Celeste.CS10_HubIntro");
            result.RegisterRuntimeType(
                OriginalHubIntroCutscene.BirdRuntimeType,
                "Celeste.CS10_HubIntro.Bird");
            result.RegisterRuntimeType(
                typeof(OriginalBadelineHelpsCutscene),
                "Celeste.CS10_BadelineHelps");
            result.RegisterRuntimeType(
                typeof(OriginalFarewellCutscene),
                "Celeste.CS10_Farewell");
            result.RegisterRuntimeType(
                typeof(OriginalFinalRoomCutscene),
                "Celeste.CS10_FinalRoom");
            result.RegisterRuntimeType(
                typeof(OriginalDisperseImageState),
                "Celeste.DisperseImage");
            result.RegisterRuntimeType(
                typeof(OriginalGrannyLaughSfxState),
                "Celeste.GrannyLaughSfx");
            // RegisterPlayerPresentationRuntimePlayer2
            result.RegisterRuntimeType(typeof(RoomPlayerSession),
                typeof(RoomPlayerSession).FullName);
            // RegisterHazardsRuntimeDustEdges
            result.RegisterRuntimeType(
                typeof(DustEdgesPresentation),
                "Celeste.DustEdges");
        }
    }
}
