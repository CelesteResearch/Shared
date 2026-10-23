using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Framework.Timing;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Gameplay.Holdables.TheoCrystal;
using Celeste.Game.Gameplay.Interaction.Springs;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Geometry.Tiling;
using Celeste.Physics.Collision;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Hazards.Spikes;
using Celeste.Simulation.Gameplay.Platforms.Cassette;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Lighting;

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
            Returning,
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

        protected List<SpriteImage> pressed = [];

        protected List<SpriteImage> solid = [];

        protected List<SpriteImage> all = [];

        private readonly LightOccludeState occluder;

        private WigglerComponent wiggler;

        private Vector2 wigglerScaler;

        protected CassetteBlockBoxSideState side;

        public CassetteBlockState(EntityData data,
            Vector2 offset, MapEntityId id, ISourceSolidWorldFactory worlds)
            : this(data.Position + offset, id, data.Width, data.Height,
                EntityAttributeReader.Int(data.Values, "index"),
                EntityAttributeReader.Float(data.Values, "tempo",
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
                    color = new(73, 170, 240, 255);
                    break;
                case 1:
                    color = new(240, 73, 190, 255);
                    break;
                case 2:
                    color = new(252, 220, 58, 255);
                    break;
                case 3:
                    color = new(56, 224, 78, 255);
                    break;
            }

            occluder = new();
            OwnedComponents.Add(occluder);
        }

        private readonly struct AutotileBounds : IConnectedBlockBounds
        {
            private readonly CassetteBlockState block;
            public float Left => block.Left;
            public float Right => block.Right;
            public float Top => block.Top;
            public float Bottom => block.Bottom;

            public AutotileBounds(CassetteBlockState block)
            {
                this.block = block;
            }
        }

        protected virtual bool ShouldQueueBoxSide => true;

        public override void Awake(object scene)
        {
            var diagnostics = SourceFrameDiagnostics.Current;
            long started = 0;
            var measuring = diagnostics?.BeginLoadGroupAwake(out started) ?? false;
            try
            {
                base.Awake(scene);
                var color = new PackedColor(102, 125, 165, 255);
                var disabledColor = new PackedColor(
                    color.R / 255f * (this.color.R / 255f),
                    color.G / 255f * (this.color.G / 255f),
                    color.B / 255f * (this.color.B / 255f), 1f);
                side = new(this, disabledColor,
                    ((ISourceEntitySourceDataEnvironment)SourceWorld.EngineContext).EntitySourceDataRegistration);
                if (ShouldQueueBoxSide) ((ISourceScene)scene).SourceScene.QueueSourceEntity(side);
                foreach (var staticMover in staticMovers)
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
                    group = [];
                    // ReSharper disable once AppendToCollectionExpression
                    group.Add(this);
                    FindInGroup(this);
                    var num = float.MaxValue;
                    var num2 = float.MinValue;
                    var num3 = float.MaxValue;
                    var num4 = float.MinValue;
                    foreach (var item in group)
                    {
                        if (item.Left < num) num = item.Left;

                        if (item.Right > num2) num2 = item.Right;

                        if (item.Bottom > num4) num4 = item.Bottom;

                        if (item.Top < num3) num3 = item.Top;
                    }

                    groupOrigin = new((int)(num + (num2 - num) / 2f), (int)num4);
                    wigglerScaler = new(ScalarMath.ClampedMap(num2 - num, 32f, 96f, 1f, 0.2f),
                        ScalarMath.ClampedMap(num4 - num3, 32f, 96f, 1f, 0.2f));
                    wiggler = ((ISourceWigglerPoolScope)SourceWorld.EngineContext).WigglerPool.Create(0.3f, 3f);
                    OwnedComponents.Add(wiggler);
                    foreach (var item2 in group)
                    {
                        item2.wiggler = wiggler;
                        item2.wigglerScaler = wigglerScaler;
                        item2.groupOrigin = groupOrigin;
                    }
                }

                foreach (var staticMover2 in staticMovers)
                    if (staticMover2.Entity is SpikesState spikes2)
                        spikes2.SetOrigins(groupOrigin);

                ConnectedBlockAutotiling.Build(
                    new AutotileBounds(this), CheckForSame, SetImage);

                UpdateVisualState();
            }
            finally
            {
                if (measuring) diagnostics.EndLoadGroupAwake(started);
            }
        }

        protected void AssignGroupTo(CassetteBlockState block)
        {
            block.group = group;
        }

        protected virtual void FindInGroup(CassetteBlockState block)
        {
            foreach (CassetteBlockState entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.CassetteBlock"))
                if (entity != this && entity != block && entity.Index == Index &&
                    (SourceEntityGeometryCollision.Rectangle(entity,
                         new((int)block.X - 1, (int)block.Y, (int)block.Width + 2, (int)block.Height)) ||
                     SourceEntityGeometryCollision.Rectangle(entity,
                         new((int)block.X, (int)block.Y - 1, (int)block.Width, (int)block.Height + 2))) &&
                    !group.Contains(entity))
                {
                    group.Add(entity);
                    FindInGroup(entity);
                    entity.group = group;
                }
        }

        protected virtual bool CheckForSame(float x, float y)
        {
            foreach (CassetteBlockState entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.CassetteBlock"))
                if (entity.Index == Index &&
                    SourceEntityGeometryCollision.Rectangle(entity.Collider, new((int)x, (int)y, 8, 8)))
                    return true;

            return false;
        }

        protected virtual void SetImage(float x, float y, int tx, int ty)
        {
            var atlasSubtextures = GameAtlas.GetAtlasSubtextures("objects/cassetteblock/pressed");
            pressed.Add(CreateImage(x, y, tx, ty, atlasSubtextures[Index % atlasSubtextures.Count]));
            solid.Add(CreateImage(x, y, tx, ty, GameAtlas["objects/cassetteblock/solid"]));
        }

        protected SpriteImage CreateImage(float x, float y, int tx, int ty, AtlasEntry tex)
        {
            var vector = new Vector2(x - X, y - Y);
            var image = new SpriteImage(tex.GetSubtexture(tx * 8, ty * 8, 8, 8));
            var vector2 = groupOrigin - Position;
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
                var flag = false;
                foreach (var item in group)
                    if (item.BlockedCheck())
                    {
                        flag = true;
                        break;
                    }

                if (!flag)
                {
                    foreach (var item2 in group)
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
            var theoCrystal = CollideFirst<TheoCrystalState>("Celeste.TheoCrystal");
            if (theoCrystal != null && !TryActorWiggleUp(theoCrystal)) return true;

            var player =
                CollideFirst<RoomPlayerSession>(typeof(RoomPlayerSession).FullName);
            if (player != null && !TryActorWiggleUp(player)) return true;

            return false;
        }

        protected virtual void UpdateVisualState()
        {
            var diagnostics = SourceFrameDiagnostics.Current;
            long updateStarted = 0;
            var measuringUpdate = diagnostics?.BeginCassetteBlockVisualUpdate(out updateStarted) ?? false;
            try
            {
                if (!Collidable)
                {
                    Depth = 8990;
                }
                else
                {
                    var players =
                        ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                            typeof(RoomPlayerSession).FullName);
                    var entity = players.Count > 0 ? players[0] as RoomPlayerSession : null;
                    if (entity != null && entity.Top >= Bottom - 1f)
                        Depth = 10;
                    else
                        Depth = -10;
                }

                foreach (var staticMover in staticMovers) ((SceneEntityState)staticMover.Entity).Depth = Depth + 1;

                side.Depth = Depth + 5;
                side.Visible = blockHeight > 0;
                occluder.Visible = Collidable;
                foreach (var item in solid) item.Visible = Collidable;

                foreach (var item2 in pressed) item2.Visible = !Collidable;

                if (!groupLeader) return;

                var scale = new Vector2(1f + wiggler.Value * 0.05f * wigglerScaler.X,
                    1f + wiggler.Value * 0.15f * wigglerScaler.Y);
                foreach (var item3 in group)
                {
                    foreach (var item4 in item3.all) item4.Scale = scale;

                    foreach (var staticMover2 in item3.staticMovers)
                    {
                        if (!(staticMover2.Entity is SpikesState spikes)) continue;

                        var components = spikes.Components.GetValueEnumerator();
                        try
                        {
                            while (components.MoveNext())
                                if (components.Current is SpriteImage image)
                                    image.Scale = scale;
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
            Activated = Collidable = activated;
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
            ShiftSize(Collidable ? 1 : -1);
            UpdateVisualState();
        }

        protected virtual void ShiftSize(int amount)
        {
            MoveV(amount);
            blockHeight -= amount;
        }

        private bool TryActorWiggleUp(ISourceEntityCollider actor)
        {
            foreach (var item in group)
                if (item != this && SourceEntityCollision.CheckAt(item, actor, item.Position + Vector2.UnitY * 4f))
                    return false;

            var collidable = Collidable;
            Collidable = true;
            for (var i = 1; i <= 4; i++)
                if (!SourceTrackedEntityCollision.CheckAt(
                        ((ISourceScene)((ISceneEntityAssociation)actor).Scene).SourceScene.Entities, "Celeste.Solid",
                        actor,
                        actor.Position - Vector2.UnitY * i))
                {
                    ((ISourceMutableEntityPosition)actor).Position -= Vector2.UnitY * i;
                    Collidable = collidable;
                    return true;
                }

            Collidable = collidable;
            return false;
        }
    }
}
