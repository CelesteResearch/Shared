using Celeste.Core.Display;
using Celeste.Core.Components;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Components.Oscillation;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Entities.Decoration.Resort
{
    public sealed class OriginalResortLanternState : SceneEntityState
    {
        private readonly IOriginalResortFixtureEnvironment engine;
        private SpriteImage holder;

        private Sprite lantern;

        private float collideTimer;

        private int mult;

        private WigglerComponent wiggler;

        private VertexLightState light;

        private BloomPointState bloom;

        private float alphaTimer;

        private SoundSourceComponentState sfx;

        public OriginalResortLanternState(Vector2 position, IOriginalResortFixtureEnvironment engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            base.Collider = new HitboxColliderGeometry(8f, 8f, -4f, -4f);
            base.Depth = 2000;
            Add(new PlayerColliderComponentState(OnPlayer));
            holder = new SpriteImage(
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/resortLantern/holder"]);
            holder.CenterOrigin();
            Add(holder);
            lantern = new Sprite(engine, ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas,
                "objects/resortLantern/");
            lantern.AddLoop("light", "lantern", 0.3f, 0, 0, 1, 2, 1);
            lantern.Play("light");
            lantern.Origin = new Vector2(7f, 7f);
            lantern.Position = new Vector2(-1f, -5f);
            Add(lantern);
            wiggler = WigglerComponent.Create(((ISourceWigglerPoolScope)engine).WigglerPool, 2.5f, 1.2f,
                delegate(float v) { lantern.Rotation = v * (float)mult * ((float)Math.PI / 180f) * 30f; });
            wiggler.StartZero = true;
            Add(wiggler);
            Add(light = new VertexLightState(engine, PackedColor.White, 0.95f, 32, 64));
            Add(bloom = new BloomPointState(0.8f, 8f));
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
            if (CollideCheck("Celeste.Solid", Position + Vector2.UnitX * 8f))
            {
                holder.Scale.X = -1f;
                lantern.Scale.X = -1f;
                lantern.Position.X += 2f;
            }
        }

        public override void Update()
        {
            base.Update();
            if (collideTimer > 0f)
            {
                collideTimer -= engine.DeltaTime;
            }

            alphaTimer += engine.DeltaTime;
            bloom.Alpha = (light.Alpha = 0.95f + (float)Math.Sin(alphaTimer * 1f) * 0.05f);
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (collideTimer <= 0f)
            {
                if (player.Speed != Vector2.Zero)
                {
                    sfx.Play("event:/game/03_resort/lantern_bump");
                    collideTimer = 0.5f;
                    mult = (((ISourceRandomEnvironment)engine).Random.Next(2) == 0 ? 1 : -1);
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
