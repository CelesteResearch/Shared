using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Game.Components.Talking;
using Celeste.Game.Execution.Processes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Game.Execution.Levels;
using Celeste.Physics.Collision.Shapes;

namespace Celeste.Game.Entities.Npcs
{
    public class OriginalNpcState : SceneEntityState
    {
        public const string MetTheo = "MetTheo";
        public const string TheoKnowsName = "TheoKnowsName";
        public const float TheoMaxSpeed = 48f;
        protected readonly ISourceEngineContext Engine;
        protected IOriginalGameplayProcess Process => (IOriginalGameplayProcess)Engine;
        private readonly List<object> temporaryCollisions = new List<object>();
        public global::Celeste.Graphics.Animation.Sprite Sprite;
        public OriginalTalkComponent Talker;
        public VertexLightState Light;
        public SoundSourceComponentState PhoneTapSfx;
        public OriginalLevelSceneRoot Level;
        public global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession Session => Level.Session;
        public float Maxspeed = 80;
        public string MoveAnim = "", IdleAnim = "";
        public bool MoveY = true, UpdateLight = true;
        public float DeltaTime => Engine.DeltaTime;

        public OriginalNpcState(ISourceEngineContext engine, Vector2 position)
            : base(
                ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration, position)
        {
            Engine = engine ?? throw new ArgumentNullException(nameof(engine));
            Depth = 1000;
            Collider = new HitboxColliderGeometry(8f, 8f, -4f, -8f);
            OwnedComponents.Add(new MirrorReflectionState());
        }

        public SimulationCoroutine AddCoroutine(IEnumerator enumerator)
        {
            var routine = new SimulationCoroutine(Engine, enumerator);
            OwnedComponents.Add(routine);
            return routine;
        }

        public void PlayAttachedSound(string name)
        {
            var sound = ((ISourceSoundSourceEnvironment)Engine).SoundSources.Create();
            sound.Play(name);
            OwnedComponents.Add(sound);
        }

        protected void PlaySourceSound(string name, Vector2 position,
            string parameter = null, float value = 0f) =>
            Process.AudioSession.Play(name, position, Process.SaveContext, parameter, value);

        public override void Added(object scene)
        {
            base.Added(scene);
            Level = scene as OriginalLevelSceneRoot;
        }

        public override void Update()
        {
            base.Update();
            if (UpdateLight && Light != null)
            {
                var bounds = Level.Bounds;
                bool inside = X > (float)(bounds.Left - 16) && Y > (float)(bounds.Top - 16) &&
                              X < (float)(bounds.Right + 16) && Y < (float)(bounds.Bottom + 16);
                Light.Alpha = global::Celeste.Core.Mathematics.ScalarMath.Approach(Light.Alpha,
                    inside && !Level.Transitioning ? 1 : 0, Engine.DeltaTime * 2f,
                    ((ISourceExtremaEnvironment)Engine).ExtremaArithmetic);
            }

            if (Sprite != null && Sprite.CurrentAnimationID == "usePhone")
            {
                if (PhoneTapSfx == null)
                    OwnedComponents.Add(PhoneTapSfx = ((ISourceSoundSourceEnvironment)Engine).SoundSources.Create());
                if (!PhoneTapSfx.Playing) PhoneTapSfx.Play("event:/char/theo/phone_taps_loop");
            }
            else if (PhoneTapSfx != null && PhoneTapSfx.Playing) PhoneTapSfx.Stop();
        }

        public void SetupTheoSpriteSounds()
        {
            Sprite.OnFrameChange = anim =>
            {
                int frame = Sprite.CurrentAnimationFrame;
                if ((anim == "walk" && (frame == 0 || frame == 6)) ||
                    (anim == "run" && (frame == 0 || frame == 4))) Footstep();
                else if (anim == "crawl" && frame == 0)
                {
                    if (!Level.Transitioning) PlaySourceSound("event:/char/theo/resort_crawl", Position);
                }
                else if (anim == "pullVent" && frame == 0)
                    PlaySourceSound("event:/char/theo/resort_vent_tug", Position);
            };
        }

        public void SetupGrannySpriteSounds()
        {
            Sprite.OnFrameChange = anim =>
            {
                int frame = Sprite.CurrentAnimationFrame;
                if (anim == "walk" && (frame == 0 || frame == 4)) Footstep();
                else if (anim == "walk" && frame == 2) PlaySourceSound("event:/char/granny/cane_tap", Position);
            };
        }

        public bool CollideSolidAt(Vector2 at)
        {
            var targets = Level.Scheduler.Entities.GetTrackedEntities("Celeste.Solid");
            Vector2 previous = Position;
            Position = at;
            bool collided = false;
            foreach (var target in targets)
            {
                if (global::Celeste.Physics.Collision.SourceEntityCollision.Check(this,
                        (global::Celeste.Physics.Collision.ISourceEntityCollider)target))
                {
                    collided = true;
                    break;
                }
            }

            Position = previous;
            return collided;
        }

