using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Randomness;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Entities.Decoration.Resort
{
    public sealed class OriginalResortLanternState : SceneEntityState
    {
        private readonly IOriginalResortFixtureEnvironment engine;
        private readonly SpriteImage holder;

        private readonly Sprite lantern;

        private float collideTimer;

        private int mult;

        private readonly WigglerComponent wiggler;

        private readonly VertexLightState light;

        private readonly BloomPointState bloom;

        private float alphaTimer;

        private readonly SoundSourceComponentState sfx;

        public OriginalResortLanternState(Vector2 position, IOriginalResortFixtureEnvironment engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            Collider = new HitboxColliderGeometry(8f, 8f, -4f, -4f);
            Depth = 2000;
            Add(new PlayerColliderComponentState(OnPlayer));
            holder = new(
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/resortLantern/holder"]);
            holder.CenterOrigin();
            Add(holder);
            lantern = new(engine, ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas,
                "objects/resortLantern/");
            lantern.AddLoop("light", "lantern", 0.3f, 0, 0, 1, 2, 1);
            lantern.Play("light");
            lantern.Origin = new(7f, 7f);
            lantern.Position = new(-1f, -5f);
            Add(lantern);
            wiggler = WigglerComponent.Create(((ISourceWigglerPoolScope)engine).WigglerPool, 2.5f, 1.2f,
                delegate(float v) { lantern.Rotation = v * mult * ((float)Math.PI / 180f) * 30f; });
            wiggler.StartZero = true;
            Add(wiggler);
            Add(light = new(engine, PackedColor.White, 0.95f, 32, 64));
            Add(bloom = new(0.8f, 8f));
            Add(sfx = engine.SoundSources.Create());
        }

        public OriginalResortLanternState(EntityData data, Vector2 offset,
            IOriginalResortFixtureEnvironment engine)
            : this(data.Position + offset, engine)
        {
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (!CollideCheck("Celeste.Solid", Position + Vector2.UnitX * 8f))
                return;
            holder.Scale.X = -1f;
            lantern.Scale.X = -1f;
            lantern.Position.X += 2f;
        }

        public override void Update()
        {
            base.Update();
            if (collideTimer > 0f) collideTimer -= engine.DeltaTime;

            alphaTimer += engine.DeltaTime;
            bloom.Alpha = light.Alpha = 0.95f + (float)Math.Sin(alphaTimer * 1f) * 0.05f;
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (collideTimer <= 0f)
            {
                if (player.Speed != Vector2.Zero)
                {
                    sfx.Play("event:/game/03_resort/lantern_bump");
                    collideTimer = 0.5f;
                    mult = ((ISourceRandomEnvironment)engine).Random.Next(2) == 0 ? 1 : -1;
                    wiggler.Start();
                }
            }
            else
            {
                collideTimer = 0.5f;
            }
        }
    }
}
