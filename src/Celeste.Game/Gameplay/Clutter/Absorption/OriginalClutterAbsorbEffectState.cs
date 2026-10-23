using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Clutter.Cabinets;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Simulation.Gameplay.Clutter;

namespace Celeste.Game.Gameplay.Clutter.Absorption
{
    public class OriginalClutterAbsorbEffectState : SceneEntityState, IClutterAbsorbEffect
    {
        private readonly ISourceEngineContext engine;
        private OriginalLevelSceneRoot level;
        private readonly List<OriginalClutterCabinetState> cabinets = [];
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;

        public OriginalClutterAbsorbEffectState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Position = Vector2.Zero;
            Tags = ((ISourcePersistentTransitionExecutionTagsEnvironment)engine).PersistentTransitionExecutionTags
                .TransitionUpdate.Value;
            Depth = -10001;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            level = Scene as OriginalLevelSceneRoot;
            foreach (var entity in level.Scheduler.Entities.GetTrackedEntities("Celeste.ClutterCabinet"))
                cabinets.Add(entity as OriginalClutterCabinetState);
        }

        public void FlyClutter(Vector2 position, AtlasEntry texture, bool shake, float delay)
        {
            var image = new SpriteImage(texture);
            image.Position = position - Position;
            image.CenterOrigin();
            OwnedComponents.Add(image);
            var routine = new SimulationCoroutine(engine, FlyClutterRoutine(image, shake, delay));
            routine.RemoveOnComplete = true;
            OwnedComponents.Add(routine);
        }

        private IEnumerator FlyClutterRoutine(SpriteImage image, bool shake, float delay)
        {
            yield return delay;
            var cabinet = cabinets[Random.Next(cabinets.Count)];
            var destination = cabinet.Position + new Vector2(8f);
            var from = image.Position;
            var to = destination + new Vector2(Random.Next(16) - 8, Random.Next(4) - 2);
            var arithmetic = ((ISourceVectorEnvironment)engine).VectorArithmetic;
            var direction = arithmetic.SafeNormalize(to - from);
            var length = arithmetic.Length(to - from);
            var normal = new Vector2(0f - direction.Y, direction.X)
                         * (length / 4f + SourceRandomMath.NextFloat(Random, 40f))
                         * (SourceRandomMath.NextFloat(Random) < .5f ? -1 : 1);
            var curve = new SimpleCurve(from, to, arithmetic.Divide(to + from, 2f) + normal);
            if (shake)
                for (var time = .25f; time > 0f; time -= engine.DeltaTime)
                {
                    image.Position.X = from.X + Random.Next(3) - 1f;
                    image.Position.Y = from.Y + Random.Next(3) - 1f;
                    yield return null;
                }

            for (var time = 0f; time < 1f; time += engine.DeltaTime)
            {
                image.Position = ((ISourceCurveEnvironment)engine).CurveArithmetic.GetPoint(curve,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(time));
                image.Scale = Vector2.One *
                              ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(1f - time * .5f);
                if (time > .5f && !cabinet.Opened) cabinet.Open();
                if (level.Clock.OnInterval(.25f, engine))
                    level.ParticlesFG.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.ClutterSwitch.P_ClutterFly,
                        image.Position);
                yield return null;
            }

            OwnedComponents.Remove(image);
        }

        public void CloseCabinets()
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, CloseCabinetsRoutine()));
        }

        private IEnumerator CloseCabinetsRoutine()
        {
            cabinets.Sort((a, b) => Math.Abs(a.Y - b.Y) < 24f
                ? Math.Sign(a.X - b.X)
                : Math.Sign(a.Y - b.Y));
            var i = 0;
            foreach (var cabinet in cabinets)
            {
                cabinet.Close();
                if (i++ % 3 == 0) yield return .1f;
            }
        }
    }
}
