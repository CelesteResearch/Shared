using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Scene.Entities;
using Celeste.Physics.Collision.Shapes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Color = Celeste.Core.Display.PackedColor;

namespace Celeste.Game.Gameplay.Decoration.MoonCreatures
{
    public class OriginalMoonCreature : SceneEntityState
    {
        private readonly IOriginalMoonCreatureProcess engine;
        private static readonly MoonCreatureMotionSettings MotionSettings = MoonCreatureMotionSettings.Original;

        private struct TrailNode : IMoonCreatureTrailNode
        {
            public Vector2 Position;

            public Color Color;

            Vector2 IMoonCreatureTrailNode.TrailPosition
            {
                get => Position;
                set => Position = value;
            }

            Color IMoonCreatureTrailNode.TrailColor => Color;
        }

        private TrailNode[] trail;

        private Vector2 start;

        private Vector2 target;

        private float targetTimer;

        private Vector2 speed;

        private Vector2 bump;

        private RoomPlayerSession following;

        private Vector2 followingOffset;

        private float followingTime;

        private Color OrbColor;

        private Color CenterColor;

        private Sprite Sprite;

        private const float Acceleration = 90f;

        private const float FollowAcceleration = 120f;

        private const float MaxSpeed = 40f;

        private const float MaxFollowSpeed = 70f;

        private const float MaxFollowDistance = 200f;

        private readonly int spawn;

        private IntRect originLevelBounds;

        public OriginalMoonCreature(Vector2 position, IOriginalMoonCreatureProcess engine)
            : base(engine.EntitySourceDataRegistration)
        {
            this.engine = engine;
            base.Tags = engine.Tags.TransitionUpdate.Value;
            base.Depth = -13010;
            base.Collider = new HitboxColliderGeometry(20f, 20f, -10f, -10f);
            start = position;
            targetTimer = 0f;
            GetRandomTarget();
            Position = target;
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OrbColor = SourceHexColor.HexToColor("b0e6ff");
            CenterColor = engine.Random.Choose(SourceHexColor.HexToColor("c34fc7"), SourceHexColor.HexToColor("4f95c7"),
                SourceHexColor.HexToColor("53c74f"));
            Color value = SourceColorInterpolation.Lerp(CenterColor, SourceHexColor.HexToColor("bde4ee"), 0.5f,
                engine.ScalarArithmetic);
            Color value2 = SourceColorInterpolation.Lerp(CenterColor, SourceHexColor.HexToColor("2f2941"), 0.5f,
                engine.ScalarArithmetic);
            trail = new TrailNode[10];
            for (int i = 0; i < 10; i++)
            {
                trail[i] = new TrailNode
                {
                    Position = Position,
                    Color = SourceColorInterpolation.Lerp(value, value2, (float)i / 9f, engine.ScalarArithmetic)
                };
            }

            OwnedComponents.Add(Sprite = engine.GameGraphics.SpriteFactory.Create("moonCreatureTiny"));
        }

        public OriginalMoonCreature(EntityData data, Vector2 offset, IOriginalMoonCreatureProcess engine)
            : this(data.Position + offset, engine)
        {
            spawn = global::Celeste.Formats.Map.Entities.Attributes.EntityAttributeReader.Int(data.Values, "number",
                1) - 1;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            for (int i = 0; i < spawn; i++)
            {
                ((OriginalLevelSceneRoot)scene).SourceScene.QueueSourceEntity(new OriginalMoonCreature(
                    Position + new Vector2(SourceRandomMath.Range(engine.Random, -4, 4),
                        SourceRandomMath.Range(engine.Random, -4, 4)), engine));
            }

            originLevelBounds = (scene as OriginalLevelSceneRoot).Bounds;
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            MoonCreatureSimulation.OnPlayer(engine, Position, start, player, in MotionSettings, ref bump,
                ref following, ref followingTime, ref followingOffset);
        }

        private void GetFollowOffset()
        {
            MoonCreatureSimulation.GetFollowOffset(engine, ref followingOffset);
        }

        private void GetRandomTarget()
        {
            MoonCreatureSimulation.GetRandomTarget(engine, start, ref target, 32f, 8f);
        }

        public override void Update()
        {
            base.Update();
            MoonCreatureSimulation.Update(engine, this, start, ref target, ref targetTimer, ref speed, ref bump,
                ref following, ref followingTime, ref followingOffset, in MotionSettings);
            MoonCreatureSimulation.UpdateTrail(engine, this, trail, .05f, 2f, 128f);
            base.X = ScalarMath.Clamp(base.X, originLevelBounds.Left + 4, originLevelBounds.Right - 4);
            base.Y = ScalarMath.Clamp(base.Y, originLevelBounds.Top + 4, originLevelBounds.Bottom - 4);
        }

        public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            Vector2 position = Position;
            Position = Vector2Geometry.Floor(Position);
            MoonCreatureSimulation.RenderTrail(context, this, trail, 3f);
            base.Render(context);
            Position = position;
        }
    }
}
