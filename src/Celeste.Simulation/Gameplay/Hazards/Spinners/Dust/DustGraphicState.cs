using Celeste.Core.Display;
using Celeste.Graphics.Content.Atlas;
#nullable disable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Hazards.Spinners.Dust
{
    public class DustGraphicState : global::Celeste.Core.Components.SourceComponentState
    {
        public class Node
        {
            public global::Celeste.Graphics.Content.Atlas.AtlasEntry Base, Overlay;
            public float Rotation;
            public Vector2 Angle;
            public bool Enabled;
        }

        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;
        internal global::Celeste.Core.Scheduling.ISourceEngineContext EngineContext => engine;

        private global::Celeste.Graphics.Content.Atlas.AtlasData Atlas =>
            ((global::Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;

        public global::Celeste.Scene.Entities.SceneEntityState Parent =>
            (global::Celeste.Scene.Entities.SceneEntityState)Entity;

        private global::Celeste.Core.Randomness.ISourceRandom Random =>
            ((global::Celeste.Core.Randomness.ISourceRandomEnvironment)engine).Random;

        private SourceDustProcessState DustProcess => ((ISourceDustProcessEnvironment)engine).DustProcess;
        internal IDustStyleProvider StyleProvider => ((ISourceDustStyleEnvironment)engine).DustStyles;

        public readonly List<Node> Nodes = new List<Node>(),
            LeftNodes = new List<Node>(),
            RightNodes = new List<Node>(),
            TopNodes = new List<Node>(),
            BottomNodes = new List<Node>();

        public readonly global::Celeste.Graphics.Content.Atlas.AtlasEntry Center;
        public readonly float Offset;
        public readonly int EyeTextureIndex, RandomSeed;
        public readonly bool IgnoreSolids, AutoControlEyes, AutoExpandDust, EyesExist, EyesFollowPlayer;
        public Vector2 Position, EyeTargetDirection, EyeDirection;
        public int EyeFlip = 1;
        public float Scale = 1, Timer, ShakeTimer;
        public Vector2 ShakeValue, EyeLookRange;
        public bool Attached => Entity != null;
        public bool EyesMoveByRotation;
        public bool LeftEyeVisible = true, RightEyeVisible = true, Estableshed;
        public global::Celeste.Graphics.Content.Atlas.AtlasEntry EyeTexture;
        public global::Celeste.Simulation.Gameplay.Hazards.Spinners.Dust.DustEyeballsState Eyes;
        public global::Celeste.Core.Scheduling.SimulationCoroutine Blink;
        public Action OnEstablish;
        public global::Celeste.Simulation.Gameplay.Hazards.Spinners.Dust.DustEdgePresentation Edge { get; private set; }
        public Vector2 RenderPosition => Parent.Position + Position + ShakeValue;

        public bool InView
        {
            get
            {
                var camera = ((global::Celeste.Graphics.Geometry.TwoD.Camera.ISourceCameraScene)Scene).Camera;
                Vector2 position = Parent.Position;
                if (!(position.X + 16f < camera.Left) && !(position.Y + 16f < camera.Top) &&
                    !(position.X - 16f > camera.Right)) return !(position.Y - 16f > camera.Bottom);
                return false;
            }
        }

        public DustGraphicState(global::Celeste.Core.Scheduling.ISourceEngineContext engine, bool ignoreSolids,
            bool autoControlEyes = false, bool autoExpandDust = false) : base(true, true)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            IgnoreSolids = ignoreSolids;
            AutoControlEyes = autoControlEyes;
            AutoExpandDust = autoExpandDust;
            Center = Choose(Random, "center");
            Offset = global::Celeste.Core.Randomness.SourceRandomMath.NextFloat(Random) * 4f;
            Timer = global::Celeste.Core.Randomness.SourceRandomMath.NextFloat(Random);
            EyeTargetDirection = EyeDirection =
                Angle(global::Celeste.Core.Randomness.SourceRandomMath.NextFloat(Random) * ((float)Math.PI * 2));
            EyeTextureIndex = Random.Next(128);
            EyesExist = true;
            if (autoControlEyes)
            {
                EyesExist = global::Celeste.Core.Randomness.SourceRandomMath.NextFloat(Random) < .5f;
                EyesFollowPlayer = global::Celeste.Core.Randomness.SourceRandomMath.NextFloat(Random) < .3f;
            }

            RandomSeed = Random.Next();
        }

        public override void Added(object entity)
        {
            base.Added(entity);
            var owned = ((global::Celeste.Core.Components.ISourceOwnedComponentList)entity).OwnedComponents;
            owned.Add(new global::Celeste.Simulation.RoomTransitionListener
                { OnIn = percent => AddDustNodesIfInCamera() });
            Edge = new DustEdgePresentation(Render);
            owned.Add(Edge);
        }

        global::Celeste.Graphics.Content.Atlas.AtlasEntry Choose(
            global::Celeste.Core.Randomness.ISourceRandom random, string name)
        {
            var list = Atlas.Frames("danger/dustcreature/" + name);
            return list[random.Next(list.Count)];
        }

        public void TransitionIn(float percent) => AddDustNodesIfInCamera();

        public override void Update()
        {
            Timer += engine.DeltaTime * .6f;
            bool view = InView;
            if (ShakeTimer > 0)
            {
                ShakeTimer -= engine.DeltaTime;
                if (ShakeTimer <= 0) ShakeValue = Vector2.Zero;
                else if (((IDustGraphicScene)Scene).Clock.OnInterval(.05f, engine))
                {
                    ShakeValue = global::Celeste.Core.Randomness.RandomShakeVector.Next(Random);
                }
            }

            if (EyesExist)
            {
                if (EyeDirection != EyeTargetDirection && view)
                {
                    if (!EyesMoveByRotation)
                    {
                        EyeDirection = ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)engine)
                            .VectorArithmetic.Approach(EyeDirection, EyeTargetDirection, 12f * engine.DeltaTime);
                    }
                    else
                    {
                        float target = Atan(EyeTargetDirection),
                            a = AngleApproach(Atan(EyeDirection), target, 8f * engine.DeltaTime);
                        EyeDirection = a == target ? EyeTargetDirection : Angle(a);
                    }
                }

                if (EyesFollowPlayer && view)
                {
                    var player = ((global::Celeste.Scene.Tracking.ISourceScene)Parent.Scene).SourceScene.Entities
                        .GetTrackedEntity<global::Celeste.Simulation.RoomPlayerSession>(
                            typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
                    if (player != null)
                    {
                        var direction = Normalize(player.Position - Parent.Position);
                        EyeTargetDirection = EyesMoveByRotation
                            ? Angle(AngleApproach(Atan(EyeLookRange), Atan(direction), (float)Math.PI / 4f))
                            : direction;
                    }
                }

                Blink?.Update();
            }

            if (Nodes.Count <= 0 && Parent.Scene != null && !Estableshed)
            {
                AddDustNodesIfInCamera();
                return;
            }

            foreach (var node in Nodes) node.Rotation += engine.DeltaTime * .5f;
        }

        public void OnHitPlayer()
        {
            if (((ISourceDustProcessEnvironment)engine).Invincible) return;
            ShakeTimer = .6f;
            if (EyesExist)
            {
                Blink = null;
                LeftEyeVisible = RightEyeVisible = true;
                EyeTexture = Atlas.Entries["danger/dustcreature/deadEyes"];
            }
        }

        public void AddDustNodesIfInCamera()
        {
            if (Nodes.Count > 0 || !InView || DustProcess.DustGraphicEstabledCounter > 25 || Estableshed) return;
            var processRandom = ((global::Celeste.Core.Randomness.ISourceRandomProcessEnvironment)engine).RandomProcess;
            processRandom.PushRandom(RandomSeed);
            int x = (int)Parent.Position.X, y = (int)Parent.Position.Y;
            var direction = Normalize(Vector2.One);
            AddNode(new Vector2(0f - direction.X, 0f - direction.Y),
                IgnoreSolids || !CollideRect("Celeste.Solid",
                    new global::Celeste.Core.Geometry.IntRect(x - 8, y - 8, 8, 8)));
            AddNode(new Vector2(direction.X, 0f - direction.Y),
                IgnoreSolids || !CollideRect("Celeste.Solid",
                    new global::Celeste.Core.Geometry.IntRect(x, y - 8, 8, 8)));
            AddNode(new Vector2(0f - direction.X, direction.Y),
                IgnoreSolids || !CollideRect("Celeste.Solid",
                    new global::Celeste.Core.Geometry.IntRect(x - 8, y, 8, 8)));
            AddNode(direction,
                IgnoreSolids || !CollideRect("Celeste.Solid", new global::Celeste.Core.Geometry.IntRect(x, y, 8, 8)));
            if (Nodes[0].Enabled || Nodes[2].Enabled) Position.X -= 1;
            if (Nodes[1].Enabled || Nodes[3].Enabled) Position.X += 1;
            if (Nodes[0].Enabled || Nodes[1].Enabled) Position.Y -= 1;
            if (Nodes[2].Enabled || Nodes[3].Enabled) Position.Y += 1;
            int count = 0;
            foreach (var node in Nodes)
                if (node.Enabled)
                    count++;
            EyesMoveByRotation = count < 4;
            if (AutoControlEyes && EyesExist && EyesMoveByRotation)
            {
                EyeLookRange = Vector2.Zero;
                if (Nodes[0].Enabled) EyeLookRange += Normalize(new Vector2(-1f, -1f));
                if (Nodes[1].Enabled) EyeLookRange += Normalize(new Vector2(1f, -1f));
                if (Nodes[2].Enabled) EyeLookRange += Normalize(new Vector2(-1f, 1f));
                if (Nodes[3].Enabled) EyeLookRange += Normalize(new Vector2(1f, 1f));
                if (count > 0 &&
                    ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)engine).VectorArithmetic.Length(
                        EyeLookRange) > 0)
                {
                    EyeLookRange /= count;
                    EyeLookRange = Normalize(EyeLookRange);
                }

                EyeTargetDirection = EyeDirection = EyeLookRange;
            }

            if (EyesExist)
            {
                Blink = new global::Celeste.Core.Scheduling.SimulationCoroutine(engine, BlinkRoutine());
                var list = Atlas.Frames(StyleProvider.GetStyle(((IDustGraphicScene)Scene).DustAreaID).EyeTextures);
                EyeTexture = list[EyeTextureIndex % list.Count];
                ((global::Celeste.Scene.Tracking.ISourceScene)Parent.Scene).SourceScene.QueueSourceEntity(
                    Eyes = new DustEyeballsState(this));
            }

            DustProcess.DustGraphicEstabledCounter++;
            Estableshed = true;
            OnEstablish?.Invoke();
            processRandom.PopRandom();
        }

        void AddNode(Vector2 angle, bool enabled)
        {
            var expand = Vector2.One;
            if (AutoExpandDust)
            {
                int x = Math.Sign(angle.X), y = Math.Sign(angle.Y);
                Parent.Collidable = false;
                global::Celeste.Core.Geometry.IntRect horizontal = new global::Celeste.Core.Geometry.IntRect(
                    (int)(Parent.Position.X - 4 + x * 16), (int)(Parent.Position.Y - 4 + y * 4),
                    8, 8);
                if (CollideRect("Celeste.Solid", horizontal) || CollideRect("Celeste.DustStaticSpinner", horizontal))
                    expand.X = 5;
                global::Celeste.Core.Geometry.IntRect vertical = new global::Celeste.Core.Geometry.IntRect(
                    (int)(Parent.Position.X - 4 + x * 4), (int)(Parent.Position.Y - 4 + y * 16),
                    8, 8);
                if (CollideRect("Celeste.Solid", vertical) || CollideRect("Celeste.DustStaticSpinner", vertical))
                    expand.Y = 5;
                Parent.Collidable = true;
            }

            var node = new Node
            {
                Base = Choose(Random, "base"), Overlay = Choose(Random, "overlay"),
                Rotation = global::Celeste.Core.Randomness.SourceRandomMath.NextFloat(Random) * ((float)Math.PI * 2f),
                Angle = angle * expand, Enabled = enabled
            };
            Nodes.Add(node);
            (angle.X < 0 ? LeftNodes : RightNodes).Add(node);
            (angle.Y < 0 ? TopNodes : BottomNodes).Add(node);
        }

        IEnumerator BlinkRoutine()
        {
            while (true)
            {
                yield return 2f + global::Celeste.Core.Randomness.SourceRandomMath.NextFloat(Random) * 1.5f;
                LeftEyeVisible = false;
                yield return .02f + global::Celeste.Core.Randomness.SourceRandomMath.NextFloat(Random) * .05f;
                RightEyeVisible = false;
                yield return .25f;
                RightEyeVisible = LeftEyeVisible = true;
            }
        }

        public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            if (!InView) return;
            var position = RenderPosition;
            foreach (var node in Nodes)
            {
                if (!node.Enabled) continue;
                DrawSourceCentered(context, Parent, node.Base, position + node.Angle * Scale,
                    global::Celeste.Core.Display.PackedColor.White, node.Rotation);
                DrawSourceCentered(context, Parent, node.Overlay, position + node.Angle * Scale,
                    global::Celeste.Core.Display.PackedColor.White, 0f - node.Rotation);
            }

            DrawSourceCentered(context, Parent, Center, position, global::Celeste.Core.Display.PackedColor.White,
                Timer);
        }

        internal void DrawSourceCentered(global::Celeste.Core.Rendering.ISourceRenderContext context,
            object actualEntity,
            global::Celeste.Graphics.Content.Atlas.AtlasEntry texture, Vector2 position,
            global::Celeste.Core.Display.PackedColor color, float rotation = 0f)
        {
            global::Celeste.Graphics.Rendering.SourceAtlasDrawing.Draw(context, actualEntity, texture, position,
                new Vector2(texture.FrameWidth / 2f, texture.FrameHeight / 2f), color, new Vector2(Scale), rotation);
        }

        public Vector2 Normalize(Vector2 value) =>
            ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(value);

        private static Vector2 Angle(float angle) =>
            global::Celeste.Core.Mathematics.Vector2Geometry.AngleToVector(angle, 1f);

        private static float Atan(Vector2 value) => global::Celeste.Core.Mathematics.Vector2Geometry.Angle(value);

        private static float AngleApproach(float value, float target, float amount) =>
            global::Celeste.Core.Mathematics.ScalarMath.AngleApproach(value, target, amount);

        private bool CollideRect(string sourceType, global::Celeste.Core.Geometry.IntRect rectangle)
        {
            var entities =
                ((global::Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Entities
                .GetTrackedEntities(sourceType);
            foreach (var entry in entities)
            {
                var actual = (global::Celeste.Physics.Collision.ISourceEntityCollider)entry;
                if (actual.Collidable && actual.Collider != null && actual.Collider.Collide(rectangle)) return true;
            }

            return false;
        }
    }
}
