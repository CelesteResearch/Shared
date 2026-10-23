using System;
using System.IO;
using System.Threading;
using Celeste.Core.IO.Content;

namespace Celeste.Graphics.Content.VirtualAssets
{
    // All decoding and GPU publication remain on the original content owner.
    public sealed class ResidentVirtualContent : VirtualContent
    {
        private readonly ResidentContentSource source;
        private readonly int ownerThread;

        // ReSharper disable once ConvertToPrimaryConstructor
        public ResidentVirtualContent(ISourceVirtualTextureEnvironment environment,
            ISourceVirtualRenderTargetFactory renderTargets, ResidentContentSource source) : base(environment,
            renderTargets)
        {
            this.source = source ?? throw new ArgumentNullException(nameof(source));
            ownerThread = Thread.CurrentThread.ManagedThreadId;
        }

        public override VirtualTexture CreateTexture(string path)
        {
            AssertOwnerThread();
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            var logical = Path.IsPathRooted(path) ? Path.GetRelativePath(source.TitleLocation, path) : path;
            logical = logical.Replace('\\', '/');
            if (!source.Manifest.TryGetFile(logical, out var file))
                throw new FileNotFoundException("Texture is absent from the content manifest.", path);
            if (file.Texture == null)
            {
                if (!source.IsReady(path))
                    throw new InvalidOperationException("Texture without physical metadata must be prepared: " + path);
                return base.CreateTexture(path);
            }

            return RegisterTexture(path, file.Texture.Width, file.Texture.Height);
        }

        internal override bool TryReloadTextureOnRead(VirtualTexture texture)
        {
            AssertOwnerThread();
            if (!source.IsReady(texture.Path))
                return false;
            texture.Reload();
            return true;
        }

        public void ReloadPreparedTextures()
        {
            AssertOwnerThread();
            foreach (var asset in Assets)
                if (asset is VirtualTexture texture && texture.ReloadWithOwner && texture.Path != null &&
                    texture.IsDisposed && source.IsReady(texture.Path))
                    texture.Reload();
        }

        private void AssertOwnerThread()
        {
            if (Thread.CurrentThread.ManagedThreadId != ownerThread)
                throw new InvalidOperationException("Texture creation and reload require their source owner thread.");
        }
    }
}
