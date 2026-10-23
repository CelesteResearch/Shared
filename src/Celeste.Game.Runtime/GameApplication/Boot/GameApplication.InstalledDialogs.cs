using Celeste.Core.IO.Content;
using Celeste.Everest.Content.Dialogs;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestDialogLevelSetEnvironment,
        IOriginalInstalledDialogEnvironment,
        IOriginalDialogLoadingEnvironment
    {
        private EverestDialogLevelSetProcess sourceDialogLevelSets;
        private IOriginalDialogLoadingPolicy sourceOriginalDialogLoading;

        public EverestDialogLevelSetProcess DialogLevelSets =>
            sourceDialogLevelSets ??= new(this);

        IOriginalInstalledDialogPolicy IOriginalInstalledDialogEnvironment.InstalledDialogs => DialogLevelSets;

        IOriginalDialogLoadingPolicy IOriginalDialogLoadingEnvironment.DialogLoadingPolicy =>
            SourceProfile == GameProfile.InstalledEverest
                ? DialogLevelSets
                : PhysicalIO.ContentFiles is ResidentContentSource
                    ? sourceOriginalDialogLoading ??= new OriginalDialogLoadingPolicy(PhysicalIO.ContentFiles)
                    : OriginalDialogLoadingPolicy.Shared;
    }
}
