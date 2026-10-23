using System;
using Celeste.Everest.UI.Dependencies;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestDependencyDownloadEnvironment
    {
        private EverestDependencyDownloadProcess sourceDependencyDownloads;

        public EverestDependencyDownloadProcess DependencyDownloads => sourceDependencyDownloads ??
                                                                       throw new InvalidOperationException(
                                                                           "The actual dependency download process is not constructed.");

        public void ConstructSourceDependencyDownloads()
        {
            if (sourceDependencyDownloads != null)
                throw new InvalidOperationException("The actual dependency download process is already constructed.");
            sourceDependencyDownloads = new EverestDependencyDownloadProcess();
        }
    }
}
