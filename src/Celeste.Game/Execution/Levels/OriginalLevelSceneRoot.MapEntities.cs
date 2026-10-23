using System;
using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Gameplay.Triggers.Inventory;
using Celeste.Game.Gameplay.Triggers.Movement;
using Celeste.Game.Gameplay.Triggers.Checkpoints;
using Celeste.Simulation.Gameplay.Lookout;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Game.Gameplay.Platforms.Jumpthrus;
using Celeste.Game.Gameplay.Collectibles.Keys;
using Celeste.Game.Execution.Processes;
using Celeste.Physics.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Graphics.Content.Tiles.Autotiling;
using Celeste.Simulation.Gameplay.Walls.Concealment;
using Celeste.Game.Content.Maps.Entities.Conditions;
using Celeste.Simulation.Gameplay.Mechanisms.Switches;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Simulation.Gameplay.Clutter;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Game.Audio.Surfaces;
using Celeste.Graphics.Content;

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
                        new global::Celeste.Game.Gameplay.Decoration.WhiteBlocks.OriginalWhiteBlock(
                            data, offset,
                            (global::Celeste.Game.Gameplay.Decoration.WhiteBlocks.IOriginalWhiteBlockProcess)
                            EngineContext,
                            ((ISourcePlatformCollisionScene)this).SolidWorldFactory));
                    break;
                case "moonCreature":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Decoration.MoonCreatures.OriginalMoonCreature(
                            data, offset,
                            (global::Celeste.Game.Gameplay.Decoration.MoonCreatures.IOriginalMoonCreatureProcess)
                            EngineContext));
                    break;
                case "powerSourceNumber":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Decoration.PowerSources.OriginalPowerSourceNumber(
                            data.Position + offset, data.Int("number", 1), GotCollectables(data),
                            (global::Celeste.Game.Gameplay.Decoration.PowerSources.
                                IOriginalPowerSourceNumberProcess)EngineContext));
                    break;
                case "summitcloud":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Decoration.SummitClouds.OriginalSummitCloud(
                            data, offset,
                            (global::Celeste.Game.Gameplay.Decoration.SummitClouds.IOriginalSummitCloudProcess)
                            EngineContext));
                    break;
                case "introCar":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Entities.IntroCar.IOriginalIntroCarEnvironment)EngineContext)
                        .IntroCars.Create(EngineContext, SolidWorldFactory, record, offset));
                    break;
                case "finalBossMovingBlock":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Gameplay.Platforms.FinalBossMovingBlock.
                            IOriginalFinalBossMovingBlockConstructionEnvironment)EngineContext)
                        .FinalBossMovingBlockConstruction.Create(record, offset, EngineContext, SolidWorldFactory));
                    break;
                case "introCrusher":
                {
                    var position = data.Position + offset;
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Gameplay.Platforms.IntroCrusher.
                            IOriginalIntroCrusherConstructionEnvironment)EngineContext)
                        .IntroCrusherConstruction.Create(EngineContext, data, offset,
                            ((ISourcePlatformCollisionScene)this).SolidWorldFactory.Create(position, true)));
                    break;
                }
                case "coreMessage":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Presentation.Hud.CoreMessages.CoreMessageState(data, offset,
                            EngineContext));
                    break;
                case "wavedashmachine":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Machines.WaveDash.OriginalWaveDashTutorialMachineState(
                            record, offset, EngineContext, SolidWorldFactory));
                    break;
                case "switchBlock":
                case "swapBlock":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Platforms.SwapBlocks.OriginalSwapBlockState(
                            EngineContext, record, offset, SolidWorldFactory.Create(record.Position + offset, false)));
                    break;
                case "zipMover":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Platforms.ZipMovers.OriginalZipMoverState(
                            EngineContext, record, offset, SolidWorldFactory.Create(record.Position + offset, false)));
                    break;
                case "coverupWall":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Walls.Concealment.OriginalCoverupWallState(
                            EngineContext, record, offset));
                    break;
                case "ridgeGate":
                    if (GotCollectables(record))
                    {
                        Scheduler.QueueSourceEntity(
                            ((global::Celeste.Game.Entities.Doors.Ridge.IOriginalRidgeGateConstructionEnvironment)
                                EngineContext)
                            .RidgeGateConstruction.Create(EngineContext, record, offset,
                                SolidWorldFactory.Create(record.Position + offset, true)));
                    }

                    break;
                case "theoCrystal":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Holdables.TheoCrystal.TheoCrystalState(record, offset,
                            EngineContext));
                    break;
                case "theoCrystalPedestal":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Holdables.TheoCrystal.TheoCrystalPedestalState(record,
                            offset, EngineContext, SolidWorldFactory));
                    break;
                case "eyebomb":
                    Scheduler.QueueSourceEntity(
                        global::Celeste.Game.Gameplay.Hazards.Puffer.OriginalPufferState.Create(this, record,
                            offset));
                    break;
                case "summitcheckpoint":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Checkpoints.Summit.OriginalSummitCheckpointState(
                            EngineContext, record, offset));
                    break;

                case "coreModeToggle":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Mechanisms.Core.OriginalCoreModeToggleState(EngineContext,
                            record, offset));
                    break;
                case "torch":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.LightSources.Torches.OriginalTorchState(EngineContext,
                            record, offset, id));
                    break;


                case "kevins_pc":
                    Scheduler.QueueSourceEntity(
                        global::Celeste.Game.Entities.Decoration.Computers.OriginalKevinsPCState.Create(this,
                            record, offset));
                    break;


                case "trapdoor":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Decoration.Resort.OriginalTrapdoorState(record, offset,
                            (global::Celeste.Game.Entities.Decoration.Resort.IOriginalResortFixtureEnvironment)
                            EngineContext));
                    break;
                case "resortLantern":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Decoration.Resort.OriginalResortLanternState(record,
                            offset,
                            (global::Celeste.Game.Entities.Decoration.Resort.IOriginalResortFixtureEnvironment)
                            EngineContext));
                    break;


                case "playerSeeker":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Player.Transformations.Seeker.OriginalPlayerSeekerState(
                            record, offset, EngineContext));
                    break;

                case "floatySpaceBlock":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Platforms.FloatySpaceBlocks.FloatySpaceBlockState(
                            record, offset, ((ISourcePlatformCollisionScene)this).SolidWorldFactory));
                    break;
                case "bigWaterfall":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Environment.Water.OriginalBigWaterfallState(data, offset,
                            EngineContext));
                    break;
                case "water":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Gameplay.Environment.Water.IOriginalWaterConstructionEnvironment)
                            EngineContext).WaterConstruction.Create(EngineContext, data, offset));
                    break;
                case "waterfall":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Environment.Water.OriginalWaterFallState(data, offset,
                            EngineContext));
                    break;
                case "clothesline":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Environment.Ridge.OriginalClotheslineState(data, offset,
                            EngineContext));
                    break;
                case "cliffflag":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Environment.Ridge.OriginalCliffFlagsState(data, offset,
                            EngineContext));
                    break;
                case "cliffside_flag":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Environment.Ridge.OriginalCliffsideWindFlagState(data,
                            offset, EngineContext));
                    break;
                case "lightbeam":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Environment.Ridge.OriginalLightBeamState(data, offset,
                            EngineContext));
                    break;
                case "foregroundDebris":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Environment.Ridge.OriginalForegroundDebrisState(data,
                            offset, EngineContext));
                    break;
                case "hanginglamp":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Environment.Ridge.OriginalHangingLampState(data,
                            offset + data.Position, EngineContext));
                    break;
                case "lamp":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Environment.Ridge.OriginalLampState(
                            offset + data.Position, EntityAttributeReader.Bool(data.Values, "broken"),
                            EngineContext));
                    break;
                case "goldenBlock":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Walls.Conditional.GoldenBlockState(
                            record.Position + offset, record.Width, record.Height,
                            SolidWorldFactory.Create(record.Position + offset, false)));
                    break;
                case "glassBlock":
                    Scheduler.QueueSourceEntity(new global::Celeste.Game.Gameplay.Walls.Solids.GlassBlockState(
                        record.Position + offset, record.Width, record.Height,
                        EntityAttributeReader.Bool(record.Values, "sinks"),
                        SolidWorldFactory.Create(record.Position + offset, false)));
                    break;
                case "towerviewer":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Entities.Lookouts.IOriginalLookoutConstructionEnvironment)
                            EngineContext)
                        .LookoutConstruction.Create(record, offset,
                            (global::Celeste.Game.Entities.Lookouts.IOriginalLookoutProcess)EngineContext));
                    break;

                case "glider":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Holdables.Gliders.OriginalGliderState(record, offset,
                            EngineContext));
                    break;
                case "bounceBlock":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Gameplay.Platforms.BounceBlocks.
                            IOriginalBounceBlockConstructionEnvironment)EngineContext)
                        .BounceBlockConstruction
                        .Create(data, offset, ((ISourcePlatformCollisionScene)this).SolidWorldFactory));
                    break;
                case "movingPlatform":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Platforms.Wood.OriginalMovingPlatformState(
                            data, offset, ((ISourcePlatformCollisionScene)this).SolidWorldFactory));
                    break;
                case "sinkingPlatform":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Platforms.Wood.OriginalSinkingPlatformState(
                            data, offset, ((ISourcePlatformCollisionScene)this).SolidWorldFactory));
                    break;
                case "crushBlock":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Gameplay.Platforms.CrushBlocks.
                            IOriginalCrushBlockConstructionEnvironment)EngineContext).CrushBlockConstruction.Create(
                            EngineContext, data, offset,
                            ((ISourcePlatformCollisionScene)this).SolidWorldFactory.Create(data.Position + offset,
                                false)));
                    break;
                case "picoconsole":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Minigames.CelesteClassic.Interaction.PicoConsoleState(
                            EngineContext, data.Position + offset));
                    break;
                case "flutterbird":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Birds.FlutterBird.FlutterBirdState(data, offset,
                            EngineContext));
                    break;
                case "jumpThru":
                    Scheduler.QueueSourceEntity(JumpthruPlatformState.CreateFromMapData(data, offset,
                        ((ISourcePlatformCollisionScene)this).SolidWorldFactory));
                    break;
                case "door":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Oshiro.OriginalDoorState(data, offset, this));
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
                        ((ISourcePlatformCollisionScene)this).SolidWorldFactory.Create(position, true),
                        CreateSourceSecretWallContext()));
                    break;
                }
                case "conditionBlock":
                {
                    var mode = EntityAttributeReader.Enum(data.Values, "condition", OriginalConditionBlockMode.Key);
                    var parts = EntityAttributeReader.Attr(data.Values, "conditionID").Split(':');
                    var conditionId = new MapEntityId(parts[0], Convert.ToInt32(parts[1]));
                    bool satisfied = mode switch
                    {
                        OriginalConditionBlockMode.Button => Session.GetFlag(global::Celeste.Game.Gameplay
                            .Mechanisms.DashSwitches.OriginalDashSwitchState.GetFlagName(conditionId)),
                        OriginalConditionBlockMode.Key => Session.DoNotLoad.Contains(conditionId),
                        OriginalConditionBlockMode.Strawberry => Session.Strawberries.Contains(conditionId),
                        _ => throw new Exception("Condition type not supported!")
                    };
                    if (satisfied)
                    {
                        var position = data.Position + offset;
                        Scheduler.QueueSourceEntity(new ExitBlockState(position, data.Width, data.Height,
                            EntityAttributeReader.Char(data.Values, "tileType", '3'),
                            ((ISourcePlatformCollisionScene)this).SolidWorldFactory.Create(position, true),
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
                        new global::Celeste.Game.Gameplay.Walls.Breakable.OriginalTempleCrackedBlockState(
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
                    bool cheatMode = sameSave.CheatMode;
                    bool seenOrFirstDeath = Session.FurthestSeenLevel == Session.Level || Session.Deaths == 0;
                    bool unlockedModes =
                        ((global::Celeste.Game.Save.Runtime.IOriginalSaveProgressionEnvironment)EngineContext)
                        .SaveProgression.GetUnlockedModes(sameSave) >= 3 ||
                        sameSave.DebugMode;
                    bool completed =
                        ((global::Celeste.Game.Save.Runtime.IOriginalSaveCounterEnvironment)EngineContext)
                        .SaveCounters.GetAreasSafe(sameSave)[Session.AreaID].Modes[Session.Mode].Completed;
                    if ((cheatMode || (unlockedModes && completed)) && seenOrFirstDeath)
                        Scheduler.QueueSourceEntity(new OriginalStrawberryState(data, offset, id,
                            (IOriginalStrawberryProcess)EngineContext));
                    break;
                }
                case "memorialTextController":
                    if (Session.Dashes == 0 && (Session.StartedFromBeginning ||
                                                (((global::Celeste.Game.Profiles.IGameProfileEnvironment)EngineContext)
                                                 .SourceProfile ==
                                                 global::Celeste.Game.Profiles.GameProfile.InstalledEverest &&
                                                 Session.RestartedFromGolden)))
                        Scheduler.QueueSourceEntity(new OriginalStrawberryState(data, offset, id,
                            (IOriginalStrawberryProcess)EngineContext));
                    break;
                case "colorSwitch":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Clutter.Switches.OriginalClutterSwitchState(
                            data, offset, ((ISourcePlatformCollisionScene)this).SolidWorldFactory));
                    break;
                case "clutterDoor":
                {
                    var position = data.Position + offset;
                    Scheduler.QueueSourceEntity(new global::Celeste.Game.Gameplay.Clutter.Doors.ClutterDoorState(
                        data, offset, Session,
                        ((ISourcePlatformCollisionScene)this).SolidWorldFactory.Create(position, false)));
                    break;
                }
                case "clutterCabinet":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Clutter.Cabinets.OriginalClutterCabinetState(
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
                        global::Celeste.Game.Entities.Doors.LockBlocks.OriginalLockBlockState.CreateFromMapData(
                            data, offset, id, this));
                    break;
                case "soundSource":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Audio.MapSoundSources.SoundSourceEntityState(record,
                            offset, EngineContext));
                    break;
                case "npc":
                    LoadSourceMapNpc(record, offset);
                    break;
                case "booster":
                    Scheduler.QueueSourceEntity(
                        global::Celeste.Game.Entities.Interaction.Boosters.OriginalBoosterState.CreateFromMapData(
                            data, offset, EngineContext));
                    break;
                case "light":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Lights.OriginalPropLightState(data, offset,
                            EngineContext));
                    break;
                case "SummitBackgroundManager":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Ascension.OriginalAscendManagerState(EngineContext,
                            record, offset));
                    break;
                case "tentacles":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.ReflectionTentacles.OriginalReflectionTentaclesState(data,
                            offset, EngineContext));
                    break;
                case "dashSwitchH":
                case "dashSwitchV":
                    var sourceDashSwitch = global::Celeste.Game.Gameplay.Mechanisms.DashSwitches
                        .OriginalDashSwitchState.Create(
                            EngineContext, data, offset, id,
                            ((ISourcePlatformCollisionScene)this).SolidWorldFactory.Create(
                                global::Celeste.Core.Mathematics.LinearAlgebra.SourceVector2Math.Add(data.Position,
                                    offset),
                                true));
                    Scheduler.QueueSourceEntity(sourceDashSwitch);
                    break;
                case "templeGate":
                    var sourceTempleGate =
                        new global::Celeste.Game.Gameplay.Doors.TempleGates.OriginalTempleGateState(
                            data, offset, id.Level, EngineContext,
                            ((ISourcePlatformCollisionScene)this).SolidWorldFactory.Create(
                                global::Celeste.Core.Mathematics.LinearAlgebra.SourceVector2Math.Add(data.Position,
                                    offset),
                                true));
                    Scheduler.QueueSourceEntity(sourceTempleGate);
                    break;
                case "risingLava":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Environment.Lava.Rising.OriginalRisingLavaState(
                            EntityAttributeReader.Bool(data.Values, "intro"),
                            (global::Celeste.Game.Gameplay.Environment.Lava.IOriginalLavaProcess)EngineContext));
                    break;
                case "sandwichLava":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Environment.Lava.Sandwich.OriginalSandwichLavaState(
                            data.Position.X + offset.X,
                            (global::Celeste.Game.Gameplay.Environment.Lava.IOriginalLavaProcess)EngineContext));
                    break;
                case "fireBarrier":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Environment.Lava.Barriers.OriginalFireBarrierState(
                            data.Position + offset, data.Width, data.Height,
                            (global::Celeste.Game.Gameplay.Environment.Lava.IOriginalLavaProcess)EngineContext));
                    break;
                case "iceBlock":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Environment.Lava.Barriers.OriginalIceBlockState(
                            data.Position + offset, data.Width, data.Height,
                            (global::Celeste.Game.Gameplay.Environment.Lava.IOriginalLavaProcess)EngineContext));
                    break;
                case "switchGate":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Mechanisms.SwitchGates.OriginalSwitchGateState(
                            data, offset,
                            (global::Celeste.Game.Gameplay.Mechanisms.SwitchGates.IOriginalSwitchGateProcess)
                            EngineContext,
                            ((ISourcePlatformCollisionScene)this).SolidWorldFactory));
                    break;
                case "seeker":
                {
                    var process =
                        (global::Celeste.Game.Gameplay.Enemies.Seekers.IOriginalSeekerProcess)EngineContext;
                    Scheduler.QueueSourceEntity(process.SeekerFactory.Create(data, offset, process));
                    break;
                }
                case "seekerStatue":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Enemies.Seekers.OriginalSeekerStatueState(
                            data, offset,
                            (global::Celeste.Game.Gameplay.Enemies.Seekers.IOriginalSeekerProcess)EngineContext));
                    break;
                case "rotateSpinner":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Gameplay.Hazards.Spinners.Moving.IOriginalMovingSpinnerEnvironment)
                            EngineContext)
                        .MovingSpinnerFactory.Create(this, data, offset, true));
                    break;
                case "trackSpinner":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Gameplay.Hazards.Spinners.Moving.IOriginalMovingSpinnerEnvironment)
                            EngineContext)
                        .MovingSpinnerFactory.Create(this, data, offset, false));
                    break;
                case "spinner":
                    if (Session.AreaID == 3 || (Session.AreaID == 7 && Session.Level.StartsWith("d-")))
                    {
                        Scheduler.QueueSourceEntity(
                            new global::Celeste.Game.Gameplay.Hazards.Spinners.Dust.OriginalDustStaticSpinnerState(
                                data, offset, EngineContext));
                        break;
                    }

                    var color = global::Celeste.Simulation.Gameplay.Hazards.Spinners.Crystal.CrystalSpinnerColor.Blue;
                    if (Session.AreaID == 5)
                        color = global::Celeste.Simulation.Gameplay.Hazards.Spinners.Crystal.CrystalSpinnerColor.Red;
                    else if (Session.AreaID == 6)
                        color = global::Celeste.Simulation.Gameplay.Hazards.Spinners.Crystal.CrystalSpinnerColor.Purple;
                    else if (Session.AreaID == 10)
                        color = global::Celeste.Simulation.Gameplay.Hazards.Spinners.Crystal.CrystalSpinnerColor
                            .Rainbow;
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Hazards.Spinners.Crystal.OriginalCrystalStaticSpinner(
                            data, offset, color, EngineContext));
                    break;
                case "spring":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Interaction.Springs.OriginalSpringState(
                            data, offset,
                            global::Celeste.Simulation.Gameplay.Interaction.Springs.SpringOrientation.Floor,
                            (global::Celeste.Game.Gameplay.Interaction.Springs.IOriginalSpringProcess)
                            EngineContext));
                    break;
                case "wallSpringLeft":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Interaction.Springs.OriginalSpringState(
                            data, offset,
                            global::Celeste.Simulation.Gameplay.Interaction.Springs.SpringOrientation.WallLeft,
                            (global::Celeste.Game.Gameplay.Interaction.Springs.IOriginalSpringProcess)
                            EngineContext));
                    break;
                case "wallSpringRight":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Interaction.Springs.OriginalSpringState(
                            data, offset,
                            global::Celeste.Simulation.Gameplay.Interaction.Springs.SpringOrientation.WallRight,
                            (global::Celeste.Game.Gameplay.Interaction.Springs.IOriginalSpringProcess)
                            EngineContext));
                    break;
                case "touchSwitch":
                {
                    var touch = new global::Celeste.Game.Gameplay.Mechanisms.Switches.OriginalTouchSwitchState(
                        data, offset,
                        (global::Celeste.Game.Gameplay.Mechanisms.Switches.IOriginalTouchSwitchProcess)
                        EngineContext);
                    Scheduler.QueueSourceEntity(touch);
                    break;
                }
                case "spikesUp":
                    Scheduler.QueueSourceEntity(
                        global::Celeste.Game.Gameplay.Hazards.Spikes.OriginalSpikeMapFactory.CreateSpikes(
                            data, offset, global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeDirection.Up,
                            EngineContext));
                    break;
                case "spikesDown":
                    Scheduler.QueueSourceEntity(
                        global::Celeste.Game.Gameplay.Hazards.Spikes.OriginalSpikeMapFactory.CreateSpikes(
                            data, offset, global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeDirection.Down,
                            EngineContext));
                    break;
                case "spikesLeft":
                    Scheduler.QueueSourceEntity(
                        global::Celeste.Game.Gameplay.Hazards.Spikes.OriginalSpikeMapFactory.CreateSpikes(
                            data, offset, global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeDirection.Left,
                            EngineContext));
                    break;
                case "spikesRight":
                    Scheduler.QueueSourceEntity(
                        global::Celeste.Game.Gameplay.Hazards.Spikes.OriginalSpikeMapFactory.CreateSpikes(
                            data, offset, global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeDirection.Right,
                            EngineContext));
                    break;
                case "triggerSpikesUp":
                    Scheduler.QueueSourceEntity(
                        global::Celeste.Game.Gameplay.Hazards.Spikes.OriginalSpikeMapFactory.CreateTriggerSpikes(
                            data, offset,
                            global::Celeste.Simulation.Gameplay.Hazards.TriggerSpikes.TriggerSpikesDirection.Up,
                            EngineContext));
                    break;
                case "triggerSpikesDown":
                    Scheduler.QueueSourceEntity(
                        global::Celeste.Game.Gameplay.Hazards.Spikes.OriginalSpikeMapFactory.CreateTriggerSpikes(
                            data, offset,
                            global::Celeste.Simulation.Gameplay.Hazards.TriggerSpikes.TriggerSpikesDirection.Down,
                            EngineContext));
                    break;
                case "triggerSpikesRight":
                    Scheduler.QueueSourceEntity(
                        global::Celeste.Game.Gameplay.Hazards.Spikes.OriginalSpikeMapFactory.CreateTriggerSpikes(
                            data, offset,
                            global::Celeste.Simulation.Gameplay.Hazards.TriggerSpikes.TriggerSpikesDirection.Right,
                            EngineContext));
                    break;
                case "triggerSpikesLeft":
                    Scheduler.QueueSourceEntity(
                        global::Celeste.Game.Gameplay.Hazards.Spikes.OriginalSpikeMapFactory.CreateTriggerSpikes(
                            data, offset,
                            global::Celeste.Simulation.Gameplay.Hazards.TriggerSpikes.TriggerSpikesDirection.Left,
                            EngineContext));
                    break;
                case "killbox":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Hazards.Killboxes.OriginalKillboxEntity(
                            EngineContext, data, offset));
                    break;
                case "cutsceneNode":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Birds.Fling.OriginalCutsceneNodeState(EngineContext, data,
                            offset));
                    return;
                case "flingBirdIntro":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Birds.Fling.OriginalFlingBirdIntroState(data, offset,
                            EngineContext));
                    return;
                case "lightningBlock":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Hazards.Lightning.LightningBreakerBoxState(data, offset,
                            ((ISourcePlatformCollisionScene)this).SolidWorldFactory, EngineContext));
                    return;
                case "flingBird":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Birds.Fling.OriginalFlingBirdState(record, offset,
                            EngineContext));
                    break;
                case "dreammirror":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Stories.OldSite.DreamMirror.DreamMirrorState(data, offset,
                            EngineContext));
                    break;
                case "bird":
                    Scheduler.QueueSourceEntity(
                        global::Celeste.Game.Entities.Birds.BirdNpcState.CreateFromMapData(this, data, offset, id));
                    break;
                case "badelineBoost":
                    Scheduler.QueueSourceEntity(new global::Celeste.Game.Entities.BadelineBoosts.BadelineBoostState(
                        EngineContext,
                        data.NodesWithPosition(offset), data.Bool("lockCamera", true), data.Bool("canSkip"),
                        data.Bool("finalCh9Boost"), data.Bool("finalCh9GoldenBoost"), data.Bool("finalCh9Dialog")));
                    break;
                case "finalBoss":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Gameplay.Enemies.BadelineBoss.Construction.
                            IOriginalFinalBossEnvironment)EngineContext).FinalBosses.Create(data, offset));
                    break;
                case "lightning":
                    if (global::Celeste.Formats.Map.Entities.Attributes.EntityAttributeReader.Bool(data.Values,
                            "perLevel") ||
                        !Session.GetFlag("disable_lightning"))
                    {
                        Scheduler.QueueSourceEntity(
                            global::Celeste.Game.Gameplay.Hazards.Construction.OriginalLightningMapConstruction
                                .Create(
                                    data, offset, EngineContext));
                        hasRoomLightning = true;
                    }

                    break;
                case "seekerBarrier":
                    Scheduler.QueueSourceEntity(
                        global::Celeste.Game.Gameplay.Hazards.Construction.OriginalSeekerBarrierMapConstruction
                            .Create(
                                data, offset,
                                ((ISourcePlatformCollisionScene)this).SolidWorldFactory.Create(data.Position + offset,
                                    false)));
                    break;
                case "heartGemDoor":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Doors.HeartGems.OriginalHeartGemDoorState(
                            data, offset,
                            (global::Celeste.Game.Gameplay.Doors.HeartGems.IOriginalHeartGemDoorProcess)
                            EngineContext,
                            ((ISourcePlatformCollisionScene)this).SolidWorldFactory,
                            ((global::Celeste.Game.Save.Runtime.IOriginalSaveCounterEnvironment)EngineContext)
                            .SaveCounters));
                    break;
                case "refill":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Collectibles.Refills.OriginalRefillState(
                            data, offset,
                            (global::Celeste.Game.Gameplay.Collectibles.Refills.IOriginalRefillProcess)
                            EngineContext));
                    break;
                case "playbackTutorial":
                    Scheduler.QueueSourceEntity(
                        global::Celeste.Game.Entities.Playback.OriginalPlayerPlaybackState.CreateFromMapData(
                            EngineContext, data, offset,
                            (global::Celeste.Simulation.Gameplay.Tutorial.Replay.IPlayerPlaybackAudio)EngineContext));
                    break;
                case "playbackBillboard":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.PlaybackBillboard.PlaybackBillboardState(
                            EngineContext, data.Position + offset, data.Width, data.Height));
                    break;
                case "cassette":
                    if (!Session.Cassette)
                    {
                        Scheduler.QueueSourceEntity(
                            new global::Celeste.Game.Gameplay.Collectibles.Cassettes.OriginalCassetteState(data,
                                offset, EngineContext));
                    }

                    break;
                case "cassetteBlock":
                {
                    var block = new global::Celeste.Game.Gameplay.Platforms.Cassette.CassetteBlockState(data,
                        offset, id,
                        ((global::Celeste.Simulation.Gameplay.Platforms.Collision.ISourcePlatformCollisionScene)this)
                        .SolidWorldFactory);
                    Scheduler.QueueSourceEntity(block);
                    HasCassetteBlocks = true;
                    if (CassetteBlockTempo == 1f) CassetteBlockTempo = block.Tempo;
                    CassetteBlockBeats = Math.Max(block.Index + 1, CassetteBlockBeats);
                    if (!firstCassetteSeen)
                    {
                        firstCassetteSeen = true;
                        if (Scheduler.Entities
                                .GetTrackedEntity<
                                    global::Celeste.Game.Gameplay.Platforms.Cassette.
                                    OriginalCassetteBlockManagerState>("Celeste.CassetteBlockManager") == null &&
                            ShouldCreateCassetteManager)
                            Scheduler.QueueSourceEntity(
                                ((global::Celeste.Game.Gameplay.Platforms.Cassette.
                                    IOriginalCassetteManagerEnvironment)EngineContext).CassetteManagers.Create());
                    }

                    break;
                }
                case "checkpoint":
                    if (checkpointsEnabled)
                    {
                        var checkpoint = new global::Celeste.Game.Gameplay.Checkpoints.OriginalCheckpointState(
                            data, offset,
                            (global::Celeste.Game.Gameplay.Checkpoints.IOriginalCheckpointProcess)EngineContext);
                        Scheduler.QueueSourceEntity(checkpoint);
                        checkpointStart = data.Position + offset + checkpoint.SpawnOffset;
                    }

                    break;
                case "cloud":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Gameplay.Platforms.Construction.
                            IOriginalCheckpointCloudCrumbleEnvironment)EngineContext)
                        .CheckpointCloudCrumbleFactory.CreateCloud(data, offset,
                            EngineContext,
                            ((ISourcePlatformCollisionScene)this).SolidWorldFactory));
                    break;
                case "crumbleBlock":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Gameplay.Platforms.Construction.
                            IOriginalCheckpointCloudCrumbleEnvironment)EngineContext)
                        .CheckpointCloudCrumbleFactory.CreateCrumble(data, offset,
                            (global::Celeste.Game.Gameplay.Platforms.Crumble.IOriginalCrumbleProcess)EngineContext,
                            ((ISourcePlatformCollisionScene)this).SolidWorldFactory));
                    break;
                case "fallingBlock":
                    Scheduler.QueueSourceEntity(global::Celeste.Game.Gameplay.Platforms.FallingBlocks
                        .OriginalFallingBlockState.Create(this, record, offset));
                    break;
                case "finalBossFallingBlock":
                    Scheduler.QueueSourceEntity(global::Celeste.Game.Gameplay.Platforms.FallingBlocks
                        .OriginalFallingBlockState.CreateFinalBossBlock(this, record, offset));
                    break;
                case "cobweb":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Entities.Decoration.Construction.IOriginalDecorationEnvironment)
                            EngineContext)
                        .Decorations.CreateCobweb(data, offset, EngineContext));
                    break;
                case "wire":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Entities.Decoration.Construction.IOriginalDecorationEnvironment)
                            EngineContext)
                        .Decorations.CreateWire(data, offset, EngineContext));
                    break;
                case "moveBlock":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Platforms.MoveBlocks.MoveBlockState(
                            data, offset, ((ISourcePlatformCollisionScene)this).SolidWorldFactory));
                    break;
                case "negaBlock":
                    Scheduler.QueueSourceEntity(
                        global::Celeste.Game.Entities.Platforms.Nega.OriginalNegaBlockConstruction
                            .CreateFromMapData(
                                data, offset, ((ISourcePlatformCollisionScene)this).SolidWorldFactory));
                    break;
                case "gondola":
                    Scheduler.QueueSourceEntity(new global::Celeste.Game.Entities.Gondolas.OriginalGondolaState(
                        data, offset, ((ISourcePlatformCollisionScene)this).SolidWorldFactory));
                    break;
                case "fireBall":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Hazards.FireBalls.OriginalFireBallState(
                            data, offset,
                            (global::Celeste.Game.Gameplay.Hazards.FireBalls.IOriginalFireBallProcess)
                            EngineContext));
                    break;
                case "bigSpinner":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Hazards.Bumpers.OriginalBumperState(
                            data.Position + offset, data.Nodes.Length == 0 ? (Vector2?)null : data.Nodes[0] + offset,
                            EngineContext));
                    break;
                case "floatingDebris":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Environment.Debris.OriginalFloatingDebrisState(
                            data, offset,
                            (global::Celeste.Game.Gameplay.Environment.Debris.IOriginalFloatingDebrisProcess)
                            EngineContext));
                    break;
                case "dreamBlock":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Entities.Platforms.Dream.IOriginalDreamBlockRuntimeEnvironment)
                            EngineContext).CreateDreamBlock(data, offset, this));
                    break;
                case "bridge":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Bridges.OriginalBridgeState(data, offset, EngineContext));
                    break;
                case "wallBooster":
                    Scheduler.QueueSourceEntity(global::Celeste.Game.Entities.Platforms.WallBoosters
                        .OriginalWallBoosterState.CreateFromMapData(data, offset, this));
                    break;
                case "infiniteStar":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.StarJump.OriginalFlyFeatherState(data, offset,
                            EngineContext));
                    break;
                case "starJumpBlock":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.StarJump.OriginalStarJumpBlockState(data, offset,
                            ((ISourcePlatformCollisionScene)this).SolidWorldFactory));
                    break;
                case "starClimbController":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.StarJump.OriginalStarJumpControllerState(EngineContext));
                    break;
                case "bonfire":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.StarJump.OriginalBonfireState(data, offset,
                            EngineContext));
                    break;
                case "plateau":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.StarJump.OriginalPlateauState(data, offset,
                            ((ISourcePlatformCollisionScene)this).SolidWorldFactory));
                    break;
                case "payphone":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Payphones.OriginalPayphoneState(EngineContext, data,
                            offset));
                    break;
                case "memorial":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Memorials.MemorialState(data, offset, EngineContext));
                    break;
                case "fakeHeart":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Collectibles.Hearts.OriginalFakeHeartState(EngineContext,
                            data, offset));
                    break;
                case "summitgem":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Collectibles.SummitGems.OriginalSummitGemState(
                            EngineContext, data, offset, id));
                    break;
                case "summitGemManager":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Collectibles.SummitGems.OriginalSummitGemManagerState(
                            EngineContext, data, offset));
                    break;
                case "dreamHeartGem":
                    if (!Session.HeartGem)
                        Scheduler.QueueSourceEntity(
                            new global::Celeste.Game.Entities.Collectibles.Hearts.OriginalDreamHeartGemState(
                                EngineContext, data, offset));
                    break;
                case "birdForsakenCityGem":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Puzzles.ForsakenSatellite.
                            OriginalForsakenCitySatelliteState(EngineContext, data, offset));
                    break;
                case "reflectionHeartStatue":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Puzzles.ReflectionHeart.
                            OriginalReflectionHeartStatueState(EngineContext, data, offset));
                    break;
                case "blackGem":
                    if (!Session.HeartGem || Session.Mode != 0)
                        Scheduler.QueueSourceEntity(
                            new global::Celeste.Game.Entities.Collectibles.Hearts.OriginalHeartGemState(
                                EngineContext, data, offset));
                    break;
                case "resortmirror":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Oshiro.OriginalResortMirrorState(data, offset,
                            EngineContext));
                    break;
                case "oshirodoor":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Oshiro.OriginalMrOshiroDoorState(data, offset,
                            EngineContext, ((ISourcePlatformCollisionScene)this).SolidWorldFactory));
                    break;
                case "hahaha":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Hahaha.OriginalHahahaState(data, offset, EngineContext));
                    break;
                case "resortRoofEnding":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Oshiro.OriginalResortRoofEndingState(data, offset,
                            this));
                    break;
                case "birdPath":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Entities.Birds.Paths.IOriginalBirdPathEnvironment)EngineContext)
                        .BirdPaths.Create(id, data, offset, EngineContext));
                    break;
                case "darkChaser":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Gameplay.Enemies.Badeline.Chasers.
                            IOriginalBadelineOldsiteEnvironment)EngineContext).BadelineOldsites
                        .Create(data, offset, darkChaserIndex, EngineContext));
                    darkChaserIndex++;
                    break;
                case "chaserBarrier":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Enemies.Badeline.Chasers.ChaserBarrierState(data, offset,
                            EngineContext));
                    break;
                case "rotatingPlatforms":
                {
                    Vector2 position = data.Position + offset;
                    Vector2 center = data.Nodes[0] + offset;
                    int width = data.Width;
                    int count =
                        global::Celeste.Formats.Map.Entities.Attributes.EntityAttributeReader.Int(data.Values,
                            "platforms");
                    bool clockwise =
                        global::Celeste.Formats.Map.Entities.Attributes.EntityAttributeReader.Bool(data.Values,
                            "clockwise");
                    float length =
                        ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)EngineContext).VectorArithmetic
                        .Length(
                            position - center);
                    float startAngle = global::Celeste.Core.Mathematics.Vector2Geometry.Angle(position - center);
                    float step = (float)Math.PI * 2f / (float)count;
                    for (int index = 0; index < count; index++)
                    {
                        float angle = startAngle + step * (float)index;
                        angle = global::Celeste.Core.Mathematics.ScalarMath.WrapAngle(angle);
                        Vector2 platformPosition =
                            center + global::Celeste.Core.Mathematics.Vector2Geometry.AngleToVector(angle, length);
                        Scheduler.QueueSourceEntity(
                            new global::Celeste.Game.Gameplay.Platforms.Rotating.OriginalRotatingPlatformState(
                                platformPosition, width, center, clockwise, SolidWorldFactory));
                    }

                    break;
                }
                case "blockField":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Collectibles.Strawberries.BlockFields.
                            OriginalBlockFieldState(
                                EngineContext, data, offset));
                    break;
                case "friendlyGhost":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Gameplay.Enemies.AngryOshiro.
                            IOriginalAngryOshiroConstructorEnvironment)EngineContext).AngryOshiroConstructors.Create(
                            data.Position + offset, false,
                            (global::Celeste.Game.Gameplay.Enemies.AngryOshiro.IOriginalAngryOshiroProcess)
                            EngineContext));
                    break;

                case "dashBlock":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Walls.Breakable.OriginalDashBlockState(data, offset, id,
                            SolidWorldFactory));
                    break;
                case "crumbleWallOnRumble":
                    Scheduler.QueueSourceEntity(
                        global::Celeste.Game.Entities.Mechanisms.RumbleWalls.OriginalCrumbleWallOnRumbleState
                            .CreateFromMapData(data, offset, id, this));
                    break;
                case "slider":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Hazards.Sliders.OriginalSliderState(EngineContext, data,
                            offset));
                    break;
                case "templeBigEyeball":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Hazards.TempleEyes.OriginalTempleBigEyeballState(data,
                            offset, EngineContext));
                    break;
                case "invisibleBarrier":
                    Scheduler.QueueSourceEntity(global::Celeste.Game.Entities.Platforms.Barriers
                        .OriginalInvisibleBarrierState.CreateFromMapData(data, offset, this));
                    break;
                case "bridgeFixed":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Bridges.OriginalBridgeFixedState(data, offset, this));
                    break;
                case "templeMirrorPortal":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Stories.Temple.TempleMirrorPortalState(data, offset,
                            EngineContext));
                    break;
                case "templeMirror":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Environment.Mirrors.OriginalTempleMirrorState(data,
                            offset, EngineContext));
                    break;
                case "templeEye":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Hazards.TempleEyes.OriginalTempleEyeState(data, offset,
                            EngineContext));
                    break;
                case "SoundTest3d":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Diagnostics.AudioTesting.OriginalSoundTest3dState(
                            EngineContext, data, offset));
                    break;
            }
        }

        private void LoadSourceClutterTiles(OriginalLevelEntityData record, ClutterColor color)
        {
            var generator =
                ((global::Celeste.Game.Gameplay.Clutter.Generation.ISourceClutterGeneratorEnvironment)EngineContext)
                .ClutterGenerator;
            generator.Init(this);
            var data = record;
            generator.Add((int)(data.Position.X / 8f), (int)(data.Position.Y / 8f),
                data.Width / 8, data.Height / 8, color);
        }

        private void LoadSourceMapNpc(OriginalLevelEntityData record, Vector2 offset)
        {
            string kind = EntityAttributeReader.Attr(record.Values, "npc").ToLower();
            switch (kind)
            {
                case "evil_05":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Stories.Temple.Badeline.OriginalTempleBadelineState(record, offset,
                            EngineContext));
                    break;

                case "oshiro_03_lobby":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Oshiro.OriginalOshiroLobbyState(record, offset,
                            EngineContext));
                    break;
                case "oshiro_03_hallway":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Oshiro.OriginalOshiroHallway1State(record, offset,
                            EngineContext));
                    break;
                case "oshiro_03_hallway2":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Oshiro.OriginalOshiroHallway2State(record, offset,
                            EngineContext));
                    break;
                case "oshiro_03_suite":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Oshiro.OriginalOshiroSuiteState(record, offset,
                            EngineContext));
                    break;
                case "oshiro_03_rooftop":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Oshiro.OriginalOshiroRooftopState(record, offset,
                            EngineContext));
                    break;
                case "oshiro_03_breakdown":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Oshiro.OriginalOshiroBreakdownState(record, offset,
                            EngineContext));
                    break;
                case "oshiro_03_bigroom":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Stories.CelestialResort.NpcOshiroClutterState(
                            record, offset, EngineContext));
                    break;
                case "theo_08_inside":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Stories.Epilogue.OriginalEpilogueTheoState(EngineContext, record,
                            offset));
                    break;
                case "granny_08_inside":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Stories.Epilogue.OriginalEpilogueGrannyState(EngineContext, record,
                            offset));
                    break;
                case "theo_03_escaping":
                    if (!Session.GetFlag("resort_theo"))
                        Scheduler.QueueSourceEntity(
                            new global::Celeste.Game.Entities.Npcs.Theo.Resort.OriginalTheoEscapingState(
                                EngineContext, record.Position + offset));
                    break;
                case "theo_06_plateau":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.StarJump.OriginalTheoPlateauState(record, offset,
                            EngineContext));
                    break;
                case "theo_06_ending":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.StarJump.OriginalTheoEndingState(record, offset,
                            EngineContext));
                    break;
                case "theo_04_cliffside":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Stories.GoldenRidge.OriginalGondolaTheoState(EngineContext,
                            record.Position + offset));
                    break;
                case "granny_06_ending":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.StarJump.OriginalReflectionEndingGrannyState(record,
                            offset, EngineContext));
                    break;
                case "theo_03_vents":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Theo.Resort.OriginalTheoVentsState(EngineContext,
                            record.Position + offset));
                    break;
                case "granny_00_house":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Granny.OriginalPrologueGrannyState(EngineContext,
                            record.Position + offset));
                    break;
                case "theo_01_campfire":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Theo.OriginalCityTheoState(EngineContext,
                            record.Position + offset));
                    break;
                case "theo_02_campfire":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Theo.OriginalOldSiteTheoState(EngineContext,
                            record.Position + offset));
                    break;
                case "granny_04_cliffside":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Granny.OriginalCliffsideGrannyState(EngineContext,
                            record.Position + offset));
                    break;
                case "theo_05_entrance":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Theo.OriginalTempleEntranceTheoState(EngineContext,
                            record.Position + offset));
                    break;
                case "theo_05_inmirror":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Theo.OriginalTempleMirrorTheoState(EngineContext,
                            record.Position + offset));
                    break;
                case "granny_06_intro":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Granny.OriginalReflectionGrannyState(EngineContext,
                            record, offset));
                    break;
                case "badeline_06_crying":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Gameplay.Enemies.BadelineBoss.OriginalBadelineCryingState(record,
                            offset, EngineContext));
                    break;
                case "granny_07x":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Entities.Npcs.Granny.IOriginalGrannyEndingConstructionEnvironment)
                            EngineContext)
                        .GrannyEndingConstruction.Create(EngineContext, record, offset));
                    break;
                case "granny_09_outside":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Granny.OriginalCoreGrannyOutsideState(EngineContext,
                            record, offset));
                    break;
                case "granny_09_inside":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Granny.OriginalCoreGrannyInsideState(EngineContext,
                            record, offset));
                    break;
                case "gravestone_10":
                    Scheduler.QueueSourceEntity(
                        new global::Celeste.Game.Entities.Npcs.Gravestone.OriginalGravestoneState(EngineContext,
                            record, offset));
                    break;
                case "granny_10_never":
                    Scheduler.QueueSourceEntity(
                        ((global::Celeste.Game.Entities.Npcs.Granny.IOriginalGrannyEndingConstructionEnvironment)
                            EngineContext).GrannyEndingConstruction
                        .Create(EngineContext, record, offset, ch9EasterEgg: true));
                    break;
            }
        }

        private SecretWallContext CreateSourceSecretWallContext()
        {
            var process = (IOriginalGameplayProcess)EngineContext;
            var indices = ((IOriginalTileSurfaceEnvironment)EngineContext).SurfaceIndices.TileToIndex;
            return new SecretWallContext
            {
                PlaySound = (path, position) => process.AudioSession.Play(path, position, process.SaveContext),
                TileToSurfaceSoundIndex = tile => indices[tile]
            };
        }
    }
}
