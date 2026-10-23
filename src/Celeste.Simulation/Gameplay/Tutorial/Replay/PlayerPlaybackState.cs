using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Player.Presentation;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Animation.Replay;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Simulation.Gameplay.Tutorial.Replay
{
// The actual recorded entity. Map/tutorial composition supplies the same process resources.
    public class PlayerPlaybackState : SceneEntityState
    {
        protected readonly ISourceEngineContext engine;
        protected readonly IPlayerPlaybackAudio audio;
        protected readonly Vector2 start;
        protected float rangeMinX = float.MinValue;
        protected float rangeMaxX = float.MaxValue;
        protected float time;
        protected int index;
        protected float loopDelay;
        protected float startDelay;
        protected bool ShowTrail;

        protected Celeste.Core.Display.PackedColor? PlaybackColor;

        public Vector2 LastPosition;
        public List<CharacterReplayFrame> Timeline;
        public PlayerSprite Sprite;
        public PlayerHair Hair;
        public float TrimStart;
        public float TrimEnd;
        public readonly float Duration;
        public Vector2 DashDirection { get; private set; }
        public float Time => time;
        public int FrameIndex => index;
        public int FrameCount => Timeline.Count;

        public PlayerPlaybackState(ISourceEngineContext engine, Vector2 start, PlayerSpriteMode mode,
            List<CharacterReplayFrame> timeline, IPlayerPlaybackAudio audio)
            : this(engine, start, mode, timeline, audio, false, false)
        {
        }

        protected PlayerPlaybackState(ISourceEngineContext engine, Vector2 start, PlayerSpriteMode mode,
            List<CharacterReplayFrame> timeline, IPlayerPlaybackAudio audio, bool deferSpriteAttachment,
            bool allowMissingTimeline)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            this.audio = audio;
            if (allowMissingTimeline && timeline == null) return;
            this.start = start;
            Collider = new HitboxColliderGeometry(8f, 11f, -4f, -11f);
            Timeline = timeline;
            Position = start;
            time = 0f;
            index = 0;
            Duration = timeline[timeline.Count - 1].TimeStamp;
            TrimStart = 0f;
            TrimEnd = Duration;
            Sprite = new PlayerSprite(engine, mode);
            Hair = new PlayerHair(Sprite, engine);
            OwnedComponents.Add(Hair);
            if (!deferSpriteAttachment) OwnedComponents.Add(Sprite);
            Collider = new HitboxColliderGeometry(8f, 4f, -4f, -4f);
            if (mode == PlayerSpriteMode.Playback) ShowTrail = true;
            Depth = 9008;
            SetFrame(0);
            for (int i = 0; i < 10; i++) Hair.AfterUpdate();
            Visible = false;
            index = Timeline.Count;
        }

        public const string AppearSound = "event:/new_content/char/tutorial_ghost/appear";
        public const string DisappearSound = "event:/new_content/char/tutorial_ghost/disappear";
        public const string LandSound = "event:/new_content/char/tutorial_ghost/land";
        public const string FootstepSound = "event:/new_content/char/tutorial_ghost/footstep";
        public const string JumpSound = "event:/new_content/char/tutorial_ghost/jump";
        public const string JumpSuperSound = "event:/new_content/char/tutorial_ghost/jump_super";
        public const string DreamBlockSound = "event:/new_content/char/tutorial_ghost/dreamblock_sequence";
        public const string DashRedRightSound = "event:/new_content/char/tutorial_ghost/dash_red_right";
        public const string DashRedLeftSound = "event:/new_content/char/tutorial_ghost/dash_red_left";
        public const string GrabSound = "event:/new_content/char/tutorial_ghost/grab";

        public void SetFrame(int index)
        {
            // PlayerPlayback.cs:109-180.
            CharacterReplayFrame frame = Timeline[index];
            string previousAnimation = Sprite.CurrentAnimationID;
            bool wasColliding = Scene != null && CollideSolid(Position + new Vector2(0f, 1f));
            Position = start + frame.Position;
            if (frame.Animation != Sprite.CurrentAnimationID && frame.Animation != null && Sprite.Has(frame.Animation))
                Sprite.Play(frame.Animation, true);
            Sprite.Scale = frame.Scale;
            if (Sprite.Scale.X != 0f) Hair.Facing = Math.Sign(Sprite.Scale.X);
            Hair.Color = PlaybackColor ?? frame.HairColour;
            if (Sprite.Mode == global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode
                    .Playback)
                Sprite.Color = Hair.Color;
            DashDirection = frame.DashDirection;
            if (Scene == null) return;
            if (!wasColliding && Scene != null && CollideSolid(Position + new Vector2(0f, 1f)))
                audio.Play(LandSound, Position);
            if (previousAnimation == Sprite.CurrentAnimationID) return;
            string animation = Sprite.CurrentAnimationID;
            int animationFrame = Sprite.CurrentAnimationFrame;
            switch (animation)
            {
                case "jumpFast":
                case "jumpSlow": audio.Play(JumpSound, Position); break;
                case "dreamDashIn": audio.Play(DreamBlockSound, Position); break;
                case "dash":
                    if (DashDirection.Y != 0f) audio.Play(JumpSuperSound, Position);
                    else if (frame.Scale.X > 0f) audio.Play(DashRedRightSound, Position);
                    else audio.Play(DashRedLeftSound, Position);
                    break;
                case "climbUp":
                case "climbDown":
                case "wallslide": audio.Play(GrabSound, Position); break;
                default:
                    if ((animation.Equals("runSlow_carry") && (animationFrame == 0 || animationFrame == 6))
                        || (animation.Equals("runFast") && (animationFrame == 0 || animationFrame == 6))
                        || (animation.Equals("runSlow") && (animationFrame == 0 || animationFrame == 6))
                        || (animation.Equals("walk") && (animationFrame == 0 || animationFrame == 6))
                        || (animation.Equals("runStumble") && animationFrame == 6)
                        || (animation.Equals("flip") && animationFrame == 4)
                        || (animation.Equals("runWind") && (animationFrame == 0 || animationFrame == 6))
                        || (animation.Equals("idleC") && Sprite.Mode == global::Celeste.Simulation.Gameplay.Player
                                .Presentation.Sprites.PlayerSpriteMode.MadelineNoBackpack &&
                            (animationFrame == 3 || animationFrame == 6 || animationFrame == 8 || animationFrame == 11))
                        || (animation.Equals("carryTheoWalk") && (animationFrame == 0 || animationFrame == 6))
                        || (animation.Equals("push") && (animationFrame == 8 || animationFrame == 15)))
                        audio.Play(FootstepSound, Position);
                    break;
            }
        }

        private bool CollideSolid(Vector2 at) => SourceTrackedEntityCollision.CheckAt(
            ((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid", this, at);

        protected void Restart()
        {
            audio.Play(AppearSound, Position);
            Visible = true;
            time = TrimStart;
            index = 0;
            loopDelay = .25f;
            while (time > Timeline[index].TimeStamp) index++;
            SetFrame(index);
        }

        public override void Update()
        {
            if (startDelay > 0f) startDelay -= engine.DeltaTime;
            LastPosition = Position;
            base.Update();
            if (index >= Timeline.Count - 1 || Time >= TrimEnd)
            {
                if (Visible) audio.Play(DisappearSound, Position);
                Visible = false;
                Position = start;
                loopDelay -= engine.DeltaTime;
                if (loopDelay <= 0f)
                {
                    RoomPlayerSession player = null;
                    if (Scene != null)
                    {
                        var players =
                            ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                                typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                        if (players.Count != 0) player = (RoomPlayerSession)players[0];
                    }

                    if (player == null || (player.Position.X > rangeMinX && player.Position.X < rangeMaxX)) Restart();
                }
            }
            else if (startDelay <= 0f)
            {
                SetFrame(index);
                time += engine.DeltaTime;
                while (index < Timeline.Count - 1 && time >= Timeline[index + 1].TimeStamp) index++;
            }

            if (Visible && ShowTrail && Scene != null &&
                ((ISourceScene)Scene).SourceScene.Clock.OnInterval(.1f, engine))
                TrailManagerState.Add(engine, (ISourceRenderEnvironment)engine, Position,
                    Sprite, Hair, Sprite.Scale, Hair.Color, Depth + 1);
        }
    }
}
