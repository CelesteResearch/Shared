using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Hazards.Spikes;
using Celeste.Game.Gameplay.Holdables.TheoCrystal;
using Celeste.Game.Gameplay.Interaction.Springs;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Cassette;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;

namespace Celeste.Game.Gameplay.Platforms.Cassette
{
    public class CassetteBlockState : SourceSolidEntityState, ICassetteRhythmBlock
    {
        int ICassetteRhythmBlock.Index => Index;
        string ICassetteRhythmBlock.Room => ID.Level;

        bool ICassetteRhythmBlock.Activated
        {
            get => Activated;
            set => Activated = value;
        }

        private AtlasData GameAtlas =>
            ((ISourceGameGraphicsEnvironment)SourceWorld.EngineContext).GameGraphics.GameAtlas;

        public enum Modes
        {
            Solid,
            Leaving,
            Disabled,
            Returning
        }

        public int Index;

        public float Tempo;

        public bool Activated;

        public Modes Mode;

        public MapEntityId ID;

        protected internal int blockHeight = 2;

        protected List<CassetteBlockState> group;

        protected bool groupLeader;

        protected Vector2 groupOrigin;

        protected PackedColor color;
        public PackedColor Color => color;

        protected List<SpriteImage> pressed = new List<SpriteImage>();

        protected List<SpriteImage> solid = new List<SpriteImage>();

        protected List<SpriteImage> all = new List<SpriteImage>();

        private LightOccludeState occluder;

        private WigglerComponent wiggler;

        private Vector2 wigglerScaler;

        protected CassetteBlockBoxSideState side;

        public CassetteBlockState(global::Celeste.Formats.Map.Entities.Structure.EntityData data,
            Vector2 offset, MapEntityId id, ISourceSolidWorldFactory worlds)
            : this(data.Position + offset, id, data.Width, data.Height,
                global::Celeste.Formats.Map.Entities.Attributes.EntityAttributeReader.Int(data.Values, "index"),
                global::Celeste.Formats.Map.Entities.Attributes.EntityAttributeReader.Float(data.Values, "tempo",
                    1f),
                worlds.Create(data.Position + offset, false))
        {
        }

        public CassetteBlockState(Vector2 position, MapEntityId id, float width, float height, int index, float tempo,
            ISourceSolidWorld world)
            : base(position, width, height, false, world)
        {
            SurfaceSoundIndex = 35;
            Index = index;
            Tempo = tempo;
            Collidable = false;
            ID = id;
            switch (Index)
            {
                default:
                    color = new PackedColor(73, 170, 240, 255);
                    break;
                case 1:
                    color = new PackedColor(240, 73, 190, 255);
                    break;
                case 2:
                    color = new PackedColor(252, 220, 58, 255);
                    break;
                case 3:
                    color = new PackedColor(56, 224, 78, 255);
                    break;
            }

            occluder = new LightOccludeState();
            OwnedComponents.Add(occluder);
        }

        private readonly struct AutotileBounds : global::Celeste.Graphics.Geometry.Tiling.IConnectedBlockBounds
        {
            private readonly CassetteBlockState block;
            public float Left => block.Left;
            public float Right => block.Right;
            public float Top => block.Top;
            public float Bottom => block.Bottom;
            public AutotileBounds(CassetteBlockState block) => this.block = block;
        }

        protected virtual bool ShouldQueueBoxSide => true;

