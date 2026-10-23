using System;
using System.Threading.Tasks;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Scene.Scenes;

namespace Celeste.Everest.Content.Reloading
{
    public sealed partial class EverestAssetReloadScene : SourceSceneState, IDisposable
    {
        internal readonly ISourceSceneExecution OrigScene;
        private readonly EverestAssetReloadProcess process;
        private SourceTexture2DResource snapshotTex;
        private SourceTexture2DResource snapshotGrayScaleTex;

        internal EverestAssetReloadScene(EverestAssetReloadProcess process, ISourceSceneExecution origScene)
            : base(process.EngineContext, process.Catalog, process.ScenePolicy)
        {
            this.process = process;
            OrigScene = origScene;
            workerTaskScheduler = new("Everest Reload Worker");
            workerTaskFactory = new(workerTaskScheduler.CancellationToken,
                TaskCreationOptions.None, TaskContinuationOptions.None, workerTaskScheduler);
        }

        public void Dispose()
        {
            workerTaskScheduler?.Dispose();
            snapshotTex?.Dispose();
            snapshotGrayScaleTex?.Dispose();
        }

        public override void End()
        {
            process.Logger.Log(EverestLogLevel.Warn, "reload",
                "Cancelling reload as an external source initiated a scene transition - THIS IS A BAD IDEA, THINGS MIGHT BREAK");
            if (process.EngineUpdate.OverloadGameLoop == Update)
                process.EngineUpdate.OverloadGameLoop = process.ReturnToGameLoop;
            process.ReturnToScene = null;
            process.ReturnToGameLoop = null;
            base.End();
            Dispose();
            process.ReleaseReloadSemaphore();
        }
    }
}
