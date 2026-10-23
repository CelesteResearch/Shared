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
    public sealed class OriginalTrapdoorState : SceneEntityState
    {
        private Sprite sprite;
        private readonly IOriginalResortFixtureEnvironment engine;

        private PlayerColliderComponentState playerCollider;

        private LightOccludeState occluder;

        public OriginalTrapdoorState(EntityData data, Vector2 offset, IOriginalResortFixtureEnvironment engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, Vector2.Zero)
        {
            this.engine = engine;
            Position = data.Position + offset;
            base.Depth = 8999;
            Add(sprite = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("trapdoor"));
            sprite.Play("idle");
            sprite.Position.Y = 6f;
            base.Collider = new HitboxColliderGeometry(24f, 4f, 0f, 6f);
            Add(playerCollider = new PlayerColliderComponentState(Open));
            Add(occluder = new LightOccludeState(new IntRect(0, 6, 24, 2)));
        }

        private void Open(RoomPlayerSession player)
        {
            Collidable = false;
            occluder.Visible = false;
            if (player.Speed.Y >= 0f)
            {
                engine.PlaySound("event:/game/03_resort/trapdoor_fromtop", Position);
                sprite.Play("open");
            }
            else
            {
                engine.PlaySound("event:/game/03_resort/trapdoor_frombottom", Position);
                Add(new SimulationCoroutine(engine, OpenFromBottom()));
            }
        }

        private IEnumerator OpenFromBottom()
        {
            sprite.Scale.Y = -1f;
            yield return sprite.PlayRoutine("open_partial");
            yield return 0.1f;
            sprite.Rate = -1f;
            yield return sprite.PlayRoutine("open_partial", restart: true);
            sprite.Scale.Y = 1f;
            sprite.Rate = 1f;
            sprite.Play("open", restart: true);
        }
    }
}
