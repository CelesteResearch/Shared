using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities.Tracking.Metadata
{
    public static class OriginalSceneTypeNameMetadata
    {
        public static void ConfigureOriginal(SceneEntityCatalog catalog)
        {
            foreach (var definition in catalog.Types)
            {
                switch (definition.Name)
                {
                    case "Celeste.AbsorbOrb": definition.ConfigureLogicalTypeName("AbsorbOrb"); break;
                    case var actorRuntimeName
                        when actorRuntimeName ==
                             typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState)
                                 .FullName:
                        definition.ConfigureLogicalTypeName("Actor"); break;
                    case "Celeste.AltMusicTrigger": definition.ConfigureLogicalTypeName("AltMusicTrigger"); break;
                    case "Celeste.AmbienceParamTrigger":
                        definition.ConfigureLogicalTypeName("AmbienceParamTrigger"); break;
                    case "Celeste.AngryOshiro": definition.ConfigureLogicalTypeName("AngryOshiro"); break;
                    case "Celeste.AnimatedTiles": definition.ConfigureLogicalTypeName("AnimatedTiles"); break;
                    case "Celeste.AreaCompleteTitle": definition.ConfigureLogicalTypeName("AreaCompleteTitle"); break;
                    case "Celeste.AscendManager": definition.ConfigureLogicalTypeName("AscendManager"); break;
                    case "Celeste.AscendManager.Clouds": definition.ConfigureLogicalTypeName("Clouds"); break;
                    case "Celeste.AscendManager.Fader": definition.ConfigureLogicalTypeName("Fader"); break;
                    case "Celeste.AscendManager.Streaks": definition.ConfigureLogicalTypeName("Streaks"); break;
                    case "Celeste.BackgroundFadeIn": definition.ConfigureLogicalTypeName("BackgroundFadeIn"); break;
                    case "Celeste.BackgroundTiles": definition.ConfigureLogicalTypeName("BackgroundTiles"); break;
                    case "Celeste.BadelineAutoAnimator":
                        definition.ConfigureLogicalTypeName("BadelineAutoAnimator"); break;
                    case "Celeste.BadelineBoost": definition.ConfigureLogicalTypeName("BadelineBoost"); break;
                    case "Celeste.BadelineDummy": definition.ConfigureLogicalTypeName("BadelineDummy"); break;
                    case "Celeste.BadelineOldsite": definition.ConfigureLogicalTypeName("BadelineOldsite"); break;
                    case "Celeste.BeforeRenderHook": definition.ConfigureLogicalTypeName("BeforeRenderHook"); break;
                    case "Celeste.BestTimeDisplay": definition.ConfigureLogicalTypeName("BestTimeDisplay"); break;
                    case "Celeste.BigWaterfall": definition.ConfigureLogicalTypeName("BigWaterfall"); break;
                    case "Celeste.Billboard": definition.ConfigureLogicalTypeName("Billboard"); break;
                    case "Celeste.BirdNPC": definition.ConfigureLogicalTypeName("BirdNPC"); break;
                    case "Celeste.BirdPath": definition.ConfigureLogicalTypeName("BirdPath"); break;
                    case "Celeste.BirdPathTrigger": definition.ConfigureLogicalTypeName("BirdPathTrigger"); break;
                    case "Celeste.BirdTutorialGui": definition.ConfigureLogicalTypeName("BirdTutorialGui"); break;
                    case "Celeste.BlackholeStrengthTrigger":
                        definition.ConfigureLogicalTypeName("BlackholeStrengthTrigger"); break;
                    case "Celeste.BladeRotateSpinner": definition.ConfigureLogicalTypeName("BladeRotateSpinner"); break;
                    case "Celeste.BladeTrackSpinner": definition.ConfigureLogicalTypeName("BladeTrackSpinner"); break;
                    case "Celeste.BlockField": definition.ConfigureLogicalTypeName("BlockField"); break;
                    case "Celeste.BloomFadeTrigger": definition.ConfigureLogicalTypeName("BloomFadeTrigger"); break;
                    case "Celeste.BloomPoint": definition.ConfigureLogicalTypeName("BloomPoint"); break;
                    case "Celeste.Bonfire": definition.ConfigureLogicalTypeName("Bonfire"); break;
                    case "Celeste.Booster": definition.ConfigureLogicalTypeName("Booster"); break;
                    case "Celeste.BounceBlock": definition.ConfigureLogicalTypeName("BounceBlock"); break;
                    case "Celeste.BounceBlock.BreakDebris": definition.ConfigureLogicalTypeName("BreakDebris"); break;
                    case "Celeste.BounceBlock.RespawnDebris":
                        definition.ConfigureLogicalTypeName("RespawnDebris"); break;
                    case "Celeste.BreathingMinigame": definition.ConfigureLogicalTypeName("BreathingMinigame"); break;
                    case "Celeste.BreathingRumbler": definition.ConfigureLogicalTypeName("BreathingRumbler"); break;
                    case "Celeste.Bridge": definition.ConfigureLogicalTypeName("Bridge"); break;
                    case "Celeste.BridgeFixed": definition.ConfigureLogicalTypeName("BridgeFixed"); break;
                    case "Celeste.BridgeTile": definition.ConfigureLogicalTypeName("BridgeTile"); break;
                    case "Celeste.Bumper": definition.ConfigureLogicalTypeName("Bumper"); break;
                    case "Celeste.ButtonConfigUI": definition.ConfigureLogicalTypeName("ButtonConfigUI"); break;
                    case "Celeste.CS00_Ending": definition.ConfigureLogicalTypeName("CS00_Ending"); break;
                    case "Celeste.CS00_Ending.EndingCutsceneDelay":
                        definition.ConfigureLogicalTypeName("EndingCutsceneDelay"); break;
                    case "Celeste.CS00_Granny": definition.ConfigureLogicalTypeName("CS00_Granny"); break;
                    case "Celeste.CS01_Ending": definition.ConfigureLogicalTypeName("CS01_Ending"); break;
                    case "Celeste.CS02_BadelineIntro": definition.ConfigureLogicalTypeName("CS02_BadelineIntro"); break;
                    case "Celeste.CS02_DreamingPhonecall":
                        definition.ConfigureLogicalTypeName("CS02_DreamingPhonecall"); break;
                    case "Celeste.CS02_Ending": definition.ConfigureLogicalTypeName("CS02_Ending"); break;
                    case "Celeste.CS02_Journal": definition.ConfigureLogicalTypeName("CS02_Journal"); break;
                    case "Celeste.CS02_Journal.PoemPage": definition.ConfigureLogicalTypeName("PoemPage"); break;
                    case "Celeste.CS02_Mirror": definition.ConfigureLogicalTypeName("CS02_Mirror"); break;
                    case "Celeste.CS03_Diary": definition.ConfigureLogicalTypeName("CS03_Diary"); break;
                    case "Celeste.CS03_Ending": definition.ConfigureLogicalTypeName("CS03_Ending"); break;
                    case "Celeste.CS03_Ending.BgFlash": definition.ConfigureLogicalTypeName("BgFlash"); break;
                    case "Celeste.CS03_Guestbook": definition.ConfigureLogicalTypeName("CS03_Guestbook"); break;
                    case "Celeste.CS03_Memo": definition.ConfigureLogicalTypeName("CS03_Memo"); break;
                    case "Celeste.CS03_Memo.MemoPage": definition.ConfigureLogicalTypeName("MemoPage"); break;
                    case "Celeste.CS03_OshiroBreakdown":
                        definition.ConfigureLogicalTypeName("CS03_OshiroBreakdown"); break;
                    case "Celeste.CS03_OshiroClutter": definition.ConfigureLogicalTypeName("CS03_OshiroClutter"); break;
                    case "Celeste.CS03_OshiroHallway1":
                        definition.ConfigureLogicalTypeName("CS03_OshiroHallway1"); break;
                    case "Celeste.CS03_OshiroHallway2":
                        definition.ConfigureLogicalTypeName("CS03_OshiroHallway2"); break;
                    case "Celeste.CS03_OshiroLobby": definition.ConfigureLogicalTypeName("CS03_OshiroLobby"); break;
                    case "Celeste.CS03_OshiroMasterSuite":
                        definition.ConfigureLogicalTypeName("CS03_OshiroMasterSuite"); break;
                    case "Celeste.CS03_OshiroRooftop": definition.ConfigureLogicalTypeName("CS03_OshiroRooftop"); break;
                    case "Celeste.CS03_TheoEscape": definition.ConfigureLogicalTypeName("CS03_TheoEscape"); break;
                    case "Celeste.CS04_Gondola": definition.ConfigureLogicalTypeName("CS04_Gondola"); break;
                    case "Celeste.CS04_Granny": definition.ConfigureLogicalTypeName("CS04_Granny"); break;
                    case "Celeste.CS04_MirrorPortal": definition.ConfigureLogicalTypeName("CS04_MirrorPortal"); break;
                    case "Celeste.CS04_MirrorPortal.Fader": definition.ConfigureLogicalTypeName("Fader"); break;
                    case "Celeste.CS05_Badeline": definition.ConfigureLogicalTypeName("CS05_Badeline"); break;
                    case "Celeste.CS05_Entrance": definition.ConfigureLogicalTypeName("CS05_Entrance"); break;
                    case "Celeste.CS05_Reflection1": definition.ConfigureLogicalTypeName("CS05_Reflection1"); break;
                    case "Celeste.CS05_SaveTheo": definition.ConfigureLogicalTypeName("CS05_SaveTheo"); break;
                    case "Celeste.CS05_SeeTheo": definition.ConfigureLogicalTypeName("CS05_SeeTheo"); break;
                    case "Celeste.CS05_TheoInMirror": definition.ConfigureLogicalTypeName("CS05_TheoInMirror"); break;
                    case "Celeste.CS05_TheoPhone": definition.ConfigureLogicalTypeName("CS05_TheoPhone"); break;
                    case "Celeste.CS06_BossEnd": definition.ConfigureLogicalTypeName("CS06_BossEnd"); break;
                    case "Celeste.CS06_BossIntro": definition.ConfigureLogicalTypeName("CS06_BossIntro"); break;
                    case "Celeste.CS06_BossMid": definition.ConfigureLogicalTypeName("CS06_BossMid"); break;
                    case "Celeste.CS06_Campfire": definition.ConfigureLogicalTypeName("CS06_Campfire"); break;
                    case "Celeste.CS06_Ending": definition.ConfigureLogicalTypeName("CS06_Ending"); break;
                    case "Celeste.CS06_Granny": definition.ConfigureLogicalTypeName("CS06_Granny"); break;
                    case "Celeste.CS06_Reflection": definition.ConfigureLogicalTypeName("CS06_Reflection"); break;
                    case "Celeste.CS06_StarJumpEnd": definition.ConfigureLogicalTypeName("CS06_StarJumpEnd"); break;
                    case "Celeste.CS07_Ascend": definition.ConfigureLogicalTypeName("CS07_Ascend"); break;
                    case "Celeste.CS07_Credits": definition.ConfigureLogicalTypeName("CS07_Credits"); break;
                    case "Celeste.CS07_Ending": definition.ConfigureLogicalTypeName("CS07_Ending"); break;
                    case "Celeste.CS08_Ending": definition.ConfigureLogicalTypeName("CS08_Ending"); break;
                    case "Celeste.CS08_Ending.TimeDisplay": definition.ConfigureLogicalTypeName("TimeDisplay"); break;
                    case "Celeste.CS08_EnterDoor": definition.ConfigureLogicalTypeName("CS08_EnterDoor"); break;
                    case "Celeste.CS10_BadelineHelps": definition.ConfigureLogicalTypeName("CS10_BadelineHelps"); break;
                    case "Celeste.CS10_CatchTheBird": definition.ConfigureLogicalTypeName("CS10_CatchTheBird"); break;
                    case "Celeste.CS10_Ending": definition.ConfigureLogicalTypeName("CS10_Ending"); break;
                    case "Celeste.CS10_Farewell": definition.ConfigureLogicalTypeName("CS10_Farewell"); break;
                    case "Celeste.CS10_FinalLaunch": definition.ConfigureLogicalTypeName("CS10_FinalLaunch"); break;
                    case "Celeste.CS10_FinalRoom": definition.ConfigureLogicalTypeName("CS10_FinalRoom"); break;
                    case "Celeste.CS10_FreeBird": definition.ConfigureLogicalTypeName("CS10_FreeBird"); break;
                    case "Celeste.CS10_Gravestone": definition.ConfigureLogicalTypeName("CS10_Gravestone"); break;
                    case "Celeste.CS10_HubIntro": definition.ConfigureLogicalTypeName("CS10_HubIntro"); break;
                    case "Celeste.CS10_HubIntro.Bird": definition.ConfigureLogicalTypeName("Bird"); break;
                    case "Celeste.CS10_MissTheBird": definition.ConfigureLogicalTypeName("CS10_MissTheBird"); break;
                    case "Celeste.CS10_MoonIntro": definition.ConfigureLogicalTypeName("CS10_MoonIntro"); break;
                    case "Celeste.CSGEN_StrawberrySeeds":
                        definition.ConfigureLogicalTypeName("CSGEN_StrawberrySeeds"); break;
                    case "Celeste.CameraAdvanceTargetTrigger":
                        definition.ConfigureLogicalTypeName("CameraAdvanceTargetTrigger"); break;
                    case "Celeste.CameraLocker": definition.ConfigureLogicalTypeName("CameraLocker"); break;
                    case "Celeste.CameraOffsetTrigger":
                        definition.ConfigureLogicalTypeName("CameraOffsetTrigger"); break;
                    case "Celeste.CameraTargetTrigger":
                        definition.ConfigureLogicalTypeName("CameraTargetTrigger"); break;
                    case "Celeste.Cassette": definition.ConfigureLogicalTypeName("Cassette"); break;
                    case "Celeste.Cassette.UnlockedBSide": definition.ConfigureLogicalTypeName("UnlockedBSide"); break;
                    case "Celeste.CassetteBlock": definition.ConfigureLogicalTypeName("CassetteBlock"); break;
                    case "Celeste.CassetteBlock.BoxSide": definition.ConfigureLogicalTypeName("BoxSide"); break;
                    case "Celeste.CassetteBlockManager":
                        definition.ConfigureLogicalTypeName("CassetteBlockManager"); break;
                    case "Celeste.ChangeRespawnTrigger":
                        definition.ConfigureLogicalTypeName("ChangeRespawnTrigger"); break;
                    case "Celeste.ChaserBarrier": definition.ConfigureLogicalTypeName("ChaserBarrier"); break;
                    case "Celeste.Checkpoint": definition.ConfigureLogicalTypeName("Checkpoint"); break;
                    case "Celeste.CheckpointBlockerTrigger":
                        definition.ConfigureLogicalTypeName("CheckpointBlockerTrigger"); break;
                    case "Celeste.CliffFlags": definition.ConfigureLogicalTypeName("CliffFlags"); break;
                    case "Celeste.CliffsideWindFlag": definition.ConfigureLogicalTypeName("CliffsideWindFlag"); break;
                    case "Celeste.ClimbBlocker": definition.ConfigureLogicalTypeName("ClimbBlocker"); break;
                    case "Celeste.Clothesline": definition.ConfigureLogicalTypeName("Clothesline"); break;
                    case "Celeste.Cloud": definition.ConfigureLogicalTypeName("Cloud"); break;
                    case "Celeste.ClutterAbsorbEffect":
                        definition.ConfigureLogicalTypeName("ClutterAbsorbEffect"); break;
                    case "Celeste.ClutterBlock": definition.ConfigureLogicalTypeName("ClutterBlock"); break;
                    case "Celeste.ClutterBlockBase": definition.ConfigureLogicalTypeName("ClutterBlockBase"); break;
                    case "Celeste.ClutterCabinet": definition.ConfigureLogicalTypeName("ClutterCabinet"); break;
                    case "Celeste.ClutterDoor": definition.ConfigureLogicalTypeName("ClutterDoor"); break;
                    case "Celeste.ClutterSwitch": definition.ConfigureLogicalTypeName("ClutterSwitch"); break;
                    case "Celeste.Cobweb": definition.ConfigureLogicalTypeName("Cobweb"); break;
                    case "Celeste.CoreMessage": definition.ConfigureLogicalTypeName("CoreMessage"); break;
                    case "Celeste.CoreModeListener": definition.ConfigureLogicalTypeName("CoreModeListener"); break;
                    case "Celeste.CoreModeToggle": definition.ConfigureLogicalTypeName("CoreModeToggle"); break;
                    case "Celeste.CoverupWall": definition.ConfigureLogicalTypeName("CoverupWall"); break;
                    case "Celeste.CreditsTrigger": definition.ConfigureLogicalTypeName("CreditsTrigger"); break;
                    case "Celeste.CrumblePlatform": definition.ConfigureLogicalTypeName("CrumblePlatform"); break;
                    case "Celeste.CrumbleWallOnRumble":
                        definition.ConfigureLogicalTypeName("CrumbleWallOnRumble"); break;
                    case "Celeste.CrushBlock": definition.ConfigureLogicalTypeName("CrushBlock"); break;
                    case "Celeste.CrystalDebris": definition.ConfigureLogicalTypeName("CrystalDebris"); break;
                    case "Celeste.CrystalStaticSpinner":
                        definition.ConfigureLogicalTypeName("CrystalStaticSpinner"); break;
                    case "Celeste.CrystalStaticSpinner.Border": definition.ConfigureLogicalTypeName("Border"); break;
                    case "Celeste.CrystalStaticSpinner.CoreModeListener":
                        definition.ConfigureLogicalTypeName("CoreModeListener"); break;
                    case "Celeste.CustomBloom": definition.ConfigureLogicalTypeName("CustomBloom"); break;
                    case "Celeste.CutsceneEntity": definition.ConfigureLogicalTypeName("CutsceneEntity"); break;
                    case "Celeste.CutsceneNode": definition.ConfigureLogicalTypeName("CutsceneNode"); break;
                    case "Celeste.DashBlock": definition.ConfigureLogicalTypeName("DashBlock"); break;
                    case "Celeste.DashListener": definition.ConfigureLogicalTypeName("DashListener"); break;
                    case "Celeste.DashSwitch": definition.ConfigureLogicalTypeName("DashSwitch"); break;
                    case "Celeste.DeathEffect": definition.ConfigureLogicalTypeName("DeathEffect"); break;
                    case "Celeste.DeathsCounter": definition.ConfigureLogicalTypeName("DeathsCounter"); break;
                    case "Celeste.Debris": definition.ConfigureLogicalTypeName("Debris"); break;
                    case "Celeste.Decal": definition.ConfigureLogicalTypeName("Decal"); break;
                    case "Celeste.Decal.Banner": definition.ConfigureLogicalTypeName("Banner"); break;
                    case "Celeste.Decal.CoreSwapImage": definition.ConfigureLogicalTypeName("CoreSwapImage"); break;
                    case "Celeste.Decal.DecalImage": definition.ConfigureLogicalTypeName("DecalImage"); break;
                    case "Celeste.Decal.FinalFlagDecalImage":
                        definition.ConfigureLogicalTypeName("FinalFlagDecalImage"); break;
                    case "Celeste.DetachStrawberryTrigger":
                        definition.ConfigureLogicalTypeName("DetachStrawberryTrigger"); break;
                    case "Celeste.DisperseImage": definition.ConfigureLogicalTypeName("DisperseImage"); break;
                    case "Celeste.DisplacementRenderHook":
                        definition.ConfigureLogicalTypeName("DisplacementRenderHook"); break;
                    case "Celeste.Door": definition.ConfigureLogicalTypeName("Door"); break;
                    case "Celeste.DreamBlock": definition.ConfigureLogicalTypeName("DreamBlock"); break;
                    case "Celeste.DreamHeartGem": definition.ConfigureLogicalTypeName("DreamHeartGem"); break;
                    case "Celeste.DreamMirror": definition.ConfigureLogicalTypeName("DreamMirror"); break;
                    case "Celeste.DustEdge": definition.ConfigureLogicalTypeName("DustEdge"); break;
                    case "Celeste.DustEdges": definition.ConfigureLogicalTypeName("DustEdges"); break;
                    case "Celeste.DustGraphic": definition.ConfigureLogicalTypeName("DustGraphic"); break;
                    case "Celeste.DustGraphic.Eyeballs": definition.ConfigureLogicalTypeName("Eyeballs"); break;
                    case "Celeste.DustRotateSpinner": definition.ConfigureLogicalTypeName("DustRotateSpinner"); break;
                    case "Celeste.DustStaticSpinner": definition.ConfigureLogicalTypeName("DustStaticSpinner"); break;
                    case "Celeste.DustTrackSpinner": definition.ConfigureLogicalTypeName("DustTrackSpinner"); break;
                    case "Celeste.EffectCutout": definition.ConfigureLogicalTypeName("EffectCutout"); break;
                    case "Celeste.EventTrigger": definition.ConfigureLogicalTypeName("EventTrigger"); break;
                    case "Celeste.ExitBlock": definition.ConfigureLogicalTypeName("ExitBlock"); break;
                    case "Celeste.FakeHeart": definition.ConfigureLogicalTypeName("FakeHeart"); break;
                    case "Celeste.FakeWall": definition.ConfigureLogicalTypeName("FakeWall"); break;
                    case "Celeste.FallEffects": definition.ConfigureLogicalTypeName("FallEffects"); break;
                    case "Celeste.FallingBlock": definition.ConfigureLogicalTypeName("FallingBlock"); break;
                    case "Celeste.FileErrorOverlay": definition.ConfigureLogicalTypeName("FileErrorOverlay"); break;
                    case "Celeste.FinalBoss": definition.ConfigureLogicalTypeName("FinalBoss"); break;
                    case "Celeste.FinalBossBeam": definition.ConfigureLogicalTypeName("FinalBossBeam"); break;
                    case "Celeste.FinalBossMovingBlock":
                        definition.ConfigureLogicalTypeName("FinalBossMovingBlock"); break;
                    case "Celeste.FinalBossShot": definition.ConfigureLogicalTypeName("FinalBossShot"); break;
                    case "Celeste.FireBall": definition.ConfigureLogicalTypeName("FireBall"); break;
                    case "Celeste.FireBarrier": definition.ConfigureLogicalTypeName("FireBarrier"); break;
                    case "Celeste.Flagline": definition.ConfigureLogicalTypeName("Flagline"); break;
                    case "Celeste.FlingBird": definition.ConfigureLogicalTypeName("FlingBird"); break;
                    case "Celeste.FlingBirdIntro": definition.ConfigureLogicalTypeName("FlingBirdIntro"); break;
                    case "Celeste.FloatingDebris": definition.ConfigureLogicalTypeName("FloatingDebris"); break;
                    case "Celeste.FloatySpaceBlock": definition.ConfigureLogicalTypeName("FloatySpaceBlock"); break;
                    case "Celeste.FlutterBird": definition.ConfigureLogicalTypeName("FlutterBird"); break;
                    case "Celeste.FlyFeather": definition.ConfigureLogicalTypeName("FlyFeather"); break;
                    case "Celeste.Follower": definition.ConfigureLogicalTypeName("Follower"); break;
                    case "Celeste.ForegroundDebris": definition.ConfigureLogicalTypeName("ForegroundDebris"); break;
                    case "Celeste.FormationBackdrop": definition.ConfigureLogicalTypeName("FormationBackdrop"); break;
                    case "Celeste.ForsakenCitySatellite":
                        definition.ConfigureLogicalTypeName("ForsakenCitySatellite"); break;
                    case "Celeste.ForsakenCitySatellite.CodeBird":
                        definition.ConfigureLogicalTypeName("CodeBird"); break;
                    case "Celeste.GameplayStats": definition.ConfigureLogicalTypeName("GameplayStats"); break;
                    case "Celeste.GlassBlock": definition.ConfigureLogicalTypeName("GlassBlock"); break;
                    case "Celeste.GlassBlockBg": definition.ConfigureLogicalTypeName("GlassBlockBg"); break;
                    case "Celeste.Glider": definition.ConfigureLogicalTypeName("Glider"); break;
                    case "Celeste.GoldBerryCollectTrigger":
                        definition.ConfigureLogicalTypeName("GoldBerryCollectTrigger"); break;
                    case "Celeste.GoldenBlock": definition.ConfigureLogicalTypeName("GoldenBlock"); break;
                    case "Celeste.Gondola": definition.ConfigureLogicalTypeName("Gondola"); break;
                    case "Celeste.Gondola.Rope": definition.ConfigureLogicalTypeName("Rope"); break;
                    case "Celeste.GondolaDarkness": definition.ConfigureLogicalTypeName("GondolaDarkness"); break;
                    case "Celeste.GondolaDarkness.Blackness": definition.ConfigureLogicalTypeName("Blackness"); break;
                    case "Celeste.GrabbyIcon": definition.ConfigureLogicalTypeName("GrabbyIcon"); break;
                    case "Celeste.GrannyLaughSfx": definition.ConfigureLogicalTypeName("GrannyLaughSfx"); break;
                    case "Celeste.Hahaha": definition.ConfigureLogicalTypeName("Hahaha"); break;
                    case "Celeste.HangingLamp": definition.ConfigureLogicalTypeName("HangingLamp"); break;
                    case "Celeste.HeartGem": definition.ConfigureLogicalTypeName("HeartGem"); break;
                    case "Celeste.HeartGemDisplay": definition.ConfigureLogicalTypeName("HeartGemDisplay"); break;
                    case "Celeste.HeartGemDoor": definition.ConfigureLogicalTypeName("HeartGemDoor"); break;
                    case "Celeste.HeartGemDoor.WhiteLine": definition.ConfigureLogicalTypeName("WhiteLine"); break;
                    case "Celeste.HeightDisplay": definition.ConfigureLogicalTypeName("HeightDisplay"); break;
                    case "Celeste.Holdable": definition.ConfigureLogicalTypeName("Holdable"); break;
                    case "Celeste.HoldableCollider": definition.ConfigureLogicalTypeName("HoldableCollider"); break;
                    case "Celeste.IceBlock": definition.ConfigureLogicalTypeName("IceBlock"); break;
                    case "Celeste.IceTileOverlay": definition.ConfigureLogicalTypeName("IceTileOverlay"); break;
                    case "Celeste.InteractTrigger": definition.ConfigureLogicalTypeName("InteractTrigger"); break;
                    case "Celeste.IntroCar": definition.ConfigureLogicalTypeName("IntroCar"); break;
                    case "Celeste.IntroCarBarrier": definition.ConfigureLogicalTypeName("IntroCarBarrier"); break;
                    case "Celeste.IntroCrusher": definition.ConfigureLogicalTypeName("IntroCrusher"); break;
                    case "Celeste.IntroPavement": definition.ConfigureLogicalTypeName("IntroPavement"); break;
                    case "Celeste.InvisibleBarrier": definition.ConfigureLogicalTypeName("InvisibleBarrier"); break;
                    case "Celeste.JumpThru": definition.ConfigureLogicalTypeName("JumpThru"); break;
                    case "Celeste.JumpthruPlatform": definition.ConfigureLogicalTypeName("JumpthruPlatform"); break;
                    case "Celeste.KevinsPC": definition.ConfigureLogicalTypeName("KevinsPC"); break;
                    case "Celeste.Key": definition.ConfigureLogicalTypeName("Key"); break;
                    case "Celeste.KeyboardConfigUI": definition.ConfigureLogicalTypeName("KeyboardConfigUI"); break;
                    case "Celeste.Killbox": definition.ConfigureLogicalTypeName("Killbox"); break;
                    case "Celeste.Lamp": definition.ConfigureLogicalTypeName("Lamp"); break;
                    case "Celeste.LanguageSelectUI": definition.ConfigureLogicalTypeName("LanguageSelectUI"); break;
                    case "Celeste.LavaRect": definition.ConfigureLogicalTypeName("LavaRect"); break;
                    case "Celeste.Leader": definition.ConfigureLogicalTypeName("Leader"); break;
                    case "Celeste.LedgeBlocker": definition.ConfigureLogicalTypeName("LedgeBlocker"); break;
                    case "Celeste.LevelEndingHook": definition.ConfigureLogicalTypeName("LevelEndingHook"); break;
                    case "Celeste.LevelEnter.BSideTitle": definition.ConfigureLogicalTypeName("BSideTitle"); break;
                    case "Celeste.LevelUpEffect": definition.ConfigureLogicalTypeName("LevelUpEffect"); break;
                    case "Celeste.LightBeam": definition.ConfigureLogicalTypeName("LightBeam"); break;
                    case "Celeste.LightFadeTrigger": definition.ConfigureLogicalTypeName("LightFadeTrigger"); break;
                    case "Celeste.LightOcclude": definition.ConfigureLogicalTypeName("LightOcclude"); break;
                    case "Celeste.Lightning": definition.ConfigureLogicalTypeName("Lightning"); break;
                    case "Celeste.LightningBreakerBox":
                        definition.ConfigureLogicalTypeName("LightningBreakerBox"); break;
                    case "Celeste.LightningRenderer": definition.ConfigureLogicalTypeName("LightningRenderer"); break;
                    case "Celeste.LightningStrike": definition.ConfigureLogicalTypeName("LightningStrike"); break;
                    case "Celeste.LockBlock": definition.ConfigureLogicalTypeName("LockBlock"); break;
                    case "Celeste.Lookout": definition.ConfigureLogicalTypeName("Lookout"); break;
                    case "Celeste.Lookout.Hud": definition.ConfigureLogicalTypeName("Hud"); break;
                    case "Celeste.LookoutBlocker": definition.ConfigureLogicalTypeName("LookoutBlocker"); break;
                    case "Celeste.Maddy3D": definition.ConfigureLogicalTypeName("Maddy3D"); break;
                    case "Celeste.MainMenuClimb": definition.ConfigureLogicalTypeName("MainMenuClimb"); break;
                    case "Celeste.MainMenuSmallButton":
                        definition.ConfigureLogicalTypeName("MainMenuSmallButton"); break;
                    case "Celeste.Memorial": definition.ConfigureLogicalTypeName("Memorial"); break;
                    case "Celeste.MemorialText": definition.ConfigureLogicalTypeName("MemorialText"); break;
                    case "Celeste.MenuButton": definition.ConfigureLogicalTypeName("MenuButton"); break;
                    case "Celeste.MiniTextbox": definition.ConfigureLogicalTypeName("MiniTextbox"); break;
                    case "Celeste.MiniTextboxTrigger": definition.ConfigureLogicalTypeName("MiniTextboxTrigger"); break;
                    case "Celeste.MirrorReflection": definition.ConfigureLogicalTypeName("MirrorReflection"); break;
                    case "Celeste.MirrorSurface": definition.ConfigureLogicalTypeName("MirrorSurface"); break;
                    case "Celeste.MirrorSurfaces": definition.ConfigureLogicalTypeName("MirrorSurfaces"); break;
                    case "Celeste.MoonCreature": definition.ConfigureLogicalTypeName("MoonCreature"); break;
                    case "Celeste.MoonGlitchBackgroundTrigger":
                        definition.ConfigureLogicalTypeName("MoonGlitchBackgroundTrigger"); break;
                    case "Celeste.MoonParticle3D": definition.ConfigureLogicalTypeName("MoonParticle3D"); break;
                    case "Celeste.MoonParticle3D.Particle": definition.ConfigureLogicalTypeName("Particle"); break;
                    case "Celeste.MoveBlock": definition.ConfigureLogicalTypeName("MoveBlock"); break;
                    case "Celeste.MoveBlock.Border": definition.ConfigureLogicalTypeName("Border"); break;
                    case "Celeste.MoveBlock.Debris": definition.ConfigureLogicalTypeName("Debris"); break;
                    case "Celeste.MovingPlatform": definition.ConfigureLogicalTypeName("MovingPlatform"); break;
                    case "Celeste.MovingPlatformLine": definition.ConfigureLogicalTypeName("MovingPlatformLine"); break;
                    case "Celeste.MrOshiroDoor": definition.ConfigureLogicalTypeName("MrOshiroDoor"); break;
                    case "Celeste.MusicFadeTrigger": definition.ConfigureLogicalTypeName("MusicFadeTrigger"); break;
                    case "Celeste.MusicTrigger": definition.ConfigureLogicalTypeName("MusicTrigger"); break;
                    case "Celeste.NPC": definition.ConfigureLogicalTypeName("NPC"); break;
                    case "Celeste.NPC00_Granny": definition.ConfigureLogicalTypeName("NPC00_Granny"); break;
                    case "Celeste.NPC01_Theo": definition.ConfigureLogicalTypeName("NPC01_Theo"); break;
                    case "Celeste.NPC02_Theo": definition.ConfigureLogicalTypeName("NPC02_Theo"); break;
                    case "Celeste.NPC03_Oshiro_Breakdown":
                        definition.ConfigureLogicalTypeName("NPC03_Oshiro_Breakdown"); break;
                    case "Celeste.NPC03_Oshiro_Cluttter":
                        definition.ConfigureLogicalTypeName("NPC03_Oshiro_Cluttter"); break;
                    case "Celeste.NPC03_Oshiro_Hallway1":
                        definition.ConfigureLogicalTypeName("NPC03_Oshiro_Hallway1"); break;
                    case "Celeste.NPC03_Oshiro_Hallway2":
                        definition.ConfigureLogicalTypeName("NPC03_Oshiro_Hallway2"); break;
                    case "Celeste.NPC03_Oshiro_Lobby": definition.ConfigureLogicalTypeName("NPC03_Oshiro_Lobby"); break;
                    case "Celeste.NPC03_Oshiro_Rooftop":
                        definition.ConfigureLogicalTypeName("NPC03_Oshiro_Rooftop"); break;
                    case "Celeste.NPC03_Oshiro_Suite": definition.ConfigureLogicalTypeName("NPC03_Oshiro_Suite"); break;
                    case "Celeste.NPC03_Theo_Escaping":
                        definition.ConfigureLogicalTypeName("NPC03_Theo_Escaping"); break;
                    case "Celeste.NPC03_Theo_Escaping.Grate": definition.ConfigureLogicalTypeName("Grate"); break;
                    case "Celeste.NPC03_Theo_Vents": definition.ConfigureLogicalTypeName("NPC03_Theo_Vents"); break;
                    case "Celeste.NPC03_Theo_Vents.Grate": definition.ConfigureLogicalTypeName("Grate"); break;
                    case "Celeste.NPC04_Granny": definition.ConfigureLogicalTypeName("NPC04_Granny"); break;
                    case "Celeste.NPC04_Theo": definition.ConfigureLogicalTypeName("NPC04_Theo"); break;
                    case "Celeste.NPC05_Badeline": definition.ConfigureLogicalTypeName("NPC05_Badeline"); break;
                    case "Celeste.NPC05_Theo_Entrance":
                        definition.ConfigureLogicalTypeName("NPC05_Theo_Entrance"); break;
                    case "Celeste.NPC05_Theo_Mirror": definition.ConfigureLogicalTypeName("NPC05_Theo_Mirror"); break;
                    case "Celeste.NPC06_Badeline_Crying":
                        definition.ConfigureLogicalTypeName("NPC06_Badeline_Crying"); break;
                    case "Celeste.NPC06_Badeline_Crying.Orb": definition.ConfigureLogicalTypeName("Orb"); break;
                    case "Celeste.NPC06_Granny": definition.ConfigureLogicalTypeName("NPC06_Granny"); break;
                    case "Celeste.NPC06_Granny_Ending":
                        definition.ConfigureLogicalTypeName("NPC06_Granny_Ending"); break;
                    case "Celeste.NPC06_Theo_Ending": definition.ConfigureLogicalTypeName("NPC06_Theo_Ending"); break;
                    case "Celeste.NPC06_Theo_Plateau": definition.ConfigureLogicalTypeName("NPC06_Theo_Plateau"); break;
                    case "Celeste.NPC07X_Granny_Ending":
                        definition.ConfigureLogicalTypeName("NPC07X_Granny_Ending"); break;
                    case "Celeste.NPC08_Granny": definition.ConfigureLogicalTypeName("NPC08_Granny"); break;
                    case "Celeste.NPC08_Theo": definition.ConfigureLogicalTypeName("NPC08_Theo"); break;
                    case "Celeste.NPC09_Granny_Inside":
                        definition.ConfigureLogicalTypeName("NPC09_Granny_Inside"); break;
                    case "Celeste.NPC09_Granny_Outside":
                        definition.ConfigureLogicalTypeName("NPC09_Granny_Outside"); break;
                    case "Celeste.NPC10_Gravestone": definition.ConfigureLogicalTypeName("NPC10_Gravestone"); break;
                    case "Celeste.NegaBlock": definition.ConfigureLogicalTypeName("NegaBlock"); break;
                    case "Celeste.NoRefillTrigger": definition.ConfigureLogicalTypeName("NoRefillTrigger"); break;
                    case "Celeste.OldSiteChaseMusicHandler":
                        definition.ConfigureLogicalTypeName("OldSiteChaseMusicHandler"); break;
                    case "Celeste.OshiroLobbyBell": definition.ConfigureLogicalTypeName("OshiroLobbyBell"); break;
                    case "Celeste.OshiroSprite": definition.ConfigureLogicalTypeName("OshiroSprite"); break;
                    case "Celeste.OshiroTrigger": definition.ConfigureLogicalTypeName("OshiroTrigger"); break;
                    case "Celeste.Oui": definition.ConfigureLogicalTypeName("Oui"); break;
                    case "Celeste.OuiAssistMode": definition.ConfigureLogicalTypeName("OuiAssistMode"); break;
                    case "Celeste.OuiChapterPanel": definition.ConfigureLogicalTypeName("OuiChapterPanel"); break;
                    case "Celeste.OuiChapterSelect": definition.ConfigureLogicalTypeName("OuiChapterSelect"); break;
                    case "Celeste.OuiChapterSelectIcon":
                        definition.ConfigureLogicalTypeName("OuiChapterSelectIcon"); break;
                    case "Celeste.OuiCredits": definition.ConfigureLogicalTypeName("OuiCredits"); break;
                    case "Celeste.OuiFileNaming": definition.ConfigureLogicalTypeName("OuiFileNaming"); break;
                    case "Celeste.OuiFileSelect": definition.ConfigureLogicalTypeName("OuiFileSelect"); break;
                    case "Celeste.OuiFileSelectSlot": definition.ConfigureLogicalTypeName("OuiFileSelectSlot"); break;
                    case "Celeste.OuiJournal": definition.ConfigureLogicalTypeName("OuiJournal"); break;
                    case "Celeste.OuiMainMenu": definition.ConfigureLogicalTypeName("OuiMainMenu"); break;
                    case "Celeste.OuiOptions": definition.ConfigureLogicalTypeName("OuiOptions"); break;
                    case "Celeste.OuiTitleScreen": definition.ConfigureLogicalTypeName("OuiTitleScreen"); break;
                    case "Celeste.Overlay": definition.ConfigureLogicalTypeName("Overlay"); break;
                    case "Celeste.Overworld.InputEntity": definition.ConfigureLogicalTypeName("InputEntity"); break;
                    case "Celeste.Payphone": definition.ConfigureLogicalTypeName("Payphone"); break;
                    case "Celeste.PicoConsole": definition.ConfigureLogicalTypeName("PicoConsole"); break;
                    case "Celeste.Plateau": definition.ConfigureLogicalTypeName("Plateau"); break;
                    case "Celeste.Platform": definition.ConfigureLogicalTypeName("Platform"); break;
                    case "Celeste.PlaybackBillboard": definition.ConfigureLogicalTypeName("PlaybackBillboard"); break;
                    case "Celeste.PlaybackBillboard.FG": definition.ConfigureLogicalTypeName("FG"); break;
                    case var playerRuntimeName
                        when playerRuntimeName == typeof(global::Celeste.Simulation.RoomPlayerSession).FullName:
                        definition.ConfigureLogicalTypeName("Player"); break;
                    case "Celeste.PlayerCollider": definition.ConfigureLogicalTypeName("PlayerCollider"); break;
                    case "Celeste.PlayerDashAssist": definition.ConfigureLogicalTypeName("PlayerDashAssist"); break;
                    case "Celeste.PlayerDeadBody": definition.ConfigureLogicalTypeName("PlayerDeadBody"); break;
                    case "Celeste.PlayerHair": definition.ConfigureLogicalTypeName("PlayerHair"); break;
                    case "Celeste.PlayerPlayback": definition.ConfigureLogicalTypeName("PlayerPlayback"); break;
                    case "Celeste.PlayerSeeker": definition.ConfigureLogicalTypeName("PlayerSeeker"); break;
                    case "Celeste.PlayerSprite": definition.ConfigureLogicalTypeName("PlayerSprite"); break;
                    case "Celeste.Poem": definition.ConfigureLogicalTypeName("Poem"); break;
                    case "Celeste.PostUpdateHook": definition.ConfigureLogicalTypeName("PostUpdateHook"); break;
                    case "Celeste.Postcard": definition.ConfigureLogicalTypeName("Postcard"); break;
                    case "Celeste.PowerSourceNumber": definition.ConfigureLogicalTypeName("PowerSourceNumber"); break;
                    case "Celeste.PrologueEndingText": definition.ConfigureLogicalTypeName("PrologueEndingText"); break;
                    case "Celeste.PropLight": definition.ConfigureLogicalTypeName("PropLight"); break;
                    case "Celeste.Puffer": definition.ConfigureLogicalTypeName("Puffer"); break;
                    case "Celeste.PufferCollider": definition.ConfigureLogicalTypeName("PufferCollider"); break;
                    case "Celeste.QuickResetHint": definition.ConfigureLogicalTypeName("QuickResetHint"); break;
                    case "Celeste.Refill": definition.ConfigureLogicalTypeName("Refill"); break;
                    case "Celeste.ReflectionHeartStatue":
                        definition.ConfigureLogicalTypeName("ReflectionHeartStatue"); break;
                    case "Celeste.ReflectionHeartStatue.Torch": definition.ConfigureLogicalTypeName("Torch"); break;
                    case "Celeste.ReflectionTentacles":
                        definition.ConfigureLogicalTypeName("ReflectionTentacles"); break;
                    case "Celeste.ResortLantern": definition.ConfigureLogicalTypeName("ResortLantern"); break;
                    case "Celeste.ResortMirror": definition.ConfigureLogicalTypeName("ResortMirror"); break;
                    case "Celeste.ResortRoofEnding": definition.ConfigureLogicalTypeName("ResortRoofEnding"); break;
                    case "Celeste.RespawnTargetTrigger":
                        definition.ConfigureLogicalTypeName("RespawnTargetTrigger"); break;
                    case "Celeste.ReturnMapHint": definition.ConfigureLogicalTypeName("ReturnMapHint"); break;
                    case "Celeste.RidgeGate": definition.ConfigureLogicalTypeName("RidgeGate"); break;
                    case "Celeste.RisingLava": definition.ConfigureLogicalTypeName("RisingLava"); break;
                    case "Celeste.RotateSpinner": definition.ConfigureLogicalTypeName("RotateSpinner"); break;
                    case "Celeste.RotatingPlatform": definition.ConfigureLogicalTypeName("RotatingPlatform"); break;
                    case "Celeste.RumbleTrigger": definition.ConfigureLogicalTypeName("RumbleTrigger"); break;
                    case "Celeste.SafeGroundBlocker": definition.ConfigureLogicalTypeName("SafeGroundBlocker"); break;
                    case "Celeste.SandwichLava": definition.ConfigureLogicalTypeName("SandwichLava"); break;
                    case "Celeste.SaveLoadIcon": definition.ConfigureLogicalTypeName("SaveLoadIcon"); break;
                    case "Celeste.Seeker": definition.ConfigureLogicalTypeName("Seeker"); break;
                    case "Celeste.Seeker.RecoverBlast": definition.ConfigureLogicalTypeName("RecoverBlast"); break;
                    case "Celeste.SeekerBarrier": definition.ConfigureLogicalTypeName("SeekerBarrier"); break;
                    case "Celeste.SeekerBarrierRenderer":
                        definition.ConfigureLogicalTypeName("SeekerBarrierRenderer"); break;
                    case "Celeste.SeekerCollider": definition.ConfigureLogicalTypeName("SeekerCollider"); break;
                    case "Celeste.SeekerEffectsController":
                        definition.ConfigureLogicalTypeName("SeekerEffectsController"); break;
                    case "Celeste.SeekerStatue": definition.ConfigureLogicalTypeName("SeekerStatue"); break;
                    case "Celeste.Selfie": definition.ConfigureLogicalTypeName("Selfie"); break;
                    case "Celeste.SinkingPlatform": definition.ConfigureLogicalTypeName("SinkingPlatform"); break;
                    case "Celeste.SinkingPlatformLine":
                        definition.ConfigureLogicalTypeName("SinkingPlatformLine"); break;
                    case "Celeste.SlashFx": definition.ConfigureLogicalTypeName("SlashFx"); break;
                    case "Celeste.Slider": definition.ConfigureLogicalTypeName("Slider"); break;
                    case "Celeste.Snow3D": definition.ConfigureLogicalTypeName("Snow3D"); break;
                    case "Celeste.Snow3D.Particle": definition.ConfigureLogicalTypeName("Particle"); break;
                    case "Celeste.Snowball": definition.ConfigureLogicalTypeName("Snowball"); break;
                    case "Celeste.Solid": definition.ConfigureLogicalTypeName("Solid"); break;
                    case "Celeste.SolidOnInvinciblePlayer":
                        definition.ConfigureLogicalTypeName("SolidOnInvinciblePlayer"); break;
                    case "Celeste.SolidOnInvinciblePlayer.Outline":
                        definition.ConfigureLogicalTypeName("Outline"); break;
                    case "Celeste.SolidTiles": definition.ConfigureLogicalTypeName("SolidTiles"); break;
                    case "Celeste.SoundEmitter": definition.ConfigureLogicalTypeName("SoundEmitter"); break;
                    case "Celeste.SoundSource": definition.ConfigureLogicalTypeName("SoundSource"); break;
                    case "Celeste.SoundSourceEntity": definition.ConfigureLogicalTypeName("SoundSourceEntity"); break;
                    case "Celeste.SpaceController": definition.ConfigureLogicalTypeName("SpaceController"); break;
                    case "Celeste.SpawnFacingTrigger": definition.ConfigureLogicalTypeName("SpawnFacingTrigger"); break;
                    case "Celeste.SpeedRing": definition.ConfigureLogicalTypeName("SpeedRing"); break;
                    case "Celeste.SpeedrunTimerDisplay":
                        definition.ConfigureLogicalTypeName("SpeedrunTimerDisplay"); break;
                    case "Celeste.Spikes": definition.ConfigureLogicalTypeName("Spikes"); break;
                    case "Celeste.Spring": definition.ConfigureLogicalTypeName("Spring"); break;
                    case "Celeste.StaminaDisplay": definition.ConfigureLogicalTypeName("StaminaDisplay"); break;
                    case "Celeste.StarJumpBlock": definition.ConfigureLogicalTypeName("StarJumpBlock"); break;
                    case "Celeste.StarJumpController": definition.ConfigureLogicalTypeName("StarJumpController"); break;
                    case "Celeste.StarRotateSpinner": definition.ConfigureLogicalTypeName("StarRotateSpinner"); break;
                    case "Celeste.StarTrackSpinner": definition.ConfigureLogicalTypeName("StarTrackSpinner"); break;
                    case "Celeste.StaticMover": definition.ConfigureLogicalTypeName("StaticMover"); break;
                    case "Celeste.StopBoostTrigger": definition.ConfigureLogicalTypeName("StopBoostTrigger"); break;
                    case "Celeste.StrawberriesCounter":
                        definition.ConfigureLogicalTypeName("StrawberriesCounter"); break;
                    case "Celeste.Strawberry": definition.ConfigureLogicalTypeName("Strawberry"); break;
                    case "Celeste.StrawberryPoints": definition.ConfigureLogicalTypeName("StrawberryPoints"); break;
                    case "Celeste.StrawberrySeed": definition.ConfigureLogicalTypeName("StrawberrySeed"); break;
                    case "Celeste.SummitCheckpoint": definition.ConfigureLogicalTypeName("SummitCheckpoint"); break;
                    case "Celeste.SummitCheckpoint.ConfettiRenderer":
                        definition.ConfigureLogicalTypeName("ConfettiRenderer"); break;
                    case "Celeste.SummitCloud": definition.ConfigureLogicalTypeName("SummitCloud"); break;
                    case "Celeste.SummitGem": definition.ConfigureLogicalTypeName("SummitGem"); break;
                    case "Celeste.SummitGem.BgFlash": definition.ConfigureLogicalTypeName("BgFlash"); break;
                    case "Celeste.SummitGemManager": definition.ConfigureLogicalTypeName("SummitGemManager"); break;
                    case "Celeste.SummitGemManager.Gem": definition.ConfigureLogicalTypeName("Gem"); break;
                    case "Celeste.SwapBlock": definition.ConfigureLogicalTypeName("SwapBlock"); break;
                    case "Celeste.SwapBlock.PathRenderer": definition.ConfigureLogicalTypeName("PathRenderer"); break;
                    case "Celeste.Switch": definition.ConfigureLogicalTypeName("Switch"); break;
                    case "Celeste.SwitchGate": definition.ConfigureLogicalTypeName("SwitchGate"); break;
                    case "Celeste.TalkComponent": definition.ConfigureLogicalTypeName("TalkComponent"); break;
                    case "Celeste.TalkComponent.TalkComponentUI":
                        definition.ConfigureLogicalTypeName("TalkComponentUI"); break;
                    case "Celeste.TempleBigEyeball": definition.ConfigureLogicalTypeName("TempleBigEyeball"); break;
                    case "Celeste.TempleBigEyeball.Fader": definition.ConfigureLogicalTypeName("Fader"); break;
                    case "Celeste.TempleBigEyeballShockwave":
                        definition.ConfigureLogicalTypeName("TempleBigEyeballShockwave"); break;
                    case "Celeste.TempleCrackedBlock": definition.ConfigureLogicalTypeName("TempleCrackedBlock"); break;
                    case "Celeste.TempleEndingMusicHandler":
                        definition.ConfigureLogicalTypeName("TempleEndingMusicHandler"); break;
                    case "Celeste.TempleEye": definition.ConfigureLogicalTypeName("TempleEye"); break;
                    case "Celeste.TempleGate": definition.ConfigureLogicalTypeName("TempleGate"); break;
                    case "Celeste.TempleMirror": definition.ConfigureLogicalTypeName("TempleMirror"); break;
                    case "Celeste.TempleMirror.Frame": definition.ConfigureLogicalTypeName("Frame"); break;
                    case "Celeste.TempleMirrorPortal": definition.ConfigureLogicalTypeName("TempleMirrorPortal"); break;
                    case "Celeste.TempleMirrorPortal.Bg": definition.ConfigureLogicalTypeName("Bg"); break;
                    case "Celeste.TempleMirrorPortal.Curtain": definition.ConfigureLogicalTypeName("Curtain"); break;
                    case "Celeste.TemplePortalTorch": definition.ConfigureLogicalTypeName("TemplePortalTorch"); break;
                    case "Celeste.TextMenu": definition.ConfigureLogicalTypeName("TextMenu"); break;
                    case "Celeste.Textbox": definition.ConfigureLogicalTypeName("Textbox"); break;
                    case "Celeste.TheoCrystal": definition.ConfigureLogicalTypeName("TheoCrystal"); break;
                    case "Celeste.TheoCrystalPedestal":
                        definition.ConfigureLogicalTypeName("TheoCrystalPedestal"); break;
                    case "Celeste.TheoPhone": definition.ConfigureLogicalTypeName("TheoPhone"); break;
                    case "Celeste.TileInterceptor": definition.ConfigureLogicalTypeName("TileInterceptor"); break;
                    case "Celeste.Torch": definition.ConfigureLogicalTypeName("Torch"); break;
                    case "Celeste.TotalStrawberriesDisplay":
                        definition.ConfigureLogicalTypeName("TotalStrawberriesDisplay"); break;
                    case "Celeste.TouchSwitch": definition.ConfigureLogicalTypeName("TouchSwitch"); break;
                    case "Celeste.TrackSpinner": definition.ConfigureLogicalTypeName("TrackSpinner"); break;
                    case "Celeste.TrailManager": definition.ConfigureLogicalTypeName("TrailManager"); break;
                    case "Celeste.TrailManager.Snapshot": definition.ConfigureLogicalTypeName("Snapshot"); break;
                    case "Celeste.TransitionListener": definition.ConfigureLogicalTypeName("TransitionListener"); break;
                    case "Celeste.Trapdoor": definition.ConfigureLogicalTypeName("Trapdoor"); break;
                    case "Celeste.Trigger": definition.ConfigureLogicalTypeName("Trigger"); break;
                    case "Celeste.TriggerSpikes": definition.ConfigureLogicalTypeName("TriggerSpikes"); break;
                    case "Celeste.UnlockEverythingThingy":
                        definition.ConfigureLogicalTypeName("UnlockEverythingThingy"); break;
                    case "Celeste.UnlockedPico8Message":
                        definition.ConfigureLogicalTypeName("UnlockedPico8Message"); break;
                    case "Celeste.UnlockedRemixDisplay":
                        definition.ConfigureLogicalTypeName("UnlockedRemixDisplay"); break;
                    case "Celeste.VertexLight": definition.ConfigureLogicalTypeName("VertexLight"); break;
                    case "Celeste.ViewportAdjustmentUI":
                        definition.ConfigureLogicalTypeName("ViewportAdjustmentUI"); break;
                    case "Celeste.WallBooster": definition.ConfigureLogicalTypeName("WallBooster"); break;
                    case "Celeste.Water": definition.ConfigureLogicalTypeName("Water"); break;
                    case "Celeste.WaterFall": definition.ConfigureLogicalTypeName("WaterFall"); break;
                    case "Celeste.WaterInteraction": definition.ConfigureLogicalTypeName("WaterInteraction"); break;
                    case "Celeste.WaterSurface": definition.ConfigureLogicalTypeName("WaterSurface"); break;
                    case "Celeste.WaveDashPresentation":
                        definition.ConfigureLogicalTypeName("WaveDashPresentation"); break;
                    case "Celeste.WaveDashTutorialMachine":
                        definition.ConfigureLogicalTypeName("WaveDashTutorialMachine"); break;
                    case "Celeste.WhiteBlock": definition.ConfigureLogicalTypeName("WhiteBlock"); break;
                    case "Celeste.WindAttackTrigger": definition.ConfigureLogicalTypeName("WindAttackTrigger"); break;
                    case "Celeste.WindController": definition.ConfigureLogicalTypeName("WindController"); break;
                    case "Celeste.WindMover": definition.ConfigureLogicalTypeName("WindMover"); break;
                    case "Celeste.WindTrigger": definition.ConfigureLogicalTypeName("WindTrigger"); break;
                    case "Celeste.Wire": definition.ConfigureLogicalTypeName("Wire"); break;
                    case "Celeste.ZipMover": definition.ConfigureLogicalTypeName("ZipMover"); break;
                    case "Celeste.ZipMover.ZipMoverPathRenderer":
                        definition.ConfigureLogicalTypeName("ZipMoverPathRenderer"); break;
                    case "Celeste._3dSoundTest": definition.ConfigureLogicalTypeName("_3dSoundTest"); break;
                    case "Monocle.Alarm": definition.ConfigureLogicalTypeName("Alarm"); break;
                    case "Monocle.CheatListener": definition.ConfigureLogicalTypeName("CheatListener"); break;
                    case "Monocle.Component": definition.ConfigureLogicalTypeName("Component"); break;
                    case "Monocle.Coroutine": definition.ConfigureLogicalTypeName("Coroutine"); break;
                    case "Monocle.CoroutineHolder": definition.ConfigureLogicalTypeName("CoroutineHolder"); break;
                    case "Monocle.CounterSet`1": definition.ConfigureLogicalTypeName("CounterSet`1"); break;
                    case var entityRuntimeName
                        when entityRuntimeName == typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName:
                        definition.ConfigureLogicalTypeName("Entity"); break;
                    case "Monocle.GraphicsComponent": definition.ConfigureLogicalTypeName("GraphicsComponent"); break;
                    case "Monocle.Image": definition.ConfigureLogicalTypeName("Image"); break;
                    case "Monocle.NumberText": definition.ConfigureLogicalTypeName("NumberText"); break;
                    case "Monocle.OutlineText": definition.ConfigureLogicalTypeName("OutlineText"); break;
                    case "Monocle.ParticleEmitter": definition.ConfigureLogicalTypeName("ParticleEmitter"); break;
                    case "Monocle.ParticleSystem": definition.ConfigureLogicalTypeName("ParticleSystem"); break;
                    case "Monocle.PixelText": definition.ConfigureLogicalTypeName("PixelText"); break;
                    case "Monocle.Shaker": definition.ConfigureLogicalTypeName("Shaker"); break;
                    case "Monocle.ShakerList": definition.ConfigureLogicalTypeName("ShakerList"); break;
                    case "Monocle.SineWave": definition.ConfigureLogicalTypeName("SineWave"); break;
                    case "Monocle.SpecEntity`1": definition.ConfigureLogicalTypeName("SpecEntity`1"); break;
                    case "Monocle.Sprite": definition.ConfigureLogicalTypeName("Sprite"); break;
                    case "Monocle.Spritesheet`1": definition.ConfigureLogicalTypeName("Spritesheet`1"); break;
                    case "Monocle.StateMachine": definition.ConfigureLogicalTypeName("StateMachine"); break;
                    case "Monocle.Text": definition.ConfigureLogicalTypeName("Text"); break;
                    case "Monocle.TileGrid": definition.ConfigureLogicalTypeName("TileGrid"); break;
                    case "Monocle.TimerText": definition.ConfigureLogicalTypeName("TimerText"); break;
                    case "Monocle.Tween": definition.ConfigureLogicalTypeName("Tween"); break;
                    case "Monocle.Wiggler": definition.ConfigureLogicalTypeName("Wiggler"); break;
                }
            }
        }

        public static void ConfigureInstalled(SceneEntityCatalog catalog)
        {
            foreach (var definition in catalog.Types)
            {
                switch (definition.Name)
                {
                    case "Celeste.AbsorbOrb": definition.ConfigureLogicalTypeName("AbsorbOrb"); break;
                    case var actorRuntimeName
                        when actorRuntimeName ==
                             typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState)
                                 .FullName:
                        definition.ConfigureLogicalTypeName("Actor"); break;
                    case "Celeste.AltMusicTrigger": definition.ConfigureLogicalTypeName("AltMusicTrigger"); break;
                    case "Celeste.AmbienceParamTrigger":
                        definition.ConfigureLogicalTypeName("AmbienceParamTrigger"); break;
                    case "Celeste.AngryOshiro": definition.ConfigureLogicalTypeName("AngryOshiro"); break;
                    case "Celeste.AnimatedTiles": definition.ConfigureLogicalTypeName("AnimatedTiles"); break;
                    case "Celeste.AreaCompleteTitle": definition.ConfigureLogicalTypeName("AreaCompleteTitle"); break;
                    case "Celeste.AscendManager": definition.ConfigureLogicalTypeName("AscendManager"); break;
                    case "Celeste.AscendManager.Clouds": definition.ConfigureLogicalTypeName("Clouds"); break;
                    case "Celeste.AscendManager.Fader": definition.ConfigureLogicalTypeName("Fader"); break;
                    case "Celeste.AscendManager.Streaks": definition.ConfigureLogicalTypeName("Streaks"); break;
                    case "Celeste.BackgroundFadeIn": definition.ConfigureLogicalTypeName("BackgroundFadeIn"); break;
                    case "Celeste.BackgroundTiles": definition.ConfigureLogicalTypeName("BackgroundTiles"); break;
                    case "Celeste.BadelineAutoAnimator":
                        definition.ConfigureLogicalTypeName("BadelineAutoAnimator"); break;
                    case "Celeste.BadelineBoost": definition.ConfigureLogicalTypeName("BadelineBoost"); break;
                    case "Celeste.BadelineDummy": definition.ConfigureLogicalTypeName("BadelineDummy"); break;
                    case "Celeste.BadelineOldsite": definition.ConfigureLogicalTypeName("BadelineOldsite"); break;
                    case "Celeste.BeforeRenderHook": definition.ConfigureLogicalTypeName("BeforeRenderHook"); break;
                    case "Celeste.BestTimeDisplay": definition.ConfigureLogicalTypeName("BestTimeDisplay"); break;
                    case "Celeste.BigWaterfall": definition.ConfigureLogicalTypeName("BigWaterfall"); break;
                    case "Celeste.Billboard": definition.ConfigureLogicalTypeName("Billboard"); break;
                    case "Celeste.BirdNPC": definition.ConfigureLogicalTypeName("BirdNPC"); break;
                    case "Celeste.BirdPath": definition.ConfigureLogicalTypeName("BirdPath"); break;
                    case "Celeste.BirdPathTrigger": definition.ConfigureLogicalTypeName("BirdPathTrigger"); break;
                    case "Celeste.BirdTutorialGui": definition.ConfigureLogicalTypeName("BirdTutorialGui"); break;
                    case "Celeste.BlackholeStrengthTrigger":
                        definition.ConfigureLogicalTypeName("BlackholeStrengthTrigger"); break;
                    case "Celeste.BladeRotateSpinner": definition.ConfigureLogicalTypeName("BladeRotateSpinner"); break;
                    case "Celeste.BladeTrackSpinner": definition.ConfigureLogicalTypeName("BladeTrackSpinner"); break;
                    case "Celeste.BlockField": definition.ConfigureLogicalTypeName("BlockField"); break;
                    case "Celeste.BloomFadeTrigger": definition.ConfigureLogicalTypeName("BloomFadeTrigger"); break;
                    case "Celeste.BloomPoint": definition.ConfigureLogicalTypeName("BloomPoint"); break;
                    case "Celeste.Bonfire": definition.ConfigureLogicalTypeName("Bonfire"); break;
                    case "Celeste.Booster": definition.ConfigureLogicalTypeName("Booster"); break;
                    case "Celeste.BounceBlock": definition.ConfigureLogicalTypeName("BounceBlock"); break;
                    case "Celeste.BounceBlock.BreakDebris": definition.ConfigureLogicalTypeName("BreakDebris"); break;
                    case "Celeste.BounceBlock.RespawnDebris":
                        definition.ConfigureLogicalTypeName("RespawnDebris"); break;
                    case "Celeste.BreathingMinigame": definition.ConfigureLogicalTypeName("BreathingMinigame"); break;
                    case "Celeste.BreathingRumbler": definition.ConfigureLogicalTypeName("BreathingRumbler"); break;
                    case "Celeste.Bridge": definition.ConfigureLogicalTypeName("Bridge"); break;
                    case "Celeste.BridgeFixed": definition.ConfigureLogicalTypeName("BridgeFixed"); break;
                    case "Celeste.BridgeTile": definition.ConfigureLogicalTypeName("BridgeTile"); break;
                    case "Celeste.Bumper": definition.ConfigureLogicalTypeName("Bumper"); break;
                    case "Celeste.ButtonConfigUI": definition.ConfigureLogicalTypeName("ButtonConfigUI"); break;
                    case "Celeste.CS00_Ending": definition.ConfigureLogicalTypeName("CS00_Ending"); break;
                    case "Celeste.CS00_Ending.EndingCutsceneDelay":
                        definition.ConfigureLogicalTypeName("EndingCutsceneDelay"); break;
                    case "Celeste.CS00_Granny": definition.ConfigureLogicalTypeName("CS00_Granny"); break;
                    case "Celeste.CS01_Ending": definition.ConfigureLogicalTypeName("CS01_Ending"); break;
                    case "Celeste.CS02_BadelineIntro": definition.ConfigureLogicalTypeName("CS02_BadelineIntro"); break;
                    case "Celeste.CS02_DreamingPhonecall":
                        definition.ConfigureLogicalTypeName("CS02_DreamingPhonecall"); break;
                    case "Celeste.CS02_Ending": definition.ConfigureLogicalTypeName("CS02_Ending"); break;
                    case "Celeste.CS02_Journal": definition.ConfigureLogicalTypeName("CS02_Journal"); break;
                    case "Celeste.CS02_Journal.PoemPage": definition.ConfigureLogicalTypeName("PoemPage"); break;
                    case "Celeste.CS02_Mirror": definition.ConfigureLogicalTypeName("CS02_Mirror"); break;
                    case "Celeste.CS03_Diary": definition.ConfigureLogicalTypeName("CS03_Diary"); break;
                    case "Celeste.CS03_Ending": definition.ConfigureLogicalTypeName("CS03_Ending"); break;
                    case "Celeste.CS03_Ending.BgFlash": definition.ConfigureLogicalTypeName("BgFlash"); break;
                    case "Celeste.CS03_Guestbook": definition.ConfigureLogicalTypeName("CS03_Guestbook"); break;
                    case "Celeste.CS03_Memo": definition.ConfigureLogicalTypeName("CS03_Memo"); break;
                    case "Celeste.CS03_Memo.MemoPage": definition.ConfigureLogicalTypeName("MemoPage"); break;
                    case "Celeste.CS03_OshiroBreakdown":
                        definition.ConfigureLogicalTypeName("CS03_OshiroBreakdown"); break;
                    case "Celeste.CS03_OshiroClutter": definition.ConfigureLogicalTypeName("CS03_OshiroClutter"); break;
                    case "Celeste.CS03_OshiroHallway1":
                        definition.ConfigureLogicalTypeName("CS03_OshiroHallway1"); break;
                    case "Celeste.CS03_OshiroHallway2":
                        definition.ConfigureLogicalTypeName("CS03_OshiroHallway2"); break;
                    case "Celeste.CS03_OshiroLobby": definition.ConfigureLogicalTypeName("CS03_OshiroLobby"); break;
                    case "Celeste.CS03_OshiroMasterSuite":
                        definition.ConfigureLogicalTypeName("CS03_OshiroMasterSuite"); break;
                    case "Celeste.CS03_OshiroRooftop": definition.ConfigureLogicalTypeName("CS03_OshiroRooftop"); break;
                    case "Celeste.CS03_TheoEscape": definition.ConfigureLogicalTypeName("CS03_TheoEscape"); break;
                    case "Celeste.CS04_Gondola": definition.ConfigureLogicalTypeName("CS04_Gondola"); break;
                    case "Celeste.CS04_Granny": definition.ConfigureLogicalTypeName("CS04_Granny"); break;
                    case "Celeste.CS04_MirrorPortal": definition.ConfigureLogicalTypeName("CS04_MirrorPortal"); break;
                    case "Celeste.CS04_MirrorPortal.Fader": definition.ConfigureLogicalTypeName("Fader"); break;
                    case "Celeste.CS05_Badeline": definition.ConfigureLogicalTypeName("CS05_Badeline"); break;
                    case "Celeste.CS05_Entrance": definition.ConfigureLogicalTypeName("CS05_Entrance"); break;
                    case "Celeste.CS05_Reflection1": definition.ConfigureLogicalTypeName("CS05_Reflection1"); break;
                    case "Celeste.CS05_SaveTheo": definition.ConfigureLogicalTypeName("CS05_SaveTheo"); break;
                    case "Celeste.CS05_SeeTheo": definition.ConfigureLogicalTypeName("CS05_SeeTheo"); break;
                    case "Celeste.CS05_TheoInMirror": definition.ConfigureLogicalTypeName("CS05_TheoInMirror"); break;
                    case "Celeste.CS05_TheoPhone": definition.ConfigureLogicalTypeName("CS05_TheoPhone"); break;
                    case "Celeste.CS06_BossEnd": definition.ConfigureLogicalTypeName("CS06_BossEnd"); break;
                    case "Celeste.CS06_BossIntro": definition.ConfigureLogicalTypeName("CS06_BossIntro"); break;
                    case "Celeste.CS06_BossMid": definition.ConfigureLogicalTypeName("CS06_BossMid"); break;
                    case "Celeste.CS06_Campfire": definition.ConfigureLogicalTypeName("CS06_Campfire"); break;
                    case "Celeste.CS06_Ending": definition.ConfigureLogicalTypeName("CS06_Ending"); break;
                    case "Celeste.CS06_Granny": definition.ConfigureLogicalTypeName("CS06_Granny"); break;
                    case "Celeste.CS06_Reflection": definition.ConfigureLogicalTypeName("CS06_Reflection"); break;
                    case "Celeste.CS06_StarJumpEnd": definition.ConfigureLogicalTypeName("CS06_StarJumpEnd"); break;
                    case "Celeste.CS07_Ascend": definition.ConfigureLogicalTypeName("CS07_Ascend"); break;
                    case "Celeste.CS07_Credits": definition.ConfigureLogicalTypeName("CS07_Credits"); break;
                    case "Celeste.CS07_Ending": definition.ConfigureLogicalTypeName("CS07_Ending"); break;
                    case "Celeste.CS08_Ending": definition.ConfigureLogicalTypeName("CS08_Ending"); break;
                    case "Celeste.CS08_Ending.TimeDisplay": definition.ConfigureLogicalTypeName("TimeDisplay"); break;
                    case "Celeste.CS08_EnterDoor": definition.ConfigureLogicalTypeName("CS08_EnterDoor"); break;
                    case "Celeste.CS10_BadelineHelps": definition.ConfigureLogicalTypeName("CS10_BadelineHelps"); break;
                    case "Celeste.CS10_CatchTheBird": definition.ConfigureLogicalTypeName("CS10_CatchTheBird"); break;
                    case "Celeste.CS10_Ending": definition.ConfigureLogicalTypeName("CS10_Ending"); break;
                    case "Celeste.CS10_Farewell": definition.ConfigureLogicalTypeName("CS10_Farewell"); break;
                    case "Celeste.CS10_FinalLaunch": definition.ConfigureLogicalTypeName("CS10_FinalLaunch"); break;
                    case "Celeste.CS10_FinalRoom": definition.ConfigureLogicalTypeName("CS10_FinalRoom"); break;
                    case "Celeste.CS10_FreeBird": definition.ConfigureLogicalTypeName("CS10_FreeBird"); break;
                    case "Celeste.CS10_Gravestone": definition.ConfigureLogicalTypeName("CS10_Gravestone"); break;
                    case "Celeste.CS10_HubIntro": definition.ConfigureLogicalTypeName("CS10_HubIntro"); break;
                    case "Celeste.CS10_HubIntro.Bird": definition.ConfigureLogicalTypeName("Bird"); break;
                    case "Celeste.CS10_MissTheBird": definition.ConfigureLogicalTypeName("CS10_MissTheBird"); break;
                    case "Celeste.CS10_MoonIntro": definition.ConfigureLogicalTypeName("CS10_MoonIntro"); break;
                    case "Celeste.CSGEN_StrawberrySeeds":
                        definition.ConfigureLogicalTypeName("CSGEN_StrawberrySeeds"); break;
                    case "Celeste.CameraAdvanceTargetTrigger":
                        definition.ConfigureLogicalTypeName("CameraAdvanceTargetTrigger"); break;
                    case "Celeste.CameraLocker": definition.ConfigureLogicalTypeName("CameraLocker"); break;
                    case "Celeste.CameraOffsetTrigger":
                        definition.ConfigureLogicalTypeName("CameraOffsetTrigger"); break;
                    case "Celeste.CameraTargetTrigger":
                        definition.ConfigureLogicalTypeName("CameraTargetTrigger"); break;
                    case "Celeste.Cassette": definition.ConfigureLogicalTypeName("Cassette"); break;
                    case "Celeste.Cassette.UnlockedBSide": definition.ConfigureLogicalTypeName("UnlockedBSide"); break;
                    case "Celeste.CassetteBlock": definition.ConfigureLogicalTypeName("CassetteBlock"); break;
                    case "Celeste.CassetteBlock.BoxSide": definition.ConfigureLogicalTypeName("BoxSide"); break;
                    case "Celeste.CassetteBlockManager":
                        definition.ConfigureLogicalTypeName("CassetteBlockManager"); break;
                    case "Celeste.ChangeRespawnTrigger":
                        definition.ConfigureLogicalTypeName("ChangeRespawnTrigger"); break;
                    case "Celeste.ChaserBarrier": definition.ConfigureLogicalTypeName("ChaserBarrier"); break;
                    case "Celeste.Checkpoint": definition.ConfigureLogicalTypeName("Checkpoint"); break;
                    case "Celeste.CheckpointBlockerTrigger":
                        definition.ConfigureLogicalTypeName("CheckpointBlockerTrigger"); break;
                    case "Celeste.CliffFlags": definition.ConfigureLogicalTypeName("CliffFlags"); break;
                    case "Celeste.CliffsideWindFlag": definition.ConfigureLogicalTypeName("CliffsideWindFlag"); break;
                    case "Celeste.ClimbBlocker": definition.ConfigureLogicalTypeName("ClimbBlocker"); break;
                    case "Celeste.Clothesline": definition.ConfigureLogicalTypeName("Clothesline"); break;
                    case "Celeste.Cloud": definition.ConfigureLogicalTypeName("Cloud"); break;
                    case "Celeste.ClutterAbsorbEffect":
                        definition.ConfigureLogicalTypeName("ClutterAbsorbEffect"); break;
                    case "Celeste.ClutterBlock": definition.ConfigureLogicalTypeName("ClutterBlock"); break;
                    case "Celeste.ClutterBlockBase": definition.ConfigureLogicalTypeName("ClutterBlockBase"); break;
                    case "Celeste.ClutterCabinet": definition.ConfigureLogicalTypeName("ClutterCabinet"); break;
                    case "Celeste.ClutterDoor": definition.ConfigureLogicalTypeName("ClutterDoor"); break;
                    case "Celeste.ClutterSwitch": definition.ConfigureLogicalTypeName("ClutterSwitch"); break;
                    case "Celeste.Cobweb": definition.ConfigureLogicalTypeName("Cobweb"); break;
                    case "Celeste.CoreMessage": definition.ConfigureLogicalTypeName("CoreMessage"); break;
                    case "Celeste.CoreModeListener": definition.ConfigureLogicalTypeName("CoreModeListener"); break;
                    case "Celeste.CoreModeToggle": definition.ConfigureLogicalTypeName("CoreModeToggle"); break;
                    case "Celeste.CoverupWall": definition.ConfigureLogicalTypeName("CoverupWall"); break;
                    case "Celeste.CreditsTrigger": definition.ConfigureLogicalTypeName("CreditsTrigger"); break;
                    case "Celeste.CrumblePlatform": definition.ConfigureLogicalTypeName("CrumblePlatform"); break;
                    case "Celeste.CrumbleWallOnRumble":
                        definition.ConfigureLogicalTypeName("CrumbleWallOnRumble"); break;
                    case "Celeste.CrushBlock": definition.ConfigureLogicalTypeName("CrushBlock"); break;
                    case "Celeste.CrystalDebris": definition.ConfigureLogicalTypeName("CrystalDebris"); break;
                    case "Celeste.CrystalStaticSpinner":
                        definition.ConfigureLogicalTypeName("CrystalStaticSpinner"); break;
                    case "Celeste.CrystalStaticSpinner.Border": definition.ConfigureLogicalTypeName("Border"); break;
                    case "Celeste.CrystalStaticSpinner.CoreModeListener":
                        definition.ConfigureLogicalTypeName("CoreModeListener"); break;
                    case "Celeste.CustomBloom": definition.ConfigureLogicalTypeName("CustomBloom"); break;
                    case "Celeste.CutsceneEntity": definition.ConfigureLogicalTypeName("CutsceneEntity"); break;
                    case "Celeste.CutsceneNode": definition.ConfigureLogicalTypeName("CutsceneNode"); break;
                    case "Celeste.DashBlock": definition.ConfigureLogicalTypeName("DashBlock"); break;
                    case "Celeste.DashListener": definition.ConfigureLogicalTypeName("DashListener"); break;
                    case "Celeste.DashSwitch": definition.ConfigureLogicalTypeName("DashSwitch"); break;
                    case "Celeste.DeathEffect": definition.ConfigureLogicalTypeName("DeathEffect"); break;
                    case "Celeste.DeathsCounter": definition.ConfigureLogicalTypeName("DeathsCounter"); break;
                    case "Celeste.Debris": definition.ConfigureLogicalTypeName("Debris"); break;
                    case "Celeste.Decal": definition.ConfigureLogicalTypeName("Decal"); break;
                    case "Celeste.Decal.Banner": definition.ConfigureLogicalTypeName("Banner"); break;
                    case "Celeste.Decal.CoreSwapImage": definition.ConfigureLogicalTypeName("CoreSwapImage"); break;
                    case "Celeste.Decal.DecalImage": definition.ConfigureLogicalTypeName("DecalImage"); break;
                    case "Celeste.Decal.FinalFlagDecalImage":
                        definition.ConfigureLogicalTypeName("FinalFlagDecalImage"); break;
                    case "Celeste.Decal.FlagSwapImage": definition.ConfigureLogicalTypeName("FlagSwapImage"); break;
                    case "Celeste.DetachStrawberryTrigger":
                        definition.ConfigureLogicalTypeName("DetachStrawberryTrigger"); break;
                    case "Celeste.DisperseImage": definition.ConfigureLogicalTypeName("DisperseImage"); break;
                    case "Celeste.DisplacementRenderHook":
                        definition.ConfigureLogicalTypeName("DisplacementRenderHook"); break;
                    case "Celeste.Door": definition.ConfigureLogicalTypeName("Door"); break;
                    case "Celeste.DreamBlock": definition.ConfigureLogicalTypeName("DreamBlock"); break;
                    case "Celeste.DreamHeartGem": definition.ConfigureLogicalTypeName("DreamHeartGem"); break;
                    case "Celeste.DreamMirror": definition.ConfigureLogicalTypeName("DreamMirror"); break;
                    case "Celeste.DustEdge": definition.ConfigureLogicalTypeName("DustEdge"); break;
                    case "Celeste.DustEdges": definition.ConfigureLogicalTypeName("DustEdges"); break;
                    case "Celeste.DustGraphic": definition.ConfigureLogicalTypeName("DustGraphic"); break;
                    case "Celeste.DustGraphic.Eyeballs": definition.ConfigureLogicalTypeName("Eyeballs"); break;
                    case "Celeste.DustRotateSpinner": definition.ConfigureLogicalTypeName("DustRotateSpinner"); break;
                    case "Celeste.DustStaticSpinner": definition.ConfigureLogicalTypeName("DustStaticSpinner"); break;
                    case "Celeste.DustTrackSpinner": definition.ConfigureLogicalTypeName("DustTrackSpinner"); break;
                    case "Celeste.EffectCutout": definition.ConfigureLogicalTypeName("EffectCutout"); break;
                    case "Celeste.EventTrigger": definition.ConfigureLogicalTypeName("EventTrigger"); break;
                    case "Celeste.ExitBlock": definition.ConfigureLogicalTypeName("ExitBlock"); break;
                    case "Celeste.FakeHeart": definition.ConfigureLogicalTypeName("FakeHeart"); break;
                    case "Celeste.FakeWall": definition.ConfigureLogicalTypeName("FakeWall"); break;
                    case "Celeste.FallEffects": definition.ConfigureLogicalTypeName("FallEffects"); break;
                    case "Celeste.FallingBlock": definition.ConfigureLogicalTypeName("FallingBlock"); break;
                    case "Celeste.FileErrorOverlay": definition.ConfigureLogicalTypeName("FileErrorOverlay"); break;
                    case "Celeste.FinalBoss": definition.ConfigureLogicalTypeName("FinalBoss"); break;
                    case "Celeste.FinalBossBeam": definition.ConfigureLogicalTypeName("FinalBossBeam"); break;
                    case "Celeste.FinalBossMovingBlock":
                        definition.ConfigureLogicalTypeName("FinalBossMovingBlock"); break;
                    case "Celeste.FinalBossShot": definition.ConfigureLogicalTypeName("FinalBossShot"); break;
                    case "Celeste.FireBall": definition.ConfigureLogicalTypeName("FireBall"); break;
                    case "Celeste.FireBarrier": definition.ConfigureLogicalTypeName("FireBarrier"); break;
                    case "Celeste.Flagline": definition.ConfigureLogicalTypeName("Flagline"); break;
                    case "Celeste.FlingBird": definition.ConfigureLogicalTypeName("FlingBird"); break;
                    case "Celeste.FlingBirdIntro": definition.ConfigureLogicalTypeName("FlingBirdIntro"); break;
                    case "Celeste.FloatingDebris": definition.ConfigureLogicalTypeName("FloatingDebris"); break;
                    case "Celeste.FloatySpaceBlock": definition.ConfigureLogicalTypeName("FloatySpaceBlock"); break;
                    case "Celeste.FlutterBird": definition.ConfigureLogicalTypeName("FlutterBird"); break;
                    case "Celeste.FlyFeather": definition.ConfigureLogicalTypeName("FlyFeather"); break;
                    case "Celeste.Follower": definition.ConfigureLogicalTypeName("Follower"); break;
                    case "Celeste.ForegroundDebris": definition.ConfigureLogicalTypeName("ForegroundDebris"); break;
                    case "Celeste.FormationBackdrop": definition.ConfigureLogicalTypeName("FormationBackdrop"); break;
                    case "Celeste.ForsakenCitySatellite":
                        definition.ConfigureLogicalTypeName("ForsakenCitySatellite"); break;
                    case "Celeste.ForsakenCitySatellite.CodeBird":
                        definition.ConfigureLogicalTypeName("CodeBird"); break;
                    case "Celeste.GameplayStats": definition.ConfigureLogicalTypeName("GameplayStats"); break;
                    case "Celeste.GlassBlock": definition.ConfigureLogicalTypeName("GlassBlock"); break;
                    case "Celeste.GlassBlockBg": definition.ConfigureLogicalTypeName("GlassBlockBg"); break;
                    case "Celeste.Glider": definition.ConfigureLogicalTypeName("Glider"); break;
                    case "Celeste.GoldBerryCollectTrigger":
                        definition.ConfigureLogicalTypeName("GoldBerryCollectTrigger"); break;
                    case "Celeste.GoldenBlock": definition.ConfigureLogicalTypeName("GoldenBlock"); break;
                    case "Celeste.Gondola": definition.ConfigureLogicalTypeName("Gondola"); break;
                    case "Celeste.Gondola.Rope": definition.ConfigureLogicalTypeName("Rope"); break;
                    case "Celeste.GondolaDarkness": definition.ConfigureLogicalTypeName("GondolaDarkness"); break;
                    case "Celeste.GondolaDarkness.Blackness": definition.ConfigureLogicalTypeName("Blackness"); break;
                    case "Celeste.GrabbyIcon": definition.ConfigureLogicalTypeName("GrabbyIcon"); break;
                    case "Celeste.GrannyLaughSfx": definition.ConfigureLogicalTypeName("GrannyLaughSfx"); break;
                    case "Celeste.Hahaha": definition.ConfigureLogicalTypeName("Hahaha"); break;
                    case "Celeste.HangingLamp": definition.ConfigureLogicalTypeName("HangingLamp"); break;
                    case "Celeste.HeartGem": definition.ConfigureLogicalTypeName("HeartGem"); break;
                    case "Celeste.HeartGemDisplay": definition.ConfigureLogicalTypeName("HeartGemDisplay"); break;
                    case "Celeste.HeartGemDoor": definition.ConfigureLogicalTypeName("HeartGemDoor"); break;
                    case "Celeste.HeartGemDoor.WhiteLine": definition.ConfigureLogicalTypeName("WhiteLine"); break;
                    case "Celeste.HeightDisplay": definition.ConfigureLogicalTypeName("HeightDisplay"); break;
                    case "Celeste.Holdable": definition.ConfigureLogicalTypeName("Holdable"); break;
                    case "Celeste.HoldableCollider": definition.ConfigureLogicalTypeName("HoldableCollider"); break;
                    case "Celeste.IceBlock": definition.ConfigureLogicalTypeName("IceBlock"); break;
                    case "Celeste.IceTileOverlay": definition.ConfigureLogicalTypeName("IceTileOverlay"); break;
                    case "Celeste.InteractTrigger": definition.ConfigureLogicalTypeName("InteractTrigger"); break;
                    case "Celeste.IntroCar": definition.ConfigureLogicalTypeName("IntroCar"); break;
                    case "Celeste.IntroCarBarrier": definition.ConfigureLogicalTypeName("IntroCarBarrier"); break;
                    case "Celeste.IntroCrusher": definition.ConfigureLogicalTypeName("IntroCrusher"); break;
                    case "Celeste.IntroPavement": definition.ConfigureLogicalTypeName("IntroPavement"); break;
                    case "Celeste.InvisibleBarrier": definition.ConfigureLogicalTypeName("InvisibleBarrier"); break;
                    case "Celeste.JumpThru": definition.ConfigureLogicalTypeName("JumpThru"); break;
                    case "Celeste.JumpthruPlatform": definition.ConfigureLogicalTypeName("JumpthruPlatform"); break;
                    case "Celeste.KevinsPC": definition.ConfigureLogicalTypeName("KevinsPC"); break;
                    case "Celeste.Key": definition.ConfigureLogicalTypeName("Key"); break;
                    case "Celeste.KeyboardConfigUI": definition.ConfigureLogicalTypeName("KeyboardConfigUI"); break;
                    case "Celeste.Killbox": definition.ConfigureLogicalTypeName("Killbox"); break;
                    case "Celeste.Lamp": definition.ConfigureLogicalTypeName("Lamp"); break;
                    case "Celeste.LanguageSelectUI": definition.ConfigureLogicalTypeName("LanguageSelectUI"); break;
                    case "Celeste.LavaRect": definition.ConfigureLogicalTypeName("LavaRect"); break;
                    case "Celeste.Leader": definition.ConfigureLogicalTypeName("Leader"); break;
                    case "Celeste.LedgeBlocker": definition.ConfigureLogicalTypeName("LedgeBlocker"); break;
                    case "Celeste.LevelEndingHook": definition.ConfigureLogicalTypeName("LevelEndingHook"); break;
                    case "Celeste.LevelEnter.BSideTitle": definition.ConfigureLogicalTypeName("BSideTitle"); break;
                    case "Celeste.LevelUpEffect": definition.ConfigureLogicalTypeName("LevelUpEffect"); break;
                    case "Celeste.LightBeam": definition.ConfigureLogicalTypeName("LightBeam"); break;
                    case "Celeste.LightFadeTrigger": definition.ConfigureLogicalTypeName("LightFadeTrigger"); break;
                    case "Celeste.LightOcclude": definition.ConfigureLogicalTypeName("LightOcclude"); break;
                    case "Celeste.Lightning": definition.ConfigureLogicalTypeName("Lightning"); break;
                    case "Celeste.LightningBreakerBox":
                        definition.ConfigureLogicalTypeName("LightningBreakerBox"); break;
                    case "Celeste.LightningRenderer": definition.ConfigureLogicalTypeName("LightningRenderer"); break;
                    case "Celeste.LightningStrike": definition.ConfigureLogicalTypeName("LightningStrike"); break;
                    case "Celeste.LockBlock": definition.ConfigureLogicalTypeName("LockBlock"); break;
                    case "Celeste.Lookout": definition.ConfigureLogicalTypeName("Lookout"); break;
                    case "Celeste.Lookout.Hud": definition.ConfigureLogicalTypeName("Hud"); break;
                    case "Celeste.LookoutBlocker": definition.ConfigureLogicalTypeName("LookoutBlocker"); break;
                    case "Celeste.Maddy3D": definition.ConfigureLogicalTypeName("Maddy3D"); break;
                    case "Celeste.MainMenuClimb": definition.ConfigureLogicalTypeName("MainMenuClimb"); break;
                    case "Celeste.MainMenuSmallButton":
                        definition.ConfigureLogicalTypeName("MainMenuSmallButton"); break;
                    case "Celeste.Memorial": definition.ConfigureLogicalTypeName("Memorial"); break;
                    case "Celeste.MemorialText": definition.ConfigureLogicalTypeName("MemorialText"); break;
                    case "Celeste.MenuButton": definition.ConfigureLogicalTypeName("MenuButton"); break;
                    case "Celeste.MiniTextbox": definition.ConfigureLogicalTypeName("MiniTextbox"); break;
                    case "Celeste.MiniTextboxTrigger": definition.ConfigureLogicalTypeName("MiniTextboxTrigger"); break;
                    case "Celeste.MirrorReflection": definition.ConfigureLogicalTypeName("MirrorReflection"); break;
                    case "Celeste.MirrorSurface": definition.ConfigureLogicalTypeName("MirrorSurface"); break;
                    case "Celeste.MirrorSurfaces": definition.ConfigureLogicalTypeName("MirrorSurfaces"); break;
                    case "Celeste.Mod.Entities.ActivateDreamBlocksTrigger":
                        definition.ConfigureLogicalTypeName("ActivateDreamBlocksTrigger"); break;
                    case "Celeste.Mod.Entities.AmbienceTrigger":
                        definition.ConfigureLogicalTypeName("AmbienceTrigger"); break;
                    case "Celeste.Mod.Entities.AmbienceVolumeTrigger":
                        definition.ConfigureLogicalTypeName("AmbienceVolumeTrigger"); break;
                    case "Celeste.Mod.Entities.BadelineOldsiteEnd":
                        definition.ConfigureLogicalTypeName("BadelineOldsiteEnd"); break;
                    case "Celeste.Mod.Entities.CSGEN_GenericStrawberrySeeds":
                        definition.ConfigureLogicalTypeName("CSGEN_GenericStrawberrySeeds"); break;
                    case "Celeste.Mod.Entities.CassetteListener":
                        definition.ConfigureLogicalTypeName("CassetteListener"); break;
                    case "Celeste.Mod.Entities.ChangeInventoryTrigger":
                        definition.ConfigureLogicalTypeName("ChangeInventoryTrigger"); break;
                    case "Celeste.Mod.Entities.CompleteAreaTrigger":
                        definition.ConfigureLogicalTypeName("CompleteAreaTrigger"); break;
                    case "Celeste.Mod.Entities.CoreModeTrigger":
                        definition.ConfigureLogicalTypeName("CoreModeTrigger"); break;
                    case "Celeste.Mod.Entities.CrystalShatterTrigger":
                        definition.ConfigureLogicalTypeName("CrystalShatterTrigger"); break;
                    case "Celeste.Mod.Entities.CustomBirdTutorial":
                        definition.ConfigureLogicalTypeName("CustomBirdTutorial"); break;
                    case "Celeste.Mod.Entities.CustomBirdTutorialTrigger":
                        definition.ConfigureLogicalTypeName("CustomBirdTutorialTrigger"); break;
                    case "Celeste.Mod.Entities.CustomCoreMessage":
                        definition.ConfigureLogicalTypeName("CustomCoreMessage"); break;
                    case "Celeste.Mod.Entities.CustomHeightDisplay":
                        definition.ConfigureLogicalTypeName("CustomHeightDisplay"); break;
                    case "Celeste.Mod.Entities.CustomHeightDisplayTrigger":
                        definition.ConfigureLogicalTypeName("CustomHeightDisplayTrigger"); break;
                    case "Celeste.Mod.Entities.CustomMemorial":
                        definition.ConfigureLogicalTypeName("CustomMemorial"); break;
                    case "Celeste.Mod.Entities.CustomMemorialText":
                        definition.ConfigureLogicalTypeName("CustomMemorialText"); break;
                    case "Celeste.Mod.Entities.CustomNPC": definition.ConfigureLogicalTypeName("CustomNPC"); break;
                    case "Celeste.Mod.Entities.DialogCutscene":
                        definition.ConfigureLogicalTypeName("DialogCutscene"); break;
                    case "Celeste.Mod.Entities.DialogCutsceneTrigger":
                        definition.ConfigureLogicalTypeName("DialogCutsceneTrigger"); break;
                    case "Celeste.Mod.Entities.EntityColliderByComponent`1":
                        definition.ConfigureLogicalTypeName("EntityColliderByComponent`1"); break;
                    case "Celeste.Mod.Entities.EntityCollider`1":
                        definition.ConfigureLogicalTypeName("EntityCollider`1"); break;
                    case "Celeste.Mod.Entities.EntityRemovedListener":
                        definition.ConfigureLogicalTypeName("EntityRemovedListener"); break;
                    case "Celeste.Mod.Entities.EntityTrigger":
                        definition.ConfigureLogicalTypeName("EntityTrigger"); break;
                    case "Celeste.Mod.Entities.EntityTriggerListener":
                        definition.ConfigureLogicalTypeName("EntityTriggerListener"); break;
                    case "Celeste.Mod.Entities.FlagTrigger": definition.ConfigureLogicalTypeName("FlagTrigger"); break;
                    case "Celeste.Mod.Entities.GenericStrawberrySeed":
                        definition.ConfigureLogicalTypeName("GenericStrawberrySeed"); break;
                    case "Celeste.Mod.Entities.LavaBlockerTrigger":
                        definition.ConfigureLogicalTypeName("LavaBlockerTrigger"); break;
                    case "Celeste.Mod.Entities.MusicLayerTrigger":
                        definition.ConfigureLogicalTypeName("MusicLayerTrigger"); break;
                    case "Celeste.Mod.Entities.SceneWrappingEntity":
                        definition.ConfigureLogicalTypeName("SceneWrappingEntity"); break;
                    case "Celeste.Mod.Entities.SceneWrappingEntity`1":
                        definition.ConfigureLogicalTypeName("SceneWrappingEntity`1"); break;
                    case "Celeste.Mod.Entities.SmoothCameraOffsetTrigger":
                        definition.ConfigureLogicalTypeName("SmoothCameraOffsetTrigger"); break;
                    case "Celeste.Mod.Entities.SpaceControllerBlocker":
                        definition.ConfigureLogicalTypeName("SpaceControllerBlocker"); break;
                    case "Celeste.Mod.Entities.StarClimbGraphicsController":
                        definition.ConfigureLogicalTypeName("StarClimbGraphicsController"); break;
                    case "Celeste.Mod.Entities.TimeRateModifier":
                        definition.ConfigureLogicalTypeName("TimeRateModifier"); break;
                    case "Celeste.Mod.Entities.TriggerSpikesOriginal":
                        definition.ConfigureLogicalTypeName("TriggerSpikesOriginal"); break;
                    case "Celeste.Mod.ModuleSettingsButtonConfigUI":
                        definition.ConfigureLogicalTypeName("ModuleSettingsButtonConfigUI"); break;
                    case "Celeste.Mod.ModuleSettingsKeyboardConfigUI":
                        definition.ConfigureLogicalTypeName("ModuleSettingsKeyboardConfigUI"); break;
                    case "Celeste.Mod.UI.CriticalErrorHandler":
                        definition.ConfigureLogicalTypeName("CriticalErrorHandler"); break;
                    case "Celeste.Mod.UI.MainMenuModOptionsButton":
                        definition.ConfigureLogicalTypeName("MainMenuModOptionsButton"); break;
                    case "Celeste.Mod.UI.OuiDependencyDownloader":
                        definition.ConfigureLogicalTypeName("OuiDependencyDownloader"); break;
                    case "Celeste.Mod.UI.OuiFileSelectSlotSubmenu":
                        definition.ConfigureLogicalTypeName("OuiFileSelectSlotSubmenu"); break;
                    case "Celeste.Mod.UI.OuiGenericMenu": definition.ConfigureLogicalTypeName("OuiGenericMenu"); break;
                    case "Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet":
                        definition.ConfigureLogicalTypeName("OuiHelper_ChapterSelect_LevelSet"); break;
                    case "Celeste.Mod.UI.OuiHelper_Shutdown":
                        definition.ConfigureLogicalTypeName("OuiHelper_Shutdown"); break;
                    case "Celeste.Mod.UI.OuiLoggedProgress":
                        definition.ConfigureLogicalTypeName("OuiLoggedProgress"); break;
                    case "Celeste.Mod.UI.OuiMapList": definition.ConfigureLogicalTypeName("OuiMapList"); break;
                    case "Celeste.Mod.UI.OuiMapSearch": definition.ConfigureLogicalTypeName("OuiMapSearch"); break;
                    case "Celeste.Mod.UI.OuiMapSearch.SearchMenu":
                        definition.ConfigureLogicalTypeName("SearchMenu"); break;
                    case "Celeste.Mod.UI.OuiModOptionString":
                        definition.ConfigureLogicalTypeName("OuiModOptionString"); break;
                    case "Celeste.Mod.UI.OuiModOptions": definition.ConfigureLogicalTypeName("OuiModOptions"); break;
                    case "Celeste.Mod.UI.OuiModToggler": definition.ConfigureLogicalTypeName("OuiModToggler"); break;
                    case "Celeste.Mod.UI.OuiModUpdateList":
                        definition.ConfigureLogicalTypeName("OuiModUpdateList"); break;
                    case "Celeste.Mod.UI.OuiNumberEntry": definition.ConfigureLogicalTypeName("OuiNumberEntry"); break;
                    case "Celeste.Mod.UI.OuiOOBE": definition.ConfigureLogicalTypeName("OuiOOBE"); break;
                    case "Celeste.Mod.UI.OuiSoundTest": definition.ConfigureLogicalTypeName("OuiSoundTest"); break;
                    case "Celeste.Mod.UI.OuiTextEntry": definition.ConfigureLogicalTypeName("OuiTextEntry"); break;
                    case "Celeste.Mod.UI.OuiVersionList": definition.ConfigureLogicalTypeName("OuiVersionList"); break;
                    case "Celeste.MoonCreature": definition.ConfigureLogicalTypeName("MoonCreature"); break;
                    case "Celeste.MoonGlitchBackgroundTrigger":
                        definition.ConfigureLogicalTypeName("MoonGlitchBackgroundTrigger"); break;
                    case "Celeste.MoonParticle3D": definition.ConfigureLogicalTypeName("MoonParticle3D"); break;
                    case "Celeste.MoonParticle3D.Particle": definition.ConfigureLogicalTypeName("Particle"); break;
                    case "Celeste.MoveBlock": definition.ConfigureLogicalTypeName("MoveBlock"); break;
                    case "Celeste.MoveBlock.Border": definition.ConfigureLogicalTypeName("Border"); break;
                    case "Celeste.MoveBlock.Debris": definition.ConfigureLogicalTypeName("Debris"); break;
                    case "Celeste.MovingPlatform": definition.ConfigureLogicalTypeName("MovingPlatform"); break;
                    case "Celeste.MovingPlatformLine": definition.ConfigureLogicalTypeName("MovingPlatformLine"); break;
                    case "Celeste.MrOshiroDoor": definition.ConfigureLogicalTypeName("MrOshiroDoor"); break;
                    case "Celeste.MusicFadeTrigger": definition.ConfigureLogicalTypeName("MusicFadeTrigger"); break;
                    case "Celeste.MusicTrigger": definition.ConfigureLogicalTypeName("MusicTrigger"); break;
                    case "Celeste.NPC": definition.ConfigureLogicalTypeName("NPC"); break;
                    case "Celeste.NPC00_Granny": definition.ConfigureLogicalTypeName("NPC00_Granny"); break;
                    case "Celeste.NPC01_Theo": definition.ConfigureLogicalTypeName("NPC01_Theo"); break;
                    case "Celeste.NPC02_Theo": definition.ConfigureLogicalTypeName("NPC02_Theo"); break;
                    case "Celeste.NPC03_Oshiro_Breakdown":
                        definition.ConfigureLogicalTypeName("NPC03_Oshiro_Breakdown"); break;
                    case "Celeste.NPC03_Oshiro_Cluttter":
                        definition.ConfigureLogicalTypeName("NPC03_Oshiro_Cluttter"); break;
                    case "Celeste.NPC03_Oshiro_Hallway1":
                        definition.ConfigureLogicalTypeName("NPC03_Oshiro_Hallway1"); break;
                    case "Celeste.NPC03_Oshiro_Hallway2":
                        definition.ConfigureLogicalTypeName("NPC03_Oshiro_Hallway2"); break;
                    case "Celeste.NPC03_Oshiro_Lobby": definition.ConfigureLogicalTypeName("NPC03_Oshiro_Lobby"); break;
                    case "Celeste.NPC03_Oshiro_Rooftop":
                        definition.ConfigureLogicalTypeName("NPC03_Oshiro_Rooftop"); break;
                    case "Celeste.NPC03_Oshiro_Suite": definition.ConfigureLogicalTypeName("NPC03_Oshiro_Suite"); break;
                    case "Celeste.NPC03_Theo_Escaping":
                        definition.ConfigureLogicalTypeName("NPC03_Theo_Escaping"); break;
                    case "Celeste.NPC03_Theo_Escaping.Grate": definition.ConfigureLogicalTypeName("Grate"); break;
                    case "Celeste.NPC03_Theo_Vents": definition.ConfigureLogicalTypeName("NPC03_Theo_Vents"); break;
                    case "Celeste.NPC03_Theo_Vents.Grate": definition.ConfigureLogicalTypeName("Grate"); break;
                    case "Celeste.NPC04_Granny": definition.ConfigureLogicalTypeName("NPC04_Granny"); break;
                    case "Celeste.NPC04_Theo": definition.ConfigureLogicalTypeName("NPC04_Theo"); break;
                    case "Celeste.NPC05_Badeline": definition.ConfigureLogicalTypeName("NPC05_Badeline"); break;
                    case "Celeste.NPC05_Theo_Entrance":
                        definition.ConfigureLogicalTypeName("NPC05_Theo_Entrance"); break;
                    case "Celeste.NPC05_Theo_Mirror": definition.ConfigureLogicalTypeName("NPC05_Theo_Mirror"); break;
                    case "Celeste.NPC06_Badeline_Crying":
                        definition.ConfigureLogicalTypeName("NPC06_Badeline_Crying"); break;
                    case "Celeste.NPC06_Badeline_Crying.Orb": definition.ConfigureLogicalTypeName("Orb"); break;
                    case "Celeste.NPC06_Granny": definition.ConfigureLogicalTypeName("NPC06_Granny"); break;
                    case "Celeste.NPC06_Granny_Ending":
                        definition.ConfigureLogicalTypeName("NPC06_Granny_Ending"); break;
                    case "Celeste.NPC06_Theo_Ending": definition.ConfigureLogicalTypeName("NPC06_Theo_Ending"); break;
                    case "Celeste.NPC06_Theo_Plateau": definition.ConfigureLogicalTypeName("NPC06_Theo_Plateau"); break;
                    case "Celeste.NPC07X_Granny_Ending":
                        definition.ConfigureLogicalTypeName("NPC07X_Granny_Ending"); break;
                    case "Celeste.NPC08_Granny": definition.ConfigureLogicalTypeName("NPC08_Granny"); break;
                    case "Celeste.NPC08_Theo": definition.ConfigureLogicalTypeName("NPC08_Theo"); break;
                    case "Celeste.NPC09_Granny_Inside":
                        definition.ConfigureLogicalTypeName("NPC09_Granny_Inside"); break;
                    case "Celeste.NPC09_Granny_Outside":
                        definition.ConfigureLogicalTypeName("NPC09_Granny_Outside"); break;
                    case "Celeste.NPC10_Gravestone": definition.ConfigureLogicalTypeName("NPC10_Gravestone"); break;
                    case "Celeste.NegaBlock": definition.ConfigureLogicalTypeName("NegaBlock"); break;
                    case "Celeste.NoRefillTrigger": definition.ConfigureLogicalTypeName("NoRefillTrigger"); break;
                    case "Celeste.OldSiteChaseMusicHandler":
                        definition.ConfigureLogicalTypeName("OldSiteChaseMusicHandler"); break;
                    case "Celeste.OshiroLobbyBell": definition.ConfigureLogicalTypeName("OshiroLobbyBell"); break;
                    case "Celeste.OshiroSprite": definition.ConfigureLogicalTypeName("OshiroSprite"); break;
                    case "Celeste.OshiroTrigger": definition.ConfigureLogicalTypeName("OshiroTrigger"); break;
                    case "Celeste.Oui": definition.ConfigureLogicalTypeName("Oui"); break;
                    case "Celeste.OuiAssistMode": definition.ConfigureLogicalTypeName("OuiAssistMode"); break;
                    case "Celeste.OuiChapterPanel": definition.ConfigureLogicalTypeName("OuiChapterPanel"); break;
                    case "Celeste.OuiChapterSelect": definition.ConfigureLogicalTypeName("OuiChapterSelect"); break;
                    case "Celeste.OuiChapterSelectIcon":
                        definition.ConfigureLogicalTypeName("OuiChapterSelectIcon"); break;
                    case "Celeste.OuiCredits": definition.ConfigureLogicalTypeName("OuiCredits"); break;
                    case "Celeste.OuiFileNaming": definition.ConfigureLogicalTypeName("OuiFileNaming"); break;
                    case "Celeste.OuiFileSelect": definition.ConfigureLogicalTypeName("OuiFileSelect"); break;
                    case "Celeste.OuiFileSelectSlot": definition.ConfigureLogicalTypeName("OuiFileSelectSlot"); break;
                    case "Celeste.OuiJournal": definition.ConfigureLogicalTypeName("OuiJournal"); break;
                    case "Celeste.OuiMainMenu": definition.ConfigureLogicalTypeName("OuiMainMenu"); break;
                    case "Celeste.OuiOptions": definition.ConfigureLogicalTypeName("OuiOptions"); break;
                    case "Celeste.OuiTitleScreen": definition.ConfigureLogicalTypeName("OuiTitleScreen"); break;
                    case "Celeste.Overlay": definition.ConfigureLogicalTypeName("Overlay"); break;
                    case "Celeste.Overworld.InputEntity": definition.ConfigureLogicalTypeName("InputEntity"); break;
                    case "Celeste.Payphone": definition.ConfigureLogicalTypeName("Payphone"); break;
                    case "Celeste.PicoConsole": definition.ConfigureLogicalTypeName("PicoConsole"); break;
                    case "Celeste.Plateau": definition.ConfigureLogicalTypeName("Plateau"); break;
                    case "Celeste.Platform": definition.ConfigureLogicalTypeName("Platform"); break;
                    case "Celeste.PlaybackBillboard": definition.ConfigureLogicalTypeName("PlaybackBillboard"); break;
                    case "Celeste.PlaybackBillboard.FG": definition.ConfigureLogicalTypeName("FG"); break;
                    case var playerRuntimeName
                        when playerRuntimeName == typeof(global::Celeste.Simulation.RoomPlayerSession).FullName:
                        definition.ConfigureLogicalTypeName("Player"); break;
                    case "Celeste.PlayerCollider": definition.ConfigureLogicalTypeName("PlayerCollider"); break;
                    case "Celeste.PlayerDashAssist": definition.ConfigureLogicalTypeName("PlayerDashAssist"); break;
                    case "Celeste.PlayerDeadBody": definition.ConfigureLogicalTypeName("PlayerDeadBody"); break;
                    case "Celeste.PlayerHair": definition.ConfigureLogicalTypeName("PlayerHair"); break;
                    case "Celeste.PlayerPlayback": definition.ConfigureLogicalTypeName("PlayerPlayback"); break;
                    case "Celeste.PlayerSeeker": definition.ConfigureLogicalTypeName("PlayerSeeker"); break;
                    case "Celeste.PlayerSprite": definition.ConfigureLogicalTypeName("PlayerSprite"); break;
                    case "Celeste.Poem": definition.ConfigureLogicalTypeName("Poem"); break;
                    case "Celeste.PostUpdateHook": definition.ConfigureLogicalTypeName("PostUpdateHook"); break;
                    case "Celeste.Postcard": definition.ConfigureLogicalTypeName("Postcard"); break;
                    case "Celeste.PowerSourceNumber": definition.ConfigureLogicalTypeName("PowerSourceNumber"); break;
                    case "Celeste.PrologueEndingText": definition.ConfigureLogicalTypeName("PrologueEndingText"); break;
                    case "Celeste.PropLight": definition.ConfigureLogicalTypeName("PropLight"); break;
                    case "Celeste.Puffer": definition.ConfigureLogicalTypeName("Puffer"); break;
                    case "Celeste.PufferCollider": definition.ConfigureLogicalTypeName("PufferCollider"); break;
                    case "Celeste.QuickResetHint": definition.ConfigureLogicalTypeName("QuickResetHint"); break;
                    case "Celeste.Refill": definition.ConfigureLogicalTypeName("Refill"); break;
                    case "Celeste.ReflectionHeartStatue":
                        definition.ConfigureLogicalTypeName("ReflectionHeartStatue"); break;
                    case "Celeste.ReflectionHeartStatue.Torch": definition.ConfigureLogicalTypeName("Torch"); break;
                    case "Celeste.ReflectionTentacles":
                        definition.ConfigureLogicalTypeName("ReflectionTentacles"); break;
                    case "Celeste.ResortLantern": definition.ConfigureLogicalTypeName("ResortLantern"); break;
                    case "Celeste.ResortMirror": definition.ConfigureLogicalTypeName("ResortMirror"); break;
                    case "Celeste.ResortRoofEnding": definition.ConfigureLogicalTypeName("ResortRoofEnding"); break;
                    case "Celeste.RespawnTargetTrigger":
                        definition.ConfigureLogicalTypeName("RespawnTargetTrigger"); break;
                    case "Celeste.ReturnMapHint": definition.ConfigureLogicalTypeName("ReturnMapHint"); break;
                    case "Celeste.RidgeGate": definition.ConfigureLogicalTypeName("RidgeGate"); break;
                    case "Celeste.RisingLava": definition.ConfigureLogicalTypeName("RisingLava"); break;
                    case "Celeste.RotateSpinner": definition.ConfigureLogicalTypeName("RotateSpinner"); break;
                    case "Celeste.RotatingPlatform": definition.ConfigureLogicalTypeName("RotatingPlatform"); break;
                    case "Celeste.RumbleTrigger": definition.ConfigureLogicalTypeName("RumbleTrigger"); break;
                    case "Celeste.SafeGroundBlocker": definition.ConfigureLogicalTypeName("SafeGroundBlocker"); break;
                    case "Celeste.SandwichLava": definition.ConfigureLogicalTypeName("SandwichLava"); break;
                    case "Celeste.SaveLoadIcon": definition.ConfigureLogicalTypeName("SaveLoadIcon"); break;
                    case "Celeste.Seeker": definition.ConfigureLogicalTypeName("Seeker"); break;
                    case "Celeste.Seeker.RecoverBlast": definition.ConfigureLogicalTypeName("RecoverBlast"); break;
                    case "Celeste.SeekerBarrier": definition.ConfigureLogicalTypeName("SeekerBarrier"); break;
                    case "Celeste.SeekerBarrierRenderer":
                        definition.ConfigureLogicalTypeName("SeekerBarrierRenderer"); break;
                    case "Celeste.SeekerCollider": definition.ConfigureLogicalTypeName("SeekerCollider"); break;
                    case "Celeste.SeekerEffectsController":
                        definition.ConfigureLogicalTypeName("SeekerEffectsController"); break;
                    case "Celeste.SeekerStatue": definition.ConfigureLogicalTypeName("SeekerStatue"); break;
                    case "Celeste.Selfie": definition.ConfigureLogicalTypeName("Selfie"); break;
                    case "Celeste.SinkingPlatform": definition.ConfigureLogicalTypeName("SinkingPlatform"); break;
                    case "Celeste.SinkingPlatformLine":
                        definition.ConfigureLogicalTypeName("SinkingPlatformLine"); break;
                    case "Celeste.SlashFx": definition.ConfigureLogicalTypeName("SlashFx"); break;
                    case "Celeste.Slider": definition.ConfigureLogicalTypeName("Slider"); break;
                    case "Celeste.Snow3D": definition.ConfigureLogicalTypeName("Snow3D"); break;
                    case "Celeste.Snow3D.Particle": definition.ConfigureLogicalTypeName("Particle"); break;
                    case "Celeste.Snowball": definition.ConfigureLogicalTypeName("Snowball"); break;
                    case "Celeste.Solid": definition.ConfigureLogicalTypeName("Solid"); break;
                    case "Celeste.SolidOnInvinciblePlayer":
                        definition.ConfigureLogicalTypeName("SolidOnInvinciblePlayer"); break;
                    case "Celeste.SolidOnInvinciblePlayer.Outline":
                        definition.ConfigureLogicalTypeName("Outline"); break;
                    case "Celeste.SolidTiles": definition.ConfigureLogicalTypeName("SolidTiles"); break;
                    case "Celeste.SoundEmitter": definition.ConfigureLogicalTypeName("SoundEmitter"); break;
                    case "Celeste.SoundSource": definition.ConfigureLogicalTypeName("SoundSource"); break;
                    case "Celeste.SoundSourceEntity": definition.ConfigureLogicalTypeName("SoundSourceEntity"); break;
                    case "Celeste.SpaceController": definition.ConfigureLogicalTypeName("SpaceController"); break;
                    case "Celeste.SpawnFacingTrigger": definition.ConfigureLogicalTypeName("SpawnFacingTrigger"); break;
                    case "Celeste.SpeedRing": definition.ConfigureLogicalTypeName("SpeedRing"); break;
                    case "Celeste.SpeedrunTimerDisplay":
                        definition.ConfigureLogicalTypeName("SpeedrunTimerDisplay"); break;
                    case "Celeste.Spikes": definition.ConfigureLogicalTypeName("Spikes"); break;
                    case "Celeste.Spring": definition.ConfigureLogicalTypeName("Spring"); break;
                    case "Celeste.StaminaDisplay": definition.ConfigureLogicalTypeName("StaminaDisplay"); break;
                    case "Celeste.StarJumpBlock": definition.ConfigureLogicalTypeName("StarJumpBlock"); break;
                    case "Celeste.StarJumpController": definition.ConfigureLogicalTypeName("StarJumpController"); break;
                    case "Celeste.StarRotateSpinner": definition.ConfigureLogicalTypeName("StarRotateSpinner"); break;
                    case "Celeste.StarTrackSpinner": definition.ConfigureLogicalTypeName("StarTrackSpinner"); break;
                    case "Celeste.StaticMover": definition.ConfigureLogicalTypeName("StaticMover"); break;
                    case "Celeste.StopBoostTrigger": definition.ConfigureLogicalTypeName("StopBoostTrigger"); break;
                    case "Celeste.StrawberriesCounter":
                        definition.ConfigureLogicalTypeName("StrawberriesCounter"); break;
                    case "Celeste.Strawberry": definition.ConfigureLogicalTypeName("Strawberry"); break;
                    case "Celeste.StrawberryPoints": definition.ConfigureLogicalTypeName("StrawberryPoints"); break;
                    case "Celeste.StrawberrySeed": definition.ConfigureLogicalTypeName("StrawberrySeed"); break;
                    case "Celeste.SummitCheckpoint": definition.ConfigureLogicalTypeName("SummitCheckpoint"); break;
                    case "Celeste.SummitCheckpoint.ConfettiRenderer":
                        definition.ConfigureLogicalTypeName("ConfettiRenderer"); break;
                    case "Celeste.SummitCloud": definition.ConfigureLogicalTypeName("SummitCloud"); break;
                    case "Celeste.SummitGem": definition.ConfigureLogicalTypeName("SummitGem"); break;
                    case "Celeste.SummitGem.BgFlash": definition.ConfigureLogicalTypeName("BgFlash"); break;
                    case "Celeste.SummitGemManager": definition.ConfigureLogicalTypeName("SummitGemManager"); break;
                    case "Celeste.SummitGemManager.Gem": definition.ConfigureLogicalTypeName("Gem"); break;
                    case "Celeste.SwapBlock": definition.ConfigureLogicalTypeName("SwapBlock"); break;
                    case "Celeste.SwapBlock.PathRenderer": definition.ConfigureLogicalTypeName("PathRenderer"); break;
                    case "Celeste.Switch": definition.ConfigureLogicalTypeName("Switch"); break;
                    case "Celeste.SwitchGate": definition.ConfigureLogicalTypeName("SwitchGate"); break;
                    case "Celeste.TalkComponent": definition.ConfigureLogicalTypeName("TalkComponent"); break;
                    case "Celeste.TalkComponent.TalkComponentUI":
                        definition.ConfigureLogicalTypeName("TalkComponentUI"); break;
                    case "Celeste.TempleBigEyeball": definition.ConfigureLogicalTypeName("TempleBigEyeball"); break;
                    case "Celeste.TempleBigEyeball.Fader": definition.ConfigureLogicalTypeName("Fader"); break;
                    case "Celeste.TempleBigEyeballShockwave":
                        definition.ConfigureLogicalTypeName("TempleBigEyeballShockwave"); break;
                    case "Celeste.TempleCrackedBlock": definition.ConfigureLogicalTypeName("TempleCrackedBlock"); break;
                    case "Celeste.TempleEndingMusicHandler":
                        definition.ConfigureLogicalTypeName("TempleEndingMusicHandler"); break;
                    case "Celeste.TempleEye": definition.ConfigureLogicalTypeName("TempleEye"); break;
                    case "Celeste.TempleGate": definition.ConfigureLogicalTypeName("TempleGate"); break;
                    case "Celeste.TempleMirror": definition.ConfigureLogicalTypeName("TempleMirror"); break;
                    case "Celeste.TempleMirror.Frame": definition.ConfigureLogicalTypeName("Frame"); break;
                    case "Celeste.TempleMirrorPortal": definition.ConfigureLogicalTypeName("TempleMirrorPortal"); break;
                    case "Celeste.TempleMirrorPortal.Bg": definition.ConfigureLogicalTypeName("Bg"); break;
                    case "Celeste.TempleMirrorPortal.Curtain": definition.ConfigureLogicalTypeName("Curtain"); break;
                    case "Celeste.TemplePortalTorch": definition.ConfigureLogicalTypeName("TemplePortalTorch"); break;
                    case "Celeste.TextMenu": definition.ConfigureLogicalTypeName("TextMenu"); break;
                    case "Celeste.Textbox": definition.ConfigureLogicalTypeName("Textbox"); break;
                    case "Celeste.TheoCrystal": definition.ConfigureLogicalTypeName("TheoCrystal"); break;
                    case "Celeste.TheoCrystalPedestal":
                        definition.ConfigureLogicalTypeName("TheoCrystalPedestal"); break;
                    case "Celeste.TheoPhone": definition.ConfigureLogicalTypeName("TheoPhone"); break;
                    case "Celeste.TileInterceptor": definition.ConfigureLogicalTypeName("TileInterceptor"); break;
                    case "Celeste.Torch": definition.ConfigureLogicalTypeName("Torch"); break;
                    case "Celeste.TotalStrawberriesDisplay":
                        definition.ConfigureLogicalTypeName("TotalStrawberriesDisplay"); break;
                    case "Celeste.TouchSwitch": definition.ConfigureLogicalTypeName("TouchSwitch"); break;
                    case "Celeste.TrackSpinner": definition.ConfigureLogicalTypeName("TrackSpinner"); break;
                    case "Celeste.TrailManager": definition.ConfigureLogicalTypeName("TrailManager"); break;
                    case "Celeste.TrailManager.Snapshot": definition.ConfigureLogicalTypeName("Snapshot"); break;
                    case "Celeste.TransitionListener": definition.ConfigureLogicalTypeName("TransitionListener"); break;
                    case "Celeste.Trapdoor": definition.ConfigureLogicalTypeName("Trapdoor"); break;
                    case "Celeste.Trigger": definition.ConfigureLogicalTypeName("Trigger"); break;
                    case "Celeste.TriggerSpikes": definition.ConfigureLogicalTypeName("TriggerSpikes"); break;
                    case "Celeste.UnlockEverythingThingy":
                        definition.ConfigureLogicalTypeName("UnlockEverythingThingy"); break;
                    case "Celeste.UnlockedPico8Message":
                        definition.ConfigureLogicalTypeName("UnlockedPico8Message"); break;
                    case "Celeste.UnlockedRemixDisplay":
                        definition.ConfigureLogicalTypeName("UnlockedRemixDisplay"); break;
                    case "Celeste.VertexLight": definition.ConfigureLogicalTypeName("VertexLight"); break;
                    case "Celeste.ViewportAdjustmentUI":
                        definition.ConfigureLogicalTypeName("ViewportAdjustmentUI"); break;
                    case "Celeste.WallBooster": definition.ConfigureLogicalTypeName("WallBooster"); break;
                    case "Celeste.Water": definition.ConfigureLogicalTypeName("Water"); break;
                    case "Celeste.WaterFall": definition.ConfigureLogicalTypeName("WaterFall"); break;
                    case "Celeste.WaterInteraction": definition.ConfigureLogicalTypeName("WaterInteraction"); break;
                    case "Celeste.WaterSurface": definition.ConfigureLogicalTypeName("WaterSurface"); break;
                    case "Celeste.WaveDashPresentation":
                        definition.ConfigureLogicalTypeName("WaveDashPresentation"); break;
                    case "Celeste.WaveDashTutorialMachine":
                        definition.ConfigureLogicalTypeName("WaveDashTutorialMachine"); break;
                    case "Celeste.WhiteBlock": definition.ConfigureLogicalTypeName("WhiteBlock"); break;
                    case "Celeste.WindAttackTrigger": definition.ConfigureLogicalTypeName("WindAttackTrigger"); break;
                    case "Celeste.WindController": definition.ConfigureLogicalTypeName("WindController"); break;
                    case "Celeste.WindMover": definition.ConfigureLogicalTypeName("WindMover"); break;
                    case "Celeste.WindTrigger": definition.ConfigureLogicalTypeName("WindTrigger"); break;
                    case "Celeste.Wire": definition.ConfigureLogicalTypeName("Wire"); break;
                    case "Celeste.ZipMover": definition.ConfigureLogicalTypeName("ZipMover"); break;
                    case "Celeste.ZipMover.ZipMoverPathRenderer":
                        definition.ConfigureLogicalTypeName("ZipMoverPathRenderer"); break;
                    case "Celeste._3dSoundTest": definition.ConfigureLogicalTypeName("_3dSoundTest"); break;
                    case "Monocle.Alarm": definition.ConfigureLogicalTypeName("Alarm"); break;
                    case "Monocle.CheatListener": definition.ConfigureLogicalTypeName("CheatListener"); break;
                    case "Monocle.Component": definition.ConfigureLogicalTypeName("Component"); break;
                    case "Monocle.Coroutine": definition.ConfigureLogicalTypeName("Coroutine"); break;
                    case "Monocle.CoroutineHolder": definition.ConfigureLogicalTypeName("CoroutineHolder"); break;
                    case "Monocle.CounterSet`1": definition.ConfigureLogicalTypeName("CounterSet`1"); break;
                    case var entityRuntimeName
                        when entityRuntimeName == typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName:
                        definition.ConfigureLogicalTypeName("Entity"); break;
                    case "Monocle.GraphicsComponent": definition.ConfigureLogicalTypeName("GraphicsComponent"); break;
                    case "Monocle.Image": definition.ConfigureLogicalTypeName("Image"); break;
                    case "Monocle.NumberText": definition.ConfigureLogicalTypeName("NumberText"); break;
                    case "Monocle.OutlineText": definition.ConfigureLogicalTypeName("OutlineText"); break;
                    case "Monocle.ParticleEmitter": definition.ConfigureLogicalTypeName("ParticleEmitter"); break;
                    case "Monocle.ParticleSystem": definition.ConfigureLogicalTypeName("ParticleSystem"); break;
                    case "Monocle.PixelText": definition.ConfigureLogicalTypeName("PixelText"); break;
                    case "Monocle.Shaker": definition.ConfigureLogicalTypeName("Shaker"); break;
                    case "Monocle.ShakerList": definition.ConfigureLogicalTypeName("ShakerList"); break;
                    case "Monocle.SineWave": definition.ConfigureLogicalTypeName("SineWave"); break;
                    case "Monocle.SpecEntity`1": definition.ConfigureLogicalTypeName("SpecEntity`1"); break;
                    case "Monocle.Sprite": definition.ConfigureLogicalTypeName("Sprite"); break;
                    case "Monocle.Spritesheet`1": definition.ConfigureLogicalTypeName("Spritesheet`1"); break;
                    case "Monocle.StateMachine": definition.ConfigureLogicalTypeName("StateMachine"); break;
                    case "Monocle.Text": definition.ConfigureLogicalTypeName("Text"); break;
                    case "Monocle.TileGrid": definition.ConfigureLogicalTypeName("TileGrid"); break;
                    case "Monocle.TimerText": definition.ConfigureLogicalTypeName("TimerText"); break;
                    case "Monocle.Tween": definition.ConfigureLogicalTypeName("Tween"); break;
                    case "Monocle.Wiggler": definition.ConfigureLogicalTypeName("Wiggler"); break;
                }
            }
        }
    }
}
