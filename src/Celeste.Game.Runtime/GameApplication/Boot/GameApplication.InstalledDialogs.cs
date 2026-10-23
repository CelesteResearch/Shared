using Celeste.Everest.Content.Dialogs;
using Celeste.Game.Content.Dialogs;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestDialogLevelSetEnvironment,
        IOriginalInstalledDialogEnvironment,
        IOriginalDialogLoadingEnvironment
    {
        private EverestDialogLevelSetProcess sourceDialogLevelSets;
        private IOriginalDialogLoadingPolicy sourceOriginalDialogLoading;

        public EverestDialogLevelSetProcess DialogLevelSets =>
            sourceDialogLevelSets ??= new EverestDialogLevelSetProcess(this);

        IOriginalInstalledDialogPolicy IOriginalInstalledDialogEnvironment.InstalledDialogs => DialogLevelSets;

        IOriginalDialogLoadingPolicy IOriginalDialogLoadingEnvironment.DialogLoadingPolicy =>
            SourceProfile == Celeste.Game.Profiles.GameProfile.InstalledEverest
                ? (IOriginalDialogLoadingPolicy)DialogLevelSets
                : PhysicalIO.ContentFiles is global::Celeste.Core.IO.Content.ResidentContentSource
                    ? sourceOriginalDialogLoading ??= new OriginalDialogLoadingPolicy(PhysicalIO.ContentFiles)
                    : OriginalDialogLoadingPolicy.Shared;
    }
}
