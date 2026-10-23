using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Graphics.Animation;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.PostProcessing.Displacement;

namespace Celeste.Game.Gameplay.Collectibles.Strawberries.Points
{
    public sealed class OriginalStrawberryPointsState : SceneEntityState
    {
        private readonly Sprite sprite;
        private readonly bool ghostberry;
        private readonly bool moonberry;
        private readonly VertexLightState light;
        private readonly BloomPointState bloom;
        private int index;
        private DisplacementBurst burst;
        private readonly IOriginalStrawberryPointsProcess process;

        public OriginalStrawberryPointsState(Vector2 position, bool ghostberry,
            int index, bool moonberry, IOriginalStrawberryPointsProcess process)
            : base(
                ((ISourceEntitySourceDataEnvironment)process)
                .EntitySourceDataRegistration,
                position)
        {
            this.process = process ?? throw new ArgumentNullException(nameof(process));
            Position = position;
            sprite = process.GameGraphics.SpriteFactory.Create("strawberry");
            OwnedComponents.Add(sprite);
            light = new(process, Vector2.Zero, PackedColor.White, 1f,
                16, 24);
            OwnedComponents.Add(light);
            bloom = new(1f, 12f);
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
            Position = new(Position.X, Position.Y - 8f * process.DeltaTime);
            Position = new(ScalarMath.Clamp(Position.X, camera.Left + 8f, camera.Right - 8f), Position.Y);
            Position = new(Position.X, ScalarMath.Clamp(Position.Y, camera.Top + 8f, camera.Bottom - 8f));
            light.Alpha = ScalarMath.Approach(light.Alpha, 0f, process.DeltaTime * 4f,
                ((ISourceExtremaEnvironment)process).ExtremaArithmetic);
            bloom.Alpha = light.Alpha;
            var type = ghostberry
                ? process.ParticleTypes.Strawberry.P_GhostGlow
                : process.ParticleTypes.Strawberry.P_Glow;
            if (moonberry && !ghostberry) type = process.ParticleTypes.Strawberry.P_MoonGlow;
            if (level.SourceScene.Clock.OnInterval(.05f, process))
                sprite.Color = sprite.Color == type.Color2 ? type.Color : type.Color2;
            if (level.SourceScene.Clock.OnInterval(.06f, process) && sprite.CurrentAnimationFrame > 11)
                level.ParticlesForeground.Emit(type, 1, Position + Vector2.UnitY * -2f, new(8f, 4f));
        }
    }
}
