using Celeste.Scene.Tracking;

namespace Celeste.Game.Entities
{
    public static partial class OriginalSceneCatalog
    {
        private static void RegisterAudioScene3dSoundTest(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste._3dSoundTest",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }

        private static void RegisterAudioSceneAltMusicTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.AltMusicTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
            result.Register(
                new SceneEntityType("Celeste.AmbienceParamTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }

        private static void RegisterAudioSceneGrannyLaughSfx(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.GrannyLaughSfx", new string[] { "Monocle.Component" }, new string[] { }),
                false);
        }

        private static void RegisterAudioSceneMusicFadeTrigger(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.MusicFadeTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
            result.Register(
                new SceneEntityType("Celeste.MusicTrigger",
                    new string[]
                        { "Celeste.Trigger", typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { "Celeste.Trigger" }), false);
        }

        private static void RegisterAudioSceneOldSiteChaseMusicHandler(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.OldSiteChaseMusicHandler",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }), false);
        }

        private static void RegisterAudioSceneSoundEmitter(SceneEntityCatalog result)
        {
            result.Register(
                new SceneEntityType("Celeste.SoundEmitter",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
            result.Register(
                new SceneEntityType("Celeste.SoundSource", new string[] { "Monocle.Component" },
                    new string[] { "Celeste.SoundSource" }), true);
            result.Register(
                new SceneEntityType("Celeste.SoundSourceEntity",
                    new string[] { typeof(global::Celeste.Scene.Entities.SceneEntityState).FullName },
                    new string[] { }),
                false);
        }
    }
}
