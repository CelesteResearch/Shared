using System;
using Celeste.Game.Entities.Decoration.Construction;
using Celeste.Game.Profiles;
using Celeste.Everest.Entities.Decoration.Construction;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalDecorationEnvironment
    {
        private IOriginalDecorationFactory sourceDecorationFactory;

        public IOriginalDecorationFactory Decorations => sourceDecorationFactory ??
                                                         throw new InvalidOperationException(
                                                             "The actual source decoration factory has not been constructed.");

        private void ConstructSourceDecorations()
        {
            if (sourceDecorationFactory != null)
                throw new InvalidOperationException("The actual source decoration factory is already constructed.");
            sourceDecorationFactory = SourceProfile == GameProfile.Original
                ? new OriginalDecorationFactory()
                : new InstalledDecorationFactory();
        }
    }
}
