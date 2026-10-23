using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Celeste.Core.Framework.Loading;
using Celeste.Core.IO.Content;
using Celeste.Game.Content.Loading;
using Celeste.Graphics.Content.VirtualAssets;

namespace Celeste.Game.Runtime.Content.Loading
{
    public sealed class OriginalContentLoadingScheduler : ISourceContextualLoadingWorkScheduler
    {
        private readonly CooperativeSourceLoadingWorkScheduler scheduler;
        private readonly Func<ResidentVirtualContent> textures;
        private readonly int ownerThread;

        public bool SourceUpdatesBlocked => scheduler.SourceUpdatesBlocked;

        public OriginalContentLoadingScheduler(ResidentContentSource source,
            Func<ResidentVirtualContent> textures,
            Func<SourceLoadingWorkInfo, CancellationToken, ValueTask> prepareAdditionalResources,
            CancellationToken cancellationToken = default)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            this.textures = textures ?? throw new ArgumentNullException(nameof(textures));
            if (prepareAdditionalResources == null)
                throw new ArgumentNullException(nameof(prepareAdditionalResources));
            ownerThread = Thread.CurrentThread.ManagedThreadId;
            scheduler = CooperativeSourceLoadingWorkScheduler.CreateWithContextPreparation(info =>
            {
                Task content;
                if (info.ContentContext is OriginalChapterPreparationContext
                    chapter)
                {
                    var paths = new List<string>();
                    foreach (var group in chapter.ContentGroups)
                        paths.AddRange(source.Manifest.GetGroupFiles(group));
                    content = source.PrepareFilesAsync(paths, cancellationToken);
                }
                else
                {
                    if (info.ContentContext != null)
                        throw new InvalidOperationException(
                            "The original game does not recognize this content context.");
                    if (info.Name == "LEVEL_LOADER" || info.Name == "COMPLETE_LEVEL" || info.Name == "SUMMIT_VIGNETTE")
                        throw new InvalidOperationException("Chapter loading requires its actual map content context.");
                    content = info.Name == "GAME_LOADER" || info.Name == "OVERWORLD_LOADER"
                        ? source.PrepareGroupAsync("menu", cancellationToken)
                        : Task.CompletedTask;
                }

                return new(Task.WhenAll(content,
                    prepareAdditionalResources(info, cancellationToken).AsTask()));
            });
        }

        public Task Schedule(Action work, Action<Exception> preparationFailed, string name, bool highPriority)
        {
            return Schedule(work, preparationFailed, new SourceLoadingWorkInfo(name), highPriority);
        }

        public Task Schedule(Action work, Action<Exception> preparationFailed, SourceLoadingWorkInfo info,
            bool highPriority)
        {
            AssertOwnerThread();
            if (work == null) throw new ArgumentNullException(nameof(work));
            return scheduler.Schedule(() =>
            {
                try
                {
                    textures().ReloadPreparedTextures();
                }
                catch (Exception exception)
                {
                    preparationFailed(exception);
                    throw;
                }

                work();
            }, preparationFailed, info, highPriority);
        }

        public void Pump()
        {
            AssertOwnerThread();
            scheduler.Pump();
        }

        private void AssertOwnerThread()
        {
            if (Thread.CurrentThread.ManagedThreadId != ownerThread)
                throw new InvalidOperationException("Loading work must be scheduled and pumped on its source owner.");
        }
    }
}
