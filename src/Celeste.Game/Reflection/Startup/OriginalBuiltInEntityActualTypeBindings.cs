using System;
using System.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Startup
{
    public static class OriginalBuiltInEntityActualTypeBindings
    {
        public static void Register(SceneEntityCatalog catalog)
        {
            Bind(catalog,
                typeof(global::Celeste.Simulation.Presentation.Backdrops.Parallax.ParallaxBackdropPresentation),
                "Celeste.Parallax");
            Bind(catalog,
                typeof(global::Celeste.Simulation.Presentation.Backdrops.Weather.Rain.RainBackdropPresentation),
                "Celeste.RainFG");
            Bind(catalog,
                typeof(global::Celeste.Simulation.Presentation.Backdrops.Weather.Snow.WindSnowBackdropPresentation),
                "Celeste.WindSnowFG");
            Bind(catalog, typeof(global::Celeste.Game.Content.Maps.Backdrops.Stars.CoreStarsBackdropPresentation),
                "Celeste.CoreStarsFG");
            Bind(catalog, typeof(global::Celeste.Simulation.Presentation.Backdrops.Stars.StarfieldBackdropPresentation),
                "Celeste.Starfield");
            Bind(catalog, typeof(global::Celeste.Simulation.UI.Menus.Text.TextMenuPresentation), "Celeste.TextMenu");
            Bind(catalog, typeof(global::Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.Item),
                "Celeste.TextMenu+Item");
            Bind(catalog, typeof(global::Celeste.Simulation.UI.Menus.Text.TextMenuPresentation.Button),
                "Celeste.TextMenu+Button");
            Bind(catalog, typeof(global::Celeste.Simulation.Presentation.Player.Death.PlayerDeathPresentation),
                "Celeste.PlayerDeadBody");
            Bind(catalog, typeof(global::Celeste.Game.Gameplay.Assists.Solids.SolidInvincibilityOutlineState),
                "Celeste.SolidOnInvinciblePlayer+Outline");
            Bind(catalog, typeof(global::Celeste.Game.UI.Menus.Buttons.MenuButtonPresentation), "Celeste.MenuButton");
            Bind(catalog, typeof(global::Celeste.Game.UI.Menus.Buttons.Title.MainMenuClimbPresentation),
                "Celeste.MainMenuClimb");
            Bind(catalog, typeof(global::Celeste.Game.UI.Menus.Buttons.Title.MainMenuSmallButtonPresentation),
                "Celeste.MainMenuSmallButton");
            Bind(catalog, typeof(global::Celeste.Simulation.Rendering.PlayerDashAssistPresentation),
                "Celeste.PlayerDashAssist");
            Bind(catalog, typeof(global::Celeste.Simulation.Gameplay.Enemies.Seeker.SeekerBarrierRendererState),
                "Celeste.SeekerBarrierRenderer");
            Bind(catalog, typeof(global::Celeste.Game.Execution.LevelLoader.Terrain.OriginalBackgroundTiles),
                "Celeste.BackgroundTiles");
            Bind(catalog, typeof(global::Celeste.Game.Execution.LevelLoader.Terrain.OriginalSolidTiles),
                "Celeste.SolidTiles");
            Bind(catalog, typeof(global::Celeste.Game.Gameplay.Environment.Water.OriginalWaterSurface),
                "Celeste.WaterSurface");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Birds.BirdNpcState), "Celeste.BirdNPC");
            Bind(catalog,
                typeof(global::Celeste.Game.Gameplay.Collectibles.Strawberries.BlockFields.OriginalBlockFieldState),
                "Celeste.BlockField");
            Bind(catalog, typeof(global::Celeste.Game.Stories.Temple.MirrorPortalCutscene),
                "Celeste.CS04_MirrorPortal");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Npcs.Theo.CS05TheoEntranceState),
                "Celeste.CS05_Entrance");
            Bind(catalog,
                typeof(global::Celeste.Game.Entities.Triggers.Camera.OriginalCameraAdvanceTargetTriggerState),
                "Celeste.CameraAdvanceTargetTrigger");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Triggers.Camera.OriginalCameraOffsetTriggerState),
                "Celeste.CameraOffsetTrigger");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Triggers.Camera.OriginalCameraTargetTriggerState),
                "Celeste.CameraTargetTrigger");
            Bind(catalog, typeof(global::Celeste.Game.Gameplay.Enemies.Badeline.Chasers.ChaserBarrierState),
                "Celeste.ChaserBarrier");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Decoration.Cobwebs.OriginalCobwebState),
                "Celeste.Cobweb");
            Bind(catalog, typeof(global::Celeste.Game.Credits.Triggers.CreditsTriggerState),
                "Celeste.CreditsTrigger");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Collectibles.Hearts.OriginalDreamHeartGemState),
                "Celeste.DreamHeartGem");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Collectibles.Hearts.OriginalFakeHeartState),
                "Celeste.FakeHeart");
            Bind(catalog, typeof(global::Celeste.Game.Gameplay.Environment.Lava.Barriers.OriginalFireBarrierState),
                "Celeste.FireBarrier");
            Bind(catalog, typeof(global::Celeste.Game.Gameplay.Walls.Solids.GlassBlockState), "Celeste.GlassBlock");
            Bind(catalog,
                typeof(
                    global::Celeste.Game.Gameplay.Collectibles.Strawberries.Triggers.GoldBerryCollectTriggerState),
                "Celeste.GoldBerryCollectTrigger");
            Bind(catalog, typeof(global::Celeste.Game.Gameplay.Walls.Conditional.GoldenBlockState),
                "Celeste.GoldenBlock");
            Bind(catalog, typeof(global::Celeste.Game.Gameplay.Environment.Lava.Barriers.OriginalIceBlockState),
                "Celeste.IceBlock");
            Bind(catalog, typeof(global::Celeste.Game.Gameplay.Platforms.Jumpthrus.JumpthruPlatformState),
                "Celeste.JumpthruPlatform");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Npcs.OriginalNpcState), "Celeste.NPC");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Npcs.Granny.OriginalPrologueGrannyState),
                "Celeste.NPC00_Granny");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Npcs.Oshiro.OriginalOshiroBreakdownState),
                "Celeste.NPC03_Oshiro_Breakdown");
            Bind(catalog, typeof(global::Celeste.Game.Stories.CelestialResort.NpcOshiroClutterState),
                "Celeste.NPC03_Oshiro_Cluttter");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Npcs.Oshiro.OriginalOshiroHallway1State),
                "Celeste.NPC03_Oshiro_Hallway1");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Npcs.Oshiro.OriginalOshiroHallway2State),
                "Celeste.NPC03_Oshiro_Hallway2");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Npcs.Oshiro.OriginalOshiroLobbyState),
                "Celeste.NPC03_Oshiro_Lobby");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Npcs.Oshiro.OriginalOshiroRooftopState),
                "Celeste.NPC03_Oshiro_Rooftop");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Npcs.Oshiro.OriginalOshiroSuiteState),
                "Celeste.NPC03_Oshiro_Suite");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Npcs.Theo.Resort.OriginalTheoEscapingState),
                "Celeste.NPC03_Theo_Escaping");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Npcs.Theo.Resort.OriginalTheoVentsState),
                "Celeste.NPC03_Theo_Vents");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Npcs.Granny.OriginalCliffsideGrannyState),
                "Celeste.NPC04_Granny");
            Bind(catalog, typeof(global::Celeste.Game.Stories.GoldenRidge.OriginalGondolaTheoState),
                "Celeste.NPC04_Theo");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Npcs.Granny.OriginalReflectionGrannyState),
                "Celeste.NPC06_Granny");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Npcs.Granny.OriginalGrannyEndingState),
                "Celeste.NPC07X_Granny_Ending");
            Bind(catalog, typeof(global::Celeste.Game.Stories.Epilogue.OriginalEpilogueGrannyState),
                "Celeste.NPC08_Granny");
            Bind(catalog, typeof(global::Celeste.Game.Stories.Epilogue.OriginalEpilogueTheoState),
                "Celeste.NPC08_Theo");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Npcs.Granny.OriginalCoreGrannyInsideState),
                "Celeste.NPC09_Granny_Inside");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Npcs.Granny.OriginalCoreGrannyOutsideState),
                "Celeste.NPC09_Granny_Outside");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Npcs.Oshiro.OriginalResortMirrorState),
                "Celeste.ResortMirror");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Hazards.Sliders.OriginalSliderState),
                "Celeste.Slider");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Hazards.Sliders.OriginalSliderState.Surfaces),
                "Celeste.Slider+Surfaces");
            Bind(catalog, typeof(global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikesState), "Celeste.Spikes");
            Bind(catalog, typeof(global::Celeste.Game.Components.Talking.OriginalTalkComponent),
                "Celeste.TalkComponent");
            Bind(catalog, typeof(global::Celeste.Game.Components.Talking.OriginalTalkComponent.HoverDisplay),
                "Celeste.TalkComponent+HoverDisplay");
            Bind(catalog, typeof(global::Celeste.Game.Components.Talking.OriginalTalkUiEntity),
                "Celeste.TalkComponent+TalkComponentUI");
            Bind(catalog, typeof(global::Celeste.Game.Stories.Temple.TemplePortalTorchState),
                "Celeste.TemplePortalTorch");
            Bind(catalog,
                typeof(global::Celeste.Game.Presentation.Backdrops.Tentacles.TentaclesBackdropPresentation),
                "Celeste.Tentacles");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Diagnostics.AudioTesting.OriginalSoundTest3dState),
                "Celeste._3dSoundTest");
            Bind(catalog, RequireNested(typeof(global::Celeste.Game.Stories.Temple.MirrorPortalCutscene), "Fader"),
                "Celeste.CS04_MirrorPortal+Fader");
            Bind(catalog,
                RequireNested(typeof(global::Celeste.Game.Gameplay.Environment.Mirrors.OriginalTempleMirrorState),
                    "Frame"), "Celeste.TempleMirror+Frame");
            Bind(catalog, RequireNested(typeof(global::Celeste.Game.Stories.Temple.TempleMirrorPortalState), "Bg"),
                "Celeste.TempleMirrorPortal+Bg");
            Bind(catalog,
                RequireNested(typeof(global::Celeste.Game.Stories.Temple.TempleMirrorPortalState), "Curtain"),
                "Celeste.TempleMirrorPortal+Curtain");
        }

        public static void RegisterConfigurationUi(SceneEntityCatalog catalog)
        {
            Bind(catalog, typeof(global::Celeste.Game.Menus.Controls.ButtonConfigPresentation),
                "Celeste.ButtonConfigUI");
            Bind(catalog, typeof(global::Celeste.Game.Menus.Controls.KeyboardConfigPresentation),
                "Celeste.KeyboardConfigUI");
        }

        private static Type RequireNested(Type parent, string name)
            => parent.GetNestedType(name, BindingFlags.NonPublic | BindingFlags.Public)
               ?? throw new InvalidOperationException("The true original nested CPU type is missing: " +
                                                      parent.FullName +
                                                      "+" + name);

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
