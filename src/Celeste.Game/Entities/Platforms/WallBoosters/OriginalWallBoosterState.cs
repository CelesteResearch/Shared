using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Collision.Blockers;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Interaction.WallBooster;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;

namespace Celeste.Game.Entities.Platforms.WallBoosters
{
    public class OriginalWallBoosterState : SceneEntityState, ISourceWallBooster
    {
        public int Facing;
        private SourceStaticMoverState staticMover;
        private readonly ClimbBlockerState climbBlocker;
        private readonly SoundSourceComponentState idleSfx;
        public bool IceMode;
        private readonly bool notCoreMode;
        private readonly List<Sprite> tiles;
        private readonly ISourceEngineContext engine;
        int ISourceWallBooster.Facing => Facing;

        public OriginalWallBoosterState(ISourceEngineContext engine, Vector2 position, float height,
            bool left, bool notCoreMode)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
            Depth = 1999;
            this.notCoreMode = notCoreMode;
            if (left)
            {
                Facing = -1;
                Collider = new HitboxColliderGeometry(2f, height);
            }
            else
            {
                Facing = 1;
                Collider = new HitboxColliderGeometry(2f, height, 6f);
            }

            OwnedComponents.Add(new CoreModeListenerState(OnChangeMode));
            OwnedComponents.Add(staticMover = new());
            OwnedComponents.Add(climbBlocker = new(false));
            OwnedComponents.Add(idleSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            tiles = BuildSprite(left);
        }

        public static OriginalWallBoosterState CreateFromMapData(EntityData data,
            Vector2 offset, OriginalLevelSceneRoot level)
        {
            return new(level.EngineContext, data.Position + offset, data.Height,
                EntityAttributeReader.Bool(data.Values, "left"),
                EntityAttributeReader.Bool(data.Values, "notCoreMode"));
        }

        private List<Sprite> BuildSprite(bool left)
        {
            List<Sprite> list = [];
            for (var i = 0; i < Height; i = unchecked(i + 8))
            {
                var id = i == 0
                    ? "WallBoosterTop"
                    : !(unchecked(i + 16) > Height)
                        ? "WallBoosterMid"
                        : "WallBoosterBottom";
                var sprite = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create(id);
                if (!left)
                {
                    sprite.FlipX = true;
                    sprite.Position = new(4f, i);
                }
                else
                {
                    sprite.Position = new(0f, i);
                }

                list.Add(sprite);
                OwnedComponents.Add(sprite);
            }

            return list;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            var mode = RoomCoreMode.None;
            if (((ISourceCoreModeScene)Scene).CoreMode == RoomCoreMode.Cold || notCoreMode)
                mode = RoomCoreMode.Cold;
            OnChangeMode(mode);
        }

        private void OnChangeMode(RoomCoreMode mode)
        {
            IceMode = mode == RoomCoreMode.Cold;
            climbBlocker.Blocking = IceMode;
            tiles.ForEach(t => t.Play(IceMode ? "ice" : "hot"));
            if (IceMode)
                idleSfx.Stop();
            else if (!idleSfx.Playing)
                idleSfx.Play("event:/env/local/09_core/conveyor_idle");
        }

        public override void Update()
        {
            PositionIdleSfx();
            if (!((OriginalLevelSceneRoot)Scene).Transitioning)
                base.Update();
        }

        private void PositionIdleSfx()
        {
            var players =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                    typeof(RoomPlayerSession).FullName);

            var player = players.Count == 0 ? null : players[0] as RoomPlayerSession;
            if (!(player != null))
                return;
            idleSfx.Position = ((ISourceVectorEnvironment)engine).VectorArithmetic.ClosestPointOnLine(
                Position, Position + new Vector2(0f, Height), player.Center) - Position;
            idleSfx.UpdateSfxPosition();
        }
    }
}
