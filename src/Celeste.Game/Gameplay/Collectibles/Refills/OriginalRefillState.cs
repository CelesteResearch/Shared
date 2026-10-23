using System;
using System.Collections;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Graphics.Animation;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Gameplay.Collectibles.Refills
{
    public partial class OriginalRefillState : SceneEntityState
    {
        protected readonly IOriginalRefillProcess engine;

        private readonly Action respawnAction;

        protected Sprite sprite;

        protected Sprite flash;

        protected SpriteImage outline;

        protected WigglerComponent wiggler;

        protected BloomPointState bloom;

        private readonly VertexLightState light;

        private IOriginalRefillScene level;

        protected SineWaveState sine;

        private bool oneUse;

        public bool TwoDashes { get; }

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public bool OneUse => oneUse;
        protected ParticleTypePresentation p_shatter;

        protected ParticleTypePresentation p_regen;

        protected ParticleTypePresentation p_glow;

        protected float respawnTimer;

        public OriginalRefillState(Vector2 position, bool twoDashes, bool oneUse, IOriginalRefillProcess engine)
            : base(
                ((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration,
                position)
        {
            this.engine = engine;
            respawnAction = Respawn;
            Collider = new HitboxColliderGeometry(16f, 16f, -8f, -8f);
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            TwoDashes = twoDashes;
            this.oneUse = oneUse;
            string text;
            if (twoDashes)
            {
                text = "objects/refillTwo/";
                p_shatter = engine.RefillParticles.P_ShatterTwo;
                p_regen = engine.RefillParticles.P_RegenTwo;
                p_glow = engine.RefillParticles.P_GlowTwo;
            }
            else
            {
                text = "objects/refill/";
                p_shatter = engine.RefillParticles.P_Shatter;
                p_regen = engine.RefillParticles.P_Regen;
                p_glow = engine.RefillParticles.P_Glow;
            }

            OwnedComponents.Add(outline = new(engine.GameGraphics.GameAtlas[text + "outline"]));
            outline.CenterOrigin();
            outline.Visible = false;
            OwnedComponents.Add(sprite = new(engine, engine.GameGraphics.GameAtlas, text + "idle"));
            sprite.AddLoop("idle", "", 0.1f);
            sprite.Play("idle");
            sprite.CenterOrigin();
            OwnedComponents.Add(flash = new(engine, engine.GameGraphics.GameAtlas, text + "flash"));
            flash.Add("flash", "", 0.05f);
            flash.OnFinish = delegate { flash.Visible = false; };
            flash.CenterOrigin();
            OwnedComponents.Add(wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(1f, 4f,
                delegate(float v) { sprite.Scale = flash.Scale = Vector2.One * (1f + v * 0.2f); }));
            OwnedComponents.Add(new MirrorReflectionState());
            OwnedComponents.Add(bloom = new(0.8f, 16f));
            OwnedComponents.Add(light = new(engine, Vector2.Zero, PackedColor.White, 1f, 16, 48));
            OwnedComponents.Add(sine = new(engine, 0.6f));
            sine.Randomize();
            UpdateY();
            presentation = RefillPresentation.BindPresentation(this.engine, new PresentationPhases(this));
            Depth = -100;
        }

        public OriginalRefillState(EntityData data, Vector2 offset, IOriginalRefillProcess engine)
            : this(data.Position + offset,
                EntityAttributeReader.Bool(data.Values, "twoDash"),
                EntityAttributeReader.Bool(data.Values, "oneUse"), engine)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            level = Scene as IOriginalRefillScene;
        }

        public override void Update()
        {
            base.Update();
            presentation.Update();
        }

        private void Respawn()
        {
            RefillPresentation.Respawn(this, engine, level, sprite, outline, wiggler, p_regen,
                TwoDashes
                    ? "event:/new_content/game/10_farewell/pinkdiamond_return"
                    : "event:/game/general/diamond_return");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void UpdateY()
        {
            RefillPresentation.UpdateY(sprite, flash, bloom, sine);
        }

        public override void Render(ISourceRenderContext context)
        {
            RefillPresentation.RenderOutline(context, sprite);
            base.Render(context);
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (!player.UseRefill(TwoDashes))
                return;
            engine.SpatialAudio.Play(
                TwoDashes
                    ? "event:/new_content/game/10_farewell/pinkdiamond_touch"
                    : "event:/game/general/diamond_touch", Position);
            engine.RumbleSession.Rumble(1, 1);
            Collidable = false;
            OwnedComponents.Add(new SimulationCoroutine(engine, RefillRoutine(player)));
            respawnTimer = 2.5f;
        }

        protected IEnumerator RefillRoutine(RoomPlayerSession player)
        {
            RefillPresentation.BeginRoutine(engine);
            yield return null;
            level.Shake();
            RefillPresentation.HideForRoutine(this, sprite, flash, outline, OneUse);
            yield return 0.05f;
            RefillPresentation.FinishRoutine(this, engine, level, p_shatter, player);
            if (OneUse) RemoveSelf();
        }
    }
}
