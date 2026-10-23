using System.IO;
using System.Xml;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio;
using Celeste.Game.Controls.Source;
using Celeste.Game.Presentation.Completion;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Threading;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Simulation.Runtime.Session;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Vignettes
{
    public class SummitVignetteScene : SourceSceneState
    {
        private CompleteRendererState complete;
        private bool slideFinished;
        private ChapterCompletionSession session;
        private bool ending;
        private bool ready;
        private bool addedRenderer;
        public bool IsReady => ready;

        public SummitVignetteScene(ChapterCompletionSession session, ISourceEngineContext engine)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            this.session = session;
            var process = (IOriginalGameplayProcess)engine;
            OriginalAudioSession.Apply(session.Audio, process.AudioSession.ChannelOutput, process.AudioApplyPolicy);
            var preparation = (engine as global::Celeste.Game.Content.Loading.IOriginalChapterPreparationEnvironment)
                ?.ChapterPreparation;
            if (preparation == null)
                ((IOriginalThreadEnvironment)engine).Threads.Start(LoadCompleteThread, "SUMMIT_VIGNETTE");
            else
                ((IOriginalThreadEnvironment)engine).Threads.Start(LoadCompleteThread,
                    preparation.CreateWorkInfo(session, "SUMMIT_VIGNETTE"));
        }

        private void LoadCompleteThread()
        {
            AtlasData atlas = null;
            var graphics = (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)EngineContext).GameGraphics;
            XmlElement xmlElement = graphics.CompleteScreensXml["Screens"]["SummitIntro"];
            if (xmlElement != null)
                atlas = SourceAtlasLoader.FromAtlas(
                    Path.Combine("Graphics", "Atlases", xmlElement.GetAttribute("atlas")),
                    AtlasDataFormat.PackerNoAtlas, (ISourceAtlasLoaderEnvironment)EngineContext);
            complete = ((IOriginalCompleteRendererConstruction)EngineContext).CreateCompleteRenderer(xmlElement, atlas,
                0f,
                () => slideFinished = true);
            complete.SlideDuration = 7.5f;
            ready = true;
        }

        public override void Update()
        {
            if (ready && !addedRenderer)
            {
                Renderers.Add(complete);
                addedRenderer = true;
            }

            base.Update();
            if ((((IOriginalGameInputProcessEnvironment)EngineContext).InputSource.MenuConfirm.Pressed || slideFinished)
                && !ending && ready)
            {
                ending = true;
                new MountainWipePresentation(this, false, () =>
                    EngineContext.Frame.Scenes.NextScene =
                        ((IOriginalLevelLoaderEnvironment)EngineContext).LevelLoaders.CreateLevelLoader(session));
            }
        }

        public override void End()
        {
            base.End();
            if (complete != null)
                complete.Dispose();
        }
    }
}
