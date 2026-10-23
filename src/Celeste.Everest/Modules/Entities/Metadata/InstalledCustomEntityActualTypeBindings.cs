using System;
using System.Reflection;
using Celeste.Everest.Entities.Birds.Paths;
using Celeste.Everest.Entities.Birds.Tutorials;
using Celeste.Everest.Entities.Decoration.Cobwebs;
using Celeste.Everest.Entities.Decoration.Wires;
using Celeste.Everest.Entities.Doors.Ridge;
using Celeste.Everest.Entities.IntroCar;
using Celeste.Everest.Entities.Memorials;
using Celeste.Everest.Entities.Npcs;
using Celeste.Everest.Entities.Npcs.Granny;
using Celeste.Everest.Entities.Triggers.Entities;
using Celeste.Everest.Entities.Triggers.Flags;
using Celeste.Everest.Entities.Triggers.Lava;
using Celeste.Everest.Gameplay.Enemies.Badeline.Chasers;
using Celeste.Everest.Gameplay.Hazards.TriggerSpikes;
using Celeste.Everest.Gameplay.Platforms.CrushBlocks;
using Celeste.Everest.Gameplay.Platforms.Dream;
using Celeste.Everest.Gameplay.Platforms.FinalBossMovingBlock;
using Celeste.Everest.Gameplay.Platforms.IntroCrusher;
using Celeste.Everest.Gameplay.Triggers.Audio;
using Celeste.Everest.Gameplay.Triggers.Camera;
using Celeste.Everest.Gameplay.Triggers.Completion;
using Celeste.Everest.Gameplay.Triggers.Core;
using Celeste.Everest.Gameplay.Triggers.Dialogue;
using Celeste.Everest.Gameplay.Triggers.Dream;
using Celeste.Everest.Gameplay.Triggers.Hazards;
using Celeste.Everest.Gameplay.Triggers.Height;
using Celeste.Everest.Gameplay.Triggers.Inventory;
using Celeste.Everest.Input;
using Celeste.Everest.Menus.Chapters;
using Celeste.Everest.Menus.InitialSetup;
using Celeste.Everest.Menus.MapList;
using Celeste.Everest.Menus.MapSearch;
using Celeste.Everest.Presentation.Effects.Trails;
using Celeste.Everest.Presentation.Hud.CoreMessages;
using Celeste.Everest.Presentation.Hud.Height;
using Celeste.Everest.Stories.Dialogue;
using Celeste.Everest.UI.Dependencies;
using Celeste.Everest.UI.Menus.Files;
using Celeste.Everest.UI.ModOptions;
using Celeste.Everest.UI.Mods.Toggling;
using Celeste.Everest.UI.Settings;
using Celeste.Everest.UI.Shutdown;
using Celeste.Everest.UI.SoundTest;
using Celeste.Everest.UI.Updating.Mods;
using Celeste.Everest.UI.Updating.Versions;
using Celeste.Game.Entities.Environment.Space;
using Celeste.Game.Entities.StarJump;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Modules.Entities.Metadata
{
    public static class InstalledCustomEntityActualTypeBindings
    {
        private const string AssemblyIdentity = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

        public static void Register(SceneEntityCatalog catalog)
        {
            Bind(catalog, typeof(InstalledCobwebState),
                "Celeste.Cobweb");
            Bind(catalog, typeof(InstalledWireState),
                "Celeste.Wire");
            Bind(catalog, typeof(EverestBirdPathState),
                "Celeste.BirdPath");
            Bind(catalog, typeof(EverestIntroCarState),
                "Celeste.IntroCar");
            Bind(catalog, typeof(EverestBadelineOldsiteState),
                "Celeste.BadelineOldsite");
            Bind(catalog, typeof(OriginalSpaceController),
                "Celeste.SpaceController");
            Bind(catalog, typeof(ActivateDreamBlocksTrigger),
                "Celeste.Mod.Entities.ActivateDreamBlocksTrigger");
            Bind(catalog, typeof(AmbienceTrigger),
                "Celeste.Mod.Entities.AmbienceTrigger");
            Bind(catalog, typeof(AmbienceVolumeTrigger),
                "Celeste.Mod.Entities.AmbienceVolumeTrigger");
            Bind(catalog,
                typeof(EverestBadelineOldsiteEndState),
                "Celeste.Mod.Entities.BadelineOldsiteEnd");
            Bind(catalog, typeof(ChangeInventoryTrigger),
                "Celeste.Mod.Entities.ChangeInventoryTrigger");
            Bind(catalog, typeof(CompleteAreaTrigger),
                "Celeste.Mod.Entities.CompleteAreaTrigger");
            Bind(catalog, typeof(CoreModeTrigger),
                "Celeste.Mod.Entities.CoreModeTrigger");
            Bind(catalog, typeof(CrystalShatterTrigger),
                "Celeste.Mod.Entities.CrystalShatterTrigger");
            Bind(catalog, typeof(CustomBirdTutorial),
                "Celeste.Mod.Entities.CustomBirdTutorial");
            Bind(catalog, typeof(CustomBirdTutorialTrigger),
                "Celeste.Mod.Entities.CustomBirdTutorialTrigger");
            Bind(catalog, typeof(CustomCoreMessageState),
                "Celeste.Mod.Entities.CustomCoreMessage");
            Bind(catalog, typeof(CustomHeightDisplayTriggerState),
                "Celeste.Mod.Entities.CustomHeightDisplayTrigger");
            Bind(catalog, typeof(CustomMemorialState),
                "Celeste.Mod.Entities.CustomMemorial");
            Bind(catalog, typeof(EverestCustomNpcState),
                "Celeste.Mod.Entities.CustomNPC");
            Bind(catalog, typeof(EverestDialogCutsceneTriggerState),
                "Celeste.Mod.Entities.DialogCutsceneTrigger");
            Bind(catalog, typeof(EverestEntityTriggerState),
                "Celeste.Mod.Entities.EntityTrigger");
            Bind(catalog, typeof(EverestFlagTriggerState),
                "Celeste.Mod.Entities.FlagTrigger");
            Bind(catalog, typeof(EverestLavaBlockerTriggerState),
                "Celeste.Mod.Entities.LavaBlockerTrigger");
            Bind(catalog, typeof(MusicLayerTrigger),
                "Celeste.Mod.Entities.MusicLayerTrigger");
            Bind(catalog, typeof(SmoothCameraOffsetTrigger),
                "Celeste.Mod.Entities.SmoothCameraOffsetTrigger");
            Bind(catalog, typeof(OriginalSpaceControllerBlocker),
                "Celeste.Mod.Entities.SpaceControllerBlocker");
            Bind(catalog, typeof(OriginalStarClimbGraphicsControllerState),
                "Celeste.Mod.Entities.StarClimbGraphicsController");
            RequireExisting(catalog,
                typeof(EverestOriginalTriggerSpikesState),
                "Celeste.Mod.Entities.TriggerSpikesOriginal");
            Bind(catalog, typeof(CustomMemorialTextState),
                "Celeste.Mod.Entities.CustomMemorialText");
            Bind(catalog, typeof(CustomHeightDisplayState),
                "Celeste.Mod.Entities.CustomHeightDisplay");
            Bind(catalog, typeof(EverestDialogCutsceneState),
                "Celeste.Mod.Entities.DialogCutscene");
            Bind(catalog, typeof(EntityTriggerListenerState),
                "Celeste.Mod.Entities.EntityTriggerListener");
            Bind(catalog,
                RequireNested(typeof(CoreModeTrigger), "Modes"),
                "Celeste.Mod.Entities.CoreModeTrigger+Modes");
            Bind(catalog, typeof(CrystalShatterTrigger.Modes),
                "Celeste.Mod.Entities.CrystalShatterTrigger+Modes");
            Bind(catalog,
                RequireNested(typeof(CrystalShatterTrigger),
                    "ModesLegacy"), "Celeste.Mod.Entities.CrystalShatterTrigger+ModesLegacy");
            Bind(catalog, typeof(EverestCustomBirdTutorialEvents),
                "Celeste.Mod.Everest+Events+CustomBirdTutorial");
            Bind(catalog,
                typeof(EverestCustomBirdTutorialEvents.ParseCommandHandler),
                "Celeste.Mod.Everest+Events+CustomBirdTutorial+ParseCommandHandler");
            Bind(catalog, typeof(SourceEverestVirtualButton), "Monocle.VirtualButton");
            Bind(catalog, typeof(EverestGrannyEndingState),
                "Celeste.NPC07X_Granny_Ending");
            Bind(catalog, typeof(EverestAssistModeState),
                "Celeste.OuiAssistMode");
            Bind(catalog, typeof(EverestChapterPanelSequence),
                "Celeste.OuiChapterPanel");
            Bind(catalog, typeof(EverestChapterSelectSequence),
                "Celeste.OuiChapterSelect");
            Bind(catalog, typeof(EverestFileNamingState), "Celeste.OuiFileNaming");
            Bind(catalog, typeof(EverestFileSelectSequence),
                "Celeste.OuiFileSelect");
            Bind(catalog, typeof(EverestDependencyDownloaderState),
                "Celeste.Mod.UI.OuiDependencyDownloader");
            Bind(catalog, typeof(EverestChapterLevelSetPickerSequence),
                "Celeste.Mod.UI.OuiHelper_ChapterSelect_LevelSet");
            Bind(catalog, typeof(EverestShutdownState),
                "Celeste.Mod.UI.OuiHelper_Shutdown");
            Bind(catalog, typeof(EverestMapListSequence),
                "Celeste.Mod.UI.OuiMapList");
            Bind(catalog, typeof(EverestMapSearchSequence),
                "Celeste.Mod.UI.OuiMapSearch");
            Bind(catalog, typeof(EverestModOptionsState),
                "Celeste.Mod.UI.OuiModOptions");
            Bind(catalog, typeof(EverestTextEntryState),
                "Celeste.Mod.UI.OuiTextEntry");
            Bind(catalog, typeof(EverestModOptionStringState),
                "Celeste.Mod.UI.OuiModOptionString");
            Bind(catalog, typeof(EverestModTogglerState),
                "Celeste.Mod.UI.OuiModToggler");
            Bind(catalog, typeof(EverestModUpdateListState),
                "Celeste.Mod.UI.OuiModUpdateList");
            Bind(catalog, typeof(EverestNumberEntryState),
                "Celeste.Mod.UI.OuiNumberEntry");
            Bind(catalog, typeof(EverestCoreOobeSequence),
                "Celeste.Mod.UI.OuiOOBE");
            Bind(catalog, typeof(EverestSoundTestState),
                "Celeste.Mod.UI.OuiSoundTest");
            Bind(catalog, typeof(EverestVersionListState),
                "Celeste.Mod.UI.OuiVersionList");
            Bind(catalog, typeof(EverestCrushBlockState),
                "Celeste.CrushBlock");
            Bind(catalog,
                typeof(EverestFinalBossMovingBlockState),
                "Celeste.FinalBossMovingBlock");
            Bind(catalog, typeof(EverestIntroCrusherState),
                "Celeste.IntroCrusher");
            Bind(catalog, typeof(EverestRidgeGateState),
                "Celeste.RidgeGate");
            Bind(catalog, typeof(EverestTrailManagerState),
                "Celeste.TrailManager");
            Bind(catalog, typeof(EverestDreamBlockState),
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
        {
            return parent.GetNestedType(name, BindingFlags.Public | BindingFlags.NonPublic)
                   ?? throw new InvalidOperationException("The actual source nested type is missing: " +
                                                          parent.FullName +
                                                          "+" +
                                                          name);
        }
    }
}
