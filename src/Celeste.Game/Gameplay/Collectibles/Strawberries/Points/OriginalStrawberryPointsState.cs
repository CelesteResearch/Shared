using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;
using Celeste.Graphics.Animation;

namespace Celeste.Game.Gameplay.Collectibles.Strawberries.Points
{
    public sealed class OriginalStrawberryPointsState : SceneEntityState
    {
        private Sprite sprite;
        private bool ghostberry;
        private bool moonberry;
        private VertexLightState light;
        private BloomPointState bloom;
        private int index;
        private DisplacementBurst burst;
        private readonly IOriginalStrawberryPointsProcess process;

        public OriginalStrawberryPointsState(Vector2 position, bool ghostberry,
            int index, bool moonberry, IOriginalStrawberryPointsProcess process)
            : base(
                ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)process)
                .EntitySourceDataRegistration,
                position)
        {
            this.process = process ?? throw new ArgumentNullException(nameof(process));
            Position = position;
            sprite = process.GameGraphics.SpriteFactory.Create("strawberry");
            OwnedComponents.Add(sprite);
            light = new VertexLightState(process, Vector2.Zero, global::Celeste.Core.Display.PackedColor.White, 1f,
                16, 24);
            OwnedComponents.Add(light);
            bloom = new BloomPointState(1f, 12f);
            OwnedComponents.Add(bloom);
            Depth = -2000100;
            Tags = OriginalSceneTags.Persistent | OriginalSceneTags.TransitionUpdate | OriginalSceneTags.FrozenUpdate;
            this.ghostberry = ghostberry;
            this.moonberry = moonberry;
            this.index = index;
        }

        public override void Added(object scene)
        {
            index = Math.Min(5, index);
            if (index >= 5) process.RegisterOneUpAchievement();
            sprite.Play(moonberry ? "fade_wow" : "fade" + index);
            sprite.OnFinish = _ => RemoveSelf();
            base.Added(scene);
            foreach (var entry in ((IOriginalStrawberryPointsScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.StrawberryPoints"))
            {
                var entity = (OriginalStrawberryPointsState)entry;
                if (entity != this && Vector2Math.DistanceSquared(entity.Position, Position) <= 256f)
                    entity.RemoveSelf();
            }

            burst = ((IOriginalStrawberryPointsScene)scene).AddStrawberryPointsBurst(Position, .3f, 16f, 24f, .3f);
        }

        public override void Update()
        {
            var level = (IOriginalStrawberryPointsScene)Scene;
            if (level.Frozen)
            {
                if (burst != null)
                {
                    burst.AlphaFrom = burst.AlphaTo = 0f;
                    burst.Percent = burst.Duration;
                }

                return;
            }

            base.Update();
            var camera = level.Camera;
            Position = new Vector2(Position.X, Position.Y - 8f * process.DeltaTime);
            Position = new Vector2(ScalarMath.Clamp(Position.X, camera.Left + 8f, camera.Right - 8f), Position.Y);
            Position = new Vector2(Position.X, ScalarMath.Clamp(Position.Y, camera.Top + 8f, camera.Bottom - 8f));
            light.Alpha = ScalarMath.Approach(light.Alpha, 0f, process.DeltaTime * 4f,
                ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)process).ExtremaArithmetic);
            bloom.Alpha = light.Alpha;
            var type = ghostberry
                ? process.ParticleTypes.Strawberry.P_GhostGlow
                : process.ParticleTypes.Strawberry.P_Glow;
            if (moonberry && !ghostberry) type = process.ParticleTypes.Strawberry.P_MoonGlow;
            if (level.SourceScene.Clock.OnInterval(.05f, process))
                sprite.Color = sprite.Color == type.Color2 ? type.Color : type.Color2;
            if (level.SourceScene.Clock.OnInterval(.06f, process) && sprite.CurrentAnimationFrame > 11)
                level.ParticlesForeground.Emit(type, 1, Position + Vector2.UnitY * -2f, new Vector2(8f, 4f));
        }
    }
}
