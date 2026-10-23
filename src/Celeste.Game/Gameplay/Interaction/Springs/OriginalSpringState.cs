using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Gameplay.Enemies.Seekers;
using Celeste.Graphics.Animation;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Hazards.Puffer;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Simulation.Gameplay.Interaction.Springs;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using JetBrains.Annotations;

namespace Celeste.Game.Gameplay.Interaction.Springs
{
    public class OriginalSpringState : SceneEntityState, ISourceSpringEntity
    {
        public SpringOrientation Orientation;

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private bool playerCanUse;

        public PackedColor DisabledColor = PackedColor.White;
        public bool VisibleWhenDisabled;

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private Sprite sprite;

        private readonly WigglerComponent wiggler;

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly IOriginalSpringProcess process;

        protected Sprite SpringSprite
        {
            get => sprite;
            set => sprite = value;
        }

        protected SourceStaticMoverState SpringStaticMover { get; set; }

        protected bool SpringPlayerCanUse => playerCanUse;
        protected IOriginalSpringProcess SpringProcess => process;

        public void AnimateSpringBounce()
        {
            BounceAnimate();
        }

        SpringOrientation ISourceSpringEntity.Orientation => Orientation;

        public OriginalSpringState(EntityData data, Vector2 offset, SpringOrientation orientation,
            IOriginalSpringProcess process) : this(data.Position + offset, orientation,
            EntityAttributeReader.Bool(data.Values, "playerCanUse", true), process)
        {
        }

        public OriginalSpringState(Vector2 position, SpringOrientation orientation, bool playerCanUse,
            IOriginalSpringProcess process)
            : base(
                ((ISourceEntitySourceDataEnvironment)process)
                .EntitySourceDataRegistration,
                position)
        {
            Orientation = orientation;
            this.playerCanUse = playerCanUse;
            this.process = process ?? throw new ArgumentNullException(nameof(process));
            OwnedComponents.Add(
                new PlayerColliderComponentState(
                    OnCollide));
            OwnedComponents.Add(new HoldableColliderState(OnHoldable));
            var pufferCollider = new PufferColliderState(OnPuffer);
            OwnedComponents.Add(pufferCollider);
            sprite = new(process, process.GameGraphics.GameAtlas, "objects/spring/");
            OwnedComponents.Add(sprite);
            sprite.Add("idle", "", 0f, 0);
            sprite.Add("bounce", "", .07f, new Chooser<string>("idle", 1f), 0, 1, 2, 2,
                2,
                2, 2, 2, 2, 2, 2, 3, 4, 5);
            sprite.Add("disabled", "white", .07f);
            sprite.Play("idle");
            sprite.Origin.X = sprite.Width / 2f;
            sprite.Origin.Y = sprite.Height;
            Depth = -8501;
            SpringStaticMover = new() { OnAttach = platform => Depth = platform.Depth + 1 };
            switch (orientation)
            {
                case SpringOrientation.Floor:
                    SpringStaticMover.SolidChecker = solid => CheckAt(solid, Position + Vector2.UnitY);
                    SpringStaticMover.JumpThruChecker = jumpThru => CheckAt(jumpThru, Position + Vector2.UnitY);
                    OwnedComponents.Add(SpringStaticMover);
                    break;
                case SpringOrientation.WallLeft:
                    SpringStaticMover.SolidChecker = solid => CheckAt(solid, Position - Vector2.UnitX);
                    SpringStaticMover.JumpThruChecker = jumpThru => CheckAt(jumpThru, Position - Vector2.UnitX);
                    OwnedComponents.Add(SpringStaticMover);
                    break;
                case SpringOrientation.WallRight:
                    SpringStaticMover.SolidChecker = solid => CheckAt(solid, Position + Vector2.UnitX);
                    SpringStaticMover.JumpThruChecker = jumpThru => CheckAt(jumpThru, Position + Vector2.UnitX);
                    OwnedComponents.Add(SpringStaticMover);
                    break;
            }

            wiggler = process.WigglerPool.Create(1f, 4f, value => sprite.Scale.Y = 1f + value * .2f);
            OwnedComponents.Add(wiggler);
            switch (orientation)
            {
                case SpringOrientation.Floor:
                    Collider = new HitboxColliderGeometry(16f, 6f, -8f, -6f);
                    pufferCollider.Collider = new HitboxColliderGeometry(16f, 10f, -8f, -10f);
                    break;
                case SpringOrientation.WallLeft:
                    Collider = new HitboxColliderGeometry(6f, 16f, 0f, -8f);
                    pufferCollider.Collider = new HitboxColliderGeometry(12f, 16f, 0f, -8f);
                    sprite.Rotation = (float)Math.PI / 2f;
                    break;
                case SpringOrientation.WallRight:
                    Collider = new HitboxColliderGeometry(6f, 16f, -6f, -8f);
                    pufferCollider.Collider = new HitboxColliderGeometry(12f, 16f, -12f, -8f);
                    sprite.Rotation = -(float)Math.PI / 2f;
                    break;
                default:
                    throw new("Orientation not supported!");
            }

            SpringStaticMover.OnEnable = OnEnable;
            SpringStaticMover.OnDisable = OnDisable;
        }

        private bool CheckAt(ISourceEntityCollider other, Vector2 at)
        {
            return SourceEntityCollision.CheckAt(this, other, at);
        }

        private void OnEnable()
        {
            Visible = Collidable = true;
            sprite.Color = PackedColor.White;
            sprite.Play("idle");
        }

        private void OnDisable()
        {
            Collidable = false;
            if (VisibleWhenDisabled)
            {
                sprite.Play("disabled");
                sprite.Color = DisabledColor;
            }
            else
            {
                Visible = false;
            }
        }

        private void OnCollide(RoomPlayerSession player)
        {
            if (player.Machine.State == 9 || !playerCanUse) return;
            if (Orientation == SpringOrientation.Floor)
            {
                if (player.Data.Motion.Normal.Speed.Y >= 0f)
                {
                    BounceAnimate();
                    player.SuperBounce(Top);
                }

                return;
            }

            if (Orientation == SpringOrientation.WallLeft)
            {
                if (player.SideBounce(1, Right, CenterY)) BounceAnimate();
                return;
            }

            if (Orientation == SpringOrientation.WallRight)
            {
                if (player.SideBounce(-1, Left, CenterY)) BounceAnimate();
                return;
            }

            throw new("Orientation not supported!");
        }

        private void BounceAnimate()
        {
            process.AudioSession.Play("event:/game/general/spring", BottomCenter, process.SaveContext);
            SpringStaticMover.TriggerPlatform();
            sprite.Play("bounce", true);
            wiggler.Start();
        }

        private void OnHoldable(HoldableState holdable)
        {
            if (holdable.HitSpring(this)) BounceAnimate();
        }

        private void OnPuffer(ISourcePufferEntity puffer)
        {
            if (puffer.HitSpring(this)) BounceAnimate();
        }

        private void OnSeeker(OriginalSeekerState seeker)
        {
            if (seeker.Speed.Y >= -120f)
            {
                BounceAnimate();
                seeker.HitSpring();
            }
        }

        public override void Render(ISourceRenderContext renderContext)
        {
            if (Collidable) sprite.DrawOutline(renderContext);
            base.Render(renderContext);
        }
    }
}
