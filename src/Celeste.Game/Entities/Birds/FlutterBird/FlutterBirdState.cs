using Celeste.Core.Display;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Entities.Birds.FlutterBird
{
    public class FlutterBirdState : SceneEntityState
    {
        private static readonly PackedColor[] colors = new PackedColor[4]
        {
            new PackedColor(137, 251, 255),
            new PackedColor(240, 252, 108),
            new PackedColor(244, 147, 255),
            new PackedColor(147, 186, 255)
        };

        private Sprite sprite;

        private Vector2 start;

        private SimulationCoroutine routine;

        private bool flyingAway;

        private SoundSourceComponentState tweetingSfx;

        private SoundSourceComponentState flyawaySfx;

        private readonly ISourceEngineContext engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;
        private OriginalLevelSceneRoot ActualScene => Scene as OriginalLevelSceneRoot;

        protected Sprite BirdSprite => sprite;
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
                ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration,
                data.Position + offset)
        {
            this.engine = engine;
            base.Depth = -9999;
            start = Position;
            OwnedComponents.Add(sprite =
                spriteFactory == null
                    ? ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("flutterbird")
                    : spriteFactory(engine, data));
            sprite.Color = colors[Random.Next(colors.Length)];
            OwnedComponents.Add(routine = new SimulationCoroutine(engine, IdleRoutine()));
            OwnedComponents.Add(flyawaySfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            OwnedComponents.Add(tweetingSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            tweetingSfx.Play(tweetingEvent);
        }

        public override void Update()
        {
            sprite.Scale.X = ScalarMath.Approach(sprite.Scale.X, Math.Sign(sprite.Scale.X), 4f * engine.DeltaTime,
                ((Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            sprite.Scale.Y = ScalarMath.Approach(sprite.Scale.Y, 1f, 4f * engine.DeltaTime,
                ((Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            base.Update();
        }

        private IEnumerator IdleRoutine()
        {
            while (true)
            {
                RoomPlayerSession player =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>();

                float delay = 0.25f + SourceRandomMath.NextFloat(Random, 1f);
                for (float p = 0f; p < delay; p += engine.DeltaTime)
                {
                    if (player != null && Math.Abs(player.Position.X - Position.X) < 48f &&
                        player.Position.Y > Position.Y - 40f && player.Position.Y < Position.Y + 8f)
                    {
                        FlyAway(Math.Sign(Position.X - player.Position.X), SourceRandomMath.NextFloat(Random, 0.2f));
                    }

                    yield return null;
                }

                ((IOriginalGameplayProcess)engine).AudioSession.Play(HopEvent, Position,
                    ((IOriginalGameplayProcess)engine).SaveContext);
                Vector2 target = start + new Vector2(-4f + SourceRandomMath.NextFloat(Random, 8f), 0f);
                sprite.Scale.X = Math.Sign(target.X - Position.X);
                SimpleCurve bezier = new SimpleCurve(Position, target, (Position + target) / 2f - Vector2.UnitY * 14f);
                for (float p = 0f; p < 1f; p += engine.DeltaTime * 4f)
                {
                    Position = bezier.GetPoint(p, ((ISourceCurveEnvironment)engine).CurveArithmetic);
                    yield return null;
                }

                sprite.Scale.X = (float)Math.Sign(sprite.Scale.X) * 1.4f;
                sprite.Scale.Y = 0.6f;
                Position = target;
            }
        }

        private IEnumerator FlyAwayRoutine(int direction, float delay)
        {
            OriginalLevelSceneRoot level = Scene as OriginalLevelSceneRoot;
            yield return delay;
            sprite.Play("fly");
            sprite.Scale.X = (float)(-direction) * 1.25f;
            sprite.Scale.Y = 1.25f;
            var random = Random;
            var dust = ((IOriginalGameplayProcess)engine).ParticleTypes.Dust;
            random.Next(1);
            level.ParticlesFG.Emit(dust, Position, -(float)Math.PI / 2f);
            Vector2 from = Position;
            Vector2 to = Position + new Vector2(direction * 4, -8f);
            for (float p = 0f; p < 1f; p += engine.DeltaTime * 3f)
            {
                Position = from + (to - from) * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p);
                yield return null;
            }

            base.Depth = -10001;
            sprite.Scale.X = 0f - sprite.Scale.X;
            to = new Vector2(direction, -4f) * 8f;
            while (Position.Y + 8f > (float)level.Bounds.Top)
            {
                to += new Vector2(direction * 64, -128f) * engine.DeltaTime;
                Position += to * engine.DeltaTime;
                if (ActualScene.Clock.OnInterval(0.1f, engine) && Position.Y > level.Camera.Top + 32f)
                {
                    foreach (var tracked in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                                 "Celeste.FlutterBird"))
                    {
                        var entity = tracked as FlutterBirdState;
                        if (Math.Abs(Position.X - entity.Position.X) < 48f &&
                            Math.Abs(Position.Y - entity.Position.Y) < 48f && !entity.flyingAway)
                        {
                            entity.FlyAway(direction, SourceRandomMath.NextFloat(Random, 0.25f));
                        }
                    }
                }

                yield return null;
            }

            ((ISourceScene)Scene).SourceScene.RemoveEntity(this);
        }

        public void FlyAway(int direction, float delay)
        {
            if (CanFlyAway && !flyingAway)
            {
                tweetingSfx.Stop();
                flyingAway = true;
                OnFlyAway();
                flyawaySfx.Play(FlyAwayEvent);
                OwnedComponents.Remove(routine);
                OwnedComponents.Add(routine = new SimulationCoroutine(engine, FlyAwayRoutine(direction, delay)));
            }
        }
    }
}
