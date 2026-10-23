using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering;
using Celeste.Physics.Collision;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Simulation.Gameplay.Hazards.Spinners.Dust
{
    public class DustGraphicState : SourceComponentState
    {
        public class Node
        {
            public AtlasEntry Base, Overlay;
            public float Rotation;
            public Vector2 Angle;
            public bool Enabled;
        }

        internal ISourceEngineContext EngineContext { get; }

        private AtlasData Atlas =>
            ((ISourceGameGraphicsEnvironment)EngineContext).GameGraphics.GameAtlas;

        public SceneEntityState Parent =>
            (SceneEntityState)Entity;

        private ISourceRandom Random =>
            ((ISourceRandomEnvironment)EngineContext).Random;

        private SourceDustProcessState DustProcess => ((ISourceDustProcessEnvironment)EngineContext).DustProcess;
        internal IDustStyleProvider StyleProvider => ((ISourceDustStyleEnvironment)EngineContext).DustStyles;

        public readonly List<Node> Nodes = [],
            LeftNodes = [],
            RightNodes = [],
            TopNodes = [],
            BottomNodes = [];

        public readonly AtlasEntry Center;
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
        public AtlasEntry EyeTexture;
        public DustEyeballsState Eyes;
        public SimulationCoroutine Blink;
        public Action OnEstablish;
        public DustEdgePresentation Edge { get; private set; }
        public Vector2 RenderPosition => Parent.Position + Position + ShakeValue;

        public bool InView
        {
            get
            {
                var camera = ((ISourceCameraScene)Scene).Camera;
                var position = Parent.Position;
                if (!(position.X + 16f < camera.Left) && !(position.Y + 16f < camera.Top) &&
                    !(position.X - 16f > camera.Right)) return !(position.Y - 16f > camera.Bottom);
                return false;
            }
        }

        public DustGraphicState(ISourceEngineContext engine, bool ignoreSolids,
            bool autoControlEyes = false, bool autoExpandDust = false) : base(true, true)
        {
            EngineContext = engine ?? throw new ArgumentNullException(nameof(engine));
            IgnoreSolids = ignoreSolids;
            AutoControlEyes = autoControlEyes;
            AutoExpandDust = autoExpandDust;
            Center = Choose(Random, "center");
            Offset = SourceRandomMath.NextFloat(Random) * 4f;
            Timer = SourceRandomMath.NextFloat(Random);
            EyeTargetDirection = EyeDirection =
                Angle(SourceRandomMath.NextFloat(Random) * ((float)Math.PI * 2));
            EyeTextureIndex = Random.Next(128);
            EyesExist = true;
            if (autoControlEyes)
            {
                EyesExist = SourceRandomMath.NextFloat(Random) < .5f;
                EyesFollowPlayer = SourceRandomMath.NextFloat(Random) < .3f;
            }

            RandomSeed = Random.Next();
        }

        public override void Added(object entity)
        {
            base.Added(entity);
            var owned = ((ISourceOwnedComponentList)entity).OwnedComponents;
            owned.Add(new RoomTransitionListener
                { OnIn = percent => AddDustNodesIfInCamera() });
            Edge = new(Render);
            owned.Add(Edge);
        }

        private AtlasEntry Choose(
            ISourceRandom random, string name)
        {
            var list = Atlas.Frames("danger/dustcreature/" + name);
            return list[random.Next(list.Count)];
        }

        public void TransitionIn(float percent)
        {
            AddDustNodesIfInCamera();
        }

        public override void Update()
        {
            Timer += EngineContext.DeltaTime * .6f;
            var view = InView;
            if (ShakeTimer > 0)
            {
                ShakeTimer -= EngineContext.DeltaTime;
                if (ShakeTimer <= 0) ShakeValue = Vector2.Zero;
                else if (((IDustGraphicScene)Scene).Clock.OnInterval(.05f, EngineContext))
                    ShakeValue = RandomShakeVector.Next(Random);
            }

            if (EyesExist)
            {
                if (EyeDirection != EyeTargetDirection && view)
                {
                    if (!EyesMoveByRotation)
                    {
                        EyeDirection = ((ISourceVectorEnvironment)EngineContext)
                            .VectorArithmetic.Approach(EyeDirection, EyeTargetDirection, 12f * EngineContext.DeltaTime);
                    }
                    else
                    {
                        float target = Atan(EyeTargetDirection),
                            a = AngleApproach(Atan(EyeDirection), target, 8f * EngineContext.DeltaTime);
                        // ReSharper disable once CompareOfFloatsByEqualityOperator
                        EyeDirection = a == target ? EyeTargetDirection : Angle(a);
                    }
                }

                if (EyesFollowPlayer && view)
                {
                    var player = ((ISourceScene)Parent.Scene).SourceScene.Entities
                        .GetTrackedEntity<RoomPlayerSession>(
                            typeof(RoomPlayerSession).FullName);
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

            foreach (var node in Nodes) node.Rotation += EngineContext.DeltaTime * .5f;
        }

        public void OnHitPlayer()
        {
            if (((ISourceDustProcessEnvironment)EngineContext).Invincible) return;
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
            var processRandom = ((ISourceRandomProcessEnvironment)EngineContext).RandomProcess;
            processRandom.PushRandom(RandomSeed);
            int x = (int)Parent.Position.X, y = (int)Parent.Position.Y;
            var direction = Normalize(Vector2.One);
            AddNode(new(0f - direction.X, 0f - direction.Y),
                IgnoreSolids || !CollideRect("Celeste.Solid",
                    new(x - 8, y - 8, 8, 8)));
            AddNode(new(direction.X, 0f - direction.Y),
                IgnoreSolids || !CollideRect("Celeste.Solid",
                    new(x, y - 8, 8, 8)));
            AddNode(new(0f - direction.X, direction.Y),
                IgnoreSolids || !CollideRect("Celeste.Solid",
                    new(x - 8, y, 8, 8)));
            AddNode(direction,
                IgnoreSolids || !CollideRect("Celeste.Solid", new(x, y, 8, 8)));
            if (Nodes[0].Enabled || Nodes[2].Enabled) Position.X -= 1;
            if (Nodes[1].Enabled || Nodes[3].Enabled) Position.X += 1;
            if (Nodes[0].Enabled || Nodes[1].Enabled) Position.Y -= 1;
            if (Nodes[2].Enabled || Nodes[3].Enabled) Position.Y += 1;
            var count = 0;
            foreach (var node in Nodes)
                if (node.Enabled)
                    count++;
            EyesMoveByRotation = count < 4;
            if (AutoControlEyes && EyesExist && EyesMoveByRotation)
            {
                EyeLookRange = Vector2.Zero;
                if (Nodes[0].Enabled) EyeLookRange += Normalize(new(-1f, -1f));
                if (Nodes[1].Enabled) EyeLookRange += Normalize(new(1f, -1f));
                if (Nodes[2].Enabled) EyeLookRange += Normalize(new(-1f, 1f));
                if (Nodes[3].Enabled) EyeLookRange += Normalize(new(1f, 1f));
                if (count > 0 &&
                    ((ISourceVectorEnvironment)EngineContext).VectorArithmetic.Length(
                        EyeLookRange) > 0)
                {
                    EyeLookRange /= count;
                    EyeLookRange = Normalize(EyeLookRange);
                }

                EyeTargetDirection = EyeDirection = EyeLookRange;
            }

            if (EyesExist)
            {
                Blink = new(EngineContext, BlinkRoutine());
                var list = Atlas.Frames(StyleProvider.GetStyle(((IDustGraphicScene)Scene).DustAreaID).EyeTextures);
                EyeTexture = list[EyeTextureIndex % list.Count];
                ((ISourceScene)Parent.Scene).SourceScene.QueueSourceEntity(
                    Eyes = new(this));
            }

            DustProcess.DustGraphicEstabledCounter++;
            Estableshed = true;
            OnEstablish?.Invoke();
            processRandom.PopRandom();
        }

        private void AddNode(Vector2 angle, bool enabled)
        {
            var expand = Vector2.One;
            if (AutoExpandDust)
            {
                int x = Math.Sign(angle.X), y = Math.Sign(angle.Y);
                Parent.Collidable = false;
                var horizontal = new IntRect(
                    (int)(Parent.Position.X - 4 + x * 16), (int)(Parent.Position.Y - 4 + y * 4),
                    8, 8);
                if (CollideRect("Celeste.Solid", horizontal) || CollideRect("Celeste.DustStaticSpinner", horizontal))
                    expand.X = 5;
                var vertical = new IntRect(
                    (int)(Parent.Position.X - 4 + x * 4), (int)(Parent.Position.Y - 4 + y * 16),
                    8, 8);
                if (CollideRect("Celeste.Solid", vertical) || CollideRect("Celeste.DustStaticSpinner", vertical))
                    expand.Y = 5;
                Parent.Collidable = true;
            }

            var node = new Node
            {
                Base = Choose(Random, "base"), Overlay = Choose(Random, "overlay"),
                Rotation = SourceRandomMath.NextFloat(Random) * ((float)Math.PI * 2f),
                Angle = angle * expand, Enabled = enabled,
            };
            Nodes.Add(node);
            (angle.X < 0 ? LeftNodes : RightNodes).Add(node);
            (angle.Y < 0 ? TopNodes : BottomNodes).Add(node);
        }

        private IEnumerator BlinkRoutine()
        {
            while (true)
            {
                yield return 2f + SourceRandomMath.NextFloat(Random) * 1.5f;
                LeftEyeVisible = false;
                yield return .02f + SourceRandomMath.NextFloat(Random) * .05f;
                RightEyeVisible = false;
                yield return .25f;
                RightEyeVisible = LeftEyeVisible = true;
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            if (!InView) return;
            var position = RenderPosition;
            foreach (var node in Nodes)
            {
                if (!node.Enabled) continue;
                DrawSourceCentered(context, Parent, node.Base, position + node.Angle * Scale,
                    PackedColor.White, node.Rotation);
                DrawSourceCentered(context, Parent, node.Overlay, position + node.Angle * Scale,
                    PackedColor.White, 0f - node.Rotation);
            }

            DrawSourceCentered(context, Parent, Center, position, PackedColor.White,
                Timer);
        }

        internal void DrawSourceCentered(ISourceRenderContext context,
            object actualEntity,
            AtlasEntry texture, Vector2 position,
            PackedColor color, float rotation = 0f)
        {
            SourceAtlasDrawing.Draw(context, actualEntity, texture, position,
                new(texture.FrameWidth / 2f, texture.FrameHeight / 2f), color, new Vector2(Scale), rotation);
        }

        public Vector2 Normalize(Vector2 value)
        {
            return ((ISourceVectorEnvironment)EngineContext).VectorArithmetic.SafeNormalize(value);
        }

        private static Vector2 Angle(float angle)
        {
            return Vector2Geometry.AngleToVector(angle, 1f);
        }

        private static float Atan(Vector2 value)
        {
            return Vector2Geometry.Angle(value);
        }

        private static float AngleApproach(float value, float target, float amount)
        {
            return ScalarMath.AngleApproach(value, target, amount);
        }

        private bool CollideRect(string sourceType, IntRect rectangle)
        {
            var entities =
                ((ISourceScene)Scene).SourceScene.Entities
                .GetTrackedEntities(sourceType);
            foreach (var entry in entities)
            {
                var actual = (ISourceEntityCollider)entry;
                if (actual.Collidable && actual.Collider != null && actual.Collider.Collide(rectangle)) return true;
            }

            return false;
        }
    }
}
