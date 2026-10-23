using System;

namespace Celeste.Everest.Content.Extensions.Entities.Registry
{
    public sealed partial class EverestEntityRegistryProcess
    {
        internal void InitializeBuiltInTypes(IEverestEntityRegistryTypeSource sourceTypes)
        {
            RegisterSidToTypeConnection("checkpoint", RequireType(sourceTypes, "Celeste.Checkpoint"));
            RegisterSidToTypeConnection("jumpThru", RequireType(sourceTypes, "Celeste.JumpthruPlatform"));
            RegisterSidToTypeConnection("refill", RequireType(sourceTypes, "Celeste.Refill"));
            RegisterSidToTypeConnection("infiniteStar", RequireType(sourceTypes, "Celeste.FlyFeather"));
            RegisterSidToTypeConnection("strawberry", RequireType(sourceTypes, "Celeste.Strawberry"));
            RegisterSidToTypeConnection("memorialTextController", RequireType(sourceTypes, "Celeste.Strawberry"));
            RegisterSidToTypeConnection("goldenBerry", RequireType(sourceTypes, "Celeste.Strawberry"));
            RegisterSidToTypeConnection("summitgem", RequireType(sourceTypes, "Celeste.SummitGem"));
            RegisterSidToTypeConnection("blackGem", RequireType(sourceTypes, "Celeste.HeartGem"));
            RegisterSidToTypeConnection("dreamHeartGem", RequireType(sourceTypes, "Celeste.DreamHeartGem"));
            RegisterSidToTypeConnection("spring", RequireType(sourceTypes, "Celeste.Spring"));
            RegisterSidToTypeConnection("wallSpringLeft", RequireType(sourceTypes, "Celeste.Spring"));
            RegisterSidToTypeConnection("wallSpringRight", RequireType(sourceTypes, "Celeste.Spring"));
            RegisterSidToTypeConnection("fallingBlock", RequireType(sourceTypes, "Celeste.FallingBlock"));
            RegisterSidToTypeConnection("zipMover", RequireType(sourceTypes, "Celeste.ZipMover"));
            RegisterSidToTypeConnection("crumbleBlock", RequireType(sourceTypes, "Celeste.CrumblePlatform"));
            RegisterSidToTypeConnection("dreamBlock", RequireType(sourceTypes, "Celeste.DreamBlock"));
            RegisterSidToTypeConnection("touchSwitch", RequireType(sourceTypes, "Celeste.TouchSwitch"));
            RegisterSidToTypeConnection("switchGate", RequireType(sourceTypes, "Celeste.SwitchGate"));
            RegisterSidToTypeConnection("negaBlock", RequireType(sourceTypes, "Celeste.NegaBlock"));
            RegisterSidToTypeConnection("key", RequireType(sourceTypes, "Celeste.Key"));
            RegisterSidToTypeConnection("lockBlock", RequireType(sourceTypes, "Celeste.LockBlock"));
            RegisterSidToTypeConnection("movingPlatform", RequireType(sourceTypes, "Celeste.MovingPlatform"));
            RegisterSidToTypeConnection("rotatingPlatforms", RequireType(sourceTypes, "Celeste.RotatingPlatform"));
            RegisterSidToTypeConnection("blockField", RequireType(sourceTypes, "Celeste.BlockField"));
            RegisterSidToTypeConnection("cloud", RequireType(sourceTypes, "Celeste.Cloud"));
            RegisterSidToTypeConnection("booster", RequireType(sourceTypes, "Celeste.Booster"));
            RegisterSidToTypeConnection("moveBlock", RequireType(sourceTypes, "Celeste.MoveBlock"));
            RegisterSidToTypeConnection("light", RequireType(sourceTypes, "Celeste.PropLight"));
            RegisterSidToTypeConnection("switchBlock", RequireType(sourceTypes, "Celeste.SwapBlock"));
            RegisterSidToTypeConnection("swapBlock", RequireType(sourceTypes, "Celeste.SwapBlock"));
            RegisterSidToTypeConnection("dashSwitchH", RequireType(sourceTypes, "Celeste.DashSwitch"));
            RegisterSidToTypeConnection("dashSwitchV", RequireType(sourceTypes, "Celeste.DashSwitch"));
            RegisterSidToTypeConnection("templeGate", RequireType(sourceTypes, "Celeste.TempleGate"));
            RegisterSidToTypeConnection("torch", RequireType(sourceTypes, "Celeste.Torch"));
            RegisterSidToTypeConnection("templeCrackedBlock", RequireType(sourceTypes, "Celeste.TempleCrackedBlock"));
            RegisterSidToTypeConnection("seekerBarrier", RequireType(sourceTypes, "Celeste.SeekerBarrier"));
            RegisterSidToTypeConnection("theoCrystal", RequireType(sourceTypes, "Celeste.TheoCrystal"));
            RegisterSidToTypeConnection("glider", RequireType(sourceTypes, "Celeste.Glider"));
            RegisterSidToTypeConnection("theoCrystalPedestal", RequireType(sourceTypes, "Celeste.TheoCrystalPedestal"));
            RegisterSidToTypeConnection("badelineBoost", RequireType(sourceTypes, "Celeste.BadelineBoost"));
            RegisterSidToTypeConnection("cassette", RequireType(sourceTypes, "Celeste.Cassette"));
            RegisterSidToTypeConnection("cassetteBlock", RequireType(sourceTypes, "Celeste.CassetteBlock"));
            RegisterSidToTypeConnection("wallBooster", RequireType(sourceTypes, "Celeste.WallBooster"));
            RegisterSidToTypeConnection("bounceBlock", RequireType(sourceTypes, "Celeste.BounceBlock"));
            RegisterSidToTypeConnection("coreModeToggle", RequireType(sourceTypes, "Celeste.CoreModeToggle"));
            RegisterSidToTypeConnection("iceBlock", RequireType(sourceTypes, "Celeste.IceBlock"));
            RegisterSidToTypeConnection("fireBarrier", RequireType(sourceTypes, "Celeste.FireBarrier"));
            RegisterSidToTypeConnection("eyebomb", RequireType(sourceTypes, "Celeste.Puffer"));
            RegisterSidToTypeConnection("flingBird", RequireType(sourceTypes, "Celeste.FlingBird"));
            RegisterSidToTypeConnection("flingBirdIntro", RequireType(sourceTypes, "Celeste.FlingBirdIntro"));
            RegisterSidToTypeConnection("birdPath", RequireType(sourceTypes, "Celeste.BirdPath"));
            RegisterSidToTypeConnection("lightningBlock", RequireType(sourceTypes, "Celeste.LightningBreakerBox"));
            RegisterSidToTypeConnection("spikesUp", RequireType(sourceTypes, "Celeste.Spikes"));
            RegisterSidToTypeConnection("spikesDown", RequireType(sourceTypes, "Celeste.Spikes"));
            RegisterSidToTypeConnection("spikesLeft", RequireType(sourceTypes, "Celeste.Spikes"));
            RegisterSidToTypeConnection("spikesRight", RequireType(sourceTypes, "Celeste.Spikes"));
            RegisterSidToTypeConnection("triggerSpikesUp", RequireType(sourceTypes, "Celeste.TriggerSpikes"));
            RegisterSidToTypeConnection("triggerSpikesDown", RequireType(sourceTypes, "Celeste.TriggerSpikes"));
            RegisterSidToTypeConnection("triggerSpikesRight", RequireType(sourceTypes, "Celeste.TriggerSpikes"));
            RegisterSidToTypeConnection("triggerSpikesLeft", RequireType(sourceTypes, "Celeste.TriggerSpikes"));
            RegisterSidToTypeConnection("darkChaser", RequireType(sourceTypes, "Celeste.BadelineOldsite"));
            RegisterSidToTypeConnection("rotateSpinner", RequireType(sourceTypes, "Celeste.BladeRotateSpinner"));
            RegisterSidToTypeConnection("rotateSpinner", RequireType(sourceTypes, "Celeste.DustRotateSpinner"));
            RegisterSidToTypeConnection("rotateSpinner", RequireType(sourceTypes, "Celeste.StarRotateSpinner"));
            RegisterSidToTypeConnection("trackSpinner", RequireType(sourceTypes, "Celeste.BladeTrackSpinner"));
            RegisterSidToTypeConnection("trackSpinner", RequireType(sourceTypes, "Celeste.StarTrackSpinner"));
            RegisterSidToTypeConnection("trackSpinner", RequireType(sourceTypes, "Celeste.DustTrackSpinner"));
            RegisterSidToTypeConnection("spinner", RequireType(sourceTypes, "Celeste.CrystalStaticSpinner"));
            RegisterSidToTypeConnection("sinkingPlatform", RequireType(sourceTypes, "Celeste.SinkingPlatform"));
            RegisterSidToTypeConnection("friendlyGhost", RequireType(sourceTypes, "Celeste.AngryOshiro"));
            RegisterSidToTypeConnection("seeker", RequireType(sourceTypes, "Celeste.Seeker"));
            RegisterSidToTypeConnection("seekerStatue", RequireType(sourceTypes, "Celeste.SeekerStatue"));
            RegisterSidToTypeConnection("slider", RequireType(sourceTypes, "Celeste.Slider"));
            RegisterSidToTypeConnection("templeBigEyeball", RequireType(sourceTypes, "Celeste.TempleBigEyeball"));
            RegisterSidToTypeConnection("crushBlock", RequireType(sourceTypes, "Celeste.CrushBlock"));
            RegisterSidToTypeConnection("bigSpinner", RequireType(sourceTypes, "Celeste.Bumper"));
            RegisterSidToTypeConnection("starJumpBlock", RequireType(sourceTypes, "Celeste.StarJumpBlock"));
            RegisterSidToTypeConnection("floatySpaceBlock", RequireType(sourceTypes, "Celeste.FloatySpaceBlock"));
            RegisterSidToTypeConnection("glassBlock", RequireType(sourceTypes, "Celeste.GlassBlock"));
            RegisterSidToTypeConnection("goldenBlock", RequireType(sourceTypes, "Celeste.GoldenBlock"));
            RegisterSidToTypeConnection("fireBall", RequireType(sourceTypes, "Celeste.FireBall"));
            RegisterSidToTypeConnection("risingLava", RequireType(sourceTypes, "Celeste.RisingLava"));
            RegisterSidToTypeConnection("sandwichLava", RequireType(sourceTypes, "Celeste.SandwichLava"));
            RegisterSidToTypeConnection("killbox", RequireType(sourceTypes, "Celeste.Killbox"));
            RegisterSidToTypeConnection("fakeHeart", RequireType(sourceTypes, "Celeste.FakeHeart"));
            RegisterSidToTypeConnection("lightning", RequireType(sourceTypes, "Celeste.Lightning"));
            RegisterSidToTypeConnection("finalBoss", RequireType(sourceTypes, "Celeste.FinalBoss"));
            RegisterSidToTypeConnection("finalBossFallingBlock", RequireType(sourceTypes, "Celeste.FallingBlock"));
            RegisterSidToTypeConnection("finalBossMovingBlock",
                RequireType(sourceTypes, "Celeste.FinalBossMovingBlock"));
            RegisterSidToTypeConnection("fakeWall", RequireType(sourceTypes, "Celeste.FakeWall"));
            RegisterSidToTypeConnection("fakeBlock", RequireType(sourceTypes, "Celeste.FakeWall"));
            RegisterSidToTypeConnection("dashBlock", RequireType(sourceTypes, "Celeste.DashBlock"));
            RegisterSidToTypeConnection("invisibleBarrier", RequireType(sourceTypes, "Celeste.InvisibleBarrier"));
            RegisterSidToTypeConnection("exitBlock", RequireType(sourceTypes, "Celeste.ExitBlock"));
            RegisterSidToTypeConnection("conditionBlock", RequireType(sourceTypes, "Celeste.ExitBlock"));
            RegisterSidToTypeConnection("coverupWall", RequireType(sourceTypes, "Celeste.CoverupWall"));
            RegisterSidToTypeConnection("crumbleWallOnRumble", RequireType(sourceTypes, "Celeste.CrumbleWallOnRumble"));
            RegisterSidToTypeConnection("ridgeGate", RequireType(sourceTypes, "Celeste.RidgeGate"));
            RegisterSidToTypeConnection("tentacles", RequireType(sourceTypes, "Celeste.Tentacles"));
            RegisterSidToTypeConnection("starClimbController",
                RequireType(sourceTypes, "Celeste.Mod.Entities.StarClimbGraphicsController"));
            RegisterSidToTypeConnection("playerSeeker", RequireType(sourceTypes, "Celeste.PlayerSeeker"));
            RegisterSidToTypeConnection("chaserBarrier", RequireType(sourceTypes, "Celeste.ChaserBarrier"));
            RegisterSidToTypeConnection("introCrusher", RequireType(sourceTypes, "Celeste.IntroCrusher"));
            RegisterSidToTypeConnection("bridge", RequireType(sourceTypes, "Celeste.Bridge"));
            RegisterSidToTypeConnection("bridgeFixed", RequireType(sourceTypes, "Celeste.BridgeFixed"));
            RegisterSidToTypeConnection("bird", RequireType(sourceTypes, "Celeste.BirdNPC"));
            RegisterSidToTypeConnection("introCar", RequireType(sourceTypes, "Celeste.IntroCar"));
            RegisterSidToTypeConnection("memorial", RequireType(sourceTypes, "Celeste.Memorial"));
            RegisterSidToTypeConnection("wire", RequireType(sourceTypes, "Celeste.Wire"));
            RegisterSidToTypeConnection("cobweb", RequireType(sourceTypes, "Celeste.Cobweb"));
            RegisterSidToTypeConnection("lamp", RequireType(sourceTypes, "Celeste.Lamp"));
            RegisterSidToTypeConnection("hanginglamp", RequireType(sourceTypes, "Celeste.HangingLamp"));
            RegisterSidToTypeConnection("hahaha", RequireType(sourceTypes, "Celeste.Hahaha"));
            RegisterSidToTypeConnection("bonfire", RequireType(sourceTypes, "Celeste.Bonfire"));
            RegisterSidToTypeConnection("payphone", RequireType(sourceTypes, "Celeste.Payphone"));
            RegisterSidToTypeConnection("colorSwitch", RequireType(sourceTypes, "Celeste.ClutterSwitch"));
            RegisterSidToTypeConnection("clutterDoor", RequireType(sourceTypes, "Celeste.ClutterDoor"));
            RegisterSidToTypeConnection("dreammirror", RequireType(sourceTypes, "Celeste.DreamMirror"));
            RegisterSidToTypeConnection("resortmirror", RequireType(sourceTypes, "Celeste.ResortMirror"));
            RegisterSidToTypeConnection("towerviewer", RequireType(sourceTypes, "Celeste.Lookout"));
            RegisterSidToTypeConnection("picoconsole", RequireType(sourceTypes, "Celeste.PicoConsole"));
            RegisterSidToTypeConnection("wavedashmachine", RequireType(sourceTypes, "Celeste.WaveDashTutorialMachine"));
            RegisterSidToTypeConnection("yellowBlocks", RequireType(sourceTypes, "Celeste.ClutterBlockBase"));
            RegisterSidToTypeConnection("redBlocks", RequireType(sourceTypes, "Celeste.ClutterBlockBase"));
            RegisterSidToTypeConnection("greenBlocks", RequireType(sourceTypes, "Celeste.ClutterBlockBase"));
            RegisterSidToTypeConnection("oshirodoor", RequireType(sourceTypes, "Celeste.MrOshiroDoor"));
            RegisterSidToTypeConnection("templeMirrorPortal", RequireType(sourceTypes, "Celeste.TempleMirrorPortal"));
            RegisterSidToTypeConnection("reflectionHeartStatue",
                RequireType(sourceTypes, "Celeste.ReflectionHeartStatue"));
            RegisterSidToTypeConnection("resortRoofEnding", RequireType(sourceTypes, "Celeste.ResortRoofEnding"));
            RegisterSidToTypeConnection("gondola", RequireType(sourceTypes, "Celeste.Gondola"));
            RegisterSidToTypeConnection("birdForsakenCityGem",
                RequireType(sourceTypes, "Celeste.ForsakenCitySatellite"));
            RegisterSidToTypeConnection("whiteblock", RequireType(sourceTypes, "Celeste.WhiteBlock"));
            RegisterSidToTypeConnection("plateau", RequireType(sourceTypes, "Celeste.Plateau"));
            RegisterSidToTypeConnection("soundSource", RequireType(sourceTypes, "Celeste.SoundSourceEntity"));
            RegisterSidToTypeConnection("templeMirror", RequireType(sourceTypes, "Celeste.TempleMirror"));
            RegisterSidToTypeConnection("templeEye", RequireType(sourceTypes, "Celeste.TempleEye"));
            RegisterSidToTypeConnection("clutterCabinet", RequireType(sourceTypes, "Celeste.ClutterCabinet"));
            RegisterSidToTypeConnection("floatingDebris", RequireType(sourceTypes, "Celeste.FloatingDebris"));
            RegisterSidToTypeConnection("foregroundDebris", RequireType(sourceTypes, "Celeste.ForegroundDebris"));
            RegisterSidToTypeConnection("moonCreature", RequireType(sourceTypes, "Celeste.MoonCreature"));
            RegisterSidToTypeConnection("lightbeam", RequireType(sourceTypes, "Celeste.LightBeam"));
            RegisterSidToTypeConnection("door", RequireType(sourceTypes, "Celeste.Door"));
            RegisterSidToTypeConnection("trapdoor", RequireType(sourceTypes, "Celeste.Trapdoor"));
            RegisterSidToTypeConnection("resortLantern", RequireType(sourceTypes, "Celeste.ResortLantern"));
            RegisterSidToTypeConnection("water", RequireType(sourceTypes, "Celeste.Water"));
            RegisterSidToTypeConnection("waterfall", RequireType(sourceTypes, "Celeste.WaterFall"));
            RegisterSidToTypeConnection("bigWaterfall", RequireType(sourceTypes, "Celeste.BigWaterfall"));
            RegisterSidToTypeConnection("clothesline", RequireType(sourceTypes, "Celeste.Clothesline"));
            RegisterSidToTypeConnection("cliffflag", RequireType(sourceTypes, "Celeste.CliffFlags"));
            RegisterSidToTypeConnection("cliffside_flag", RequireType(sourceTypes, "Celeste.CliffsideWindFlag"));
            RegisterSidToTypeConnection("flutterbird", RequireType(sourceTypes, "Celeste.FlutterBird"));
            RegisterSidToTypeConnection("SoundTest3d", RequireType(sourceTypes, "Celeste._3dSoundTest"));
            RegisterSidToTypeConnection("SummitBackgroundManager", RequireType(sourceTypes, "Celeste.AscendManager"));
            RegisterSidToTypeConnection("summitGemManager", RequireType(sourceTypes, "Celeste.SummitGem"));
            RegisterSidToTypeConnection("heartGemDoor", RequireType(sourceTypes, "Celeste.HeartGemDoor"));
            RegisterSidToTypeConnection("summitcheckpoint", RequireType(sourceTypes, "Celeste.SummitCheckpoint"));
            RegisterSidToTypeConnection("summitcloud", RequireType(sourceTypes, "Celeste.SummitCloud"));
            RegisterSidToTypeConnection("coreMessage", RequireType(sourceTypes, "Celeste.CoreMessage"));
            RegisterSidToTypeConnection("playbackTutorial", RequireType(sourceTypes, "Celeste.PlayerPlayback"));
            RegisterSidToTypeConnection("playbackBillboard", RequireType(sourceTypes, "Celeste.PlaybackBillboard"));
            RegisterSidToTypeConnection("cutsceneNode", RequireType(sourceTypes, "Celeste.CutsceneNode"));
            RegisterSidToTypeConnection("kevins_pc", RequireType(sourceTypes, "Celeste.KevinsPC"));
            RegisterSidToTypeConnection("powerSourceNumber", RequireType(sourceTypes, "Celeste.PowerSourceNumber"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC00_Granny"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC01_Theo"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC02_Theo"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC03_Oshiro_Cluttter"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC03_Oshiro_Breakdown"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC03_Oshiro_Hallway2"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC03_Oshiro_Hallway1"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC03_Oshiro_Lobby"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC03_Oshiro_Rooftop"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC03_Oshiro_Suite"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC03_Theo_Escaping"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC03_Theo_Vents"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC04_Theo"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC04_Granny"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC05_Badeline"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC05_Theo_Entrance"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC05_Theo_Mirror"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC06_Granny"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC06_Badeline_Crying"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC06_Granny_Ending"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC06_Theo_Ending"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC06_Theo_Plateau"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC07X_Granny_Ending"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC08_Theo"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC08_Granny"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC09_Granny_Outside"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC09_Granny_Inside"));
            RegisterSidToTypeConnection("npc", RequireType(sourceTypes, "Celeste.NPC10_Gravestone"));
            RegisterSidToTypeConnection("eventTrigger", RequireType(sourceTypes, "Celeste.EventTrigger"));
            RegisterSidToTypeConnection("musicFadeTrigger", RequireType(sourceTypes, "Celeste.MusicFadeTrigger"));
            RegisterSidToTypeConnection("musicTrigger", RequireType(sourceTypes, "Celeste.MusicTrigger"));
            RegisterSidToTypeConnection("altMusicTrigger", RequireType(sourceTypes, "Celeste.AltMusicTrigger"));
            RegisterSidToTypeConnection("cameraOffsetTrigger", RequireType(sourceTypes, "Celeste.CameraOffsetTrigger"));
            RegisterSidToTypeConnection("lightFadeTrigger", RequireType(sourceTypes, "Celeste.LightFadeTrigger"));
            RegisterSidToTypeConnection("bloomFadeTrigger", RequireType(sourceTypes, "Celeste.BloomFadeTrigger"));
            RegisterSidToTypeConnection("cameraTargetTrigger", RequireType(sourceTypes, "Celeste.CameraTargetTrigger"));
            RegisterSidToTypeConnection("cameraAdvanceTargetTrigger",
                RequireType(sourceTypes, "Celeste.CameraAdvanceTargetTrigger"));
            RegisterSidToTypeConnection("respawnTargetTrigger",
                RequireType(sourceTypes, "Celeste.RespawnTargetTrigger"));
            RegisterSidToTypeConnection("changeRespawnTrigger",
                RequireType(sourceTypes, "Celeste.ChangeRespawnTrigger"));
            RegisterSidToTypeConnection("windTrigger", RequireType(sourceTypes, "Celeste.WindTrigger"));
            RegisterSidToTypeConnection("windAttackTrigger", RequireType(sourceTypes, "Celeste.WindAttackTrigger"));
            RegisterSidToTypeConnection("minitextboxTrigger", RequireType(sourceTypes, "Celeste.MiniTextboxTrigger"));
            RegisterSidToTypeConnection("oshiroTrigger", RequireType(sourceTypes, "Celeste.OshiroTrigger"));
            RegisterSidToTypeConnection("interactTrigger", RequireType(sourceTypes, "Celeste.InteractTrigger"));
            RegisterSidToTypeConnection("checkpointBlockerTrigger",
                RequireType(sourceTypes, "Celeste.CheckpointBlockerTrigger"));
            RegisterSidToTypeConnection("lookoutBlocker", RequireType(sourceTypes, "Celeste.LookoutBlocker"));
            RegisterSidToTypeConnection("stopBoostTrigger", RequireType(sourceTypes, "Celeste.StopBoostTrigger"));
            RegisterSidToTypeConnection("noRefillTrigger", RequireType(sourceTypes, "Celeste.NoRefillTrigger"));
            RegisterSidToTypeConnection("ambienceParamTrigger",
                RequireType(sourceTypes, "Celeste.AmbienceParamTrigger"));
            RegisterSidToTypeConnection("creditsTrigger", RequireType(sourceTypes, "Celeste.CreditsTrigger"));
            RegisterSidToTypeConnection("goldenBerryCollectTrigger",
                RequireType(sourceTypes, "Celeste.GoldBerryCollectTrigger"));
            RegisterSidToTypeConnection("moonGlitchBackgroundTrigger",
                RequireType(sourceTypes, "Celeste.MoonGlitchBackgroundTrigger"));
            RegisterSidToTypeConnection("blackholeStrength",
                RequireType(sourceTypes, "Celeste.BlackholeStrengthTrigger"));
            RegisterSidToTypeConnection("rumbleTrigger", RequireType(sourceTypes, "Celeste.RumbleTrigger"));
            RegisterSidToTypeConnection("birdPathTrigger", RequireType(sourceTypes, "Celeste.BirdPathTrigger"));
            RegisterSidToTypeConnection("spawnFacingTrigger", RequireType(sourceTypes, "Celeste.SpawnFacingTrigger"));
            RegisterSidToTypeConnection("detachFollowersTrigger",
                RequireType(sourceTypes, "Celeste.DetachStrawberryTrigger"));
        }

        private static Type RequireType(IEverestEntityRegistryTypeSource sourceTypes, string sourceFullName)
        {
            return sourceTypes.ResolveSourceType(sourceFullName)
                   ?? throw new InvalidOperationException("The actual entity type is not published: " + sourceFullName);
        }
    }
}
