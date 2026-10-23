using System;
using System.Numerics;
using Celeste.Core.Randomness;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;

namespace Celeste.Game.Gameplay.Environment.Debris
{
    public class OriginalFloatingDebrisState : SceneEntityState
    {
        private readonly IOriginalFloatingDebrisProcess engine;

        private readonly Vector2 start;

        protected SpriteImage DebrisImage { get; set; }

        private readonly SineWaveState sine;

        private Vector2 pushOut;

        private float accelMult = 1f;

        public float RotationSpeed { get; set; }

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
            Collider = new HitboxColliderGeometry(12f, 12f, -6f, -6f);
            Depth = -5;
            var texture = sheet.GetSubtexture(engine.Random.Next(sheet.Width / width) * width, 0, width, height);
            DebrisImage = new(texture);
            DebrisImage.CenterOrigin();
            OwnedComponents.Add(DebrisImage);
            RotationSpeed = engine.Random.Choose(-2, -1, 0, 0, 0, 0, 0, 0, 0, 1, 2) * 40 *
                            ((float)Math.PI / 180f);
            OwnedComponents.Add(sine = new(engine, 0.4f));
            sine.Randomize();
            DebrisImage.Position.Y = sine.Value * 2f;
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
        }

        public OriginalFloatingDebrisState(EntityData data,
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

            DebrisImage.Rotation += RotationSpeed * engine.DeltaTime;
            DebrisImage.Position.Y = sine.Value * 2f;
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            var vector = engine.VectorArithmetic.SafeNormalize(Position - player.Center,
                engine.VectorArithmetic.Length(player.Data.Motion.Normal.Speed) * 0.2f);
            if (engine.VectorArithmetic.LengthSquared(vector) > engine.VectorArithmetic.LengthSquared(pushOut))
                pushOut = vector;

            accelMult = 1f;
        }

        public void OnExplode(Vector2 from)
        {
            pushOut = engine.VectorArithmetic.SafeNormalize(Position - from, 160f);
            accelMult = 4f;
        }
    }
}
