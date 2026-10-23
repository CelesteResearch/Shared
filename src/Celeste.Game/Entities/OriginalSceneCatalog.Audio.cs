using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterAudioScene3dSoundTest(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste._3dSoundTest",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterAudioSceneAltMusicTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.AltMusicTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
            result.Register(
                new("Celeste.AmbienceParamTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }

        private static void RegisterAudioSceneGrannyLaughSfx(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.GrannyLaughSfx", (string[])["Monocle.Component"], (string[])[]));
        }

        private static void RegisterAudioSceneMusicFadeTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.MusicFadeTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
            result.Register(
                new("Celeste.MusicTrigger",
                    (string[])["Celeste.Trigger", typeof(SceneEntityState).FullName],
                    (string[])["Celeste.Trigger"]));
        }

        private static void RegisterAudioSceneOldSiteChaseMusicHandler(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.OldSiteChaseMusicHandler",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }

        private static void RegisterAudioSceneSoundEmitter(SceneEntityCatalog result)
        {
            result.Register(
                new("Celeste.SoundEmitter",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
            result.Register(
                new("Celeste.SoundSource", (string[])["Monocle.Component"],
                    (string[])["Celeste.SoundSource"]), true);
            result.Register(
                new("Celeste.SoundSourceEntity",
                    (string[])[typeof(SceneEntityState).FullName],
                    (string[])[]));
        }
    }
}
