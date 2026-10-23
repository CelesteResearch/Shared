using System;
using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Audio.Surfaces;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Entities.Conditions;
using Celeste.Game.Entities.Ascension;
using Celeste.Game.Entities.Audio.MapSoundSources;
using Celeste.Game.Entities.BadelineBoosts;
using Celeste.Game.Entities.Birds;
using Celeste.Game.Entities.Birds.Fling;
using Celeste.Game.Entities.Birds.FlutterBird;
using Celeste.Game.Entities.Birds.Paths;
using Celeste.Game.Entities.Bridges;
using Celeste.Game.Entities.Collectibles.Hearts;
using Celeste.Game.Entities.Collectibles.SummitGems;
using Celeste.Game.Entities.Decoration.Computers;
using Celeste.Game.Entities.Decoration.Construction;
using Celeste.Game.Entities.Decoration.Resort;
using Celeste.Game.Entities.Diagnostics.AudioTesting;
using Celeste.Game.Entities.Doors.LockBlocks;
using Celeste.Game.Entities.Doors.Ridge;
using Celeste.Game.Entities.Gondolas;
using Celeste.Game.Entities.Hahaha;
using Celeste.Game.Entities.Hazards.Killboxes;
using Celeste.Game.Entities.Hazards.Sliders;
using Celeste.Game.Entities.Hazards.Spinners.Crystal;
using Celeste.Game.Entities.Interaction.Boosters;
using Celeste.Game.Entities.IntroCar;
using Celeste.Game.Entities.Lights;
using Celeste.Game.Entities.LightSources.Torches;
using Celeste.Game.Entities.Lookouts;
using Celeste.Game.Entities.Machines.WaveDash;
using Celeste.Game.Entities.Mechanisms.RumbleWalls;
using Celeste.Game.Entities.Memorials;
using Celeste.Game.Entities.Npcs.Granny;
using Celeste.Game.Entities.Npcs.Gravestone;
using Celeste.Game.Entities.Npcs.Oshiro;
using Celeste.Game.Entities.Npcs.Theo;
using Celeste.Game.Entities.Npcs.Theo.Resort;
using Celeste.Game.Entities.Payphones;
using Celeste.Game.Entities.Platforms.Barriers;
using Celeste.Game.Entities.Platforms.Dream;
using Celeste.Game.Entities.Platforms.Nega;
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
using Celeste.Game.Entities.Walls.Concealment;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Checkpoints;
using Celeste.Game.Gameplay.Checkpoints.Summit;
using Celeste.Game.Gameplay.Clutter.Cabinets;
using Celeste.Game.Gameplay.Clutter.Doors;
using Celeste.Game.Gameplay.Clutter.Generation;
using Celeste.Game.Gameplay.Clutter.Switches;
using Celeste.Game.Gameplay.Collectibles.Cassettes;
using Celeste.Game.Gameplay.Collectibles.Keys;
using Celeste.Game.Gameplay.Collectibles.Refills;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Game.Gameplay.Collectibles.Strawberries.BlockFields;
using Celeste.Game.Gameplay.Decoration.MoonCreatures;
using Celeste.Game.Gameplay.Decoration.PowerSources;
using Celeste.Game.Gameplay.Decoration.SummitClouds;
using Celeste.Game.Gameplay.Decoration.WhiteBlocks;
using Celeste.Game.Gameplay.Doors.HeartGems;
using Celeste.Game.Gameplay.Doors.TempleGates;
using Celeste.Game.Gameplay.Enemies.AngryOshiro;
using Celeste.Game.Gameplay.Enemies.Badeline.Chasers;
using Celeste.Game.Gameplay.Enemies.BadelineBoss;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Construction;
using Celeste.Game.Gameplay.Enemies.Seekers;
using Celeste.Game.Gameplay.Environment.Debris;
using Celeste.Game.Gameplay.Environment.Lava;
using Celeste.Game.Gameplay.Environment.Lava.Barriers;
using Celeste.Game.Gameplay.Environment.Lava.Rising;
using Celeste.Game.Gameplay.Environment.Lava.Sandwich;
using Celeste.Game.Gameplay.Environment.Mirrors;
using Celeste.Game.Gameplay.Environment.Ridge;
using Celeste.Game.Gameplay.Environment.Water;
using Celeste.Game.Gameplay.Hazards.Bumpers;
using Celeste.Game.Gameplay.Hazards.Construction;
using Celeste.Game.Gameplay.Hazards.FireBalls;
using Celeste.Game.Gameplay.Hazards.Lightning;
using Celeste.Game.Gameplay.Hazards.Puffer;
using Celeste.Game.Gameplay.Hazards.Spikes;
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
using Celeste.Game.Gameplay.Platforms.BounceBlocks;
using Celeste.Game.Gameplay.Platforms.Cassette;
using Celeste.Game.Gameplay.Platforms.Construction;
using Celeste.Game.Gameplay.Platforms.Crumble;
using Celeste.Game.Gameplay.Platforms.CrushBlocks;
using Celeste.Game.Gameplay.Platforms.FallingBlocks;
using Celeste.Game.Gameplay.Platforms.FinalBossMovingBlock;
using Celeste.Game.Gameplay.Platforms.FloatySpaceBlocks;
using Celeste.Game.Gameplay.Platforms.IntroCrusher;
using Celeste.Game.Gameplay.Platforms.Jumpthrus;
using Celeste.Game.Gameplay.Platforms.MoveBlocks;
using Celeste.Game.Gameplay.Platforms.Rotating;
using Celeste.Game.Gameplay.Player.Transformations.Seeker;
using Celeste.Game.Gameplay.Walls.Breakable;
using Celeste.Game.Gameplay.Walls.Conditional;
using Celeste.Game.Gameplay.Walls.Solids;
using Celeste.Game.Minigames.CelesteClassic.Interaction;
using Celeste.Game.Presentation.Hud.CoreMessages;
using Celeste.Game.Profiles;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Stories.CelestialResort;
using Celeste.Game.Stories.Epilogue;
using Celeste.Game.Stories.GoldenRidge;
using Celeste.Game.Stories.OldSite.DreamMirror;
using Celeste.Game.Stories.Temple;
using Celeste.Game.Stories.Temple.Badeline;
using Celeste.Simulation.Gameplay.Clutter;
using Celeste.Simulation.Gameplay.Hazards.Spikes;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Crystal;
using Celeste.Simulation.Gameplay.Hazards.TriggerSpikes;
using Celeste.Simulation.Gameplay.Interaction.Springs;
using Celeste.Simulation.Gameplay.Tutorial.Replay;
using Celeste.Simulation.Gameplay.Walls.Concealment;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public void LoadSourceMapEntity(OriginalLevelEntityData record, Vector2 offset, MapEntityId id,
            bool checkpointsEnabled, ref Vector2? checkpointStart, ref bool firstCassetteSeen,
            ref int darkChaserIndex, ref bool hasRoomLightning)
        {
            var data = record;
            switch (data.Name)
            {
                case "whiteblock":
                    Scheduler.QueueSourceEntity(
                        new OriginalWhiteBlock(
                            data, offset,
                            (IOriginalWhiteBlockProcess)
                            EngineContext,
                            SolidWorldFactory));
                    break;
                case "moonCreature":
                    Scheduler.QueueSourceEntity(
                        new OriginalMoonCreature(
                            data, offset,
                            (IOriginalMoonCreatureProcess)
                            EngineContext));
                    break;
                case "powerSourceNumber":
                    Scheduler.QueueSourceEntity(
                        new OriginalPowerSourceNumber(
                            data.Position + offset, data.Int("number", 1), GotCollectables(data),
                            (IOriginalPowerSourceNumberProcess)EngineContext));
                    break;
                case "summitcloud":
                    Scheduler.QueueSourceEntity(
                        new OriginalSummitCloud(
                            data, offset,
                            (IOriginalSummitCloudProcess)
                            EngineContext));
                    break;
                case "introCar":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalIntroCarEnvironment)EngineContext)
                        .IntroCars.Create(EngineContext, SolidWorldFactory, record, offset));
                    break;
                case "finalBossMovingBlock":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalFinalBossMovingBlockConstructionEnvironment)EngineContext)
                        .FinalBossMovingBlockConstruction.Create(record, offset, EngineContext, SolidWorldFactory));
                    break;
                case "introCrusher":
                {
                    var position = data.Position + offset;
                    Scheduler.QueueSourceEntity(
                        ((IOriginalIntroCrusherConstructionEnvironment)EngineContext)
                        .IntroCrusherConstruction.Create(EngineContext, data, offset,
                            SolidWorldFactory.Create(position, true)));
                    break;
                }
                case "coreMessage":
                    Scheduler.QueueSourceEntity(
                        new CoreMessageState(data, offset,
                            EngineContext));
                    break;
                case "wavedashmachine":
                    Scheduler.QueueSourceEntity(
                        new OriginalWaveDashTutorialMachineState(
                            record, offset, EngineContext, SolidWorldFactory));
                    break;
                case "switchBlock":
                case "swapBlock":
                    Scheduler.QueueSourceEntity(
                        new OriginalSwapBlockState(
                            EngineContext, record, offset, SolidWorldFactory.Create(record.Position + offset, false)));
                    break;
                case "zipMover":
                    Scheduler.QueueSourceEntity(
                        new OriginalZipMoverState(
                            EngineContext, record, offset, SolidWorldFactory.Create(record.Position + offset, false)));
                    break;
                case "coverupWall":
                    Scheduler.QueueSourceEntity(
                        new OriginalCoverupWallState(
                            EngineContext, record, offset));
                    break;
                case "ridgeGate":
                    if (GotCollectables(record))
                        Scheduler.QueueSourceEntity(
                            ((IOriginalRidgeGateConstructionEnvironment)
                                EngineContext)
                            .RidgeGateConstruction.Create(EngineContext, record, offset,
                                SolidWorldFactory.Create(record.Position + offset, true)));

                    break;
                case "theoCrystal":
                    Scheduler.QueueSourceEntity(
                        new TheoCrystalState(record, offset,
                            EngineContext));
                    break;
                case "theoCrystalPedestal":
                    Scheduler.QueueSourceEntity(
                        new TheoCrystalPedestalState(record,
                            offset, EngineContext, SolidWorldFactory));
                    break;
                case "eyebomb":
                    Scheduler.QueueSourceEntity(
                        OriginalPufferState.Create(this, record,
                            offset));
                    break;
                case "summitcheckpoint":
                    Scheduler.QueueSourceEntity(
                        new OriginalSummitCheckpointState(
                            EngineContext, record, offset));
                    break;

                case "coreModeToggle":
                    Scheduler.QueueSourceEntity(
                        new OriginalCoreModeToggleState(EngineContext,
                            record, offset));
                    break;
                case "torch":
                    Scheduler.QueueSourceEntity(
                        new OriginalTorchState(EngineContext,
                            record, offset, id));
                    break;


                case "kevins_pc":
                    Scheduler.QueueSourceEntity(
                        OriginalKevinsPCState.Create(this,
                            record, offset));
                    break;


                case "trapdoor":
                    Scheduler.QueueSourceEntity(
                        new OriginalTrapdoorState(record, offset,
                            (IOriginalResortFixtureEnvironment)
                            EngineContext));
                    break;
                case "resortLantern":
                    Scheduler.QueueSourceEntity(
                        new OriginalResortLanternState(record,
                            offset,
                            (IOriginalResortFixtureEnvironment)
                            EngineContext));
                    break;


                case "playerSeeker":
                    Scheduler.QueueSourceEntity(
                        new OriginalPlayerSeekerState(
                            record, offset, EngineContext));
                    break;

                case "floatySpaceBlock":
                    Scheduler.QueueSourceEntity(
                        new FloatySpaceBlockState(
                            record, offset, SolidWorldFactory));
                    break;
                case "bigWaterfall":
                    Scheduler.QueueSourceEntity(
                        new OriginalBigWaterfallState(data, offset,
                            EngineContext));
                    break;
                case "water":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalWaterConstructionEnvironment)
                            EngineContext).WaterConstruction.Create(EngineContext, data, offset));
                    break;
                case "waterfall":
                    Scheduler.QueueSourceEntity(
                        new OriginalWaterFallState(data, offset,
                            EngineContext));
                    break;
                case "clothesline":
                    Scheduler.QueueSourceEntity(
                        new OriginalClotheslineState(data, offset,
                            EngineContext));
                    break;
                case "cliffflag":
                    Scheduler.QueueSourceEntity(
                        new OriginalCliffFlagsState(data, offset,
                            EngineContext));
                    break;
                case "cliffside_flag":
                    Scheduler.QueueSourceEntity(
                        new OriginalCliffsideWindFlagState(data,
                            offset, EngineContext));
                    break;
                case "lightbeam":
                    Scheduler.QueueSourceEntity(
                        new OriginalLightBeamState(data, offset,
                            EngineContext));
                    break;
                case "foregroundDebris":
                    Scheduler.QueueSourceEntity(
                        new OriginalForegroundDebrisState(data,
                            offset, EngineContext));
                    break;
                case "hanginglamp":
                    Scheduler.QueueSourceEntity(
                        new OriginalHangingLampState(data,
                            offset + data.Position, EngineContext));
                    break;
                case "lamp":
                    Scheduler.QueueSourceEntity(
                        new OriginalLampState(
                            offset + data.Position, EntityAttributeReader.Bool(data.Values, "broken"),
                            EngineContext));
                    break;
                case "goldenBlock":
                    Scheduler.QueueSourceEntity(
                        new GoldenBlockState(
                            record.Position + offset, record.Width, record.Height,
                            SolidWorldFactory.Create(record.Position + offset, false)));
                    break;
                case "glassBlock":
                    Scheduler.QueueSourceEntity(new GlassBlockState(
                        record.Position + offset, record.Width, record.Height,
                        EntityAttributeReader.Bool(record.Values, "sinks"),
                        SolidWorldFactory.Create(record.Position + offset, false)));
                    break;
                case "towerviewer":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalLookoutConstructionEnvironment)
                            EngineContext)
                        .LookoutConstruction.Create(record, offset,
                            (IOriginalLookoutProcess)EngineContext));
                    break;

                case "glider":
                    Scheduler.QueueSourceEntity(
                        new OriginalGliderState(record, offset,
                            EngineContext));
                    break;
                case "bounceBlock":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalBounceBlockConstructionEnvironment)EngineContext)
                        .BounceBlockConstruction
                        .Create(data, offset, SolidWorldFactory));
                    break;
                case "movingPlatform":
                    Scheduler.QueueSourceEntity(
                        new OriginalMovingPlatformState(
                            data, offset, SolidWorldFactory));
                    break;
                case "sinkingPlatform":
                    Scheduler.QueueSourceEntity(
                        new OriginalSinkingPlatformState(
                            data, offset, SolidWorldFactory));
                    break;
                case "crushBlock":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalCrushBlockConstructionEnvironment)EngineContext).CrushBlockConstruction.Create(
                            EngineContext, data, offset,
                            SolidWorldFactory.Create(data.Position + offset,
                                false)));
                    break;
                case "picoconsole":
                    Scheduler.QueueSourceEntity(
                        new PicoConsoleState(
                            EngineContext, data.Position + offset));
                    break;
                case "flutterbird":
                    Scheduler.QueueSourceEntity(
                        new FlutterBirdState(data, offset,
                            EngineContext));
                    break;
                case "jumpThru":
                    Scheduler.QueueSourceEntity(JumpthruPlatformState.CreateFromMapData(data, offset,
                        SolidWorldFactory));
                    break;
                case "door":
                    Scheduler.QueueSourceEntity(
                        new OriginalDoorState(data, offset, this));
                    break;
                case "fakeWall":
                case "fakeBlock":
                {
                    var state = new FakeWallState(id, data.Position + offset,
                        EntityAttributeReader.Char(data.Values, "tiletype", '3'),
                        data.Width, data.Height,
                        data.Name == "fakeWall" ? FakeWallMode.Wall : FakeWallMode.Block,
                        CreateSourceSecretWallContext(), EngineContext);
                    state.PlayTransitionReveal = EntityAttributeReader.Bool(data.Values, "playTransitionReveal");
                    Scheduler.QueueSourceEntity(state);
                    break;
                }
                case "exitBlock":
                {
                    var position = data.Position + offset;
                    Scheduler.QueueSourceEntity(new ExitBlockState(position, data.Width, data.Height,
                        EntityAttributeReader.Char(data.Values, "tileType", '3'),
                        SolidWorldFactory.Create(position, true),
                        CreateSourceSecretWallContext()));
                    break;
                }
                case "conditionBlock":
                {
                    var mode = EntityAttributeReader.Enum(data.Values, "condition", OriginalConditionBlockMode.Key);
                    var parts = EntityAttributeReader.Attr(data.Values, "conditionID").Split(':');
                    var conditionId = new MapEntityId(parts[0], Convert.ToInt32(parts[1]));
                    var satisfied = mode switch
                    {
                        OriginalConditionBlockMode.Button => Session.GetFlag(
                            OriginalDashSwitchState.GetFlagName(conditionId)),
                        OriginalConditionBlockMode.Key => Session.DoNotLoad.Contains(conditionId),
                        OriginalConditionBlockMode.Strawberry => Session.Strawberries.Contains(conditionId),
                        _ => throw new("Condition type not supported!"),
                    };
                    if (satisfied)
                    {
                        var position = data.Position + offset;
                        Scheduler.QueueSourceEntity(new ExitBlockState(position, data.Width, data.Height,
                            EntityAttributeReader.Char(data.Values, "tileType", '3'),
                            SolidWorldFactory.Create(position, true),
                            CreateSourceSecretWallContext()));
                    }

                    break;
                }
                case "key":
                    Scheduler.QueueSourceEntity(new OriginalKeyState(data, offset, id,
                        (IOriginalKeyProcess)EngineContext));
                    break;
                case "templeCrackedBlock":
                    Scheduler.QueueSourceEntity(
                        new OriginalTempleCrackedBlockState(
                            id, record, offset, EngineContext,
                            SolidWorldFactory.Create(record.Position + offset, true)));
                    break;
                case "strawberry":
                    Scheduler.QueueSourceEntity(new OriginalStrawberryState(data, offset, id,
                        (IOriginalStrawberryProcess)EngineContext));
                    break;
                case "goldenBerry":
                {
                    var sameSave = ((IOriginalGameplayProcess)EngineContext).SaveContext.CurrentSave;
                    var cheatMode = sameSave.CheatMode;
                    var seenOrFirstDeath = Session.FurthestSeenLevel == Session.Level || Session.Deaths == 0;
                    var unlockedModes =
                        ((IOriginalSaveProgressionEnvironment)EngineContext)
                        .SaveProgression.GetUnlockedModes(sameSave) >= 3 ||
                        sameSave.DebugMode;
                    var completed =
                        ((IOriginalSaveCounterEnvironment)EngineContext)
                        .SaveCounters.GetAreasSafe(sameSave)[Session.AreaID].Modes[Session.Mode].Completed;
                    if ((cheatMode || (unlockedModes && completed)) && seenOrFirstDeath)
                        Scheduler.QueueSourceEntity(new OriginalStrawberryState(data, offset, id,
                            (IOriginalStrawberryProcess)EngineContext));
                    break;
                }
                case "memorialTextController":
                    if (Session.Dashes == 0 && (Session.StartedFromBeginning ||
                                                (((IGameProfileEnvironment)EngineContext)
                                                 .SourceProfile ==
                                                 GameProfile.InstalledEverest &&
                                                 Session.RestartedFromGolden)))
                        Scheduler.QueueSourceEntity(new OriginalStrawberryState(data, offset, id,
                            (IOriginalStrawberryProcess)EngineContext));
                    break;
                case "colorSwitch":
                    Scheduler.QueueSourceEntity(
                        new OriginalClutterSwitchState(
                            data, offset, SolidWorldFactory));
                    break;
                case "clutterDoor":
                {
                    var position = data.Position + offset;
                    Scheduler.QueueSourceEntity(new ClutterDoorState(
                        data, offset, Session,
                        SolidWorldFactory.Create(position, false)));
                    break;
                }
                case "clutterCabinet":
                    Scheduler.QueueSourceEntity(
                        new OriginalClutterCabinetState(
                            data, offset, EngineContext));
                    break;
                case "yellowBlocks":
                    LoadSourceClutterTiles(record, ClutterColor.Yellow);
                    break;
                case "redBlocks":
                    LoadSourceClutterTiles(record, ClutterColor.Red);
                    break;
                case "greenBlocks":
                    LoadSourceClutterTiles(record, ClutterColor.Green);
                    break;
                case "lockBlock":
                    Scheduler.QueueSourceEntity(
                        OriginalLockBlockState.CreateFromMapData(
                            data, offset, id, this));
                    break;
                case "soundSource":
                    Scheduler.QueueSourceEntity(
                        new SoundSourceEntityState(record,
                            offset, EngineContext));
                    break;
                case "npc":
                    LoadSourceMapNpc(record, offset);
                    break;
                case "booster":
                    Scheduler.QueueSourceEntity(
                        OriginalBoosterState.CreateFromMapData(
                            data, offset, EngineContext));
                    break;
                case "light":
                    Scheduler.QueueSourceEntity(
                        new OriginalPropLightState(data, offset,
                            EngineContext));
                    break;
                case "SummitBackgroundManager":
                    Scheduler.QueueSourceEntity(
                        new OriginalAscendManagerState(EngineContext,
                            record, offset));
                    break;
                case "tentacles":
                    Scheduler.QueueSourceEntity(
                        new OriginalReflectionTentaclesState(data,
                            offset, EngineContext));
                    break;
                case "dashSwitchH":
                case "dashSwitchV":
                    var sourceDashSwitch = OriginalDashSwitchState.Create(
                        EngineContext, data, offset, id,
                        SolidWorldFactory.Create(
                            SourceVector2Math.Add(data.Position,
                                offset),
                            true));
                    Scheduler.QueueSourceEntity(sourceDashSwitch);
                    break;
                case "templeGate":
                    var sourceTempleGate =
                        new OriginalTempleGateState(
                            data, offset, id.Level, EngineContext,
                            SolidWorldFactory.Create(
                                SourceVector2Math.Add(data.Position,
                                    offset),
                                true));
                    Scheduler.QueueSourceEntity(sourceTempleGate);
                    break;
                case "risingLava":
                    Scheduler.QueueSourceEntity(
                        new OriginalRisingLavaState(
                            EntityAttributeReader.Bool(data.Values, "intro"),
                            (IOriginalLavaProcess)EngineContext));
                    break;
                case "sandwichLava":
                    Scheduler.QueueSourceEntity(
                        new OriginalSandwichLavaState(
                            data.Position.X + offset.X,
                            (IOriginalLavaProcess)EngineContext));
                    break;
                case "fireBarrier":
                    Scheduler.QueueSourceEntity(
                        new OriginalFireBarrierState(
                            data.Position + offset, data.Width, data.Height,
                            (IOriginalLavaProcess)EngineContext));
                    break;
                case "iceBlock":
                    Scheduler.QueueSourceEntity(
                        new OriginalIceBlockState(
                            data.Position + offset, data.Width, data.Height,
                            (IOriginalLavaProcess)EngineContext));
                    break;
                case "switchGate":
                    Scheduler.QueueSourceEntity(
                        new OriginalSwitchGateState(
                            data, offset,
                            (IOriginalSwitchGateProcess)
                            EngineContext,
                            SolidWorldFactory));
                    break;
                case "seeker":
                {
                    var process =
                        (IOriginalSeekerProcess)EngineContext;
                    Scheduler.QueueSourceEntity(process.SeekerFactory.Create(data, offset, process));
                    break;
                }
                case "seekerStatue":
                    Scheduler.QueueSourceEntity(
                        new OriginalSeekerStatueState(
                            data, offset,
                            (IOriginalSeekerProcess)EngineContext));
                    break;
                case "rotateSpinner":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalMovingSpinnerEnvironment)
                            EngineContext)
                        .MovingSpinnerFactory.Create(this, data, offset, true));
                    break;
                case "trackSpinner":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalMovingSpinnerEnvironment)
                            EngineContext)
                        .MovingSpinnerFactory.Create(this, data, offset, false));
                    break;
                case "spinner":
                    if (Session.AreaID == 3 || (Session.AreaID == 7 && Session.Level.StartsWith("d-")))
                    {
                        Scheduler.QueueSourceEntity(
                            new OriginalDustStaticSpinnerState(
                                data, offset, EngineContext));
                        break;
                    }

                    var color = CrystalSpinnerColor.Blue;
                    if (Session.AreaID == 5)
                        color = CrystalSpinnerColor.Red;
                    else if (Session.AreaID == 6)
                        color = CrystalSpinnerColor.Purple;
                    else if (Session.AreaID == 10)
                        color = CrystalSpinnerColor
                            .Rainbow;
                    Scheduler.QueueSourceEntity(
                        new OriginalCrystalStaticSpinner(
                            data, offset, color, EngineContext));
                    break;
                case "spring":
                    Scheduler.QueueSourceEntity(
                        new OriginalSpringState(
                            data, offset,
                            SpringOrientation.Floor,
                            (IOriginalSpringProcess)
                            EngineContext));
                    break;
                case "wallSpringLeft":
                    Scheduler.QueueSourceEntity(
                        new OriginalSpringState(
                            data, offset,
                            SpringOrientation.WallLeft,
                            (IOriginalSpringProcess)
                            EngineContext));
                    break;
                case "wallSpringRight":
                    Scheduler.QueueSourceEntity(
                        new OriginalSpringState(
                            data, offset,
                            SpringOrientation.WallRight,
                            (IOriginalSpringProcess)
                            EngineContext));
                    break;
                case "touchSwitch":
                {
                    var touch = new OriginalTouchSwitchState(
                        data, offset,
                        (IOriginalTouchSwitchProcess)
                        EngineContext);
                    Scheduler.QueueSourceEntity(touch);
                    break;
                }
                case "spikesUp":
                    Scheduler.QueueSourceEntity(
                        OriginalSpikeMapFactory.CreateSpikes(
                            data, offset, SpikeDirection.Up,
                            EngineContext));
                    break;
                case "spikesDown":
                    Scheduler.QueueSourceEntity(
                        OriginalSpikeMapFactory.CreateSpikes(
                            data, offset, SpikeDirection.Down,
                            EngineContext));
                    break;
                case "spikesLeft":
                    Scheduler.QueueSourceEntity(
                        OriginalSpikeMapFactory.CreateSpikes(
                            data, offset, SpikeDirection.Left,
                            EngineContext));
                    break;
                case "spikesRight":
                    Scheduler.QueueSourceEntity(
                        OriginalSpikeMapFactory.CreateSpikes(
                            data, offset, SpikeDirection.Right,
                            EngineContext));
                    break;
                case "triggerSpikesUp":
                    Scheduler.QueueSourceEntity(
                        OriginalSpikeMapFactory.CreateTriggerSpikes(
                            data, offset,
                            TriggerSpikesDirection.Up,
                            EngineContext));
                    break;
                case "triggerSpikesDown":
                    Scheduler.QueueSourceEntity(
                        OriginalSpikeMapFactory.CreateTriggerSpikes(
                            data, offset,
                            TriggerSpikesDirection.Down,
                            EngineContext));
                    break;
                case "triggerSpikesRight":
                    Scheduler.QueueSourceEntity(
                        OriginalSpikeMapFactory.CreateTriggerSpikes(
                            data, offset,
                            TriggerSpikesDirection.Right,
                            EngineContext));
                    break;
                case "triggerSpikesLeft":
                    Scheduler.QueueSourceEntity(
                        OriginalSpikeMapFactory.CreateTriggerSpikes(
                            data, offset,
                            TriggerSpikesDirection.Left,
                            EngineContext));
                    break;
                case "killbox":
                    Scheduler.QueueSourceEntity(
                        new OriginalKillboxEntity(
                            EngineContext, data, offset));
                    break;
                case "cutsceneNode":
                    Scheduler.QueueSourceEntity(
                        new OriginalCutsceneNodeState(EngineContext, data,
                            offset));
                    return;
                case "flingBirdIntro":
                    Scheduler.QueueSourceEntity(
                        new OriginalFlingBirdIntroState(data, offset,
                            EngineContext));
                    return;
                case "lightningBlock":
                    Scheduler.QueueSourceEntity(
                        new LightningBreakerBoxState(data, offset,
                            SolidWorldFactory, EngineContext));
                    return;
                case "flingBird":
                    Scheduler.QueueSourceEntity(
                        new OriginalFlingBirdState(record, offset,
                            EngineContext));
                    break;
                case "dreammirror":
                    Scheduler.QueueSourceEntity(
                        new DreamMirrorState(data, offset,
                            EngineContext));
                    break;
                case "bird":
                    Scheduler.QueueSourceEntity(
                        BirdNpcState.CreateFromMapData(this, data, offset, id));
                    break;
                case "badelineBoost":
                    Scheduler.QueueSourceEntity(new BadelineBoostState(
                        EngineContext,
                        data.NodesWithPosition(offset), data.Bool("lockCamera", true), data.Bool("canSkip"),
                        data.Bool("finalCh9Boost"), data.Bool("finalCh9GoldenBoost"), data.Bool("finalCh9Dialog")));
                    break;
                case "finalBoss":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalFinalBossEnvironment)EngineContext).FinalBosses.Create(data, offset));
                    break;
                case "lightning":
                    if (EntityAttributeReader.Bool(data.Values,
                            "perLevel") ||
                        !Session.GetFlag("disable_lightning"))
                    {
                        Scheduler.QueueSourceEntity(
                            OriginalLightningMapConstruction
                                .Create(
                                    data, offset, EngineContext));
                        hasRoomLightning = true;
                    }

                    break;
                case "seekerBarrier":
                    Scheduler.QueueSourceEntity(
                        OriginalSeekerBarrierMapConstruction
                            .Create(
                                data, offset,
                                SolidWorldFactory.Create(data.Position + offset,
                                    false)));
                    break;
                case "heartGemDoor":
                    Scheduler.QueueSourceEntity(
                        new OriginalHeartGemDoorState(
                            data, offset,
                            (IOriginalHeartGemDoorProcess)
                            EngineContext,
                            SolidWorldFactory,
                            ((IOriginalSaveCounterEnvironment)EngineContext)
                            .SaveCounters));
                    break;
                case "refill":
                    Scheduler.QueueSourceEntity(
                        new OriginalRefillState(
                            data, offset,
                            (IOriginalRefillProcess)
                            EngineContext));
                    break;
                case "playbackTutorial":
                    Scheduler.QueueSourceEntity(
                        OriginalPlayerPlaybackState.CreateFromMapData(
                            EngineContext, data, offset,
                            (IPlayerPlaybackAudio)EngineContext));
                    break;
                case "playbackBillboard":
                    Scheduler.QueueSourceEntity(
                        new PlaybackBillboardState(
                            EngineContext, data.Position + offset, data.Width, data.Height));
                    break;
                case "cassette":
                    if (!Session.Cassette)
                        Scheduler.QueueSourceEntity(
                            new OriginalCassetteState(data,
                                offset, EngineContext));

                    break;
                case "cassetteBlock":
                {
                    var block = new CassetteBlockState(data,
                        offset, id,
                        SolidWorldFactory);
                    Scheduler.QueueSourceEntity(block);
                    HasCassetteBlocks = true;
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (CassetteBlockTempo == 1f) CassetteBlockTempo = block.Tempo;
                    CassetteBlockBeats = Math.Max(block.Index + 1, CassetteBlockBeats);
                    if (!firstCassetteSeen)
                    {
                        firstCassetteSeen = true;
                        if (Scheduler.Entities
                                .GetTrackedEntity<
                                    OriginalCassetteBlockManagerState>("Celeste.CassetteBlockManager") == null &&
                            ShouldCreateCassetteManager)
                            Scheduler.QueueSourceEntity(
                                ((IOriginalCassetteManagerEnvironment)EngineContext).CassetteManagers.Create());
                    }

                    break;
                }
                case "checkpoint":
                    if (checkpointsEnabled)
                    {
                        var checkpoint = new OriginalCheckpointState(
                            data, offset,
                            (IOriginalCheckpointProcess)EngineContext);
                        Scheduler.QueueSourceEntity(checkpoint);
                        checkpointStart = data.Position + offset + checkpoint.SpawnOffset;
                    }

                    break;
                case "cloud":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalCheckpointCloudCrumbleEnvironment)EngineContext)
                        .CheckpointCloudCrumbleFactory.CreateCloud(data, offset,
                            EngineContext,
                            SolidWorldFactory));
                    break;
                case "crumbleBlock":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalCheckpointCloudCrumbleEnvironment)EngineContext)
                        .CheckpointCloudCrumbleFactory.CreateCrumble(data, offset,
                            (IOriginalCrumbleProcess)EngineContext,
                            SolidWorldFactory));
                    break;
                case "fallingBlock":
                    Scheduler.QueueSourceEntity(OriginalFallingBlockState.Create(this, record, offset));
                    break;
                case "finalBossFallingBlock":
                    Scheduler.QueueSourceEntity(OriginalFallingBlockState.CreateFinalBossBlock(this, record, offset));
                    break;
                case "cobweb":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalDecorationEnvironment)
                            EngineContext)
                        .Decorations.CreateCobweb(data, offset, EngineContext));
                    break;
                case "wire":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalDecorationEnvironment)
                            EngineContext)
                        .Decorations.CreateWire(data, offset, EngineContext));
                    break;
                case "moveBlock":
                    Scheduler.QueueSourceEntity(
                        new MoveBlockState(
                            data, offset, SolidWorldFactory));
                    break;
                case "negaBlock":
                    Scheduler.QueueSourceEntity(
                        OriginalNegaBlockConstruction
                            .CreateFromMapData(
                                data, offset, SolidWorldFactory));
                    break;
                case "gondola":
                    Scheduler.QueueSourceEntity(new OriginalGondolaState(
                        data, offset, SolidWorldFactory));
                    break;
                case "fireBall":
                    Scheduler.QueueSourceEntity(
                        new OriginalFireBallState(
                            data, offset,
                            (IOriginalFireBallProcess)
                            EngineContext));
                    break;
                case "bigSpinner":
                    Scheduler.QueueSourceEntity(
                        new OriginalBumperState(
                            data.Position + offset, data.Nodes.Length == 0 ? null : data.Nodes[0] + offset,
                            EngineContext));
                    break;
                case "floatingDebris":
                    Scheduler.QueueSourceEntity(
                        new OriginalFloatingDebrisState(
                            data, offset,
                            (IOriginalFloatingDebrisProcess)
                            EngineContext));
                    break;
                case "dreamBlock":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalDreamBlockRuntimeEnvironment)
                            EngineContext).CreateDreamBlock(data, offset, this));
                    break;
                case "bridge":
                    Scheduler.QueueSourceEntity(
                        new OriginalBridgeState(data, offset, EngineContext));
                    break;
                case "wallBooster":
                    Scheduler.QueueSourceEntity(OriginalWallBoosterState.CreateFromMapData(data, offset, this));
                    break;
                case "infiniteStar":
                    Scheduler.QueueSourceEntity(
                        new OriginalFlyFeatherState(data, offset,
                            EngineContext));
                    break;
                case "starJumpBlock":
                    Scheduler.QueueSourceEntity(
                        new OriginalStarJumpBlockState(data, offset,
                            SolidWorldFactory));
                    break;
                case "starClimbController":
                    Scheduler.QueueSourceEntity(
                        new OriginalStarJumpControllerState(EngineContext));
                    break;
                case "bonfire":
                    Scheduler.QueueSourceEntity(
                        new OriginalBonfireState(data, offset,
                            EngineContext));
                    break;
                case "plateau":
                    Scheduler.QueueSourceEntity(
                        new OriginalPlateauState(data, offset,
                            SolidWorldFactory));
                    break;
                case "payphone":
                    Scheduler.QueueSourceEntity(
                        new OriginalPayphoneState(EngineContext, data,
                            offset));
                    break;
                case "memorial":
                    Scheduler.QueueSourceEntity(
                        new MemorialState(data, offset, EngineContext));
                    break;
                case "fakeHeart":
                    Scheduler.QueueSourceEntity(
                        new OriginalFakeHeartState(EngineContext,
                            data, offset));
                    break;
                case "summitgem":
                    Scheduler.QueueSourceEntity(
                        new OriginalSummitGemState(
                            EngineContext, data, offset, id));
                    break;
                case "summitGemManager":
                    Scheduler.QueueSourceEntity(
                        new OriginalSummitGemManagerState(
                            EngineContext, data, offset));
                    break;
                case "dreamHeartGem":
                    if (!Session.HeartGem)
                        Scheduler.QueueSourceEntity(
                            new OriginalDreamHeartGemState(
                                EngineContext, data, offset));
                    break;
                case "birdForsakenCityGem":
                    Scheduler.QueueSourceEntity(
                        new OriginalForsakenCitySatelliteState(EngineContext, data, offset));
                    break;
                case "reflectionHeartStatue":
                    Scheduler.QueueSourceEntity(
                        new OriginalReflectionHeartStatueState(EngineContext, data, offset));
                    break;
                case "blackGem":
                    if (!Session.HeartGem || Session.Mode != 0)
                        Scheduler.QueueSourceEntity(
                            new OriginalHeartGemState(
                                EngineContext, data, offset));
                    break;
                case "resortmirror":
                    Scheduler.QueueSourceEntity(
                        new OriginalResortMirrorState(data, offset,
                            EngineContext));
                    break;
                case "oshirodoor":
                    Scheduler.QueueSourceEntity(
                        new OriginalMrOshiroDoorState(data, offset,
                            EngineContext, SolidWorldFactory));
                    break;
                case "hahaha":
                    Scheduler.QueueSourceEntity(
                        new OriginalHahahaState(data, offset, EngineContext));
                    break;
                case "resortRoofEnding":
                    Scheduler.QueueSourceEntity(
                        new OriginalResortRoofEndingState(data, offset,
                            this));
                    break;
                case "birdPath":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalBirdPathEnvironment)EngineContext)
                        .BirdPaths.Create(id, data, offset, EngineContext));
                    break;
                case "darkChaser":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalBadelineOldsiteEnvironment)EngineContext).BadelineOldsites
                        .Create(data, offset, darkChaserIndex, EngineContext));
                    darkChaserIndex++;
                    break;
                case "chaserBarrier":
                    Scheduler.QueueSourceEntity(
                        new ChaserBarrierState(data, offset,
                            EngineContext));
                    break;
                case "rotatingPlatforms":
                {
                    var position = data.Position + offset;
                    var center = data.Nodes[0] + offset;
                    var width = data.Width;
                    var count =
                        EntityAttributeReader.Int(data.Values,
                            "platforms");
                    var clockwise =
                        EntityAttributeReader.Bool(data.Values,
                            "clockwise");
                    var length =
                        ((ISourceVectorEnvironment)EngineContext).VectorArithmetic
                        .Length(
                            position - center);
                    var startAngle = Vector2Geometry.Angle(position - center);
                    var step = (float)Math.PI * 2f / count;
                    for (var index = 0; index < count; index++)
                    {
                        var angle = startAngle + step * index;
                        angle = ScalarMath.WrapAngle(angle);
                        var platformPosition =
                            center + Vector2Geometry.AngleToVector(angle, length);
                        Scheduler.QueueSourceEntity(
                            new OriginalRotatingPlatformState(
                                platformPosition, width, center, clockwise, SolidWorldFactory));
                    }

                    break;
                }
                case "blockField":
                    Scheduler.QueueSourceEntity(
                        new OriginalBlockFieldState(
                            EngineContext, data, offset));
                    break;
                case "friendlyGhost":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalAngryOshiroConstructorEnvironment)EngineContext).AngryOshiroConstructors.Create(
                            data.Position + offset, false,
                            (IOriginalAngryOshiroProcess)
                            EngineContext));
                    break;

                case "dashBlock":
                    Scheduler.QueueSourceEntity(
                        new OriginalDashBlockState(data, offset, id,
                            SolidWorldFactory));
                    break;
                case "crumbleWallOnRumble":
                    Scheduler.QueueSourceEntity(
                        OriginalCrumbleWallOnRumbleState
                            .CreateFromMapData(data, offset, id, this));
                    break;
                case "slider":
                    Scheduler.QueueSourceEntity(
                        new OriginalSliderState(EngineContext, data,
                            offset));
                    break;
                case "templeBigEyeball":
                    Scheduler.QueueSourceEntity(
                        new OriginalTempleBigEyeballState(data,
                            offset, EngineContext));
                    break;
                case "invisibleBarrier":
                    Scheduler.QueueSourceEntity(OriginalInvisibleBarrierState.CreateFromMapData(data, offset, this));
                    break;
                case "bridgeFixed":
                    Scheduler.QueueSourceEntity(
                        new OriginalBridgeFixedState(data, offset, this));
                    break;
                case "templeMirrorPortal":
                    Scheduler.QueueSourceEntity(
                        new TempleMirrorPortalState(data, offset,
                            EngineContext));
                    break;
                case "templeMirror":
                    Scheduler.QueueSourceEntity(
                        new OriginalTempleMirrorState(data,
                            offset, EngineContext));
                    break;
                case "templeEye":
                    Scheduler.QueueSourceEntity(
                        new OriginalTempleEyeState(data, offset,
                            EngineContext));
                    break;
                case "SoundTest3d":
                    Scheduler.QueueSourceEntity(
                        new OriginalSoundTest3dState(
                            EngineContext, data, offset));
                    break;
            }
        }

        private void LoadSourceClutterTiles(OriginalLevelEntityData record, ClutterColor color)
        {
            var generator =
                ((ISourceClutterGeneratorEnvironment)EngineContext)
                .ClutterGenerator;
            generator.Init(this);
            var data = record;
            generator.Add((int)(data.Position.X / 8f), (int)(data.Position.Y / 8f),
                data.Width / 8, data.Height / 8, color);
        }

        private void LoadSourceMapNpc(OriginalLevelEntityData record, Vector2 offset)
        {
            var kind = EntityAttributeReader.Attr(record.Values, "npc").ToLower();
            switch (kind)
            {
                case "evil_05":
                    Scheduler.QueueSourceEntity(
                        new OriginalTempleBadelineState(record, offset,
                            EngineContext));
                    break;

                case "oshiro_03_lobby":
                    Scheduler.QueueSourceEntity(
                        new OriginalOshiroLobbyState(record, offset,
                            EngineContext));
                    break;
                case "oshiro_03_hallway":
                    Scheduler.QueueSourceEntity(
                        new OriginalOshiroHallway1State(record, offset,
                            EngineContext));
                    break;
                case "oshiro_03_hallway2":
                    Scheduler.QueueSourceEntity(
                        new OriginalOshiroHallway2State(record, offset,
                            EngineContext));
                    break;
                case "oshiro_03_suite":
                    Scheduler.QueueSourceEntity(
                        new OriginalOshiroSuiteState(record, offset,
                            EngineContext));
                    break;
                case "oshiro_03_rooftop":
                    Scheduler.QueueSourceEntity(
                        new OriginalOshiroRooftopState(record, offset,
                            EngineContext));
                    break;
                case "oshiro_03_breakdown":
                    Scheduler.QueueSourceEntity(
                        new OriginalOshiroBreakdownState(record, offset,
                            EngineContext));
                    break;
                case "oshiro_03_bigroom":
                    Scheduler.QueueSourceEntity(
                        new NpcOshiroClutterState(
                            record, offset, EngineContext));
                    break;
                case "theo_08_inside":
                    Scheduler.QueueSourceEntity(
                        new OriginalEpilogueTheoState(EngineContext, record,
                            offset));
                    break;
                case "granny_08_inside":
                    Scheduler.QueueSourceEntity(
                        new OriginalEpilogueGrannyState(EngineContext, record,
                            offset));
                    break;
                case "theo_03_escaping":
                    if (!Session.GetFlag("resort_theo"))
                        Scheduler.QueueSourceEntity(
                            new OriginalTheoEscapingState(
                                EngineContext, record.Position + offset));
                    break;
                case "theo_06_plateau":
                    Scheduler.QueueSourceEntity(
                        new OriginalTheoPlateauState(record, offset,
                            EngineContext));
                    break;
                case "theo_06_ending":
                    Scheduler.QueueSourceEntity(
                        new OriginalTheoEndingState(record, offset,
                            EngineContext));
                    break;
                case "theo_04_cliffside":
                    Scheduler.QueueSourceEntity(
                        new OriginalGondolaTheoState(EngineContext,
                            record.Position + offset));
                    break;
                case "granny_06_ending":
                    Scheduler.QueueSourceEntity(
                        new OriginalReflectionEndingGrannyState(record,
                            offset, EngineContext));
                    break;
                case "theo_03_vents":
                    Scheduler.QueueSourceEntity(
                        new OriginalTheoVentsState(EngineContext,
                            record.Position + offset));
                    break;
                case "granny_00_house":
                    Scheduler.QueueSourceEntity(
                        new OriginalPrologueGrannyState(EngineContext,
                            record.Position + offset));
                    break;
                case "theo_01_campfire":
                    Scheduler.QueueSourceEntity(
                        new OriginalCityTheoState(EngineContext,
                            record.Position + offset));
                    break;
                case "theo_02_campfire":
                    Scheduler.QueueSourceEntity(
                        new OriginalOldSiteTheoState(EngineContext,
                            record.Position + offset));
                    break;
                case "granny_04_cliffside":
                    Scheduler.QueueSourceEntity(
                        new OriginalCliffsideGrannyState(EngineContext,
                            record.Position + offset));
                    break;
                case "theo_05_entrance":
                    Scheduler.QueueSourceEntity(
                        new OriginalTempleEntranceTheoState(EngineContext,
                            record.Position + offset));
                    break;
                case "theo_05_inmirror":
                    Scheduler.QueueSourceEntity(
                        new OriginalTempleMirrorTheoState(EngineContext,
                            record.Position + offset));
                    break;
                case "granny_06_intro":
                    Scheduler.QueueSourceEntity(
                        new OriginalReflectionGrannyState(EngineContext,
                            record, offset));
                    break;
                case "badeline_06_crying":
                    Scheduler.QueueSourceEntity(
                        new OriginalBadelineCryingState(record,
                            offset, EngineContext));
                    break;
                case "granny_07x":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalGrannyEndingConstructionEnvironment)
                            EngineContext)
                        .GrannyEndingConstruction.Create(EngineContext, record, offset));
                    break;
                case "granny_09_outside":
                    Scheduler.QueueSourceEntity(
                        new OriginalCoreGrannyOutsideState(EngineContext,
                            record, offset));
                    break;
                case "granny_09_inside":
                    Scheduler.QueueSourceEntity(
                        new OriginalCoreGrannyInsideState(EngineContext,
                            record, offset));
                    break;
                case "gravestone_10":
                    Scheduler.QueueSourceEntity(
                        new OriginalGravestoneState(EngineContext,
                            record, offset));
                    break;
                case "granny_10_never":
                    Scheduler.QueueSourceEntity(
                        ((IOriginalGrannyEndingConstructionEnvironment)
                            EngineContext).GrannyEndingConstruction
                        .Create(EngineContext, record, offset, true));
                    break;
            }
        }

        private SecretWallContext CreateSourceSecretWallContext()
        {
            var process = (IOriginalGameplayProcess)EngineContext;
            var indices = ((IOriginalTileSurfaceEnvironment)EngineContext).SurfaceIndices.TileToIndex;
            return new()
            {
                PlaySound = (path, position) => process.AudioSession.Play(path, position, process.SaveContext),
                TileToSurfaceSoundIndex = tile => indices[tile],
            };
        }
    }
}
