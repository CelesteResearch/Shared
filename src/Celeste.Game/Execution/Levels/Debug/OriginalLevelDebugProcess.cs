using System;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Execution.Levels.Debug
{
    public sealed class OriginalLevelDebugProcess
    {
        private readonly IOriginalLevelDebugInput input;
        private readonly IOriginalLevelDebugSceneFactory scenes;
        private readonly IOriginalLevelDebugAssetReloadProcess assets;

        public OriginalLevelDebugProcess(IOriginalLevelDebugInput actualInput,
            IOriginalLevelDebugSceneFactory actualScenes, IOriginalLevelDebugAssetReloadProcess actualAssets)
        {
            input = actualInput ?? throw new ArgumentNullException(nameof(actualInput));
            scenes = actualScenes ?? throw new ArgumentNullException(nameof(actualScenes));
            assets = actualAssets ?? throw new ArgumentNullException(nameof(actualAssets));
        }

        private static SceneUpdateScheduler CurrentScene(OriginalLevelSceneRoot level)
        {
            return ((ISourceScene)level.EngineContext.Frame.Scenes.CurrentScene).SourceScene;
        }

        public void Update(OriginalLevelSceneRoot level)
        {
            if (input.TabPressed &&
                CurrentScene(level).Entities.GetTrackedEntities("Celeste.KeyboardConfigUI").Count == 0 &&
                CurrentScene(level).Entities.GetTrackedEntities("Celeste.ButtonConfigUI").Count == 0)
                level.EngineContext.Frame.Scenes.NextScene =
                    scenes.CreateMapEditor(level.Session.AreaID, level.Session.Mode);
            if (input.F1Pressed)
            {
                assets.ReloadAssets(true, false, false, level.Session.AreaID, level.Session.Mode);
                level.EngineContext.Frame.Scenes.NextScene = scenes.CreateLevelLoader(level.Session);
            }
            else if (input.F2Pressed)
            {
                assets.ReloadAssets(true, true, false, level.Session.AreaID, level.Session.Mode);
                level.EngineContext.Frame.Scenes.NextScene = scenes.CreateLevelLoader(level.Session);
            }
            else if (input.F3Pressed)
            {
                assets.ReloadAssets(true, true, true, level.Session.AreaID, level.Session.Mode);
                level.EngineContext.Frame.Scenes.NextScene = scenes.CreateLevelLoader(level.Session);
            }
        }
    }
}
