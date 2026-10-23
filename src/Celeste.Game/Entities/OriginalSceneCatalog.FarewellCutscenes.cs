using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterFarewellCutsceneTypes(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.CS10_BadelineHelps",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS10_CatchTheBird",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS10_Ending",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS10_Farewell",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS10_FinalLaunch",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS10_FinalRoom",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS10_FreeBird",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS10_Gravestone",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS10_HubIntro",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS10_HubIntro.Bird",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.CS10_MissTheBird",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CS10_MoonIntro",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CSGEN_StrawberrySeeds",
                    new string[]
                        { "Celeste.CutsceneEntity", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }
    }
}
