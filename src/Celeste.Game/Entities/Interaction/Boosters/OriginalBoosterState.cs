using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Timing;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Scene.Components.Oscillation;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Interaction.Booster;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.Particles;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Entities.Doors.LockBlocks;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Color = Celeste.Core.Display.PackedColor;

namespace Celeste.Game.Entities.Interaction.Boosters
{
    public class OriginalBoosterState : SceneEntityState, ISourceBooster
    {
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        bool ISourceBooster.Ch9HubTransition => Ch9HubTransition;

        private void Play(string name, Vector2 position) =>
            Process.AudioSession.Play(name, position, Process.SaveContext);

        private SoundSourceComponentState CreateHubSound()
        {
            var sound = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create();
            sound.Play("event:/new_content/timeline_bubble_to_remembered");
            sound.DisposeOnTransition = false;
            return sound;
        }

        private const float RespawnTime = 1f;

        private ParticleTypePresentation P_Burst => Process.ParticleTypes.Booster.P_Burst;

        private ParticleTypePresentation P_BurstRed => Process.ParticleTypes.Booster.P_BurstRed;

        private ParticleTypePresentation P_Appear => Process.ParticleTypes.Booster.P_Appear;

        private ParticleTypePresentation P_RedAppear => Process.ParticleTypes.Booster.P_RedAppear;

        public static readonly Vector2 playerOffset = new Vector2(0f, -2f);

        private Sprite sprite;

        private SceneEntityState outline;

        private WigglerComponent wiggler;

        private BloomPointState bloom;

        private VertexLightState light;

        private SimulationCoroutine dashRoutine;

        private DashListenerState dashListener;

        private ParticleTypePresentation particleType;

        protected Sprite BoosterSprite
        {
            get => sprite;
            set => sprite = value;
        }

        protected BloomPointState BoosterBloom => bloom;

        protected ParticleTypePresentation BoosterParticleType
        {
            get => particleType;
            set => particleType = value;
        }

        protected SceneEntityState BoosterOutline => outline;

        protected float BoosterRespawnTimer
        {
            get => respawnTimer;
            set => respawnTimer = value;
        }

        protected float BoosterCannotUseTimer => cannotUseTimer;

        private float respawnTimer;

        private float cannotUseTimer;

        private bool red;

        private SoundSourceComponentState loopingSfx;

        public bool Ch9HubBooster;

        public bool Ch9HubTransition;

        public bool BoostingPlayer { get; private set; }

        public OriginalBoosterState(ISourceEngineContext engine, Vector2 position, bool red)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            base.Depth = -8500;
            base.Collider =
                new CircleColliderGeometry(((ISourceVectorEnvironment)engine).VectorArithmetic, 10f, 0f, 2f);
            this.red = red;
            OwnedComponents.Add(sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create(
                    red ? "boosterRed" : "booster"));
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OwnedComponents.Add(light = new VertexLightState(engine, Color.White, 1f, 16, 32));
            OwnedComponents.Add(bloom = new BloomPointState(0.1f, 16f));
            OwnedComponents.Add(wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.5f, 4f,
                delegate(float f) { sprite.Scale = Vector2.One * (1f + f * 0.25f); }));
            OwnedComponents.Add(dashRoutine = new SimulationCoroutine(engine, removeOnComplete: false));
            OwnedComponents.Add(dashListener = new DashListenerState());
            OwnedComponents.Add(new MirrorReflectionState());
            OwnedComponents.Add(loopingSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            dashListener.OnDash = OnPlayerDashed;
            particleType = (red ? P_BurstRed : P_Burst);
        }

        public static OriginalBoosterState CreateFromMapData(EntityData data, Vector2 offset,
            ISourceEngineContext engine)
        {
            var booster = new OriginalBoosterState(engine, data.Position + offset,
                EntityAttributeReader.Bool(data.Values, "red"));
            booster.Ch9HubBooster = EntityAttributeReader.Bool(data.Values, "ch9_hub_booster");
            return booster;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            SpriteImage image =
                new SpriteImage(
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.Entries["objects/booster/outline"]);
            image.CenterOrigin();
            image.Color = Color.White * 0.75f;
            outline = new SceneEntityState(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                Position);
            outline.Depth = 8999;
            outline.Visible = false;
            outline.OwnedComponents.Add(image);
            outline.OwnedComponents.Add(new MirrorReflectionState());
            ((ISourceScene)scene).SourceScene.QueueSourceEntity(outline);
        }

        public void Appear()
        {
            Play(
                red
                    ? "event:/game/05_mirror_temple/redbooster_reappear"
                    : "event:/game/04_cliffside/greenbooster_reappear",
                Position);
            sprite.Play("appear");
            wiggler.Start();
            Visible = true;
            AppearParticles();
        }

        private void AppearParticles()
        {
            ParticleSystemPresentation particlesBG = ((OriginalLevelSceneRoot)Scene).ParticlesBG;
            for (int i = 0; i < 360; i += 30)
            {
                particlesBG.Emit(red ? P_RedAppear : P_Appear, 1, base.Center, Vector2.One * 2f,
                    (float)i * ((float)Math.PI / 180f));
            }
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (respawnTimer <= 0f && cannotUseTimer <= 0f && !BoostingPlayer)
            {
                cannotUseTimer = 0.45f;
                if (red)
                {
                    player.RedBoost(this);
                }
                else
                {
                    player.Boost(this);
                }

                Play(
                    red
                        ? "event:/game/05_mirror_temple/redbooster_enter"
                        : "event:/game/04_cliffside/greenbooster_enter",
                    Position);
                wiggler.Start();
                sprite.Play("inside");
                sprite.FlipX = player.Facing == -1;
            }
        }

