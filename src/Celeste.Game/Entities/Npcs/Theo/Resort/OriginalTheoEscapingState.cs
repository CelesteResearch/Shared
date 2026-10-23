using Celeste.Core.Display;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Audio;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Physics.Collision.Shapes;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Game.Components.Talking;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.UI.Dialogue.Textboxes;

namespace Celeste.Game.Entities.Npcs.Theo.Resort
{
    public class OriginalTheoEscapingState : OriginalNpcState
    {
        private readonly ISourceEngineContext engine;

        public class Grate : SceneEntityState
        {
            private readonly ISourceEngineContext engine;
            public SpriteImage Sprite;

            private Vector2 speed;

            private bool falling;

            private float alpha = 1f;

            public Grate(ISourceEngineContext engine, Vector2 position)
                : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
            {
                this.engine = engine;
                OwnedComponents.Add(Sprite =
                    new SpriteImage(((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["scenery/grate"]));
                Sprite.JustifyOrigin(0.5f, 0f);
                Sprite.Rotation = (float)Math.PI / 2f;
            }

            public void Fall()
            {
                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/char/theo/resort_vent_tumble",
                    Position);
                falling = true;
                speed = new Vector2(-120f, -120f);
                base.Collider = new HitboxColliderGeometry(2f, 2f, -2f, -1f);
            }

            public override void Update()
            {
                if (falling)
                {
                    speed.X = ScalarMath.Approach(speed.X, 0f, engine.DeltaTime * 120f,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                    speed.Y += 400f * engine.DeltaTime;
                    Position += speed * engine.DeltaTime;
                    if (CollideCheck("Celeste.Solid", Position + new Vector2(0f, 2f)) && speed.Y > 0f)
                    {
                        speed.Y = (0f - speed.Y) * 0.25f;
                    }

                    alpha -= engine.DeltaTime;
                    Sprite.Rotation += engine.DeltaTime *
                                       ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(speed) * 0.05f;
                    Sprite.Color = PackedColor.White * alpha;
                    if (alpha <= 0f)
                    {
                        RemoveSelf();
                    }
                }

                base.Update();
            }
        }

        private bool talked;

        private VertexLightState light;

        public Grate grate;

        public OriginalTheoEscapingState(ISourceEngineContext engine, Vector2 position)
            : base(engine, position)
        {
            this.engine = engine;
            OwnedComponents.Add(Sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("theo"));
            Sprite.Play("idle");
            Sprite.Position.X = -4f;
            SetupTheoSpriteSounds();
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            OwnedComponents.Add(light =
                new VertexLightState(engine, base.Center - Position, PackedColor.White, 1f, 32, 64));
            while (!CollideCheck("Celeste.Solid", Position + new Vector2(1f, 0f)))
            {
                base.X++;
            }

            grate = new Grate(engine, Position + new Vector2(base.Width / 2f, -8f));
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(grate);
            Sprite.Play("goToVent");
        }

        public override void Update()
        {
            base.Update();
            RoomPlayerSession player = ((ISourceScene)Scene).SourceScene.Entities.FindFirst<RoomPlayerSession>();
            if (player != null && !talked && player.X > base.X - 100f)
            {
                Talk(player);
            }

            if (Sprite.CurrentAnimationID == "pullVent" && Sprite.CurrentAnimationFrame > 0)
            {
                grate.Sprite.Position.X = 0f;
            }
            else
            {
                grate.Sprite.Position.X = 1f;
            }
        }

        private void Talk(RoomPlayerSession player)
        {
            talked = true;
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(
                new OriginalTheoEscapeCutsceneState(engine, this, player));
        }

        public void CrawlUntilOut()
        {
            Sprite.Scale.X = 1f;
            Sprite.Play("crawl");
            OwnedComponents.Add(new SimulationCoroutine(engine, CrawlUntilOutRoutine()));
        }

        private IEnumerator CrawlUntilOutRoutine()
        {
            Tags |= ((ISourceGlobalFrozenExecutionTagsEnvironment)engine).GlobalFrozenExecutionTags.Global.Value;
            int target = ((OriginalLevelSceneRoot)Scene).Bounds.Right + 280;
            while (base.X != (float)target)
            {
                base.X = ScalarMath.Approach(base.X, target, 20f * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }

            RemoveSelf();
        }
    }
}
