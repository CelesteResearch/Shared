using System;
using System.Numerics;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Components.Oscillation;
using Celeste.Core.Randomness;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Gameplay.Environment.Debris
{
    public class OriginalFloatingDebrisState : SceneEntityState
    {
        private readonly IOriginalFloatingDebrisProcess engine;

        private Vector2 start;

        private SpriteImage image;

        protected SpriteImage DebrisImage
        {
            get => image;
            set => image = value;
        }

        private SineWaveState sine;

        private float rotateSpeed;

        private Vector2 pushOut;

        private float accelMult = 1f;

        public float RotationSpeed
        {
            get => rotateSpeed;
            set => rotateSpeed = value;
        }

        public OriginalFloatingDebrisState(Vector2 position, IOriginalFloatingDebrisProcess engine)
            : this(position, engine, engine.GameGraphics.GameAtlas.Entries["scenery/debris"], 8, 8)
        {
        }

        public OriginalFloatingDebrisState(Vector2 position, IOriginalFloatingDebrisProcess engine,
            AtlasEntry sheet, int width, int height)
            : base(engine.EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            start = Position;
            base.Collider = new HitboxColliderGeometry(12f, 12f, -6f, -6f);
            base.Depth = -5;
            AtlasEntry texture = sheet.GetSubtexture(engine.Random.Next(sheet.Width / width) * width, 0, width, height);
            image = new SpriteImage(texture);
            image.CenterOrigin();
            OwnedComponents.Add(image);
            rotateSpeed = (float)(engine.Random.Choose<int>(-2, -1, 0, 0, 0, 0, 0, 0, 0, 1, 2) * 40) *
                          ((float)Math.PI / 180f);
            OwnedComponents.Add(sine = new SineWaveState(engine, 0.4f));
            sine.Randomize();
            image.Position.Y = sine.Value * 2f;
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
        }

        public OriginalFloatingDebrisState(global::Celeste.Formats.Map.Entities.Structure.EntityData data,
            Vector2 offset, IOriginalFloatingDebrisProcess engine) : this(data.Position + offset, engine)
        {
        }

        public override void Update()
        {
            base.Update();
            if (pushOut != Vector2.Zero)
            {
                Position += pushOut * engine.DeltaTime;
                pushOut = engine.VectorArithmetic.Approach(pushOut, Vector2.Zero, 64f * accelMult * engine.DeltaTime);
            }
            else
            {
                accelMult = 1f;
                Position = engine.VectorArithmetic.Approach(Position, start, 6f * engine.DeltaTime);
            }

            image.Rotation += rotateSpeed * engine.DeltaTime;
            image.Position.Y = sine.Value * 2f;
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            Vector2 vector = engine.VectorArithmetic.SafeNormalize(Position - player.Center,
                engine.VectorArithmetic.Length(player.Data.Motion.Normal.Speed) * 0.2f);
            if (engine.VectorArithmetic.LengthSquared(vector) > engine.VectorArithmetic.LengthSquared(pushOut))
            {
                pushOut = vector;
            }

            accelMult = 1f;
        }

        public void OnExplode(Vector2 from)
        {
            pushOut = engine.VectorArithmetic.SafeNormalize(Position - from, 160f);
            accelMult = 4f;
        }
    }
}