        public void PlayerBoosted(RoomPlayerSession player, Vector2 direction)
        {
            Play(red ? "event:/game/05_mirror_temple/redbooster_dash" : "event:/game/04_cliffside/greenbooster_dash",
                Position);
            if (red)
            {
                loopingSfx.Play("event:/game/05_mirror_temple/redbooster_move");
                loopingSfx.DisposeOnTransition = false;
            }

            if (Ch9HubBooster && direction.Y < 0f)
            {
                bool flag = true;
                List<OriginalLockBlockState> list =
                    ((ISourceScene)base.Scene).SourceScene.Entities.FindAll<OriginalLockBlockState>();
                if (list.Count > 0)
                {
                    foreach (OriginalLockBlockState item in list)
                    {
                        if (!item.UnlockingRegistered)
                        {
                            flag = false;
                            break;
                        }
                    }
                }

                if (flag)
                {
                    Ch9HubTransition = true;
                    OwnedComponents.Add(SourceAlarmState.Create(engine.AlarmPool, SourceAlarmState.AlarmMode.Oneshot,
                        delegate { OwnedComponents.Add(CreateHubSound()); }, 2f, start: true));
                }
            }

            BoostingPlayer = true;
            base.Tags = ((IOriginalGameTagsEnvironment)engine).Tags.Persistent.Value |
                        ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
            sprite.Play("spin");
            sprite.FlipX = player.Facing == -1;
            outline.Visible = true;
            wiggler.Start();
            dashRoutine.Replace(BoostRoutine(player, direction));
        }

        private IEnumerator BoostRoutine(RoomPlayerSession player, Vector2 dir)
        {
            float angle = Vector2Geometry.Angle(-dir);
            while ((player.Machine.State == 2 || player.Machine.State == 5) && BoostingPlayer)
            {
                sprite.RenderPosition = player.Center + playerOffset;
                loopingSfx.Position = sprite.Position;
                if (((ISourceScene)base.Scene).SourceScene.Clock.OnInterval(0.02f, engine))
                {
                    (base.Scene as OriginalLevelSceneRoot).ParticlesBG.Emit(particleType, 2,
                        player.Center - dir * 3f + new Vector2(0f, -2f), new Vector2(3f, 3f), angle);
                }

                yield return null;
            }

            PlayerReleased();
            if (player.Machine.State == 4)
            {
                sprite.Visible = false;
            }

            while (((OriginalLevelSceneRoot)Scene).Transitioning)
            {
                yield return null;
            }

            base.Tags = 0;
        }

        public void OnPlayerDashed(Vector2 direction)
        {
            if (BoostingPlayer)
            {
                BoostingPlayer = false;
            }
        }

        public void PlayerReleased()
        {
            Play(red ? "event:/game/05_mirror_temple/redbooster_end" : "event:/game/04_cliffside/greenbooster_end",
                sprite.RenderPosition);
            sprite.Play("pop");
            cannotUseTimer = 0f;
            respawnTimer = 1f;
            BoostingPlayer = false;
            wiggler.Stop();
            loopingSfx.Stop();
        }

        public void PlayerDied()
        {
            if (BoostingPlayer)
            {
                PlayerReleased();
                dashRoutine.Active = false;
                base.Tags = 0;
            }
        }

        public void Respawn()
        {
            Play(
                red
                    ? "event:/game/05_mirror_temple/redbooster_reappear"
                    : "event:/game/04_cliffside/greenbooster_reappear",
                Position);
            sprite.Position = Vector2.Zero;
            sprite.Play("loop", restart: true);
            wiggler.Start();
            sprite.Visible = true;
            outline.Visible = false;
            AppearParticles();
        }

        public override void Update()
        {
            base.Update();
            if (BoosterBubbleMotion.AdvanceCooldowns(engine, ref cannotUseTimer, ref respawnTimer))
            {
                Respawn();
            }

            if (!dashRoutine.Active && respawnTimer <= 0f)
            {
                Vector2 target = Vector2.Zero;
                RoomPlayerSession entity =
                    ((ISourceScene)base.Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (entity != null && SourceEntityCollision.Check(this, entity))
                {
                    target = entity.Center + playerOffset - Position;
                }

                BoosterBubbleMotion.ApproachSprite(engine, sprite, target);
            }

            if (sprite.CurrentAnimationID == "inside" && !BoostingPlayer &&
                !CollideCheck(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName))

            {
                sprite.Play("loop");
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            Vector2 position = BoosterBubbleMotion.BeginRender(sprite, context);
            base.Render(context);
            BoosterBubbleMotion.EndRender(sprite, position);
        }

        public override void Removed(object scene)
        {
            if (Ch9HubTransition)
            {
                OriginalLevelSceneRoot level = scene as OriginalLevelSceneRoot;
                foreach (BackdropPresentation item in level.Background.GetEach<BackdropPresentation>("bright"))
                {
                    item.ForceVisible = false;
                    item.FadeAlphaMultiplier = 1f;
                }

                level.Bloom.Base = level.AreaData.BloomBase + 0.25f;
                level.Session.BloomBaseAdd = 0.25f;
            }

            base.Removed(scene);
        }
    }
}
