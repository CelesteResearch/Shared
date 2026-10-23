using Celeste.Input.Bindings;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Reflection.Startup
{
    public static class OriginalTrackerFrameworkTypeBindings
    {
        public static void Register(SceneEntityCatalog catalog)
        {
            catalog.RegisterRuntimeType(typeof(global::Celeste.Input.Bindings.SourceVirtualButton),
                "Monocle.VirtualButton");
            catalog.RegisterRuntimeType(typeof(global::Celeste.Core.Components.SourceComponentState),
                "Monocle.Component");
            catalog.RegisterRuntimeType(typeof(global::Celeste.Scene.Entities.SceneEntityState),
                typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName);
            catalog.RegisterRuntimeType(
                typeof(global::Celeste.Simulation.Gameplay.Platforms.Foundation.SourcePlatformEntityState),
                "Celeste.Platform");
            catalog.RegisterRuntimeType(
                typeof(global::Celeste.Simulation.Gameplay.Platforms.Foundation.SourceSolidEntityState),
                "Celeste.Solid");
            catalog.RegisterRuntimeType(
                typeof(global::Celeste.Simulation.Gameplay.Platforms.Foundation.SourceJumpThruEntityState),
                "Celeste.JumpThru");
            catalog.RegisterRuntimeType(
                typeof(global::Celeste.Simulation.Gameplay.Triggers.Foundation.SourceTriggerEntityState),
                "Celeste.Trigger");
            catalog.RegisterRuntimeType(
                typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState),
                typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName);
            catalog.RegisterRuntimeType(typeof(global::Celeste.Simulation.RoomPlayerSession),
                typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            catalog.SelectLogicalActualType(typeof(global::Celeste.Simulation.RoomPlayerSession), "Celeste.Player");
            catalog.SelectLogicalActualType(
                typeof(global::Celeste.Game.Entities.Playback.OriginalPlayerPlaybackState),
                "Celeste.PlayerPlayback");
            OriginalBuiltInEntityActualTypeBindings.Register(catalog);
            catalog.RegisterRuntimeType(typeof(global::Celeste.Game.Menus.Files.AssistModeSequence),
                "Celeste.OuiAssistMode");
            catalog.SelectLogicalActualType(typeof(global::Celeste.Game.Menus.Files.AssistModeSequence),
                "Celeste.OuiAssistMode");
            catalog.RegisterRuntimeType(typeof(global::Celeste.Game.Credits.OuiCreditsSequence),
                "Celeste.OuiCredits");
            catalog.SelectLogicalActualType(typeof(global::Celeste.Game.Credits.OuiCreditsSequence),
                "Celeste.OuiCredits");
            catalog.RegisterRuntimeType(typeof(global::Celeste.Game.Menus.Chapters.ChapterPanelSequence),
                "Celeste.OuiChapterPanel");
            catalog.SelectLogicalActualType(typeof(global::Celeste.Game.Menus.Chapters.ChapterPanelSequence),
                "Celeste.OuiChapterPanel");
            catalog.RegisterRuntimeType(typeof(global::Celeste.Game.Menus.Chapters.ChapterSelectSequence),
                "Celeste.OuiChapterSelect");
            catalog.SelectLogicalActualType(typeof(global::Celeste.Game.Menus.Chapters.ChapterSelectSequence),
                "Celeste.OuiChapterSelect");
            catalog.RegisterRuntimeType(typeof(global::Celeste.Game.Menus.Files.FileNamingSequence),
                "Celeste.OuiFileNaming");
            catalog.SelectLogicalActualType(typeof(global::Celeste.Game.Menus.Files.FileNamingSequence),
                "Celeste.OuiFileNaming");
            catalog.RegisterRuntimeType(typeof(global::Celeste.Game.Menus.Files.FileSelectSequence),
                "Celeste.OuiFileSelect");
            catalog.SelectLogicalActualType(typeof(global::Celeste.Game.Menus.Files.FileSelectSequence),
                "Celeste.OuiFileSelect");
            catalog.RegisterRuntimeType(typeof(global::Celeste.Game.Menus.Overworld.OptionsSequence),
                "Celeste.OuiOptions");
            catalog.SelectLogicalActualType(typeof(global::Celeste.Game.Menus.Overworld.OptionsSequence),
                "Celeste.OuiOptions");
        }
    }
}
