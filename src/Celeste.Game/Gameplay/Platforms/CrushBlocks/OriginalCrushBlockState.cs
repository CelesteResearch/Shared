using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Geometry;
using Celeste.Core.Audio;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Components.Timing;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Simulation.Gameplay.Environment.Water;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Surfaces;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Controls.Source;
using Celeste.Game.Gameplay.Platforms.FallingBlocks;

namespace Celeste.Game.Gameplay.Platforms.CrushBlocks
{
    public class OriginalCrushBlockState : SourceSolidEntityState,
        Celeste.Simulation.Gameplay.Platforms.Crushing.ICrushingSolidCollisionCallbackSource
    {
        public Action<Vector2, Vector2, ISourcePlatformEntity> CrushingCollisionCallback { get; set; }

        public enum Axes
        {
            Both,
            Horizontal,
            Vertical
        }

        private struct MoveState
        {
            public Vector2 From, Direction;

            public MoveState(Vector2 from, Vector2 direction)
            {
                From = from;
                Direction = direction;
            }
        }

        private ParticleTypePresentation P_Impact =>
            ((IOriginalGameplayProcess)engine).ParticleTypes.CrushBlock.P_Impact;

        private ParticleTypePresentation P_Crushing =>
            ((IOriginalGameplayProcess)engine).ParticleTypes.CrushBlock.P_Crushing;

        private ParticleTypePresentation P_Activate =>
            ((IOriginalGameplayProcess)engine).ParticleTypes.CrushBlock.P_Activate;

        private const float CrushSpeed = 240f;

        private const float CrushAccel = 500f;

        private const float ReturnSpeed = 60f;

        private const float ReturnAccel = 160f;

        private PackedColor fill = new PackedColor(98, 34, 43, 255);

        private OriginalLevelSceneRoot level;
        private readonly ISourceEngineContext engine;
        private readonly string spriteDirectory;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private SceneEntityRegistry Tracker => ((ISourceScene)Scene).SourceScene.Entities;

        private bool canActivate;

        private Vector2 crushDir;

        private List<MoveState> returnStack;

        private SimulationCoroutine attackCoroutine;

        private bool canMoveVertically;

        private bool canMoveHorizontally;

        private bool chillOut;

        private bool giant;

        private Sprite face;

        private string nextFaceDirection;

        private List<SpriteImage> idleImages = new List<SpriteImage>();

        private List<SpriteImage> activeTopImages = new List<SpriteImage>();

        private List<SpriteImage> activeRightImages = new List<SpriteImage>();

        private List<SpriteImage> activeLeftImages = new List<SpriteImage>();

        private List<SpriteImage> activeBottomImages = new List<SpriteImage>();

        private SoundSourceComponentState currentMoveLoopSfx;

        private SoundSourceComponentState returnLoopSfx;

        private bool Submerged => SourceSceneCollision.CheckRect(Tracker, "Celeste.Water",
            new IntRect((int)(base.Center.X - 4f), (int)base.Center.Y, 8, 4));

        public OriginalCrushBlockState(ISourceEngineContext engine, Vector2 position, float width, float height,
            Axes axes,
            ISourceSolidWorld world, bool chillOut = false)
            : this(engine, position, width, height, axes, world, chillOut, null)
        {
        }

        protected OriginalCrushBlockState(ISourceEngineContext engine, Vector2 position, float width, float height,
            Axes axes, ISourceSolidWorld world, bool chillOut, string spriteDirectory)
            : base(position, width, height, false, world)
        {
            this.engine = engine;
            this.spriteDirectory = spriteDirectory;
            OnDashCollide = OnDashed;
            returnStack = new List<MoveState>();
            this.chillOut = chillOut;
            giant = base.Width >= 48f && base.Height >= 48f && chillOut;
            canActivate = true;
            attackCoroutine = new SimulationCoroutine(engine);
            attackCoroutine.RemoveOnComplete = false;
            OwnedComponents.Add(attackCoroutine);
            List<AtlasEntry> atlasSubtextures =
                Graphics.GameAtlas.GetAtlasSubtextures(ResolveTexturePath("objects/crushblock/block"));
            AtlasEntry idle;
            switch (axes)
            {
                default:
                    idle = atlasSubtextures[3];
                    canMoveHorizontally = (canMoveVertically = true);
                    break;
                case Axes.Horizontal:
                    idle = atlasSubtextures[1];
                    canMoveHorizontally = true;
                    canMoveVertically = false;
                    break;
                case Axes.Vertical:
                    idle = atlasSubtextures[2];
                    canMoveHorizontally = false;
                    canMoveVertically = true;
                    break;
            }

            OwnedComponents.Add(face = Graphics.SpriteBank.Create(giant ? "giant_crushblock_face" : "crushblock_face"));
            face.Position =
                ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(new Vector2(base.Width, base.Height), 2f);
            face.Play("idle");
            face.OnLastFrame = delegate(string f)
            {
                if (f == "hit")
                {
                    face.Play(nextFaceDirection);
                }
            };
            int num = (int)(base.Width / 8f) - 1;
            int num2 = (int)(base.Height / 8f) - 1;
            AddImage(idle, 0, 0, 0, 0, -1, -1);
            AddImage(idle, num, 0, 3, 0, 1, -1);
            AddImage(idle, 0, num2, 0, 3, -1, 1);
            AddImage(idle, num, num2, 3, 3, 1, 1);
            for (int num3 = 1; num3 < num; num3++)
            {
                AddImage(idle, num3, 0, ((ISourceRandomEnvironment)engine).Random.Choose(1, 2), 0, 0, -1);
                AddImage(idle, num3, num2, ((ISourceRandomEnvironment)engine).Random.Choose(1, 2), 3, 0, 1);
            }

            for (int num4 = 1; num4 < num2; num4++)
            {
                AddImage(idle, 0, num4, 0, ((ISourceRandomEnvironment)engine).Random.Choose(1, 2), -1);
                AddImage(idle, num, num4, 3, ((ISourceRandomEnvironment)engine).Random.Choose(1, 2), 1);
            }

            OwnedComponents.Add(new LightOccludeState(0.2f));
            OwnedComponents.Add(returnLoopSfx = new SoundSourceComponentState(engine));
            OwnedComponents.Add(
                ((IWaterInteractionConstructionEnvironment)engine).WaterInteractions.Create(() =>
                    crushDir != Vector2.Zero));
        }

        public OriginalCrushBlockState(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world)
            : this(engine, SourceVector2Math.Add(data.Position, offset), data.Width, data.Height,
                EntityAttributeReader.Enum(data.Values, "axes", Axes.Both), world,
                EntityAttributeReader.Bool(data.Values, "chillout"))
        {
        }

        protected OriginalCrushBlockState(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world, string spriteDirectory)
            : this(engine, SourceVector2Math.Add(data.Position, offset), data.Width, data.Height,
                EntityAttributeReader.Enum(data.Values, "axes", Axes.Both), world,
                EntityAttributeReader.Bool(data.Values, "chillout"), spriteDirectory)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            level = ((OriginalLevelSceneRoot)Scene);
        }

