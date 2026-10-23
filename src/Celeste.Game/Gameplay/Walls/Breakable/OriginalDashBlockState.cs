using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Audio.Surfaces;
using Celeste.Game.Execution.Engine.Actions;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Presentation.Walls.Breakable;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Surfaces;
using Celeste.Simulation.Gameplay.Walls.Breakable;

namespace Celeste.Game.Gameplay.Walls.Breakable
{
    public class OriginalDashBlockState : SourceSolidEntityState, IBreakableWallEntity
    {
        public enum Modes
        {
            Dash,
            FinalBoss,
            Crusher,
        }

        private readonly bool permanent;

        private readonly MapEntityId id;

        private char tileType;

        private float width;

        private float height;

        private readonly bool blendIn;

        public bool CanDash { get; }

        public OriginalDashBlockState(Vector2 position, char tiletype, float width, float height, bool blendIn,
            bool permanent, bool canDash, MapEntityId id, ISourceSolidWorldFactory worlds)
            : base(position, width, height, true, worlds.Create(position, true))
        {
            Depth = -12999;
            this.id = id;
            this.permanent = permanent;
            this.width = width;
            this.height = height;
            this.blendIn = blendIn;
            CanDash = canDash;
            tileType = tiletype;
            OnDashCollide = OnDashed;
            SurfaceSoundIndex =
                ((IOriginalTileSurfaceEnvironment)SourceWorld.EngineContext).SurfaceIndices.TileToIndex[tileType];
        }

        public OriginalDashBlockState(EntityData data, Vector2 offset, MapEntityId id,
            ISourceSolidWorldFactory worlds)
            : this(data.Position + offset, EntityAttributeReader.Char(data.Values, "tiletype", '3'), data.Width,
                data.Height, EntityAttributeReader.Bool(data.Values, "blendin"),
                EntityAttributeReader.Bool(data.Values, "permanent", true),
                EntityAttributeReader.Bool(data.Values, "canDash", true), id, worlds)
        {
        }

        protected void AwakeSolid(object scene)
        {
            base.Awake(scene);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            BreakableTileBlockVisuals.AddTiles(this, SourceWorld,
                ref tileType, blendIn, ref width, ref height);
            if (SourceTrackedEntityCollision.Check(((ISourceScene)Scene).SourceScene.Entities,
                    typeof(RoomPlayerSession).FullName, this))
                RemoveSelf();
        }

        public override void Removed(object scene)
        {
            base.Removed(scene);
            OriginalCelesteFreeze.Freeze(SourceWorld.EngineContext, 0.05f);
        }

        public virtual void Break(Vector2 from, Vector2 direction, bool playSound = true, bool playDebrisSound = true)
        {
            if (playSound)
                BreakableTileBlockEffects.PlayBreakSound(SourceWorld,
                    tileType, this);
            BreakableTileBlockEffects.EmitDebris(this, SourceWorld,
                ref tileType, playDebrisSound, from);

            Collidable = false;
            if (permanent)
                RemoveAndFlagAsGone();
            else
                RemoveSelf();
        }

        public void RemoveAndFlagAsGone()
        {
            RemoveSelf();
            ((OriginalLevelSceneRoot)Scene).Session.DoNotLoad.Add(id);
        }

        private DashCollisionResult OnDashed(RoomPlayerSession player, Vector2 direction)
        {
            if (!CanDash && player.Machine.State != 5 && player.Machine.State != 10)
                return DashCollisionResult.NormalCollision;

            Break(player.Center, direction);
            return DashCollisionResult.Rebound;
        }
    }
}
