using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Timing;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Doors.LockBlocks;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Interaction.Booster;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using JetBrains.Annotations;
using Color = Celeste.Core.Display.PackedColor;

namespace Celeste.Game.Entities.Interaction.Boosters
{
    public class OriginalBoosterState : SceneEntityState, ISourceBooster
    {
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        bool ISourceBooster.Ch9HubTransition => Ch9HubTransition;

        private void Play(string name, Vector2 position)
        {
            Process.AudioSession.Play(name, position, Process.SaveContext);
        }

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

        public static readonly Vector2 playerOffset = new(0f, -2f);

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private SceneEntityState outline;

        private readonly WigglerComponent wiggler;

        private VertexLightState light;

        private readonly SimulationCoroutine dashRoutine;

        private readonly DashListenerState dashListener;

        protected Sprite BoosterSprite { get; set; }

        protected BloomPointState BoosterBloom { get; }

        protected ParticleTypePresentation BoosterParticleType { get; set; }

        protected SceneEntityState BoosterOutline => outline;

        protected float BoosterRespawnTimer
        {
            get => respawnTimer;
            set => respawnTimer = value;
        }

        protected float BoosterCannotUseTimer => cannotUseTimer;

        private float respawnTimer;

        private float cannotUseTimer;

        private readonly bool red;

        private readonly SoundSourceComponentState loopingSfx;

        public bool Ch9HubBooster;

        public bool Ch9HubTransition;

        public bool BoostingPlayer { get; private set; }

        public OriginalBoosterState(ISourceEngineContext engine, Vector2 position, bool red)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            Depth = -8500;
            Collider =
                new CircleColliderGeometry(((ISourceVectorEnvironment)engine).VectorArithmetic, 10f, 0f, 2f);
            this.red = red;
            OwnedComponents.Add(BoosterSprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create(
                    red ? "boosterRed" : "booster"));
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OwnedComponents.Add(light = new(engine, Color.White, 1f, 16, 32));
            OwnedComponents.Add(BoosterBloom = new(0.1f, 16f));
            OwnedComponents.Add(wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.5f, 4f,
                delegate(float f) { BoosterSprite.Scale = Vector2.One * (1f + f * 0.25f); }));
            OwnedComponents.Add(dashRoutine = new(engine, false));
            OwnedComponents.Add(dashListener = new());
            OwnedComponents.Add(new MirrorReflectionState());
            OwnedComponents.Add(loopingSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            dashListener.OnDash = OnPlayerDashed;
            BoosterParticleType = red ? P_BurstRed : P_Burst;
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
            var image =
                new SpriteImage(
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.Entries["objects/booster/outline"]);
            image.CenterOrigin();
            image.Color = Color.White * 0.75f;
            outline = new(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
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
            BoosterSprite.Play("appear");
            wiggler.Start();
            Visible = true;
            AppearParticles();
        }

        private void AppearParticles()
        {
            var particlesBg = ((OriginalLevelSceneRoot)Scene).ParticlesBG;
            for (var i = 0; i < 360; i += 30)
                particlesBg.Emit(red ? P_RedAppear : P_Appear, 1, Center, Vector2.One * 2f,
                    i * ((float)Math.PI / 180f));
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (respawnTimer <= 0f && cannotUseTimer <= 0f && !BoostingPlayer)
            {
                cannotUseTimer = 0.45f;
                if (red)
                    player.RedBoost(this);
                else
                    player.Boost(this);

                Play(
                    red
                        ? "event:/game/05_mirror_temple/redbooster_enter"
                        : "event:/game/04_cliffside/greenbooster_enter",
                    Position);
                wiggler.Start();
                BoosterSprite.Play("inside");
                BoosterSprite.FlipX = player.Facing == -1;
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
                var flag = true;
                var list =
                    ((ISourceScene)Scene).SourceScene.Entities.FindAll<OriginalLockBlockState>();
                if (list.Count > 0)
                    foreach (var item in list)
                        if (!item.UnlockingRegistered)
                        {
                            flag = false;
                            break;
                        }

                if (flag)
                {
                    Ch9HubTransition = true;
                    OwnedComponents.Add(SourceAlarmState.Create(engine.AlarmPool, SourceAlarmState.AlarmMode.Oneshot,
                        delegate { OwnedComponents.Add(CreateHubSound()); }, 2f, true));
                }
            }

            BoostingPlayer = true;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.Persistent.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
            BoosterSprite.Play("spin");
            BoosterSprite.FlipX = player.Facing == -1;
            outline.Visible = true;
            wiggler.Start();
            dashRoutine.Replace(BoostRoutine(player, direction));
        }

        private IEnumerator BoostRoutine(RoomPlayerSession player, Vector2 dir)
        {
            var angle = Vector2Geometry.Angle(-dir);
            while ((player.Machine.State == 2 || player.Machine.State == 5) && BoostingPlayer)
            {
                BoosterSprite.RenderPosition = player.Center + playerOffset;
                loopingSfx.Position = BoosterSprite.Position;
                if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.02f, engine))
                    (Scene as OriginalLevelSceneRoot).ParticlesBG.Emit(BoosterParticleType, 2,
                        player.Center - dir * 3f + new Vector2(0f, -2f), new(3f, 3f), angle);

                yield return null;
            }

            PlayerReleased();
            if (player.Machine.State == 4) BoosterSprite.Visible = false;

            while (((OriginalLevelSceneRoot)Scene).Transitioning) yield return null;

            Tags = 0;
        }

        public void OnPlayerDashed(Vector2 direction)
        {
            if (BoostingPlayer) BoostingPlayer = false;
        }

        public void PlayerReleased()
        {
            Play(red ? "event:/game/05_mirror_temple/redbooster_end" : "event:/game/04_cliffside/greenbooster_end",
                BoosterSprite.RenderPosition);
            BoosterSprite.Play("pop");
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
                Tags = 0;
            }
        }

        public void Respawn()
        {
            Play(
                red
                    ? "event:/game/05_mirror_temple/redbooster_reappear"
                    : "event:/game/04_cliffside/greenbooster_reappear",
                Position);
            BoosterSprite.Position = Vector2.Zero;
            BoosterSprite.Play("loop", true);
            wiggler.Start();
            BoosterSprite.Visible = true;
            outline.Visible = false;
            AppearParticles();
        }

        public override void Update()
        {
            base.Update();
            if (BoosterBubbleMotion.AdvanceCooldowns(engine, ref cannotUseTimer, ref respawnTimer)) Respawn();

            if (!dashRoutine.Active && respawnTimer <= 0f)
            {
                var target = Vector2.Zero;
                var entity =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                if (entity != null && SourceEntityCollision.Check(this, entity))
                    target = entity.Center + playerOffset - Position;

                BoosterBubbleMotion.ApproachSprite(engine, BoosterSprite, target);
            }

            if (BoosterSprite.CurrentAnimationID == "inside" && !BoostingPlayer &&
                !CollideCheck(typeof(RoomPlayerSession).FullName))
                BoosterSprite.Play("loop");
        }

        public override void Render(ISourceRenderContext context)
        {
            var position = BoosterBubbleMotion.BeginRender(BoosterSprite, context);
            base.Render(context);
            BoosterBubbleMotion.EndRender(BoosterSprite, position);
        }

        public override void Removed(object scene)
        {
            if (Ch9HubTransition)
            {
                var level = scene as OriginalLevelSceneRoot;
                foreach (var item in level.Background.GetEach<BackdropPresentation>("bright"))
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
