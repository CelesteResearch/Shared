using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterLightingSceneBloomFadeTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.BloomFadeTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
            result.Register(
                new("Celeste.BloomPoint", (string[])["Monocle.Component"],
                    (string[])["Celeste.BloomPoint"]), true);
        }

        private static void RegisterLightingSceneLightBeam(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.LightBeam",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.LightFadeTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }

        private static void RegisterLightingSceneLightOcclude(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.LightOcclude", (string[])["Monocle.Component"],
                    (string[])["Celeste.LightOcclude"]), true);
        }

        private static void RegisterLightingScenePropLight(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.PropLight",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterLightingSceneVertexLight(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.VertexLight", (string[])["Monocle.Component"],
                    (string[])["Celeste.VertexLight"]), true);
        }
    }
}
