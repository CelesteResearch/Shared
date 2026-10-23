using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Actors.Foundation;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterStoryScenesSceneAscendManager(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.AscendManager",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.AscendManager.Clouds",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.AscendManager.Fader",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.AscendManager.Streaks",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterStoryScenesSceneBadelineAutoAnimator(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.BadelineAutoAnimator", (string[])["Monocle.Component"],
                    (string[])[]));
        }

        private static void RegisterStoryScenesSceneBadelineDummy(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.BadelineDummy",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterStoryScenesSceneBirdNPC(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.BirdNPC",
                    (string[])
                    [
                        typeof(SourceActorEntityState).FullName,
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])
                    [
                        typeof(SourceActorEntityState).FullName,
                    ]));
            result.Register(
                new("Celeste.BirdPath",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.BirdPathTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }

        private static void RegisterStoryScenesSceneBreathingMinigame(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.BreathingMinigame",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.BreathingRumbler",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterStoryScenesSceneCutsceneNode(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.CutsceneNode",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.CutsceneNode"]), true);
        }

        private static void RegisterStoryScenesSceneDreamMirror(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.DreamMirror",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterStoryScenesSceneEventTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.EventTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }

        private static void RegisterStoryScenesSceneFlingBird(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.FlingBird",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.FlingBirdIntro",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterStoryScenesSceneForsakenCitySatellite(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.ForsakenCitySatellite",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.ForsakenCitySatellite.CodeBird",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterStoryScenesSceneGondola(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Gondola",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
            result.Register(
                new("Celeste.Gondola.Rope",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.GondolaDarkness",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.GondolaDarkness.Blackness",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterStoryScenesSceneHahaha(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Hahaha",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterStoryScenesSceneIntroCar(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.IntroCar",
                    (string[])
                    [
                        "Celeste.JumpThru", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.JumpThru", "Celeste.Platform"]));
        }

        private static void RegisterStoryScenesSceneIntroPavement(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.IntroPavement",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
        }

        private static void RegisterStoryScenesSceneKevinsPC(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.KevinsPC",
                    (string[])
                    [
                        typeof(SourceActorEntityState).FullName,
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])
                    [
                        typeof(SourceActorEntityState).FullName,
                    ]));
        }

        private static void RegisterStoryScenesSceneMemorial(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Memorial",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.MemorialText",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterStoryScenesSceneMirrorReflection(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.MirrorReflection", (string[])["Monocle.Component"],
                    (string[])["Celeste.MirrorReflection"]), true);
            result.Register(
                new("Celeste.MirrorSurface", (string[])["Monocle.Component"],
                    (string[])["Celeste.MirrorSurface"]), true);
            result.Register(
                new("Celeste.MirrorSurfaces",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.MirrorSurfaces"]), true);
        }

        private static void RegisterStoryScenesSceneOshiroLobbyBell(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.OshiroLobbyBell",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.OshiroSprite",
                    (string[])["Monocle.Sprite", "Monocle.Image", "Monocle.GraphicsComponent", "Monocle.Component"],
                    (string[])[]));
            result.Register(
                new("Celeste.OshiroTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }

        private static void RegisterStoryScenesScenePayphone(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Payphone",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Payphone"]), true);
        }

        private static void RegisterStoryScenesScenePoem(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Poem",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterStoryScenesScenePowerSourceNumber(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.PowerSourceNumber",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterStoryScenesSceneReflectionHeartStatue(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.ReflectionHeartStatue",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.ReflectionHeartStatue.Torch",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.ReflectionTentacles",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])["Celeste.ReflectionTentacles"]), true);
        }

        private static void RegisterStoryScenesSceneResortMirror(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.ResortMirror",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.ResortRoofEnding",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
        }

        private static void RegisterStoryScenesSceneSelfie(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.Selfie",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterStoryScenesSceneTheoPhone(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.TheoPhone",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }
    }
}
