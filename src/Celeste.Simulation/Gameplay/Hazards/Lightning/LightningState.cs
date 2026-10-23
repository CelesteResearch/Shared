using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Simulation.Gameplay.Hazards.Lightning
{
    public class LightningState : LightningHazardState
    {
        public const string Flag = "disable_lightning";
        public float Fade;
        public bool Disappearing;
        public SimulationCoroutine Movement { get; }

        public LightningState(Vector2 position, int width, int height, Vector2? node, float moveTime,
            ISourceEngineContext engine)
            : base(position, width, height, engine)
        {
            if (node.HasValue)
            {
                Movement = new(engine, MoveRoutine(position, node.Value, moveTime));
                OwnedComponents.Add(Movement);
            }

            ToggleOffset = (float)((ISourceRandomEnvironment)engine).Random.NextDouble();
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            var entities = ((ISourceScene)scene).SourceScene.Entities;
            ((LightningRendererState)entities.GetTrackedEntities("Celeste.LightningRenderer")[0]).Track(this);
        }

        public override void Removed(object scene)
        {
            base.Removed(scene);
            var entities = ((ISourceScene)scene).SourceScene.Entities;
            ((LightningRendererState)entities.GetTrackedEntities("Celeste.LightningRenderer")[0]).Untrack(this);
        }

        protected override void OnPlayer(RoomPlayerSession player)
        {
            if (!Disappearing && !((ISourceLightningScene)Scene).Invincible)
            {
                var direction = Math.Sign(player.Position.X - X);
                if (direction == 0) direction = -1;
                player.Die(Vector2.UnitX * direction);
            }
        }

        private IEnumerator MoveRoutine(Vector2 start, Vector2 end, float moveTime)
        {
            while (true)
            {
                yield return Move(start, end, moveTime);
                yield return Move(end, start, moveTime);
            }
        }

        private IEnumerator Move(Vector2 start, Vector2 end, float moveTime)
        {
            var at = 0f;
            while (true)
            {
                var engine = ((ISourceEngineContextScene)Scene).EngineContext;
                var ease = ((ISourceEasingEnvironment)engine).EasingArithmetic.SineInOut(at);
                Position = Vector2Interpolation.Lerp(start, end, ease,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                if (at >= 1f) break;
                yield return null;
                at = ScalarMath.Clamp(at + ((ISourceEngineContextScene)Scene).EngineContext.DeltaTime / moveTime, 0f,
                    1f);
            }
        }

        public void Shatter()
        {
            if (Scene == null) return;
            for (var i = 4; i < Width; i += 8)
            for (var j = 4; j < Height; j += 8)
                ((ISourceLightningScene)Scene).EmitLightningShatter(TopLeft + new Vector2(i, j), Vector2.One * 3f);
        }
    }
}
