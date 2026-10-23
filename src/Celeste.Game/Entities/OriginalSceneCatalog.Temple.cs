using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterTempleSceneTypes(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.TempleBigEyeball",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.TempleBigEyeball.Fader",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.TempleBigEyeballShockwave",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.TempleCrackedBlock",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.TempleCrackedBlock", "Celeste.Solid", "Celeste.Platform"]), true);
            result.Register(
                new("Celeste.TempleEndingMusicHandler",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.TempleEye",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.TempleGate",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.TempleGate", "Celeste.Solid", "Celeste.Platform"]), true);
            result.Register(
                new("Celeste.TempleMirror",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.TempleMirror.Frame",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.TempleMirrorPortal",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.TempleMirrorPortal.Bg",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.TempleMirrorPortal.Curtain",
                    (string[])
                    [
                        "Celeste.Solid", "Celeste.Platform",
                        typeof(SceneEntityState).FullName,
                    ],
                    (string[])["Celeste.Solid", "Celeste.Platform"]));
            result.Register(
                new("Celeste.TemplePortalTorch",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }
    }
}
