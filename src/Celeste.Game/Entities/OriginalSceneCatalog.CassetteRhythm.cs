using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterCassetteRhythmSceneCassetteBlock(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.CassetteBlock",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.CassetteBlock", "Celeste.Solid", "Celeste.Platform" }), true);
            result.Register(
                new SceneEntityType("Celeste.CassetteBlock.BoxSide",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.CassetteBlockManager",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.CassetteBlockManager" }), true);
        }
    }
}
