using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;

namespace Celeste.Game.Entities.Gondolas
{
    public class OriginalGondolaState : SourceSolidEntityState
    {
        private readonly ISourceEngineContext engine;
        public float Rotation;
        public float RotationSpeed;
        public SceneEntityState LeftCliffside;
        public SceneEntityState RightCliffside;
        private SceneEntityState back;
        private SpriteImage backImg;
        private Sprite front;
        public Sprite Lever;
        private SpriteImage top;
        private bool brokenLever;
        private bool inCliffside;
        public Vector2 Start { get; private set; }
        public Vector2 Destination { get; private set; }
        public Vector2 Halfway { get; private set; }

        public OriginalGondolaState(EntityData data, Vector2 offset, ISourceSolidWorldFactory worlds)
            : this(data.Position + offset, data, offset, worlds)
        {
        }

        private OriginalGondolaState(Vector2 position, EntityData data, Vector2 offset,
            ISourceSolidWorldFactory worlds)
            : base(position, 64f, 8f, true, worlds.Create(position, true))
        {
            engine = SourceWorld.EngineContext;
            EnableAssistModeChecks = false;
            var graphics = ((ISourceGameGraphicsEnvironment)engine).GameGraphics;
            OwnedComponents.Add(front = graphics.SpriteFactory.Create("gondola"));
            front.Play("idle");
            front.Origin = new Vector2(front.Width / 2f, 12f);
            front.Position.Y = -52f;
            OwnedComponents.Add(top = new SpriteImage(graphics.GameAtlas.Entries["objects/gondola/top"]));
            top.Origin = new Vector2(top.Width / 2f, 12f);
            top.Position.Y = -52f;
            OwnedComponents.Add(Lever = AtlasSpriteFactory.Create(engine, graphics.GameAtlas, "objects/gondola/lever"));
            Lever.Add("idle", "", 0f, default(int));
            Lever.Add("pulled", "", .5f, new Chooser<string>("idle", 1f), 1, 1);
            Lever.Origin = new Vector2(front.Width / 2f, 12f);
            Lever.Position.Y = -52f;
            Lever.Play("idle");
            (Collider as HitboxColliderGeometry).Position.X = (0f - Collider.Width) / 2f;
            Start = Position;
            Destination = offset + data.Nodes[0];
            Halfway = ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(Position + Destination, 2f);
            Depth = -10500;
            inCliffside = EntityAttributeReader.Bool(data.Values, "active", true);
            SurfaceSoundIndex = 28;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            var level = (OriginalLevelSceneRoot)scene;
            var registration = ((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration;
            level.Scheduler.QueueSourceEntity(back = new SceneEntityState(registration, Position));
            back.Depth = 9000;
            var graphics = ((ISourceGameGraphicsEnvironment)engine).GameGraphics;
            backImg = new SpriteImage(graphics.GameAtlas.Entries["objects/gondola/back"]);
            backImg.Origin = new Vector2(backImg.Width / 2f, 12f);
            backImg.Position.Y = -52f;
            back.OwnedComponents.Add(backImg);
            level.Scheduler.QueueSourceEntity(LeftCliffside =
                new SceneEntityState(registration, Position + new Vector2(-124f, 0f)));
            SpriteImage image = new SpriteImage(graphics.GameAtlas.Entries["objects/gondola/cliffsideLeft"]);
            image.JustifyOrigin(0f, 1f);
            LeftCliffside.OwnedComponents.Add(image);
            LeftCliffside.Depth = 8998;
            level.Scheduler.QueueSourceEntity(RightCliffside =
                new SceneEntityState(registration, Destination + new Vector2(144f, -104f)));
            SpriteImage image2 = new SpriteImage(graphics.GameAtlas.Entries["objects/gondola/cliffsideRight"]);
            image2.JustifyOrigin(0f, .5f);
            image2.Scale.X = -1f;
            RightCliffside.OwnedComponents.Add(image2);
            RightCliffside.Depth = 8998;
            level.Scheduler.QueueSourceEntity(new OriginalGondolaRopeState(engine) { Gondola = this });
            if (!inCliffside)
            {
                Position = Destination;
                Lever.Visible = false;
                UpdatePositions();
                Vector2 position = Position + new Vector2((0f - Width) / 2f, -36f);
                var jumpThru = new SourceJumpThruEntityState(position, (int)Width, true,
                    ((ISourcePlatformCollisionScene)level).SolidWorldFactory.CreateJumpThru(position, true));
                jumpThru.SurfaceSoundIndex = 28;
                level.Scheduler.QueueSourceEntity(jumpThru);
            }

            top.Rotation = Vector2Geometry.Angle(Start, Destination);
        }

        public override void Update()
        {
            if (inCliffside)
            {
                float num = Math.Sign(Rotation) == Math.Sign(RotationSpeed) ? 8f : 6f;
                if (Math.Abs(Rotation) < .5f) num *= .5f;
                if (Math.Abs(Rotation) < .25f) num *= .5f;
                RotationSpeed += (float)(-Math.Sign(Rotation)) * num * engine.DeltaTime;
                Rotation += RotationSpeed * engine.DeltaTime;
                Rotation = ScalarMath.Clamp(Rotation, -.4f, .4f,
                    ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                if (Math.Abs(Rotation) < .02f && Math.Abs(RotationSpeed) < .2f)
                    Rotation = RotationSpeed = 0f;
            }

            UpdatePositions();
            base.Update();
        }

        private void UpdatePositions()
        {
            back.Position = Position;
            backImg.Rotation = Rotation;
            front.Rotation = Rotation;
            if (!brokenLever) Lever.Rotation = Rotation;
            top.Rotation = Vector2Geometry.Angle(Start, Destination);
        }

        public Vector2 GetRotatedFloorPositionAt(float x, float y = 52f)
        {
            Vector2 vector = Vector2Geometry.AngleToVector(Rotation + (float)Math.PI / 2f, 1f);
            Vector2 vector2 = new(0f - vector.Y, vector.X);
            return Position + new Vector2(0f, -52f) + vector * y - vector2 * x;
        }

        public void BreakLever() => OwnedComponents.Add(new SimulationCoroutine(engine, BreakLeverRoutine()));

        private IEnumerator BreakLeverRoutine()
        {
            brokenLever = true;
            Vector2 speed = new(240f, -130f);
            while (true)
            {
                Lever.Position += speed * engine.DeltaTime;
                Lever.Rotation += 2f * engine.DeltaTime;
                speed.Y += 400f * engine.DeltaTime;
                yield return null;
            }
        }

        public void PullSides() => front.Play("pull");
        public void CancelPullSides() => front.Play("idle");
    }
}
