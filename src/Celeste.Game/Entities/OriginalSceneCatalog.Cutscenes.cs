using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterEarlyCutsceneTypes(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.CS00_Ending",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS00_Ending.EndingCutsceneDelay",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS00_Granny",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS01_Ending",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS02_BadelineIntro",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS02_DreamingPhonecall",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS02_Ending",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS02_Journal",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS02_Journal.PoemPage",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS02_Mirror",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS03_Diary",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS03_Ending",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS03_Ending.BgFlash",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.CS03_Guestbook",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS03_Memo",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS03_Memo.MemoPage",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.CS03_OshiroBreakdown",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS03_OshiroClutter",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS03_OshiroHallway1",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS03_OshiroHallway2",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS03_OshiroLobby",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS03_OshiroMasterSuite",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS03_OshiroRooftop",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS03_TheoEscape",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS04_Gondola",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS04_Granny",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS04_MirrorPortal",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS04_MirrorPortal.Fader",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS05_Badeline",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS05_Entrance",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS05_Reflection1",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS05_SaveTheo",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS05_SeeTheo",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS05_TheoInMirror",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS05_TheoPhone",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS06_BossEnd",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS06_BossIntro",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS06_BossMid",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS06_Campfire",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS06_Ending",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS06_Granny",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS06_Reflection",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS06_StarJumpEnd",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS07_Ascend",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS07_Credits",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS07_Ending",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS08_Ending",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS08_Ending.TimeDisplay", new string[] { "Monocle.Component" },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS08_EnterDoor",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }
    }
}
