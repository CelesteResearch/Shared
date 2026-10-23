using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Input.Gameplay;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Entities;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.ScreenEffects;

namespace Celeste.Simulation.Presentation.Player.Death
{
    public sealed class PlayerDeathPresentation : SceneEntityState
    {
        public const int DefaultDepth = -1000000;
        public Action DeathAction;
        public float ActionDelay;
        public bool HasGolden;
        public string DeathSoundOverride;
        public PlayerHair Hair;
        public PlayerSprite Sprite;
        public VertexLightState Light;
        public DeathEffect Effect { get; private set; }
        public bool Finished { get; private set; }
        public Vector2 Bounce => bounce;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public int Facing => facing;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public float Scale => scale;

        public float LightAlpha
        {
            get => Light.Alpha;
            set => Light.Alpha = value;
        }

        private readonly PackedColor initialHairColor;
        private readonly RoomPlayerSession player;
        private Vector2 bounce;

        private int facing;

        private float scale = 1f;

        public PlayerDeathPresentation(RoomPlayerSession player, Vector2 direction)
            : base(((ISourceEntitySourceDataEnvironment)player.EngineContext)
                .EntitySourceDataRegistration)
        {
            Depth = DefaultDepth;
            this.player = player;
            facing = player.Data.Facing;
            Position = player.Position;
            Components.Add(Hair = player.Hair);
            Components.Add(Sprite = player.Sprite);
            Components.Add(Light = player.Light);
            Sprite.Color = PackedColor.White;
            initialHairColor = Hair.Color;
            bounce = direction;
            Components.Add(new SimulationCoroutine(player.EngineContext, DeathRoutine()));
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (!(bounce != Vector2.Zero)) return;
            if (Math.Abs(bounce.X) > Math.Abs(bounce.Y))
            {
                Sprite.Play("deadside");
                facing = -Math.Sign(bounce.X);
                return;
            }

            bounce = Vector2Geometry.AngleToVector(ScalarMath.AngleApproach(
                Vector2Geometry.Angle(bounce),
                Vector2Geometry.Angle(new(-player.Data.Facing, 0f)), .5f), 1f);
            Sprite.Play(bounce.Y < 0f ? "deadup" : "deaddown");
        }

        private IEnumerator DeathRoutine()
        {
            var level = (IPlayerDeathLevel)Scene;
            var engine = level.EngineContext;
            if (bounce != Vector2.Zero)
            {
                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/char/madeline/predeath", Position);
                scale = 1.5f;
                ((ISourceFreezeEnvironment)engine).Freeze(.05f);
                yield return null;
                var from = Position;
                var to = from + bounce * 24f;
                var tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut, .5f, true);
                Components.Add(tween);
                tween.OnUpdate = t =>
                {
                    Position = from + (to - from) * t.Eased;
                    scale = 1.5f - t.Eased * .5f;
                    Sprite.Rotation = (float)(Math.Floor(t.Eased * 4f) * 6.2831854820251465);
                };
                yield return tween.Duration * .75f;
                tween.Stop();
            }

            Position += Vector2.UnitY * -5f;
            ((ISourcePlayerDeathDisplacementScene)level).AddPlayerDeathDisplacement(Position, .3f, 0f, 80f);
            ((ISourceLevelShakeScene)level).Shake();
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 2);
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                DeathSoundOverride ??
                (HasGolden ? "event:/new_content/char/madeline/death_golden" : "event:/char/madeline/death"), Position);
            Effect = new(initialHairColor, engine, Center - Position);
            Effect.OnUpdate = f => Light.Alpha = 1f - f;
            Components.Add(Effect);
            yield return Effect.Duration * .65f;
            if (ActionDelay > 0f) yield return ActionDelay;
            End();
        }

        private void End()
        {
            if (Finished) return;
            Finished = true;
            var level = (IPlayerDeathLevel)Scene;
            if (DeathAction == null) DeathAction = level.Reload;
            level.WipeOut(DeathAction);
        }

        public override void Update()
        {
            base.Update();
            if (player.Input[GameAction.MenuConfirm].Pressed && !Finished) End();
            Hair.Color = Sprite.CurrentAnimationFrame == 0 ? PackedColor.White : initialHairColor;
        }

        public override void Render(ISourceRenderContext context)
        {
            if (Effect == null)
            {
                Sprite.Scale.X = Facing * Scale;
                Sprite.Scale.Y = Scale;
                Hair.Facing = Facing;
                base.Render(context);
            }
            else
            {
                Effect.Render(context);
            }
        }
    }
}
