using System;
using Celeste.Everest.UI.Files;
using Celeste.Game.Menus.Files;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalFileSlotFirstAreaEnvironment
    {
        private IOriginalFileSlotFirstAreaPolicy sourceFileSlotFirstArea;

        public IOriginalFileSlotFirstAreaPolicy FileSlotFirstArea => sourceFileSlotFirstArea ??
                                                                     throw new InvalidOperationException(
                                                                         "The actual first-area file slot policy has not been constructed.");

        internal void ConstructSourceFileSlotFirstAreaPolicy()
        {
            if (sourceFileSlotFirstArea != null)
                throw new InvalidOperationException("The actual first-area file slot policy is already constructed.");
            sourceFileSlotFirstArea = SourceProfile switch
            {
                GameProfile.Original => new OriginalFileSlotFirstAreaPolicy(),
                GameProfile.InstalledEverest => new EverestFileSlotFirstAreaPolicy(),
                _ => throw new InvalidOperationException("A supported source profile is required.")
            };
        }
    }
}
