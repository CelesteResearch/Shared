using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Graphics.Rendering;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Gameplay.Player.Collision.Components;

namespace Celeste.Game.Entities.Hazards.Sliders
{
    public class OriginalSliderState : SceneEntityState
    {
        public enum Surfaces
        {
            Floor,
            Ceiling,
            LeftWall,
            RightWall,
        }

        private const float MaxSpeed = 80f;
        private const float Accel = 400f;
        private readonly ISourceEngineContext engine;
        private Vector2 dir;
        private Vector2 surface;
        private bool foundSurfaceAfterCorner;
        private bool gotOutOfWall;
        private float speed;
        private bool moving;

        public OriginalSliderState(ISourceEngineContext engine, Vector2 position, bool clockwise, Surfaces surface)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            Collider = new CircleColliderGeometry(((ISourceVectorEnvironment)engine).VectorArithmetic, 10f);
            OwnedComponents.Add(new SourceStaticMoverState());
            switch (surface)
            {
                default:
                    dir = Vector2.UnitX;
                    this.surface = Vector2.UnitY;
                    break;
                case Surfaces.Ceiling:
                    dir = -Vector2.UnitX;
                    this.surface = -Vector2.UnitY;
                    break;
                case Surfaces.LeftWall:
                    dir = -Vector2.UnitY;
                    this.surface = -Vector2.UnitX;
                    break;
                case Surfaces.RightWall:
                    dir = Vector2.UnitY;
                    this.surface = Vector2.UnitX;
                    break;
            }

            if (!clockwise) dir *= -1f;
            moving = true;
            foundSurfaceAfterCorner = gotOutOfWall = true;
            speed = 80f;
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
        }

        public OriginalSliderState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : this(engine, data.Position + offset, data.Bool("clockwise", true), data.Enum("surface", Surfaces.Floor))
        {
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            var num = 0;
            while (!SolidAt(Position))
            {
                Position += surface;
                if (num >= 100) throw new("Couldn't find surface");
            }
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            player.Die(((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(player.Center - Center,
                -Vector2.UnitY));
            moving = false;
        }

        public override void Update()
        {
            base.Update();
            if (!moving) return;
            speed = ScalarMath.Approach(speed, 80f, 400f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            Position += dir * speed * engine.DeltaTime;
            if (!OnSurfaceCheck())
            {
                if (!foundSurfaceAfterCorner) return;
                Position = Vector2Math.Round(Position);
                var num = 0;
                while (!OnSurfaceCheck())
                {
                    Position -= dir;
                    num++;
                    if (num >= 100) throw new("Couldn't get back onto corner!");
                }

                foundSurfaceAfterCorner = false;
                var vector = dir;
                dir = surface;
                surface = -vector;
                return;
            }

            foundSurfaceAfterCorner = true;
            if (InWallCheck())
            {
                if (!gotOutOfWall) return;
                Position = Vector2Math.Round(Position);
                var num2 = 0;
                while (InWallCheck())
                {
                    Position -= dir;
                    num2++;
                    if (num2 >= 100) throw new("Couldn't get out of wall!");
                }

                Position += dir - surface;
                gotOutOfWall = false;
                var vector2 = surface;
                surface = dir;
                dir = -vector2;
            }
            else
            {
                gotOutOfWall = true;
            }
        }

        private bool SolidAt(Vector2 point)
        {
            return SourceSceneCollision.CheckPoint(((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid", point);
        }

        private bool OnSurfaceCheck()
        {
            return SolidAt(Vector2Math.Round(Position) + surface);
        }

        private bool InWallCheck()
        {
            return SolidAt(Vector2Math.Round(Position) - surface);
        }

        public override void Render(ISourceRenderContext context)
        {
            SourcePrimitiveDrawing.Circle(context, this, Position, 12f, PackedColor.Red, 8,
                ((ISourceVectorEnvironment)engine).VectorArithmetic);
        }
    }
}
