using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterEarlyCutsceneTypes(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.CS00_Ending",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS00_Ending.EndingCutsceneDelay",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS00_Granny",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS01_Ending",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS02_BadelineIntro",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS02_DreamingPhonecall",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS02_Ending",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS02_Journal",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS02_Journal.PoemPage",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS02_Mirror",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS03_Diary",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS03_Ending",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS03_Ending.BgFlash",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS03_Guestbook",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS03_Memo",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS03_Memo.MemoPage",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS03_OshiroBreakdown",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS03_OshiroClutter",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS03_OshiroHallway1",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS03_OshiroHallway2",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS03_OshiroLobby",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS03_OshiroMasterSuite",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS03_OshiroRooftop",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS03_TheoEscape",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS04_Gondola",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS04_Granny",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS04_MirrorPortal",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS04_MirrorPortal.Fader",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS05_Badeline",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS05_Entrance",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS05_Reflection1",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS05_SaveTheo",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS05_SeeTheo",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS05_TheoInMirror",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS05_TheoPhone",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS06_BossEnd",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS06_BossIntro",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS06_BossMid",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS06_Campfire",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS06_Ending",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS06_Granny",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS06_Reflection",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS06_StarJumpEnd",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS07_Ascend",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS07_Credits",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS07_Ending",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS08_Ending",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS08_Ending.TimeDisplay", (string[])["Monocle.Component"],
                    (string[])[]));
            result.Register(
                new("Celeste.CS08_EnterDoor",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
        }
    }
}
