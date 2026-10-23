using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Geometry;
using Celeste.Scene.Entities;
using Celeste.Physics.Collision.Shapes;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Game.Entities.Npcs.Oshiro;
using Celeste.Game.Stories.CelestialResort.Cutscenes;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Entities.Npcs.Oshiro
{
    public class OriginalResortRoofEndingState : SourceSolidEntityState
    {
        private readonly ISourceEngineContext engine;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceScalarArithmetic Scalar => ((ISourceScalarEnvironment)engine).ScalarArithmetic;
        private ISourceEasingArithmetic Ease => ((ISourceEasingEnvironment)engine).EasingArithmetic;

        private static OriginalGameGraphicsResources Graphics(ISourceEngineContext engine) =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;
        private AtlasEntry[] roofCenters;

        private static AtlasEntry[] ReadCenters(ISourceEngineContext engine) => new[]
        {
            Graphics(engine).GameAtlas["decals/3-resort/roofCenter"],
            Graphics(engine).GameAtlas["decals/3-resort/roofCenter_b"],
            Graphics(engine).GameAtlas["decals/3-resort/roofCenter_c"],
            Graphics(engine).GameAtlas["decals/3-resort/roofCenter_d"]
        };

        private List<SpriteImage> images = new List<SpriteImage>();

        private List<SimulationCoroutine> wobbleRoutines = new List<SimulationCoroutine>();

        public bool BeginFalling;

        public OriginalResortRoofEndingState(EntityData data, Vector2 offset, OriginalLevelSceneRoot level)
            : this(data, offset, level, ReadCenters(level.EngineContext))
        {
        }

        private OriginalResortRoofEndingState(EntityData data, Vector2 offset, OriginalLevelSceneRoot level,
            AtlasEntry[] centers)
            : this(data.Position + offset, data.Width, level, centers)
        {
        }

        private OriginalResortRoofEndingState(Vector2 position, int width, OriginalLevelSceneRoot level,
            AtlasEntry[] centers)
            : base(position, width, 2f, true, level.SolidWorldFactory.Create(position, true))
        {
            engine = level.EngineContext;
            roofCenters = centers;
            EnableAssistModeChecks = false;
            SpriteImage image = new SpriteImage(Graphics(engine).GameAtlas["decals/3-resort/roofEdge_d"]);
            image.CenterOrigin();
            image.X = 8f;
            image.Y = 4f;
            OwnedComponents.Add(image);
            int i;
            for (i = 0; (float)i < base.Width; i += 16)
            {
                SpriteImage image2 =
                    new SpriteImage(RandomSelection.Choose(((ISourceRandomEnvironment)engine).Random, roofCenters));
                image2.CenterOrigin();
                image2.X = i + 8;
                image2.Y = 4f;
                OwnedComponents.Add(image2);
                images.Add(image2);
            }

            SpriteImage image3 = new SpriteImage(Graphics(engine).GameAtlas["decals/3-resort/roofEdge"]);
            image3.CenterOrigin();
            image3.X = i + 8;
            image3.Y = 4f;
            OwnedComponents.Add(image3);
            images.Add(image3);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (!Level.Session.GetFlag("oshiroEnding"))
            {
                RoomPlayerSession entity =
                    Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
                if (entity != null)
                {
                    Level.Scheduler.QueueSourceEntity(new CS03OshiroEndingState(engine, this, entity));
                }
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            Position += base.Shake;
            base.Render(context);
            Position -= base.Shake;
        }

        public void Wobble(global::Celeste.Game.Gameplay.Enemies.AngryOshiro.OriginalAngryOshiroState ghost,
            bool fall = false)
        {
            foreach (SimulationCoroutine wobbleRoutine in wobbleRoutines)
            {
                wobbleRoutine.RemoveSelf();
            }

            wobbleRoutines.Clear();
            RoomPlayerSession entity =
                Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            foreach (SpriteImage image in images)
            {
                SimulationCoroutine coroutine = new SimulationCoroutine(engine,
                    WobbleImage(image, Math.Abs(base.X + image.X - ghost.X) * 0.001f, entity, fall));
                OwnedComponents.Add(coroutine);
                wobbleRoutines.Add(coroutine);
            }
        }

        private IEnumerator WobbleImage(SpriteImage img, float delay, RoomPlayerSession player, bool fall)
        {
            float orig = img.Y;
            yield return delay;
            for (int i = 0; i < 2; i++)
            {
                Level.Scheduler.QueueSourceEntity(engine.EntityPools
                    .Create<global::Celeste.Simulation.Gameplay.Actors.Debris.DebrisState>().Init(
                        Position + img.Position + new Vector2(-4 + i * 8,
                            SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 0, 8)), '9'));
            }

            if (!fall)
            {
                float p = 0f;
                float amount = 5f;
                while (true)
                {
                    p += engine.DeltaTime * 16f;
                    amount = ScalarMath.Approach(amount, 1f, engine.DeltaTime * 5f, Extrema);
                    float num = (float)Math.Sin(p) * amount;
                    img.Y = orig + num;
                    if (player != null && Math.Abs(base.X + img.X - player.X) < 16f)
                    {
                        player.Sprite.Y = num;
                    }

                    yield return null;
                }
            }

            if (fall)
            {
                while (!BeginFalling)
                {
                    int num2 = SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 0, 2);
                    img.Y = orig + (float)num2;
                    if (player != null && Math.Abs(base.X + img.X - player.X) < 16f)
                    {
                        player.Sprite.Y = num2;
                    }

                    yield return 0.01f;
                }

                img.Texture = Graphics(engine)
                    .GameAtlas[
                        "decals/3-resort/roofCenter_snapped_" +
                        RandomSelection.Choose(((ISourceRandomEnvironment)engine).Random, "a", "b", "c")];
                Collidable = false;
                float amount = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random);
                float p = -24f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 48f);
                float speedY = 0f - (80f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 80f));
                float up = Vector2Geometry.Angle(new Vector2(0f, -1f));
                float off = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random);
                for (float p2 = 0f; p2 < 4f; p2 += engine.DeltaTime)
                {
                    img.Position += new Vector2(p, speedY) * engine.DeltaTime;
                    img.Rotation += amount * Ease.CubeIn(p2);
                    p = ScalarMath.Approach(p, 0f, engine.DeltaTime * 200f, Extrema);
                    speedY += 600f * engine.DeltaTime;
                    if (Level.OnInterval(0.1f, off))
                    {
                        global::Celeste.Game.Presentation.Particles.OriginalDustBurstSource.Burst(engine,
                            Position + img.Position, up);
                    }

                    yield return null;
                }
            }

            player.Sprite.Y = 0f;
        }
    }
}
