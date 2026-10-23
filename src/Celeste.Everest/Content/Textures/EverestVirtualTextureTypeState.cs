using Celeste.Core.Threading;

namespace Celeste.Everest.Content.Textures
{
    public sealed class EverestVirtualTextureTypeState
    {
        public EverestTextureDataBuffers Buffers { get; private set; }
        public EverestFastTextureLoadingProcess FastLoading { get; private set; }

        public sealed class Factory : ISourceTypeInitializationFactory<EverestVirtualTextureTypeState>
        {
            public EverestVirtualTextureTypeState Allocate()
            {
                return new();
            }

            public void Initialize(EverestVirtualTextureTypeState instance)
            {
                instance.Buffers = new();
                instance.FastLoading = new();
            }
        }
    }
}
