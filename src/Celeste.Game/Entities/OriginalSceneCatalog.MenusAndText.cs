using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterMenusAndTextSceneButtonConfigUI(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.ButtonConfigUI",
                    new string[]
                        { "Celeste.TextMenu", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.ButtonConfigUI" }), true);
        }

        private static void RegisterMenusAndTextSceneFileErrorOverlay(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.FileErrorOverlay",
                    new string[]
                        { "Celeste.Overlay", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterMenusAndTextSceneKeyboardConfigUI(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.KeyboardConfigUI",
                    new string[]
                        { "Celeste.TextMenu", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.KeyboardConfigUI" }), true);
        }

        private static void RegisterMenusAndTextSceneLanguageSelectUI(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.LanguageSelectUI",
                    new string[]
                        { "Celeste.TextMenu", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterMenusAndTextSceneLevelEnterBSideTitle(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.LevelEnter.BSideTitle",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterMenusAndTextSceneMainMenuClimb(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.MainMenuClimb",
                    new string[]
                        { "Celeste.MenuButton", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.MenuButton" }), false);
            result.Register(
                new SceneEntityType("Celeste.MainMenuSmallButton",
                    new string[]
                        { "Celeste.MenuButton", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.MenuButton" }),
                false);
        }

        private static void RegisterMenusAndTextSceneMenuButton(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.MenuButton",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), true);
        }

        private static void RegisterMenusAndTextSceneOverlay(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Overlay",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.Overworld.InputEntity",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterMenusAndTextScenePostcard(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Postcard",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterMenusAndTextScenePrologueEndingText(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.PrologueEndingText",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterMenusAndTextSceneSlider(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Slider",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterMenusAndTextSceneTextbox(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Textbox",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Textbox" }), true);
            result.Register(
                new SceneEntityType("Celeste.TextMenu",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterMenusAndTextSceneUnlockEverythingThingy(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.UnlockEverythingThingy",
                    new string[]
                        { "Monocle.CheatListener", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterMenusAndTextSceneViewportAdjustmentUI(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.ViewportAdjustmentUI",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterMenusAndTextRuntimeTextbox(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.CS02_Journal",
                    new[]
                    {
                        "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS03_Memo",
                    new[]
                    {
                        "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS02_Journal.PoemPage",
                    new[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName }, new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.CS03_Memo.MemoPage",
                    new[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName }, new string[] { }),
                false);
        }
    }
}
