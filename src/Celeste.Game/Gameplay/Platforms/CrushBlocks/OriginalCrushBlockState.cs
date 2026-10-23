using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Audio;
using Celeste.Core.Components.Timing;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Platforms.FallingBlocks;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Environment.Water;
using Celeste.Simulation.Gameplay.Platforms.Crushing;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Surfaces;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Gameplay.Platforms.CrushBlocks
{
    public class OriginalCrushBlockState : SourceSolidEntityState,
        ICrushingSolidCollisionCallbackSource
    {
        public Action<Vector2, Vector2, ISourcePlatformEntity> CrushingCollisionCallback { get; set; }

        public enum Axes
        {
            Both,
            Horizontal,
            Vertical,
        }

        private struct MoveState
        {
            public readonly Vector2 From;
            public readonly Vector2 Direction;

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

        private OriginalLevelSceneRoot level;
        private readonly ISourceEngineContext engine;
        private readonly string spriteDirectory;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private SceneEntityRegistry Tracker => ((ISourceScene)Scene).SourceScene.Entities;

        private bool canActivate;

        private Vector2 crushDir;

        private readonly List<MoveState> returnStack;

        private readonly SimulationCoroutine attackCoroutine;

        private readonly bool canMoveVertically;

        private readonly bool canMoveHorizontally;

        private readonly bool chillOut;

        private string nextFaceDirection;

        private readonly List<SpriteImage> idleImages = [];

        private readonly List<SpriteImage> activeTopImages = [];

        private readonly List<SpriteImage> activeRightImages = [];

        private readonly List<SpriteImage> activeLeftImages = [];

        private readonly List<SpriteImage> activeBottomImages = [];

        private SoundSourceComponentState currentMoveLoopSfx;

        private bool Submerged => SourceSceneCollision.CheckRect(Tracker, "Celeste.Water",
            new((int)(Center.X - 4f), (int)Center.Y, 8, 4));

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
            returnStack = [];
            this.chillOut = chillOut;
            SourceGiant = Width >= 48f && Height >= 48f && chillOut;
            canActivate = true;
            attackCoroutine = new(engine);
            attackCoroutine.RemoveOnComplete = false;
            OwnedComponents.Add(attackCoroutine);
            var atlasSubtextures =
                Graphics.GameAtlas.GetAtlasSubtextures(ResolveTexturePath("objects/crushblock/block"));
            AtlasEntry idle;
            switch (axes)
            {
                default:
                    idle = atlasSubtextures[3];
                    canMoveHorizontally = canMoveVertically = true;
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

            OwnedComponents.Add(SourceFace =
                Graphics.SpriteBank.Create(SourceGiant ? "giant_crushblock_face" : "crushblock_face"));
            SourceFace.Position =
                ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(new Vector2(Width, Height), 2f);
            SourceFace.Play("idle");
            SourceFace.OnLastFrame = delegate(string f)
            {
                if (f == "hit") SourceFace.Play(nextFaceDirection);
            };
            var num = (int)(Width / 8f) - 1;
            var num2 = (int)(Height / 8f) - 1;
            AddImage(idle, 0, 0, 0, 0, -1, -1);
            AddImage(idle, num, 0, 3, 0, 1, -1);
            AddImage(idle, 0, num2, 0, 3, -1, 1);
            AddImage(idle, num, num2, 3, 3, 1, 1);
            for (var num3 = 1; num3 < num; num3++)
            {
                AddImage(idle, num3, 0, ((ISourceRandomEnvironment)engine).Random.Choose(1, 2), 0, 0, -1);
                AddImage(idle, num3, num2, ((ISourceRandomEnvironment)engine).Random.Choose(1, 2), 3, 0, 1);
            }

            for (var num4 = 1; num4 < num2; num4++)
            {
                AddImage(idle, 0, num4, 0, ((ISourceRandomEnvironment)engine).Random.Choose(1, 2), -1);
                AddImage(idle, num, num4, 3, ((ISourceRandomEnvironment)engine).Random.Choose(1, 2), 1);
            }

            OwnedComponents.Add(new LightOccludeState(0.2f));
            OwnedComponents.Add(ReturnMoveLoopSource = new(engine));
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
            level = (OriginalLevelSceneRoot)Scene;
        }

        public override void Update()
        {
            base.Update();
            if (crushDir == Vector2.Zero)
            {
                SourceFace.Position =
                    ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(new Vector2(Width, Height),
                        2f);
                if (SourceTrackedEntityCollision.CheckAt(Tracker,
                        typeof(RoomPlayerSession).FullName, this,
                        SourceVector2Math.Add(Position, new(-1f, 0f))))
                    SourceFace.Position.X -= 1f;
                else if (SourceTrackedEntityCollision.CheckAt(Tracker,
                             typeof(RoomPlayerSession).FullName, this,
                             SourceVector2Math.Add(Position, new(1f, 0f))))
                    SourceFace.Position.X += 1f;
                else if (SourceTrackedEntityCollision.CheckAt(Tracker,
                             typeof(RoomPlayerSession).FullName, this,
                             SourceVector2Math.Add(Position, new(0f, -1f))))
                    SourceFace.Position.Y -= 1f;
            }

            if (CurrentMoveLoopSource != null) CurrentMoveLoopSource.Param("submerged", Submerged ? 1 : 0);

            if (ReturnMoveLoopSource != null) ReturnMoveLoopSource.Param("submerged", Submerged ? 1 : 0);
        }

        public override void Render(ISourceRenderContext context)
        {
            var position = Position;
            Position = SourceVector2Math.Add(Position, Shake);
            SourcePrimitiveDrawing.Rect(context, this, X + 2f, Y + 2f, Width - 4f, Height - 4f,
                SourceFill);
            base.Render(context);
            Position = position;
        }

        private void AddImage(AtlasEntry idle, int x, int y, int tx, int ty, int borderX = 0, int borderY = 0)
        {
            var subtexture = idle.GetSubtexture(tx * 8, ty * 8, 8, 8);
            var vector = new Vector2(x * 8, y * 8);
            if (borderX != 0)
            {
                var image = new SpriteImage(subtexture);
                image.Color = PackedColor.Black;
                image.Position = SourceVector2Math.Add(vector, new(borderX, 0f));
                OwnedComponents.Add(image);
            }

            if (borderY != 0)
            {
                var image2 = new SpriteImage(subtexture);
                image2.Color = PackedColor.Black;
                image2.Position = SourceVector2Math.Add(vector, new(0f, borderY));
                OwnedComponents.Add(image2);
            }

            var image3 = new SpriteImage(subtexture);
            image3.Position = vector;
            OwnedComponents.Add(image3);
            idleImages.Add(image3);
            if (borderX != 0 || borderY != 0)
            {
                if (borderX < 0)
                {
                    var image4 = new SpriteImage(Graphics
                        .GameAtlas[ResolveTexturePath("objects/crushblock/lit_left")]
                        .GetSubtexture(0, ty * 8, 8, 8));
                    activeLeftImages.Add(image4);
                    image4.Position = vector;
                    image4.Visible = false;
                    OwnedComponents.Add(image4);
                }
                else if (borderX > 0)
                {
                    var image5 = new SpriteImage(Graphics
                        .GameAtlas[ResolveTexturePath("objects/crushblock/lit_right")]
                        .GetSubtexture(0, ty * 8, 8, 8));
                    activeRightImages.Add(image5);
                    image5.Position = vector;
                    image5.Visible = false;
                    OwnedComponents.Add(image5);
                }

                if (borderY < 0)
                {
                    var image6 =
                        new SpriteImage(Graphics.GameAtlas[ResolveTexturePath("objects/crushblock/lit_top")]
                            .GetSubtexture(tx * 8, 0, 8, 8));
                    activeTopImages.Add(image6);
                    image6.Position = vector;
                    image6.Visible = false;
                    OwnedComponents.Add(image6);
                }
                else if (borderY > 0)
                {
                    var image7 = new SpriteImage(Graphics
                        .GameAtlas[ResolveTexturePath("objects/crushblock/lit_bottom")]
                        .GetSubtexture(tx * 8, 0, 8, 8));
                    activeBottomImages.Add(image7);
                    image7.Position = vector;
                    image7.Visible = false;
                    OwnedComponents.Add(image7);
                }
            }
        }

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        protected SoundSourceComponentState CurrentMoveLoopSource => currentMoveLoopSfx;
        protected SoundSourceComponentState ReturnMoveLoopSource { get; }

        protected Sprite SourceFace { get; }

        protected bool SourceGiant { get; }

        protected PackedColor SourceFill { get; set; } = new(98, 34, 43, 255);

        private string ResolveTexturePath(string path)
        {
            return spriteDirectory == null ? path : path.Replace("objects/crushblock", spriteDirectory);
        }

        protected virtual string ResolveSoundPath(string path)
        {
            return path;
        }

        protected Vector2 SourceCrushDirection => crushDir;

        protected virtual void StopMoveLoopForSlowdown()
        {
            CurrentMoveLoopSource.Stop();
        }

        private void TurnOffImages()
        {
            foreach (var activeLeftImage in activeLeftImages) activeLeftImage.Visible = false;

            foreach (var activeRightImage in activeRightImages) activeRightImage.Visible = false;

            foreach (var activeTopImage in activeTopImages) activeTopImage.Visible = false;

            foreach (var activeBottomImage in activeBottomImages) activeBottomImage.Visible = false;
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
            if (SourceGiant && direction.X <= 0f) return false;

            if (canActivate && crushDir != direction)
            {
                if (direction.X != 0f && !canMoveHorizontally) return false;

                return direction.Y != 0f && !canMoveVertically ? false : true;
            }

            return false;
        }

        private void Attack(Vector2 direction)
        {
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                ResolveSoundPath("event:/game/06_reflection/crushblock_activate"),
                Center);
            if (CurrentMoveLoopSource != null)
            {
                CurrentMoveLoopSource.Param("end", 1f);
                var sfx = CurrentMoveLoopSource;
                SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, 0.5f, delegate { sfx.RemoveSelf(); });
            }

            OwnedComponents.Add(currentMoveLoopSfx = new(engine));
            CurrentMoveLoopSource.Position =
                ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(new Vector2(Width, Height), 2f);
            if (((IOriginalGameplayProcess)engine).SaveContext.CurrentSave != null &&
                ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Name != null &&
                ((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.Name.StartsWith("FWAHAHA",
                    StringComparison.InvariantCultureIgnoreCase))
                CurrentMoveLoopSource.Play("event:/game/06_reflection/crushblock_move_loop_covert");
            else
                CurrentMoveLoopSource.Play(ResolveSoundPath("event:/game/06_reflection/crushblock_move_loop"));

            SourceFace.Play("hit");
            crushDir = direction;
            canActivate = false;
            attackCoroutine.Replace(AttackSequence());
            ClearRemainder();
            TurnOffImages();
            ActivateParticles(crushDir);
            if (crushDir.X < 0f)
            {
                foreach (var activeLeftImage in activeLeftImages) activeLeftImage.Visible = true;

                nextFaceDirection = "left";
            }
            else if (crushDir.X > 0f)
            {
                foreach (var activeRightImage in activeRightImages) activeRightImage.Visible = true;

                nextFaceDirection = "right";
            }
            else if (crushDir.Y < 0f)
            {
                foreach (var activeTopImage in activeTopImages) activeTopImage.Visible = true;

                nextFaceDirection = "up";
            }
            else if (crushDir.Y > 0f)
            {
                foreach (var activeBottomImage in activeBottomImages) activeBottomImage.Visible = true;

                nextFaceDirection = "down";
            }

            var flag = true;
            if (returnStack.Count > 0)
            {
                var moveState = returnStack[returnStack.Count - 1];
                if (moveState.Direction == direction || moveState.Direction == SourceVector2Math.Negate(direction))
                    flag = false;
            }

            if (flag) returnStack.Add(new(Position, crushDir));
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
                position = SourceVector2Math.Subtract(CenterRight, Vector2.UnitX);
                positionRange =
                    SourceVector2Math.Multiply(SourceVector2Math.Multiply(Vector2.UnitY, Height - 2f), 0.5f);
                num = (int)(Height / 8f) * 4;
            }
            else if (dir == SourceVector2Math.Negate(Vector2.UnitX))
            {
                direction = (float)Math.PI;
                position = SourceVector2Math.Add(CenterLeft, Vector2.UnitX);
                positionRange =
                    SourceVector2Math.Multiply(SourceVector2Math.Multiply(Vector2.UnitY, Height - 2f), 0.5f);
                num = (int)(Height / 8f) * 4;
            }
            else if (dir == Vector2.UnitY)
            {
                direction = (float)Math.PI / 2f;
                position = SourceVector2Math.Subtract(BottomCenter, Vector2.UnitY);
                positionRange =
                    SourceVector2Math.Multiply(SourceVector2Math.Multiply(Vector2.UnitX, Width - 2f), 0.5f);
                num = (int)(Width / 8f) * 4;
            }
            else
            {
                direction = -(float)Math.PI / 2f;
                position = SourceVector2Math.Add(TopCenter, Vector2.UnitY);
                positionRange =
                    SourceVector2Math.Multiply(SourceVector2Math.Multiply(Vector2.UnitX, Width - 2f), 0.5f);
                num = (int)(Width / 8f) * 4;
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
            if (!chillOut) canActivate = true;

            StopPlayerRunIntoAnimation = false;
            var slowing = false;
            var speed = 0f;
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
                            SourceFace.Play("hurt");
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

                var flag = crushDir.X == 0f
                    ? MoveVCheck(speed * crushDir.Y * engine.DeltaTime)
                    : MoveHCheck(speed * crushDir.X * engine.DeltaTime);
                if (Top >= level.Bounds.Bottom + 32)
                {
                    RemoveSelf();
                    yield break;
                }

                if (flag) break;

                if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.02f, engine))
                {
                    Vector2 position;
                    float direction;
                    if (crushDir == Vector2.UnitX)
                    {
                        position = new(Left + 1f,
                            SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, Top + 3f,
                                Bottom - 3f));
                        direction = (float)Math.PI;
                    }
                    else if (crushDir == SourceVector2Math.Negate(Vector2.UnitX))
                    {
                        position = new(Right - 1f,
                            SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, Top + 3f,
                                Bottom - 3f));
                        direction = 0f;
                    }
                    else if (crushDir == Vector2.UnitY)
                    {
                        position = new(
                            SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, Left + 3f,
                                Right - 3f), Top + 1f);
                        direction = -(float)Math.PI / 2f;
                    }
                    else
                    {
                        position = new(
                            SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, Left + 3f,
                                Right - 3f), Bottom - 1f);
                        direction = (float)Math.PI / 2f;
                    }

                    level.Particles.Emit(P_Crushing, position, direction);
                }

                yield return null;
            }

            var fallingBlock =
                SourceTrackedEntityCollision.FirstAt<OriginalFallingBlockState>(Tracker, "Celeste.FallingBlock", this,
                    SourceVector2Math.Add(Position, crushDir));
            if (fallingBlock != null) fallingBlock.Triggered = true;

            if (crushDir == SourceVector2Math.Negate(Vector2.UnitX))
            {
                var vector = new Vector2(0f, 2f);
                for (var num = 0; num < Height / 8f; num++)
                {
                    var vector2 = new Vector2(Left - 1f, Top + 4f + num * 8);
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
                var vector3 = new Vector2(0f, 2f);
                for (var num2 = 0; num2 < Height / 8f; num2++)
                {
                    var vector4 = new Vector2(Right + 1f, Top + 4f + num2 * 8);
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
                var vector5 = new Vector2(2f, 0f);
                for (var num3 = 0; num3 < Width / 8f; num3++)
                {
                    var vector6 = new Vector2(Left + 4f + num3 * 8, Top - 1f);
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
                var vector7 = new Vector2(2f, 0f);
                for (var num4 = 0; num4 < Width / 8f; num4++)
                {
                    var vector8 = new Vector2(Left + 4f + num4 * 8, Bottom + 1f);
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
                Center);
            level.DirectionalShake(crushDir);
            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Medium,
                RumbleLength.Medium);
            StartShaking(0.4f);
            StopPlayerRunIntoAnimation = true;
            var sfx = CurrentMoveLoopSource;
            CurrentMoveLoopSource.Param("end", 1f);
            currentMoveLoopSfx = null;
            SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, 0.5f, delegate { sfx.RemoveSelf(); });
            crushDir = Vector2.Zero;
            TurnOffImages();
            if (chillOut) yield break;

            SourceFace.Play("hurt");
            ReturnMoveLoopSource.Play(ResolveSoundPath("event:/game/06_reflection/crushblock_return_loop"));
            yield return 0.4f;
            speed = 0f;
            var waypointSfxDelay = 0f;
            while (returnStack.Count > 0)
            {
                yield return null;
                StopPlayerRunIntoAnimation = false;
                var moveState = returnStack[returnStack.Count - 1];
                speed = ScalarMath.Approach(speed, 60f, 160f * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                waypointSfxDelay -= engine.DeltaTime;
                if (moveState.Direction.X != 0f) MoveTowardsX(moveState.From.X, speed * engine.DeltaTime);

                if (moveState.Direction.Y != 0f) MoveTowardsY(moveState.From.Y, speed * engine.DeltaTime);

                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if ((moveState.Direction.X != 0f && ExactPosition.X != moveState.From.X) ||
                    (moveState.Direction.Y != 0f && /* ReSharper disable once CompareOfFloatsByEqualityOperator */
                     ExactPosition.Y != moveState.From.Y))
                    continue;

                speed = 0f;
                returnStack.RemoveAt(returnStack.Count - 1);
                StopPlayerRunIntoAnimation = true;
                if (returnStack.Count <= 0)
                {
                    SourceFace.Play("idle");
                    ReturnMoveLoopSource.Stop();
                    if (waypointSfxDelay <= 0f)
                        ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                            ResolveSoundPath("event:/game/06_reflection/crushblock_rest"), Center);
                }
                else if (waypointSfxDelay <= 0f)
                {
                    ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                        ResolveSoundPath("event:/game/06_reflection/crushblock_rest_waypoint"), Center);
                }

                waypointSfxDelay = 0.1f;
                StartShaking(0.2f);
                yield return 0.2f;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool MoveHCheck(float amount)
        {
            return CrushingSolidMotion.CheckHorizontal(this, level, amount,
                CrushingCollisionCallback);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool MoveVCheck(float amount)
        {
            return CrushingSolidMotion
                .CheckVertical(this, level, amount, false, CrushingCollisionCallback);
        }
    }
}
