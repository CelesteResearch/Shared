using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation.Gameplay.Collision.Blockers;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Gameplay.Player.Collision.Components;

namespace Celeste.Simulation.Gameplay.Hazards.Spikes
{
    public class SpikesState : SceneEntityState
    {
        public SpikeDirection Direction;
        private readonly int size;
        private readonly string overrideType;
        private string spikeType;
        private Vector2 imageOffset;
        public PackedColor EnabledColor = PackedColor.White;
        public PackedColor DisabledColor = PackedColor.White;
        public bool VisibleWhenDisabled;
        private readonly PlayerColliderComponentState pc;
        private readonly Func<SourceSolidEntityState, bool> originalSolidChecker;

        public SpikesState(Vector2 position, int size, SpikeDirection direction, string type,
            ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            Position = position;
            Depth = -1;
            Direction = direction;
            this.size = size;
            overrideType = type;
            switch (direction)
            {
                case SpikeDirection.Up:
                    Collider = new HitboxColliderGeometry(size, 3f, 0f, -3f);
                    OwnedComponents.Add(new LedgeBlockerState());
                    break;
                case SpikeDirection.Down:
                    Collider = new HitboxColliderGeometry(size, 3f);
                    break;
                case SpikeDirection.Left:
                    Collider = new HitboxColliderGeometry(3f, size, -3f);
                    OwnedComponents.Add(new LedgeBlockerState());
                    break;
                case SpikeDirection.Right:
                    Collider = new HitboxColliderGeometry(3f, size);
                    OwnedComponents.Add(new LedgeBlockerState());
                    break;
            }

            pc = new(OnCollide);
            OwnedComponents.Add(pc);
            OwnedComponents.Add(new SourceStaticMoverState
            {
                OnShake = OnShake, SolidChecker = originalSolidChecker = IsRiding, JumpThruChecker = IsRiding,
                OnEnable = OnEnable, OnDisable = OnDisable,
            });
        }

        public override void Added(object actualScene)
        {
            base.Added(actualScene);
            var scene = (ISourceSpikeScene)actualScene;
            spikeType = ResolveSpikeType(scene.SpikeType);
            SpikeDecorationBuilder.Add(scene.EngineContext, this, size, Direction, spikeType, GetSpikeTexturePrefix,
                scene.SpikeRandom, OnImageAdded, AddTentacle);
        }

        protected virtual string ResolveSpikeType(string areaType)
        {
            return !string.IsNullOrEmpty(overrideType) && !overrideType.Equals("default") ? overrideType : areaType;
        }

        protected virtual string GetSpikeTexturePrefix(string type)
        {
            return "danger/spikes/" + type;
        }

        protected virtual void OnImageAdded(SpriteImage image)
        {
        }

        private void AddTentacle(float i)
        {
            var scene = (ISourceSpikeScene)Scene;
            SpikeDecorationBuilder.AddTentacle(scene.EngineContext, this, size, Direction, scene.SpikeRandom, i);
        }

        public void SetSpikeColor(PackedColor color)
        {
            foreach (object component in Components)
                if (component is SpriteImage image)
                    image.Color = color;
        }

        protected virtual void OnEnable()
        {
            Active = Visible = Collidable = true;
            SetSpikeColor(EnabledColor);
        }

        private void OnDisable()
        {
            Active = Collidable = false;
            if (VisibleWhenDisabled)
            {
                foreach (object component in Components)
                    if (component is SpriteImage image)
                        image.Color = DisabledColor;
                return;
            }

            Visible = false;
        }

        private void OnShake(Vector2 amount)
        {
            imageOffset += amount;
        }

        public override void Render(ISourceRenderContext context)
        {
            var position = Position;
            Position += imageOffset;
            base.Render(context);
            Position = position;
        }

        public void SetOrigins(Vector2 origin)
        {
            foreach (object component in Components)
                if (component is SpriteImage image)
                {
                    var vector = origin - Position;
                    image.Origin = image.Origin + vector - image.Position;
                    image.Position = vector;
                }
        }

        protected virtual void OnCollide(RoomPlayerSession player)
        {
            switch (Direction)
            {
                case SpikeDirection.Up:
                    if (player.Data.Motion.Normal.Speed.Y >= 0f && player.Bottom <= Bottom)
                        player.Die(new(0f, -1f));
                    break;
                case SpikeDirection.Down:
                    if (player.Data.Motion.Normal.Speed.Y <= 0f) player.Die(new(0f, 1f));
                    break;
                case SpikeDirection.Left:
                    if (player.Data.Motion.Normal.Speed.X >= 0f) player.Die(new(-1f, 0f));
                    break;
                case SpikeDirection.Right:
                    if (player.Data.Motion.Normal.Speed.X <= 0f) player.Die(new(1f, 0f));
                    break;
            }
        }

        private bool CheckAt(ISourceEntityCollider other, Vector2 at)
        {
            var previous = Position;
            Position = at;
            var result = SourceEntityCollision.Check(this, other);
            Position = previous;
            return result;
        }

        private bool IsRiding(SourceSolidEntityState solid)
        {
            Vector2 at;
            switch (Direction)
            {
                case SpikeDirection.Up: at = Position + Vector2.UnitY; break;
                case SpikeDirection.Down: at = Position - Vector2.UnitY; break;
                case SpikeDirection.Left: at = Position + Vector2.UnitX; break;
                case SpikeDirection.Right: at = Position - Vector2.UnitX; break;
                default: return false;
            }

            return !SourceEntityCollision.Check(this, solid) && CheckAt(solid, at);
        }

        protected virtual bool IsRiding(ISourceJumpThruEntity jumpThru)
        {
            if (Direction != SpikeDirection.Up) return false;
            return CheckAt(jumpThru, Position + Vector2.UnitY);
        }

        // This delegate points only back to this spike. No external callback cache owns it.
        public bool IsOriginalSolidChecker(Func<SourceSolidEntityState, bool> checker)
        {
            return checker != null && ReferenceEquals(checker, originalSolidChecker);
        }
    }
}
