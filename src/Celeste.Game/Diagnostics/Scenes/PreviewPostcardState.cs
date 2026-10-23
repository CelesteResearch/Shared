using System.Collections;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Scene.Scheduling;
using Celeste.Game.Entities.Postcards;
using Celeste.Game.Presentation.Hud;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Overworld;

namespace Celeste.Game.Diagnostics.Scenes
{
    public class PreviewPostcardState : SourceSceneState
    {
        private PostcardState postcard;

        public PreviewPostcardState(ISourceEngineContext engine, PostcardState postcard)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            ((IOriginalGameplayProcess)engine).AudioSession.SetMusic(null);
            ((IOriginalGameplayProcess)engine).AudioSession.SetAmbience(null);
            this.postcard = postcard;
            var entity =
                new SceneEntityState(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration);
            entity.OwnedComponents.Add(new SimulationCoroutine(engine, Routine(postcard)));
            SourceScene.QueueSourceEntity(entity);
            Renderers.Add(new HudRendererState());
        }

        private IEnumerator Routine(PostcardState postcard)
        {
            yield return 0.25f;
            SourceScene.QueueSourceEntity(postcard);
            yield return postcard.DisplayRoutine();
            EngineContext.Frame.Scenes.NextScene = ((IOriginalOverworldLoaderEnvironment)EngineContext)
                .OverworldLoaders.CreateOverworldLoader(OverworldStartMode.MainMenu);
        }

        public override void BeforeRender()
        {
            base.BeforeRender();
            if (postcard != null)
                postcard.BeforeRender();
        }
    }
}