        private void Footstep()
        {
            int? index = OriginalNpcFootstepPolicy.GetStepSoundIndex(Level, this, temporaryCollisions);
            if (index.HasValue) PlaySourceSound("event:/char/madeline/footstep", Center, "surface_index", index.Value);
        }

        public IEnumerator PlayerApproachRightSide(RoomPlayerSession player, bool turnToFace = true,
            float? spacing = null)
        {
            yield return PlayerApproach(player, turnToFace, spacing, 1);
        }

        public IEnumerator PlayerApproachLeftSide(RoomPlayerSession player, bool turnToFace = true,
            float? spacing = null)
        {
            yield return PlayerApproach(player, turnToFace, spacing, -1);
        }

        public IEnumerator PlayerApproach(RoomPlayerSession player, bool turnToFace = true, float? spacing = null,
            int? side = null)
        {
            if (!side.HasValue) side = Math.Sign(player.Position.X - Position.X);
            if (side == 0) side = 1;
            player.Machine.State = 11;
            player.Machine.Locked = true;
            if (spacing.HasValue) yield return player.DummyWalkToExact((int)(Position.X + side.Value * spacing.Value));
            else if (Math.Abs(Position.X - player.Position.X) < 12 ||
                     Math.Sign(player.Position.X - Position.X) != side.Value)
                yield return player.DummyWalkToExact((int)(Position.X + side.Value * 12));
            player.Data.Facing = -side.Value;
            if (turnToFace && Sprite != null) Sprite.Scale.X = side.Value;
            yield return null;
        }

        public IEnumerator PlayerApproach48px()
        {
            var player =
                Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            yield return PlayerApproach(player, true, 48f);
        }

        public IEnumerator PlayerLeave(RoomPlayerSession player, float? to = null)
        {
            if (to.HasValue) yield return player.DummyWalkToExact((int)to.Value);
            player.Machine.Locked = false;
            player.Machine.State = 0;
            yield return null;
        }

        public IEnumerator MoveTo(Vector2 target, bool fadeIn = false, int? turnAtEndTo = null,
            bool removeAtEnd = false)
        {
            if (removeAtEnd)
                Tags |= ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)Engine).Tags
                    .TransitionUpdate.Value;
            if (Math.Sign(target.X - Position.X) != 0 && Sprite != null)
                Sprite.Scale.X = Math.Sign(target.X - Position.X);
            ((ISourceVectorEnvironment)Engine).VectorArithmetic.SafeNormalize(target - Position);
            float alpha = fadeIn ? 0 : 1;
            if (Sprite != null && Sprite.Has(MoveAnim)) Sprite.Play(MoveAnim);
            float speed = 0;
            while ((MoveY && Position != target) || (!MoveY && Position.X != target.X))
            {
                speed = global::Celeste.Core.Mathematics.ScalarMath.Approach(speed, Maxspeed, 160f * DeltaTime,
                    ((ISourceExtremaEnvironment)Engine).ExtremaArithmetic);
                if (MoveY)
                    Position = ((ISourceVectorEnvironment)Engine).VectorArithmetic.Approach(Position, target,
                        speed * DeltaTime);
                else
                    Position = new Vector2(
                        global::Celeste.Core.Mathematics.ScalarMath.Approach(Position.X, target.X, speed * DeltaTime,
                            ((ISourceExtremaEnvironment)Engine).ExtremaArithmetic), Position.Y);
                if (Sprite != null) Sprite.Color = global::Celeste.Core.Display.PackedColor.White * alpha;
                alpha = global::Celeste.Core.Mathematics.ScalarMath.Approach(alpha, 1, DeltaTime,
                    ((ISourceExtremaEnvironment)Engine).ExtremaArithmetic);
                yield return null;
            }

            if (Sprite != null && Sprite.Has(IdleAnim)) Sprite.Play(IdleAnim);
            while (alpha < 1)
            {
                if (Sprite != null) Sprite.Color = global::Celeste.Core.Display.PackedColor.White * alpha;
                alpha = global::Celeste.Core.Mathematics.ScalarMath.Approach(alpha, 1, DeltaTime,
                    ((ISourceExtremaEnvironment)Engine).ExtremaArithmetic);
                yield return null;
            }

            if (turnAtEndTo.HasValue && Sprite != null) Sprite.Scale.X = turnAtEndTo.Value;
            if (removeAtEnd) RemoveSelf();
            yield return null;
        }

        public void MoveToAndRemove(Vector2 target)
        {
            AddCoroutine(MoveTo(target, false, null, true));
        }
    }
}