        public override void Awake(object scene)
        {
            var diagnostics = global::Celeste.Core.Framework.Timing.SourceFrameDiagnostics.Current;
            long started = 0;
            bool measuring = diagnostics?.BeginLoadGroupAwake(out started) ?? false;
            try
            {
                base.Awake(scene);
                PackedColor color = new PackedColor(102, 125, 165, 255);
                PackedColor disabledColor = new PackedColor(
                    (float)(int)color.R / 255f * ((float)(int)this.color.R / 255f),
                    (float)(int)color.G / 255f * ((float)(int)this.color.G / 255f),
                    (float)(int)color.B / 255f * ((float)(int)this.color.B / 255f), 1f);
                side = new CassetteBlockBoxSideState(this, disabledColor,
                    ((ISourceEntitySourceDataEnvironment)SourceWorld.EngineContext).EntitySourceDataRegistration);
                if (ShouldQueueBoxSide) ((ISourceScene)scene).SourceScene.QueueSourceEntity(side);
                foreach (SourceStaticMoverState staticMover in staticMovers)
                {
                    if (staticMover.Entity is SpikesState spikes)
                    {
                        spikes.EnabledColor = this.color;
                        spikes.DisabledColor = disabledColor;
                        spikes.VisibleWhenDisabled = true;
                        spikes.SetSpikeColor(this.color);
                    }

                    if (staticMover.Entity is OriginalSpringState spring)
                    {
                        spring.DisabledColor = disabledColor;
                        spring.VisibleWhenDisabled = true;
                    }
                }

                if (group == null)
                {
                    groupLeader = true;
                    group = new List<CassetteBlockState>();
                    group.Add(this);
                    FindInGroup(this);
                    float num = float.MaxValue;
                    float num2 = float.MinValue;
                    float num3 = float.MaxValue;
                    float num4 = float.MinValue;
                    foreach (CassetteBlockState item in group)
                    {
                        if (item.Left < num)
                        {
                            num = item.Left;
                        }

                        if (item.Right > num2)
                        {
                            num2 = item.Right;
                        }

                        if (item.Bottom > num4)
                        {
                            num4 = item.Bottom;
                        }

                        if (item.Top < num3)
                        {
                            num3 = item.Top;
                        }
                    }

                    groupOrigin = new Vector2((int)(num + (num2 - num) / 2f), (int)num4);
                    wigglerScaler = new Vector2(ScalarMath.ClampedMap(num2 - num, 32f, 96f, 1f, 0.2f),
                        ScalarMath.ClampedMap(num4 - num3, 32f, 96f, 1f, 0.2f));
                    wiggler = ((ISourceWigglerPoolScope)SourceWorld.EngineContext).WigglerPool.Create(0.3f, 3f);
                    OwnedComponents.Add(wiggler);
                    foreach (CassetteBlockState item2 in group)
                    {
                        item2.wiggler = wiggler;
                        item2.wigglerScaler = wigglerScaler;
                        item2.groupOrigin = groupOrigin;
                    }
                }

                foreach (SourceStaticMoverState staticMover2 in staticMovers)
                {
                    if (staticMover2.Entity is SpikesState spikes2)
                    {
                        spikes2.SetOrigins(groupOrigin);
                    }
                }

                global::Celeste.Graphics.Geometry.Tiling.ConnectedBlockAutotiling.Build(
                    new AutotileBounds(this), CheckForSame, SetImage);

                UpdateVisualState();
            }
            finally
            {
                if (measuring) diagnostics.EndLoadGroupAwake(started);
            }
        }

        protected void AssignGroupTo(CassetteBlockState block) => block.group = group;

