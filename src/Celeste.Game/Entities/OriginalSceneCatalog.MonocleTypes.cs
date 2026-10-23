using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterMonocleTypes(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Monocle.Alarm", new string[] { "Monocle.Component" }, new string[] { }), false);
            result.Register(
                new SceneEntityType("Monocle.CheatListener",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(new SceneEntityType("Monocle.Component", new string[] { }, new string[] { }), false);
            result.Register(
                new SceneEntityType("Monocle.Coroutine", new string[] { "Monocle.Component" }, new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Monocle.CoroutineHolder", new string[] { "Monocle.Component" }, new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Monocle.CounterSet`1", new string[] { "Monocle.Component" }, new string[] { }),
                false);
            result.Register(
                new SceneEntityType(typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName, new string[] { },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Monocle.GraphicsComponent", new string[] { "Monocle.Component" },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Monocle.Image", new string[] { "Monocle.GraphicsComponent", "Monocle.Component" },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Monocle.NumberText",
                    new string[] { "Monocle.GraphicsComponent", "Monocle.Component" }, new string[] { }), false);
            result.Register(
                new SceneEntityType("Monocle.OutlineText",
                    new string[] { "Monocle.Text", "Monocle.GraphicsComponent", "Monocle.Component" },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Monocle.ParticleEmitter", new string[] { "Monocle.Component" }, new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Monocle.ParticleSystem",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Monocle.PixelText", new string[] { "Monocle.Component" }, new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Monocle.Shaker", new string[] { "Monocle.Component" }, new string[] { }), false);
            result.Register(
                new SceneEntityType("Monocle.ShakerList", new string[] { "Monocle.Component" }, new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Monocle.SineWave", new string[] { "Monocle.Component" }, new string[] { }), false);
            result.Register(
                new SceneEntityType("Monocle.SpecEntity`1",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Monocle.Sprite",
                    new string[] { "Monocle.Image", "Monocle.GraphicsComponent", "Monocle.Component" },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Monocle.Spritesheet`1",
                    new string[] { "Monocle.Image", "Monocle.GraphicsComponent", "Monocle.Component" },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Monocle.StateMachine", new string[] { "Monocle.Component" }, new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Monocle.Text", new string[] { "Monocle.GraphicsComponent", "Monocle.Component" },
                    new string[] { }), false);
            result.Register(
                new SceneEntityType("Monocle.TileGrid", new string[] { "Monocle.Component" }, new string[] { }), false);
            result.Register(
                new SceneEntityType("Monocle.TimerText",
                    new string[] { "Monocle.GraphicsComponent", "Monocle.Component" }, new string[] { }), false);
            result.Register(
                new SceneEntityType("Monocle.Tween", new string[] { "Monocle.Component" }, new string[] { }), false);
            result.Register(
                new SceneEntityType("Monocle.Wiggler", new string[] { "Monocle.Component" }, new string[] { }), false);
        }
    }
}
