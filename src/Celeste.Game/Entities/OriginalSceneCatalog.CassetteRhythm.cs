using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterCassetteRhythmSceneCassetteBlock(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.CassetteBlock",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.CassetteBlock", "Celeste.Solid", "Celeste.Platform"]), true);
            result.Register(
                new("Celeste.CassetteBlock.BoxSide",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.CassetteBlockManager",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.CassetteBlockManager"]), true);
        }
    }
}
