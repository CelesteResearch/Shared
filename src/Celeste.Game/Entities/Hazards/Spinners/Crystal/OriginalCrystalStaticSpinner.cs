using Celeste.Core.Display;
using Celeste.Game.Profiles;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Collision;
using Celeste.Simulation.Gameplay.Collision.Blockers;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Simulation.Gameplay.Hazards;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Crystal;
using Celeste.Simulation.Gameplay.Effects.Debris;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Game.Entities.Hazards.Spinners.Crystal
{
    public class OriginalCrystalStaticSpinner : SceneEntityState, IDestructibleHazard, ISourceEngineContextEntity
    {
        private class CoreModeListener : SourceComponentState, ISourceEngineContextEntity
        {
            public OriginalCrystalStaticSpinner Parent;
            ISourceEngineContext ISourceEngineContextEntity.EngineContext => Parent.engine;

            public CoreModeListener(OriginalCrystalStaticSpinner parent)
                : base(active: true, visible: false)
            {
                Parent = parent;
            }

            public override void Update()
            {
                OriginalLevelSceneRoot level = base.Scene as OriginalLevelSceneRoot;
                if ((Parent.color == CrystalSpinnerColor.Blue && level.CoreMode == RoomCoreMode.Hot) ||
                    (Parent.color == CrystalSpinnerColor.Red && level.CoreMode == RoomCoreMode.Cold))
                {
                    if (Parent.color == CrystalSpinnerColor.Blue)
                    {
                        Parent.color = CrystalSpinnerColor.Red;
                    }
                    else
                    {
                        Parent.color = CrystalSpinnerColor.Blue;
                    }

                    Parent.ClearSprites();
                    Parent.CreateSprites();
                }
            }
        }

        private class Border : SceneEntityState
        {
            private SceneEntityState[] drawing = new SceneEntityState[2];

            private readonly PackedColor color;

            public Border(SceneEntityState parent, SceneEntityState filler, ISourceEngineContext engine,
                PackedColor color)
                : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
            {
                this.color = color;
                PresentationOwner = parent;
                drawing[0] = parent;
                drawing[1] = filler;
                base.Depth = parent.Depth + 2;
            }

            public override void Render(ISourceRenderContext context)
            {
                if (drawing[0].Visible)
                {
                    DrawBorder(drawing[0], context);
                    DrawBorder(drawing[1], context);
                }
            }

            private void DrawBorder(SceneEntityState entity, ISourceRenderContext context)
            {
                Celeste.Game.Entities.Hazards.Rendering.StaticHazardBorderState.DrawImages(entity, context, this.color);
            }
        }

        public static ParticleTypePresentation P_Move;

        public const float ParticleInterval = 0.02f;

        private static Dictionary<CrystalSpinnerColor, string> fgTextureLookup =
            new Dictionary<CrystalSpinnerColor, string>
            {
                {
                    CrystalSpinnerColor.Blue,
                    "danger/crystal/fg_blue"
                },
                {
                    CrystalSpinnerColor.Red,
                    "danger/crystal/fg_red"
                },
                {
                    CrystalSpinnerColor.Purple,
                    "danger/crystal/fg_purple"
                },
                {
                    CrystalSpinnerColor.Rainbow,
                    "danger/crystal/fg_white"
                }
            };

        private static Dictionary<CrystalSpinnerColor, string> bgTextureLookup =
            new Dictionary<CrystalSpinnerColor, string>
            {
                {
                    CrystalSpinnerColor.Blue,
                    "danger/crystal/bg_blue"
                },
                {
                    CrystalSpinnerColor.Red,
                    "danger/crystal/bg_red"
                },
                {
                    CrystalSpinnerColor.Purple,
                    "danger/crystal/bg_purple"
                },
                {
                    CrystalSpinnerColor.Rainbow,
                    "danger/crystal/bg_white"
                }
            };

        public bool AttachToSolid;

        protected SceneEntityState filler;

        private Border border;

        protected float offset;
        protected readonly ISourceEngineContext engine;
        public int ID;
        protected ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;
        protected ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
        protected OriginalLevelSceneRoot Level => Scene as OriginalLevelSceneRoot;

        protected bool expanded;

        protected int randomSeed;

        private CrystalSpinnerColor color;

        public OriginalCrystalStaticSpinner(Vector2 position, bool attachToSolid, CrystalSpinnerColor color,
            ISourceEngineContext engine)
            : this(position, attachToSolid, color, engine,
                SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random))
        {
        }

        protected OriginalCrystalStaticSpinner(Vector2 position, bool attachToSolid, CrystalSpinnerColor color,
            ISourceEngineContext engine, float sourceOffset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            offset = sourceOffset;
            this.engine = engine;
            this.color = color;
            Tags = OriginalSceneTags.TransitionUpdate;
            Collider = new ColliderListGeometry(
                new CircleColliderGeometry(((ISourceVectorEnvironment)engine).VectorArithmetic, 6f),
                new HitboxColliderGeometry(16f, 4f, -8f, -3f));
            Visible = false;
            Add(new PlayerColliderComponentState(OnPlayer));
            Add(new HoldableColliderState(OnHoldable));
            Add(new LedgeBlockerState());
            Depth = -8500;
            AttachToSolid = attachToSolid;
            if (attachToSolid)
                Add(new SourceStaticMoverState { OnShake = OnShake, SolidChecker = IsRiding, OnDestroy = RemoveSelf });
            randomSeed = Random.Next();
        }

        public OriginalCrystalStaticSpinner(EntityData data, Vector2 offset, CrystalSpinnerColor color,
            ISourceEngineContext engine)
            : this(data.Position + offset, EntityAttributeReader.Bool(data.Values, "attachToSolid", false), color,
                engine)
        {
            if (((IGameProfileEnvironment)engine).SourceProfile ==
                GameProfile.InstalledEverest) ID = data.ID;
        }

        public override void Awake(object scene)
        {
            if (EnableCoreModeListener && ((IGameProfileEnvironment)engine).SourceProfile ==
                GameProfile.InstalledEverest && (int)color == -1)
            {
                Add(new CoreModeListener(this));
                color = (scene as OriginalLevelSceneRoot).CoreMode == RoomCoreMode.Cold
                    ? CrystalSpinnerColor.Blue
                    : CrystalSpinnerColor.Red;
            }

            base.Awake(scene);
            if (EnableCoreModeListener && (scene as OriginalLevelSceneRoot).Session.AreaID == 9)
            {
                Add(new CoreModeListener(this));
                if ((scene as OriginalLevelSceneRoot).CoreMode == RoomCoreMode.Cold)
                {
                    color = CrystalSpinnerColor.Blue;
                }
                else
                {
                    color = CrystalSpinnerColor.Red;
                }
            }

            if (InView())
            {
                CreateSprites();
            }
        }

        public void ForceInstantiate()
        {
            CreateSprites();
            Visible = true;
        }

        public override void Update()
        {
            if (!ShouldShow)
            {
                Visible = Collidable = false;
            }
            else if (!Visible)
            {
                Collidable = false;
                if (InView())
                {
                    Visible = true;
                    if (!expanded)
                    {
                        CreateSprites();
                    }

                    if (IsRainbow)
                    {
                        UpdateHue();
                    }
                }
            }
            else
            {
                UpdateComponents();
                if (ShouldUpdateHue)
                {
                    UpdateHue();
                }

                if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.25f, offset, engine) && !InView())
                {
                    Visible = false;
                }

                if (Collider != null && ((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.05f, offset, engine))
                {
                    RoomPlayerSession entity =
                        ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                            typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                    if (entity != null)
                    {
                        Collidable = Math.Abs(entity.Position.X - Position.X) < 128f &&
                                     Math.Abs(entity.Position.Y - Position.Y) < 128f;
                    }
                }

                AfterSpinnerUpdate();
            }

            if (filler != null)
            {
                filler.Position = Position;
            }
        }

        public CrystalSpinnerColor SpinnerColor => color;

        protected void UpdateComponents() => base.Update();

        protected virtual bool EnableCoreModeListener => true;
        protected virtual bool ShouldShow => true;
        protected virtual bool IsRainbow => color == CrystalSpinnerColor.Rainbow;

        protected virtual bool ShouldUpdateHue => IsRainbow &&
                                                  ((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.08f, offset,
                                                      engine);

        protected virtual void AfterSpinnerUpdate()
        {
        }

        protected void CreateBorder(PackedColor color)
            => ((ISourceScene)Scene).SourceScene.QueueSourceEntity(border = new Border(this, filler, engine, color));

        public virtual void UpdateHue()
        {
            foreach (SourceComponentState component in base.Components)
            {
                if (component is SpriteImage image)
                {
                    image.Color = GetHue(Position + image.Position);
                }
            }

            if (filler == null)
            {
                return;
            }

            foreach (SourceComponentState component2 in filler.Components)
            {
                if (component2 is SpriteImage image2)
                {
                    image2.Color = GetHue(Position + image2.Position);
                }
            }
        }

        protected virtual bool InView()
        {
            var camera = Level.Camera;
            if (Position.X > camera.X - 16f && Position.Y > camera.Y - 16f && Position.X < camera.X + 320f + 16f)
            {
                return Position.Y < camera.Y + 180f + 16f;
            }

            return false;
        }

        protected virtual void CreateSprites()
        {
            if (expanded)
            {
                return;
            }

            ((ISourceRandomProcessEnvironment)engine).RandomProcess.PushRandom(randomSeed);
            List<AtlasEntry> atlasSubtextures =
                ((global::Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas
                .GetAtlasSubtextures(fgTextureLookup[this.color]);
            AtlasEntry mTexture = Random.Choose(atlasSubtextures);
            PackedColor color = PackedColor.White;
            if (this.color == CrystalSpinnerColor.Rainbow)
            {
                color = GetHue(Position);
            }

            if (!SolidCheck(new Vector2(Position.X - 4f, Position.Y - 4f)))
            {
                Add(CreateImage(mTexture.GetSubtexture(0, 0, 14, 14), 12f, 12f, color));
            }

            if (!SolidCheck(new Vector2(Position.X + 4f, Position.Y - 4f)))
            {
                Add(CreateImage(mTexture.GetSubtexture(10, 0, 14, 14), 2f, 12f, color));
            }

            if (!SolidCheck(new Vector2(Position.X + 4f, Position.Y + 4f)))
            {
                Add(CreateImage(mTexture.GetSubtexture(10, 10, 14, 14), 2f, 2f, color));
            }

            if (!SolidCheck(new Vector2(Position.X - 4f, Position.Y + 4f)))
            {
                Add(CreateImage(mTexture.GetSubtexture(0, 10, 14, 14), 12f, 2f, color));
            }

            foreach (object actual in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.CrystalStaticSpinner"))
            {
                var entity = (OriginalCrystalStaticSpinner)actual;
                {
                    if (entity != this && entity.AttachToSolid == AttachToSolid && entity.Position.X >= Position.X &&
                        VectorArithmetic.Length(entity.Position - Position) < 24f)
                    {
                        AddSprite(VectorArithmetic.Divide(Position + entity.Position, 2f) - Position);
                    }
                }
            }

            CreateBorder(PackedColor.Black);
            expanded = true;
            ((ISourceRandomProcessEnvironment)engine).RandomProcess.PopRandom();
        }

        private void AddSprite(Vector2 offset)
        {
            if (filler == null)
            {
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(filler =
                    new SceneEntityState(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                        Position) { PresentationOwner = this });
                filler.Depth = base.Depth + 1;
            }

            List<AtlasEntry> atlasSubtextures =
                ((global::Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas
                .GetAtlasSubtextures(bgTextureLookup[color]);
            SpriteImage image = new SpriteImage(Random.Choose(atlasSubtextures));
            image.Position = offset;
            image.Rotation = (float)Random.Choose(0, 1, 2, 3) * ((float)Math.PI / 2f);
            image.CenterOrigin();
            if (color == CrystalSpinnerColor.Rainbow)
            {
                image.Color = GetHue(Position + offset);
            }

            filler.Add(image);
        }

        protected bool SolidCheck(Vector2 position)
        {
            if (AttachToSolid)
            {
                return false;
            }

            foreach (SourceSolidEntityState item in SourceSceneCollision.AllPoint<SourceSolidEntityState>(
                         ((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid", position))
            {
                if (item is ISourceSolidTilesEntity)
                {
                    return true;
                }
            }

            return false;
        }

        protected void ClearSprites()
        {
            if (filler != null)
            {
                filler.RemoveSelf();
            }

            filler = null;
            if (border != null)
            {
                border.RemoveSelf();
            }

            border = null;
            foreach (SpriteImage item in Components.GetAll<SpriteImage>())
            {
                item.RemoveSelf();
            }

            expanded = false;
        }

        private void OnShake(Vector2 pos)
        {
            foreach (SourceComponentState component in base.Components)
            {
                if (component is SpriteImage)
                {
                    (component as SpriteImage).Position = pos;
                }
            }
        }

        private bool IsRiding(SourceSolidEntityState solid)
        {
            return SourceEntityCollision.Check(this, solid);
        }

        protected virtual void OnPlayer(RoomPlayerSession player)
        {
            player.Die(VectorArithmetic.SafeNormalize(player.Position - Position));
        }

        protected virtual void OnHoldable(HoldableState h)
        {
            h.HitSpinner(this);
        }

        public override void Removed(object scene)
        {
            if (filler != null && filler.Scene == scene)
            {
                filler.RemoveSelf();
            }

            if (border != null && border.Scene == scene)
            {
                border.RemoveSelf();
            }

            base.Removed(scene);
        }

        public virtual void Destroy(bool boss = false)
        {
            if (InView())
            {
                ((Celeste.Core.Audio.ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                    "event:/game/06_reflection/fall_spike_smash", Position);
                PackedColor color = PackedColor.White;
                if (this.color == CrystalSpinnerColor.Red)
                {
                    color = PackedColor.FromHex("ff4f4f");
                }
                else if (this.color == CrystalSpinnerColor.Blue)
                {
                    color = PackedColor.FromHex("639bff");
                }
                else if (this.color == CrystalSpinnerColor.Purple)
                {
                    color = PackedColor.FromHex("ff4fef");
                }

                CrystalDebrisState.Burst(engine, Position, color, boss, 8);
            }

            RemoveSelf();
        }

        public virtual PackedColor GetHue(Vector2 position)
        {
            float num = 280f;
            float value =
                (VectorArithmetic.Length(position) + ((ISourceScene)Scene).SourceScene.Clock.TimeActive * 50f) %
                num / num;
            return ColorMath.HsvToPackedColor(0.4f + ScalarMath.YoYo(value) * 0.4f, 0.4f, 0.9f);
        }

        void IDestructibleHazard.Destroy() => Destroy();
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => engine;

        private static SpriteImage CreateImage(AtlasEntry texture, float x, float y, PackedColor color)
        {
            var image = new SpriteImage(texture).SetOrigin(x, y);
            image.Color = color;
            return image;
        }
    }
}
