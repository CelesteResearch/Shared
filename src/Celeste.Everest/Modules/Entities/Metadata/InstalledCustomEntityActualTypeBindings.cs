using System;
using System.Reflection;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Modules.Entities.Metadata
{
    public static class InstalledCustomEntityActualTypeBindings
    {
        private const string AssemblyIdentity = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

        public static void Register(SceneEntityCatalog catalog)
        {
            Bind(catalog, typeof(global::Celeste.Everest.Entities.Decoration.Cobwebs.InstalledCobwebState),
                "Celeste.Cobweb");
            Bind(catalog, typeof(global::Celeste.Everest.Entities.Decoration.Wires.InstalledWireState),
                "Celeste.Wire");
            Bind(catalog, typeof(global::Celeste.Everest.Entities.Birds.Paths.EverestBirdPathState),
                "Celeste.BirdPath");
            Bind(catalog, typeof(global::Celeste.Everest.Entities.IntroCar.EverestIntroCarState),
                "Celeste.IntroCar");
            Bind(catalog, typeof(global::Celeste.Everest.Gameplay.Enemies.Badeline.Chasers.EverestBadelineOldsiteState),
                "Celeste.BadelineOldsite");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Environment.Space.OriginalSpaceController),
                "Celeste.SpaceController");
            Bind(catalog, typeof(global::Celeste.Everest.Gameplay.Triggers.Dream.ActivateDreamBlocksTrigger),
                "Celeste.Mod.Entities.ActivateDreamBlocksTrigger");
            Bind(catalog, typeof(global::Celeste.Everest.Gameplay.Triggers.Audio.AmbienceTrigger),
                "Celeste.Mod.Entities.AmbienceTrigger");
            Bind(catalog, typeof(global::Celeste.Everest.Gameplay.Triggers.Audio.AmbienceVolumeTrigger),
                "Celeste.Mod.Entities.AmbienceVolumeTrigger");
            Bind(catalog,
                typeof(global::Celeste.Everest.Gameplay.Enemies.Badeline.Chasers.EverestBadelineOldsiteEndState),
                "Celeste.Mod.Entities.BadelineOldsiteEnd");
            Bind(catalog, typeof(global::Celeste.Everest.Gameplay.Triggers.Inventory.ChangeInventoryTrigger),
                "Celeste.Mod.Entities.ChangeInventoryTrigger");
            Bind(catalog, typeof(global::Celeste.Everest.Gameplay.Triggers.Completion.CompleteAreaTrigger),
                "Celeste.Mod.Entities.CompleteAreaTrigger");
            Bind(catalog, typeof(global::Celeste.Everest.Gameplay.Triggers.Core.CoreModeTrigger),
                "Celeste.Mod.Entities.CoreModeTrigger");
            Bind(catalog, typeof(global::Celeste.Everest.Gameplay.Triggers.Hazards.CrystalShatterTrigger),
                "Celeste.Mod.Entities.CrystalShatterTrigger");
            Bind(catalog, typeof(global::Celeste.Everest.Entities.Birds.Tutorials.CustomBirdTutorial),
                "Celeste.Mod.Entities.CustomBirdTutorial");
            Bind(catalog, typeof(global::Celeste.Everest.Entities.Birds.Tutorials.CustomBirdTutorialTrigger),
                "Celeste.Mod.Entities.CustomBirdTutorialTrigger");
            Bind(catalog, typeof(global::Celeste.Everest.Presentation.Hud.CoreMessages.CustomCoreMessageState),
                "Celeste.Mod.Entities.CustomCoreMessage");
            Bind(catalog, typeof(global::Celeste.Everest.Gameplay.Triggers.Height.CustomHeightDisplayTriggerState),
                "Celeste.Mod.Entities.CustomHeightDisplayTrigger");
            Bind(catalog, typeof(global::Celeste.Everest.Entities.Memorials.CustomMemorialState),
                "Celeste.Mod.Entities.CustomMemorial");
            Bind(catalog, typeof(global::Celeste.Everest.Entities.Npcs.EverestCustomNpcState),
                "Celeste.Mod.Entities.CustomNPC");
            Bind(catalog, typeof(global::Celeste.Everest.Gameplay.Triggers.Dialogue.EverestDialogCutsceneTriggerState),
                "Celeste.Mod.Entities.DialogCutsceneTrigger");
            Bind(catalog, typeof(global::Celeste.Everest.Entities.Triggers.Entities.EverestEntityTriggerState),
                "Celeste.Mod.Entities.EntityTrigger");
            Bind(catalog, typeof(global::Celeste.Everest.Entities.Triggers.Flags.EverestFlagTriggerState),
                "Celeste.Mod.Entities.FlagTrigger");
            Bind(catalog, typeof(global::Celeste.Everest.Entities.Triggers.Lava.EverestLavaBlockerTriggerState),
                "Celeste.Mod.Entities.LavaBlockerTrigger");
            Bind(catalog, typeof(global::Celeste.Everest.Gameplay.Triggers.Audio.MusicLayerTrigger),
                "Celeste.Mod.Entities.MusicLayerTrigger");
            Bind(catalog, typeof(global::Celeste.Everest.Gameplay.Triggers.Camera.SmoothCameraOffsetTrigger),
                "Celeste.Mod.Entities.SmoothCameraOffsetTrigger");
            Bind(catalog, typeof(global::Celeste.Game.Entities.Environment.Space.OriginalSpaceControllerBlocker),
                "Celeste.Mod.Entities.SpaceControllerBlocker");
            Bind(catalog, typeof(global::Celeste.Game.Entities.StarJump.OriginalStarClimbGraphicsControllerState),
                "Celeste.Mod.Entities.StarClimbGraphicsController");
            RequireExisting(catalog,
                typeof(global::Celeste.Everest.Gameplay.Hazards.TriggerSpikes.EverestOriginalTriggerSpikesState),
                "Celeste.Mod.Entities.TriggerSpikesOriginal");
            Bind(catalog, typeof(global::Celeste.Everest.Entities.Memorials.CustomMemorialTextState),
                "Celeste.Mod.Entities.CustomMemorialText");
            Bind(catalog, typeof(global::Celeste.Everest.Presentation.Hud.Height.CustomHeightDisplayState),
                "Celeste.Mod.Entities.CustomHeightDisplay");
            Bind(catalog, typeof(global::Celeste.Everest.Stories.Dialogue.EverestDialogCutsceneState),
                "Celeste.Mod.Entities.DialogCutscene");
            Bind(catalog, typeof(global::Celeste.Everest.Entities.Triggers.Entities.EntityTriggerListenerState),
                "Celeste.Mod.Entities.EntityTriggerListener");
            Bind(catalog,
                RequireNested(typeof(global::Celeste.Everest.Gameplay.Triggers.Core.CoreModeTrigger), "Modes"),
                "Celeste.Mod.Entities.CoreModeTrigger+Modes");
            Bind(catalog, typeof(global::Celeste.Everest.Gameplay.Triggers.Hazards.CrystalShatterTrigger.Modes),
                "Celeste.Mod.Entities.CrystalShatterTrigger+Modes");
            Bind(catalog,
                RequireNested(typeof(global::Celeste.Everest.Gameplay.Triggers.Hazards.CrystalShatterTrigger),
                    "ModesLegacy"), "Celeste.Mod.Entities.CrystalShatterTrigger+ModesLegacy");
            Bind(catalog, typeof(global::Celeste.Everest.Entities.Birds.Tutorials.EverestCustomBirdTutorialEvents),
                "Celeste.Mod.Everest+Events+CustomBirdTutorial");
            Bind(catalog,
                typeof(global::Celeste.Everest.Entities.Birds.Tutorials.EverestCustomBirdTutorialEvents.
                    ParseCommandHandler), "Celeste.Mod.Everest+Events+CustomBirdTutorial+ParseCommandHandler");
            Bind(catalog, typeof(global::Celeste.Everest.Input.SourceEverestVirtualButton), "Monocle.VirtualButton");
            Bind(catalog, typeof(global::Celeste.Everest.Entities.Npcs.Granny.EverestGrannyEndingState),
                "Celeste.NPC07X_Granny_Ending");
            Bind(catalog, typeof(global::Celeste.Everest.UI.Menus.Files.EverestAssistModeState),
                "Celeste.OuiAssistMode");
            Bind(catalog, typeof(global::Celeste.Everest.Menus.Chapters.EverestChapterPanelSequence),
                "Celeste.OuiChapterPanel");
            Bind(catalog, typeof(global::Celeste.Everest.Menus.Chapters.EverestChapterSelectSequence),
                "Celeste.OuiChapterSelect");
            Bind(catalog, typeof(global::Celeste.Everest.UI.Settings.EverestFileNamingState), "Celeste.OuiFileNaming");
            Bind(catalog, typeof(global::Celeste.Everest.UI.Menus.Files.EverestFileSelectSequence),
                "Celeste.OuiFileSelect");
            Bind(catalog, typeof(global::Celeste.Everest.UI.Dependencies.EverestDependencyDownloaderState),
                "Celeste.Mod.UI.OuiDependencyDownloader");
            Bind(catalog, typeof(global::Celeste.Everest.Menus.Chapters.EverestChapterLevelSetPickerSequence),
                "Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet");
            Bind(catalog, typeof(global::Celeste.Everest.UI.Shutdown.EverestShutdownState),
                "Celeste.Mod.UI.OuiHelper_Shutdown");
            Bind(catalog, typeof(global::Celeste.Everest.Menus.MapList.EverestMapListSequence),
                "Celeste.Mod.UI.OuiMapList");
            Bind(catalog, typeof(global::Celeste.Everest.Menus.MapSearch.EverestMapSearchSequence),
                "Celeste.Mod.UI.OuiMapSearch");
            Bind(catalog, typeof(global::Celeste.Everest.UI.ModOptions.EverestModOptionsState),
                "Celeste.Mod.UI.OuiModOptions");
            Bind(catalog, typeof(global::Celeste.Everest.UI.Settings.EverestTextEntryState),
                "Celeste.Mod.UI.OuiTextEntry");
            Bind(catalog, typeof(global::Celeste.Everest.UI.Settings.EverestModOptionStringState),
                "Celeste.Mod.UI.OuiModOptionString");
            Bind(catalog, typeof(global::Celeste.Everest.UI.Mods.Toggling.EverestModTogglerState),
                "Celeste.Mod.UI.OuiModToggler");
            Bind(catalog, typeof(global::Celeste.Everest.UI.Updating.Mods.EverestModUpdateListState),
                "Celeste.Mod.UI.OuiModUpdateList");
            Bind(catalog, typeof(global::Celeste.Everest.UI.Settings.EverestNumberEntryState),
                "Celeste.Mod.UI.OuiNumberEntry");
            Bind(catalog, typeof(global::Celeste.Everest.Menus.InitialSetup.EverestCoreOobeSequence),
                "Celeste.Mod.UI.OuiOOBE");
            Bind(catalog, typeof(global::Celeste.Everest.UI.SoundTest.EverestSoundTestState),
                "Celeste.Mod.UI.OuiSoundTest");
            Bind(catalog, typeof(global::Celeste.Everest.UI.Updating.Versions.EverestVersionListState),
                "Celeste.Mod.UI.OuiVersionList");
            Bind(catalog, typeof(global::Celeste.Everest.Gameplay.Platforms.CrushBlocks.EverestCrushBlockState),
                "Celeste.CrushBlock");
            Bind(catalog,
                typeof(global::Celeste.Everest.Gameplay.Platforms.FinalBossMovingBlock.
                    EverestFinalBossMovingBlockState),
                "Celeste.FinalBossMovingBlock");
            Bind(catalog, typeof(global::Celeste.Everest.Gameplay.Platforms.IntroCrusher.EverestIntroCrusherState),
                "Celeste.IntroCrusher");
            Bind(catalog, typeof(global::Celeste.Everest.Entities.Doors.Ridge.EverestRidgeGateState),
                "Celeste.RidgeGate");
            Bind(catalog, typeof(global::Celeste.Everest.Presentation.Effects.Trails.EverestTrailManagerState),
                "Celeste.TrailManager");
            Bind(catalog, typeof(global::Celeste.Everest.Gameplay.Platforms.Dream.EverestDreamBlockState),
                "Celeste.DreamBlock");
        }

        private static SceneEntityType RequireDefinition(SceneEntityCatalog catalog, string identity)
        {
            var definition = catalog.FindLogicalMetadata(identity)
                             ?? throw new InvalidOperationException("Installed original TypeDef is not published: " +
                                                                    identity);
            if (definition.LogicalAssemblyIdentity != AssemblyIdentity || definition.LogicalMetadataToken == 0)
                throw new InvalidOperationException(
                    "Installed original TypeDef belongs to a different qualified source: " +
                    identity);
            return definition;
        }

        private static void Bind(SceneEntityCatalog catalog, Type actualType, string identity)
        {
            var definition = RequireDefinition(catalog, identity);
            catalog.RegisterRuntimeType(actualType, definition.RegistryKey);
            catalog.SelectLogicalActualType(actualType, identity);
        }

        private static void RequireExisting(SceneEntityCatalog catalog, Type actualType, string identity)
        {
            RequireDefinition(catalog, identity);
            if (catalog.RequireActualTypeForLogicalIdentity(identity) != actualType)
                throw new InvalidOperationException("Installed original type has a different actual registration: " +
                                                    identity);
        }

        private static Type RequireNested(Type parent, string name)
            => parent.GetNestedType(name, BindingFlags.Public | BindingFlags.NonPublic)
               ?? throw new InvalidOperationException("The actual source nested type is missing: " + parent.FullName +
                                                      "+" +
                                                      name);
    }
}
