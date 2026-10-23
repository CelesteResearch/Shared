using System;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.Renderers;
using Celeste.Core.Scheduling;
using Celeste.Core.Scheduling.Hooks;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Scene.Entities;
using Celeste.Scene.Rendering;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Scenes
{
    public partial class SourceSceneState : ISourceScene, ISourceEngineContextScene,
        ISourceSceneExecution, ISourceSceneClock, ISourceSceneGraphicsLifecycle,
        ISourceRendererScene, ISourceRenderContextScene, ISourceSceneRenderExecution
    {
        public ISourceEngineContext EngineContext { get; }
        public SceneUpdateScheduler SourceScene { get; }
        public ISourceComponentIndex ComponentIndex => SourceScene.Components;
        public SceneRendererList Renderers { get; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public SceneEntityState HelperEntity { get; private set; }
        public float DeltaTime => EngineContext.Frame.DeltaTime;
        public float RawDeltaTime => EngineContext.Frame.RawDeltaTime;

        public bool Paused
        {
            get => SourceScene.Paused;
            set => SourceScene.Paused = value;
        }

        public bool Focused => SourceScene.Focused;

        public float TimeActive
        {
            get => SourceScene.Clock.TimeActive;
            set => SourceScene.Clock.TimeActive = value;
        }

        public float RawTimeActive
        {
            get => SourceScene.Clock.RawTimeActive;
            set => SourceScene.Clock.RawTimeActive = value;
        }

        public Action OnEndOfFrame
        {
            get => SourceScene.OnEndOfFrame;
            set => SourceScene.OnEndOfFrame = value;
        }

        public ISourceRenderContext SourceRenderContext => ((ISourceRenderEnvironment)EngineContext).CurrentContext;

        public SourceSceneState(ISourceEngineContext engine, SceneEntityCatalog catalog,
            SceneUpdatePolicy policy)
        {
            EngineContext = engine ?? throw new ArgumentNullException(nameof(engine));
            SourceScene = new(catalog, policy,
                ((ISourceEntityQueueEnvironment)engine).EntityQueuePolicy,
                ((ISourceEntityAddMetadataEnvironment)engine).EntityAddMetadata,
                ((ISourceEntityListProcessEnvironment)engine).EntityListProcess);
            SourceScene.BindActualSceneIdentity(this);
            Renderers = new(this, SelectRenderer);
            HelperEntity =
                new(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration);
            SourceScene.QueueSourceEntity(HelperEntity);
        }

        private void SelectRenderer(ISceneRenderer renderer)
        {
            ((ISourceDrawScope)EngineContext).Draw.Renderer = renderer;
        }

        public virtual void Begin()
        {
            SourceScene.DispatchSceneBegin();
        }

        public virtual void End()
        {
            SourceScene.DispatchSceneEnd();
        }

        public virtual void BeforeUpdate()
        {
            BeforeUpdateSourceBody();
        }

        private void BeforeUpdateSourceBody()
        {
            SourceScene.BeforeUpdate(DeltaTime, RawDeltaTime);
            Renderers.UpdateLists();
        }

        public virtual void Update()
        {
            if (!Paused)
            {
                SourceScene.Entities.Update(EngineContext);
                Renderers.Update();
            }

            SourceRuntimeExtensions
                .Get<ISourceGameUpdateObserver>(EngineContext)
                ?.AfterSceneUpdate();
        }

        public virtual void AfterUpdate()
        {
            SourceScene.DispatchAfterUpdate();
            ((ISourceUpdateMethodHooksEnvironment)EngineContext)
                .SourceSceneUpdateHooks.InvokeAfterUpdate(this);
        }

        public virtual void BeforeRender()
        {
            Renderers.BeforeRender();
        }

        public virtual void Render()
        {
            Renderers.Render();
        }

        public virtual void AfterRender()
        {
            Renderers.AfterRender();
        }

        public virtual void HandleGraphicsReset()
        {
            SourceScene.HandleEntityGraphicsReset();
        }

        public virtual void HandleGraphicsCreate()
        {
            SourceScene.HandleEntityGraphicsCreate();
        }

        public virtual void GainFocus()
        {
        }

        public virtual void LoseFocus()
        {
        }

        public void SetEntityActualDepth(object identity, SceneEntityDepthState fields)
        {
            SourceScene.SetEntityActualDepth(identity, fields);
        }

        public void SetEntityTags(object identity, SceneTagSet tags)
        {
            SourceScene.SetEntityTags(identity, tags);
        }

        public bool RemoveEntity(object identity)
        {
            return SourceScene.RemoveEntity(identity);
        }

        public void AddEntity(ISourceEntityUpdate entity)
        {
            SourceScene.QueueSourceEntity(entity);
        }

        public bool BetweenInterval(float interval)
        {
            return SourceScene.Clock.BetweenInterval(interval);
        }

        public bool BetweenRawInterval(float interval)
        {
            return SourceScene.Clock.BetweenRawInterval(interval);
        }

        public bool OnInterval(float interval)
        {
            return SourceScene.Clock.OnInterval(interval, EngineContext);
        }

        public bool OnInterval(float interval, float offset)
        {
            return SourceScene.Clock.OnInterval(interval, offset, EngineContext);
        }

        public bool OnRawInterval(float interval)
        {
            return SourceScene.Clock.OnRawInterval(interval, EngineContext);
        }

        public bool OnRawInterval(float interval, float offset)
        {
            return SourceScene.Clock.OnRawInterval(interval, offset, EngineContext);
        }
    }
}
