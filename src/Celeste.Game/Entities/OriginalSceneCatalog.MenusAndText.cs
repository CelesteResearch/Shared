using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterMenusAndTextSceneButtonConfigUI(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.ButtonConfigUI",
                    (string[])["Celeste.TextMenu", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.ButtonConfigUI"]), true);
        }

        private static void RegisterMenusAndTextSceneFileErrorOverlay(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.FileErrorOverlay",
                    (string[])["Celeste.Overlay", typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterMenusAndTextSceneKeyboardConfigUI(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.KeyboardConfigUI",
                    (string[])["Celeste.TextMenu", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.KeyboardConfigUI"]), true);
        }

        private static void RegisterMenusAndTextSceneLanguageSelectUI(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.LanguageSelectUI",
                    (string[])["Celeste.TextMenu", typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterMenusAndTextSceneLevelEnterBSideTitle(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.LevelEnter.BSideTitle",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterMenusAndTextSceneMainMenuClimb(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.MainMenuClimb",
                    (string[])["Celeste.MenuButton", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.MenuButton"]));
            result.Register(
                new("Celeste.MainMenuSmallButton",
                    (string[])["Celeste.MenuButton", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.MenuButton"]));
        }

        private static void RegisterMenusAndTextSceneMenuButton(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.MenuButton",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]), true);
        }

        private static void RegisterMenusAndTextSceneOverlay(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Overlay",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.Overworld.InputEntity",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterMenusAndTextScenePostcard(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Postcard",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterMenusAndTextScenePrologueEndingText(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.PrologueEndingText",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterMenusAndTextSceneSlider(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Slider",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterMenusAndTextSceneTextbox(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Textbox",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Textbox"]), true);
            result.Register(
                new("Celeste.TextMenu",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterMenusAndTextSceneUnlockEverythingThingy(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.UnlockEverythingThingy",
                    (string[])["Monocle.CheatListener", typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterMenusAndTextSceneViewportAdjustmentUI(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.ViewportAdjustmentUI",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterMenusAndTextRuntimeTextbox(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.CS02_Journal",
                    (string[])
                    [
                        "Celeste.CutsceneEntity", typeof(SceneEntityState).FullName,
                    ],
                    (string[])[]));
            result.Register(
                new("Celeste.CS03_Memo",
                    (string[])
                    [
                        "Celeste.CutsceneEntity", typeof(SceneEntityState).FullName,
                    ],
                    (string[])[]));
            result.Register(
                new("Celeste.CS02_Journal.PoemPage",
                    (string[])[typeof(SceneEntityState).FullName], (string[])[]));
            result.Register(
                new("Celeste.CS03_Memo.MemoPage",
                    (string[])[typeof(SceneEntityState).FullName], (string[])[]));
        }
    }
}
