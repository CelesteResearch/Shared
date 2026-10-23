using System;
using System.Linq;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Graphics.Content;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Gameplay.Platforms.IntroCrusher;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Audio.Surfaces;
using Celeste.Simulation.Gameplay.Tiles;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Everest.Gameplay.Platforms.IntroCrusher
{
    public class EverestIntroCrusherState : OriginalIntroCrusherState
    {
        public string levelFlags;

        public EverestIntroCrusherState(ISourceEngineContext engine, Vector2 position, int width, int height,
            Vector2 node, ISourceSolidWorld world) : base(engine, position, width, height, node, world)
        {
        }

        public EverestIntroCrusherState(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world) : base(engine, data, offset, world)
        {
            levelFlags = EntityAttributeReader.Attr(data.Values, "flags");
            string text = EntityAttributeReader.Attr(data.Values, "tiletype");
            if (!string.IsNullOrEmpty(text))
            {
                SurfaceSoundIndex = ((IOriginalTileSurfaceEnvironment)engine).SurfaceIndices.TileToIndex[text[0]];
                OwnedComponents.Remove(tilegrid);
                OwnedComponents.Add(tilegrid =
                    ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                    .ForegroundAutotiler.GenerateBox(text[0], data.Width / 8, data.Height / 8).TileGrid);
            }

            OwnedComponents.Add(new TileInterceptorState(tilegrid, false));
        }

        public override void Added(object scene)
        {
            var level = scene as OriginalLevelSceneRoot;
            var keys = ((IOriginalAreaKeyEnvironment)engine).AreaKeys;
            if (keys.GetLevelSet(keys.GetSessionArea(level.Session)) == "Celeste" || string.IsNullOrEmpty(levelFlags))
            {
                base.Added(scene);
                return;
            }

            // The installed alternate branch calls Solid.Added directly, then its own flag test.
            AddedToSourceSolid(scene);
            if (levelFlags.Split(',').Any(flag => level.Session.GetLevelFlag(flag)))
                Position = end;
            else OwnedComponents.Add(new SimulationCoroutine(engine, Sequence()));
        }
    }
}
