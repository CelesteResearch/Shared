using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Maps;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Actors.Debris;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Gameplay.Walls.Breakable
{
    public class OriginalTempleCrackedBlockState : SourceSolidEntityState
    {
        private readonly MapEntityId eid;

        private readonly ISourceEngineContext engine;

        private readonly bool persistent;

        private readonly AtlasEntry[,,] tiles;

        private float frame;

        private bool broken;

        private readonly int frames;

        public OriginalTempleCrackedBlockState(MapEntityId eid, Vector2 position, float width, float height,
            bool persistent, ISourceEngineContext engine, ISourceSolidWorld actualWorld)
            : base(position, width, height, true, actualWorld)
        {
            this.engine = engine;
            this.eid = eid;
            this.persistent = persistent;
            Collidable = Visible = false;
            var num = (int)(width / 8f);
            var num2 = (int)(height / 8f);
            var atlasSubtextures =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                    "objects/temple/breakBlock");
            tiles = new AtlasEntry[num, num2, atlasSubtextures.Count];
            frames = atlasSubtextures.Count;
            for (var i = 0; i < num; i++)
            for (var j = 0; j < num2; j++)
            {
                var num3 = i < num / 2 && i < 2
                    ? i
                    : i < num / 2 || i < num - 2
                        ? 2 + i % 2
                        : 5 - (num - i - 1);
                var num4 = j < num2 / 2 && j < 2
                    ? j
                    : j < num2 / 2 || j < num2 - 2
                        ? 2 + j % 2
                        : 5 - (num2 - j - 1);
                for (var k = 0; k < atlasSubtextures.Count; k++)
                    tiles[i, j, k] = atlasSubtextures[k].GetSubtexture(num3 * 8, num4 * 8, 8, 8);
            }

            OwnedComponents.Add(new LightOccludeState(0.5f));
        }

        public OriginalTempleCrackedBlockState(MapEntityId eid, EntityData data, Vector2 offset,
            ISourceEngineContext engine, ISourceSolidWorld actualWorld)
            : this(eid, data.Position + offset, data.Width, data.Height,
                EntityAttributeReader.Bool(data.Values, "persistent"), engine, actualWorld)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (SourceTrackedEntityCollision.Check(((ISourceScene)Scene).SourceScene.Entities,
                    typeof(RoomPlayerSession).FullName, this))

            {
                if (persistent) ((OriginalLevelSceneRoot)Scene).Session.DoNotLoad.Add(eid);

                RemoveSelf();
            }
            else
            {
                Collidable = Visible = true;
            }
        }

        public override void Update()
        {
            base.Update();
            if (broken)
            {
                frame += engine.DeltaTime * 15f;
                if (frame >= frames) RemoveSelf();
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            var num = (int)frame;
            if (num >= frames) return;

            for (var i = 0; i < Width / 8f; i++)
            for (var j = 0; j < Height / 8f; j++)
                SourceAtlasDrawing.Draw(context, this, tiles[i, j, num], Position + new Vector2(i, j) * 8f);
        }

        public void Break(Vector2 from)
        {
            if (persistent) ((OriginalLevelSceneRoot)Scene).Session.DoNotLoad.Add(eid);

            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                "event:/game/05_mirror_temple/crackedwall_vanish",
                Center);
            broken = true;
            Collidable = false;
            for (var i = 0; i < Width / 8f; i++)
            for (var j = 0; j < Height / 8f; j++)
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(engine.EntityPools.Create<DebrisState>()
                    .Init(Position + new Vector2(i * 8 + 4, j * 8 + 4), '1').BlastFrom(from));
        }
    }
}
