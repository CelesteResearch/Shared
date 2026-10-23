using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Entities.Decoration.Resort
{
    public sealed class OriginalTrapdoorState : SceneEntityState
    {
        private readonly Sprite sprite;
        private readonly IOriginalResortFixtureEnvironment engine;

        private PlayerColliderComponentState playerCollider;

        private readonly LightOccludeState occluder;

        public OriginalTrapdoorState(EntityData data, Vector2 offset, IOriginalResortFixtureEnvironment engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, Vector2.Zero)
        {
            this.engine = engine;
            Position = data.Position + offset;
            Depth = 8999;
            Add(sprite = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("trapdoor"));
            sprite.Play("idle");
            sprite.Position.Y = 6f;
            Collider = new HitboxColliderGeometry(24f, 4f, 0f, 6f);
            Add(playerCollider = new(Open));
            Add(occluder = new(new IntRect(0, 6, 24, 2)));
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
            yield return sprite.PlayRoutine("open_partial", true);
            sprite.Scale.Y = 1f;
            sprite.Rate = 1f;
            sprite.Play("open", true);
        }
    }
}
