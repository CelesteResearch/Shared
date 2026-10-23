using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterFarewellCutsceneTypes(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.CS10_BadelineHelps",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS10_CatchTheBird",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS10_Ending",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS10_Farewell",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS10_FinalLaunch",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS10_FinalRoom",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS10_FreeBird",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS10_Gravestone",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS10_HubIntro",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS10_HubIntro.Bird",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS10_MissTheBird",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CS10_MoonIntro",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CSGEN_StrawberrySeeds",
                    (string[])["Celeste.CutsceneEntity", typeof(SceneEntityState).FullName],
                    (string[])[]));
        }
    }
}
