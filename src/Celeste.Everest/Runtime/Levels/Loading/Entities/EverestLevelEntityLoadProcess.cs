using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Entities;
using JetBrains.Annotations;

namespace Celeste.Everest.Runtime.Levels.Loading.Entities
{
    public sealed class EverestLevelEntityLoadProcess
    {
        public delegate SceneEntityState EntityLoader(OriginalLevelSceneRoot level,
            OriginalLevelRoomData levelData, Vector2 offset, OriginalLevelEntityData entityData);

        private readonly IEverestLevelEntityLoadThreadEnvironment threads;
        private HashSet<string> loadStrings;

        [UsedImplicitly(ImplicitUseKindFlags.Access |
                        ImplicitUseKindFlags.Assign)]
        private Dictionary<string, EntityLoader> entityLoaders;

        public Dictionary<string, EntityLoader> EntityLoaders => entityLoaders;

        public EverestLevelEntityLoadThreadState Current => threads.CurrentEntityLoadState;

        public EverestLevelEntityLoadProcess(IEverestLevelEntityLoadThreadEnvironment threads)
        {
            this.threads = threads ?? throw new ArgumentNullException(nameof(threads));
        }

        internal void InitializeSourceFields()
        {
            loadStrings =
            [
                "theoCrystalHoldingBarrier", "checkpoint", "jumpThru", "refill", "infiniteStar",
                "strawberry", "memorialTextController", "goldenBerry", "summitgem", "blackGem",
                "dreamHeartGem", "spring", "wallSpringLeft", "wallSpringRight", "fallingBlock",
                "zipMover", "crumbleBlock", "dreamBlock", "touchSwitch", "switchGate",
                "negaBlock", "key", "lockBlock", "movingPlatform", "rotatingPlatforms",
                "blockField", "cloud", "booster", "moveBlock", "light",
                "switchBlock", "swapBlock", "dashSwitchH", "dashSwitchV", "templeGate",
                "torch", "templeCrackedBlock", "seekerBarrier", "theoCrystal", "glider",
                "theoCrystalPedestal", "badelineBoost", "cassette", "cassetteBlock", "wallBooster",
                "bounceBlock", "coreModeToggle", "iceBlock", "fireBarrier", "eyebomb",
                "flingBird", "flingBirdIntro", "birdPath", "lightningBlock", "spikesUp",
                "spikesDown", "spikesLeft", "spikesRight", "triggerSpikesUp", "triggerSpikesDown",
                "triggerSpikesRight", "triggerSpikesLeft", "darkChaser", "rotateSpinner", "trackSpinner",
                "spinner", "sinkingPlatform", "friendlyGhost", "seeker", "seekerStatue",
                "slider", "templeBigEyeball", "crushBlock", "bigSpinner", "starJumpBlock",
                "floatySpaceBlock", "glassBlock", "goldenBlock", "fireBall", "risingLava",
                "sandwichLava", "killbox", "fakeHeart", "lightning", "finalBoss",
                "finalBossFallingBlock", "finalBossMovingBlock", "fakeWall", "fakeBlock", "dashBlock",
                "invisibleBarrier", "exitBlock", "conditionBlock", "coverupWall", "crumbleWallOnRumble",
                "ridgeGate", "tentacles", "starClimbController", "playerSeeker", "chaserBarrier",
                "introCrusher", "bridge", "bridgeFixed", "bird", "introCar",
                "memorial", "wire", "cobweb", "lamp", "hanginglamp",
                "hahaha", "bonfire", "payphone", "colorSwitch", "clutterDoor",
                "dreammirror", "resortmirror", "towerviewer", "picoconsole", "wavedashmachine",
                "yellowBlocks", "redBlocks", "greenBlocks", "oshirodoor", "templeMirrorPortal",
                "reflectionHeartStatue", "resortRoofEnding", "gondola", "birdForsakenCityGem", "whiteblock",
                "plateau", "soundSource", "templeMirror", "templeEye", "clutterCabinet",
                "floatingDebris", "foregroundDebris", "moonCreature", "lightbeam", "door",
                "trapdoor", "resortLantern", "water", "waterfall", "bigWaterfall",
                "clothesline", "cliffflag", "cliffside_flag", "flutterbird", "SoundTest3d",
                "SummitBackgroundManager", "summitGemManager", "heartGemDoor", "summitcheckpoint", "summitcloud",
                "coreMessage", "playbackTutorial", "playbackBillboard", "cutsceneNode", "kevins_pc",
                "powerSourceNumber", "npc", "eventTrigger", "musicFadeTrigger", "musicTrigger",
                "altMusicTrigger", "cameraOffsetTrigger", "lightFadeTrigger", "bloomFadeTrigger", "cameraTargetTrigger",
                "cameraAdvanceTargetTrigger", "respawnTargetTrigger", "changeRespawnTrigger", "windTrigger",
                "windAttackTrigger",
                "minitextboxTrigger", "oshiroTrigger", "interactTrigger", "checkpointBlockerTrigger", "lookoutBlocker",
                "stopBoostTrigger", "noRefillTrigger", "ambienceParamTrigger", "creditsTrigger",
                "goldenBerryCollectTrigger",
                "moonGlitchBackgroundTrigger", "blackholeStrength", "rumbleTrigger", "birdPathTrigger",
                "spawnFacingTrigger",
                "detachFollowersTrigger",
            ];
            entityLoaders = new();
        }

        public bool IsOriginalLoadString(string name)
        {
            return loadStrings.Contains(name);
        }
    }
}
