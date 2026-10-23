using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Components.Talking;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Scene.Tracking;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Npcs.Theo.Resort
{
    public class OriginalTheoVentsState : OriginalNpcState
    {
        private readonly ISourceEngineContext engine;

        private class Grate : SceneEntityState
        {
            private readonly ISourceEngineContext engine;
            private readonly SpriteImage sprite;

            private float shake;

            private Vector2 speed;

            private bool falling;

            private float alpha = 1f;

            public Grate(ISourceEngineContext engine, Vector2 position)
                : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
            {
                this.engine = engine;
                OwnedComponents.Add(sprite =
                    new(((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["scenery/grate"]));
                sprite.JustifyOrigin(0.5f, 0f);
            }

            public void Shake()
            {
                if (!!falling)
                    return;
                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                    "event:/char/theo/resort_ceilingvent_shake",
                    Position);
                shake = 0.5f;
            }

            public void Fall()
            {
                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/char/theo/resort_ceilingvent_popoff",
                    Position);
                falling = true;
                speed = new(40f, 200f);
                Collider = new HitboxColliderGeometry(2f, 2f, -1f);
            }

            public override void Update()
            {
                if (shake > 0f)
                {
                    shake -= engine.DeltaTime;
                    if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.05f, engine))
                        sprite.Position.X = 1f - sprite.Position.X;
                }

                if (falling)
                {
                    speed.X = ScalarMath.Approach(speed.X, 0f, engine.DeltaTime * 80f,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                    speed.Y += 200f * engine.DeltaTime;
                    Position += speed * engine.DeltaTime;
                    if (CollideCheck("Celeste.Solid", Position + new Vector2(0f, 2f)) && speed.Y > 0f)
                        speed.Y = (0f - speed.Y) * 0.25f;

                    alpha -= engine.DeltaTime;
                    sprite.Rotation += engine.DeltaTime;
                    sprite.Color = PackedColor.White * alpha;
                    if (alpha <= 0f) RemoveSelf();
                }

                base.Update();
            }
        }

        private const string AppeardFlag = "theoVentsAppeared";

        private const string TalkedFlag = "theoVentsTalked";

        private const int SpriteAppearY = -8;

        private float particleDelay;

        private bool appeared;

        private Grate grate;

        public OriginalTheoVentsState(ISourceEngineContext engine, Vector2 position)
            : base(engine, position)
        {
            this.engine = engine;
            Tags = ((ISourcePersistentTransitionExecutionTagsEnvironment)engine).PersistentTransitionExecutionTags
                .TransitionUpdate.Value;
            OwnedComponents.Add(Sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("theo"));
            Sprite.Scale.Y = -1f;
            Sprite.Scale.X = -1f;
            Visible = false;
            Maxspeed = 48f;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (Session.GetFlag("theoVentsTalked"))
                RemoveSelf();
            else
                OwnedComponents.Add(new SimulationCoroutine(engine, Appear()));
        }

        public override void Update()
        {
            base.Update();
            if (appeared) return;

            particleDelay -= engine.DeltaTime;
            if (!(particleDelay <= 0f))
                return;
            Level.ParticlesFG.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.VentDust, 8, Position,
                new(6f, 0f));
            if (grate != null) grate.Shake();

            particleDelay = ((ISourceRandomEnvironment)engine).Random.Choose(1f, 2f, 3f);
        }

        private IEnumerator Appear()
        {
            if (!Session.GetFlag("theoVentsAppeared"))
            {
                grate = new(engine, Position);
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(grate);
                RoomPlayerSession entity;
                do
                {
                    yield return null;
                    entity =
                        ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                            typeof(RoomPlayerSession).FullName);
                } while (entity == null || !(entity.X > X - 32f));

                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/char/theo/resort_ceilingvent_hey",
                    Position);
                Level.ParticlesFG.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.VentDust, 24, Position,
                    new(6f, 0f));
                grate.Fall();
                var from = -24;
                for (var p = 0f; p < 1f; p += engine.DeltaTime * 2f)
                {
                    yield return null;
                    Visible = true;
                    Sprite.Position.Y = from +
                                        (-8 - from) *
                                        ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p);
                }

                Session.SetFlag("theoVentsAppeared");
            }

            appeared = true;
            Sprite.Position.Y = -8f;
            Visible = true;
            OwnedComponents.Add(Talker = new((IOriginalTalkProcess)engine,
                new(-16, 0, 32, 100), new(0f, -8f), OnTalk));
        }

        private void OnTalk(RoomPlayerSession player)
        {
            Level.StartCutscene(OnTalkEnd);
            OwnedComponents.Add(new SimulationCoroutine(engine, Talk(player)));
        }

        private IEnumerator Talk(RoomPlayerSession player)
        {
            yield return PlayerApproach(player, true, 10f, -1);
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("lookUp");
            yield return OriginalCutsceneEntityState.CameraTo(engine,
                new(Level.Bounds.Right - 320, Level.Bounds.Top), 0.5f);
            yield return Level.ZoomTo(new(240f, 70f), 2f, 0.5f);
            yield return TextboxState.Say("CH3_THEO_VENTS", engine);
            yield return Disappear();
            yield return 0.25f;
            yield return Level.ZoomBack(0.5f);
            Level.EndCutscene();
            OnTalkEnd(Level);
        }

        private void OnTalkEnd(OriginalLevelSceneRoot level)
        {
            var entity =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (entity != null)
            {
                entity.Dummy.AutoAnimate = true;
                entity.Machine.Locked = false;
                entity.Machine.State = 0;
            }

            Session.SetFlag("theoVentsTalked");
            RemoveSelf();
        }

        private IEnumerator Disappear()
        {
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/char/theo/resort_ceilingvent_seeya",
                Position);
            var to = -24;
            var from = Sprite.Position.Y;
            for (var p = 0f; p < 1f; p += engine.DeltaTime * 2f)
            {
                yield return null;
                Level.ParticlesFG.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.VentDust, 1, Position,
                    new(6f, 0f));
                Sprite.Position.Y =
                    from + (to - from) * ((ISourceEasingEnvironment)engine).EasingArithmetic.BackIn(p);
            }
        }
    }
}
