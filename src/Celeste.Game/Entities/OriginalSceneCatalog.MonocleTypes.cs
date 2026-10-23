using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterMonocleTypes(SceneEntityCatalog result)
        {
            result.Register(
                new("Monocle.Alarm", (string[])["Monocle.Component"], (string[])[]));
            result.Register(
                new("Monocle.CheatListener",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(new("Monocle.Component", (string[])[], (string[])[]));
            result.Register(
                new("Monocle.Coroutine", (string[])["Monocle.Component"], (string[])[]));
            result.Register(
                new("Monocle.CoroutineHolder", (string[])["Monocle.Component"], (string[])[]));
            result.Register(
                new("Monocle.CounterSet`1", (string[])["Monocle.Component"], (string[])[]));
            result.Register(
                new(typeof(SceneEntityState).FullName, (string[])[],
                    (string[])[]));
            result.Register(
                new("Monocle.GraphicsComponent", (string[])["Monocle.Component"],
                    (string[])[]));
            result.Register(
                new("Monocle.Image", (string[])["Monocle.GraphicsComponent", "Monocle.Component"],
                    (string[])[]));
            result.Register(
                new("Monocle.NumberText",
                    (string[])["Monocle.GraphicsComponent", "Monocle.Component"], (string[])[]));
            result.Register(
                new("Monocle.OutlineText",
                    (string[])["Monocle.Text", "Monocle.GraphicsComponent", "Monocle.Component"],
                    (string[])[]));
            result.Register(
                new("Monocle.ParticleEmitter", (string[])["Monocle.Component"], (string[])[]));
            result.Register(
                new("Monocle.ParticleSystem",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Monocle.PixelText", (string[])["Monocle.Component"], (string[])[]));
            result.Register(
                new("Monocle.Shaker", (string[])["Monocle.Component"], (string[])[]));
            result.Register(
                new("Monocle.ShakerList", (string[])["Monocle.Component"], (string[])[]));
            result.Register(
                new("Monocle.SineWave", (string[])["Monocle.Component"], (string[])[]));
            result.Register(
                new("Monocle.SpecEntity`1",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Monocle.Sprite",
                    (string[])["Monocle.Image", "Monocle.GraphicsComponent", "Monocle.Component"],
                    (string[])[]));
            result.Register(
                new("Monocle.Spritesheet`1",
                    (string[])["Monocle.Image", "Monocle.GraphicsComponent", "Monocle.Component"],
                    (string[])[]));
            result.Register(
                new("Monocle.StateMachine", (string[])["Monocle.Component"], (string[])[]));
            result.Register(
                new("Monocle.Text", (string[])["Monocle.GraphicsComponent", "Monocle.Component"],
                    (string[])[]));
            result.Register(
                new("Monocle.TileGrid", (string[])["Monocle.Component"], (string[])[]));
            result.Register(
                new("Monocle.TimerText",
                    (string[])["Monocle.GraphicsComponent", "Monocle.Component"], (string[])[]));
            result.Register(
                new("Monocle.Tween", (string[])["Monocle.Component"], (string[])[]));
            result.Register(
                new("Monocle.Wiggler", (string[])["Monocle.Component"], (string[])[]));
        }
    }
}
