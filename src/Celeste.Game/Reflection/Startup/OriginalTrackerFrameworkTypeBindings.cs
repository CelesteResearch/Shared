using Celeste.Core.Components;
using Celeste.Game.Credits;
using Celeste.Game.Entities.Playback;
using Celeste.Game.Menus.Chapters;
using Celeste.Game.Menus.Files;
using Celeste.Game.Menus.Overworld;
using Celeste.Input.Bindings;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Game.Reflection.Startup
{
    public static class OriginalTrackerFrameworkTypeBindings
    {
        public static void Register(SceneEntityCatalog catalog)
        {
            catalog.RegisterRuntimeType(typeof(SourceVirtualButton),
                "Monocle.VirtualButton");
            catalog.RegisterRuntimeType(typeof(SourceComponentState),
                "Monocle.Component");
            catalog.RegisterRuntimeType(typeof(SceneEntityState),
                typeof(SceneEntityState).FullName);
            catalog.RegisterRuntimeType(
                typeof(SourcePlatformEntityState),
                "Celeste.Platform");
            catalog.RegisterRuntimeType(
                typeof(SourceSolidEntityState),
                "Celeste.Solid");
            catalog.RegisterRuntimeType(
                typeof(SourceJumpThruEntityState),
                "Celeste.JumpThru");
            catalog.RegisterRuntimeType(
                typeof(SourceTriggerEntityState),
                "Celeste.Trigger");
            catalog.RegisterRuntimeType(
                typeof(SourceActorEntityState),
                typeof(SourceActorEntityState).FullName);
            catalog.RegisterRuntimeType(typeof(RoomPlayerSession),
                typeof(RoomPlayerSession).FullName);
            catalog.SelectLogicalActualType(typeof(RoomPlayerSession), "Celeste.Player");
            catalog.SelectLogicalActualType(
                typeof(OriginalPlayerPlaybackState),
                "Celeste.PlayerPlayback");
            OriginalBuiltInEntityActualTypeBindings.Register(catalog);
            catalog.RegisterRuntimeType(typeof(AssistModeSequence),
                "Celeste.OuiAssistMode");
            catalog.SelectLogicalActualType(typeof(AssistModeSequence),
                "Celeste.OuiAssistMode");
            catalog.RegisterRuntimeType(typeof(OuiCreditsSequence),
                "Celeste.OuiCredits");
            catalog.SelectLogicalActualType(typeof(OuiCreditsSequence),
                "Celeste.OuiCredits");
            catalog.RegisterRuntimeType(typeof(ChapterPanelSequence),
                "Celeste.OuiChapterPanel");
            catalog.SelectLogicalActualType(typeof(ChapterPanelSequence),
                "Celeste.OuiChapterPanel");
            catalog.RegisterRuntimeType(typeof(ChapterSelectSequence),
                "Celeste.OuiChapterSelect");
            catalog.SelectLogicalActualType(typeof(ChapterSelectSequence),
                "Celeste.OuiChapterSelect");
            catalog.RegisterRuntimeType(typeof(FileNamingSequence),
                "Celeste.OuiFileNaming");
            catalog.SelectLogicalActualType(typeof(FileNamingSequence),
                "Celeste.OuiFileNaming");
            catalog.RegisterRuntimeType(typeof(FileSelectSequence),
                "Celeste.OuiFileSelect");
            catalog.SelectLogicalActualType(typeof(FileSelectSequence),
                "Celeste.OuiFileSelect");
            catalog.RegisterRuntimeType(typeof(OptionsSequence),
                "Celeste.OuiOptions");
            catalog.SelectLogicalActualType(typeof(OptionsSequence),
                "Celeste.OuiOptions");
        }
    }
}
