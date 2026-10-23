using System.IO;
using System.Xml;
using Celeste.Core.Serialization.Xml;
using Celeste.Everest.Content.Maps.Metadata.Completion;
using Celeste.Everest.Presentation.Completion;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Game.Audio;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Threading;
using Celeste.Input.Gameplay;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Runtime.Chapters.Flow
{
    public sealed class CustomScreenVignetteScene : SourceSceneState
    {
        private readonly ChapterCompletionSession session;
        private EverestCompleteRendererState renderer;
        private bool addedRenderer;
        private readonly MapMetaCompleteScreen meta;
        private readonly XmlElement xml;
        private bool ready;
        private bool slideFinished;
        private bool ending;
        private readonly IOriginalLevelEnterProcess process;

        public CustomScreenVignetteScene(ChapterCompletionSession session, XmlElement xml,
            MapMetaCompleteScreen meta, IOriginalLevelEnterProcess process)
            : base(process, ((ISourceSceneCatalogEnvironment)process).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)process).PlainScenePolicy)
        {
            this.process = process;
            this.session = session;
            OriginalAudioSession.Apply(session.Audio, process.AudioSession.ChannelOutput, process.AudioApplyPolicy);
            this.meta = meta;
            this.xml = xml;
            ((IOriginalThreadEnvironment)process).Threads.Start(LoadCompleteThread, "SUMMIT_VIGNETTE");
        }

        private void LoadCompleteThread()
        {
            var atlas = SourceAtlasLoader.FromAtlas(Path.Combine("Graphics", "Atlases",
                    meta == null ? xml.Attr("atlas") : meta.Atlas), AtlasDataFormat.PackerNoAtlas,
                (ISourceAtlasLoaderEnvironment)process);
            renderer = new(process, xml, atlas, 0f,
                () => slideFinished = true, meta);
            renderer.SlideDuration = 7.5f;
            ready = true;
        }

        public override void Update()
        {
            if (ready && !addedRenderer)
            {
                Renderers.Add(renderer);
                addedRenderer = true;
            }

            base.Update();
            if ((((IGameInputEnvironment)process).Input[GameAction.MenuConfirm].Pressed || slideFinished) && !ending &&
                ready)
            {
                ending = true;
                OriginalAreaScreenWipe.DoScreenWipe(process.AreaKeys.GetArea(process.AreaKeys.GetSessionArea(session)),
                    this, false,
                    () => process.Frame.Scenes.NextScene = process.LevelLoaders.CreateLevelLoader(session));
            }
        }

        public override void End()
        {
            base.End();
            renderer?.Dispose();
        }
    }
}
