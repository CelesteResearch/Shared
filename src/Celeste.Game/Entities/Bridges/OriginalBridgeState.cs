using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;

namespace Celeste.Game.Entities.Bridges
{
    public class OriginalBridgeState : SceneEntityState
    {
        private List<OriginalBridgeTileState> tiles;

        private OriginalLevelSceneRoot level;

        private readonly ISourceEngineContext engine;

        private bool canCollapse;

        private bool canEndCollapseA;

        private bool canEndCollapseB;

        private float collapseTimer;

        private readonly int width;

        private readonly List<IntRect> tileSizes = [];

        private bool ending;

        private float gapStartX;

        private float gapEndX;

        private readonly SoundSourceComponentState collapseSfx;

        public OriginalBridgeState(Vector2 position, int width, float gapStartX, float gapEndX,
            ISourceEngineContext engine)
            : base(
                ((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration,
                position)
        {
            this.engine = engine;
            this.width = width;
            this.gapStartX = gapStartX;
            this.gapEndX = gapEndX;
            tileSizes.Add(new(0, 0, 16, 52));
            tileSizes.Add(new(16, 0, 8, 52));
            tileSizes.Add(new(24, 0, 8, 52));
            tileSizes.Add(new(32, 0, 8, 52));
            tileSizes.Add(new(40, 0, 8, 52));
            tileSizes.Add(new(48, 0, 8, 52));
            tileSizes.Add(new(56, 0, 8, 52));
            tileSizes.Add(new(64, 0, 8, 52));
            tileSizes.Add(new(72, 0, 8, 52));
            tileSizes.Add(new(80, 0, 16, 52));
            tileSizes.Add(new(96, 0, 8, 52));
            OwnedComponents.Add(collapseSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
        }

        public OriginalBridgeState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data.Position + offset, data.Width, data.Nodes[0].X, data.Nodes[1].X, engine)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            level = scene as OriginalLevelSceneRoot;
            tiles = [];
            gapStartX += level.Bounds.Left;
            gapEndX += level.Bounds.Left;
            ((ISourceRandomProcessEnvironment)engine).RandomProcess.PushRandom(1);
            var position = Position;
            var num = 0;
            while (position.X < X + width)
            {
                var tileSize = num < 2 || num > 7
                    ? tileSizes[num]
                    : tileSizes[2 + ((ISourceRandomEnvironment)engine).Random.Next(6)];
                if (position.X < gapStartX || position.X >= gapEndX)
                {
                    var bridgeTile = new OriginalBridgeTileState(position, tileSize, engine,
                        level.SolidWorldFactory.CreateJumpThru(position, false));
                    tiles.Add(bridgeTile);
                    level.Scheduler.QueueSourceEntity(bridgeTile);
                }

                position.X += tileSize.Width;
                num = (num + 1) % tileSizes.Count;
            }

            ((ISourceRandomProcessEnvironment)engine).RandomProcess.PopRandom();
        }

        public override void Update()
        {
            base.Update();
            var entity =
                level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (entity == null || entity.Dead) collapseSfx.Stop();

            if (!canCollapse)
            {
                if (entity != null && entity.X >= X + 112f)
                {
                    ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput.SetMusic("event:/music/lvl0/bridge");
                    collapseSfx.Play("event:/game/00_prologue/bridge_rumble_loop");
                    canCollapse = true;
                    canEndCollapseA = true;
                    canEndCollapseB = true;
                    for (var i = 0; i < 11; i++)
                    {
                        tiles[0].Fall(SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 0.1f, 0.5f));
                        tiles.RemoveAt(0);
                    }
                }
            }
            else if (tiles.Count > 0)
            {
                if (entity == null) return;

                if (canEndCollapseA && entity.X > X + width - 216f)
                {
                    canEndCollapseA = false;
                    for (var j = 0; j < 5; j++)
                    {
                        tiles[tiles.Count - 8]
                            .Fall(SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 0.1f, 0.5f));
                        tiles.RemoveAt(tiles.Count - 8);
                    }
                }
                else if (canEndCollapseB && entity.X > X + width - 104f)
                {
                    canEndCollapseB = false;
                    for (var k = 0; k < 7; k++)
                    {
                        if (tiles.Count <= 0) break;

                        tiles[tiles.Count - 1]
                            .Fall(SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 0.1f, 0.3f));
                        tiles.RemoveAt(tiles.Count - 1);
                    }
                }
                else if (collapseTimer > 0f)
                {
                    collapseTimer -= engine.DeltaTime;
                    if (tiles.Count >= 5 && entity.X >= tiles[4].X)
                    {
                        var index = 0;
                        tiles[index].Fall();
                        tiles.RemoveAt(index);
                    }
                }
                else
                {
                    tiles[0].Fall();
                    tiles.RemoveAt(0);
                    collapseTimer = 0.2f;
                }
            }
            else if (!ending)
            {
                ending = true;
                StopCollapseLoop();
            }
        }

        public void StopCollapseLoop()
        {
            collapseSfx.Stop();
        }
    }
}
