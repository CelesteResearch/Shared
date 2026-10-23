using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterStoryScenesSceneAscendManager(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.AscendManager",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.AscendManager.Clouds",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.AscendManager.Fader",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.AscendManager.Streaks",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterStoryScenesSceneBadelineAutoAnimator(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.BadelineAutoAnimator", new string[] { "Monocle.Component" },
                    new string[] { }), false);
        }

        private static void RegisterStoryScenesSceneBadelineDummy(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.BadelineDummy",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterStoryScenesSceneBirdNPC(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.BirdNPC",
                    new string[]
                    {
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName,
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[]
                    {
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName
                    }), false);
            result.Register(
                new SceneEntityType("Celeste.BirdPath",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.BirdPathTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }

        private static void RegisterStoryScenesSceneBreathingMinigame(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.BreathingMinigame",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.BreathingRumbler",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterStoryScenesSceneCutsceneNode(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.CutsceneNode",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.CutsceneNode" }), true);
        }

        private static void RegisterStoryScenesSceneDreamMirror(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.DreamMirror",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterStoryScenesSceneEventTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.EventTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }

        private static void RegisterStoryScenesSceneFlingBird(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.FlingBird",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.FlingBirdIntro",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterStoryScenesSceneForsakenCitySatellite(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.ForsakenCitySatellite",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.ForsakenCitySatellite.CodeBird",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterStoryScenesSceneGondola(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Gondola",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
            result.Register(
                new SceneEntityType("Celeste.Gondola.Rope",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.GondolaDarkness",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.GondolaDarkness.Blackness",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterStoryScenesSceneHahaha(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Hahaha",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterStoryScenesSceneIntroCar(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.IntroCar",
                    new string[]
                    {
                        "Celeste.JumpThru", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.JumpThru", "Celeste.Platform" }), false);
        }

        private static void RegisterStoryScenesSceneIntroPavement(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.IntroPavement",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
        }

        private static void RegisterStoryScenesSceneKevinsPC(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.KevinsPC",
                    new string[]
                    {
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName,
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[]
                    {
                        typeof(global::Celeste.Simulation.Gameplay.Actors.Foundation.SourceActorEntityState).FullName
                    }), false);
        }

        private static void RegisterStoryScenesSceneMemorial(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Memorial",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.MemorialText",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterStoryScenesSceneMirrorReflection(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.MirrorReflection", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.MirrorReflection" }), true);
            result.Register(
                new SceneEntityType("Celeste.MirrorSurface", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.MirrorSurface" }), true);
            result.Register(
                new SceneEntityType("Celeste.MirrorSurfaces",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.MirrorSurfaces" }), true);
        }

        private static void RegisterStoryScenesSceneOshiroLobbyBell(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.OshiroLobbyBell",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.OshiroSprite",
                    new string[]
                        { "Monocle.Sprite", "Monocle.Image", "Monocle.GraphicsComponent", "Monocle.Component" },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.OshiroTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }

        private static void RegisterStoryScenesScenePayphone(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Payphone",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Payphone" }), true);
        }

        private static void RegisterStoryScenesScenePoem(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Poem",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterStoryScenesScenePowerSourceNumber(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.PowerSourceNumber",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterStoryScenesSceneReflectionHeartStatue(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.ReflectionHeartStatue",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.ReflectionHeartStatue.Torch",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Celeste.ReflectionTentacles",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.ReflectionTentacles" }), true);
        }

        private static void RegisterStoryScenesSceneResortMirror(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.ResortMirror",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.ResortRoofEnding",
                    new string[]
                    {
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName
                    },
                    new string[] { "Celeste.Solid", "Celeste.Platform" }), false);
        }

        private static void RegisterStoryScenesSceneSelfie(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.Selfie",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterStoryScenesSceneTheoPhone(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.TheoPhone",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }
    }
}
