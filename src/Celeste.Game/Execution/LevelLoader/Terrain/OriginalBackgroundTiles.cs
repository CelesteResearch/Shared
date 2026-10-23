using System.Numerics;
using Celeste.Core.Collections;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Entities;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Tiles;

namespace Celeste.Game.Execution.LevelLoader.Terrain
{
    public sealed class OriginalBackgroundTiles : SceneEntityState
    {
        public TileGrid Tiles;

        public OriginalBackgroundTiles(Vector2 position, VirtualMap<char> data, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            Position = position;
            Tags = ((Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)engine).Tags.Global.Value;
            Tiles = ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                .BackgroundAutotiler
                .GenerateMap(data, paddingIgnoreOutOfLevel: false).TileGrid;
            Tiles.VisualExtend = 1;
            Components.Add(Tiles);
            Depth = 10000;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            Tiles.ClipCamera = (Scene as OriginalLevelSceneRoot).Camera;
        }
    }
}
