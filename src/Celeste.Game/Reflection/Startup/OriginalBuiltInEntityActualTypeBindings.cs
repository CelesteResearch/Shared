using System;
using System.Reflection;
using Celeste.Game.Components.Talking;
using Celeste.Game.Content.Maps.Backdrops.Stars;
using Celeste.Game.Credits.Triggers;
using Celeste.Game.Entities.Birds;
using Celeste.Game.Entities.Collectibles.Hearts;
using Celeste.Game.Entities.Decoration.Cobwebs;
using Celeste.Game.Entities.Diagnostics.AudioTesting;
using Celeste.Game.Entities.Hazards.Sliders;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Entities.Npcs.Granny;
using Celeste.Game.Entities.Npcs.Oshiro;
using Celeste.Game.Entities.Npcs.Theo;
using Celeste.Game.Entities.Npcs.Theo.Resort;
using Celeste.Game.Entities.Triggers.Camera;
using Celeste.Game.Execution.LevelLoader.Terrain;
using Celeste.Game.Gameplay.Assists.Solids;
using Celeste.Game.Gameplay.Collectibles.Strawberries.BlockFields;
using Celeste.Game.Gameplay.Collectibles.Strawberries.Triggers;
using Celeste.Game.Gameplay.Enemies.Badeline.Chasers;
using Celeste.Game.Gameplay.Environment.Lava.Barriers;
using Celeste.Game.Gameplay.Environment.Mirrors;
using Celeste.Game.Gameplay.Environment.Water;
using Celeste.Game.Gameplay.Platforms.Jumpthrus;
using Celeste.Game.Gameplay.Walls.Conditional;
using Celeste.Game.Gameplay.Walls.Solids;
using Celeste.Game.Menus.Controls;
using Celeste.Game.Presentation.Backdrops.Tentacles;
using Celeste.Game.Stories.CelestialResort;
using Celeste.Game.Stories.Epilogue;
using Celeste.Game.Stories.GoldenRidge;
using Celeste.Game.Stories.Temple;
using Celeste.Game.UI.Menus.Buttons;
using Celeste.Game.UI.Menus.Buttons.Title;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Enemies.Seeker;
using Celeste.Simulation.Gameplay.Hazards.Spikes;
using Celeste.Simulation.Presentation.Backdrops.Parallax;
using Celeste.Simulation.Presentation.Backdrops.Stars;
using Celeste.Simulation.Presentation.Backdrops.Weather.Rain;
using Celeste.Simulation.Presentation.Backdrops.Weather.Snow;
using Celeste.Simulation.Presentation.Player.Death;
using Celeste.Simulation.Rendering;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Game.Reflection.Startup
{
    public static class OriginalBuiltInEntityActualTypeBindings
    {
        public static void Register(SceneEntityCatalog catalog)
        {
            Bind(catalog,
                typeof(ParallaxBackdropPresentation),
                "Celeste.Parallax");
            Bind(catalog,
                typeof(RainBackdropPresentation),
                "Celeste.RainFG");
            Bind(catalog,
                typeof(WindSnowBackdropPresentation),
                "Celeste.WindSnowFG");
            Bind(catalog, typeof(CoreStarsBackdropPresentation),
                "Celeste.CoreStarsFG");
            Bind(catalog, typeof(StarfieldBackdropPresentation),
                "Celeste.Starfield");
            Bind(catalog, typeof(TextMenuPresentation), "Celeste.TextMenu");
            Bind(catalog, typeof(TextMenuPresentation.Item),
                "Celeste.TextMenu+Item");
            Bind(catalog, typeof(TextMenuPresentation.Button),
                "Celeste.TextMenu+Button");
            Bind(catalog, typeof(PlayerDeathPresentation),
                "Celeste.PlayerDeadBody");
            Bind(catalog, typeof(SolidInvincibilityOutlineState),
                "Celeste.SolidOnInvinciblePlayer+Outline");
            Bind(catalog, typeof(MenuButtonPresentation), "Celeste.MenuButton");
            Bind(catalog, typeof(MainMenuClimbPresentation),
                "Celeste.MainMenuClimb");
            Bind(catalog, typeof(MainMenuSmallButtonPresentation),
                "Celeste.MainMenuSmallButton");
            Bind(catalog, typeof(PlayerDashAssistPresentation),
                "Celeste.PlayerDashAssist");
            Bind(catalog, typeof(SeekerBarrierRendererState),
                "Celeste.SeekerBarrierRenderer");
            Bind(catalog, typeof(OriginalBackgroundTiles),
                "Celeste.BackgroundTiles");
            Bind(catalog, typeof(OriginalSolidTiles),
                "Celeste.SolidTiles");
            Bind(catalog, typeof(OriginalWaterSurface),
                "Celeste.WaterSurface");
            Bind(catalog, typeof(BirdNpcState), "Celeste.BirdNPC");
            Bind(catalog,
                typeof(OriginalBlockFieldState),
                "Celeste.BlockField");
            Bind(catalog, typeof(MirrorPortalCutscene),
                "Celeste.CS04_MirrorPortal");
            Bind(catalog, typeof(CS05TheoEntranceState),
                "Celeste.CS05_Entrance");
            Bind(catalog,
                typeof(OriginalCameraAdvanceTargetTriggerState),
                "Celeste.CameraAdvanceTargetTrigger");
            Bind(catalog, typeof(OriginalCameraOffsetTriggerState),
                "Celeste.CameraOffsetTrigger");
            Bind(catalog, typeof(OriginalCameraTargetTriggerState),
                "Celeste.CameraTargetTrigger");
            Bind(catalog, typeof(ChaserBarrierState),
                "Celeste.ChaserBarrier");
            Bind(catalog, typeof(OriginalCobwebState),
                "Celeste.Cobweb");
            Bind(catalog, typeof(CreditsTriggerState),
                "Celeste.CreditsTrigger");
            Bind(catalog, typeof(OriginalDreamHeartGemState),
                "Celeste.DreamHeartGem");
            Bind(catalog, typeof(OriginalFakeHeartState),
                "Celeste.FakeHeart");
            Bind(catalog, typeof(OriginalFireBarrierState),
                "Celeste.FireBarrier");
            Bind(catalog, typeof(GlassBlockState), "Celeste.GlassBlock");
            Bind(catalog,
                typeof(
                    GoldBerryCollectTriggerState),
                "Celeste.GoldBerryCollectTrigger");
            Bind(catalog, typeof(GoldenBlockState),
                "Celeste.GoldenBlock");
            Bind(catalog, typeof(OriginalIceBlockState),
                "Celeste.IceBlock");
            Bind(catalog, typeof(JumpthruPlatformState),
                "Celeste.JumpthruPlatform");
            Bind(catalog, typeof(OriginalNpcState), "Celeste.NPC");
            Bind(catalog, typeof(OriginalPrologueGrannyState),
                "Celeste.NPC00_Granny");
            Bind(catalog, typeof(OriginalOshiroBreakdownState),
                "Celeste.NPC03_Oshiro_Breakdown");
            Bind(catalog, typeof(NpcOshiroClutterState),
                "Celeste.NPC03_Oshiro_Cluttter");
            Bind(catalog, typeof(OriginalOshiroHallway1State),
                "Celeste.NPC03_Oshiro_Hallway1");
            Bind(catalog, typeof(OriginalOshiroHallway2State),
                "Celeste.NPC03_Oshiro_Hallway2");
            Bind(catalog, typeof(OriginalOshiroLobbyState),
                "Celeste.NPC03_Oshiro_Lobby");
            Bind(catalog, typeof(OriginalOshiroRooftopState),
                "Celeste.NPC03_Oshiro_Rooftop");
            Bind(catalog, typeof(OriginalOshiroSuiteState),
                "Celeste.NPC03_Oshiro_Suite");
            Bind(catalog, typeof(OriginalTheoEscapingState),
                "Celeste.NPC03_Theo_Escaping");
            Bind(catalog, typeof(OriginalTheoVentsState),
                "Celeste.NPC03_Theo_Vents");
            Bind(catalog, typeof(OriginalCliffsideGrannyState),
                "Celeste.NPC04_Granny");
            Bind(catalog, typeof(OriginalGondolaTheoState),
                "Celeste.NPC04_Theo");
            Bind(catalog, typeof(OriginalReflectionGrannyState),
                "Celeste.NPC06_Granny");
            Bind(catalog, typeof(OriginalGrannyEndingState),
                "Celeste.NPC07X_Granny_Ending");
            Bind(catalog, typeof(OriginalEpilogueGrannyState),
                "Celeste.NPC08_Granny");
            Bind(catalog, typeof(OriginalEpilogueTheoState),
                "Celeste.NPC08_Theo");
            Bind(catalog, typeof(OriginalCoreGrannyInsideState),
                "Celeste.NPC09_Granny_Inside");
            Bind(catalog, typeof(OriginalCoreGrannyOutsideState),
                "Celeste.NPC09_Granny_Outside");
            Bind(catalog, typeof(OriginalResortMirrorState),
                "Celeste.ResortMirror");
            Bind(catalog, typeof(OriginalSliderState),
                "Celeste.Slider");
            Bind(catalog, typeof(OriginalSliderState.Surfaces),
                "Celeste.Slider+Surfaces");
            Bind(catalog, typeof(SpikesState), "Celeste.Spikes");
            Bind(catalog, typeof(OriginalTalkComponent),
                "Celeste.TalkComponent");
            Bind(catalog, typeof(OriginalTalkComponent.HoverDisplay),
                "Celeste.TalkComponent+HoverDisplay");
            Bind(catalog, typeof(OriginalTalkUiEntity),
                "Celeste.TalkComponent+TalkComponentUI");
            Bind(catalog, typeof(TemplePortalTorchState),
                "Celeste.TemplePortalTorch");
            Bind(catalog,
                typeof(TentaclesBackdropPresentation),
                "Celeste.Tentacles");
            Bind(catalog, typeof(OriginalSoundTest3dState),
                "Celeste._3dSoundTest");
            Bind(catalog, RequireNested(typeof(MirrorPortalCutscene), "Fader"),
                "Celeste.CS04_MirrorPortal+Fader");
            Bind(catalog,
                RequireNested(typeof(OriginalTempleMirrorState),
                    "Frame"), "Celeste.TempleMirror+Frame");
            Bind(catalog, RequireNested(typeof(TempleMirrorPortalState), "Bg"),
                "Celeste.TempleMirrorPortal+Bg");
            Bind(catalog,
                RequireNested(typeof(TempleMirrorPortalState), "Curtain"),
                "Celeste.TempleMirrorPortal+Curtain");
        }

        public static void RegisterConfigurationUi(SceneEntityCatalog catalog)
        {
            Bind(catalog, typeof(ButtonConfigPresentation),
                "Celeste.ButtonConfigUI");
            Bind(catalog, typeof(KeyboardConfigPresentation),
                "Celeste.KeyboardConfigUI");
        }

        private static Type RequireNested(Type parent, string name)
        {
            return parent.GetNestedType(name, BindingFlags.NonPublic | BindingFlags.Public)
                   ?? throw new InvalidOperationException("The true original nested CPU type is missing: " +
                                                          parent.FullName +
                                                          "+" + name);
        }

        private static void Bind(SceneEntityCatalog catalog, Type actualType, string identity)
        {
            var definition = catalog.FindLogicalMetadata(identity)
                             ?? throw new InvalidOperationException(
                                 "Original built-in entity TypeDef is not published: " +
                                 identity);
            if (definition.LogicalMetadataToken == 0 || definition.LogicalAssemblyIdentity !=
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
                throw new InvalidOperationException(
                    "Original built-in entity TypeDef belongs to a different source assembly: " + identity);
            catalog.RegisterRuntimeType(actualType, definition.RegistryKey);
            catalog.SelectLogicalActualType(actualType, identity);
        }
    }
}