        protected virtual void FindInGroup(CassetteBlockState block)
        {
            foreach (CassetteBlockState entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.CassetteBlock"))
            {
                if (entity != this && entity != block && entity.Index == Index &&
                    (SourceEntityGeometryCollision.Rectangle(entity,
                         new IntRect((int)block.X - 1, (int)block.Y, (int)block.Width + 2, (int)block.Height)) ||
                     SourceEntityGeometryCollision.Rectangle(entity,
                         new IntRect((int)block.X, (int)block.Y - 1, (int)block.Width, (int)block.Height + 2))) &&
                    !group.Contains(entity))
                {
                    group.Add(entity);
                    FindInGroup(entity);
                    entity.group = group;
                }
            }
        }

        protected virtual bool CheckForSame(float x, float y)
        {
            foreach (CassetteBlockState entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.CassetteBlock"))
            {
                if (entity.Index == Index &&
                    SourceEntityGeometryCollision.Rectangle(entity.Collider, new IntRect((int)x, (int)y, 8, 8)))
                {
                    return true;
                }
            }

            return false;
        }

        protected virtual void SetImage(float x, float y, int tx, int ty)
        {
            List<AtlasEntry> atlasSubtextures = GameAtlas.GetAtlasSubtextures("objects/cassetteblock/pressed");
            pressed.Add(CreateImage(x, y, tx, ty, atlasSubtextures[Index % atlasSubtextures.Count]));
            solid.Add(CreateImage(x, y, tx, ty, GameAtlas["objects/cassetteblock/solid"]));
        }

        protected SpriteImage CreateImage(float x, float y, int tx, int ty, AtlasEntry tex)
        {
            Vector2 vector = new Vector2(x - base.X, y - base.Y);
            SpriteImage image = new SpriteImage(tex.GetSubtexture(tx * 8, ty * 8, 8, 8));
            Vector2 vector2 = groupOrigin - Position;
            image.Origin = vector2 - vector;
            image.Position = vector2;
            image.Color = color;
            OwnedComponents.Add(image);
            all.Add(image);
            return image;
        }

        public override void Update()
        {
            base.Update();
            if (groupLeader && Activated && !Collidable)
            {
                bool flag = false;
                foreach (CassetteBlockState item in group)
                {
                    if (item.BlockedCheck())
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    foreach (CassetteBlockState item2 in group)
                    {
                        item2.Collidable = true;
                        item2.EnableStaticMovers();
                        item2.ShiftSize(-1);
                    }

                    wiggler.Start();
                }
            }
            else if (!Activated && Collidable)
            {
                ShiftSize(1);
                Collidable = false;
                DisableStaticMovers();
            }

            UpdateVisualState();
        }

        public bool BlockedCheck()
        {
            TheoCrystalState theoCrystal = CollideFirst<TheoCrystalState>("Celeste.TheoCrystal");
            if (theoCrystal != null && !TryActorWiggleUp(theoCrystal))
            {
                return true;
            }

            RoomPlayerSession player =
                CollideFirst<RoomPlayerSession>(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            if (player != null && !TryActorWiggleUp(player))
            {
                return true;
            }

            return false;
        }

        protected virtual void UpdateVisualState()
        {
            var diagnostics = global::Celeste.Core.Framework.Timing.SourceFrameDiagnostics.Current;
            long updateStarted = 0;
            bool measuringUpdate = diagnostics?.BeginCassetteBlockVisualUpdate(out updateStarted) ?? false;
            try
            {
                if (!Collidable)
                {
                    base.Depth = 8990;
                }
                else
                {
                    var players =
                        ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                            typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
                    RoomPlayerSession entity = players.Count > 0 ? players[0] as RoomPlayerSession : null;
                    if (entity != null && entity.Top >= base.Bottom - 1f)
                    {
                        base.Depth = 10;
                    }
                    else
                    {
                        base.Depth = -10;
                    }
                }

                foreach (SourceStaticMoverState staticMover in staticMovers)
                {
                    ((SceneEntityState)staticMover.Entity).Depth = base.Depth + 1;
                }

                side.Depth = base.Depth + 5;
                side.Visible = blockHeight > 0;
                occluder.Visible = Collidable;
                foreach (SpriteImage item in solid)
                {
                    item.Visible = Collidable;
                }

                foreach (SpriteImage item2 in pressed)
                {
                    item2.Visible = !Collidable;
                }

                if (!groupLeader)
                {
                    return;
                }

                Vector2 scale = new Vector2(1f + wiggler.Value * 0.05f * wigglerScaler.X,
                    1f + wiggler.Value * 0.15f * wigglerScaler.Y);
                foreach (CassetteBlockState item3 in group)
                {
                    foreach (SpriteImage item4 in item3.all)
                    {
                        item4.Scale = scale;
                    }

                    foreach (SourceStaticMoverState staticMover2 in item3.staticMovers)
                    {
                        if (!(staticMover2.Entity is SpikesState spikes))
                        {
                            continue;
                        }

                        var components = spikes.Components.GetValueEnumerator();
                        try
                        {
                            while (components.MoveNext())
                            {
                                if (components.Current is SpriteImage image)
                                {
                                    image.Scale = scale;
                                }
                            }
                        }
                        finally
                        {
                            components.Dispose();
                        }
                    }
                }
            }
            finally
            {
                if (measuringUpdate) diagnostics.EndCassetteBlockVisualUpdate(updateStarted);
            }
        }

        public void SetActivatedSilently(bool activated)
        {
            Activated = (Collidable = activated);
            UpdateVisualState();
            if (activated)
            {
                EnableStaticMovers();
                return;
            }

            ShiftSize(2);
            DisableStaticMovers();
        }

        public void Finish()
        {
            Activated = false;
        }

        public void WillToggle()
        {
            ShiftSize(Collidable ? 1 : (-1));
            UpdateVisualState();
        }

        protected virtual void ShiftSize(int amount)
        {
            MoveV(amount);
            blockHeight -= amount;
        }

        private bool TryActorWiggleUp(ISourceEntityCollider actor)
        {
            foreach (CassetteBlockState item in group)
            {
                if (item != this && SourceEntityCollision.CheckAt(item, actor, item.Position + Vector2.UnitY * 4f))
                {
                    return false;
                }
            }

            bool collidable = Collidable;
            Collidable = true;
            for (int i = 1; i <= 4; i++)
            {
                if (!SourceTrackedEntityCollision.CheckAt(
                        ((ISourceScene)((ISceneEntityAssociation)actor).Scene).SourceScene.Entities, "Celeste.Solid",
                        actor,
                        actor.Position - Vector2.UnitY * i))
                {
                    ((ISourceMutableEntityPosition)actor).Position -= Vector2.UnitY * i;
                    Collidable = collidable;
                    return true;
                }
            }

            Collidable = collidable;
            return false;
        }
    }
}
