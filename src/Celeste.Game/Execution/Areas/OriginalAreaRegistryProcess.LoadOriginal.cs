using System;
using Celeste.Core.Audio;
using Celeste.Core.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Scene.Rendering;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Gameplay.Player.Inventory;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Execution.Areas
{
    public sealed partial class OriginalAreaRegistryProcess
    {
        public void LoadOriginalSource()
        {
            Areas = [];
            {
                var targetAreas = Areas;
                var area = areaFactory.Create();
                area.Name = "area_0";
                area.Icon = "areas/intro";
                area.Interlude = true;
                area.CompleteScreenName = null;
                var sourceModes = new OriginalAreaModeData[3];
                var sourceMode0 = areaFactory.CreateMode();
                sourceMode0.PoemID = null;
                sourceMode0.Path = "0-Intro";
                sourceMode0.Checkpoints = null;
                sourceMode0.Inventory = RoomPlayerInventory.Prologue;
                sourceMode0.AudioState = new("event:/music/lvl0/intro", "event:/env/amb/00_prologue");
                sourceModes[0] = sourceMode0;
                area.Mode = sourceModes;
                area.TitleBaseColor = SourceHexColor.HexToColor("383838");
                area.TitleAccentColor = SourceHexColor.HexToColor("50AFAE");
                area.TitleTextColor = PackedColor.White;
                area.IntroType = PlayerIntroType.WalkInRight;
                area.Dreaming = false;
                area.ColorGrade = null;
                area.Wipe = delegate(ISourceRendererScene scene, bool wipeIn, Action onComplete)
                {
                    new CurtainWipePresentation(scene, wipeIn, onComplete);
                };
                area.DarknessAlpha = 0.05f;
                area.BloomBase = 0f;
                area.BloomStrength = 1f;
                area.OnLevelBegin = null;
                area.Jumpthru = "wood";
                targetAreas.Add(area);
            }
            {
                var targetAreas = Areas;
                var area = areaFactory.Create();
                area.Name = "area_1";
                area.Icon = "areas/city";
                area.Interlude = false;
                area.CanFullClear = true;
                area.CompleteScreenName = "ForsakenCity";
                area.CassetteCheckpointIndex = 2;
                var sourceModes = new OriginalAreaModeData[3];
                var sourceMode0 = areaFactory.CreateMode();
                sourceMode0.PoemID = "fc";
                sourceMode0.Path = "1-ForsakenCity";
                var sourceCheckpoints0 = new OriginalCheckpointData[2];
                var sourceCheckpoint0 = areaFactory.CreateCheckpoint("6", "checkpoint_1_0");
                sourceCheckpoints0[0] = sourceCheckpoint0;
                var sourceCheckpoint1 = areaFactory.CreateCheckpoint("9b", "checkpoint_1_1");
                sourceCheckpoints0[1] = sourceCheckpoint1;
                sourceMode0.Checkpoints = sourceCheckpoints0;
                sourceMode0.Inventory = RoomPlayerInventory.Default;
                sourceMode0.AudioState = new("event:/music/lvl1/main", "event:/env/amb/01_main");
                sourceModes[0] = sourceMode0;
                var sourceMode1 = areaFactory.CreateMode();
                sourceMode1.PoemID = "fcr";
                sourceMode1.Path = "1H-ForsakenCity";
                var sourceCheckpoints1 = new OriginalCheckpointData[2];
                var sourceCheckpoint2 = areaFactory.CreateCheckpoint("04", "checkpoint_1h_0");
                sourceCheckpoints1[0] = sourceCheckpoint2;
                var sourceCheckpoint3 = areaFactory.CreateCheckpoint("08", "checkpoint_1h_1");
                sourceCheckpoints1[1] = sourceCheckpoint3;
                sourceMode1.Checkpoints = sourceCheckpoints1;
                sourceMode1.Inventory = RoomPlayerInventory.Default;
                sourceMode1.AudioState =
                    new("event:/music/remix/01_forsaken_city", "event:/env/amb/01_main");
                sourceModes[1] = sourceMode1;
                var sourceMode2 = areaFactory.CreateMode();
                sourceMode2.Path = "1X-ForsakenCity";
                sourceMode2.Checkpoints = null;
                sourceMode2.Inventory = RoomPlayerInventory.Default;
                sourceMode2.AudioState =
                    new("event:/music/remix/01_forsaken_city", "event:/env/amb/01_main");
                sourceModes[2] = sourceMode2;
                area.Mode = sourceModes;
                area.TitleBaseColor = SourceHexColor.HexToColor("6c7c81");
                area.TitleAccentColor = SourceHexColor.HexToColor("2f344b");
                area.TitleTextColor = PackedColor.White;
                area.IntroType = PlayerIntroType.Jump;
                area.Dreaming = false;
                area.ColorGrade = null;
                area.Wipe = delegate(ISourceRendererScene scene, bool wipeIn, Action onComplete)
                {
                    new AngledWipePresentation(scene, wipeIn, onComplete);
                };
                area.DarknessAlpha = 0.05f;
                area.BloomBase = 0f;
                area.BloomStrength = 1f;
                area.OnLevelBegin = null;
                area.Jumpthru = "wood";
                area.CassseteNoteColor = SourceHexColor.HexToColor("33a9ee");
                area.CassetteSong = "event:/music/cassette/01_forsaken_city";
                targetAreas.Add(area);
            }
            {
                var targetAreas = Areas;
                var area = areaFactory.Create();
                area.Name = "area_2";
                area.Icon = "areas/oldsite";
                area.Interlude = false;
                area.CanFullClear = true;
                area.CompleteScreenName = "OldSite";
                area.CassetteCheckpointIndex = 0;
                var sourceModes = new OriginalAreaModeData[3];
                var sourceMode0 = areaFactory.CreateMode();
                sourceMode0.PoemID = "os";
                sourceMode0.Path = "2-OldSite";
                var sourceCheckpoints2 = new OriginalCheckpointData[2];
                var sourceCheckpoint4 =
                    areaFactory.CreateCheckpoint("3", "checkpoint_2_0", RoomPlayerInventory.Default, true);
                sourceCheckpoints2[0] = sourceCheckpoint4;
                var sourceCheckpoint5 = areaFactory.CreateCheckpoint("end_3", "checkpoint_2_1");
                sourceCheckpoints2[1] = sourceCheckpoint5;
                sourceMode0.Checkpoints = sourceCheckpoints2;
                sourceMode0.Inventory = RoomPlayerInventory.OldSite;
                sourceMode0.AudioState = new("event:/music/lvl2/beginning", "event:/env/amb/02_dream");
                sourceModes[0] = sourceMode0;
                var sourceMode1 = areaFactory.CreateMode();
                sourceMode1.PoemID = "osr";
                sourceMode1.Path = "2H-OldSite";
                var sourceCheckpoints3 = new OriginalCheckpointData[2];
                var sourceCheckpoint6 = areaFactory.CreateCheckpoint("03", "checkpoint_2h_0", null, true);
                sourceCheckpoints3[0] = sourceCheckpoint6;
                var sourceCheckpoint7 = areaFactory.CreateCheckpoint("08b", "checkpoint_2h_1", null, true);
                sourceCheckpoints3[1] = sourceCheckpoint7;
                sourceMode1.Checkpoints = sourceCheckpoints3;
                sourceMode1.Inventory = RoomPlayerInventory.Default;
                sourceMode1.AudioState =
                    new("event:/music/remix/02_old_site", "event:/env/amb/02_dream");
                sourceModes[1] = sourceMode1;
                var sourceMode2 = areaFactory.CreateMode();
                sourceMode2.Path = "2X-OldSite";
                sourceMode2.Checkpoints = null;
                sourceMode2.Inventory = RoomPlayerInventory.Default;
                sourceMode2.AudioState =
                    new("event:/music/remix/02_old_site", "event:/env/amb/02_dream");
                sourceModes[2] = sourceMode2;
                area.Mode = sourceModes;
                area.TitleBaseColor = SourceHexColor.HexToColor("247F35");
                area.TitleAccentColor = SourceHexColor.HexToColor("E4EF69");
                area.TitleTextColor = PackedColor.White;
                area.IntroType = PlayerIntroType.WakeUp;
                area.Dreaming = true;
                area.ColorGrade = "oldsite";
                area.Wipe = delegate(ISourceRendererScene scene, bool wipeIn, Action onComplete)
                {
                    new DreamWipePresentation(scene, wipeIn, onComplete);
                };
                area.DarknessAlpha = 0.15f;
                area.BloomBase = 0.5f;
                area.BloomStrength = 1f;
                area.OnLevelBegin = OriginalAreaLevelBeginCallbacks.OldSite;
                area.Jumpthru = "wood";
                area.CassseteNoteColor = SourceHexColor.HexToColor("33eea2");
                area.CassetteSong = "event:/music/cassette/02_old_site";
                targetAreas.Add(area);
            }
            {
                var targetAreas = Areas;
                var area = areaFactory.Create();
                area.Name = "area_3";
                area.Icon = "areas/resort";
                area.Interlude = false;
                area.CanFullClear = true;
                area.CompleteScreenName = "CelestialResort";
                area.CassetteCheckpointIndex = 2;
                var sourceModes = new OriginalAreaModeData[3];
                var sourceMode0 = areaFactory.CreateMode();
                sourceMode0.PoemID = "cr";
                sourceMode0.Path = "3-CelestialResort";
                var sourceCheckpoints4 = new OriginalCheckpointData[3];
                var sourceCheckpoint8 = areaFactory.CreateCheckpoint("08-a", "checkpoint_3_0");
                sourceCheckpoint8.AudioState =
                    new(
                        new EventTrackState("event:/music/lvl3/explore").SetProgress(3),
                        new("event:/env/amb/03_interior"));
                sourceCheckpoints4[0] = sourceCheckpoint8;
                var sourceCheckpoint9 = areaFactory.CreateCheckpoint("09-d", "checkpoint_3_1");
                sourceCheckpoint9.AudioState =
                    new(
                        new EventTrackState("event:/music/lvl3/clean").SetProgress(3),
                        new("event:/env/amb/03_interior"));
                sourceCheckpoints4[1] = sourceCheckpoint9;
                var sourceCheckpoint10 = areaFactory.CreateCheckpoint("00-d", "checkpoint_3_2");
                sourceCheckpoints4[2] = sourceCheckpoint10;
                sourceMode0.Checkpoints = sourceCheckpoints4;
                sourceMode0.Inventory = RoomPlayerInventory.Default;
                sourceMode0.AudioState = new("event:/music/lvl3/intro", "event:/env/amb/03_exterior");
                sourceModes[0] = sourceMode0;
                var sourceMode1 = areaFactory.CreateMode();
                sourceMode1.PoemID = "crr";
                sourceMode1.Path = "3H-CelestialResort";
                var sourceCheckpoints5 = new OriginalCheckpointData[3];
                var sourceCheckpoint11 = areaFactory.CreateCheckpoint("06", "checkpoint_3h_0");
                sourceCheckpoints5[0] = sourceCheckpoint11;
                var sourceCheckpoint12 = areaFactory.CreateCheckpoint("11", "checkpoint_3h_1");
                sourceCheckpoints5[1] = sourceCheckpoint12;
                var sourceCheckpoint13 = areaFactory.CreateCheckpoint("16", "checkpoint_3h_2");
                sourceCheckpoints5[2] = sourceCheckpoint13;
                sourceMode1.Checkpoints = sourceCheckpoints5;
                sourceMode1.Inventory = RoomPlayerInventory.Default;
                sourceMode1.AudioState =
                    new("event:/music/remix/03_resort", "event:/env/amb/03_exterior");
                sourceModes[1] = sourceMode1;
                var sourceMode2 = areaFactory.CreateMode();
                sourceMode2.Path = "3X-CelestialResort";
                sourceMode2.Checkpoints = null;
                sourceMode2.Inventory = RoomPlayerInventory.Default;
                sourceMode2.AudioState =
                    new("event:/music/remix/03_resort", "event:/env/amb/03_exterior");
                sourceModes[2] = sourceMode2;
                area.Mode = sourceModes;
                area.TitleBaseColor = SourceHexColor.HexToColor("b93c27");
                area.TitleAccentColor = SourceHexColor.HexToColor("ffdd42");
                area.TitleTextColor = PackedColor.White;
                area.IntroType = PlayerIntroType.WalkInRight;
                area.Dreaming = false;
                area.ColorGrade = null;
                area.Wipe = delegate(ISourceRendererScene scene, bool wipeIn, Action onComplete)
                {
                    new KeyDoorWipePresentation(scene, wipeIn, onComplete);
                };
                area.DarknessAlpha = 0.15f;
                area.BloomBase = 0f;
                area.BloomStrength = 1f;
                area.OnLevelBegin = null;
                area.Jumpthru = "wood";
                area.CassseteNoteColor = SourceHexColor.HexToColor("eed933");
                area.CassetteSong = "event:/music/cassette/03_resort";
                targetAreas.Add(area);
            }
            {
                var targetAreas = Areas;
                var area = areaFactory.Create();
                area.Name = "area_4";
                area.Icon = "areas/cliffside";
                area.Interlude = false;
                area.CanFullClear = true;
                area.CompleteScreenName = "Cliffside";
                area.CassetteCheckpointIndex = 0;
                area.TitleBaseColor = SourceHexColor.HexToColor("FF7F83");
                area.TitleAccentColor = SourceHexColor.HexToColor("6D54B7");
                area.TitleTextColor = PackedColor.White;
                var sourceModes = new OriginalAreaModeData[3];
                var sourceMode0 = areaFactory.CreateMode();
                sourceMode0.PoemID = "cs";
                sourceMode0.Path = "4-GoldenRidge";
                var sourceCheckpoints6 = new OriginalCheckpointData[3];
                var sourceCheckpoint14 = areaFactory.CreateCheckpoint("b-00", "checkpoint_4_0");
                sourceCheckpoints6[0] = sourceCheckpoint14;
                var sourceCheckpoint15 = areaFactory.CreateCheckpoint("c-00", "checkpoint_4_1");
                sourceCheckpoints6[1] = sourceCheckpoint15;
                var sourceCheckpoint16 = areaFactory.CreateCheckpoint("d-00", "checkpoint_4_2");
                sourceCheckpoints6[2] = sourceCheckpoint16;
                sourceMode0.Checkpoints = sourceCheckpoints6;
                sourceMode0.Inventory = RoomPlayerInventory.Default;
                sourceMode0.AudioState = new("event:/music/lvl4/main", "event:/env/amb/04_main");
                sourceModes[0] = sourceMode0;
                var sourceMode1 = areaFactory.CreateMode();
                sourceMode1.PoemID = "csr";
                sourceMode1.Path = "4H-GoldenRidge";
                var sourceCheckpoints7 = new OriginalCheckpointData[3];
                var sourceCheckpoint17 = areaFactory.CreateCheckpoint("b-00", "checkpoint_4h_0");
                sourceCheckpoints7[0] = sourceCheckpoint17;
                var sourceCheckpoint18 = areaFactory.CreateCheckpoint("c-00", "checkpoint_4h_1");
                sourceCheckpoints7[1] = sourceCheckpoint18;
                var sourceCheckpoint19 = areaFactory.CreateCheckpoint("d-00", "checkpoint_4h_2");
                sourceCheckpoints7[2] = sourceCheckpoint19;
                sourceMode1.Checkpoints = sourceCheckpoints7;
                sourceMode1.Inventory = RoomPlayerInventory.Default;
                sourceMode1.AudioState =
                    new("event:/music/remix/04_cliffside", "event:/env/amb/04_main");
                sourceModes[1] = sourceMode1;
                var sourceMode2 = areaFactory.CreateMode();
                sourceMode2.Path = "4X-GoldenRidge";
                sourceMode2.Checkpoints = null;
                sourceMode2.Inventory = RoomPlayerInventory.Default;
                sourceMode2.AudioState =
                    new("event:/music/remix/04_cliffside", "event:/env/amb/04_main");
                sourceModes[2] = sourceMode2;
                area.Mode = sourceModes;
                area.IntroType = PlayerIntroType.WalkInRight;
                area.Dreaming = false;
                area.ColorGrade = null;
                area.Wipe = delegate(ISourceRendererScene scene, bool wipeIn, Action onComplete)
                {
                    new WindWipePresentation(scene, wipeIn, onComplete);
                };
                area.DarknessAlpha = 0.1f;
                area.BloomBase = 0.25f;
                area.BloomStrength = 1f;
                area.OnLevelBegin = null;
                area.Jumpthru = "cliffside";
                area.Spike = "cliffside";
                area.CrumbleBlock = "cliffside";
                area.WoodPlatform = "cliffside";
                area.CassseteNoteColor = SourceHexColor.HexToColor("eb4bd9");
                area.CassetteSong = "event:/music/cassette/04_cliffside";
                targetAreas.Add(area);
            }
            {
                var targetAreas = Areas;
                var area = areaFactory.Create();
                area.Name = "area_5";
                area.Icon = "areas/temple";
                area.Interlude = false;
                area.CanFullClear = true;
                area.CompleteScreenName = "MirrorTemple";
                area.CassetteCheckpointIndex = 1;
                var sourceModes = new OriginalAreaModeData[3];
                var sourceMode0 = areaFactory.CreateMode();
                sourceMode0.PoemID = "t";
                sourceMode0.Path = "5-MirrorTemple";
                var sourceCheckpoints8 = new OriginalCheckpointData[4];
                var sourceCheckpoint20 = areaFactory.CreateCheckpoint("b-00", "checkpoint_5_0");
                sourceCheckpoints8[0] = sourceCheckpoint20;
                var sourceCheckpoint21 = areaFactory.CreateCheckpoint("c-00", "checkpoint_5_1", null, true,
                    new("event:/music/lvl5/middle_temple", "event:/env/amb/05_interior_dark"));
                sourceCheckpoints8[1] = sourceCheckpoint21;
                var sourceCheckpoint22 = areaFactory.CreateCheckpoint("d-00", "checkpoint_5_2", null, true,
                    new("event:/music/lvl5/middle_temple", "event:/env/amb/05_interior_dark"));
                sourceCheckpoints8[2] = sourceCheckpoint22;
                var sourceCheckpoint23 = areaFactory.CreateCheckpoint("e-00", "checkpoint_5_3", null, true,
                    new("event:/music/lvl5/mirror", "event:/env/amb/05_interior_dark"));
                sourceCheckpoints8[3] = sourceCheckpoint23;
                sourceMode0.Checkpoints = sourceCheckpoints8;
                sourceMode0.Inventory = RoomPlayerInventory.Default;
                sourceMode0.AudioState =
                    new("event:/music/lvl5/normal", "event:/env/amb/05_interior_main");
                sourceModes[0] = sourceMode0;
                var sourceMode1 = areaFactory.CreateMode();
                sourceMode1.PoemID = "tr";
                sourceMode1.Path = "5H-MirrorTemple";
                var sourceCheckpoints9 = new OriginalCheckpointData[3];
                var sourceCheckpoint24 = areaFactory.CreateCheckpoint("b-00", "checkpoint_5h_0");
                sourceCheckpoints9[0] = sourceCheckpoint24;
                var sourceCheckpoint25 = areaFactory.CreateCheckpoint("c-00", "checkpoint_5h_1");
                sourceCheckpoints9[1] = sourceCheckpoint25;
                var sourceCheckpoint26 = areaFactory.CreateCheckpoint("d-00", "checkpoint_5h_2");
                sourceCheckpoints9[2] = sourceCheckpoint26;
                sourceMode1.Checkpoints = sourceCheckpoints9;
                sourceMode1.Inventory = RoomPlayerInventory.Default;
                sourceMode1.AudioState =
                    new("event:/music/remix/05_mirror_temple", "event:/env/amb/05_interior_main");
                sourceModes[1] = sourceMode1;
                var sourceMode2 = areaFactory.CreateMode();
                sourceMode2.Path = "5X-MirrorTemple";
                sourceMode2.Checkpoints = null;
                sourceMode2.Inventory = RoomPlayerInventory.Default;
                sourceMode2.AudioState =
                    new("event:/music/remix/05_mirror_temple", "event:/env/amb/05_interior_main");
                sourceModes[2] = sourceMode2;
                area.Mode = sourceModes;
                area.TitleBaseColor = SourceHexColor.HexToColor("8314bc");
                area.TitleAccentColor = SourceHexColor.HexToColor("df72f9");
                area.TitleTextColor = PackedColor.White;
                area.IntroType = PlayerIntroType.WakeUp;
                area.Dreaming = false;
                area.ColorGrade = null;
                area.Wipe = delegate(ISourceRendererScene scene, bool wipeIn, Action onComplete)
                {
                    new DropWipePresentation(scene, wipeIn, onComplete);
                };
                area.DarknessAlpha = 0.15f;
                area.BloomBase = 0f;
                area.BloomStrength = 1f;
                area.OnLevelBegin = OriginalAreaLevelBeginCallbacks.MirrorTemple;
                area.Jumpthru = "temple";
                area.CassseteNoteColor = SourceHexColor.HexToColor("5a56e6");
                area.CobwebColor = [SourceHexColor.HexToColor("9f2166")];
                area.CassetteSong = "event:/music/cassette/05_mirror_temple";
                targetAreas.Add(area);
            }
            {
                var targetAreas = Areas;
                var area = areaFactory.Create();
                area.Name = "area_6";
                area.Icon = "areas/reflection";
                area.Interlude = false;
                area.CanFullClear = true;
                area.CompleteScreenName = "Fall";
                area.CassetteCheckpointIndex = 2;
                var sourceModes = new OriginalAreaModeData[3];
                var sourceMode0 = areaFactory.CreateMode();
                sourceMode0.PoemID = "tf";
                sourceMode0.Path = "6-Reflection";
                var sourceCheckpoints10 = new OriginalCheckpointData[5];
                var sourceCheckpoint27 = areaFactory.CreateCheckpoint("00", "checkpoint_6_0");
                sourceCheckpoints10[0] = sourceCheckpoint27;
                var sourceCheckpoint28 = areaFactory.CreateCheckpoint("04", "checkpoint_6_1");
                sourceCheckpoints10[1] = sourceCheckpoint28;
                var sourceCheckpoint29 = areaFactory.CreateCheckpoint("b-00", "checkpoint_6_2");
                sourceCheckpoints10[2] = sourceCheckpoint29;
                var sourceCheckpoint30 = areaFactory.CreateCheckpoint("boss-00", "checkpoint_6_3");
                sourceCheckpoints10[3] = sourceCheckpoint30;
                var sourceCheckpoint31 =
                    areaFactory.CreateCheckpoint("after-00", "checkpoint_6_4", RoomPlayerInventory.CH6End);
                sourceCheckpoint31.Flags = ["badeline_connection"];
                sourceCheckpoint31.AudioState = new(
                    new EventTrackState("event:/music/lvl6/badeline_acoustic").Param(
                        "levelup",
                        2f), new("event:/env/amb/06_main"));
                sourceCheckpoints10[4] = sourceCheckpoint31;
                sourceMode0.Checkpoints = sourceCheckpoints10;
                sourceMode0.Inventory = RoomPlayerInventory.Default;
                sourceMode0.AudioState = new("event:/music/lvl6/main", "event:/env/amb/06_main");
                sourceModes[0] = sourceMode0;
                var sourceMode1 = areaFactory.CreateMode();
                sourceMode1.PoemID = "tfr";
                sourceMode1.Path = "6H-Reflection";
                var sourceCheckpoints11 = new OriginalCheckpointData[3];
                var sourceCheckpoint32 = areaFactory.CreateCheckpoint("b-00", "checkpoint_6h_0");
                sourceCheckpoints11[0] = sourceCheckpoint32;
                var sourceCheckpoint33 = areaFactory.CreateCheckpoint("c-00", "checkpoint_6h_1");
                sourceCheckpoints11[1] = sourceCheckpoint33;
                var sourceCheckpoint34 = areaFactory.CreateCheckpoint("d-00", "checkpoint_6h_2");
                sourceCheckpoints11[2] = sourceCheckpoint34;
                sourceMode1.Checkpoints = sourceCheckpoints11;
                sourceMode1.Inventory = RoomPlayerInventory.Default;
                sourceMode1.AudioState =
                    new("event:/music/remix/06_reflection", "event:/env/amb/06_main");
                sourceModes[1] = sourceMode1;
                var sourceMode2 = areaFactory.CreateMode();
                sourceMode2.Path = "6X-Reflection";
                sourceMode2.Checkpoints = null;
                sourceMode2.Inventory = RoomPlayerInventory.Default;
                sourceMode2.AudioState =
                    new("event:/music/remix/06_reflection", "event:/env/amb/06_main");
                sourceModes[2] = sourceMode2;
                area.Mode = sourceModes;
                area.TitleBaseColor = SourceHexColor.HexToColor("359FE0");
                area.TitleAccentColor = SourceHexColor.HexToColor("3C5CBC");
                area.TitleTextColor = PackedColor.White;
                area.IntroType = PlayerIntroType.None;
                area.Dreaming = false;
                area.ColorGrade = "reflection";
                area.Wipe = delegate(ISourceRendererScene scene, bool wipeIn, Action onComplete)
                {
                    new FallWipePresentation(scene, wipeIn, onComplete);
                };
                area.DarknessAlpha = 0.2f;
                area.BloomBase = 0.2f;
                area.BloomStrength = 1f;
                area.OnLevelBegin = null;
                area.Jumpthru = "reflection";
                area.Spike = "reflection";
                area.CassseteNoteColor = SourceHexColor.HexToColor("56e6dd");
                area.CassetteSong = "event:/music/cassette/06_reflection";
                targetAreas.Add(area);
            }
            {
                var targetAreas = Areas;
                var area = areaFactory.Create();
                area.Name = "area_7";
                area.Icon = "areas/summit";
                area.Interlude = false;
                area.CanFullClear = true;
                area.CompleteScreenName = "Summit";
                area.CassetteCheckpointIndex = 3;
                var sourceModes = new OriginalAreaModeData[3];
                var sourceMode0 = areaFactory.CreateMode();
                sourceMode0.PoemID = "ts";
                sourceMode0.Path = "7-Summit";
                var sourceCheckpoints12 = new OriginalCheckpointData[6];
                var sourceCheckpoint35 = areaFactory.CreateCheckpoint("b-00", "checkpoint_7_0", null, false,
                    new(
                        new EventTrackState("event:/music/lvl7/main").SetProgress(1), null));
                sourceCheckpoints12[0] = sourceCheckpoint35;
                var sourceCheckpoint36 = areaFactory.CreateCheckpoint("c-00", "checkpoint_7_1", null, false,
                    new(
                        new EventTrackState("event:/music/lvl7/main").SetProgress(2), null));
                sourceCheckpoints12[1] = sourceCheckpoint36;
                var sourceCheckpoint37 = areaFactory.CreateCheckpoint("d-00", "checkpoint_7_2", null, false,
                    new(
                        new EventTrackState("event:/music/lvl7/main").SetProgress(3), null));
                sourceCheckpoints12[2] = sourceCheckpoint37;
                var sourceCheckpoint38 = areaFactory.CreateCheckpoint("e-00b", "checkpoint_7_3", null, false,
                    new(
                        new EventTrackState("event:/music/lvl7/main").SetProgress(4), null));
                sourceCheckpoints12[3] = sourceCheckpoint38;
                var sourceCheckpoint39 = areaFactory.CreateCheckpoint("f-00", "checkpoint_7_4", null, false,
                    new(
                        new EventTrackState("event:/music/lvl7/main").SetProgress(5), null));
                sourceCheckpoints12[4] = sourceCheckpoint39;
                var sourceCheckpoint40 = areaFactory.CreateCheckpoint("g-00", "checkpoint_7_5", null, false,
                    new("event:/music/lvl7/final_ascent", null));
                sourceCheckpoints12[5] = sourceCheckpoint40;
                sourceMode0.Checkpoints = sourceCheckpoints12;
                sourceMode0.Inventory = RoomPlayerInventory.TheSummit;
                sourceMode0.AudioState = new("event:/music/lvl7/main", null);
                sourceModes[0] = sourceMode0;
                var sourceMode1 = areaFactory.CreateMode();
                sourceMode1.PoemID = "tsr";
                sourceMode1.Path = "7H-Summit";
                var sourceCheckpoints13 = new OriginalCheckpointData[6];
                var sourceCheckpoint41 = areaFactory.CreateCheckpoint("b-00", "checkpoint_7H_0");
                sourceCheckpoints13[0] = sourceCheckpoint41;
                var sourceCheckpoint42 = areaFactory.CreateCheckpoint("c-01", "checkpoint_7H_1");
                sourceCheckpoints13[1] = sourceCheckpoint42;
                var sourceCheckpoint43 = areaFactory.CreateCheckpoint("d-00", "checkpoint_7H_2");
                sourceCheckpoints13[2] = sourceCheckpoint43;
                var sourceCheckpoint44 = areaFactory.CreateCheckpoint("e-00", "checkpoint_7H_3");
                sourceCheckpoints13[3] = sourceCheckpoint44;
                var sourceCheckpoint45 = areaFactory.CreateCheckpoint("f-00", "checkpoint_7H_4");
                sourceCheckpoints13[4] = sourceCheckpoint45;
                var sourceCheckpoint46 = areaFactory.CreateCheckpoint("g-00", "checkpoint_7H_5");
                sourceCheckpoints13[5] = sourceCheckpoint46;
                sourceMode1.Checkpoints = sourceCheckpoints13;
                sourceMode1.Inventory = RoomPlayerInventory.TheSummit;
                sourceMode1.AudioState = new("event:/music/remix/07_summit", null);
                sourceModes[1] = sourceMode1;
                var sourceMode2 = areaFactory.CreateMode();
                sourceMode2.Path = "7X-Summit";
                sourceMode2.Checkpoints = null;
                sourceMode2.Inventory = RoomPlayerInventory.TheSummit;
                sourceMode2.AudioState = new("event:/music/remix/07_summit", null);
                sourceModes[2] = sourceMode2;
                area.Mode = sourceModes;
                area.TitleBaseColor = SourceHexColor.HexToColor("FFD819");
                area.TitleAccentColor = SourceHexColor.HexToColor("197DB7");
                area.TitleTextColor = PackedColor.Black;
                area.IntroType = PlayerIntroType.None;
                area.Dreaming = false;
                area.ColorGrade = null;
                area.Wipe = delegate(ISourceRendererScene scene, bool wipeIn, Action onComplete)
                {
                    new MountainWipePresentation(scene, wipeIn, onComplete);
                };
                area.DarknessAlpha = 0.05f;
                area.BloomBase = 0.2f;
                area.BloomStrength = 1f;
                area.OnLevelBegin = null;
                area.Jumpthru = "temple";
                area.Spike = "outline";
                area.CassseteNoteColor = SourceHexColor.HexToColor("e69156");
                area.CassetteSong = "event:/music/cassette/07_summit";
                targetAreas.Add(area);
            }
            {
                var targetAreas = Areas;
                var area = areaFactory.Create();
                area.Name = "area_8";
                area.Icon = "areas/intro";
                area.Interlude = true;
                area.CompleteScreenName = null;
                area.CassetteCheckpointIndex = 1;
                var sourceModes = new OriginalAreaModeData[3];
                var sourceMode0 = areaFactory.CreateMode();
                sourceMode0.PoemID = null;
                sourceMode0.Path = "8-Epilogue";
                sourceMode0.Checkpoints = null;
                sourceMode0.Inventory = RoomPlayerInventory.TheSummit;
                sourceMode0.AudioState = new("event:/music/lvl8/main", "event:/env/amb/00_prologue");
                sourceModes[0] = sourceMode0;
                area.Mode = sourceModes;
                area.TitleBaseColor = SourceHexColor.HexToColor("383838");
                area.TitleAccentColor = SourceHexColor.HexToColor("50AFAE");
                area.TitleTextColor = PackedColor.White;
                area.IntroType = PlayerIntroType.WalkInLeft;
                area.Dreaming = false;
                area.ColorGrade = null;
                area.Wipe = delegate(ISourceRendererScene scene, bool wipeIn, Action onComplete)
                {
                    new CurtainWipePresentation(scene, wipeIn, onComplete);
                };
                area.DarknessAlpha = 0.05f;
                area.BloomBase = 0f;
                area.BloomStrength = 1f;
                area.OnLevelBegin = null;
                area.Jumpthru = "wood";
                targetAreas.Add(area);
            }
            {
                var targetAreas = Areas;
                var area = areaFactory.Create();
                area.Name = "area_9";
                area.Icon = "areas/core";
                area.Interlude = false;
                area.CanFullClear = true;
                area.CompleteScreenName = "Core";
                area.CassetteCheckpointIndex = 3;
                var sourceModes = new OriginalAreaModeData[3];
                var sourceMode0 = areaFactory.CreateMode();
                sourceMode0.PoemID = "mc";
                sourceMode0.Path = "9-Core";
                var sourceCheckpoints14 = new OriginalCheckpointData[3];
                var sourceCheckpoint47 = areaFactory.CreateCheckpoint("a-00", "checkpoint_8_0");
                sourceCheckpoints14[0] = sourceCheckpoint47;
                var sourceCheckpoint48 = areaFactory.CreateCheckpoint("c-00", "checkpoint_8_1");
                sourceCheckpoint48.CoreMode = RoomCoreMode.Cold;
                sourceCheckpoints14[1] = sourceCheckpoint48;
                var sourceCheckpoint49 = areaFactory.CreateCheckpoint("d-00", "checkpoint_8_2");
                sourceCheckpoints14[2] = sourceCheckpoint49;
                sourceMode0.Checkpoints = sourceCheckpoints14;
                sourceMode0.Inventory = RoomPlayerInventory.Core;
                sourceMode0.AudioState = new("event:/music/lvl9/main", "event:/env/amb/09_main");
                sourceMode0.IgnoreLevelAudioLayerData = true;
                sourceModes[0] = sourceMode0;
                var sourceMode1 = areaFactory.CreateMode();
                sourceMode1.PoemID = "mcr";
                sourceMode1.Path = "9H-Core";
                var sourceCheckpoints15 = new OriginalCheckpointData[3];
                var sourceCheckpoint50 = areaFactory.CreateCheckpoint("a-00", "checkpoint_8H_0");
                sourceCheckpoints15[0] = sourceCheckpoint50;
                var sourceCheckpoint51 = areaFactory.CreateCheckpoint("b-00", "checkpoint_8H_1");
                sourceCheckpoints15[1] = sourceCheckpoint51;
                var sourceCheckpoint52 = areaFactory.CreateCheckpoint("c-01", "checkpoint_8H_2");
                sourceCheckpoints15[2] = sourceCheckpoint52;
                sourceMode1.Checkpoints = sourceCheckpoints15;
                sourceMode1.Inventory = RoomPlayerInventory.Core;
                sourceMode1.AudioState = new("event:/music/remix/09_core", "event:/env/amb/09_main");
                sourceModes[1] = sourceMode1;
                var sourceMode2 = areaFactory.CreateMode();
                sourceMode2.Path = "9X-Core";
                sourceMode2.Checkpoints = null;
                sourceMode2.Inventory = RoomPlayerInventory.Core;
                sourceMode2.AudioState = new("event:/music/remix/09_core", "event:/env/amb/09_main");
                sourceModes[2] = sourceMode2;
                area.Mode = sourceModes;
                area.TitleBaseColor = SourceHexColor.HexToColor("761008");
                area.TitleAccentColor = SourceHexColor.HexToColor("E0201D");
                area.TitleTextColor = PackedColor.White;
                area.IntroType = PlayerIntroType.WalkInRight;
                area.Dreaming = false;
                area.ColorGrade = null;
                area.Wipe = delegate(ISourceRendererScene scene, bool wipeIn, Action onComplete)
                {
                    new HeartWipePresentation(scene, wipeIn, onComplete);
                };
                area.DarknessAlpha = 0.05f;
                area.BloomBase = 0f;
                area.BloomStrength = 1f;
                area.OnLevelBegin = null;
                area.Jumpthru = "core";
                area.CassseteNoteColor = SourceHexColor.HexToColor("e6566a");
                area.CassetteSong = "event:/music/cassette/09_core";
                area.CoreMode = RoomCoreMode.Hot;
                targetAreas.Add(area);
            }
            {
                var targetAreas = Areas;
                var area = areaFactory.Create();
                area.Name = "area_10";
                area.Icon = "areas/farewell";
                area.Interlude = false;
                area.CanFullClear = false;
                area.IsFinal = true;
                area.CompleteScreenName = "Core";
                area.CassetteCheckpointIndex = -1;
                var sourceModes = new OriginalAreaModeData[1];
                var sourceMode0 = areaFactory.CreateMode();
                sourceMode0.PoemID = "fw";
                sourceMode0.Path = "LostLevels";
                var sourceCheckpoints16 = new OriginalCheckpointData[8];
                var sourceCheckpoint53 = areaFactory.CreateCheckpoint("a-00", "checkpoint_9_0", null, false,
                    new(
                        new EventTrackState("event:/new_content/music/lvl10/part01")
                            .SetProgress(1), null));
                sourceCheckpoints16[0] = sourceCheckpoint53;
                var sourceCheckpoint54 = areaFactory.CreateCheckpoint("c-00", "checkpoint_9_1", null, false,
                    new(
                        new EventTrackState("event:/new_content/music/lvl10/part01")
                            .SetProgress(1), null));
                sourceCheckpoints16[1] = sourceCheckpoint54;
                var sourceCheckpoint55 = areaFactory.CreateCheckpoint("e-00z", "checkpoint_9_2", null, false,
                    new(
                        new EventTrackState("event:/new_content/music/lvl10/part02"), null));
                sourceCheckpoints16[2] = sourceCheckpoint55;
                var sourceCheckpoint56 = areaFactory.CreateCheckpoint("f-door", "checkpoint_9_3", null, false,
                    new(
                        new EventTrackState(
                            "event:/new_content/music/lvl10/intermission_heartgroove"), null));
                sourceCheckpoints16[3] = sourceCheckpoint56;
                var sourceCheckpoint57 = areaFactory.CreateCheckpoint("h-00b", "checkpoint_9_4", null, false,
                    new(
                        new EventTrackState("event:/new_content/music/lvl10/part03"), null));
                sourceCheckpoints16[4] = sourceCheckpoint57;
                var sourceCheckpoint58 = areaFactory.CreateCheckpoint("i-00", "checkpoint_9_5", null, false,
                    new(
                        new EventTrackState("event:/new_content/music/lvl10/cassette_rooms")
                            .Param("sixteenth_note", 7f), null));
                sourceCheckpoint58.ColorGrade = "feelingdown";
                sourceCheckpoints16[5] = sourceCheckpoint58;
                var sourceCheckpoint59 = areaFactory.CreateCheckpoint("j-00", "checkpoint_9_6", null, false,
                    new(
                        new EventTrackState("event:/new_content/music/lvl10/cassette_rooms")
                            .Param("sixteenth_note", 7f).SetProgress(3), null));
                sourceCheckpoint59.ColorGrade = "feelingdown";
                sourceCheckpoints16[6] = sourceCheckpoint59;
                var sourceCheckpoint60 = areaFactory.CreateCheckpoint("j-16", "checkpoint_9_7", null, false,
                    new(
                        new EventTrackState("event:/new_content/music/lvl10/final_run")
                            .SetProgress(3), null));
                sourceCheckpoints16[7] = sourceCheckpoint60;
                sourceMode0.Checkpoints = sourceCheckpoints16;
                sourceMode0.Inventory = RoomPlayerInventory.Farewell;
                sourceMode0.AudioState =
                    new(
                        new EventTrackState("event:/new_content/music/lvl10/part01")
                            .SetProgress(1),
                        new("event:/env/amb/00_prologue"));
                sourceModes[0] = sourceMode0;
                area.Mode = sourceModes;
                area.TitleBaseColor = SourceHexColor.HexToColor("240d7c");
                area.TitleAccentColor = SourceHexColor.HexToColor("FF6AA9");
                area.TitleTextColor = PackedColor.White;
                area.IntroType = PlayerIntroType.ThinkForABit;
                area.Dreaming = false;
                area.ColorGrade = null;
                area.Wipe = delegate(ISourceRendererScene scene, bool wipeIn, Action onComplete)
                {
                    new StarfieldWipePresentation(scene, wipeIn, onComplete);
                };
                area.DarknessAlpha = 0.05f;
                area.BloomBase = 0.5f;
                area.BloomStrength = 1f;
                area.OnLevelBegin = null;
                area.Jumpthru = "wood";
                area.CassseteNoteColor = SourceHexColor.HexToColor("e6566a");
                area.CassetteSong = null;
                area.CobwebColor =
                [
                    SourceHexColor.HexToColor("42c192"),
                    SourceHexColor.HexToColor("af36a8"),
                    SourceHexColor.HexToColor("3474a6"),
                ];
                targetAreas.Add(area);
            }
            var num = Enum.GetNames(typeof(OriginalAreaMode)).Length;
            for (var num2 = 0; num2 < Areas.Count; num2++)
            {
                Areas[num2].ID = num2;
                Areas[num2].Mode[0].MapData =
                    new(areaKeys.Create(num2), this, mapStartPolicy, mapLoadPolicy);
                if (interludePolicy.IsInterlude(Areas[num2])) continue;

                for (var num3 = 1; num3 < num; num3++)
                    if (Areas[num2].HasMode(num3))
                        Areas[num2].Mode[num3].MapData = new(areaKeys.Create(num2, num3), this,
                            mapStartPolicy, mapLoadPolicy);
            }

            mountainViews.MountainViews.ReloadMountainViews();
        }
    }
}
