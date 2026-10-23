using Celeste.Scene.Tracking;
using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Audio;
using Celeste.Graphics.Content;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Controls.Source;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Animation;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;

namespace Celeste.Game.Gameplay.Platforms.Clouds
{
    public class OriginalCloudState : SourceJumpThruEntityState
    {
        private readonly ISourceEngineContext engine;


        private Sprite sprite;

        private WigglerComponent wiggler;

        private ParticleTypePresentation particleType;

        private SoundSourceComponentState sfx;

        private bool waiting = true;

        private float speed;

        protected float startY;

        protected float respawnTimer;

        private bool returning;

        private bool fragile;

        protected float timer;

        private Vector2 scale;

        private bool canRumble;

        public OriginalCloudState(ISourceEngineContext engine, Vector2 position, bool fragile, ISourceSolidWorld world)
            : base(position, 32, false, world)
        {
            this.engine = engine;
            this.fragile = fragile;
            startY = base.Y;
            base.Collider.Position.X = -16f;
            timer = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random) * 4f;
            wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.3f, 4f);
            OwnedComponents.Add(wiggler);
            particleType = (fragile
                ? ((IOriginalGameplayProcess)engine).ParticleTypes.Cloud.P_FragileCloud
                : ((IOriginalGameplayProcess)engine).ParticleTypes.Cloud.P_Cloud);
            SurfaceSoundIndex = 4;
            OwnedComponents.Add(new LightOccludeState(0.2f));
            scale = Vector2.One;
            sfx = new SoundSourceComponentState(engine);
            OwnedComponents.Add(sfx);
        }

        public OriginalCloudState(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world)
            : this(engine, SourceVector2Math.Add(data.Position, offset),
                EntityAttributeReader.Bool(data.Values, "fragile"), world)
        {
        }

        protected virtual bool IsSmall(bool isSmall) => isSmall;

        public override void Added(object scene)
        {
            base.Added(scene);
            string text = (fragile ? "cloudFragile" : "cloud");
            if (IsSmall((byte)((IOriginalAreaKeyEnvironment)engine).AreaKeys
                    .GetSessionArea(((OriginalLevelSceneRoot)Scene).Session).Mode != 0))
            {
                base.Collider.Position.X += 2f;
                base.Collider.Width -= 6f;
                text += "Remix";
            }

            sprite = ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).SpriteBank
                .Create(text);
            OwnedComponents.Add(sprite);
            sprite.Origin = new Vector2(sprite.Width / 2f, 8f);
            sprite.OnFrameChange = delegate(string s)
            {
                if (s == "spawn" && sprite.CurrentAnimationFrame == 6)
                {
                    wiggler.Start();
                }
            };
        }

        public override void Update()
        {
            base.Update();
            BouncingCloudMotion.Update(new MotionState(this));
        }

        private readonly struct MotionState : IBouncingCloudState
        {
            private readonly OriginalCloudState owner;

            public MotionState(OriginalCloudState owner)
            {
                this.owner = owner;
            }

            public ISourceEngineContext Engine => owner.engine;
            public SourceJumpThruEntityState Platform => owner;
            public Sprite Sprite => owner.sprite;
            public SoundSourceComponentState Sound => owner.sfx;
            public ParticleTypePresentation ParticleType => owner.particleType;
            public bool Fragile => owner.fragile;
            public bool ShouldFade => owner.fragile && owner.Collidable && !owner.HasPlayerRider();
            public bool Pink => owner.fragile;
            public bool SquashWhileRising => owner.fragile;
            public ref Vector2 Scale => ref owner.scale;
            public ref float Timer => ref owner.timer;
            public ref float RespawnTimer => ref owner.respawnTimer;
            public ref float Speed => ref owner.speed;
            public ref float StartY => ref owner.startY;
            public ref bool Waiting => ref owner.waiting;
            public ref bool Returning => ref owner.returning;
            public ref bool CanRumble => ref owner.canRumble;

            public void BeginFade(bool respawn)
            {
                owner.Collidable = false;
                owner.sprite.Play("fade");
                if (respawn) owner.respawnTimer = 2.5f;
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            Vector2 vector = scale;
            vector = SourceVector2Math.Multiply(vector, 1f + 0.1f * wiggler.Value);
            sprite.Scale = vector;
            base.Render(context);
        }
    }
}
