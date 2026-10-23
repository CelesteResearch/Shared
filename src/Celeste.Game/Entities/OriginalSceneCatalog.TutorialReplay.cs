using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterTutorialReplaySceneBillboard(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Billboard", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.Billboard" }), true);
        }

        private static void RegisterTutorialReplaySceneBirdTutorialGui(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.BirdTutorialGui",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterTutorialReplayScenePlaybackBillboard(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.PlaybackBillboard",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.PlaybackBillboard" }), true);
            result.Register(
                new SceneEntityType("Celeste.PlaybackBillboard.FG",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterTutorialReplayScenePlayerPlayback(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.PlayerPlayback",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterTutorialReplaySceneWaveDashPresentation(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.WaveDashPresentation",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.WaveDashTutorialMachine",
                    new string[]
                    {
                        "Celeste.JumpThru", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.JumpThru", "Celeste.Platform" }), false);
        }
    }
}
