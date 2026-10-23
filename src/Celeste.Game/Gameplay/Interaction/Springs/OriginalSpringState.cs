using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Simulation.Gameplay.Hazards.Puffer;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Gameplay.Interaction.Springs;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Display;

namespace Celeste.Game.Gameplay.Interaction.Springs
{
    public class OriginalSpringState : SceneEntityState, ISourceSpringEntity
    {
        public SpringOrientation Orientation;
        private bool playerCanUse;
        public PackedColor DisabledColor = PackedColor.White;
        public bool VisibleWhenDisabled;
        private Sprite sprite;
        private WigglerComponent wiggler;
        private SourceStaticMoverState staticMover;
        private readonly IOriginalSpringProcess process;

        protected Sprite SpringSprite
        {
            get => sprite;
            set => sprite = value;
        }

        protected SourceStaticMoverState SpringStaticMover
        {
            get => staticMover;
            set => staticMover = value;
        }

        protected bool SpringPlayerCanUse => playerCanUse;
        protected IOriginalSpringProcess SpringProcess => process;
        public void AnimateSpringBounce() => BounceAnimate();
        SpringOrientation ISourceSpringEntity.Orientation => Orientation;

        public OriginalSpringState(EntityData data, Vector2 offset, SpringOrientation orientation,
            IOriginalSpringProcess process) : this(data.Position + offset, orientation,
            EntityAttributeReader.Bool(data.Values, "playerCanUse", true), process)
        {
        }

        public OriginalSpringState(Vector2 position, SpringOrientation orientation, bool playerCanUse,
            IOriginalSpringProcess process)
            : base(
                ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)process)
                .EntitySourceDataRegistration,
                position)
        {
            Orientation = orientation;
            this.playerCanUse = playerCanUse;
            this.process = process ?? throw new ArgumentNullException(nameof(process));
            OwnedComponents.Add(
                new global::Celeste.Simulation.Gameplay.Player.Collision.Components.PlayerColliderComponentState(
                    OnCollide));
            OwnedComponents.Add(new HoldableColliderState(OnHoldable));
            var pufferCollider = new PufferColliderState(OnPuffer);
            OwnedComponents.Add(pufferCollider);
            sprite = new Sprite(process, process.GameGraphics.GameAtlas, "objects/spring/");
            OwnedComponents.Add(sprite);
            sprite.Add("idle", "", 0f, 0);
            sprite.Add("bounce", "", .07f, new global::Celeste.Core.Randomness.Chooser<string>("idle", 1f), 0, 1, 2, 2,
                2,
                2, 2, 2, 2, 2, 2, 3, 4, 5);
            sprite.Add("disabled", "white", .07f);
            sprite.Play("idle");
            sprite.Origin.X = sprite.Width / 2f;
            sprite.Origin.Y = sprite.Height;
            Depth = -8501;
            staticMover = new SourceStaticMoverState { OnAttach = platform => Depth = platform.Depth + 1 };
            switch (orientation)
            {
                case SpringOrientation.Floor:
                    staticMover.SolidChecker = solid => CheckAt(solid, Position + Vector2.UnitY);
                    staticMover.JumpThruChecker = jumpThru => CheckAt(jumpThru, Position + Vector2.UnitY);
                    OwnedComponents.Add(staticMover);
                    break;
                case SpringOrientation.WallLeft:
                    staticMover.SolidChecker = solid => CheckAt(solid, Position - Vector2.UnitX);
                    staticMover.JumpThruChecker = jumpThru => CheckAt(jumpThru, Position - Vector2.UnitX);
                    OwnedComponents.Add(staticMover);
                    break;
                case SpringOrientation.WallRight:
                    staticMover.SolidChecker = solid => CheckAt(solid, Position + Vector2.UnitX);
                    staticMover.JumpThruChecker = jumpThru => CheckAt(jumpThru, Position + Vector2.UnitX);
                    OwnedComponents.Add(staticMover);
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
                    throw new Exception("Orientation not supported!");
            }

            staticMover.OnEnable = OnEnable;
            staticMover.OnDisable = OnDisable;
        }

        private bool CheckAt(ISourceEntityCollider other, Vector2 at)
            => SourceEntityCollision.CheckAt(this, other, at);

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
            else Visible = false;
        }

        private void OnCollide(global::Celeste.Simulation.RoomPlayerSession player)
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

            throw new Exception("Orientation not supported!");
        }

        private void BounceAnimate()
        {
            process.AudioSession.Play("event:/game/general/spring", BottomCenter, process.SaveContext);
            staticMover.TriggerPlatform();
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

        private void OnSeeker(global::Celeste.Game.Gameplay.Enemies.Seekers.OriginalSeekerState seeker)
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