        public override void Update()
        {
            base.Update();
            if (crushDir == Vector2.Zero)
            {
                face.Position =
                    ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(new Vector2(base.Width, base.Height),
                        2f);
                if (SourceTrackedEntityCollision.CheckAt(Tracker,
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName, this,
                        SourceVector2Math.Add(Position, new Vector2(-1f, 0f))))
                {
                    face.Position.X -= 1f;
                }
                else if (SourceTrackedEntityCollision.CheckAt(Tracker,
                             typeof(global::Celeste.Simulation.RoomPlayerSession).FullName, this,
                             SourceVector2Math.Add(Position, new Vector2(1f, 0f))))
                {
                    face.Position.X += 1f;
                }
                else if (SourceTrackedEntityCollision.CheckAt(Tracker,
                             typeof(global::Celeste.Simulation.RoomPlayerSession).FullName, this,
                             SourceVector2Math.Add(Position, new Vector2(0f, -1f))))
                {
                    face.Position.Y -= 1f;
                }
            }

            if (currentMoveLoopSfx != null)
            {
                currentMoveLoopSfx.Param("submerged", Submerged ? 1 : 0);
            }

            if (returnLoopSfx != null)
            {
                returnLoopSfx.Param("submerged", Submerged ? 1 : 0);
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            Vector2 position = Position;
            Position = SourceVector2Math.Add(Position, base.Shake);
            SourcePrimitiveDrawing.Rect(context, this, base.X + 2f, base.Y + 2f, base.Width - 4f, base.Height - 4f,
                fill);
            base.Render(context);
            Position = position;
        }

        private void AddImage(AtlasEntry idle, int x, int y, int tx, int ty, int borderX = 0, int borderY = 0)
        {
            AtlasEntry subtexture = idle.GetSubtexture(tx * 8, ty * 8, 8, 8);
            Vector2 vector = new Vector2(x * 8, y * 8);
            if (borderX != 0)
            {
                SpriteImage image = new SpriteImage(subtexture);
                image.Color = PackedColor.Black;
                image.Position = SourceVector2Math.Add(vector, new Vector2(borderX, 0f));
                OwnedComponents.Add(image);
            }

            if (borderY != 0)
            {
                SpriteImage image2 = new SpriteImage(subtexture);
                image2.Color = PackedColor.Black;
                image2.Position = SourceVector2Math.Add(vector, new Vector2(0f, borderY));
                OwnedComponents.Add(image2);
            }

            SpriteImage image3 = new SpriteImage(subtexture);
            image3.Position = vector;
            OwnedComponents.Add(image3);
            idleImages.Add(image3);
            if (borderX != 0 || borderY != 0)
            {
                if (borderX < 0)
                {
                    SpriteImage image4 = new SpriteImage(Graphics
                        .GameAtlas[ResolveTexturePath("objects/crushblock/lit_left")]
                        .GetSubtexture(0, ty * 8, 8, 8));
                    activeLeftImages.Add(image4);
                    image4.Position = vector;
                    image4.Visible = false;
                    OwnedComponents.Add(image4);
                }
                else if (borderX > 0)
                {
                    SpriteImage image5 = new SpriteImage(Graphics
                        .GameAtlas[ResolveTexturePath("objects/crushblock/lit_right")]
                        .GetSubtexture(0, ty * 8, 8, 8));
                    activeRightImages.Add(image5);
                    image5.Position = vector;
                    image5.Visible = false;
                    OwnedComponents.Add(image5);
                }

                if (borderY < 0)
                {
                    SpriteImage image6 =
                        new SpriteImage(Graphics.GameAtlas[ResolveTexturePath("objects/crushblock/lit_top")]
                            .GetSubtexture(tx * 8, 0, 8, 8));
                    activeTopImages.Add(image6);
                    image6.Position = vector;
                    image6.Visible = false;
                    OwnedComponents.Add(image6);
                }
                else if (borderY > 0)
                {
                    SpriteImage image7 = new SpriteImage(Graphics
                        .GameAtlas[ResolveTexturePath("objects/crushblock/lit_bottom")]
                        .GetSubtexture(tx * 8, 0, 8, 8));
                    activeBottomImages.Add(image7);
                    image7.Position = vector;
                    image7.Visible = false;
                    OwnedComponents.Add(image7);
                }
            }
        }

        protected SoundSourceComponentState CurrentMoveLoopSource => currentMoveLoopSfx;
        protected SoundSourceComponentState ReturnMoveLoopSource => returnLoopSfx;
        protected Sprite SourceFace => face;
        protected bool SourceGiant => giant;

        protected PackedColor SourceFill
        {
            get => fill;
            set => fill = value;
        }

        private string ResolveTexturePath(string path)
            => spriteDirectory == null ? path : path.Replace("objects/crushblock", spriteDirectory);

        protected virtual string ResolveSoundPath(string path) => path;
        protected Vector2 SourceCrushDirection => crushDir;
        protected virtual void StopMoveLoopForSlowdown() => currentMoveLoopSfx.Stop();

        private void TurnOffImages()
        {
            foreach (SpriteImage activeLeftImage in activeLeftImages)
            {
                activeLeftImage.Visible = false;
            }

            foreach (SpriteImage activeRightImage in activeRightImages)
            {
                activeRightImage.Visible = false;
            }

            foreach (SpriteImage activeTopImage in activeTopImages)
            {
                activeTopImage.Visible = false;
            }

            foreach (SpriteImage activeBottomImage in activeBottomImages)
            {
                activeBottomImage.Visible = false;
            }
        }

        private DashCollisionResult OnDashed(RoomPlayerSession player, Vector2 direction)
        {
            if (CanActivate(SourceVector2Math.Negate(direction)))
            {
                Attack(SourceVector2Math.Negate(direction));
                return DashCollisionResult.Rebound;
            }

            return DashCollisionResult.NormalCollision;
        }

        private bool CanActivate(Vector2 direction)
        {
            if (giant && direction.X <= 0f)
            {
                return false;
            }

            if (canActivate && crushDir != direction)
            {
                if (direction.X != 0f && !canMoveHorizontally)
                {
                    return false;
                }

                if (direction.Y != 0f && !canMoveVertically)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        private void Attack(Vector2 direction)
        {
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                ResolveSoundPath("event:/game/06_reflection/crushblock_activate"),
                base.Center);
            if (currentMoveLoopSfx != null)
            {
                currentMoveLoopSfx.Param("end", 1f);
                SoundSourceComponentState sfx = currentMoveLoopSfx;
                SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, 0.5f, delegate { sfx.RemoveSelf(); });
            }

            OwnedComponents.Add(currentMoveLoopSfx = new SoundSourceComponentState(engine));
            currentMoveLoopSfx.Position =
                ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(new Vector2(base.Width, base.Height), 2f);
            if (((IOriginalGameplayProcess)engine).SaveContext.CurrentSave != null &&
                ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Name != null &&
                ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Name.StartsWith("FWAHAHA",
                    StringComparison.InvariantCultureIgnoreCase))
            {
                currentMoveLoopSfx.Play("event:/game/06_reflection/crushblock_move_loop_covert");
            }
            else
            {
                currentMoveLoopSfx.Play(ResolveSoundPath("event:/game/06_reflection/crushblock_move_loop"));
            }

            face.Play("hit");
            crushDir = direction;
            canActivate = false;
            attackCoroutine.Replace(AttackSequence());
            ClearRemainder();
            TurnOffImages();
            ActivateParticles(crushDir);
            if (crushDir.X < 0f)
            {
                foreach (SpriteImage activeLeftImage in activeLeftImages)
                {
                    activeLeftImage.Visible = true;
                }

                nextFaceDirection = "left";
            }
            else if (crushDir.X > 0f)
            {
                foreach (SpriteImage activeRightImage in activeRightImages)
                {
                    activeRightImage.Visible = true;
                }

                nextFaceDirection = "right";
            }
            else if (crushDir.Y < 0f)
            {
                foreach (SpriteImage activeTopImage in activeTopImages)
                {
                    activeTopImage.Visible = true;
                }

                nextFaceDirection = "up";
            }
            else if (crushDir.Y > 0f)
            {
                foreach (SpriteImage activeBottomImage in activeBottomImages)
                {
                    activeBottomImage.Visible = true;
                }

                nextFaceDirection = "down";
            }

            bool flag = true;
            if (returnStack.Count > 0)
            {
                MoveState moveState = returnStack[returnStack.Count - 1];
                if (moveState.Direction == direction || moveState.Direction == SourceVector2Math.Negate(direction))
                {
                    flag = false;
                }
            }

            if (flag)
            {
                returnStack.Add(new MoveState(Position, crushDir));
            }
        }

        private void ActivateParticles(Vector2 dir)
        {
            float direction;
            Vector2 position;
            Vector2 positionRange;
            int num;
            if (dir == Vector2.UnitX)
            {
                direction = 0f;
                position = SourceVector2Math.Subtract(base.CenterRight, Vector2.UnitX);
                positionRange =
                    SourceVector2Math.Multiply(SourceVector2Math.Multiply(Vector2.UnitY, (base.Height - 2f)), 0.5f);
                num = (int)(base.Height / 8f) * 4;
            }
            else if (dir == SourceVector2Math.Negate(Vector2.UnitX))
            {
                direction = (float)Math.PI;
                position = SourceVector2Math.Add(base.CenterLeft, Vector2.UnitX);
                positionRange =
                    SourceVector2Math.Multiply(SourceVector2Math.Multiply(Vector2.UnitY, (base.Height - 2f)), 0.5f);
                num = (int)(base.Height / 8f) * 4;
            }
            else if (dir == Vector2.UnitY)
            {
                direction = (float)Math.PI / 2f;
                position = SourceVector2Math.Subtract(base.BottomCenter, Vector2.UnitY);
                positionRange =
                    SourceVector2Math.Multiply(SourceVector2Math.Multiply(Vector2.UnitX, (base.Width - 2f)), 0.5f);
                num = (int)(base.Width / 8f) * 4;
            }
            else
            {
                direction = -(float)Math.PI / 2f;
                position = SourceVector2Math.Add(base.TopCenter, Vector2.UnitY);
                positionRange =
                    SourceVector2Math.Multiply(SourceVector2Math.Multiply(Vector2.UnitX, (base.Width - 2f)), 0.5f);
                num = (int)(base.Width / 8f) * 4;
            }

            num += 2;
            level.Particles.Emit(P_Activate, num, position, positionRange, direction);
        }

        private IEnumerator AttackSequence()
        {
            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Strong,
                RumbleLength.Medium);
            StartShaking(0.4f);
            yield return 0.4f;
            if (!chillOut)
            {
                canActivate = true;
            }

            StopPlayerRunIntoAnimation = false;
            bool slowing = false;
            float speed = 0f;
            while (true)
            {
                if (!chillOut)
                {
                    speed = ScalarMath.Approach(speed, 240f, 500f * engine.DeltaTime,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                }
                else if (slowing || SourceTrackedEntityCollision.CheckAt(Tracker, "Celeste.SolidTiles", this,
                             SourceVector2Math.Add(Position, SourceVector2Math.Multiply(crushDir, 256f))))
                {
                    speed = ScalarMath.Approach(speed, 24f, 500f * engine.DeltaTime * 0.25f,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                    if (!slowing)
                    {
                        slowing = true;
                        SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, 0.5f, delegate
                        {
                            face.Play("hurt");
                            StopMoveLoopForSlowdown();
                            TurnOffImages();
                        });
                    }
                }
                else
                {
                    speed = ScalarMath.Approach(speed, 240f, 500f * engine.DeltaTime,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                }

                bool flag = ((crushDir.X == 0f)
                    ? MoveVCheck(speed * crushDir.Y * engine.DeltaTime)
                    : MoveHCheck(speed * crushDir.X * engine.DeltaTime));
                if (base.Top >= (float)(level.Bounds.Bottom + 32))
                {
                    RemoveSelf();
                    yield break;
                }

                if (flag)
                {
                    break;
                }

                if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.02f, engine))
                {
                    Vector2 position;
                    float direction;
                    if (crushDir == Vector2.UnitX)
                    {
                        position = new Vector2(base.Left + 1f,
                            SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, base.Top + 3f,
                                base.Bottom - 3f));
                        direction = (float)Math.PI;
                    }
                    else if (crushDir == SourceVector2Math.Negate(Vector2.UnitX))
                    {
                        position = new Vector2(base.Right - 1f,
                            SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, base.Top + 3f,
                                base.Bottom - 3f));
                        direction = 0f;
                    }
                    else if (crushDir == Vector2.UnitY)
                    {
                        position = new Vector2(
                            SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, base.Left + 3f,
                                base.Right - 3f), base.Top + 1f);
                        direction = -(float)Math.PI / 2f;
                    }
                    else
                    {
                        position = new Vector2(
                            SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, base.Left + 3f,
                                base.Right - 3f), base.Bottom - 1f);
                        direction = (float)Math.PI / 2f;
                    }

                    level.Particles.Emit(P_Crushing, position, direction);
                }

                yield return null;
            }

            OriginalFallingBlockState fallingBlock =
                SourceTrackedEntityCollision.FirstAt<OriginalFallingBlockState>(Tracker, "Celeste.FallingBlock", this,
                    SourceVector2Math.Add(Position, crushDir));
            if (fallingBlock != null)
            {
                fallingBlock.Triggered = true;
            }

            if (crushDir == SourceVector2Math.Negate(Vector2.UnitX))
            {
                Vector2 vector = new Vector2(0f, 2f);
                for (int num = 0; (float)num < base.Height / 8f; num++)
                {
                    Vector2 vector2 = new Vector2(base.Left - 1f, base.Top + 4f + (float)(num * 8));
                    if (!SourceSceneCollision.CheckPoint(Tracker, "Celeste.Water", vector2) &&
                        SourceSceneCollision.CheckPoint(Tracker, "Celeste.Solid", vector2))
                    {
                        ((OriginalLevelSceneRoot)Scene).ParticlesFG.Emit(P_Impact,
                            SourceVector2Math.Add(vector2, vector),
                            0f);
                        ((OriginalLevelSceneRoot)Scene).ParticlesFG.Emit(P_Impact,
                            SourceVector2Math.Subtract(vector2, vector), 0f);
                    }
                }
            }
            else if (crushDir == Vector2.UnitX)
            {
                Vector2 vector3 = new Vector2(0f, 2f);
                for (int num2 = 0; (float)num2 < base.Height / 8f; num2++)
                {
                    Vector2 vector4 = new Vector2(base.Right + 1f, base.Top + 4f + (float)(num2 * 8));
                    if (!SourceSceneCollision.CheckPoint(Tracker, "Celeste.Water", vector4) &&
                        SourceSceneCollision.CheckPoint(Tracker, "Celeste.Solid", vector4))
                    {
                        ((OriginalLevelSceneRoot)Scene).ParticlesFG.Emit(P_Impact,
                            SourceVector2Math.Add(vector4, vector3),
                            (float)Math.PI);
                        ((OriginalLevelSceneRoot)Scene).ParticlesFG.Emit(P_Impact,
                            SourceVector2Math.Subtract(vector4, vector3), (float)Math.PI);
                    }
                }
            }
            else if (crushDir == SourceVector2Math.Negate(Vector2.UnitY))
            {
                Vector2 vector5 = new Vector2(2f, 0f);
                for (int num3 = 0; (float)num3 < base.Width / 8f; num3++)
                {
                    Vector2 vector6 = new Vector2(base.Left + 4f + (float)(num3 * 8), base.Top - 1f);
                    if (!SourceSceneCollision.CheckPoint(Tracker, "Celeste.Water", vector6) &&
                        SourceSceneCollision.CheckPoint(Tracker, "Celeste.Solid", vector6))
                    {
                        ((OriginalLevelSceneRoot)Scene).ParticlesFG.Emit(P_Impact,
                            SourceVector2Math.Add(vector6, vector5),
                            (float)Math.PI / 2f);
                        ((OriginalLevelSceneRoot)Scene).ParticlesFG.Emit(P_Impact,
                            SourceVector2Math.Subtract(vector6, vector5), (float)Math.PI / 2f);
                    }
                }
            }
            else if (crushDir == Vector2.UnitY)
            {
                Vector2 vector7 = new Vector2(2f, 0f);
                for (int num4 = 0; (float)num4 < base.Width / 8f; num4++)
                {
                    Vector2 vector8 = new Vector2(base.Left + 4f + (float)(num4 * 8), base.Bottom + 1f);
                    if (!SourceSceneCollision.CheckPoint(Tracker, "Celeste.Water", vector8) &&
                        SourceSceneCollision.CheckPoint(Tracker, "Celeste.Solid", vector8))
                    {
                        ((OriginalLevelSceneRoot)Scene).ParticlesFG.Emit(P_Impact,
                            SourceVector2Math.Add(vector8, vector7),
                            -(float)Math.PI / 2f);
                        ((OriginalLevelSceneRoot)Scene).ParticlesFG.Emit(P_Impact,
                            SourceVector2Math.Subtract(vector8, vector7), -(float)Math.PI / 2f);
                    }
                }
            }

            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                ResolveSoundPath("event:/game/06_reflection/crushblock_impact"),
                base.Center);
            level.DirectionalShake(crushDir);
            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Medium,
                RumbleLength.Medium);
            StartShaking(0.4f);
            StopPlayerRunIntoAnimation = true;
            SoundSourceComponentState sfx = currentMoveLoopSfx;
            currentMoveLoopSfx.Param("end", 1f);
            currentMoveLoopSfx = null;
            SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, 0.5f, delegate { sfx.RemoveSelf(); });
            crushDir = Vector2.Zero;
            TurnOffImages();
            if (chillOut)
            {
                yield break;
            }

            face.Play("hurt");
            returnLoopSfx.Play(ResolveSoundPath("event:/game/06_reflection/crushblock_return_loop"));
            yield return 0.4f;
            speed = 0f;
            float waypointSfxDelay = 0f;
            while (returnStack.Count > 0)
            {
                yield return null;
                StopPlayerRunIntoAnimation = false;
                MoveState moveState = returnStack[returnStack.Count - 1];
                speed = ScalarMath.Approach(speed, 60f, 160f * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                waypointSfxDelay -= engine.DeltaTime;
                if (moveState.Direction.X != 0f)
                {
                    MoveTowardsX(moveState.From.X, speed * engine.DeltaTime);
                }

                if (moveState.Direction.Y != 0f)
                {
                    MoveTowardsY(moveState.From.Y, speed * engine.DeltaTime);
                }

                if ((moveState.Direction.X != 0f && base.ExactPosition.X != moveState.From.X) ||
                    (moveState.Direction.Y != 0f && base.ExactPosition.Y != moveState.From.Y))
                {
                    continue;
                }

                speed = 0f;
                returnStack.RemoveAt(returnStack.Count - 1);
                StopPlayerRunIntoAnimation = true;
                if (returnStack.Count <= 0)
                {
                    face.Play("idle");
                    returnLoopSfx.Stop();
                    if (waypointSfxDelay <= 0f)
                    {
                        ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                            ResolveSoundPath("event:/game/06_reflection/crushblock_rest"), base.Center);
                    }
                }
                else if (waypointSfxDelay <= 0f)
                {
                    ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                        ResolveSoundPath("event:/game/06_reflection/crushblock_rest_waypoint"), base.Center);
                }

                waypointSfxDelay = 0.1f;
                StartShaking(0.2f);
                yield return 0.2f;
            }
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        private bool MoveHCheck(float amount) =>
            Celeste.Simulation.Gameplay.Platforms.Crushing.CrushingSolidMotion.CheckHorizontal(this, level, amount,
                CrushingCollisionCallback);

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        private bool MoveVCheck(float amount) =>
            Celeste.Simulation.Gameplay.Platforms.Crushing.CrushingSolidMotion
                .CheckVertical(this, level, amount, false, CrushingCollisionCallback);
    }
}
