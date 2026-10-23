using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Celeste.Core.IO.Content;
using Celeste.Core.Framework.Loading;
using Celeste.Game.Profiles;
using Celeste.Game.Runtime.Platform;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Game.Runtime.Content.Loading
{
    // Await bytes from the host; create and initialize the game on its owning loop.
    public sealed class ProgressiveOriginalContentBootstrap
    {
        private readonly ResidentContentSource source;
        private readonly Func<SourceLoadingWorkInfo, CancellationToken, ValueTask> prepareAdditionalResources;
        private readonly CancellationToken cancellationToken;
        private readonly int ownerThread;
        private Task? bootPreparation;
        private GameApplication? game;
        private bool creationAttempted;

        public OriginalContentLoadingScheduler Scheduler { get; }

        public ProgressiveOriginalContentBootstrap(ResidentContentSource source,
            Func<SourceLoadingWorkInfo, CancellationToken, ValueTask> prepareAdditionalResources,
            CancellationToken cancellationToken = default)
        {
            this.source = source ?? throw new ArgumentNullException(nameof(source));
            this.prepareAdditionalResources = prepareAdditionalResources ??
                                              throw new ArgumentNullException(nameof(prepareAdditionalResources));
            this.cancellationToken = cancellationToken;
            ownerThread = Thread.CurrentThread.ManagedThreadId;
            Scheduler = new OriginalContentLoadingScheduler(source, GetTextures, prepareAdditionalResources,
                cancellationToken);
        }

        public Task PrepareBootAsync()
        {
            AssertOwnerThread();
            cancellationToken.ThrowIfCancellationRequested();
            return bootPreparation ??= Task.WhenAll(source.PrepareGroupAsync("boot", cancellationToken),
                prepareAdditionalResources(new SourceLoadingWorkInfo("BOOT"), cancellationToken).AsTask());
        }

        public GameApplication CreatePreparedGame(GamePlatformServices physical)
        {
            AssertOwnerThread();
            if (physical == null) throw new ArgumentNullException(nameof(physical));
            if (creationAttempted) throw new InvalidOperationException("Game creation has already been attempted.");
            if (bootPreparation == null || !bootPreparation.IsCompleted)
                throw new InvalidOperationException("Await boot preparation before creating the original game.");
            bootPreparation.GetAwaiter().GetResult();
            cancellationToken.ThrowIfCancellationRequested();
            if (!ReferenceEquals(physical.ContentFiles, source)
                || !ReferenceEquals(physical.LoadingWorkScheduler, Scheduler)
                || !string.Equals(Path.GetFullPath(physical.ContentRoot), source.TitleLocation,
                    StringComparison.Ordinal))
                throw new ArgumentException("Physical services must use this content source, root and scheduler.",
                    nameof(physical));
            creationAttempted = true;
            game = GameApplicationFactory.Create(GameProfile.Original, physical);
            return game ?? throw new InvalidOperationException("Original game construction did not complete.");
        }

        private ResidentVirtualContent GetTextures()
            => game?.VirtualContent as ResidentVirtualContent ??
               throw new InvalidOperationException("The progressive original texture owner is not constructed.");

        private void AssertOwnerThread()
        {
            if (Thread.CurrentThread.ManagedThreadId != ownerThread)
                throw new InvalidOperationException("Create the original game on the bootstrap owner thread.");
        }
    }
}
