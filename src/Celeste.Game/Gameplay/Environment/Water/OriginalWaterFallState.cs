using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;
using Color = Celeste.Core.Display.PackedColor;
using Level = Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;
using Solid = Celeste.Simulation.Gameplay.Platforms.Foundation.SourceSolidEntityState;
using SoundSource = Celeste.Simulation.Audio.Sources.SoundSourceComponentState;

namespace Celeste.Game.Gameplay.Environment.Water
{
    public class OriginalWaterFallState : SceneEntityState, ISourceEngineContextEntity
    {
        private readonly ISourceEngineContext engine;
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => engine;

        protected float height;

        protected OriginalWaterState water;

        private Solid solid;

        private SoundSource loopingSfx;

        private SoundSource enteringSfx;

        protected virtual Color FillColor => ((IOriginalWaterStaticsEnvironment)engine).WaterStatics.FillColor;
        protected virtual Color SurfaceColor => ((IOriginalWaterStaticsEnvironment)engine).WaterStatics.SurfaceColor;
        protected virtual bool ShouldRipple => water != null;

        protected virtual bool HasDeepWaterEntry => water != null && !SourceSceneCollision.CheckRect(
            ((Level)Scene).Scheduler.Entities, "Celeste.Solid",
            new((int)X, (int)(Y + height), 8, 16));

        public OriginalWaterFallState(Vector2 position, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            Depth = -9999;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
        }

        public OriginalWaterFallState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data.Position + offset, engine)
        {
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            var level = Scene as Level;
            var flag = false;
            height = 8f;
            while (Y + height < level.Bounds.Bottom &&
                   (water = SourceSceneCollision.FirstRect<OriginalWaterState>(((Level)Scene).Scheduler.Entities,
                       "Celeste.Water", new((int)X, (int)(Y + height), 8, 8))) == null && ((solid =
                           SourceSceneCollision.FirstRect<Solid>(((Level)Scene).Scheduler.Entities, "Celeste.Solid",
                               new((int)X, (int)(Y + height), 8, 8))) == null ||
                       !solid.BlockWaterfalls))
            {
                height += 8f;
                solid = null;
            }

            if (HasDeepWaterEntry) flag = true;

            Add(loopingSfx = ((IOriginalWaterfallSoundEnvironment)engine).SoundSources.Create());
            loopingSfx.Play("event:/env/local/waterfall_small_main");
            Add(enteringSfx = ((IOriginalWaterfallSoundEnvironment)engine).SoundSources.Create());
            enteringSfx.Play(flag
                ? "event:/env/local/waterfall_small_in_deep"
                : "event:/env/local/waterfall_small_in_shallow");
            enteringSfx.Position.Y = height;
            Add(new DisplacementRenderHookState(RenderDisplacement));
        }

        public override void Update()
        {
            var position = (Scene as Level).Camera.Position;
            loopingSfx.Position.Y = ScalarMath.Clamp(position.Y + 90f, Y, height,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (ShouldRipple && ((Level)Scene).OnInterval(0.3f)) water.TopSurface.DoRipple(new(X + 4f, water.Y), 0.75f);

            if (water != null || solid != null)
            {
                var position2 = new Vector2(X + 4f, Y + height + 2f);
                EmitSplash((Level)Scene, position2);
            }

            base.Update();
        }

        protected virtual void EmitSplash(Level level, Vector2 position)
        {
            level.ParticlesFG.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.Water.P_Splash,
                1, position, new(8f, 2f), (float)Math.Atan2(-1f, 0f));
        }

        public void RenderDisplacement()
        {
            var context = ((ISourceRenderEnvironment)engine).CurrentContext;
            SourcePrimitiveDrawing.Rect(context, this, X, Y, 8f, height, new(0.5f, 0.5f, 0.8f, 1f));
        }

        public override void Render(ISourceRenderContext context)
        {
            if (water == null || water.TopSurface == null)
            {
                SourcePrimitiveDrawing.Rect(context, this, X + 1f, Y, 6f, height,
                    FillColor);
                SourcePrimitiveDrawing.Rect(context, this, X - 1f, Y, 2f, height,
                    SurfaceColor);
                SourcePrimitiveDrawing.Rect(context, this, X + 7f, Y, 2f, height,
                    SurfaceColor);
                return;
            }

            var topSurface = water.TopSurface;
            var num = height + water.TopSurface.Position.Y - water.Y;
            for (var i = 0; i < 6; i++)
                SourcePrimitiveDrawing.Rect(context, this, X + i + 1f, Y, 1f,
                    num - topSurface.GetSurfaceHeight(new Vector2(X + 1f + i, water.Y)),
                    FillColor);

            SourcePrimitiveDrawing.Rect(context, this, X - 1f, Y, 2f,
                num - topSurface.GetSurfaceHeight(new Vector2(X, water.Y)),
                SurfaceColor);
            SourcePrimitiveDrawing.Rect(context, this, X + 7f, Y, 2f,
                num - topSurface.GetSurfaceHeight(new Vector2(X + 8f, water.Y)),
                SurfaceColor);
        }
    }
}
