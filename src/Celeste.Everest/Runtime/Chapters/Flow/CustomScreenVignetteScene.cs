using Celeste.Core.Serialization.Xml;
using System.IO;
using System.Xml;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Atlases;
using Celeste.Everest.Content.Maps.Metadata.Completion;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Presentation.Completion;
using Celeste.Input.Gameplay;
using Celeste.Game.Audio;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Entities;
using Celeste.Game.Presentation.Completion;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Threading;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Formats.Graphics.Xml;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Runtime.Chapters.Flow
{
    public sealed class CustomScreenVignetteScene : SourceSceneState
    {
        private ChapterCompletionSession session;
        private EverestCompleteRendererState renderer;
        private bool addedRenderer;
        private MapMetaCompleteScreen meta;
        private XmlElement xml;
        private bool ready;
        private bool slideFinished;
        private bool ending;
        private readonly IOriginalLevelEnterProcess process;

        public CustomScreenVignetteScene(ChapterCompletionSession session, XmlElement xml,
            MapMetaCompleteScreen meta, IOriginalLevelEnterProcess process)
            : base(process, ((ISourceSceneCatalogEnvironment)process).SceneCatalog,
                ((global::Celeste.Scene.Scheduling.ISourceSceneUpdatePolicyEnvironment)process).PlainScenePolicy)
        {
            this.process = process;
            this.session = session;
            OriginalAudioSession.Apply(session.Audio, process.AudioSession.ChannelOutput, process.AudioApplyPolicy,
                false);
            this.meta = meta;
            this.xml = xml;
            ((IOriginalThreadEnvironment)process).Threads.Start(LoadCompleteThread, "SUMMIT_VIGNETTE");
        }

        private void LoadCompleteThread()
        {
            var atlas = SourceAtlasLoader.FromAtlas(Path.Combine("Graphics", "Atlases",
                    meta == null ? SourceXmlAttributes.Attr(xml, "atlas") : meta.Atlas), AtlasDataFormat.PackerNoAtlas,
                (ISourceAtlasLoaderEnvironment)process);
            renderer = new EverestCompleteRendererState(process, xml, atlas, 0f,
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
