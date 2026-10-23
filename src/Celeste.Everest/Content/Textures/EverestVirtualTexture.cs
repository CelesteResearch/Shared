using System.Threading.Tasks;
using Celeste.Core.Display;
using Celeste.Everest.Content.Assets;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Everest.Content.Textures
{
    public sealed partial class EverestVirtualTexture : VirtualTexture
    {
        private readonly IEverestVirtualTextureEnvironment Environment;
        private bool _Texture_Reloading;
        private bool _Texture_Requesting;
        private bool _Texture_UnloadAfterReload;
        private object _Texture_QueuedLoadLock;
        private ValueTask<SourceTexture2DResource> _Texture_QueuedLoad;
        private bool _Texture_FTLCount;
        private bool _Texture_FTLLoading;
        private uint _Texture_FTLSize;
        public EverestContentAsset Metadata;
        public VirtualTexture Fallback;

        internal EverestVirtualTexture(EverestVirtualContent owner, string path) : base(owner)
        {
            Environment = owner.SourceEnvironment;
            Path = path;
            Name = path;
            InitializeTexture();
        }

        internal EverestVirtualTexture(EverestVirtualContent owner, string name, int width, int height,
            PackedColor color) :
            base(owner)
        {
            Environment = owner.SourceEnvironment;
            Name = name;
            Width = width;
            Height = height;
            this.color = color;
            InitializeTexture();
        }

        internal EverestVirtualTexture(EverestVirtualContent owner, EverestContentAsset metadata) : base(owner)
        {
            Environment = owner.SourceEnvironment;
            Metadata = metadata;
            Name = metadata.PathVirtual;
            InitializeTexture();
        }

        private void InitializeTexture()
        {
            if (!Preload(Environment.IsHeadless) && !Environment.IsHeadless) Reload();
            if (Environment.IsHeadless) Texture = Environment.TextureFactory.CreateTexture(Name, Width, Height);
        }

        public override bool IsDisposed
        {
            get
            {
                if (TextureSafe != null && !TextureSafe.IsDisposed)
                    return TextureSafe.GraphicsDevice.IsDisposed;
                return true;
            }
        }

        public override SourceTexture2DResource TextureSafe
        {
            get
            {
                var textureQueuedLoadLock = _Texture_QueuedLoadLock;
                var flag = false;
                if (textureQueuedLoadLock != null)
                {
                    lock (textureQueuedLoadLock)
                    {
                        if (_Texture_QueuedLoadLock != textureQueuedLoadLock) return Texture;

                        if (Environment.MainThread.IsMainThread)
                        {
                            _Texture_QueuedLoadLock = null;
                            _Texture_Reloading = false;
                            flag = true;
                        }
                    }

                    if (!Environment.MainThread.IsMainThread) return _Texture_QueuedLoad.Result;
                }

                if (_Texture_Reloading || !(Environment.Settings.LazyLoading || flag)) return Texture;

                var texture = Texture;
                if (texture == null || texture.IsDisposed)
                {
                    _Texture_Requesting = true;
                    Reload();
                }

                return Texture;
            }
            set => Texture = value;
        }

        internal bool LoadImmediately
        {
            get
            {
                if (!_Texture_FTLLoading)
                {
                    if (Environment.Settings.ThreadedGL != true) return Environment.MainThread.IsMainThread;

                    return true;
                }

                return false;
            }
        }

        private bool CanPreload
        {
            get
            {
                if (!string.IsNullOrEmpty(Path))
                {
                    var extension = System.IO.Path.GetExtension(Path);
                    if (extension == ".data") return true;

                    if (extension == ".png") return true;

                    return false;
                }

                if (Metadata != null)
                {
                    if (Metadata.Format == "png") return true;

                    return false;
                }

                return false;
            }
        }
    }
}
