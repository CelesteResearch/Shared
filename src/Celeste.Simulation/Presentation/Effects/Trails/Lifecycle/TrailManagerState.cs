using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Graphics.Display;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Trails;
using Celeste.Core.Rendering.States;

namespace Celeste.Simulation.Presentation.Effects.Trails.Lifecycle
{
    public class TrailManagerState : SceneEntityState
    {
        protected readonly ISourceEngineContext engine;
        protected readonly ISourceRenderEnvironment renderEngine;

        protected internal float CubeOut(float value) =>
            ((Celeste.Core.Mathematics.Easing.ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(value);

        protected TrailSnapshotState[] snapshots = new TrailSnapshotState[64];
        protected internal VirtualRenderTarget Buffer;
        protected bool dirty;

        public TrailManagerState(ISourceEngineContext engine, ISourceRenderEnvironment renderEngine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            this.renderEngine = renderEngine ?? throw new ArgumentNullException(nameof(renderEngine));
            Tags = ((global::Celeste.Scene.Scheduling.ExecutionTags.ISourceGlobalFrozenExecutionTagsEnvironment)engine)
                .GlobalFrozenExecutionTags.Global.Value;
            Depth = 10;
            var hook = new BeforeRenderCallbackComponentState(BeforeRender);
            OwnedComponents.Add(hook);
            var reflection = new MirrorReflectionState();
            OwnedComponents.Add(reflection);
        }

        public override void Removed(object actualScene)
        {
            DisposeBuffer();
            base.Removed(actualScene);
        }

        public override void SceneEnd(object actualScene)
        {
            DisposeBuffer();
            base.SceneEnd(actualScene);
        }

        protected virtual void DisposeBuffer()
        {
            if (Buffer != null) Buffer.Dispose();
            Buffer = null;
        }

        internal void Release(int index) => snapshots[index] = null;

        protected virtual void BeforeRender()
        {
            if (!dirty) return;
            if (Buffer == null)
                Buffer = ((ISourceVirtualContentEnvironment)engine).VirtualContent
                    .CreateRenderTarget("trail-manager", 512, 512);
            var context = renderEngine.CurrentContext;
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(
                (SourceRenderTarget2DResource)Buffer.Target);
            var batch = ((ISourceDrawScope)context).Draw.SpriteBatch;
            batch.Begin(SourceSpriteSortMode.Deferred,
                ((ISourceTrailBlendEnvironment)engine).TrailBlends.OccludeBlendState);
            for (int i = 0; i < snapshots.Length; i++)
                if (snapshots[i] != null && !snapshots[i].Drawn)
                    SourcePrimitiveDrawing.Rect(context, this, i % 8 * 64, i / 8 * 64, 64f, 64f,
                        PackedColor.Transparent);
            batch.End();
            batch.Begin(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend, SourceSamplerState.PointClamp, null,
                SourceRasterizerState.CullNone);
            for (int j = 0; j < snapshots.Length; j++)
            {
                if (snapshots[j] == null || snapshots[j].Drawn) continue;
                TrailSnapshotState snapshot = snapshots[j];
                Vector2 offset = new Vector2(((float)(j % 8) + .5f) * 64f,
                    ((float)(j / 8) + .5f) * 64f) - snapshot.Position;
                if (snapshot.Hair != null)
                {
                    for (int k = 0; k < snapshot.Hair.Nodes.Count; k++) snapshot.Hair.Nodes[k] += offset;
                    snapshot.Hair.Render(context);
                    for (int l = 0; l < snapshot.Hair.Nodes.Count; l++) snapshot.Hair.Nodes[l] -= offset;
                }

                Vector2 scale = snapshot.Sprite.Scale;
                snapshot.Sprite.Scale = snapshot.SpriteScale;
                snapshot.Sprite.Position += offset;
                snapshot.Sprite.Render(context);
                snapshot.Sprite.Scale = scale;
                snapshot.Sprite.Position -= offset;
                snapshot.Drawn = true;
            }

            batch.End();
            batch.Begin(SourceSpriteSortMode.Deferred,
                ((ISourceTrailBlendEnvironment)engine).TrailBlends.MaxBlendState);
            SourcePrimitiveDrawing.Rect(context, this, 0f, 0f, Buffer.Width, Buffer.Height, PackedColor.White);
            batch.End();
            dirty = false;
        }

        public static void Add(ISourceEngineContext engine, ISourceRenderEnvironment renderEngine,
            ISourceOwnedComponentList entity, PackedColor color,
            float duration = 1f, bool frozenUpdate = false, bool useRawDeltaTime = false)
        {
            SpriteImage image = entity.OwnedComponents.Get<PlayerSprite>();
            if (image == null) image = entity.OwnedComponents.Get<Sprite>();
            PlayerHair hair = entity.OwnedComponents.Get<PlayerHair>();
            Add(engine, renderEngine, ((ISourceEntityPosition)entity).Position, image, hair,
                image.Scale, color, ((ISceneEntityDepth)entity).DepthState.RawDepth + 1,
                duration, frozenUpdate, useRawDeltaTime);
        }

        public static void Add(ISourceEngineContext engine, ISourceRenderEnvironment renderEngine,
            ISourceOwnedComponentList entity, Vector2 scale, PackedColor color,
            float duration = 1f)
        {
            SpriteImage image = entity.OwnedComponents.Get<PlayerSprite>();
            if (image == null) image = entity.OwnedComponents.Get<Sprite>();
            PlayerHair hair = entity.OwnedComponents.Get<PlayerHair>();
            Add(engine, renderEngine, ((ISourceEntityPosition)entity).Position, image, hair,
                scale, color, ((ISceneEntityDepth)entity).DepthState.RawDepth + 1, duration);
        }

        public static void Add(ISourceEngineContext engine, ISourceRenderEnvironment renderEngine,
            Vector2 position, SpriteImage image, PackedColor color, int depth,
            float duration = 1f)
            => Add(engine, renderEngine, position, image, null, image.Scale, color, depth, duration);

        public static TrailSnapshotState Add(ISourceEngineContext engine, ISourceRenderEnvironment renderEngine,
            Vector2 position, SpriteImage sprite, PlayerHair hair, Vector2 scale,
            PackedColor color, int depth, float duration = 1f, bool frozenUpdate = false, bool useRawDeltaTime = false)
        {
            var scene = (ISourceScene)engine.Frame.Scenes.CurrentScene;
            var managers = scene.SourceScene.Entities.GetTrackedEntities("Celeste.TrailManager");
            TrailManagerState manager = managers.Count == 0 ? null : (TrailManagerState)managers[0];
            if (manager == null)
            {
                manager = ((ISourceTrailConstructionEnvironment)engine).TrailConstruction.Create(engine, renderEngine);
                scene.SourceScene.QueueSourceEntity(manager);
            }

            for (int i = 0; i < manager.snapshots.Length; i++)
            {
                if (manager.snapshots[i] != null) continue;
                // Pool registration is mandatory at the unique process source Pooler startup.
                var snapshot = engine.EntityPools.Create<TrailSnapshotState>(() => new TrailSnapshotState(engine));
                snapshot.Init(manager, i, position, sprite, hair, scale, color, duration, depth,
                    frozenUpdate, useRawDeltaTime);
                manager.snapshots[i] = snapshot;
                manager.dirty = true;
                scene.SourceScene.QueueSourceEntity(snapshot);
                return snapshot;
            }

            return null;
        }

        public static void Clear(ISourceEngineContext engine)
        {
            var scene = (ISourceScene)engine.Frame.Scenes.CurrentScene;
            var managers = scene.SourceScene.Entities.GetTrackedEntities("Celeste.TrailManager");
            var manager = managers.Count == 0 ? null : (TrailManagerState)managers[0];
            if (manager == null) return;
            for (int i = 0; i < manager.snapshots.Length; i++)
                if (manager.snapshots[i] != null)
                    manager.snapshots[i].RemoveSelf();
        }

        protected internal virtual void RenderSnapshot(ISourceRenderContext context, TrailSnapshotState snapshot)
        {
            var buffer = Buffer;
            var source =
                new global::Celeste.Core.Geometry.IntRect(snapshot.Index % 8 * 64, snapshot.Index / 8 * 64, 64, 64);
            float fade = snapshot.Duration > 0f ? .75f * (1f - CubeOut(snapshot.Percent)) : 1f;
            if (buffer != null)
                ((ISourceDrawScope)context).Draw.SpriteBatch.Draw((SourceRenderTarget2DResource)buffer.Target,
                    snapshot.Position, source,
                    (snapshot.Color * fade).PackedValue, 0f, new Vector2(64f, 64f) * .5f, Vector2.One,
                    SourceSpriteEffects.None, 0f);
        }
    }
}
