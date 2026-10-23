using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Collision.Blockers;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Interaction.WallBooster;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;

namespace Celeste.Game.Entities.Platforms.WallBoosters
{
    public class OriginalWallBoosterState : SceneEntityState, ISourceWallBooster
    {
        public int Facing;
        private SourceStaticMoverState staticMover;
        private ClimbBlockerState climbBlocker;
        private SoundSourceComponentState idleSfx;
        public bool IceMode;
        private bool notCoreMode;
        private List<Sprite> tiles;
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
            OwnedComponents.Add(staticMover = new SourceStaticMoverState());
            OwnedComponents.Add(climbBlocker = new ClimbBlockerState(false));
            OwnedComponents.Add(idleSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            tiles = BuildSprite(left);
        }

        public static OriginalWallBoosterState CreateFromMapData(EntityData data,
            Vector2 offset, OriginalLevelSceneRoot level)
            => new(level.EngineContext, data.Position + offset, data.Height,
                EntityAttributeReader.Bool(data.Values, "left"),
                EntityAttributeReader.Bool(data.Values, "notCoreMode"));

        private List<Sprite> BuildSprite(bool left)
        {
            List<Sprite> list = new();
            for (int i = 0; (float)i < Height; i = unchecked(i + 8))
            {
                string id = i == 0
                    ? "WallBoosterTop"
                    : !((float)unchecked(i + 16) > Height)
                        ? "WallBoosterMid"
                        : "WallBoosterBottom";
                Sprite sprite = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create(id);
                if (!left)
                {
                    sprite.FlipX = true;
                    sprite.Position = new Vector2(4f, i);
                }
                else
                    sprite.Position = new Vector2(0f, i);

                list.Add(sprite);
                OwnedComponents.Add(sprite);
            }

            return list;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            RoomCoreMode mode = RoomCoreMode.None;
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
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            var player = players.Count == 0 ? null : players[0] as RoomPlayerSession;
            if (player != null)
            {
                idleSfx.Position = ((ISourceVectorEnvironment)engine).VectorArithmetic.ClosestPointOnLine(
                    Position, Position + new Vector2(0f, Height), player.Center) - Position;
                idleSfx.UpdateSfxPosition();
            }
        }
    }
}
