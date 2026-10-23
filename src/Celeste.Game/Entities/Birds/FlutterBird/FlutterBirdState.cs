using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;

namespace Celeste.Game.Entities.Birds.FlutterBird
{
    public class FlutterBirdState : SceneEntityState
    {
        private static readonly PackedColor[] colors =
        [
            new(137, 251, 255),
            new(240, 252, 108),
            new(244, 147, 255),
            new(147, 186, 255),
        ];

        private readonly Vector2 start;

        private SimulationCoroutine routine;

        private bool flyingAway;

        private readonly SoundSourceComponentState tweetingSfx;

        private readonly SoundSourceComponentState flyawaySfx;

        private readonly ISourceEngineContext engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;
        private OriginalLevelSceneRoot ActualScene => Scene as OriginalLevelSceneRoot;

        protected Sprite BirdSprite { get; }

        protected virtual bool CanFlyAway => true;
        protected virtual string HopEvent => "event:/game/general/birdbaby_hop";
        protected virtual string FlyAwayEvent => "event:/game/general/birdbaby_flyaway";

        protected virtual void OnFlyAway()
        {
        }

        public FlutterBirdState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data, offset, engine, null, "event:/game/general/birdbaby_tweet_loop")
        {
        }

        protected FlutterBirdState(EntityData data, Vector2 offset, ISourceEngineContext engine,
            Func<ISourceEngineContext, EntityData, Sprite> spriteFactory, string tweetingEvent)
            : base(
                ((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration,
                data.Position + offset)
        {
            this.engine = engine;
            Depth = -9999;
            start = Position;
            OwnedComponents.Add(BirdSprite =
                spriteFactory == null
                    ? ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("flutterbird")
                    : spriteFactory(engine, data));
            BirdSprite.Color = colors[Random.Next(colors.Length)];
            OwnedComponents.Add(routine = new(engine, IdleRoutine()));
            OwnedComponents.Add(flyawaySfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            OwnedComponents.Add(tweetingSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            tweetingSfx.Play(tweetingEvent);
        }

        public override void Update()
        {
            BirdSprite.Scale.X = ScalarMath.Approach(BirdSprite.Scale.X, Math.Sign(BirdSprite.Scale.X),
                4f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            BirdSprite.Scale.Y = ScalarMath.Approach(BirdSprite.Scale.Y, 1f, 4f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            base.Update();
        }

        private IEnumerator IdleRoutine()
        {
            while (true)
            {
                var player =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>();

                var delay = 0.25f + SourceRandomMath.NextFloat(Random, 1f);
                for (var p = 0f; p < delay; p += engine.DeltaTime)
                {
                    if (player != null && Math.Abs(player.Position.X - Position.X) < 48f &&
                        player.Position.Y > Position.Y - 40f && player.Position.Y < Position.Y + 8f)
                        FlyAway(Math.Sign(Position.X - player.Position.X), SourceRandomMath.NextFloat(Random, 0.2f));

                    yield return null;
                }

                ((IOriginalGameplayProcess)engine).AudioSession.Play(HopEvent, Position,
                    ((IOriginalGameplayProcess)engine).SaveContext);
                var target = start + new Vector2(-4f + SourceRandomMath.NextFloat(Random, 8f), 0f);
                BirdSprite.Scale.X = Math.Sign(target.X - Position.X);
                var bezier = new SimpleCurve(Position, target, (Position + target) / 2f - Vector2.UnitY * 14f);
                for (var p = 0f; p < 1f; p += engine.DeltaTime * 4f)
                {
                    Position = bezier.GetPoint(p, ((ISourceCurveEnvironment)engine).CurveArithmetic);
                    yield return null;
                }

                BirdSprite.Scale.X = Math.Sign(BirdSprite.Scale.X) * 1.4f;
                BirdSprite.Scale.Y = 0.6f;
                Position = target;
            }
        }

        private IEnumerator FlyAwayRoutine(int direction, float delay)
        {
            var level = Scene as OriginalLevelSceneRoot;
            yield return delay;
            BirdSprite.Play("fly");
            BirdSprite.Scale.X = -direction * 1.25f;
            BirdSprite.Scale.Y = 1.25f;
            var random = Random;
            var dust = ((IOriginalGameplayProcess)engine).ParticleTypes.Dust;
            random.Next(1);
            level.ParticlesFG.Emit(dust, Position, -(float)Math.PI / 2f);
            var from = Position;
            var to = Position + new Vector2(direction * 4, -8f);
            for (var p = 0f; p < 1f; p += engine.DeltaTime * 3f)
            {
                Position = from + (to - from) * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p);
                yield return null;
            }

            Depth = -10001;
            BirdSprite.Scale.X = 0f - BirdSprite.Scale.X;
            to = new Vector2(direction, -4f) * 8f;
            while (Position.Y + 8f > level.Bounds.Top)
            {
                to += new Vector2(direction * 64, -128f) * engine.DeltaTime;
                Position += to * engine.DeltaTime;
                if (ActualScene.Clock.OnInterval(0.1f, engine) && Position.Y > level.Camera.Top + 32f)
                    foreach (var tracked in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                                 "Celeste.FlutterBird"))
                    {
                        var entity = tracked as FlutterBirdState;
                        if (Math.Abs(Position.X - entity.Position.X) < 48f &&
                            Math.Abs(Position.Y - entity.Position.Y) < 48f && !entity.flyingAway)
                            entity.FlyAway(direction, SourceRandomMath.NextFloat(Random, 0.25f));
                    }

                yield return null;
            }

            ((ISourceScene)Scene).SourceScene.RemoveEntity(this);
        }

        public void FlyAway(int direction, float delay)
        {
            if (!(CanFlyAway && !flyingAway))
                return;
            tweetingSfx.Stop();
            flyingAway = true;
            OnFlyAway();
            flyawaySfx.Play(FlyAwayEvent);
            OwnedComponents.Remove(routine);
            OwnedComponents.Add(routine = new(engine, FlyAwayRoutine(direction, delay)));
        }
    }
}
