using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterOverworldUiTypes(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Oui",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.OuiAssistMode",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.OuiChapterPanel",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.OuiChapterSelect",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.OuiChapterSelectIcon",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.OuiCredits",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.OuiFileNaming",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.OuiFileSelect",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.OuiFileSelectSlot",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.OuiJournal",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.OuiMainMenu",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.OuiOptions",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.OuiTitleScreen",
                    (string[])["Celeste.Oui", typeof(SceneEntityState).FullName],
                    (string[])[]));
        }
    }
}
