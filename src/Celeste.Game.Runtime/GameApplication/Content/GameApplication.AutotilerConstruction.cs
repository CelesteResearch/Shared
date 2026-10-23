using System;
using Celeste.Everest.Content.Tiles.Autotiling;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Profiles;
using Celeste.Graphics.Content.Tiles.Autotiling;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceAutotilerConstructionEnvironment
    {
        private ISourceAutotilerConstruction sourceAutotilerConstruction;

        public ISourceAutotilerConstruction AutotilerConstruction => sourceAutotilerConstruction ??
                                                                     throw new InvalidOperationException(
                                                                         "The actual source Autotiler construction has not been selected.");

        internal void ConstructSourceAutotilerConstruction()
        {
            if (sourceAutotilerConstruction != null)
                throw new InvalidOperationException("The actual source Autotiler construction is already selected.");
            sourceAutotilerConstruction = SourceProfile == GameProfile.Original
                ? new OriginalAutotilerConstruction()
                : new EverestAutotilerConstruction();
        }
    }
}
