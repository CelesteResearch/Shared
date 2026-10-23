using System;
using System.Collections.Generic;
using Celeste.Game.Execution.Audio.Surfaces;

namespace Celeste.Game.Audio.Surfaces
{
    public sealed class OriginalTileSurfaceIndices
    {
        private readonly IOriginalSurfaceIndexEnvironment environment;

        public OriginalTileSurfaceIndices(IOriginalSurfaceIndexEnvironment environment)
            => this.environment = environment ?? throw new ArgumentNullException(nameof(environment));

        public Dictionary<char, int> TileToIndex
        {
            get => environment.SurfaceIndex.TileToIndex;
            set => environment.SurfaceIndex.TileToIndex = value;
        }
    }
}
