using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Collections;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.FloatySpaceBlock;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Gameplay.Interaction.Springs;
using Celeste.Simulation.Gameplay.Player.Collision.Surfaces;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Game.Gameplay.Interaction.Springs;
using Celeste.Game.Audio.Surfaces;
using Celeste.Game.Execution.Graphics;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Tiles.Autotiling;
using Celeste.Graphics.Animation;

namespace Celeste.Game.Gameplay.Platforms.FloatySpaceBlocks
{
    public class FloatySpaceBlockState : SourceSolidEntityState
    {
        private readonly ISourceEngineContext engine;
        private TileGrid tiles;

        private char tileType;

        private float yLerp;

        private float sinkTimer;

        private float sineWave;

        private float dashEase;

        private Vector2 dashDirection;

        private FloatySpaceBlockState master;

        private bool awake;

        public List<FloatySpaceBlockState> Group;

        public List<SourceJumpThruEntityState> Jumpthrus;

        public Dictionary<SourcePlatformEntityState, Vector2> Moves;

        public IntPoint GroupBoundsMin;

        public IntPoint GroupBoundsMax;

        public bool HasGroup { get; private set; }

        public bool MasterOfGroup { get; private set; }

        public FloatySpaceBlockState(Vector2 position, float width, float height, char tileType,
            bool disableSpawnOffset,
            ISourceSolidWorld world)
            : base(position, width, height, true, world)
        {
            engine = world.EngineContext;
            this.tileType = tileType;
            base.Depth = -9000;
            OwnedComponents.Add(new LightOccludeState());
            SurfaceSoundIndex = ((IOriginalTileSurfaceEnvironment)engine).SurfaceIndices.TileToIndex[tileType];
            if (!disableSpawnOffset)
            {
                sineWave = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, (float)Math.PI * 2f);
            }
            else
            {
                sineWave = 0f;
            }
        }

        public FloatySpaceBlockState(EntityData data, Vector2 offset, ISourceSolidWorldFactory worlds)
            : this(data.Position + offset, data.Width, data.Height,
                EntityAttributeReader.Char(data.Values, "tiletype", '3'),
                EntityAttributeReader.Bool(data.Values, "disableSpawnOffset"),
                worlds.Create(data.Position + offset, true))
        {
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            awake = true;
            if (!HasGroup)
            {
                MasterOfGroup = true;
                Moves = new Dictionary<SourcePlatformEntityState, Vector2>();
                Group = new List<FloatySpaceBlockState>();
                Jumpthrus = new List<SourceJumpThruEntityState>();
                GroupBoundsMin = new IntPoint((int)base.X, (int)base.Y);
                GroupBoundsMax = new IntPoint((int)base.Right, (int)base.Bottom);
                AddToGroupAndFindChildren(this);
                _ = base.Scene;
                tiles = Celeste.Game.Presentation.Platforms.FloatySpaceBlocks.OriginalFloatyBlockGroupTiles.Generate(
                    Group,
                    GroupBoundsMin, GroupBoundsMax, ref tileType, engine);
                tiles.Position = new Vector2((float)GroupBoundsMin.X - base.X, (float)GroupBoundsMin.Y - base.Y);
                OwnedComponents.Add(tiles);
            }

            TryToInitPosition();
        }

        public override void OnStaticMoverTrigger(SourceStaticMoverState sm)
        {
            FloatySpringReaction.Apply(sm, ref sinkTimer, ref dashEase, ref dashDirection);
        }

        private void TryToInitPosition()
        {
            if (MasterOfGroup)
            {
                foreach (FloatySpaceBlockState item in Group)
                {
                    if (!item.awake)
                    {
                        return;
                    }
                }

                MoveToTarget();
            }
            else
            {
                master.TryToInitPosition();
            }
        }

