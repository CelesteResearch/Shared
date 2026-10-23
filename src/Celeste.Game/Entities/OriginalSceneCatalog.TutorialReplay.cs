using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterTutorialReplaySceneBillboard(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Billboard", (string[])["Monocle.Component"],
                    (string[])["Celeste.Billboard"]), true);
        }

        private static void RegisterTutorialReplaySceneBirdTutorialGui(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.BirdTutorialGui",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterTutorialReplayScenePlaybackBillboard(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.PlaybackBillboard",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.PlaybackBillboard"]), true);
            result.Register(
                new("Celeste.PlaybackBillboard.FG",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterTutorialReplayScenePlayerPlayback(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.PlayerPlayback",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterTutorialReplaySceneWaveDashPresentation(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.WaveDashPresentation",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.WaveDashTutorialMachine",
                    (string[])
                    [
                        "Celeste.JumpThru", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.JumpThru", "Celeste.Platform"]));
        }
    }
}
