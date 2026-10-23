using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterLightingSceneBloomFadeTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.BloomFadeTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
            result.Register(
                new SceneEntityType("Celeste.BloomPoint", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.BloomPoint" }), true);
        }

        private static void RegisterLightingSceneLightBeam(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.LightBeam",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.LightFadeTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }

        private static void RegisterLightingSceneLightOcclude(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.LightOcclude", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.LightOcclude" }), true);
        }

        private static void RegisterLightingScenePropLight(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.PropLight",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterLightingSceneVertexLight(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.VertexLight", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.VertexLight" }), true);
        }
    }
}