        private void AddToGroupAndFindChildren(FloatySpaceBlockState from)
        {
            if (from.X < (float)GroupBoundsMin.X)
            {
                GroupBoundsMin.X = (int)from.X;
            }

            if (from.Y < (float)GroupBoundsMin.Y)
            {
                GroupBoundsMin.Y = (int)from.Y;
            }

            if (from.Right > (float)GroupBoundsMax.X)
            {
                GroupBoundsMax.X = (int)from.Right;
            }

            if (from.Bottom > (float)GroupBoundsMax.Y)
            {
                GroupBoundsMax.Y = (int)from.Bottom;
            }

            from.HasGroup = true;
            from.OnDashCollide = OnDash;
            Group.Add(from);
            Moves.Add(from, from.Position);
            if (from != this)
            {
                from.master = this;
            }

            foreach (SourceJumpThruEntityState item in SourceSceneCollision.AllRect<SourceJumpThruEntityState>(
                         ((ISourceScene)Scene).SourceScene.Entities, "Celeste.JumpThru",
                         new IntRect((int)from.X - 1, (int)from.Y, (int)from.Width + 2, (int)from.Height)))
            {
                if (!Jumpthrus.Contains(item))
                {
                    AddJumpThru(item);
                }
            }

            foreach (SourceJumpThruEntityState item2 in SourceSceneCollision.AllRect<SourceJumpThruEntityState>(
                         ((ISourceScene)Scene).SourceScene.Entities, "Celeste.JumpThru",
                         new IntRect((int)from.X, (int)from.Y - 1, (int)from.Width, (int)from.Height + 2)))
            {
                if (!Jumpthrus.Contains(item2))
                {
                    AddJumpThru(item2);
                }
            }

            foreach (FloatySpaceBlockState entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.FloatySpaceBlock"))
            {
                if (!entity.HasGroup && entity.tileType == tileType &&
                    (SourceSceneCollision.CheckRect(
                         new IntRect((int)from.X - 1, (int)from.Y, (int)from.Width + 2, (int)from.Height), entity) ||
                     SourceSceneCollision.CheckRect(
                         new IntRect((int)from.X, (int)from.Y - 1, (int)from.Width, (int)from.Height + 2), entity)))
                {
                    AddToGroupAndFindChildren(entity);
                }
            }
        }

        private void AddJumpThru(SourceJumpThruEntityState jp)
        {
            jp.OnDashCollide = OnDash;
            Jumpthrus.Add(jp);
            Moves.Add(jp, jp.Position);
            foreach (FloatySpaceBlockState entity in ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         "Celeste.FloatySpaceBlock"))
            {
                if (!entity.HasGroup && entity.tileType == tileType &&
                    SourceSceneCollision.CheckRect(
                        new IntRect((int)jp.X - 1, (int)jp.Y, (int)jp.Width + 2, (int)jp.Height),
                        entity))
                {
                    AddToGroupAndFindChildren(entity);
                }
            }
        }

        private DashCollisionResult OnDash(RoomPlayerSession player, Vector2 direction)
        {
            if (MasterOfGroup && dashEase <= 0.2f)
            {
                dashEase = 1f;
                dashDirection = direction;
            }

            return DashCollisionResult.NormalOverride;
        }

        public override void Update()
        {
            base.Update();
            if (MasterOfGroup)
            {
                bool flag = false;
                foreach (FloatySpaceBlockState item in Group)
                {
                    if (item.HasPlayerRider())
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    foreach (SourceJumpThruEntityState jumpthru in Jumpthrus)
                    {
                        if (jumpthru.HasPlayerRider())
                        {
                            flag = true;
                            break;
                        }
                    }
                }

                if (flag)
                {
                    sinkTimer = 0.3f;
                }
                else if (sinkTimer > 0f)
                {
                    sinkTimer -= engine.DeltaTime;
                }

                if (sinkTimer > 0f)
                {
                    yLerp = ScalarMath.Approach(yLerp, 1f, 1f * engine.DeltaTime,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                }
                else
                {
                    yLerp = ScalarMath.Approach(yLerp, 0f, 1f * engine.DeltaTime,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                }

                sineWave += engine.DeltaTime;
                dashEase = ScalarMath.Approach(dashEase, 0f, engine.DeltaTime * 1.5f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                MoveToTarget();
            }

            LiftSpeed = Vector2.Zero;
        }

        private void MoveToTarget()
        {
            float num = ((ISourceFloatySpaceEnvironment)engine).FloatySpaceArithmetic.GetSine(sineWave);
            Vector2 vector = ScalarMath.YoYo(((ISourceEasingEnvironment)engine).EasingArithmetic.QuadIn(dashEase)) *
                             dashDirection * 8f;
            FloatyPlatformGroupMotion.Move(ref Moves, num, vector, new FloatyTarget(this));
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        private float GetMoveTargetY(float origin, float sine, float dash)
            => ((ISourceFloatySpaceEnvironment)engine).FloatySpaceArithmetic.GetTargetY(origin,
                ((ISourceEasingEnvironment)engine).EasingArithmetic.SineInOut(yLerp), sine, dash);

        private readonly struct FloatyTarget : IFloatyPlatformTarget
        {
            private readonly FloatySpaceBlockState owner;
            public FloatyTarget(FloatySpaceBlockState owner) => this.owner = owner;
            public float GetTargetY(float origin, float sine, float dashY) => owner.GetMoveTargetY(origin, sine, dashY);
        }

        public override void OnShake(Vector2 amount)
        {
            if (!MasterOfGroup)
            {
                return;
            }

            base.OnShake(amount);
            tiles.Position += amount;
            foreach (SourceJumpThruEntityState jumpthru in Jumpthrus)
            {
                foreach (SourceComponentState component in jumpthru.OwnedComponents)
                {
                    if (component is SpriteImage image)
                    {
                        image.Position += amount;
                    }
                }
            }
        }
    }
}
