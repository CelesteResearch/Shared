using System;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Levels.Debug;
using Celeste.Game.Profiles;
using Celeste.Input.Devices.Keyboard;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Runtime
{
    internal sealed class GameApplicationLevelDebugServices : IOriginalLevelDebugInput,
        IOriginalLevelDebugSceneFactory, IOriginalLevelDebugAssetReloadProcess
    {
        private readonly GameApplication process;

        public GameApplicationLevelDebugServices(GameApplication actualProcess)
        {
            process = actualProcess ?? throw new ArgumentNullException(nameof(actualProcess));
        }

        public bool TabPressed => process.SourceProfile == GameProfile.Original
            ? process.MInput.Keyboard.Pressed(SourceKeys.Tab)
            : process.CurrentCoreSettings.DebugMap.Pressed;

        public bool F1Pressed => process.MInput.Keyboard.Pressed(SourceKeys.F1);
        public bool F2Pressed => process.MInput.Keyboard.Pressed(SourceKeys.F2);
        public bool F3Pressed => process.MInput.Keyboard.Pressed(SourceKeys.F3);

        public ISourceSceneExecution CreateMapEditor(int areaID, int mode)
        {
            return process.MapEditors.Create(process, process.AreaKeys.Create(areaID, mode));
        }

        public ISourceSceneExecution CreateLevelLoader(ChapterCompletionSession session)
        {
            return process.LevelLoaders.CreateLevelLoader(session);
        }

        public void ReloadAssets(bool levels, bool graphics, bool hires, int areaID, int mode)
        {
            GameRuntime.ReloadAssets(levels, graphics, hires, process.AreaKeys.Create(areaID, mode));
        }
    }
}
